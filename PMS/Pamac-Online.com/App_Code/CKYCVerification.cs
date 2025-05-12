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
using System.Data.SqlClient;

/// <summary>
/// Summary description for CKYCVerification
/// </summary>
public class CKYCVerification
{
    private CCommon oCmn;
	public CKYCVerification()
	{
        oCmn = new CCommon();
    }

    #region Property Declaration
    //added by hemangi kambli on 03/10/2007 ----
    private DateTime dtTransStart;
    private DateTime dtTransEnd;
    private string sUserId;
    private string sCentreId;
    private string sProductId;
    private string sClientId;


    //---------add by kanchan--------//
    private string str_LandmarkVerified;
    public string LandmarkVerified
    {
        get { return str_LandmarkVerified; }
        set { str_LandmarkVerified = value; }
    }

    //----------comp-----------//

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

    //// added by abhijeet for kotak //
    private string sProductDealingIn;
    public string ProductDealingIn
    {
        get { return sProductDealingIn; }
        set { sProductDealingIn = value; }
    }


    private string sTurnOver1;
    public string TurnOver1
    {
        get { return sTurnOver1; }
        set { sTurnOver1 = value; }
    }



    private string sdoccumentryPrrof;
    public string doccumentryPrrof
    {
        get { return sdoccumentryPrrof; }
        set { sdoccumentryPrrof = value; }
    }


    private string sNameofindividual;
    public string Nameofindividual
    {
        get { return sNameofindividual; }
        set { sNameofindividual = value; }
    }


    private string sNameofindividualpersonmet;
    public string Nameofindividualpersonmet
    {
        get { return sNameofindividualpersonmet; }
        set { sNameofindividualpersonmet = value; }
    }



    private string sDoccumentryProofFurnished;
    public string DoccumentryProofFurnished
    {
        get { return sDoccumentryProofFurnished; }
        set { sDoccumentryProofFurnished = value; }
    }


    private string sRecommondation;
    public string Recommondation
    {
        get { return sRecommondation; }
        set { sRecommondation = value; }
    }
    //ended by abhijee for kotak//

  


    ////------------------------------------------------

    //Added by SANKET for Kunverji
    private string sOfficeType;
    public string OfficeType
    {
        get { return sOfficeType; }
        set { sOfficeType = value; }
    }

    private string sOCL_distance;
    public string OCL_distance
    {
        get { return sOCL_distance; }
        set { sOCL_distance = value; }
    }

    private string sOfficeInternal;
    public string OfficeInternal
    {
        get { return sOfficeInternal; }
        set { sOfficeInternal = value; }
    }

    private string sTradingexperienceYears;
    public string TradingexperienceYears
    {
        get { return sTradingexperienceYears; }
        set { sTradingexperienceYears = value; }
    }

    private string sAppicantBusiness;
    public string AppicantBusiness
    {
        get { return sAppicantBusiness; }
        set { sAppicantBusiness = value; }
    }

    private string sAddressProofSighted;
    public string AddressProofSighted
    {
        get { return sAddressProofSighted; }
        set { sAddressProofSighted = value; }
    }

    private string sTypeofAddressProof;
    public string TypeofAddressProof
    {
        get { return sTypeofAddressProof; }
        set { sTypeofAddressProof = value; }
    }

    private string sNameofPerson;
    public string NameofPerson
    {
        get { return sNameofPerson; }
        set { sNameofPerson = value; }
    }

    //end for Kunverji


    //added by abhijeet for payzippy//

    private string slegalname;
    public string legalname
    {
        get { return slegalname; }
        set { slegalname = value; }
    }


    private string swarehouseaddress;
    public string warehouseaddress
    {
        get { return swarehouseaddress; }
        set { swarehouseaddress = value; }
    }


    private string svisitno;
    public string visitno
    {
        get { return svisitno; }
        set { svisitno = value; }
    }


    private string sreachable;
    public string reachable
    {
        get { return sreachable; }
        set { sreachable = value; }
    }

    private string ssetuplocation;
    public string setuplocation
    {
        get { return ssetuplocation; }
        set { ssetuplocation = value; }
    }

    private string sboardtype;
    public string boardtype
    {
        get { return sboardtype; }
        set { sboardtype = value; }
    }


    private string sconnectivity;
    public string connectivity
    {
        get { return sconnectivity; }
        set { sconnectivity = value; }
    }


    private string sproperarea;
    public string properarea
    {
        get { return sproperarea; }
        set { sproperarea = value; }
    }


    private string sestablishmentcertificate;
    public string establishmentcertificate
    {
        get { return sestablishmentcertificate; }
        set { sestablishmentcertificate = value; }
    }


    private string stypeoffurnishing;
    public string typeoffurnishing
    {
        get { return stypeoffurnishing; }
        set { stypeoffurnishing = value; }
    }

    private string sPremisesMaintenanceQuality;
    public string PremisesMaintenanceQuality
    {
        get { return sPremisesMaintenanceQuality; }
        set { sPremisesMaintenanceQuality = value; }
    }


    private string schildlabourmarchant;
    public string childlabourmarchant
    {
        get { return schildlabourmarchant; }
        set { schildlabourmarchant = value; }
    }


    private string schildlabourneighbours;
    public string childlabourneighbours
    {
        get { return schildlabourneighbours; }
        set { schildlabourneighbours = value; }
    }


    private string schildlabouremployees;
    public string childlabouremployees
    {
        get { return schildlabouremployees; }
        set { schildlabouremployees = value; }
    }


    private string sproducttype;
    public string producttype
    {
        get { return sproducttype; }
        set { sproducttype = value; }
    }


    private string sLogistics;
    public string Logistics
    {
        get { return sLogistics; }
        set { sLogistics = value; }
    }


    private string sInventory;
    public string Inventory
    {
        get { return sInventory; }
        set { sInventory = value; }
    }


    private string sInventorySize;
    public string InventorySize
    {
        get { return sInventorySize; }
        set { sInventorySize = value; }
    }

    private string sREGISTERATIONPROOF;
    public string REGISTERATIONPROOF
    {
        get { return sREGISTERATIONPROOF; }
        set { sREGISTERATIONPROOF = value; }
    }


    private string sADDITIONALDOCUMENTS;
    public string ADDITIONALDOCUMENTS
    {
        get { return sADDITIONALDOCUMENTS; }
        set { sADDITIONALDOCUMENTS = value; }
    }



    private string sTop1Item;
    public string Top1Item
    {
        get { return sTop1Item; }
        set { sTop1Item = value; }
    }

    private string sTop2Item;
    public string Top2Item
    {
        get { return sTop2Item; }
        set { sTop2Item = value; }
    }

    private string sTop3Item;
    public string Top3Item
    {
        get { return sTop3Item; }
        set { sTop3Item = value; }
    }


    private string sTop4Item;
    public string Top4Item
    {
        get { return sTop4Item; }
        set { sTop4Item = value; }
    }


    private string snameboard;
    public string nameboard
    {
        get { return snameboard; }
        set { snameboard = value; }
    }


    private string sNoofemployee;
    public string Noofemployee
    {
        get { return sNoofemployee; }
        set { sNoofemployee = value; }
    }





    private string sYearsWorkInmarchant;
    public string YearsWorkInmarchant
    {
        get { return sYearsWorkInmarchant; }
        set { sYearsWorkInmarchant = value; }
    }

    private string sYearsWorkInnei;
    public string YearsWorkInnei
    {
        get { return sYearsWorkInnei; }
        set { sYearsWorkInnei = value; }
    }

    private string sYearsWorkInemp;
    public string YearsWorkInemp
    {
        get { return sYearsWorkInemp; }
        set { sYearsWorkInemp = value; }
    }


    private string sIdproof;
    public string Idproof
    {
        get { return sIdproof; }
        set { sIdproof = value; }
    }



    private string sAddressproof;
    public string Addressproof
    {
        get { return sAddressproof; }
        set { sAddressproof = value; }
    }


    private string sworktimedurationfrom;
    public string worktimedurationfrom
    {
        get { return sworktimedurationfrom; }
        set { sworktimedurationfrom = value; }
    }


    private string sworktimedurationto;
    public string worktimedurationto
    {
        get { return sworktimedurationto; }
        set { sworktimedurationto = value; }
    }



    private string sworktimedurationdays;
    public string worktimedurationdays
    {
        get { return sworktimedurationdays; }
        set { sworktimedurationdays = value; }
    }

    private string sfireexepresent;
    public string fireexepresent
    {
        get { return sfireexepresent; }
        set { sfireexepresent = value; }
    }
    //ended by abhijeet for payzippy//

    //// added by abhijeet //

    private string strtelecallernamee;
    public string telecallername
    {
        get { return strEntityType; }
        set { strEntityType = value; }
    }

    private string strtelecalleraddress;
    public string telecalleraddress
    {
        get { return strtelecalleraddress; }
        set { strtelecalleraddress = value; }
    }



    //private string strtelecallerphno;
    //public string telecallerphno
    //{
    //    get { return strtelecallerphno; }
    //    set { strtelecallerphno = value; }
    //}


    private string strtelecallerloc;
    public string telecallerloc
    {
        get { return strtelecallerloc; }
        set { strtelecallerloc = value; }
    }


    private string strvisitreason;
    public string visitreason
    {
        get { return strvisitreason; }
        set { strvisitreason = value; }
    }


    private string strpersonmetreason;
    public string personmetreason
    {
        get { return strpersonmetreason; }
        set { strpersonmetreason = value; }
    }


    private string strsetupdetails;
    public string setupdetails
    {
        get { return strsetupdetails; }
        set { strsetupdetails = value; }
    }


    private string strpersonassociateofHDFCBank;
    public string personassociateofHDFCBank
    {
        get { return strpersonassociateofHDFCBank; }
        set { strpersonassociateofHDFCBank = value; }
    }


    private string strpersonnotassociateofHDFCBank;
    public string personnotassociateofHDFCBank
    {
        get { return strpersonnotassociateofHDFCBank; }
        set { strpersonnotassociateofHDFCBank = value; }
    }


    private string strptheReasonofCallingBehalfofHDFCBank;
    public string theReasonofCallingBehalfofHDFCBank
    {
        get { return strptheReasonofCallingBehalfofHDFCBank; }
        set { strptheReasonofCallingBehalfofHDFCBank = value; }
    }

    private string stranyothrinformation;
    public string anyothrinformation
    {
        get { return stranyothrinformation; }
        set { stranyothrinformation = value; }
    }

    private string strvisited;
    public string visited
    {
        get { return strvisited; }
        set { strvisited = value; }
    }

    private string strpersonmet;
    public string personmet
    {
        get { return strpersonmet; }
        set { strpersonmet = value; }
    }





    //// endded by abhijeet //






    private string strEntityType;
    public string EntityType 
    {
        get { return strEntityType ; }
        set { strEntityType = value; }
    }
    private string strbusinessActivity;
    public string BusinessActivity
    {
        get { return strbusinessActivity; }
        set { strbusinessActivity = value; }
    }
    private string strSpervisorName;
    public string SupervisorName 
    {
        get { return strSpervisorName; }
        set { strSpervisorName = value; }
    }
    private string dtSupervisordatetime;
    public string SupervisorDateTime
    {
         
        get
        {
          
            return dtSupervisordatetime;
        }

        set
        {
            if ( value != null)
             dtSupervisordatetime = value;
            
         }
    }
    private string dtVerifierDatetime;
    public string VerifierDatetime
    {
        get
        {
           
            return dtVerifierDatetime;
        }
        set
        {
            if (value != null)
                dtVerifierDatetime = value;
           
        }
    }
    private string strTeleRemark;
    public string TeleRemark
    {
        get { return strTeleRemark; }
        set { strTeleRemark = value; }
    }
    private string strOverallRemark;
    public string OverallRemark
    {
        get { return strOverallRemark; }
        set { strOverallRemark = value; }
    }


    //Added by SANKET for HDFC Ergo
    private string strStandardRemark;
    public string StandardRemark
    {
        get { return strStandardRemark; }
        set { strStandardRemark = value; }
    }
    //END


    private string strTelephoneNoOfCAFirm;

    public string TelephoneNoOfCAFirm 
    {
        get { return strTelephoneNoOfCAFirm ; }
        set { strTelephoneNoOfCAFirm = value; }
    }

    private string strNoOfYearsInCurrentEmployment ;
    public string NoOfYearsInCurrentEmployment 
    {
        get { return strNoOfYearsInCurrentEmployment; }
        set { strNoOfYearsInCurrentEmployment = value; }
    }

    private string sIfOthersPremisespecify;
    public string IfOthersPremisespecify
    {
        get { return sIfOthersPremisespecify; }
        set { sIfOthersPremisespecify = value; }
    }

    private string sCaseId;
    public string CaseId
    {
        get { return sCaseId; }
        set { sCaseId = value; }
    }
    private string sCaseStatusId;
    public string CaseStatusId
    {
        get { return sCaseStatusId; }
        set { sCaseStatusId = value; }
    }

    private string sVerificationTypeId;
    public string VerificationTypeId
    {
        get { return sVerificationTypeId; }
        set { sVerificationTypeId = value; }
    }

    private string sRefNo;
    public string RefNo
    {
        get { return sRefNo; }
        set { sRefNo = value; }
    }

    private string sCompanyType;
    public string CompanyType
    {
        get { return sCompanyType; }
        set { sCompanyType = value; }
    }

    private string sNameOfFirm;
    public string NameOfFirm
    {
        get { return sNameOfFirm; }
        set { sNameOfFirm = value; }
    }

    private string sBusinessAddress;
    public string BusinessAddress
    {
        get { return sBusinessAddress; }
        set { sBusinessAddress = value; }
    }

    private string sBusinessPicode;
    public string BusinessPicode
    {
        get { return sBusinessPicode; }
        set { sBusinessPicode = value; }
    }

    private string sBusinessTelNo;
    public string BusinessTelNo
    {
        get { return sBusinessTelNo; }
        set { sBusinessTelNo = value; }
    }

    private string sPersonContacted;
    public string PersonContacted
    {
        get { return sPersonContacted; }
        set { sPersonContacted = value; }
    }
    private string Strrvcomment;
    public string NameRVComment
    {
        get { return Strrvcomment; }
        set { Strrvcomment = value; }
    }
    private string sNameOfPersonContacted;
    public string NameOfPersonContacted
    {
        get { return sNameOfPersonContacted; }
        set { sNameOfPersonContacted = value; }
    }

    private string sDesignation;
    public string Designation
    {
        get { return sDesignation; }
        set { sDesignation = value; }
    }

    private string sPremiseLocation;
    public string PremiseLocation
    {
        get { return sPremiseLocation; }
        set { sPremiseLocation = value; }
    }

    private string sProminetLandmark;
    public string ProminetLandmark
    {
        get { return sProminetLandmark; }
        set { sProminetLandmark = value; }
    }

    private string sAddressVerifiedIs;
    public string AddressVerifiedIs
    {
        get { return sAddressVerifiedIs; }
        set { sAddressVerifiedIs = value; }
    }

    private string sHowLongInBusiness;
    public string HowLongInBusiness
    {
        get { return sHowLongInBusiness; }
        set { sHowLongInBusiness = value; }
    }
    private string sRmFormat;
    public string RmFormat
    {
        get { return sRmFormat; }
        set { sRmFormat = value; }
    }
    private string sBllCase;
    public string BllCase
    {
        get { return sBllCase; }
        set { sBllCase = value; }
    }
    private string sBllSvr;
    public string BllSvr
    {
        get { return sBllSvr; }
        set { sBllSvr = value; }
    }
    private string sNocName;
    public string NocName
    {
        get { return sNocName; }
        set { sNocName = value; }
    }
    private string sTvTele;
    public string TvTele
    {
        get { return sTvTele; }
        set { sTvTele = value; }
    }
    private string sTvPerson;
    public string TvPerson
    {
        get { return sTvPerson; }
        set { sTvPerson = value; }
    }
    private string sTvRelation;
    public string TvRelation
    {
        get { return sTvRelation; }
        set { sTvRelation = value; }
    }
    private string sTvConAdd;
    public string TvConAdd
    {
        get { return sTvConAdd; }
        set { sTvConAdd = value; }
    }
    private string sTvCustId;
    public string TvCustId
    {
        get { return sTvCustId; }
        set { sTvCustId = value; }
    }
    private string sIfNamePLate;
    public string IfNamePLate
    {
        get { return sIfNamePLate; }
        set { sIfNamePLate = value; }
    }
    private string sNameOfficer;
    public string NameOfficer
    {
        get { return sNameOfficer; }
        set { sNameOfficer = value; }
    }
    private string sSiteVerifier;
    public string SiteVerifier
    {
        get { return sSiteVerifier; }
        set { sSiteVerifier = value; }
    }
    private string sSign1;
    public string Sign1
    {
        get { return sSign1; }
        set { sSign1 = value; }
    }
    private string sSign2;
    public string Sign2
    {
        get { return sSign2; }
        set { sSign2 = value; }
    }
    private string sSign3;
    public string Sign3
    {
        get { return sSign3; }
        set { sSign3 = value; }
    }
    private string sSign4;
    public string Sign4
    {
        get { return sSign4; }
        set { sSign4 = value; }
    }
    private string sSign5;
    public string Sign5
    {
        get { return sSign5; }
        set { sSign5 = value; }
    }
    private string sSign6;
    public string Sign6
    {
        get { return sSign6; }
        set { sSign6 = value; }
    }
    private string sDesgBO;
    public string DesgBO
    {
        get { return sDesgBO; }
        set { sDesgBO = value; }
    }    
    
    private string sAccOpen;
    public string AccOpen
    {
        get { return sAccOpen; }
        set { sAccOpen = value; }
    }
    private string sRetDel;
    public string RetDel
    {
        get { return sRetDel; }
        set { sRetDel = value; }
    }

    private string sDesBuild;
    public string DesBuild
    {
        get { return sDesBuild; }
        set { sDesBuild = value; }
    }
    private string sBspName;
    public string BspName
    {
        get { return sBspName; }
        set { sBspName = value; }
    }
    private string sBuilding;
    public string Building
    {
        get { return sBuilding; }
        set { sBuilding = value; }
    }

    private string sAreaOfPremises;
    public string AreaOfPremises
    {
        get { return sAreaOfPremises; }
        set { sAreaOfPremises = value; }
    }

    private string sOwnershipOfPremises;
    public string OwnershipOfPremises
    {
        get { return sOwnershipOfPremises; }
        set { sOwnershipOfPremises = value; }
    }

    private string sTypeOfPremises;
    public string TypeOfPremises
    {
        get { return sTypeOfPremises; }
        set { sTypeOfPremises = value; }
    }

    private string sContactPerson;
    public string ContactPerson
    {
        get { return sContactPerson; }
        set { sContactPerson = value; }
    }

    private string sNatureOfBusiness;
    public string NatureOfBusiness
    {
        get { return sNatureOfBusiness; }
        set { sNatureOfBusiness = value; }
    }

    private string sFirmSightedBoard;
    public string FirmSightedBoard
    {
        get { return sFirmSightedBoard; }
        set { sFirmSightedBoard = value; }
    }

    private string sSignBoardSightedRemark;
    public string SignBoardSightedRemark
    {
        get { return sSignBoardSightedRemark; }
        set { sSignBoardSightedRemark = value; }
    }

    private string sTypeOfDocSighted;
    public string TypeOfDocSighted
    {
        get { return sTypeOfDocSighted; }
        set { sTypeOfDocSighted = value; }
    }

    private string sOtherDocSightedRemark;
    public string OtherDocSightedRemark
    {
        get { return sOtherDocSightedRemark; }
        set { sOtherDocSightedRemark = value; }
    }
    private string sNatureBuss;
    public string NatureBuss
    {
        get { return sNatureBuss;}
        set { sNatureBuss = value; }
    }

    private string sUsedPagesSightedDate;
    public string UsedPagesSightedDate
    {
        get { return sUsedPagesSightedDate; }
        set { sUsedPagesSightedDate = value; }
    }

    private string sIssuedTo;
    public string IssuedTo
    {
        get { return sIssuedTo; }
        set { sIssuedTo = value; }
    }

    private string sInitialInvoiceSightedNo;
    public string InitialInvoiceSightedNo
    {
        get { return sInitialInvoiceSightedNo; }
        set { sInitialInvoiceSightedNo = value; }
    }

    private string sInitialInvoiceSightedDate;
    public string InitialInvoiceSightedDate
    {
        get { return sInitialInvoiceSightedDate; }
        set { sInitialInvoiceSightedDate = value; }
    }

    private string sInitialInvoiceSightedIssuedTo;
    public string InitialInvoiceSightedIssuedTo
    {
        get { return sInitialInvoiceSightedIssuedTo; }
        set { sInitialInvoiceSightedIssuedTo = value; }
    }

    private string sThirdPartyInvoiceNo;
    public string ThirdPartyInvoiceNo
    {
        get { return sThirdPartyInvoiceNo; }
        set { sThirdPartyInvoiceNo = value; }
    }

    private string sThirdPartyInvoiceDate;
    public string ThirdPartyInvoiceDate
    {
        get { return sThirdPartyInvoiceDate; }
        set { sThirdPartyInvoiceDate = value; }
    }

    private string sThirdPartyInvoiceIssuedBy;
    public string ThirdPartyInvoiceIssuedBy
    {
        get { return sThirdPartyInvoiceIssuedBy; }
        set { sThirdPartyInvoiceIssuedBy = value; }
    }

    private string sThirdPartyAddress;
    public string ThirdPartyAddress
    {
        get { return sThirdPartyAddress; }
        set { sThirdPartyAddress = value; }
    }

    private string sAnyOthDet;
    public string AnyOthDet
    {
        get { return sAnyOthDet; }
        set { sAnyOthDet = value; }
    }

    private string sRelationshipBTNEntity;
    public string RelationshipBTNEntity
    {
        get { return sRelationshipBTNEntity; }
        set { sRelationshipBTNEntity = value; }
    }

    private string sBusinessOwnership;
    public string BusinessOwnership
    {
        get { return sBusinessOwnership; }
        set { sBusinessOwnership = value; }
    }

    private string sLevelOfBusinssActivity;
    public string LevelOfBusinssActivity
    {
        get { return sLevelOfBusinssActivity; }
        set { sLevelOfBusinssActivity = value; }
    }

    private string sNoOfEmployees;
    public string NoOfEmployees
    {
        get { return sNoOfEmployees; }
        set { sNoOfEmployees = value; }
    }

    private string sBusinessEquipSighted;
    public string BusinessEquipSighted
    {
        get { return sBusinessEquipSighted; }
        set { sBusinessEquipSighted = value; }
    }

    private string sVerifierName;
    public string VerifierName
    {
        get { return sVerifierName; }
        set { sVerifierName = value; }
    }

    //private string sVerifierDate;
    //public string VerifierDate
    //{
    //    get { return sVerifierDate; }
    //    set { sVerifierDate = value; }
    //}

    //private string sVerifierTime;
    //public string VerifierTime
    //{
    //    get { return sVerifierTime; }
    //    set { sVerifierTime = value; }
    //}

    private string sDateOfReceipt;
    public string DateOfReceipt
    {
        get { return sDateOfReceipt; }
        set { sDateOfReceipt = value; }
    }

    private string sNameOfApplicant;
    public string NameOfApplicant
    {
        get { return sNameOfApplicant; }
        set { sNameOfApplicant = value; }
    }

    private string sAddress;
    public string Address
    {
        get { return sAddress; }
        set { sAddress = value; }
    }

    private string sPhoneNo;
    public string PhoneNo
    {
        get { return sPhoneNo; }
        set { sPhoneNo = value; }
    }

    private string sMobileNo;
    public string MobileNo
    {
        get { return sMobileNo; }
        set { sMobileNo = value; }
    }

    private string sEmailId;
    public string EmailId
    {
        get { return sEmailId; }
        set { sEmailId = value; }
    }

    private string sDateOfBirth;
    public string DateOfBirth
    {
        get { return sDateOfBirth; }
        set { sDateOfBirth = value; }
    }
    private string sNeighbour;
    public string Neighbour
    {
        get { return sNeighbour;}
        set { sNeighbour = value; }
    }
    private string sMaritalStatus;
    public string MaritalStatus
    {
        get { return sMaritalStatus; }
        set { sMaritalStatus = value; }
    }

    private string sNameDisplayOnNameBoard;
    public string NameDisplayOnNameBoard
    {
        get { return sNameDisplayOnNameBoard; }
        set { sNameDisplayOnNameBoard = value; }
    }

    private string sRelationshipWithApplicant;
    public string RelationshipWithApplicant
    {
        get { return sRelationshipWithApplicant; }
        set { sRelationshipWithApplicant = value; }
    }

    private string sStayingSinceAtResi;
    public string StayingSinceAtResi
    {
        get { return sStayingSinceAtResi; }
        set { sStayingSinceAtResi = value; }
    }

    private string sStatusOfDematAcct;
    public string StatusOfDematAcct
    {
        get { return sStatusOfDematAcct; }
        set { sStatusOfDematAcct = value; }
    }

    private string sNameOfDematAcct;
    public string NameOfDematAcct
    {
        get { return sNameOfDematAcct; }
        set { sNameOfDematAcct = value; }
    }

    private string sDoingBroken;
    public string DoingBroken
    {
        get { return sDoingBroken; }
        set { sDoingBroken = value; }
    }

    private string sAttituteOfPersonContacted;
    public string AttituteOfPersonContacted
    {
        get { return sAttituteOfPersonContacted; }
        set { sAttituteOfPersonContacted = value; }
    }

    private string sRating;
    public string Rating
    {
        get { return sRating; }
        set { sRating = value; }
    }

    private string sStatus;
    public string Status
    {
        get { return sStatus; }
        set { sStatus = value; }
    }

    //private string sSupervisorName;
    //public string SupervisorName
    //{
    //    get { return sSupervisorName; }
    //    set { sSupervisorName = value; }
    //}

    //private string sSupervisorDate;
    //public string SupervisorDate
    //{
    //    get { return sSupervisorDate; }
    //    set { sSupervisorDate = value; }
    //}

    //private string sSupervisorTime;
    //public string SupervisorTime
    //{
    //    get { return sSupervisorTime; }
    //    set { sSupervisorTime = value; }
    //}

    private string sSendDate;
    public string SendDate
    {
        get { return sSendDate; }
        set { sSendDate = value; }
    }

    private string sProduct;
    public string Product
    {
        get { return sProduct; }
        set { sProduct = value; }
    }

    private string sNameOfVerifyAgent;
    public string NameOfVerifyAgent
    {
        get { return sNameOfVerifyAgent; }
        set { sNameOfVerifyAgent = value; }
    }

    private string sResidenceAddress;
    public string ResidenceAddress
    {
        get { return sResidenceAddress; }
        set { sResidenceAddress = value; }
    }

    private string sResiPincode;
    public string ResiPincode
    {
        get { return sResiPincode; }
        set { sResiPincode = value; }
    }

    private string sResiTelNo;
    public string ResiTelNo
    {
        get { return sResiTelNo; }
        set { sResiTelNo = value; }
    }

    private string sStock;
    public string Stock
    {
        get { return sStock; }
        set { sStock = value; }
    }

    private string sResiLandmark;
    public string ResiLandmark
    {
        get { return sResiLandmark; }
        set { sResiLandmark = value; }
    }

    private string sPermanentAddress;
    public string PermanentAddress
    {
        get { return sPermanentAddress; }
        set { sPermanentAddress = value; }
    }

    private string sPermanentPincode;
    public string PermanentPincode
    {
        get { return sPermanentPincode; }
        set { sPermanentPincode = value; }
    }

    private string sPermanentTelNo;
    public string PermanentTelNo
    {
        get { return sPermanentTelNo; }
        set { sPermanentTelNo = value; }
    }

    private string sBusinessOccupDetail;
    public string BusinessOccupDetail
    {
        get { return sBusinessOccupDetail; }
        set { sBusinessOccupDetail = value; }
    }

    private string sCityLimit;
    public string CityLimit
    {
        get { return sCityLimit;}
        set { sCityLimit = value; }
    }

    private string sPlaceVisited;
    public string PlaceVisited
    {
        get { return sPlaceVisited; }
        set { sPlaceVisited = value; }
    }

   
    private string sAreaOfResidence;
    public string AreaOfResidence
    {
        get { return sAreaOfResidence; }
        set { sAreaOfResidence = value; }
    }

    private string sLocatingAddress;
    public string LocatingAddress
    {
        get { return sLocatingAddress; }
        set { sLocatingAddress = value; }
    }

    private string sIfOfficeBusiActivitySeen;
    public string IfOfficeBusiActivitySeen
    {
        get { return sIfOfficeBusiActivitySeen; }
        set { sIfOfficeBusiActivitySeen = value; }
    }

    private string sDescriptionOfResi;
    public string DescriptionOfResi
    {
        get { return sDescriptionOfResi; }
        set { sDescriptionOfResi = value; }
    }

    private string sGeneralComment;
    public string GeneralComment
    {
        get { return sGeneralComment; }
        set { sGeneralComment = value; }
    }

    private string sNameOfAccount;
    public string NameOfAccount
    {
        get { return sNameOfAccount; }
        set { sNameOfAccount = value; }
    }

    private string sRequestNo;
    public string RequestNo
    {
        get { return sRequestNo; }
        set { sRequestNo = value; }
    }

    private string sNameOfCAFirm;
    public string NameOfCAFirm
    {
        get { return sNameOfCAFirm; }
        set { sNameOfCAFirm = value; }
    }

    private string sAddressOfCAFirm;
    public string AddressOfCAFirm
    {
        get { return sAddressOfCAFirm; }
        set { sAddressOfCAFirm = value; }
    }

    private string sDoesFirmExistAtAddress;
    public string DoesFirmExistAtAddress
    {
        get { return sDoesFirmExistAtAddress; }
        set { sDoesFirmExistAtAddress = value; }
    }

    private string sIsFirmCAFirm;
    public string IsFirmCAFirm
    {
        get { return sIsFirmCAFirm; }
        set { sIsFirmCAFirm = value; }
    }

    private string sNameOfPersonWhoIssuedCACertificate;
    public string NameOfPersonWhoIssuedCACertificate
    {
        get { return sNameOfPersonWhoIssuedCACertificate; }
        set { sNameOfPersonWhoIssuedCACertificate = value; }
    }

    private string sIsPersonPractisingCasInFirm;
    public string IsPersonPractisingCasInFirm
    {
        get { return sIsPersonPractisingCasInFirm; }
        set { sIsPersonPractisingCasInFirm = value; }
    }

    private string sWasPersonSpokenTo;
    public string WasPersonSpokenTo
    {
        get { return sWasPersonSpokenTo; }
        set { sWasPersonSpokenTo = value; }
    }

    private string sConfirmCACertificateIssued;
    public string ConfirmCACertificateIssued
    {
        get { return sConfirmCACertificateIssued; }
        set { sConfirmCACertificateIssued = value; }
    }

    private string sInConclusiveReason;
    public string InConclusiveReason
    {
        get { return sInConclusiveReason; }
        set { sInConclusiveReason = value; }
    }

   /// <summary>
   /// ///////////add by santosh for TCM//////////////
   /// 
    private string sWebsite;
    public string Website
    {
        get { return sWebsite; }
        set { sWebsite = value; }
    }

    private string sCompRegiCheckSince;
    public string CompRegiCheckSince
    {
        get { return sCompRegiCheckSince; }
        set { sCompRegiCheckSince = value; }
    }

    private string sCompRegiCheckSinceRegNo;
    public string CompRegiCheckSinceRegNo
    {
        get { return sCompRegiCheckSinceRegNo; }
        set { sCompRegiCheckSinceRegNo = value; }
    }

    private string sCompRegiCheckRemark;
    public string CompRegiCheckRemark
    {
        get { return sCompRegiCheckRemark; }
        set { sCompRegiCheckRemark = value; }
    }

    private string sLocation_Profile;
    public string Location_Profile
    {
        get { return sLocation_Profile; }
        set { sLocation_Profile = value; }
    }

    private string sbldg_Profile;
    public string bldg_Profile
    {
        get { return sbldg_Profile; }
        set { sbldg_Profile = value; }
    }

    private string sFlr_Profile;
    public string Flr_Profile
    {
        get { return sFlr_Profile; }
        set { sFlr_Profile = value; }
    }

    private string sFlr_Profile_left_neigh;
    public string Flr_Profile_left_neigh
    {
        get { return sFlr_Profile_left_neigh; }
        set { sFlr_Profile_left_neigh = value; }
    }

    private string sFlr_Profile_Flr_above;
    public string Flr_Profile_Flr_above
    {
        get { return sFlr_Profile_Flr_above; }
        set { sFlr_Profile_Flr_above = value; }
    }

    private string sFlr_Profile_Flr_belwo;
    public string Flr_Profile_Flr_belwo
    {
        get { return sFlr_Profile_Flr_belwo; }
        set { sFlr_Profile_Flr_belwo = value; }
    }

    private string sName_board_out_Office;
    public string Name_board_out_Office
    {
        get { return sName_board_out_Office; }
        set { sName_board_out_Office = value; }
    }

    private string sName_board_Lobby_area;
    public string Name_board_Lobby_area
    {
        get { return sName_board_Lobby_area; }
        set { sName_board_Lobby_area = value; }
    }

    private string sasso_company;
    public string asso_company
    {
        get { return sasso_company; }
        set { sasso_company = value; }
    }

    private string sGen_Interior;
    public string Gen_Interior
    {
        get { return sGen_Interior; }
        set { sGen_Interior = value; }
    }

    private string sNo_workstations;
    public string No_workstations
    {
        get { return sNo_workstations; }
        set { sNo_workstations = value; }
    }

    private string sowner_cabin;
    public string owner_cabin
    {
        get { return sowner_cabin; }
        set { sowner_cabin = value; }
    }

    private string slandlord;
    public string landlord
    {
        get { return slandlord; }
        set { slandlord = value; }
    }

    private string sProppery_resi;
    public string Proppery_resi
    {
        get { return sProppery_resi; }
        set { sProppery_resi = value; }
    }

    private string sProppery_comm;
    public string Proppery_comm
    {
        get { return sProppery_comm; }
        set { sProppery_comm = value; }
    }

    private string sProppery_shop;
    public string Proppery_shop
    {
        get { return sProppery_shop; }
        set { sProppery_shop = value; }
    }

    ////////end code////////////////////
   /// </summary>

    private string sProprietor_partener_met;
    public string ProprietorPartenerMet
    {
        get { return sProprietor_partener_met; }
        set { sProprietor_partener_met = value; }
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
    private string strSubRemark;
    public string SubRemark
    {
        get
        {
            return strSubRemark;
        }
        set
        {
            strSubRemark = value;
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
    private string strNameOnSignBoard;
    public string NameOnSignBoard
    {
        get
        {
            return strNameOnSignBoard;
        }
        set
        {
            strNameOnSignBoard = value;
        }
    }
    private string strHowTheConcernIsRelated;
    public string HowTheConcernIsRelated
    {
        get
        {
            return strHowTheConcernIsRelated;
        }
        set
        {
            strHowTheConcernIsRelated = value;
        }
    }
 private string strConcernRelatedName;
    public string ConcernRelatedName 
    {
        get
        {
            return strConcernRelatedName ;
        }
        set
        {
             strConcernRelatedName = value;
        }
    }
 private string strFamilyMemberIs;
    public string FamilyMemberIs 
    {
        get
        {
            return strFamilyMemberIs ;
        }
        set
        {
             strFamilyMemberIs = value;
        }
    }
 private string strFamilyMemberName;
    public string FamilyMemberName 
    {
        get
        {
            return strFamilyMemberName  ;
        }
        set
        {
             strFamilyMemberName = value;
        }
    }
 private string strFamilyMemberRelationship;
    public string FamilyMemberRelationship
    {
        get
        {
            return strFamilyMemberRelationship;
        }
        set
        {
            strFamilyMemberRelationship = value;
        }
    }
 private string strHavingDematAccountWithOtherInstitution;
    public string HavingDematAccountWithOtherInstitution
    {
        get
        {
            return strHavingDematAccountWithOtherInstitution;
        }
        set
        {
             strHavingDematAccountWithOtherInstitution = value;
        }
    }
 private string strNameOfDP;
    public string NameOfDP 
    {
        get
        {
            return strNameOfDP;
        }
        set
        {
            strNameOfDP = value;
        }
    }

    private string strHavingSMEAccountWithOtherInstitution;
    public string HavingSMEAccountWithOtherInstitution
    {
        get
        {
            return strHavingSMEAccountWithOtherInstitution;
        }
        set
        {
            strHavingSMEAccountWithOtherInstitution = value;
        }
    }
    private string strNameOfInstitution;
    public string NameOfInstitution
    {
        get
        {
            return strNameOfInstitution;
        }
        set
        {
            strNameOfInstitution = value;
        }
    }
 
 
    private string strNamePlateofApplicantSighted;
    public string NamePlateofApplicantSighted 
    {
        get
        {
            return strNamePlateofApplicantSighted;
        }
        set
        {
            strNamePlateofApplicantSighted = value;
        }
    }
    
    

 //added by kamal matekar..

    private string sType_Org;
    public string Type_Org
    {
        get { return sType_Org;}
        set { sType_Org= value; }
    }

    private string sCard_No;
    public string Card_No
    {
        get { return sCard_No;}
        set { sCard_No= value; }
    }

    private string sBuss_Proof_Seen;
    public string Buss_Proof_Seen
    {
        get { return sBuss_Proof_Seen;}
        set {sBuss_Proof_Seen= value; }
    }

    private string sLocality_Type;
    public string Locality_Type
    {
        get { return sLocality_Type;}
        set { sLocality_Type= value; }
    }

    private string sEquipmentSeen_OR_Shift_Arrangement;
    public string EquipmentSeen_OR_Shift_Arrangement
    {
        get { return sEquipmentSeen_OR_Shift_Arrangement;}
        set { sEquipmentSeen_OR_Shift_Arrangement= value; }
    }

    private string sObservation_If_NotRecommended;
    public string Observation_If_NotRecommended
    {
        get { return sObservation_If_NotRecommended; }
        set { sObservation_If_NotRecommended= value; }
    }

    //ended by kamal matekar

    //----added by Kamal Matekar For HDFC_Liab pdf format-------------
    private string sNameAddressNeighbour;
    public string NameAddressNeighbour
    {
        get { return sNameAddressNeighbour; }
        set { sNameAddressNeighbour = value; }
    }
    private string sDocVeri;
    public string DocVeri
    {
        get { return sDocVeri; }
        set { sDocVeri = value; }
    }
    private string sNeighAware;
    public string NeighAware
    {
        get { return sNeighAware; }
        set { sNeighAware = value; }
    }
    private string sAuthoSign;
    public string AuthoSign
    {
        get { return sAuthoSign; }
        set { sAuthoSign = value; }
    }

    private string sDoNeighbourKnowTheCustomerForFemu;
    public string DoNeighbourKnowTheCustomerForFemu
    {
        get { return sDoNeighbourKnowTheCustomerForFemu; }
        set { sDoNeighbourKnowTheCustomerForFemu = value; }
    }

    private string sLocality;
    public string Locality
    {
        get { return sLocality; }
        set { sLocality = value; }
    }
    private string sTrigSVR;
    public string TrigSVR
    {
        get { return sTrigSVR; }
        set { sTrigSVR = value; }
    }
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
    private string sRmName;
    public string RmName
    {
        get { return sRmName; }
        set { sRmName = value; }
    }
    private string sRmCode;
    public string RmCode
    {
        get { return sRmCode; }
        set { sRmCode = value; }
    }
    private string sAccountNo;
    public string AccountNo
    {
        get { return sAccountNo; }
        set { sAccountNo = value; }
    }

    private string sBusinessEquipSightedFemu;
    public string BusinessEquipSightedFemu
    {
        get { return sBusinessEquipSightedFemu; }
        set { sBusinessEquipSightedFemu = value; }
    }
   
    ///ended by kamal matekar  
    //Added by Manoj
    private string sNoOfEmp;
    public string NoOfEmp
    {
        get { return sNoOfEmp; }
        set { sNoOfEmp = value; }
    }
    private string sNoOfComputer;
    public string NoOfComputer
    {
        get { return sNoOfComputer; }
        set { sNoOfComputer = value; }
    }
    private string sNoOfTelephone;
    public string NoOfTelephone
    {
        get { return sNoOfTelephone; }
        set { sNoOfTelephone = value; }
    }
    private string sNoOfFloor;
    public string NoOfFloor
    {
        get { return sNoOfFloor; }
        set { sNoOfFloor = value; }
    }
    private string scustomerexiswhichfloor;
    public string customerexiswhichfloor
    {
        get { return scustomerexiswhichfloor; }
        set { scustomerexiswhichfloor = value; }
    }
    private string sConfirmationaddress;
    public string Confirmationaddress
    {
        get { return sConfirmationaddress; }
        set { sConfirmationaddress = value; }
    }
    private string sThiredpartyconfirmation;
    public string Thiredpartyconfirmation
    {
        get { return sThiredpartyconfirmation; }
        set { sThiredpartyconfirmation = value; }
    }
    private string sOwnershipofresidence;
    public string Ownershipofresidence
    {
        get { return sOwnershipofresidence; }
        set { sOwnershipofresidence = value; }
    }
    private string sRationcardavailable;
    public string Rationcardavailable
    {
        get { return sRationcardavailable; }
        set { sRationcardavailable = value; }
    }

    private string sMetToapplicant;
    public string MetToapplicant
    {
        get { return sMetToapplicant; }
        set { sMetToapplicant = value; }
    }
    //Added by Manoj Jadhav

    private string sAreaID;
    public string AreaID
    {
        get { return sAreaID; }
        set { sAreaID = value; }
    }
    //Ended by Manoj Jadhav
    private string sDifferncesfound;
    public string Differncesfound
    {
        get { return sDifferncesfound; }
        set { sDifferncesfound = value; }
    }
    private string sActiontaken;
    public string Actiontaken
    {
        get { return sActiontaken; }
        set { sActiontaken = value; }
    }
    private string sOccuption;
    public string Occuption
    {
        get { return sOccuption; }
        set { sOccuption = value; }
    }
    private string sOccupationdetails;
    public string Occupationdetails
    {
        get { return sOccupationdetails; }
        set { sOccupationdetails = value; }
    }
    private string sNATUREOFDSCREPANCY;
    public string NATUREOFDSCREPANCY
    {
        get { return sNATUREOFDSCREPANCY; }
        set { sNATUREOFDSCREPANCY = value; }
    }
    //Ended by Manoj
    private string sapplicantstayheare;
    public string applicantstayheare
    {
        get { return sapplicantstayheare; }
        set { sapplicantstayheare = value; }
    }

    private string sOwnership;
    public string Ownership
    {
        get { return sOwnership; }
        set { sOwnership = value; }
    }

    private string sTradingexperiencel;
    public string Tradingexperiencel
    {
        get { return sTradingexperiencel; }
        set { sTradingexperiencel = value; }
    }

    private string sNoofmembers;
    public string Noofmembers
    {
        get { return sNoofmembers; }
        set { sNoofmembers = value; }
    }

    private string svehical;
    public string vehical
    {
        get { return svehical; }
        set { svehical = value; }
    }



    private string sIfSalnameoftheoragnization;
    public string IfSalnameoftheoragnization
    {
        get { return sIfSalnameoftheoragnization; }
        set { sIfSalnameoftheoragnization = value; }
    }

    private string sIfBusinessnatureofbusiness;
    public string IfBusinessnatureofbusiness
    {
        get { return sIfBusinessnatureofbusiness; }
        set { sIfBusinessnatureofbusiness = value; }
    }

    private string scarpark;
    public string carpark
    {
        get { return scarpark; }
        set { scarpark = value; }
    }

    private string sTypeofResidence;
    public string TypeofResidence
    {
        get { return sTypeofResidence; }
        set { sTypeofResidence = value; }
    }

    private string sEquipInOffice;
    public string EquipInOffice
    {
        get { return sEquipInOffice; }
        set { sEquipInOffice = value; }
    }

    private string sResidenceInternal;
    public string ResidenceInternal
    {
        get { return sResidenceInternal; }
        set { sResidenceInternal = value; }
    }

    private string sConstruction;
    public string Construction
    {
        get { return sConstruction; }
        set { sConstruction = value; }
    }

    private string stypeofflooring;
    public string typeofflooring
    {
        get { return stypeofflooring; }
        set { stypeofflooring = value; }
    }

    private string sTypeOfRoofing;
    public string TypeOfRoofing
    {
        get { return sTypeOfRoofing; }
        set { sTypeOfRoofing = value; }
    }

    private string sStandardofliving;
    public string Standardofliving
    {
        get { return sStandardofliving; }
        set { sStandardofliving = value; }
    }

    private string sAssets;
    public string Assets
    {
        get { return sAssets; }
        set { sAssets = value; }
    }

    private string sAnydisplayofpoliticalpartyseen;
    public string Anydisplayofpoliticalpartyseen
    {
        get { return sAnydisplayofpoliticalpartyseen; }
        set { sAnydisplayofpoliticalpartyseen = value; }
    }

    private string sInpersonverificationwiththeapplicant;
    public string Inpersonverificationwiththeapplicant
    {
        get { return sInpersonverificationwiththeapplicant; }
        set { sInpersonverificationwiththeapplicant = value; }
    }

    private string sProducts;
    public string Products
    {
        get { return sProducts; }
        set { sProducts = value; }
    }

    private string sReasonsfornotrecommended;
    public string Reasonsfornotrecommended
    {
        get { return sReasonsfornotrecommended; }
        set { sReasonsfornotrecommended = value; }
    }

    private string sMatchinnegativelists;
    public string Matchinnegativelists
    {
        get { return sMatchinnegativelists; }
        set { sMatchinnegativelists = value; }
    }
    #endregion Property Declaration

    #region GetVerificationDetail()
    //Name              :   GetVerificationDetail
    //Create By			:	Hemangi Kambli
    //Create Date		:	17-July-2007

    public OleDbDataReader GetVerificationDetail(string sCaseId, string sVerifyType, string sClientId, string sCentreId)
    {

        string sSql = "";
        sSql = "select CKYC.Case_Id from  CPV_KYC_CASE_DETAILS CD " +
               " INNER JOIN CPV_KYC_VERIFICATION_TYPE CKYC ON CD.Case_ID=CKYC.Case_ID " +
               " WHERE CKYC.case_id='" + sCaseId + "' " +
               " And CKYC.verification_type_id='" + sVerifyType + "'" +
               " AND CD.Client_ID='" + sClientId + "'" +
               " AND CD.Centre_Id='" + sCentreId + "'" +
               " AND CD.SEND_DATETIME IS NULL ";

        return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
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

        return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetQCVerificationDetail()




    #region GetVerifierID()
    public OleDbDataReader GetVerifierID(string sCaseId, string sVerifyType)
    {
        string sSql = "";
        sSql = "select FE_ID from CPV_KYC_FE_MAPPING where case_id='" + sCaseId + "' " +
             " And verification_type_id='" + sVerifyType + "'";

        return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetVerifierID()

    #region GetCASEDetail()
    public OleDbDataReader GetCASEDetail(string sCaseId, string sVerifyType)
    {
        string sSql = "";
        sSql = "SELECT CD.REF_NO,CD.CASE_STATUS_ID, CONVERT(CHAR(24), cd.CASE_REC_DATETIME,103) + ' ' + " +
               "LTRIM(SUBSTRING(CONVERT( VARCHAR(210),cd.CASE_REC_DATETIME, 22), 10, 5) +  RIGHT " +
               "(CONVERT(VARCHAR(20), cd.CASE_REC_DATETIME, 22), 3)) as CASE_REC_DATETIME,  + " +
               "ISNULL(CD.FIRST_NAME,'') + ' ' + ISNULL(CD.MIDDLE_NAME,'')+ISNULL(CD.LAST_NAME,'') AS NAME ,  " +
               "CONVERT(CHAR(24), cd.SEND_DATETIME,103) + ' ' +  " +
               " LTRIM(SUBSTRING(CONVERT( VARCHAR(210),cd.SEND_DATETIME, 22), 10, 5)  + " +
               " RIGHT(CONVERT(VARCHAR(20), cd.SEND_DATETIME, 22), 3)) as SEND_DATETIME  " +
               " FROM CPV_KYC_CASE_DETAILS CD   where CD.case_id=" + sCaseId + " ";
               

        return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetCASEDetail()

    #region GetFEAreaName()
    public OleDbDataReader GetFEAreaName(string sCaseId, string sVerifyType)
    {

        string sSql = "";
        sSql = "select PincodeArea_Name,PincodeArea_ID from  CPV_KYC_CASE_VERIFICATION_Details BVBT inner join FE_Area_Master FAM   " +
               "on FAM.PincodeArea_ID=BVBT.AreaID where case_id='" + sCaseId + "' " +
               "and Verification_Type_id='" + sVerifyType + "'";

        return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetFEAreaName()
   

    public string InsertKYCVerificationEntry()
    {
        OleDbConnection oledbConn = new OleDbConnection(oCmn.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        OleDbDataReader oledbDR;
        OleDbDataReader oledbDR1;
        string sqlQuery = "";
        string sqlQuery1 = "";
        string sql = "";
        string sql1 = "";
        string msg = "";

        try
        {
            sqlQuery = " Select case_id,Verification_type_id from CPV_KYC_CASE_VERIFICATION " +
                       " where Case_ID = '" + CaseId + "'" + " And VERIFICATION_TYPE_ID='" + VerificationTypeId + "'";

            oledbDR = OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sqlQuery);

            OleDbParameter[] oledbParam = new OleDbParameter[142];
            if (oledbDR.Read() == false)
            {
                sql = "Insert into CPV_KYC_CASE_VERIFICATION (case_id,Verification_type_id,Reference_no,Company_Type,Name_Firm," +
                       " Business_Address,Business_Pincode,Bussiness_tel_no,Person_Contacted,Name_person_contacted,Designation," +
                       " Premise_Location,Prominent_Landmark,Address_Verified_is,How_long_Business,Area_Premises,Ownership_Premises," +
                       " Type_Premise,Type_Premise_Other,Nature_Business,Firm_Signboard_Sighted,Sign_Sighted_Remark,Type_Document_Sighted,"+
                       " Document_Sighted_Remark,Used_Pages_Sighted_Date,Issued_to,Initial_Invoice_Sighted_No,Initial_Invoice_Sighted_Date,"+
                       " Initial_Invoice_issued_to,Third_Party_Invoice_No,Third_Party_Invoice_Date,Third_Party_Invoice_Issued_by,Third_Party_Address,"+
                       " Relationship_between,Business_Ownership,Level_Business_Activity,No_Employees,Business_Equipment_Sighted,Marital_Status,"+
                       " Name_Displayed_Board,Relationship_with_Applicant,Staying_since_Resi,Status_Demat_Account,Name_Demat_Account,Broking_through_other,"+
                       " Attitude_Person_Contacted,Rating,Status,Product,Verification_Agent,Residence_Address,Resi_Pincode,Resi_Tel_no,Resi_Landmark,"+
                       " Permanent_Address,Permanent_Pincode,Permamnent_Tel_no,Business_Occupation_Details,Place_Visited,Area_Residence,Locating_Address,"+
                       " Business_activity_Seen,Description_Res,General_Comments,Name_Account,Request_No,Name_CA_firms,Address_CA_Firm,firm_Exist_Address,"+
                       " IS_CA_firm,Name_Person_CA_Certificate,IS_person_case_praticing,Person_issued_Cerificate_spoken,Cerificate_person_confirm,inconclusive_Reason,Email_ID,"+
                       " Name_On_Sign_Board,Concern_Is_Related,Concern_Related_Name,Family_Member_Is,Family_Member_Name,Family_Member_Relationship,Other_Institution_Demat_Account," +
                       " Name_Of_DP,Name_Plate_Of_App_Sighted,Entity_Type,Tele_No_CA_Firm,No_Years_Current_Employment,Other_Institution_SME_Account,Name_Of_Institution,RV_COMMENT,sup_date_time, "+
                       " supervisor_name,veri_date_time,Tlele_Remark,ContactPerson,properietor_Partener_Met,business_activity,ADD_BY,ADD_DATE,Remark,VeriName,City_Limit,Website,CompRegiCheckSince,CompRegiCheckSinceRegNo, "+
                       " CompRegiCheckRemark,Location_Profile,bldg_Profile,Flr_Profile,Flr_Profile_left_neigh,Flr_Profile_Flr_above,Flr_Profile_Flr_belwo,Name_board_out_Office,Name_board_Lobby_area,asso_company,Gen_Interior,No_workstations,owner_cabin,landlord,Proppery_resi,Proppery_comm,Proppery_shop,Comments_Neighbour,Locality,NoOfEmp,NoOfComputer,NoOfTelephone,NoOfFloor,customerexiswhichfloor,Ownershipofresidence,Rationcardavailable,MetToapplicant,Differncesfound,Actiontaken,Occuption,Occupationdetails,NATUREOFDSCREPANCY,Standard_Remark, " +
                    //Added by SANKET for Kunverji
                       "OfficeType,OCL_distance,OfficeInternal)" +
                    //end for Kunverji

                       " values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                oledbParam[0] = new OleDbParameter("@CaseId", OleDbType.VarChar, 15);
                oledbParam[0].Value = CaseId;

                oledbParam[1] = new OleDbParameter("@VerificationTypeId", OleDbType.VarChar, 4);
                oledbParam[1].Value = VerificationTypeId;

                oledbParam[2] = new OleDbParameter("@RefNo", OleDbType.VarChar, 50);
                oledbParam[2].Value = RefNo;

                oledbParam[3] = new OleDbParameter("@CompanyType", OleDbType.VarChar, 50);
                oledbParam[3].Value = CompanyType;

                oledbParam[4] = new OleDbParameter("@NameOfFirm", OleDbType.VarChar, 100);
                oledbParam[4].Value = NameOfFirm;

                oledbParam[5] = new OleDbParameter("@BusinessAddress", OleDbType.VarChar, 1000);
                oledbParam[5].Value = BusinessAddress;

                oledbParam[6] = new OleDbParameter("@BusinessPicode", OleDbType.VarChar, 20);
                oledbParam[6].Value = BusinessPicode;

                oledbParam[7] = new OleDbParameter("@BusinessTelNo", OleDbType.VarChar, 50);
                oledbParam[7].Value = BusinessTelNo;

                oledbParam[8] = new OleDbParameter("@PersonContacted", OleDbType.VarChar, 100);
                oledbParam[8].Value = PersonContacted;

                oledbParam[9] = new OleDbParameter("@NameOfPersonContacted", OleDbType.VarChar, 100);
                oledbParam[9].Value = NameOfPersonContacted;

                oledbParam[10] = new OleDbParameter("@Designation", OleDbType.VarChar, 100);
                oledbParam[10].Value = Designation;

                oledbParam[11] = new OleDbParameter("@PremiseLocation", OleDbType.VarChar, 100);
                oledbParam[11].Value = PremiseLocation;

                oledbParam[12] = new OleDbParameter("@ProminetLandmark", OleDbType.VarChar, 100);
                oledbParam[12].Value = ProminetLandmark;

                oledbParam[13] = new OleDbParameter("@AddressVerifiedIs", OleDbType.VarChar, 50);
                oledbParam[13].Value = AddressVerifiedIs;

                oledbParam[14] = new OleDbParameter("@HowLongInBusiness", OleDbType.VarChar, 50);
                oledbParam[14].Value = HowLongInBusiness;

                oledbParam[15] = new OleDbParameter("@AreaOfPremises", OleDbType.VarChar, 50);
                oledbParam[15].Value = AreaOfPremises;

                oledbParam[16] = new OleDbParameter("@OwnershipOfPremises", OleDbType.VarChar, 100);
                oledbParam[16].Value = OwnershipOfPremises;

                oledbParam[17] = new OleDbParameter("@TypeOfPremises", OleDbType.VarChar, 100);
                oledbParam[17].Value = TypeOfPremises;


                oledbParam[18] = new OleDbParameter("@IfOthersPremisespecify", OleDbType.VarChar, 100);
                oledbParam[18].Value = IfOthersPremisespecify;


                oledbParam[19] = new OleDbParameter("@NatureOfBusiness", OleDbType.VarChar, 100);
                oledbParam[19].Value = NatureOfBusiness;


                oledbParam[20] = new OleDbParameter("@FirmSightedBoard", OleDbType.VarChar, 50);
                oledbParam[20].Value = FirmSightedBoard;


                oledbParam[21] = new OleDbParameter("@SignBoardSightedRemark", OleDbType.VarChar, 255);
                oledbParam[21].Value = SignBoardSightedRemark;


                oledbParam[22] = new OleDbParameter("@TypeOfDocSighted", OleDbType.VarChar, 50);
                oledbParam[22].Value = TypeOfDocSighted;


                oledbParam[23] = new OleDbParameter("@OtherDocSightedRemark", OleDbType.VarChar, 255);
                oledbParam[23].Value = OtherDocSightedRemark;


                oledbParam[24] = new OleDbParameter("@UsedPagesSightedDate", OleDbType.VarChar, 50);
                oledbParam[24].Value = UsedPagesSightedDate;


                oledbParam[25] = new OleDbParameter("@IssuedTo", OleDbType.VarChar, 100);
                oledbParam[25].Value = IssuedTo;


                oledbParam[26] = new OleDbParameter("@InitialInvoiceSightedNo", OleDbType.VarChar, 50);
                oledbParam[26].Value = InitialInvoiceSightedNo;


                oledbParam[27] = new OleDbParameter("@InitialInvoiceSightedDate", OleDbType.VarChar, 50);
                oledbParam[27].Value = InitialInvoiceSightedDate;


                oledbParam[28] = new OleDbParameter("@InitialInvoiceSightedIssuedTo", OleDbType.VarChar, 50);
                oledbParam[28].Value = InitialInvoiceSightedIssuedTo;


                oledbParam[29] = new OleDbParameter("@ThirdPartyInvoiceNo", OleDbType.VarChar, 50);
                oledbParam[29].Value = ThirdPartyInvoiceNo;

                oledbParam[30] = new OleDbParameter("@ThirdPartyInvoiceDate", OleDbType.VarChar, 50);
                oledbParam[30].Value = ThirdPartyInvoiceDate;

                oledbParam[31] = new OleDbParameter("@ThirdPartyInvoiceIssuedBy", OleDbType.VarChar, 50);
                oledbParam[31].Value = ThirdPartyInvoiceIssuedBy;

                oledbParam[32] = new OleDbParameter("@ThirdPartyAddress", OleDbType.VarChar, 255);
                oledbParam[32].Value = ThirdPartyAddress;


                oledbParam[33] = new OleDbParameter("@RelationshipBTNEntity", OleDbType.VarChar, 50);
                oledbParam[33].Value = RelationshipBTNEntity;

                oledbParam[34] = new OleDbParameter("@BusinessOwnership", OleDbType.VarChar, 50);
                oledbParam[34].Value = BusinessOwnership;

                oledbParam[35] = new OleDbParameter("@LevelOfBusinssActivity", OleDbType.VarChar, 50);
                oledbParam[35].Value = LevelOfBusinssActivity;

                oledbParam[36] = new OleDbParameter("@NoOfEmployees", OleDbType.VarChar, 50);
                oledbParam[36].Value = NoOfEmployees;

                oledbParam[37] = new OleDbParameter("@BusinessEquipSighted", OleDbType.VarChar, 100);
                oledbParam[37].Value = BusinessEquipSighted;

                oledbParam[38] = new OleDbParameter("@MaritalStatus", OleDbType.VarChar, 50);
                oledbParam[38].Value = MaritalStatus;

                oledbParam[39] = new OleDbParameter("@NameDisplayOnNameBoard", OleDbType.VarChar, 100);
                oledbParam[39].Value = NameDisplayOnNameBoard;

                oledbParam[40] = new OleDbParameter("@RelationshipWithApplicant", OleDbType.VarChar, 100);
                oledbParam[40].Value = RelationshipWithApplicant;

                oledbParam[41] = new OleDbParameter("@StayingSinceAtResi", OleDbType.VarChar, 50);
                oledbParam[41].Value = StayingSinceAtResi;

                oledbParam[42] = new OleDbParameter("@StatusOfDematAcct", OleDbType.VarChar, 50);
                oledbParam[42].Value = StatusOfDematAcct;

                oledbParam[43] = new OleDbParameter("@NameOfDematAcct", OleDbType.VarChar, 100);
                oledbParam[43].Value = NameOfDematAcct;

                oledbParam[44] = new OleDbParameter("@DoingBroken", OleDbType.VarChar, 100);
                oledbParam[44].Value = DoingBroken;

                oledbParam[45] = new OleDbParameter("@AttituteOfPersonContacted", OleDbType.VarChar, 100);
                oledbParam[45].Value = AttituteOfPersonContacted;

                oledbParam[46] = new OleDbParameter("@Rating", OleDbType.VarChar, 50);
                oledbParam[46].Value = Rating;

                oledbParam[47] = new OleDbParameter("@Status", OleDbType.VarChar, 50);
                oledbParam[47].Value = Status;

                oledbParam[48] = new OleDbParameter("@Product", OleDbType.VarChar, 50);
                oledbParam[48].Value = Product;

                oledbParam[49] = new OleDbParameter("@NameOfVerifyAgent", OleDbType.VarChar, 50);
                oledbParam[49].Value = NameOfVerifyAgent;

                oledbParam[50] = new OleDbParameter("@ResidenceAddress", OleDbType.VarChar, 1000);
                oledbParam[50].Value = ResidenceAddress;

                oledbParam[51] = new OleDbParameter("@ResiPincode", OleDbType.VarChar, 50);
                oledbParam[51].Value = ResiPincode;

                oledbParam[52] = new OleDbParameter("@ResiTelNo", OleDbType.VarChar, 50);
                oledbParam[52].Value = ResiTelNo;

                oledbParam[53] = new OleDbParameter("@ResiLandmark", OleDbType.VarChar, 1000);
                oledbParam[53].Value = ResiLandmark;

                oledbParam[54] = new OleDbParameter("@PermanentAddress", OleDbType.VarChar, 1000);
                oledbParam[54].Value = PermanentAddress;

                oledbParam[55] = new OleDbParameter("@PermanentPincode", OleDbType.VarChar, 50);
                oledbParam[55].Value = PermanentPincode;

                oledbParam[56] = new OleDbParameter("@PermanentTelNo", OleDbType.VarChar, 50);
                oledbParam[56].Value = PermanentTelNo;

                oledbParam[57] = new OleDbParameter("@BusinessOccupDetail", OleDbType.VarChar, 100);
                oledbParam[57].Value = BusinessOccupDetail; 

                oledbParam[58] = new OleDbParameter("@PlaceVisited", OleDbType.VarChar, 100);
                oledbParam[58].Value = PlaceVisited;

                oledbParam[59] = new OleDbParameter("@AreaOfResidence", OleDbType.VarChar, 100);
                oledbParam[59].Value = AreaOfResidence;

                oledbParam[60] = new OleDbParameter("@LocatingAddress", OleDbType.VarChar, 1000);
                oledbParam[60].Value = LocatingAddress;

                oledbParam[61] = new OleDbParameter("@IfOfficeBusiActivitySeen", OleDbType.VarChar, 50);
                oledbParam[61].Value = IfOfficeBusiActivitySeen;

                oledbParam[62] = new OleDbParameter("@DescriptionOfResi", OleDbType.VarChar, 255);
                oledbParam[62].Value = DescriptionOfResi;

                oledbParam[63] = new OleDbParameter("@GeneralComment", OleDbType.VarChar, 1000);
                oledbParam[63].Value = GeneralComment;

                oledbParam[64] = new OleDbParameter("@NameOfAccount", OleDbType.VarChar, 50);
                oledbParam[64].Value = NameOfAccount;

                oledbParam[65] = new OleDbParameter("@RequestNo", OleDbType.VarChar, 50);
                oledbParam[65].Value = RequestNo;

                oledbParam[66] = new OleDbParameter("@NameOfCAFirm", OleDbType.VarChar, 100);
                oledbParam[66].Value = NameOfCAFirm;

                oledbParam[67] = new OleDbParameter("@AddressOfCAFirm", OleDbType.VarChar, 100);
                oledbParam[67].Value = AddressOfCAFirm;

                oledbParam[68] = new OleDbParameter("@DoesFirmExistAtAddress", OleDbType.VarChar, 50);
                oledbParam[68].Value = DoesFirmExistAtAddress;

                oledbParam[69] = new OleDbParameter("@IsFirmCAFirm", OleDbType.VarChar, 50);
                oledbParam[69].Value = IsFirmCAFirm;

                oledbParam[70] = new OleDbParameter("@NameOfPersonWhoIssuedCACertificate", OleDbType.VarChar, 100);
                oledbParam[70].Value = NameOfPersonWhoIssuedCACertificate;

                oledbParam[71] = new OleDbParameter("@IsPersonPractisingCasInFirm", OleDbType.VarChar, 50);
                oledbParam[71].Value = IsPersonPractisingCasInFirm;

                oledbParam[72] = new OleDbParameter("@WasPersonSpokenTo", OleDbType.VarChar, 50);
                //oledbParam[72].Value = WasPersonSpokenTo;
                oledbParam[72].Value = Neighbour;

                oledbParam[73] = new OleDbParameter("@ConfirmCACertificateIssued", OleDbType.VarChar, 500);
                oledbParam[73].Value = ConfirmCACertificateIssued;

                oledbParam[74] = new OleDbParameter("@InConclusiveReason", OleDbType.VarChar, 255);
                oledbParam[74].Value = InConclusiveReason;

                oledbParam[75] = new OleDbParameter("@EmailId", OleDbType.VarChar, 100);
                oledbParam[75].Value = EmailId;

                oledbParam[76] = new OleDbParameter("@NameOnSignBoard", OleDbType.VarChar, 100);
                oledbParam[76].Value = NameOnSignBoard;

                oledbParam[77] = new OleDbParameter("@HowTheConcernIsRelated", OleDbType.VarChar, 50);
                oledbParam[77].Value = HowTheConcernIsRelated;

                oledbParam[78] = new OleDbParameter("@ConcernRelatedName", OleDbType.VarChar, 100);
                oledbParam[78].Value = ConcernRelatedName;

                oledbParam[79] = new OleDbParameter("@FamilyMemberIs", OleDbType.VarChar, 50);
                oledbParam[79].Value = FamilyMemberIs;

                oledbParam[80] = new OleDbParameter("@FamilyMemberName", OleDbType.VarChar, 100);
                oledbParam[80].Value = FamilyMemberName;

                oledbParam[81] = new OleDbParameter("@FamilyMemberRelationship", OleDbType.VarChar, 100);
                oledbParam[81].Value = FamilyMemberRelationship;

                oledbParam[82] = new OleDbParameter("@HavingDematAccountWithOtherInstitution", OleDbType.VarChar, 50);
                oledbParam[82].Value = HavingDematAccountWithOtherInstitution;

                oledbParam[83] = new OleDbParameter("@NameOfDP", OleDbType.VarChar, 100);
                oledbParam[83].Value = NameOfDP;

             
                oledbParam[84] = new OleDbParameter("@NamePlateofApplicantSighted", OleDbType.VarChar, 50);
                oledbParam[84].Value = NamePlateofApplicantSighted;

                oledbParam[85] = new OleDbParameter("@EntityType", OleDbType.VarChar, 50);
                oledbParam[85].Value = EntityType;


                oledbParam[86] = new OleDbParameter("@TelephoneNoOfCAFirm", OleDbType.VarChar, 50);
                oledbParam[86].Value = TelephoneNoOfCAFirm;


                oledbParam[87] = new OleDbParameter("@NoOfYearsInCurrentEmployment", OleDbType.VarChar, 50);
                oledbParam[87].Value = NoOfYearsInCurrentEmployment;

                oledbParam[88] = new OleDbParameter("@HavingSMEAccountWithOtherInstitution", OleDbType.VarChar, 50);
                oledbParam[88].Value = HavingSMEAccountWithOtherInstitution;

                oledbParam[89] = new OleDbParameter("@NameOfInstitution", OleDbType.VarChar, 100);
                oledbParam[89].Value = NameOfInstitution;

                oledbParam[90] = new OleDbParameter("@RV_COMMENT", OleDbType.VarChar, 1000);
                oledbParam[90].Value = NameRVComment;

                oledbParam[91] = new OleDbParameter("@sup_datetime", OleDbType.VarChar,50);
                oledbParam[91].Value = dtSupervisordatetime ;

                oledbParam[92] = new OleDbParameter("@supervisorname", OleDbType.VarChar,200);
                oledbParam[92].Value = SupervisorName;

                oledbParam[93] = new OleDbParameter("@veri_datetime", OleDbType.VarChar,50);
                oledbParam[93].Value = dtVerifierDatetime;

                oledbParam[94] = new OleDbParameter("@TeleRemark", OleDbType.VarChar,1000);
                oledbParam[94].Value = TeleRemark;

                oledbParam[95] = new OleDbParameter("@contactedperson", OleDbType.VarChar, 200);
                oledbParam[95].Value = ContactPerson;

                oledbParam[96] = new OleDbParameter("@ProprietorPartenrMet", OleDbType.VarChar, 50);
                oledbParam[96].Value = ProprietorPartenerMet;

                oledbParam[97] = new OleDbParameter("@BusinessActivity", OleDbType.VarChar, 50);
                oledbParam[97].Value = BusinessActivity;

                oledbParam[98] = new OleDbParameter("@AddedBy", OleDbType.VarChar, 15);
                oledbParam[98].Value = HttpContext.Current.Session["UserId"];

                oledbParam[99] = new OleDbParameter("@AddedDate", OleDbType.DBTimeStamp, 8);
                oledbParam[99].Value = System.DateTime.Now;

                oledbParam[100] = new OleDbParameter("@Remark", OleDbType.VarChar, 2000);
                oledbParam[100].Value = OverallRemark;

                oledbParam[101] = new OleDbParameter("@VerifierName", OleDbType.VarChar, 100);
                oledbParam[101].Value = VerifierName;

                oledbParam[102] = new OleDbParameter("@CityLimit", OleDbType.VarChar, 100);
                oledbParam[102].Value = CityLimit;

                oledbParam[103] = new OleDbParameter("@Website", OleDbType.VarChar, 500);
                oledbParam[103].Value = Website;

                oledbParam[104] = new OleDbParameter("@CompRegiCheckSince", OleDbType.VarChar, 500);
                oledbParam[104].Value = CompRegiCheckSince;

                oledbParam[105] = new OleDbParameter("@CompRegiCheckSinceRegNo", OleDbType.VarChar, 500);
                oledbParam[105].Value = CompRegiCheckSinceRegNo;

                oledbParam[106] = new OleDbParameter("@CompRegiCheckRemark", OleDbType.VarChar, 500);
                oledbParam[106].Value = CompRegiCheckRemark;

                oledbParam[107] = new OleDbParameter("@Location_Profile", OleDbType.VarChar, 500);
                oledbParam[107].Value = Location_Profile;

                oledbParam[108] = new OleDbParameter("@bldg_Profile", OleDbType.VarChar, 500);
                oledbParam[108].Value = bldg_Profile;

                oledbParam[109] = new OleDbParameter("@Flr_Profile", OleDbType.VarChar, 500);
                oledbParam[109].Value = Flr_Profile;

                oledbParam[110] = new OleDbParameter("@Flr_Profile_left_neigh", OleDbType.VarChar, 500);
                oledbParam[110].Value = Flr_Profile_left_neigh;

                oledbParam[111] = new OleDbParameter("@Flr_Profile_Flr_above", OleDbType.VarChar, 500);
                oledbParam[111].Value = Flr_Profile_Flr_above;

                oledbParam[112] = new OleDbParameter("@Flr_Profile_Flr_belwo", OleDbType.VarChar, 500);
                oledbParam[112].Value = Flr_Profile_Flr_belwo;

                oledbParam[113] = new OleDbParameter("@Name_board_out_Office", OleDbType.VarChar, 500);
                oledbParam[113].Value = Name_board_out_Office;

                oledbParam[114] = new OleDbParameter("@Name_board_Lobby_area", OleDbType.VarChar, 500);
                oledbParam[114].Value = Name_board_Lobby_area;

                oledbParam[115] = new OleDbParameter("@asso_company", OleDbType.VarChar, 500);
                oledbParam[115].Value = asso_company;

                oledbParam[116] = new OleDbParameter("@Gen_Interior", OleDbType.VarChar, 500);
                oledbParam[116].Value = Gen_Interior;

                oledbParam[117] = new OleDbParameter("@No_workstations", OleDbType.VarChar, 500);
                oledbParam[117].Value = No_workstations;

                oledbParam[118] = new OleDbParameter("@owner_cabin", OleDbType.VarChar, 500);
                oledbParam[118].Value = owner_cabin;

                oledbParam[119] = new OleDbParameter("@landlord", OleDbType.VarChar, 500);
                oledbParam[119].Value = landlord;

                oledbParam[120] = new OleDbParameter("@Proppery_resi", OleDbType.VarChar, 500);
                oledbParam[120].Value = Proppery_resi;

                oledbParam[121] = new OleDbParameter("@Proppery_comm", OleDbType.VarChar, 500);
                oledbParam[121].Value = Proppery_comm;

                oledbParam[122] = new OleDbParameter("@Proppery_shop", OleDbType.VarChar, 500);
                oledbParam[122].Value = Proppery_shop;

                oledbParam[123] = new OleDbParameter("@Comments_Neighbour", OleDbType.VarChar, 500);
                oledbParam[123].Value = DoNeighbourKnowTheCustomerForFemu;

                oledbParam[124] = new OleDbParameter("@Locality", OleDbType.VarChar, 500);
                oledbParam[124].Value = Locality;


                oledbParam[125] = new OleDbParameter("@NoOfEmp", OleDbType.VarChar, 500);
                oledbParam[125].Value = NoOfEmp;

                oledbParam[126] = new OleDbParameter("@NoOfComputer", OleDbType.VarChar, 500);
                oledbParam[126].Value = NoOfComputer;

                oledbParam[127] = new OleDbParameter("@NoOfTelephone", OleDbType.VarChar, 500);
                oledbParam[127].Value = NoOfTelephone;

                oledbParam[128] = new OleDbParameter("@NoOfFloor", OleDbType.VarChar, 500);
                oledbParam[128].Value = NoOfFloor;

                oledbParam[129] = new OleDbParameter("@customerexiswhichfloor", OleDbType.VarChar, 500);
                oledbParam[129].Value = customerexiswhichfloor;

                oledbParam[130] = new OleDbParameter("@Ownershipofresidence", OleDbType.VarChar, 500);
                oledbParam[130].Value = Ownershipofresidence;

                oledbParam[131] = new OleDbParameter("@Rationcardavailable", OleDbType.VarChar, 500);
                oledbParam[131].Value = Rationcardavailable;

                oledbParam[132] = new OleDbParameter("@MetToapplicant", OleDbType.VarChar, 500);
                oledbParam[132].Value = MetToapplicant;
                //Added by Manoj Jadhav

                oledbParam[133] = new OleDbParameter("@Differncesfound", OleDbType.VarChar, 500);
                oledbParam[133].Value = Differncesfound;

                oledbParam[134] = new OleDbParameter("@Actiontaken", OleDbType.VarChar, 500);
                oledbParam[134].Value = Actiontaken;

                oledbParam[135] = new OleDbParameter("@Occuption", OleDbType.VarChar, 500);
                oledbParam[135].Value = Occuption;

                oledbParam[136] = new OleDbParameter("@Occupationdetails", OleDbType.VarChar, 500);
                oledbParam[136].Value = Occupationdetails;

                oledbParam[137] = new OleDbParameter("@NATUREOFDSCREPANCY", OleDbType.VarChar, 500);
                oledbParam[137].Value = NATUREOFDSCREPANCY;

                //added by SANKET
                oledbParam[138] = new OleDbParameter("@Standard_Remark", OleDbType.VarChar, 100);
                oledbParam[138].Value = StandardRemark;
                //end

                //Added by SANKET for Kunverji
                oledbParam[139] = new OleDbParameter("@OfficeType", OleDbType.VarChar, 100);
                oledbParam[139].Value = OfficeType;
                oledbParam[140] = new OleDbParameter("@OCL_distance", OleDbType.VarChar, 100);
                oledbParam[140].Value = OCL_distance;
                oledbParam[141] = new OleDbParameter("@OfficeInternal", OleDbType.VarChar, 100);
                oledbParam[141].Value = OfficeInternal;
                //end for Kunverji

                msg = "Record Added Sucessfully";

            }
            else
            {
                sql = "Update CPV_KYC_CASE_VERIFICATION Set Reference_no=?,Company_Type=?,Name_Firm=?," +
                       " Business_Address=?,Business_Pincode=?,Bussiness_tel_no=?,Person_Contacted=?,Name_person_contacted=?,Designation=?," +
                       " Premise_Location=?,Prominent_Landmark=?,Address_Verified_is=?,How_long_Business=?,Area_Premises=?,Ownership_Premises=?," +
                       " Type_Premise=?,Type_Premise_Other=?,Nature_Business=?,Firm_Signboard_Sighted=?,Sign_Sighted_Remark=?,Type_Document_Sighted=?,"+
                       " Document_Sighted_Remark=?,Used_Pages_Sighted_Date=?,Issued_to=?,Initial_Invoice_Sighted_No=?,Initial_Invoice_Sighted_Date=?,"+
                       " Initial_Invoice_issued_to=?,Third_Party_Invoice_No=?,Third_Party_Invoice_Date=?,Third_Party_Invoice_Issued_by=?,Third_Party_Address=?,"+
                       " Relationship_between=?,Business_Ownership=?,Level_Business_Activity=?,No_Employees=?,Business_Equipment_Sighted=?,Marital_Status=?,"+
                       " Name_Displayed_Board=?,Relationship_with_Applicant=?,Staying_since_Resi=?,Status_Demat_Account=?,Name_Demat_Account=?,Broking_through_other=?,"+
                       " Attitude_Person_Contacted=?,Rating=?,Status=?,Product=?,Verification_Agent=?,Residence_Address=?,Resi_Pincode=?,Resi_Tel_no=?,Resi_Landmark=?,"+
                       " Permanent_Address=?,Permanent_Pincode=?,Permamnent_Tel_no=?,Business_Occupation_Details=?,Place_Visited=?,Area_Residence=?,Locating_Address=?,"+
                       " Business_activity_Seen=?,Description_Res=?,General_Comments=?,Name_Account=?,Request_No=?,Name_CA_firms=?,Address_CA_Firm=?,firm_Exist_Address=?,"+
                       " IS_CA_firm=?,Name_Person_CA_Certificate=?,IS_person_case_praticing=?,Person_issued_Cerificate_spoken=?,Cerificate_person_confirm=?,inconclusive_Reason=?,Email_ID=?,  "+
                       " Name_On_Sign_Board=?,Concern_Is_Related=?,Concern_Related_Name=?,Family_Member_Is=?,Family_Member_Name=?,Family_Member_Relationship=?,Other_Institution_Demat_Account=?, " +
                       " Name_Of_DP=?,Name_Plate_Of_App_Sighted=?,Entity_Type=?,Tele_No_CA_Firm=?,No_Years_Current_Employment=?,Other_Institution_SME_Account=?,Name_Of_Institution=?,RV_COMMENT=?,"+
                       "supervisor_name=?,sup_date_time=?,veri_date_time=?,Tlele_Remark=?,ContactPerson=?,properietor_Partener_Met=?,business_activity=? ,Remark=? ,MODIFY_BY=?, MODIFY_DATE=?,VeriName=?,City_Limit=?,Website=?, "+
                       "CompRegiCheckSince=?,CompRegiCheckSinceRegNo=?,CompRegiCheckRemark=?,Location_Profile=?,bldg_Profile=?,Flr_Profile=?,Flr_Profile_left_neigh=?,Flr_Profile_Flr_above=?,Flr_Profile_Flr_belwo=?,Name_board_out_Office=?,Name_board_Lobby_area=?, "+
                       " asso_company=?,Gen_Interior=?,No_workstations=?,owner_cabin=?,landlord=?,Proppery_resi=?,Proppery_comm=?,Proppery_shop=?,Comments_Neighbour=?,Locality=?,NoOfEmp=?,NoOfComputer=?,NoOfTelephone=?,NoOfFloor=?,customerexiswhichfloor=?,Ownershipofresidence=?,Rationcardavailable=?,MetToapplicant=?,Differncesfound=?,Actiontaken=?,Occuption=?,Occupationdetails=?,NATUREOFDSCREPANCY=?,Standard_Remark=?, "+
                    //Added by SANKET for Kunverji
            "OfficeType=?,OCL_distance=?,OfficeInternal=? " +
                    //end for Kunverji
                       
                       " where case_id=? and Verification_type_id=? ";

          

                oledbParam[0] = new OleDbParameter("@RefNo", OleDbType.VarChar, 50);
                oledbParam[0].Value = RefNo;

                oledbParam[1] = new OleDbParameter("@CompanyType", OleDbType.VarChar, 50);
                oledbParam[1].Value = CompanyType;

                oledbParam[2] = new OleDbParameter("@NameOfFirm", OleDbType.VarChar, 100);
                oledbParam[2].Value = NameOfFirm;

                oledbParam[3] = new OleDbParameter("@BusinessAddress", OleDbType.VarChar, 1000);
                oledbParam[3].Value = BusinessAddress;

                oledbParam[4] = new OleDbParameter("@BusinessPicode", OleDbType.VarChar, 20);
                oledbParam[4].Value = BusinessPicode;

                oledbParam[5] = new OleDbParameter("@BusinessTelNo", OleDbType.VarChar, 50);
                oledbParam[5].Value = BusinessTelNo;

                oledbParam[6] = new OleDbParameter("@PersonContacted", OleDbType.VarChar, 100);
                oledbParam[6].Value = PersonContacted;

                oledbParam[7] = new OleDbParameter("@NameOfPersonContacted", OleDbType.VarChar, 100);
                oledbParam[7].Value = NameOfPersonContacted;

                oledbParam[8] = new OleDbParameter("@Designation", OleDbType.VarChar, 100);
                oledbParam[8].Value = Designation;

                oledbParam[9] = new OleDbParameter("@PremiseLocation", OleDbType.VarChar, 100);
                oledbParam[9].Value = PremiseLocation;

                oledbParam[10] = new OleDbParameter("@ProminetLandmark", OleDbType.VarChar, 100);
                oledbParam[10].Value = ProminetLandmark;

                oledbParam[11] = new OleDbParameter("@AddressVerifiedIs", OleDbType.VarChar, 50);
                oledbParam[11].Value = AddressVerifiedIs;

                oledbParam[12] = new OleDbParameter("@HowLongInBusiness", OleDbType.VarChar, 50);
                oledbParam[12].Value = HowLongInBusiness;

                oledbParam[13] = new OleDbParameter("@AreaOfPremises", OleDbType.VarChar, 50);
                oledbParam[13].Value = AreaOfPremises;

                oledbParam[14] = new OleDbParameter("@OwnershipOfPremises", OleDbType.VarChar, 100);
                oledbParam[14].Value = OwnershipOfPremises;

                oledbParam[15] = new OleDbParameter("@TypeOfPremises", OleDbType.VarChar, 100);
                oledbParam[15].Value = TypeOfPremises;


                oledbParam[16] = new OleDbParameter("@IfOthersPremisespecify", OleDbType.VarChar, 100);
                oledbParam[16].Value = IfOthersPremisespecify;


                oledbParam[17] = new OleDbParameter("@NatureOfBusiness", OleDbType.VarChar, 100);
                oledbParam[17].Value = NatureOfBusiness;


                oledbParam[18] = new OleDbParameter("@FirmSightedBoard", OleDbType.VarChar, 50);
                oledbParam[18].Value = FirmSightedBoard;


                oledbParam[19] = new OleDbParameter("@SignBoardSightedRemark", OleDbType.VarChar, 255);
                oledbParam[19].Value = SignBoardSightedRemark;


                oledbParam[20] = new OleDbParameter("@TypeOfDocSighted", OleDbType.VarChar, 50);
                oledbParam[20].Value = TypeOfDocSighted;


                oledbParam[21] = new OleDbParameter("@OtherDocSightedRemark", OleDbType.VarChar, 255);
                oledbParam[21].Value = OtherDocSightedRemark;


                oledbParam[22] = new OleDbParameter("@UsedPagesSightedDate", OleDbType.VarChar, 50);
                oledbParam[22].Value = UsedPagesSightedDate;


                oledbParam[23] = new OleDbParameter("@IssuedTo", OleDbType.VarChar, 100);
                oledbParam[23].Value = IssuedTo;


                oledbParam[24] = new OleDbParameter("@InitialInvoiceSightedNo", OleDbType.VarChar, 50);
                oledbParam[24].Value = InitialInvoiceSightedNo;


                oledbParam[25] = new OleDbParameter("@InitialInvoiceSightedDate", OleDbType.VarChar, 50);
                oledbParam[25].Value = InitialInvoiceSightedDate;


                oledbParam[26] = new OleDbParameter("@InitialInvoiceSightedIssuedTo", OleDbType.VarChar, 50);
                oledbParam[26].Value = InitialInvoiceSightedIssuedTo;


                oledbParam[27] = new OleDbParameter("@ThirdPartyInvoiceNo", OleDbType.VarChar, 50);
                oledbParam[27].Value = ThirdPartyInvoiceNo;

                oledbParam[28] = new OleDbParameter("@ThirdPartyInvoiceDate", OleDbType.VarChar, 50);
                oledbParam[28].Value = ThirdPartyInvoiceDate;

                oledbParam[29] = new OleDbParameter("@ThirdPartyInvoiceIssuedBy", OleDbType.VarChar, 50);
                oledbParam[29].Value = ThirdPartyInvoiceIssuedBy;

                oledbParam[30] = new OleDbParameter("@ThirdPartyAddress", OleDbType.VarChar, 255);
                oledbParam[30].Value = ThirdPartyAddress;


                oledbParam[31] = new OleDbParameter("@RelationshipBTNEntity", OleDbType.VarChar, 50);
                oledbParam[31].Value = RelationshipBTNEntity;

                oledbParam[32] = new OleDbParameter("@BusinessOwnership", OleDbType.VarChar, 50);
                oledbParam[32].Value = BusinessOwnership;

                oledbParam[33] = new OleDbParameter("@LevelOfBusinssActivity", OleDbType.VarChar, 50);
                oledbParam[33].Value = LevelOfBusinssActivity;

                oledbParam[34] = new OleDbParameter("@NoOfEmployees", OleDbType.VarChar, 50);
                oledbParam[34].Value = NoOfEmployees;

                oledbParam[35] = new OleDbParameter("@BusinessEquipSighted", OleDbType.VarChar, 100);
                oledbParam[35].Value = BusinessEquipSighted;

                oledbParam[36] = new OleDbParameter("@MaritalStatus", OleDbType.VarChar, 50);
                oledbParam[36].Value = MaritalStatus;

                oledbParam[37] = new OleDbParameter("@NameDisplayOnNameBoard", OleDbType.VarChar, 100);
                oledbParam[37].Value = NameDisplayOnNameBoard;

                oledbParam[38] = new OleDbParameter("@RelationshipWithApplicant", OleDbType.VarChar, 100);
                oledbParam[38].Value = RelationshipWithApplicant;

                oledbParam[39] = new OleDbParameter("@StayingSinceAtResi", OleDbType.VarChar, 50);
                oledbParam[39].Value = StayingSinceAtResi;

                oledbParam[40] = new OleDbParameter("@StatusOfDematAcct", OleDbType.VarChar, 50);
                oledbParam[40].Value = StatusOfDematAcct;

                oledbParam[41] = new OleDbParameter("@NameOfDematAcct", OleDbType.VarChar, 100);
                oledbParam[41].Value = NameOfDematAcct;

                oledbParam[42] = new OleDbParameter("@DoingBroken", OleDbType.VarChar, 100);
                oledbParam[42].Value = DoingBroken;

                oledbParam[43] = new OleDbParameter("@AttituteOfPersonContacted", OleDbType.VarChar, 100);
                oledbParam[43].Value = AttituteOfPersonContacted;

                oledbParam[44] = new OleDbParameter("@Rating", OleDbType.VarChar, 50);
                oledbParam[44].Value = Rating;

                oledbParam[45] = new OleDbParameter("@Status", OleDbType.VarChar, 50);
                oledbParam[45].Value = Status;

                oledbParam[46] = new OleDbParameter("@Product", OleDbType.VarChar, 50);
                oledbParam[46].Value = Product;

                oledbParam[47] = new OleDbParameter("@NameOfVerifyAgent", OleDbType.VarChar, 50);
                oledbParam[47].Value = NameOfVerifyAgent;

                oledbParam[48] = new OleDbParameter("@ResidenceAddress", OleDbType.VarChar, 255);
                oledbParam[48].Value = ResidenceAddress;

                oledbParam[49] = new OleDbParameter("@ResiPincode", OleDbType.VarChar, 50);
                oledbParam[49].Value = ResiPincode;

                oledbParam[50] = new OleDbParameter("@ResiTelNo", OleDbType.VarChar, 50);
                oledbParam[50].Value = ResiTelNo;

                oledbParam[51] = new OleDbParameter("@ResiLandmark", OleDbType.VarChar, 100);
                oledbParam[51].Value = ResiLandmark;

                oledbParam[52] = new OleDbParameter("@PermanentAddress", OleDbType.VarChar, 255);
                oledbParam[52].Value = PermanentAddress;

                oledbParam[53] = new OleDbParameter("@PermanentPincode", OleDbType.VarChar, 50);
                oledbParam[53].Value = PermanentPincode;

                oledbParam[54] = new OleDbParameter("@PermanentTelNo", OleDbType.VarChar, 50);
                oledbParam[54].Value = PermanentTelNo;

                oledbParam[55] = new OleDbParameter("@BusinessOccupDetail", OleDbType.VarChar, 100);
                oledbParam[55].Value = BusinessOccupDetail; 

                oledbParam[56] = new OleDbParameter("@PlaceVisited", OleDbType.VarChar, 100);
                oledbParam[56].Value = PlaceVisited;

                oledbParam[57] = new OleDbParameter("@AreaOfResidence", OleDbType.VarChar, 100);
                oledbParam[57].Value = AreaOfResidence;

                oledbParam[58] = new OleDbParameter("@LocatingAddress", OleDbType.VarChar, 255);
                oledbParam[58].Value = LocatingAddress;

                oledbParam[59] = new OleDbParameter("@IfOfficeBusiActivitySeen", OleDbType.VarChar, 50);
                oledbParam[59].Value = IfOfficeBusiActivitySeen;

                oledbParam[60] = new OleDbParameter("@DescriptionOfResi", OleDbType.VarChar, 255);
                oledbParam[60].Value = DescriptionOfResi;

                oledbParam[61] = new OleDbParameter("@GeneralComment", OleDbType.VarChar, 1000);
                oledbParam[61].Value = GeneralComment;

                oledbParam[62] = new OleDbParameter("@NameOfAccount", OleDbType.VarChar, 50);
                oledbParam[62].Value = NameOfAccount;

                oledbParam[63] = new OleDbParameter("@RequestNo", OleDbType.VarChar, 50);
                oledbParam[63].Value = RequestNo;

                oledbParam[64] = new OleDbParameter("@NameOfCAFirm", OleDbType.VarChar, 100);
                oledbParam[64].Value = NameOfCAFirm;

                oledbParam[65] = new OleDbParameter("@AddressOfCAFirm", OleDbType.VarChar, 100);
                oledbParam[65].Value = AddressOfCAFirm;

                oledbParam[66] = new OleDbParameter("@DoesFirmExistAtAddress", OleDbType.VarChar, 50);
                oledbParam[66].Value = DoesFirmExistAtAddress;

                oledbParam[67] = new OleDbParameter("@IsFirmCAFirm", OleDbType.VarChar, 50);
                oledbParam[67].Value = IsFirmCAFirm;

                oledbParam[68] = new OleDbParameter("@NameOfPersonWhoIssuedCACertificate", OleDbType.VarChar, 100);
                oledbParam[68].Value = NameOfPersonWhoIssuedCACertificate;

                oledbParam[69] = new OleDbParameter("@IsPersonPractisingCasInFirm", OleDbType.VarChar, 50);
                oledbParam[69].Value = IsPersonPractisingCasInFirm;

                oledbParam[70] = new OleDbParameter("@WasPersonSpokenTo", OleDbType.VarChar, 50);
                oledbParam[70].Value = Neighbour;

                oledbParam[71] = new OleDbParameter("@ConfirmCACertificateIssued", OleDbType.VarChar, 500);
                oledbParam[71].Value = ConfirmCACertificateIssued;

                oledbParam[72] = new OleDbParameter("@InConclusiveReason", OleDbType.VarChar, 255);
                oledbParam[72].Value = InConclusiveReason;

                oledbParam[73] = new OleDbParameter("@EmailId", OleDbType.VarChar, 100);
                oledbParam[73].Value = EmailId;


                oledbParam[74] = new OleDbParameter("@NameOnSignBoard", OleDbType.VarChar, 100);
                oledbParam[74].Value = NameOnSignBoard;

                oledbParam[75] = new OleDbParameter("@HowTheConcernIsRelated", OleDbType.VarChar, 50);
                oledbParam[75].Value = HowTheConcernIsRelated;

                oledbParam[76] = new OleDbParameter("@ConcernRelatedName", OleDbType.VarChar, 100);
                oledbParam[76].Value = ConcernRelatedName;

                oledbParam[77] = new OleDbParameter("@FamilyMemberIs", OleDbType.VarChar, 50);
                oledbParam[77].Value = FamilyMemberIs;

                oledbParam[78] = new OleDbParameter("@FamilyMemberName", OleDbType.VarChar, 100);
                oledbParam[78].Value = FamilyMemberName;

                oledbParam[79] = new OleDbParameter("@FamilyMemberRelationship", OleDbType.VarChar, 100);
                oledbParam[79].Value = FamilyMemberRelationship;

                oledbParam[80] = new OleDbParameter("@HavingDematAccountWithOtherInstitution", OleDbType.VarChar, 50);
                oledbParam[80].Value = HavingDematAccountWithOtherInstitution;

                oledbParam[81] = new OleDbParameter("@NameOfDP", OleDbType.VarChar, 100);
                oledbParam[81].Value = NameOfDP;

                oledbParam[82] = new OleDbParameter("@NamePlateofApplicantSighted", OleDbType.VarChar, 50);
                oledbParam[82].Value = NamePlateofApplicantSighted;

                oledbParam[83] = new OleDbParameter("@EntityType", OleDbType.VarChar, 50);
                oledbParam[83].Value = EntityType;


                oledbParam[84] = new OleDbParameter("@TelephoneNoOfCAFirm", OleDbType.VarChar, 50);
                oledbParam[84].Value = TelephoneNoOfCAFirm;


                oledbParam[85] = new OleDbParameter("@NoOfYearsInCurrentEmployment", OleDbType.VarChar, 50);
                oledbParam[85].Value = NoOfYearsInCurrentEmployment;

                oledbParam[86] = new OleDbParameter("@HavingSMEAccountWithOtherInstitution", OleDbType.VarChar, 50);
                oledbParam[86].Value = HavingSMEAccountWithOtherInstitution;

                oledbParam[87] = new OleDbParameter("@NameOfInstitution", OleDbType.VarChar, 100);
                oledbParam[87].Value = NameOfInstitution;

                
                oledbParam[88] = new OleDbParameter("@RV_COMMENT", OleDbType.VarChar, 750);
                oledbParam[88].Value = NameRVComment;

                oledbParam[89] = new OleDbParameter("@Supervisorname", OleDbType.VarChar, 200);
                oledbParam[89].Value = SupervisorName;

                oledbParam[90] = new OleDbParameter("@Supdatetime", OleDbType.VarChar, 50);
                oledbParam[90].Value = SupervisorDateTime;

                oledbParam[91] = new OleDbParameter("@veritime", OleDbType.VarChar,50);
                oledbParam[91].Value = VerifierDatetime;

                oledbParam[92] = new OleDbParameter("@Teleremark", OleDbType.VarChar, 1000);
                oledbParam[92].Value = TeleRemark;

                oledbParam[93] = new OleDbParameter("@ContactedPerson", OleDbType.VarChar, 200);
                oledbParam[93].Value = ContactPerson;

                oledbParam[94] = new OleDbParameter("@ProprietorPartenrMet", OleDbType.VarChar, 50);
                oledbParam[94].Value = ProprietorPartenerMet;

                oledbParam[95] = new OleDbParameter("@BisinessActivity", OleDbType.VarChar, 50);
                oledbParam[95].Value = BusinessActivity;

                oledbParam[96] = new OleDbParameter("@Remark", OleDbType.VarChar, 2000);
                oledbParam[96].Value = OverallRemark;

                oledbParam[97] = new OleDbParameter("@Modifyby", OleDbType.VarChar, 15);
                oledbParam[97].Value = HttpContext.Current.Session["UserId"];

                oledbParam[98] = new OleDbParameter("@ModifyDate", OleDbType.DBTimeStamp, 8);
                oledbParam[98].Value = System.DateTime.Now;

                oledbParam[99] = new OleDbParameter("@VerifierName", OleDbType.VarChar, 100);
                oledbParam[99].Value = VerifierName;

                oledbParam[100] = new OleDbParameter("@CityLimit", OleDbType.VarChar, 100);
                oledbParam[100].Value = CityLimit; 

                /////////////////////////tcm code///////////////////////////////

                oledbParam[101] = new OleDbParameter("@Website", OleDbType.VarChar, 500);
                oledbParam[101].Value = Website;

                oledbParam[102] = new OleDbParameter("@CompRegiCheckSince", OleDbType.VarChar, 500);
                oledbParam[102].Value = CompRegiCheckSince;

                oledbParam[103] = new OleDbParameter("@CompRegiCheckSinceRegNo", OleDbType.VarChar, 500);
                oledbParam[103].Value = CompRegiCheckSinceRegNo;

                oledbParam[104] = new OleDbParameter("@CompRegiCheckRemark", OleDbType.VarChar, 500);
                oledbParam[104].Value = CompRegiCheckRemark;

                oledbParam[105] = new OleDbParameter("@Location_Profile", OleDbType.VarChar, 500);
                oledbParam[105].Value = Location_Profile;

                oledbParam[106] = new OleDbParameter("@bldg_Profile", OleDbType.VarChar, 500);
                oledbParam[106].Value = bldg_Profile;

                oledbParam[107] = new OleDbParameter("@Flr_Profile", OleDbType.VarChar, 500);
                oledbParam[107].Value = Flr_Profile;

                oledbParam[108] = new OleDbParameter("@Flr_Profile_left_neigh", OleDbType.VarChar, 500);
                oledbParam[108].Value = Flr_Profile_left_neigh;

                oledbParam[109] = new OleDbParameter("@Flr_Profile_Flr_above", OleDbType.VarChar, 500);
                oledbParam[109].Value = Flr_Profile_Flr_above;

                oledbParam[110] = new OleDbParameter("@Flr_Profile_Flr_belwo", OleDbType.VarChar, 500);
                oledbParam[110].Value = Flr_Profile_Flr_belwo;

                oledbParam[111] = new OleDbParameter("@Name_board_out_Office", OleDbType.VarChar, 500);
                oledbParam[111].Value = Name_board_out_Office;

                oledbParam[112] = new OleDbParameter("@Name_board_Lobby_area", OleDbType.VarChar, 500);
                oledbParam[112].Value = Name_board_Lobby_area;

                oledbParam[113] = new OleDbParameter("@asso_company", OleDbType.VarChar, 500);
                oledbParam[113].Value = asso_company;

                oledbParam[114] = new OleDbParameter("@Gen_Interior", OleDbType.VarChar, 500);
                oledbParam[114].Value = Gen_Interior;

                oledbParam[115] = new OleDbParameter("@No_workstations", OleDbType.VarChar, 500);
                oledbParam[115].Value = No_workstations;

                oledbParam[116] = new OleDbParameter("@owner_cabin", OleDbType.VarChar, 500);
                oledbParam[116].Value = owner_cabin;

                oledbParam[117] = new OleDbParameter("@landlord", OleDbType.VarChar, 500);
                oledbParam[117].Value = landlord;

                oledbParam[118] = new OleDbParameter("@Proppery_resi", OleDbType.VarChar, 500);
                oledbParam[118].Value = Proppery_resi;

                oledbParam[119] = new OleDbParameter("@Proppery_comm", OleDbType.VarChar, 500);
                oledbParam[119].Value = Proppery_comm;

                oledbParam[120] = new OleDbParameter("@Proppery_shop", OleDbType.VarChar, 500);
                oledbParam[120].Value = Proppery_shop;

                oledbParam[121] = new OleDbParameter("@Comments_Neighbour", OleDbType.VarChar, 500);
                oledbParam[121].Value = DoNeighbourKnowTheCustomerForFemu;

                oledbParam[122] = new OleDbParameter("@Locality", OleDbType.VarChar, 500);
                oledbParam[122].Value = Locality;

                oledbParam[123] = new OleDbParameter("@NoOfEmp", OleDbType.VarChar, 500);
                oledbParam[123].Value = NoOfEmp;

                oledbParam[124] = new OleDbParameter("@NoOfComputer", OleDbType.VarChar, 500);
                oledbParam[124].Value = NoOfComputer;

                oledbParam[125] = new OleDbParameter("@NoOfTelephone", OleDbType.VarChar, 500);
                oledbParam[125].Value = NoOfTelephone;

                oledbParam[126] = new OleDbParameter("@NoOfFloor", OleDbType.VarChar, 500);
                oledbParam[126].Value = NoOfFloor;

                oledbParam[127] = new OleDbParameter("@customerexiswhichfloor", OleDbType.VarChar, 500);
                oledbParam[127].Value = customerexiswhichfloor;


                oledbParam[128] = new OleDbParameter("@Ownershipofresidence", OleDbType.VarChar, 500);
                oledbParam[128].Value = Ownershipofresidence;

                oledbParam[129] = new OleDbParameter("@Rationcardavailable", OleDbType.VarChar, 500);
                oledbParam[129].Value = Rationcardavailable;

                oledbParam[130] = new OleDbParameter("@MetToapplicant", OleDbType.VarChar, 500);
                oledbParam[130].Value = MetToapplicant;

                oledbParam[131] = new OleDbParameter("@Differncesfound", OleDbType.VarChar, 500);
                oledbParam[131].Value = Differncesfound;

                oledbParam[132] = new OleDbParameter("@Actiontaken", OleDbType.VarChar, 500);
                oledbParam[132].Value = Actiontaken;

                oledbParam[133] = new OleDbParameter("@Occuption", OleDbType.VarChar, 500);
                oledbParam[133].Value = Occuption;

                oledbParam[134] = new OleDbParameter("@Occupationdetails", OleDbType.VarChar, 500);
                oledbParam[134].Value = Occupationdetails;

                oledbParam[135] = new OleDbParameter("@NATUREOFDSCREPANCY", OleDbType.VarChar, 500);
                oledbParam[135].Value = NATUREOFDSCREPANCY;

                //added by SANKET
                oledbParam[136] = new OleDbParameter("@Standard_Remark", OleDbType.VarChar, 100);
                oledbParam[136].Value = StandardRemark;
                //end

                //Added by SANKET for Kunverji
                oledbParam[137] = new OleDbParameter("@OfficeType", OleDbType.VarChar, 100);
                oledbParam[137].Value = OfficeType;
                oledbParam[138] = new OleDbParameter("@OCL_distance", OleDbType.VarChar, 100);
                oledbParam[138].Value = OCL_distance;
                oledbParam[139] = new OleDbParameter("@OfficeInternal", OleDbType.VarChar, 100);
                oledbParam[139].Value = OfficeInternal;
                //end for Kunverji


                oledbParam[140] = new OleDbParameter("@CaseId", OleDbType.VarChar, 15);
                oledbParam[140].Value = CaseId;

                oledbParam[141] = new OleDbParameter("@VerificationTypeId", OleDbType.VarChar, 4);
                oledbParam[141].Value = VerificationTypeId;

                msg = "Record Updated Sucessfully";
            }
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql, oledbParam);


            OleDbParameter[] oledbParamCaseDetail = new OleDbParameter[5];
            sql = "Update CPV_KYC_CASE_DETAILS Set DOB=?,RES_PHONE=?,MOBILE=?,CASE_STATUS_ID=? " +
                 "  where case_id=? ";
                  /////and VERIFICATION_TYPE_ID=? ";

            oledbParamCaseDetail[0] = new OleDbParameter("@DateOfBirth", OleDbType.VarChar);
            oledbParamCaseDetail[0].Value = DateOfBirth;

            oledbParamCaseDetail[1] = new OleDbParameter("@PhoneNo", OleDbType.VarChar, 50);
            oledbParamCaseDetail[1].Value = PhoneNo;

            oledbParamCaseDetail[2] = new OleDbParameter("@MobileNo", OleDbType.VarChar, 50);
            oledbParamCaseDetail[2].Value = MobileNo;

            oledbParamCaseDetail[3] = new OleDbParameter("@CaseStatusId", OleDbType.VarChar, 50);
            oledbParamCaseDetail[3].Value = CaseStatusId;

            oledbParamCaseDetail[4] = new OleDbParameter("@CaseId", OleDbType.VarChar, 15);
            oledbParamCaseDetail[4].Value = CaseId;  
         
            /////added by kamal matekar.....

            //oledbParamCaseDetail[5] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar, 15);
            //oledbParamCaseDetail[5].Value = VerificationTypeId;

            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql, oledbParamCaseDetail);

            //Start Insert into CASE_TRANSACTION_LOG -------------------
            sql = "";
            sql = "Insert into CASE_TRANSACTION_LOG(CASE_ID,VERIFICATION_TYPE_ID,USER_ID,TRANS_START,TRANS_END," +
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

            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql, paramTransLog);

            //End  Insert into CASE_TRANSACTION_LOG --------------------
            //Update CPV_CC_Case_details with status 'Y' ---------------
            if (VerificationTypeId == "25" || VerificationTypeId == "27")
            {
                if (IsVerificationComplete(oledbTrans, CaseId) == "true")
                {
                    QCVerificationComplete(oledbTrans, CaseId);
                    msg += " Case verification data entry completed.";
                }
            }
            else
            {
                if (IsVerificationComplete(oledbTrans, CaseId) == "true")
                {
                    VerificationComplete(oledbTrans, CaseId);
                    msg += " Case verification data entry completed.";
                }
            }
            //------------------------------------------------------------
            oledbTrans.Commit();
            oledbConn.Close();
            return msg;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("ErrorFound :" + ex.Message);
        }
    }


    public string InsertKYCVerificationDetailEntry()
    {
        OleDbConnection oledbConn = new OleDbConnection(oCmn.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        OleDbDataReader oledbDR1;
        string sqlQuery1 = "";
        string sql1 = "";
        string msg = "";

        try
        {
            ///added by kamal matekar....for CPV_KYC_CASE_VERIFICATION_Details

            sqlQuery1 = " Select case_id,Verification_type_id from CPV_KYC_CASE_VERIFICATION_Details " +
                      " where Case_ID = '" + CaseId + "'" + " And VERIFICATION_TYPE_ID='" + VerificationTypeId + "'";

            oledbDR1 = OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sqlQuery1);

            OleDbParameter[] oledbParam1 = new OleDbParameter[132];
            if (oledbDR1.Read() == false)
            {

                sql1 = " Insert into CPV_KYC_CASE_VERIFICATION_Details(Case_id,Verification_type_id,Type_Org,Card_No,Buss_Proof_Seen,Locality_Type, " +
                     " EquipmentSeen_OR_Shift_Arrangement,Observation_If_NotRecommended,Address_Neighbour,Neigh_Shop,Buss_Quip_Sight,TrigSVR,BranchName,BranchCode, " +
                     " RmName,RmCode,AccountNo,RmFormat,BllCase,BllSvr,NocName,TvTele,TvPerson,TvRelation,TvConAdd,TvCustId,DesBuild,BspName,IfNamePLate,NameOfficer,SiteVerifier,AccOpen, " +
                     " RetDel,Sign1,Sign2,Sign3,Sign4,Sign5,Sign6,Building,DesgBO,Buss_stock_seen,Father_Name,Father_Occupation,Mother_Name,Confirmationaddress,Thiredpartyconfirmation,Mettoapplicant,Rationcardavailable,AreaID," +
                     " applicantstayheare,Ownership,Tradingexperiencel,Noofmembers,vehical,Occuption,IfSalnameoftheoragnization, " +
                     " IfBusinessnatureofbusiness,carpark,TypeofResidence,EquipInOffice,ResidenceInternal,Construction,typeofflooring, " +
                     " TypeOfRoofing,Standardofliving,Assets,Anydisplayofpoliticalpartyseen,Inpersonverificationwiththeapplicant,Products,Reasonsfornotrecommended,Matchinnegativelists,Legal_Name,Visit_No,reachable,Setup_location,boardtype,connectivity,properarea,establishmentcertificate,type_of_furnishing,Premises_Maintenance_Quality,childlabourmarchant,childlabourneighbours,childlabouremployees,Logistics,Inventory,InventorySize,REGISTERATIONPROOF,ADDITIONALDOCUMENTS,warehouseaddress,Top1Item,Top2Item,Top3Item,Top4Item,producttype,nameboard,No_emp,YEARS_WORKEDmarchant,YEARS_WORKEDnei,YEARS_WORKEDemp,ID_Proof,Address_proof,weektimeduaration_from,weektimeduaration_to,weektimeduaration_days,fireexepresent,telecaller_name,telecaller_Address,telecaller_location,visit_reason,Personmet_reason,Setup_details,Associate,Not_Associate,Calling_behalf,Any_other_info,Person_Met,visited, " +
                    //Added by SANKET for Kunverji
                    "TradingexperienceYears,AppicantBusiness,AddressProofSighted,TypeofAddressProof,NameofPerson,ProductDealingIn,TurnOver1,doccumentryPrrof,Nameofindividual,Nameofindividualpersonmet,DoccumentryProofFurnished,Recommondation,landmark_verified)" +
                    //END for Kunverji


                     " values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                oledbParam1[0] = new OleDbParameter("@CaseId", OleDbType.VarChar, 15);
                oledbParam1[0].Value = CaseId;

                oledbParam1[1] = new OleDbParameter("@Verification_type_id", OleDbType.VarChar, 4);
                oledbParam1[1].Value = VerificationTypeId;

                oledbParam1[2] = new OleDbParameter("@Type_Org", OleDbType.VarChar, 500);
                oledbParam1[2].Value = Type_Org;

                oledbParam1[3] = new OleDbParameter("@Card_No", OleDbType.VarChar, 500);
                oledbParam1[3].Value = Card_No;

                oledbParam1[4] = new OleDbParameter("@Buss_Proof_Seen", OleDbType.VarChar, 500);
                oledbParam1[4].Value = Buss_Proof_Seen;

                oledbParam1[5] = new OleDbParameter("@Locality_Type", OleDbType.VarChar, 500);
                oledbParam1[5].Value = Locality_Type;

                oledbParam1[6] = new OleDbParameter("@EquipmentSeen_OR_Shift_Arrangement", OleDbType.VarChar, 500);
                oledbParam1[6].Value = EquipmentSeen_OR_Shift_Arrangement;

                oledbParam1[7] = new OleDbParameter("@Observation_If_NotRecommended", OleDbType.VarChar, 500);
                oledbParam1[7].Value = Observation_If_NotRecommended;

                oledbParam1[8] = new OleDbParameter("@Address_Neighbour", OleDbType.VarChar, 500);
                oledbParam1[8].Value = NameAddressNeighbour;

                oledbParam1[9] = new OleDbParameter("@Neigh_Shop", OleDbType.VarChar, 500);
                oledbParam1[9].Value = DoNeighbourKnowTheCustomerForFemu;

                oledbParam1[10] = new OleDbParameter("@Buss_Quip_Sight", OleDbType.VarChar, 500);
                oledbParam1[10].Value = BusinessEquipSightedFemu;

                oledbParam1[11] = new OleDbParameter("@TrigSVR", OleDbType.VarChar, 500);
                oledbParam1[11].Value = TrigSVR;

                oledbParam1[12] = new OleDbParameter("@BranchName", OleDbType.VarChar, 500);
                oledbParam1[12].Value = BranchName;

                oledbParam1[13] = new OleDbParameter("@BranchCode", OleDbType.VarChar, 500);
                oledbParam1[13].Value = BranchCode;

                oledbParam1[14] = new OleDbParameter("@RmName", OleDbType.VarChar, 500);
                oledbParam1[14].Value = RmName;

                oledbParam1[15] = new OleDbParameter("@RmCode", OleDbType.VarChar, 500);
                oledbParam1[15].Value = RmCode;

                oledbParam1[16] = new OleDbParameter("@AccountNo", OleDbType.VarChar, 500);
                oledbParam1[16].Value = AccountNo;

                oledbParam1[17] = new OleDbParameter("@RmFormat", OleDbType.VarChar, 500);
                oledbParam1[17].Value = RmFormat;

                oledbParam1[18] = new OleDbParameter("@BllCase", OleDbType.VarChar, 500);
                oledbParam1[18].Value = BllCase;

                oledbParam1[19] = new OleDbParameter("@BllSvr", OleDbType.VarChar, 500);
                oledbParam1[19].Value = BllSvr;

                oledbParam1[20] = new OleDbParameter("@NocName", OleDbType.VarChar, 500);
                oledbParam1[20].Value = NocName;

                oledbParam1[21] = new OleDbParameter("@TvTele", OleDbType.VarChar, 500);
                oledbParam1[21].Value = TvTele;

                oledbParam1[22] = new OleDbParameter("@TvPerson", OleDbType.VarChar, 500);
                oledbParam1[22].Value = TvPerson;

                oledbParam1[23] = new OleDbParameter("@TvRelation", OleDbType.VarChar, 500);
                oledbParam1[23].Value = TvRelation;

                oledbParam1[24] = new OleDbParameter("@TvConAdd", OleDbType.VarChar, 500);
                oledbParam1[24].Value = TvConAdd;

                oledbParam1[25] = new OleDbParameter("@TvCustId", OleDbType.VarChar, 500);
                oledbParam1[25].Value = TvCustId;

                oledbParam1[26] = new OleDbParameter("@DesBuild", OleDbType.VarChar, 500);
                oledbParam1[26].Value = DesBuild;

                oledbParam1[27] = new OleDbParameter("@BspName", OleDbType.VarChar, 500);
                oledbParam1[27].Value = BspName;

                oledbParam1[28] = new OleDbParameter("@IfNamePLate", OleDbType.VarChar, 500);
                oledbParam1[28].Value = IfNamePLate;

                oledbParam1[29] = new OleDbParameter("@NameOfficer", OleDbType.VarChar, 500);
                oledbParam1[29].Value = NameOfficer;

                oledbParam1[30] = new OleDbParameter("@SiteVerifier", OleDbType.VarChar, 500);
                oledbParam1[30].Value = SiteVerifier;

                oledbParam1[31] = new OleDbParameter("@AccOpen", OleDbType.VarChar, 500);
                oledbParam1[31].Value = AccOpen;

                oledbParam1[32] = new OleDbParameter("@RetDel", OleDbType.VarChar, 500);
                oledbParam1[32].Value = RetDel;

                oledbParam1[33] = new OleDbParameter("@Sign1", OleDbType.VarChar, 500);
                oledbParam1[33].Value = Sign1;

                oledbParam1[34] = new OleDbParameter("@Sign2", OleDbType.VarChar, 500);
                oledbParam1[34].Value = Sign2;

                oledbParam1[35] = new OleDbParameter("@Sign3", OleDbType.VarChar, 500);
                oledbParam1[35].Value = Sign3;

                oledbParam1[36] = new OleDbParameter("@Sign4", OleDbType.VarChar, 500);
                oledbParam1[36].Value = Sign4;

                oledbParam1[37] = new OleDbParameter("@Sign5", OleDbType.VarChar, 500);
                oledbParam1[37].Value = Sign5;

                oledbParam1[38] = new OleDbParameter("@Sign6", OleDbType.VarChar, 500);
                oledbParam1[38].Value = Sign6;

                oledbParam1[39] = new OleDbParameter("@Building", OleDbType.VarChar, 500);
                oledbParam1[39].Value = Building;

                oledbParam1[40] = new OleDbParameter("@DesgBO", OleDbType.VarChar, 500);
                oledbParam1[40].Value = DesgBO;

                oledbParam1[41] = new OleDbParameter("@Stock", OleDbType.VarChar, 500);
                oledbParam1[41].Value = Stock;

                oledbParam1[42] = new OleDbParameter("@DocVeri", OleDbType.VarChar, 500);
                oledbParam1[42].Value = DocVeri;

                oledbParam1[43] = new OleDbParameter("@NeighAware", OleDbType.VarChar, 500);
                oledbParam1[43].Value = NeighAware;

                oledbParam1[44] = new OleDbParameter("@AuthoSign", OleDbType.VarChar, 500);
                oledbParam1[44].Value = AuthoSign;

                oledbParam1[45] = new OleDbParameter("@Confirmationaddress", OleDbType.VarChar, 500);
                oledbParam1[45].Value = Confirmationaddress;

                oledbParam1[46] = new OleDbParameter("@Thiredpartyconfirmation", OleDbType.VarChar, 500);
                oledbParam1[46].Value = Thiredpartyconfirmation;

                oledbParam1[47] = new OleDbParameter("@MetToapplicant", OleDbType.VarChar, 500);
                oledbParam1[47].Value = MetToapplicant;

                oledbParam1[48] = new OleDbParameter("@Rationcardavailable", OleDbType.VarChar, 500);
                oledbParam1[48].Value = Rationcardavailable;

                oledbParam1[49] = new OleDbParameter("@AreaID", OleDbType.VarChar, 100);
                oledbParam1[49].Value = AreaID;

                oledbParam1[50] = new OleDbParameter("@applicantstayheare", OleDbType.VarChar, 500);
                oledbParam1[50].Value = applicantstayheare;

                oledbParam1[51] = new OleDbParameter("@Ownership", OleDbType.VarChar, 500);
                oledbParam1[51].Value = Ownership;

                oledbParam1[52] = new OleDbParameter("@Tradingexperiencel", OleDbType.VarChar, 500);
                oledbParam1[52].Value = Tradingexperiencel;

                oledbParam1[53] = new OleDbParameter("@Noofmembers", OleDbType.VarChar, 500);
                oledbParam1[53].Value = Noofmembers;

                oledbParam1[54] = new OleDbParameter("@vehical", OleDbType.VarChar, 500);
                oledbParam1[54].Value = vehical;

                oledbParam1[55] = new OleDbParameter("@Occuption", OleDbType.VarChar, 500);
                oledbParam1[55].Value = Occuption;

                oledbParam1[56] = new OleDbParameter("@IfSalnameoftheoragnization", OleDbType.VarChar, 500);
                oledbParam1[56].Value = IfSalnameoftheoragnization;

                oledbParam1[57] = new OleDbParameter("@IfBusinessnatureofbusiness", OleDbType.VarChar, 500);
                oledbParam1[57].Value = IfBusinessnatureofbusiness;

                oledbParam1[58] = new OleDbParameter("@carpark", OleDbType.VarChar, 500);
                oledbParam1[58].Value = carpark;

                oledbParam1[59] = new OleDbParameter("@TypeofResidence", OleDbType.VarChar, 500);
                oledbParam1[59].Value = TypeofResidence;

                oledbParam1[60] = new OleDbParameter("@EquipInOffice", OleDbType.VarChar, 500);
                oledbParam1[60].Value = EquipInOffice;

                oledbParam1[61] = new OleDbParameter("@ResidenceInternal", OleDbType.VarChar, 500);
                oledbParam1[61].Value = ResidenceInternal;

                oledbParam1[62] = new OleDbParameter("@Construction", OleDbType.VarChar, 500);
                oledbParam1[62].Value = Construction;

                oledbParam1[63] = new OleDbParameter("@typeofflooring", OleDbType.VarChar, 500);
                oledbParam1[63].Value = typeofflooring;

                oledbParam1[64] = new OleDbParameter("@TypeOfRoofing", OleDbType.VarChar, 500);
                oledbParam1[64].Value = TypeOfRoofing;

                oledbParam1[65] = new OleDbParameter("@Standardofliving", OleDbType.VarChar, 500);
                oledbParam1[65].Value = Standardofliving;

                oledbParam1[66] = new OleDbParameter("@Assets", OleDbType.VarChar, 500);
                oledbParam1[66].Value = Assets;

                oledbParam1[67] = new OleDbParameter("@Anydisplayofpoliticalpartyseen", OleDbType.VarChar, 500);
                oledbParam1[67].Value = Anydisplayofpoliticalpartyseen;

                oledbParam1[68] = new OleDbParameter("@Inpersonverificationwiththeapplicant", OleDbType.VarChar, 500);
                oledbParam1[68].Value = Inpersonverificationwiththeapplicant;

                oledbParam1[69] = new OleDbParameter("@Products", OleDbType.VarChar, 500);
                oledbParam1[69].Value = Products;

                oledbParam1[70] = new OleDbParameter("@Reasonsfornotrecommended", OleDbType.VarChar, 500);
                oledbParam1[70].Value = Reasonsfornotrecommended;

                oledbParam1[71] = new OleDbParameter("@Matchinnegativelists", OleDbType.VarChar, 500);
                oledbParam1[71].Value = Matchinnegativelists;


                oledbParam1[72] = new OleDbParameter("@Legal_Name", OleDbType.VarChar, 100);
                oledbParam1[72].Value = legalname;


                oledbParam1[73] = new OleDbParameter("@Visit_No", OleDbType.VarChar, 50);
                oledbParam1[73].Value = visitno;


                oledbParam1[74] = new OleDbParameter("@reachable", OleDbType.VarChar, 50);
                oledbParam1[74].Value = reachable;

                oledbParam1[75] = new OleDbParameter("@Setup_location", OleDbType.VarChar, 100);
                oledbParam1[75].Value = setuplocation;

                oledbParam1[76] = new OleDbParameter("@boardtype", OleDbType.VarChar, 50);
                oledbParam1[76].Value = boardtype;


                oledbParam1[77] = new OleDbParameter("@connectivity", OleDbType.VarChar, 100);
                oledbParam1[77].Value = connectivity;


                oledbParam1[78] = new OleDbParameter("@properarea", OleDbType.VarChar, 100);
                oledbParam1[78].Value = properarea;



                oledbParam1[79] = new OleDbParameter("@establishmentcertificate", OleDbType.VarChar, 100);
                oledbParam1[79].Value = establishmentcertificate;



                oledbParam1[80] = new OleDbParameter("@type_of_furnishing", OleDbType.VarChar, 100);
                oledbParam1[80].Value = typeoffurnishing;




                oledbParam1[81] = new OleDbParameter("@Premises_Maintenance_Quality", OleDbType.VarChar, 100);
                oledbParam1[81].Value = PremisesMaintenanceQuality;



                oledbParam1[82] = new OleDbParameter("@childlabourmarchant", OleDbType.VarChar, 100);
                oledbParam1[82].Value = childlabourmarchant;


                oledbParam1[83] = new OleDbParameter("@childlabourneighbours", OleDbType.VarChar, 100);
                oledbParam1[83].Value = childlabourneighbours;


                oledbParam1[84] = new OleDbParameter("@childlabouremployees", OleDbType.VarChar, 100);
                oledbParam1[84].Value = childlabouremployees;

                oledbParam1[85] = new OleDbParameter("@Logistics", OleDbType.VarChar, 100);
                oledbParam1[85].Value = Logistics;


                oledbParam1[86] = new OleDbParameter("@Inventory", OleDbType.VarChar, 100);
                oledbParam1[86].Value = Inventory;


                oledbParam1[87] = new OleDbParameter("@InventorySize", OleDbType.VarChar, 50);
                oledbParam1[87].Value = InventorySize;


                oledbParam1[88] = new OleDbParameter("@REGISTERATIONPROOF", OleDbType.VarChar, 500);
                oledbParam1[88].Value = REGISTERATIONPROOF;

                oledbParam1[89] = new OleDbParameter("@ADDITIONALDOCUMENTS", OleDbType.VarChar, 500);
                oledbParam1[89].Value = ADDITIONALDOCUMENTS;

                oledbParam1[90] = new OleDbParameter("@warehouseaddress", OleDbType.VarChar, 1000);
                oledbParam1[90].Value = warehouseaddress;

                oledbParam1[91] = new OleDbParameter("@Top1Item", OleDbType.VarChar, 100);
                oledbParam1[91].Value = Top1Item;


                oledbParam1[92] = new OleDbParameter("@Top2Item", OleDbType.VarChar, 100);
                oledbParam1[92].Value = Top2Item;


                oledbParam1[93] = new OleDbParameter("@Top3Item", OleDbType.VarChar, 100);
                oledbParam1[93].Value = Top3Item;


                oledbParam1[94] = new OleDbParameter("@Top4Item", OleDbType.VarChar, 100);
                oledbParam1[94].Value = Top4Item;

                oledbParam1[95] = new OleDbParameter("@producttype", OleDbType.VarChar, 50);
                oledbParam1[95].Value = producttype;





                oledbParam1[96] = new OleDbParameter("@nameboard", OleDbType.VarChar, 50);
                oledbParam1[96].Value = nameboard;


                oledbParam1[97] = new OleDbParameter("@No_emp", OleDbType.VarChar, 50);
                oledbParam1[97].Value = Noofemployee;

                oledbParam1[98] = new OleDbParameter("@YEARS_WORKEDmarchant", OleDbType.VarChar, 100);
                oledbParam1[98].Value = YearsWorkInmarchant;

                oledbParam1[99] = new OleDbParameter("@YEARS_WORKEDnei", OleDbType.VarChar, 100);
                oledbParam1[99].Value = YearsWorkInnei;


                oledbParam1[100] = new OleDbParameter("@YEARS_WORKEDemp", OleDbType.VarChar, 100);
                oledbParam1[100].Value = YearsWorkInemp;

                oledbParam1[101] = new OleDbParameter("@ID_Proof", OleDbType.VarChar, 100);
                oledbParam1[101].Value = Idproof;

                oledbParam1[102] = new OleDbParameter("@Address_proof", OleDbType.VarChar, 100);
                oledbParam1[102].Value = Addressproof;

                oledbParam1[103] = new OleDbParameter("@weektimeduaration_from", OleDbType.VarChar, 100);
                oledbParam1[103].Value = worktimedurationfrom;

                oledbParam1[104] = new OleDbParameter("@weektimeduaration_to", OleDbType.VarChar, 100);
                oledbParam1[104].Value = worktimedurationto;

                oledbParam1[105] = new OleDbParameter("@weektimeduaration_days", OleDbType.VarChar, 100);
                oledbParam1[105].Value = worktimedurationdays;

                oledbParam1[106] = new OleDbParameter("@fireexepresent", OleDbType.VarChar, 100);
                oledbParam1[106].Value = fireexepresent;
                oledbParam1[107] = new OleDbParameter("@telecaller_name", OleDbType.VarChar, 100);
                oledbParam1[107].Value = telecallername;

                oledbParam1[108] = new OleDbParameter("@telecaller_Address", OleDbType.VarChar, 100);
                oledbParam1[108].Value = telecalleraddress;

                oledbParam1[109] = new OleDbParameter("@telecaller_location", OleDbType.VarChar, 100);
                oledbParam1[109].Value = telecallerloc;

                oledbParam1[110] = new OleDbParameter("@visit_reason", OleDbType.VarChar, 1000);
                oledbParam1[110].Value = visitreason;

                oledbParam1[111] = new OleDbParameter("@Personmet_reason", OleDbType.VarChar, 1000);
                oledbParam1[111].Value = personmetreason;

                oledbParam1[112] = new OleDbParameter("@Setup_details", OleDbType.VarChar, 1000);
                oledbParam1[112].Value = setupdetails;

                oledbParam1[113] = new OleDbParameter("@Associate", OleDbType.VarChar, 1000);
                oledbParam1[113].Value = personassociateofHDFCBank;

                oledbParam1[114] = new OleDbParameter("@Not_Associate", OleDbType.VarChar, 1000);
                oledbParam1[114].Value = personnotassociateofHDFCBank;

                oledbParam1[115] = new OleDbParameter("@Calling_behalf", OleDbType.VarChar, 1000);
                oledbParam1[115].Value = theReasonofCallingBehalfofHDFCBank;

                oledbParam1[116] = new OleDbParameter("@Any_other_info", OleDbType.VarChar, 1000);
                oledbParam1[116].Value = anyothrinformation;

                oledbParam1[117] = new OleDbParameter("@Person_Met", OleDbType.VarChar, 100);
                oledbParam1[117].Value = personmet;

                oledbParam1[118] = new OleDbParameter("@visited", OleDbType.VarChar, 100);
                oledbParam1[118].Value = visited;


                //Added by SANKET for Kunverji

                oledbParam1[119] = new OleDbParameter("@TradingexperienceYears", OleDbType.VarChar, 100);
                oledbParam1[119].Value = TradingexperienceYears;
                oledbParam1[120] = new OleDbParameter("@AppicantBusiness", OleDbType.VarChar, 100);
                oledbParam1[120].Value = AppicantBusiness;
                oledbParam1[121] = new OleDbParameter("@AddressProofSighted", OleDbType.VarChar, 100);
                oledbParam1[121].Value = AddressProofSighted;
                oledbParam1[122] = new OleDbParameter("@TypeofAddressProof", OleDbType.VarChar, 500);
                oledbParam1[122].Value = TypeofAddressProof;
                oledbParam1[123] = new OleDbParameter("@NameofPerson", OleDbType.VarChar, 100);
                oledbParam1[123].Value = NameofPerson;

                //END for Kunverji


                //added by abhijeet for kotak//


                //added by abhijeet for Kotak//
                oledbParam1[124] = new OleDbParameter("@ProductDealingIn", OleDbType.VarChar, 100);
                oledbParam1[124].Value = ProductDealingIn;

                oledbParam1[125] = new OleDbParameter("@TurnOver1", OleDbType.VarChar, 100);
                oledbParam1[125].Value = TurnOver1;

                oledbParam1[126] = new OleDbParameter("@doccumentryPrrof", OleDbType.VarChar, 100);
                oledbParam1[126].Value = doccumentryPrrof;

                oledbParam1[127] = new OleDbParameter("@Nameofindividual", OleDbType.VarChar, 100);
                oledbParam1[127].Value = Nameofindividual;

                oledbParam1[128] = new OleDbParameter("@Nameofindividualpersonmet", OleDbType.VarChar, 100);
                oledbParam1[128].Value = Nameofindividualpersonmet;


                oledbParam1[129] = new OleDbParameter("@DoccumentryProofFurnished", OleDbType.VarChar, 1000);
                oledbParam1[129].Value = DoccumentryProofFurnished;


                oledbParam1[130] = new OleDbParameter("@Recommondation", OleDbType.VarChar, 100);
                oledbParam1[130].Value = Recommondation;

                //ended By abhijeet for kotak//
                //ended by abhijeet for Kotak//

                //----add by kanchan---//
                oledbParam1[131] = new OleDbParameter("@landmark_verified", OleDbType.VarChar, 100);
                oledbParam1[131].Value = LandmarkVerified;
                //-----comp----//

                msg = "Record Added Sucessfully";

            }
            else
            {
                sql1 = "Update CPV_KYC_CASE_VERIFICATION_Details set Type_Org=?,Card_No=?,Buss_Proof_Seen=?," +
                       "Locality_Type=?,EquipmentSeen_OR_Shift_Arrangement=?,Observation_If_NotRecommended=?,Address_Neighbour=?, " +
                       " Neigh_Shop=?,Buss_Quip_Sight=?,TrigSVR=?,BranchName=?,BranchCode=?,RmName=?,RmCode=?,AccountNo=?,RmFormat=?,BllCase=?,BllSvr=?, " +
                       " NocName=?,TvTele=?,TvPerson=?,TvRelation=?,TvConAdd=?,TvCustId=?,DesBuild=?,BspName=?,IfNamePLate=?,NameOfficer=?,SiteVerifier=?,AccOpen=?,RetDel=?,Sign1=?, " +
                       " Sign2=?,Sign3=?,Sign4=?,Sign5=?,Sign6=?,Building=?,DesgBO=?,Buss_stock_seen=?,Father_Name=?,Father_Occupation=?,Mother_Name=?,Confirmationaddress=?,Thiredpartyconfirmation=?,Mettoapplicant=?,Rationcardavailable=?,AreaID=?," +
                       " applicantstayheare=?,Ownership=?,Tradingexperiencel=?,Noofmembers=?,vehical=?,Occuption=?,IfSalnameoftheoragnization=?," +
                       " IfBusinessnatureofbusiness=?,carpark=?,TypeofResidence=?,EquipInOffice=?,ResidenceInternal=?,Construction=?,typeofflooring=?," +
                       " TypeOfRoofing=?,Standardofliving=?,Assets=?,Anydisplayofpoliticalpartyseen=?,Inpersonverificationwiththeapplicant=?,Products=?,Reasonsfornotrecommended=?,Matchinnegativelists=? ,Legal_Name=?,Visit_No=?,reachable=?,Setup_location=?,boardtype=?,connectivity=?,properarea=?,establishmentcertificate=?,type_of_furnishing=?,Premises_Maintenance_Quality=?,childlabourmarchant=?,childlabourneighbours=?,childlabouremployees=?,Logistics=?,Inventory=?,InventorySize=?,REGISTERATIONPROOF=?,ADDITIONALDOCUMENTS=?,warehouseaddress=?,Top1Item=?,Top2Item=?,Top3Item=?,Top4Item=?,producttype=?,nameboard=?,No_emp=?,YEARS_WORKEDmarchant=?,YEARS_WORKEDnei=?,YEARS_WORKEDemp=?,ID_Proof=?,Address_proof=?,weektimeduaration_from=?,weektimeduaration_to=?,weektimeduaration_days=?,fireexepresent=?,telecaller_name=?,telecaller_Address=?,telecaller_location=?,visit_reason=?,Personmet_reason=?,Setup_details=?,Associate=?,Not_Associate=?,Calling_behalf=?,Any_other_info=?,Person_Met=?,visited=?," +
                    
                       //Added by SANKET for Kunverji
                    "TradingexperienceYears=?,AppicantBusiness=?,AddressProofSighted=?,TypeofAddressProof=?,NameofPerson=? ,ProductDealingIn=?,TurnOver=?,doccumentryPrrof=?,Nameofindividual=?,Nameofindividualpersonmet=?,DoccumentryProofFurnished=?,Recommondation=?,landmark_verified=?" +
                    //END for Kunverji
                       
                       " where case_id=? and Verification_type_id=? ";  

                oledbParam1[0] = new OleDbParameter("@Type_Org", OleDbType.VarChar, 500);
                oledbParam1[0].Value = Type_Org;

                oledbParam1[1] = new OleDbParameter("@Card_No", OleDbType.VarChar, 500);
                oledbParam1[1].Value = Card_No;

                oledbParam1[2] = new OleDbParameter("@Buss_Proof_Seen", OleDbType.VarChar, 500);
                oledbParam1[2].Value = Buss_Proof_Seen;

                oledbParam1[3] = new OleDbParameter("@Locality_Type", OleDbType.VarChar, 500);
                oledbParam1[3].Value = Locality_Type;

                oledbParam1[4] = new OleDbParameter("@EquipmentSeen_OR_Shift_Arrangement", OleDbType.VarChar, 500);
                oledbParam1[4].Value = EquipmentSeen_OR_Shift_Arrangement;

                oledbParam1[5] = new OleDbParameter("@Observation_If_NotRecommended", OleDbType.VarChar, 500);
                oledbParam1[5].Value = Observation_If_NotRecommended;

                oledbParam1[6] = new OleDbParameter("@Address_Neighbour", OleDbType.VarChar, 500);
                oledbParam1[6].Value = NameAddressNeighbour;

                oledbParam1[7] = new OleDbParameter("@Neigh_Shop", OleDbType.VarChar, 500);
                oledbParam1[7].Value = DoNeighbourKnowTheCustomerForFemu;

                oledbParam1[8] = new OleDbParameter("@Buss_Quip_Sight", OleDbType.VarChar, 500);
                oledbParam1[8].Value = BusinessEquipSightedFemu;

                oledbParam1[9] = new OleDbParameter("@TrigSVR", OleDbType.VarChar, 500);
                oledbParam1[9].Value = TrigSVR;

                oledbParam1[10] = new OleDbParameter("@BranchName", OleDbType.VarChar, 500);
                oledbParam1[10].Value = BranchName;

                oledbParam1[11] = new OleDbParameter("@BranchCode", OleDbType.VarChar, 500);
                oledbParam1[11].Value = BranchCode;

                oledbParam1[12] = new OleDbParameter("@RmName", OleDbType.VarChar, 500);
                oledbParam1[12].Value = RmName;

                oledbParam1[13] = new OleDbParameter("@RmCode", OleDbType.VarChar, 500);
                oledbParam1[13].Value = RmCode;

                oledbParam1[14] = new OleDbParameter("@AccountNo", OleDbType.VarChar, 500);
                oledbParam1[14].Value = AccountNo;

                oledbParam1[15] = new OleDbParameter("@RmFormat", OleDbType.VarChar, 500);
                oledbParam1[15].Value = RmFormat;

                oledbParam1[16] = new OleDbParameter("@BllCase", OleDbType.VarChar, 500);
                oledbParam1[16].Value = BllCase;

                oledbParam1[17] = new OleDbParameter("@BllSvr", OleDbType.VarChar, 500);
                oledbParam1[17].Value = BllSvr;

                oledbParam1[18] = new OleDbParameter("@NocName", OleDbType.VarChar, 500);
                oledbParam1[18].Value = NocName;

                oledbParam1[19] = new OleDbParameter("@TvTele", OleDbType.VarChar, 500);
                oledbParam1[19].Value = TvTele;

                oledbParam1[20] = new OleDbParameter("@TvPerson", OleDbType.VarChar, 500);
                oledbParam1[20].Value = TvPerson;

                oledbParam1[21] = new OleDbParameter("@TvRelation", OleDbType.VarChar, 500);
                oledbParam1[21].Value = TvRelation;

                oledbParam1[22] = new OleDbParameter("@TvConAdd", OleDbType.VarChar, 500);
                oledbParam1[22].Value = TvConAdd;

                oledbParam1[23] = new OleDbParameter("@TvCustId", OleDbType.VarChar, 500);
                oledbParam1[23].Value = TvCustId;

                oledbParam1[24] = new OleDbParameter("@DesBuild", OleDbType.VarChar, 500);
                oledbParam1[24].Value = DesBuild;

                oledbParam1[25] = new OleDbParameter("@BspName", OleDbType.VarChar, 500);
                oledbParam1[25].Value = BspName;

                oledbParam1[26] = new OleDbParameter("@IfNamePLate", OleDbType.VarChar, 500);
                oledbParam1[26].Value = IfNamePLate;

                oledbParam1[27] = new OleDbParameter("@NameOfficer", OleDbType.VarChar, 500);
                oledbParam1[27].Value = NameOfficer;

                oledbParam1[28] = new OleDbParameter("@SiteVerifier", OleDbType.VarChar, 500);
                oledbParam1[28].Value = SiteVerifier;

                oledbParam1[29] = new OleDbParameter("@AccOpen", OleDbType.VarChar, 500);
                oledbParam1[29].Value = AccOpen;

                oledbParam1[30] = new OleDbParameter("@RetDel", OleDbType.VarChar, 500);
                oledbParam1[30].Value = RetDel;

                oledbParam1[31] = new OleDbParameter("@Sign1", OleDbType.VarChar, 500);
                oledbParam1[31].Value = Sign1;

                oledbParam1[32] = new OleDbParameter("@Sign2", OleDbType.VarChar, 500);
                oledbParam1[32].Value = Sign2;

                oledbParam1[33] = new OleDbParameter("@Sign3", OleDbType.VarChar, 500);
                oledbParam1[33].Value = Sign3;

                oledbParam1[34] = new OleDbParameter("@Sign4", OleDbType.VarChar, 500);
                oledbParam1[34].Value = Sign4;

                oledbParam1[35] = new OleDbParameter("@Sign5", OleDbType.VarChar, 500);
                oledbParam1[35].Value = Sign5;

                oledbParam1[36] = new OleDbParameter("@Sign6", OleDbType.VarChar, 500);
                oledbParam1[36].Value = Sign6;

                oledbParam1[37] = new OleDbParameter("@Building", OleDbType.VarChar, 500);
                oledbParam1[37].Value = Building;

                oledbParam1[38] = new OleDbParameter("@DesgBO", OleDbType.VarChar, 500);
                oledbParam1[38].Value = DesgBO;

                oledbParam1[39] = new OleDbParameter("@Stock", OleDbType.VarChar, 500);
                oledbParam1[39].Value = Stock;

                oledbParam1[40] = new OleDbParameter("@DocVeri", OleDbType.VarChar, 500);
                oledbParam1[40].Value = DocVeri;

                oledbParam1[41] = new OleDbParameter("@NeighAware", OleDbType.VarChar, 500);
                oledbParam1[41].Value = NeighAware;

                oledbParam1[42] = new OleDbParameter("@AuthoSign", OleDbType.VarChar, 500);
                oledbParam1[42].Value = AuthoSign;


                oledbParam1[43] = new OleDbParameter("@Confirmationaddress", OleDbType.VarChar, 500);
                oledbParam1[43].Value = Confirmationaddress;

                oledbParam1[44] = new OleDbParameter("@Thiredpartyconfirmation", OleDbType.VarChar, 500);
                oledbParam1[44].Value = Thiredpartyconfirmation;

                oledbParam1[45] = new OleDbParameter("@MetToapplicant", OleDbType.VarChar, 500);
                oledbParam1[45].Value = MetToapplicant;

                oledbParam1[46] = new OleDbParameter("@Rationcardavailable", OleDbType.VarChar, 500);
                oledbParam1[46].Value = Rationcardavailable;

                oledbParam1[47] = new OleDbParameter("@AreaID", OleDbType.VarChar, 100);
                oledbParam1[47].Value = AreaID;

                oledbParam1[48] = new OleDbParameter("@applicantstayheare", OleDbType.VarChar, 500);
                oledbParam1[48].Value = applicantstayheare;

                oledbParam1[49] = new OleDbParameter("@Ownership", OleDbType.VarChar, 500);
                oledbParam1[49].Value = Ownership;

                oledbParam1[50] = new OleDbParameter("@Tradingexperiencel", OleDbType.VarChar, 500);
                oledbParam1[50].Value = Tradingexperiencel;

                oledbParam1[51] = new OleDbParameter("@Noofmembers", OleDbType.VarChar, 500);
                oledbParam1[51].Value = Noofmembers;

                oledbParam1[52] = new OleDbParameter("@vehical", OleDbType.VarChar, 500);
                oledbParam1[52].Value = vehical;

                oledbParam1[53] = new OleDbParameter("@Occuption", OleDbType.VarChar, 500);
                oledbParam1[53].Value = Occuption;

                oledbParam1[54] = new OleDbParameter("@IfSalnameoftheoragnization", OleDbType.VarChar, 500);
                oledbParam1[54].Value = IfSalnameoftheoragnization;

                oledbParam1[55] = new OleDbParameter("@IfBusinessnatureofbusiness", OleDbType.VarChar, 500);
                oledbParam1[55].Value = IfBusinessnatureofbusiness;

                oledbParam1[56] = new OleDbParameter("@carpark", OleDbType.VarChar, 500);
                oledbParam1[56].Value = carpark;

                oledbParam1[57] = new OleDbParameter("@TypeofResidence", OleDbType.VarChar, 500);
                oledbParam1[57].Value = TypeofResidence;

                oledbParam1[58] = new OleDbParameter("@EquipInOffice", OleDbType.VarChar, 500);
                oledbParam1[58].Value = EquipInOffice;

                oledbParam1[59] = new OleDbParameter("@ResidenceInternal", OleDbType.VarChar, 500);
                oledbParam1[59].Value = ResidenceInternal;

                oledbParam1[60] = new OleDbParameter("@Construction", OleDbType.VarChar, 500);
                oledbParam1[60].Value = Construction;

                oledbParam1[61] = new OleDbParameter("@typeofflooring", OleDbType.VarChar, 500);
                oledbParam1[61].Value = typeofflooring;

                oledbParam1[62] = new OleDbParameter("@TypeOfRoofing", OleDbType.VarChar, 500);
                oledbParam1[62].Value = TypeOfRoofing;

                oledbParam1[63] = new OleDbParameter("@Standardofliving", OleDbType.VarChar, 500);
                oledbParam1[63].Value = Standardofliving;

                oledbParam1[64] = new OleDbParameter("@Assets", OleDbType.VarChar, 500);
                oledbParam1[64].Value = Assets;

                oledbParam1[65] = new OleDbParameter("@Anydisplayofpoliticalpartyseen", OleDbType.VarChar, 500);
                oledbParam1[65].Value = Anydisplayofpoliticalpartyseen;

                oledbParam1[66] = new OleDbParameter("@Inpersonverificationwiththeapplicant", OleDbType.VarChar, 500);
                oledbParam1[66].Value = Inpersonverificationwiththeapplicant;

                oledbParam1[67] = new OleDbParameter("@Products", OleDbType.VarChar, 500);
                oledbParam1[67].Value = Products;

                oledbParam1[68] = new OleDbParameter("@Reasonsfornotrecommended", OleDbType.VarChar, 500);
                oledbParam1[68].Value = Reasonsfornotrecommended;

                oledbParam1[69] = new OleDbParameter("@Matchinnegativelists", OleDbType.VarChar, 500);
                oledbParam1[69].Value = Matchinnegativelists;

                // added by abhijeet for pay-zippy//

                oledbParam1[70] = new OleDbParameter("@Legal_Name", OleDbType.VarChar, 100);
                oledbParam1[70].Value = legalname;


                oledbParam1[71] = new OleDbParameter("@Visit_No", OleDbType.VarChar, 50);
                oledbParam1[71].Value = visitno;


                oledbParam1[72] = new OleDbParameter("@reachable", OleDbType.VarChar, 50);
                oledbParam1[72].Value = reachable;

                oledbParam1[73] = new OleDbParameter("@Setup_location", OleDbType.VarChar, 100);
                oledbParam1[73].Value = setuplocation;

                oledbParam1[74] = new OleDbParameter("@boardtype", OleDbType.VarChar, 50);
                oledbParam1[74].Value = boardtype;


                oledbParam1[75] = new OleDbParameter("@connectivity", OleDbType.VarChar, 100);
                oledbParam1[75].Value = connectivity;


                oledbParam1[76] = new OleDbParameter("@properarea", OleDbType.VarChar, 100);
                oledbParam1[76].Value = properarea;



                oledbParam1[77] = new OleDbParameter("@establishmentcertificate", OleDbType.VarChar, 100);
                oledbParam1[77].Value = establishmentcertificate;



                oledbParam1[78] = new OleDbParameter("@type_of_furnishing", OleDbType.VarChar, 100);
                oledbParam1[78].Value = typeoffurnishing;




                oledbParam1[79] = new OleDbParameter("@Premises_Maintenance_Quality", OleDbType.VarChar, 100);
                oledbParam1[79].Value = PremisesMaintenanceQuality;



                oledbParam1[80] = new OleDbParameter("@childlabourmarchant", OleDbType.VarChar, 100);
                oledbParam1[80].Value = childlabourmarchant;


                oledbParam1[81] = new OleDbParameter("@childlabourneighbours", OleDbType.VarChar, 100);
                oledbParam1[81].Value = childlabourneighbours;


                oledbParam1[82] = new OleDbParameter("@childlabouremployees", OleDbType.VarChar, 100);
                oledbParam1[82].Value = childlabouremployees;

                oledbParam1[83] = new OleDbParameter("@Logistics", OleDbType.VarChar, 100);
                oledbParam1[83].Value = Logistics;


                oledbParam1[84] = new OleDbParameter("@Inventory", OleDbType.VarChar, 100);
                oledbParam1[84].Value = Inventory;


                oledbParam1[85] = new OleDbParameter("@InventorySize", OleDbType.VarChar, 50);
                oledbParam1[85].Value = InventorySize;


                oledbParam1[86] = new OleDbParameter("@REGISTERATIONPROOF", OleDbType.VarChar, 500);
                oledbParam1[86].Value = REGISTERATIONPROOF;

                oledbParam1[87] = new OleDbParameter("@ADDITIONALDOCUMENTS", OleDbType.VarChar, 500);
                oledbParam1[87].Value = ADDITIONALDOCUMENTS;

                oledbParam1[88] = new OleDbParameter("@warehouseaddress", OleDbType.VarChar, 1000);
                oledbParam1[88].Value = warehouseaddress;

                oledbParam1[89] = new OleDbParameter("@Top1Item", OleDbType.VarChar, 100);
                oledbParam1[89].Value = Top1Item;


                oledbParam1[90] = new OleDbParameter("@Top2Item", OleDbType.VarChar, 100);
                oledbParam1[90].Value = Top2Item;


                oledbParam1[91] = new OleDbParameter("@Top3Item", OleDbType.VarChar, 100);
                oledbParam1[91].Value = Top3Item;


                oledbParam1[92] = new OleDbParameter("@Top4Item", OleDbType.VarChar, 100);
                oledbParam1[92].Value = Top4Item;

                oledbParam1[93] = new OleDbParameter("@producttype", OleDbType.VarChar, 50);
                oledbParam1[93].Value = producttype;





                oledbParam1[94] = new OleDbParameter("@nameboard", OleDbType.VarChar, 50);
                oledbParam1[94].Value = nameboard;


                oledbParam1[95] = new OleDbParameter("@No_emp", OleDbType.VarChar, 50);
                oledbParam1[95].Value = Noofemployee;

                oledbParam1[96] = new OleDbParameter("@YEARS_WORKEDmarchant", OleDbType.VarChar, 100);
                oledbParam1[96].Value = YearsWorkInmarchant;

                oledbParam1[97] = new OleDbParameter("@YEARS_WORKEDnei", OleDbType.VarChar, 100);
                oledbParam1[97].Value = YearsWorkInnei;


                oledbParam1[98] = new OleDbParameter("@YEARS_WORKEDemp", OleDbType.VarChar, 100);
                oledbParam1[98].Value = YearsWorkInemp;

                oledbParam1[99] = new OleDbParameter("@ID_Proof", OleDbType.VarChar, 100);
                oledbParam1[99].Value = Idproof;

                oledbParam1[100] = new OleDbParameter("@Address_proof", OleDbType.VarChar, 100);
                oledbParam1[100].Value = Addressproof;

                oledbParam1[101] = new OleDbParameter("@weektimeduaration_from", OleDbType.VarChar, 100);
                oledbParam1[101].Value = worktimedurationfrom;

                oledbParam1[102] = new OleDbParameter("@weektimeduaration_to", OleDbType.VarChar, 100);
                oledbParam1[102].Value = worktimedurationto;

                oledbParam1[103] = new OleDbParameter("@weektimeduaration_days", OleDbType.VarChar, 100);
                oledbParam1[103].Value = worktimedurationdays;


                oledbParam1[104] = new OleDbParameter("@fireexepresent", OleDbType.VarChar, 100);
                oledbParam1[104].Value = fireexepresent;


                oledbParam1[105] = new OleDbParameter("@telecaller_name", OleDbType.VarChar, 100);
                oledbParam1[105].Value = telecallername;

                oledbParam1[106] = new OleDbParameter("@telecaller_Address", OleDbType.VarChar, 100);
                oledbParam1[106].Value = telecalleraddress;

                oledbParam1[107] = new OleDbParameter("@telecaller_location", OleDbType.VarChar, 100);
                oledbParam1[107].Value = telecallerloc;

                oledbParam1[108] = new OleDbParameter("@visit_reason", OleDbType.VarChar, 1000);
                oledbParam1[108].Value = visitreason;

                oledbParam1[109] = new OleDbParameter("@Personmet_reason", OleDbType.VarChar, 1000);
                oledbParam1[109].Value = personmetreason;

                oledbParam1[110] = new OleDbParameter("@Setup_details", OleDbType.VarChar, 1000);
                oledbParam1[110].Value = setupdetails;

                oledbParam1[111] = new OleDbParameter("@Associate", OleDbType.VarChar, 1000);
                oledbParam1[111].Value = personassociateofHDFCBank;

                oledbParam1[112] = new OleDbParameter("@Not_Associate", OleDbType.VarChar, 1000);
                oledbParam1[112].Value = personnotassociateofHDFCBank;

                oledbParam1[113] = new OleDbParameter("@Calling_behalf", OleDbType.VarChar, 1000);
                oledbParam1[113].Value = theReasonofCallingBehalfofHDFCBank;

                oledbParam1[114] = new OleDbParameter("@Any_other_info", OleDbType.VarChar, 1000);
                oledbParam1[114].Value = anyothrinformation;

                oledbParam1[115] = new OleDbParameter("@Person_Met", OleDbType.VarChar, 100);
                oledbParam1[115].Value = personmet;

                oledbParam1[116] = new OleDbParameter("@visited", OleDbType.VarChar, 100);
                oledbParam1[116].Value = visited;

                //ended by abhijeet for payzippy ///

                //Added by SANKET for Kunverji

                oledbParam1[117] = new OleDbParameter("@TradingexperienceYears", OleDbType.VarChar, 100);
                oledbParam1[117].Value = TradingexperienceYears;

                oledbParam1[118] = new OleDbParameter("@AppicantBusiness", OleDbType.VarChar, 100);
                oledbParam1[118].Value = AppicantBusiness;
                oledbParam1[119] = new OleDbParameter("@AddressProofSighted", OleDbType.VarChar, 100);
                oledbParam1[119].Value = AddressProofSighted;
                oledbParam1[120] = new OleDbParameter("@TypeofAddressProof", OleDbType.VarChar, 500);
                oledbParam1[120].Value = TypeofAddressProof;
                oledbParam1[121] = new OleDbParameter("@NameofPerson", OleDbType.VarChar, 100);
                oledbParam1[121].Value = NameofPerson;

                //END for Kunverji

                //added by abhijeet for kotak//

                oledbParam1[122] = new OleDbParameter("@ProductDealingIn", OleDbType.VarChar, 100);
                oledbParam1[122].Value = ProductDealingIn;

                oledbParam1[123] = new OleDbParameter("@TurnOver1", OleDbType.VarChar, 100);
                oledbParam1[123].Value = TurnOver1;

                oledbParam1[124] = new OleDbParameter("@doccumentryPrrof", OleDbType.VarChar, 100);
                oledbParam1[124].Value = doccumentryPrrof;

                oledbParam1[125] = new OleDbParameter("@Nameofindividual", OleDbType.VarChar, 100);
                oledbParam1[125].Value = Nameofindividual;

                oledbParam1[126] = new OleDbParameter("@Nameofindividualpersonmet", OleDbType.VarChar, 100);
                oledbParam1[126].Value = Nameofindividualpersonmet;


                oledbParam1[127] = new OleDbParameter("@DoccumentryProofFurnished", OleDbType.VarChar, 1000);
                oledbParam1[127].Value = DoccumentryProofFurnished;


                oledbParam1[128] = new OleDbParameter("@Recommondation", OleDbType.VarChar, 100);
                oledbParam1[128].Value = Recommondation;


                //----add by kanchan
                oledbParam1[129] = new OleDbParameter("@landmark_verified", OleDbType.VarChar, 100);
                oledbParam1[129].Value = LandmarkVerified;

                //----comp-----//


                //ended By abhijeet For kotak//


                oledbParam1[130] = new OleDbParameter("@CaseId", OleDbType.VarChar, 15);
                oledbParam1[130].Value = CaseId;

                oledbParam1[131] = new OleDbParameter("@Verification_type_id", OleDbType.VarChar, 4);
                oledbParam1[131].Value = VerificationTypeId;
                
                msg = "Record Updated Sucessfully";

            }

            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql1, oledbParam1);

            oledbTrans.Commit();
            oledbConn.Close();
            return msg;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("ErrorFound :" + ex.Message);
        }
    }



    public Int32 InsertTeleCallLog(ArrayList arrTeleCallLog)
    {
        OleDbConnection oledbConn = new OleDbConnection(oCmn.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        OleDbDataReader objoledbDR;
        String sqlSelectQuery = "";
        String sqlQuery = "";
        Int32 returnValue = 0;

        try
        {

            sqlSelectQuery = "Select CASE_ID,VERIFICATION_TYPE_ID from CPV_KYC_VERI_ATTEMPTS where CASE_ID='" + CaseId + "'" + "and VERIFICATION_TYPE_ID='" + VerificationTypeId + "'";
            objoledbDR = OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sqlSelectQuery);
            OleDbParameter[] oledbParam = new OleDbParameter[6];

            if (objoledbDR.Read() == true)
            {
                sqlQuery = "Delete from CPV_KYC_VERI_ATTEMPTS where CASE_ID='" + CaseId + "'" +
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

                sqlQuery = "Insert into CPV_KYC_VERI_ATTEMPTS(CASE_ID,ATTEMPT_DATE_TIME,REMARK,VERIFICATION_TYPE_ID,VERIFIER_ID,SubRemark) " +
                          "Values(?,?,?,?,?,?)";


                oledbParam[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
                oledbParam[0].Value = CaseId;

                oledbParam[1] = new OleDbParameter("@AttemptDateTime", OleDbType.VarChar);
                oledbParam[1].Value = AttemptDateTime;

                oledbParam[2] = new OleDbParameter("@Remark", OleDbType.VarChar, 1000);
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
            sSql = "Update CPV_KYC_CASE_DETAILS SET IS_CASE_COMPLETE='Y' WHERE CASE_ID='" + sCaseId + "'";
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

    public OleDbDataReader GetKYCVerificationEntry(string sCaseId, string sVerifyTypeID)
    {

        string sSql = "";
        

        sSql = "Select Company_Type,Name_Firm," +
                       " Business_Address,Business_Pincode,Bussiness_tel_no,Person_Contacted,Name_person_contacted,Designation," +
                       " Premise_Location,Prominent_Landmark,Address_Verified_is,How_long_Business,Area_Premises,Ownership_Premises,Type_Premise, " + 
                       " Type_Premise_Other,Nature_Business,business_occupation_details,Firm_Signboard_Sighted,Sign_Sighted_Remark,Type_Document_Sighted,Document_Sighted_Remark, " + 
                       " Used_Pages_Sighted_Date,Issued_to,Initial_Invoice_Sighted_No,Initial_Invoice_Sighted_Date,Initial_Invoice_issued_to,Third_Party_Invoice_No,Third_Party_Invoice_Date, " + 
                       " Third_Party_Invoice_Issued_by,Third_Party_Address,Relationship_between,Business_Ownership,Level_Business_Activity,No_Employees,Business_Equipment_Sighted,Marital_Status," +
                       " Name_Displayed_Board,Relationship_with_Applicant,Staying_since_Resi,Status_Demat_Account,Name_Demat_Account,Broking_through_other," +
                       " Attitude_Person_Contacted,Rating,Status,Product,Verification_Agent,Residence_Address,Resi_Pincode,Resi_Tel_no,Resi_Landmark," +
                       " Permanent_Address,Permanent_Pincode,Permamnent_Tel_no,Business_Occupation_Details,Place_Visited,Area_Residence,Locating_Address," +
                       " Business_activity_Seen,Description_Res,General_Comments,Name_Account,Request_No,Name_CA_firms,Address_CA_Firm,firm_Exist_Address," +
                       " IS_CA_firm,Name_Person_CA_Certificate,IS_person_case_praticing,Person_issued_Cerificate_spoken,Cerificate_person_confirm,inconclusive_Reason,Email_ID,  " +
                       " Name_On_Sign_Board,Concern_Is_Related,Concern_Related_Name,Family_Member_Is,Family_Member_Name,Family_Member_Relationship,Other_Institution_Demat_Account,business_activity," +
                       " Name_Of_DP,Name_Plate_Of_App_Sighted,Entity_Type,Tele_No_CA_Firm,No_Years_Current_Employment,Other_Institution_SME_Account,Name_Of_Institution,RV_COMMENT,supervisor_name,sup_date_time,veri_date_time,Tlele_Remark,ContactPerson,properietor_Partener_Met,Remark,city_limit, " +
                       " Website,CompRegiCheckSince,CompRegiCheckSinceRegNo,CompRegiCheckRemark,Location_Profile,bldg_Profile,Flr_Profile,Flr_Profile_left_neigh,Flr_Profile_Flr_above,Flr_Profile_Flr_belwo,Name_board_out_Office,Name_board_Lobby_area,asso_company,Gen_Interior,No_workstations,owner_cabin,landlord, " +
                       " Proppery_resi,Proppery_comm,Proppery_shop,Comments_Neighbour,Locality,NoOfEmp,NoOfComputer,NoOfTelephone,NoOfFloor,customerexiswhichfloor,Ownershipofresidence,Rationcardavailable,MetToapplicant,Differncesfound,Actiontaken,Occuption,Occupationdetails,NATUREOFDSCREPANCY,Standard_Remark, "+
            //Added by SANKET for Kunverji
            "OfficeType,OCL_distance,OfficeInternal " +
            //end for Kunverji                       
                       " from CPV_KYC_CASE_VERIFICATION where case_id='" + sCaseId + "' and Verification_type_id='" + sVerifyTypeID + "'";

        return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    }

    public DataSet GetTeleCallLogDetail(string sCaseID, string sVerificationTypeID)
    {
        string sSql = "";

        sSql = "SELECT ATTEMPT_DATE_TIME,REMARK,VERIFIER_ID,SubRemark from CPV_KYC_VERI_ATTEMPTS " +
              " where CASE_ID='" + sCaseID + "'" + "and VERIFICATION_TYPE_ID='" + sVerificationTypeID + "'";
        return OleDbHelper.ExecuteDataset(oCmn.ConnectionString, CommandType.Text, sSql);
    }

    public DataSet GetTeleCallLogDetail1(string sCaseID, string sVerificationTypeID)
    {
        string sSql = "";

        sSql = "select top 3 a.case_id,a.verification_type_id, c.fullname,a.date_time from CPV_KYC_FE_MAPPING a,employee_master c where " +
               " a.fe_id=c.emp_id and a.case_id='" + sCaseID + "' and a.verification_type_id='" + sVerificationTypeId + "' union all " +
               " select top 3 b.case_id,b.verification_type_id,c.fullname,b.date_time from cpv_kyc_fe_case_mapping_history b,employee_master c " +
               " where b.fe_id=c.emp_id and b.case_id='" + sCaseID + "' and b.verification_type_id='" + sVerificationTypeId + "' order by date_time asc";

        return OleDbHelper.ExecuteDataset(oCmn.ConnectionString, CommandType.Text, sSql);
    }

    public OleDbDataReader GetVerifierID(string sCaseId)
    {
        string sSql = "";
        sSql = " Select FEV.EMP_ID,FEV.FULLNAME from FE_VW as FEV "+ 
                "inner join CPV_KYC_FE_MAPPING as FEM "+
                "on FEV.EMP_ID=FEM.FE_ID   where FEM.CASE_ID='" + sCaseId + "' ";

        return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    }

    public DataTable GetCaseStatus()
    {
        string sSql = "";

        DataTable dt = new DataTable();
        sSql = "SELECT [CASE_STATUS_ID], [STATUS_NAME] FROM [CASE_STATUS_MASTER] WHERE ([PRODUCT_ID] =  '" + HttpContext.Current.Session["ProductId"] + "' ) ORDER BY STATUS_CODE";
        OleDbDataAdapter oledbDa = new OleDbDataAdapter(sSql, oCmn.ConnectionString);
        DataSet ds = new DataSet();
        oledbDa.Fill(ds, "Status");
        dt = ds.Tables["Status"];
        return dt;

    }

    public OleDbDataReader GetKYCCaseDetail(string sCaseId)
    {

        string sSql = "";


        //Res_pin_code, Off_pin_code added by SANKET for HDFC Ergo

        sSql = "Select REF_NO,(isnull(TITLE,'')+ ' ' + isnull(FIRST_NAME,'')+ ' ' + isnull(MIDDLE_NAME,'')+ ' ' + isnull(LAST_NAME,'')) as Applicant_Name," +
               "(isnull(RES_ADD_LINE_1,'')+ ' ' + isnull(RES_ADD_LINE_2,'')+ ' ' + isnull(RES_ADD_LINE_3,'')) as Address, " +
               "(ISNULL(OFF_ADD_LINE_1+' ','') + ISNULL(OFF_ADD_LINE_2+' ','') + ISNULL(OFF_ADD_LINE_3+' ','')+ ISNULL(OFF_CITY + ' ','')  + ISNULL(OFF_PIN_CODE +' ','')) as OffAddress," +
               "Res_pin_code,Off_pin_code,  CONVERT(CHAR(10), CASE_REC_DATETIME,103) + ' ' + " +
               " LTRIM(SUBSTRING(CONVERT( VARCHAR(210),CASE_REC_DATETIME, 22), 10, 5) + " +
               " RIGHT(CONVERT(VARCHAR(20), CASE_REC_DATETIME, 22), 3)) as CASE_REC_DATETIME, " +
               "CONVERT(CHAR(24), DOB,103) as DOB,Res_PHONE,MOBILE,Tele_Status,off_city,RES_LAND_MARK " +
               " from CPV_KYC_CASE_DETAILS where CASE_ID='" + sCaseId + "'";

        return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    }
    //added by kamal matekar...........
    public OleDbDataReader GetKYCCaseVerificationDetail(string sCaseId, string sVerifyTypeID)
    {

        string sSql = "";


        sSql = "Select Type_Org,Card_No,Buss_Proof_Seen,Locality_Type,EquipmentSeen_OR_Shift_Arrangement,Observation_If_NotRecommended,Address_Neighbour,Neigh_Shop, " +
              "TrigSVR,Buss_Quip_Sight,BranchName,BranchCode,RmName,RmCode,AccountNo,RmFormat,BllCase,BllSvr,NocName,TvTele,TvPerson,TvRelation,TvConAdd,TvCustId,DesBuild,BspName,IfNamePLate, " +
              "NameOfficer,SiteVerifier,AccOpen,RetDel,Sign1,Sign2,Sign3,Sign4,Sign5,Sign6,Building,DesgBO,Buss_stock_seen,Father_Name,Father_Occupation,Mother_Name,Confirmationaddress,Thiredpartyconfirmation,MetToapplicant,Rationcardavailable, " +
              "applicantstayheare,Ownership,Tradingexperiencel,Noofmembers,vehical,Occuption,IfSalnameoftheoragnization," +
              "IfBusinessnatureofbusiness,carpark,TypeofResidence,EquipInOffice,ResidenceInternal,Construction,typeofflooring," +
              "TypeOfRoofing,Standardofliving,Assets,Anydisplayofpoliticalpartyseen,Inpersonverificationwiththeapplicant,Products,Reasonsfornotrecommended,Matchinnegativelists,Legal_Name,Visit_No,reachable,Setup_location,boardtype,connectivity,properarea,establishmentcertificate,type_of_furnishing,Premises_Maintenance_Quality,childlabourmarchant,childlabourneighbours,childlabouremployees,Logistics,Inventory,InventorySize,REGISTERATIONPROOF,ADDITIONALDOCUMENTS,warehouseaddress,Top1Item,Top2Item,Top3Item,Top4Item,producttype,nameboard,No_emp,YEARS_WORKEDmarchant,YEARS_WORKEDnei,YEARS_WORKEDemp,ID_Proof,Address_proof,weektimeduaration_from,weektimeduaration_to,weektimeduaration_days,fireexepresent,telecaller_name,telecaller_Address,telecaller_location,visit_reason,Personmet_reason,Setup_details,Associate,Not_Associate,Calling_behalf,Any_other_info,Person_Met,visited, " +
            //Added by SANKET for Kunverji
              "TradingexperienceYears,AppicantBusiness,AddressProofSighted,TypeofAddressProof,NameofPerson ,ProductDealingIn,TurnOver1,doccumentryPrrof,Nameofindividual,Nameofindividualpersonmet,DoccumentryProofFurnished,Recommondation,landmark_verified " +
            //END for Kunverji
              " from CPV_KYC_CASE_VERIFICATION_Details where case_id='" + sCaseId + "' and Verification_type_id='" + sVerifyTypeID + "'";

        return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    }

    //ended by kamal

    public OleDbDataReader GetKYCCaseDetail1(string sCaseId)
    {

        string sSql = "";


        sSql = "Select REF_NO,(isnull(TITLE,'')+ ' ' + isnull(FIRST_NAME,'')+ ' ' + isnull(MIDDLE_NAME,'')+ ' ' + isnull(LAST_NAME,'')) as Applicant_Name," +
               "(isnull(off_ADD_LINE_1,'')+ ' ' + isnull(off_ADD_LINE_2,'')+ ' ' + isnull(off_ADD_LINE_3,'')) as Address, off_name," +
               " CONVERT(CHAR(10), CASE_REC_DATETIME,103) + ' ' + " +
               " LTRIM(SUBSTRING(CONVERT( VARCHAR(210),CASE_REC_DATETIME, 22), 10, 5) + " +
               " RIGHT(CONVERT(VARCHAR(20), CASE_REC_DATETIME, 22), 3)) as CASE_REC_DATETIME, " +
               "CONVERT(CHAR(24), DOB,103) as DOB,off_PHONE,MOBILE  " +
               " from CPV_KYC_CASE_DETAILS where CASE_ID='" + sCaseId + "'";

        return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    }
    #region IsVerificationComplete
    //Name             :   IsVerificationComplete
    //Create By		   :   Hemangi Kambli
    //Create Date	   :   09 Oct 2007
    //Remarks 		   :   This method is used to check whether verification of case is completed or not.

    public string IsVerificationComplete(OleDbTransaction oledbTrans, string sCaseId)
    {
        string sSql = "";
        OleDbDataReader oledbRead;
        string bComplete = "";
        sSql = " Select case (select count(*) from CPV_KYC_VERIFICATION_TYPE " +
              " where case_id='" + sCaseId + "') " +
              " when (select count(*) from (select distinct verification_type_id from " +
              " CPV_KYC_CASE_EXPORT_VW where case_id='" + sCaseId + "') AS A )" +
              " then 'true' else 'false' end as IsComplete";

        oledbRead = OleDbHelper.ExecuteReader(oledbTrans, CommandType.Text, sSql);
        if (oledbRead.Read() == true)
            bComplete = oledbRead["IsComplete"].ToString();

        return bComplete;
    }

    public string IsQCVerificationComplete(OleDbTransaction oledbTrans, string sCaseId)
    {
        string sSql = "";
        OleDbDataReader oledbRead;
        string bComplete = "";
        sSql = " Select case (select count(*) from CPV_KYC_VERIFICATION_TYPE " +
              " where case_id='" + sCaseId + "') " +
              " when (select count(*) from (select distinct verification_type_id from " +
              " CPV_KYC_CASE_EXPORT_VW where case_id='" + sCaseId + "') AS A )" +
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
        sSql = "Update CPV_KYC_CASE_DETAILS SET IS_CASE_COMPLETE='Y' WHERE CASE_ID='" + sCaseId + "'";
        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);
    }
    #endregion VerificationComplete

    #region QCVerificationComplete after completing verification IS_CASE_COMPLETE='Y'
    public void QCVerificationComplete(OleDbTransaction oledbTrans, string sCaseId)
    {
        string sSql = "";
        sSql = "Update CPV_QC_Case_Details SET IS_CASE_COMPLETE='Y' WHERE CASE_ID='" + sCaseId + "'";
        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);
    }
    #endregion VerificationComplete


}
