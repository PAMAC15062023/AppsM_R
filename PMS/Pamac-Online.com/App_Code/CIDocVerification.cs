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
using System.Data.SqlClient;

/// <summary>
/// Summary description for CIDocVerification
/// </summary>
public class CIDocVerification
{
    private CCommon oCmn;

    #region Property Declaration
    private string strCaseID;
    private string strCaseStatusId;
    private string strVerificationTypeId;
    private string strApplicantName;
    private string strCDMREFNo;
    private string strDOI;
    private string strNameofCompany;
    private decimal decTotalIncome;
    private string strOverWritingTempring;
    private string strPanCorrect;
    private string strTanCorrect;
    private string strOverallComputationCorrect;
    private string strIncomeCalculationCorrect;
    private string strTaxCalculationCorrect;
    private string strF16TaxPaybleISCorrect;
    private string strSendForVerification;
    private string strSpellMistake;
    private string strOtherVerification;
    private string strNameOfPersonContacted;
    private string strDesignationDepartment;
    private string strApplicantDesignation;
    private string strApplicationDepartment;
    private decimal decApplicantYearService;
    private decimal decApplicantGrossAnnualMonthlyIncome;
    private int iNumberOfEmployeeinOrg;
    private string strTypeOfOrg;
    private string strDocumentConf;
    private string strSealOfOrg;
    private string strSigOfIssAuth;
    private string strStanForOrg;
    private string strDtSSSPSC;
    private string strAmtSSSPSC;
    private string strAppOffCorrect;
    private string strBusinessActivitySeen;
    private string sNoEmployess;
    private string strStock;
    private string strNameBoard;
    private string strFERemarks;

    private string strDate1;
    private string strTime1;
    private string strRemarks1;
    private string strStatus;
    private string strFEName;
    private string strSupName;
    private string strVeriDate;
    private string strTeleremark;
    private string strVerifierID;
    private string strTellNO;
    private string strTellRemark;
    private string strAtemptDateTime;
    private string strSalary;
    private string strSupervisor_sign;
   
    public string CaseID
    {
        get { return strCaseID; }
        set { strCaseID = value; }
    }

    public string CaseStatusID
    {
        get { return strCaseStatusId; }
        set { strCaseStatusId = value; }
    }

    public string VerificationTypeId
    {
        get { return strVerificationTypeId; }
        set { strVerificationTypeId = value; }
    }

    public string ApplicantName
    {
        get { return strApplicantName; }
        set { strApplicantName = value; }
    }
    public string CDMREFNo
    {
        get { return strCDMREFNo; }
        set { strCDMREFNo = value; }
    }

    public string DOI
    {
        get { return strDOI; }
        set { strDOI = value; }
    }
    public string NameofCompany
    {
        get { return strNameofCompany; }
        set { strNameofCompany = value; }
    }
    public decimal TotalIncome
    {
        get { return decTotalIncome; }
        set { decTotalIncome = value; }
    }
    public string OverWritingTempring
    {
        get { return strOverWritingTempring; }
        set { strOverWritingTempring = value; }
    }
    public string PanCorrect
    {
        get { return strPanCorrect; }
        set { strPanCorrect = value; }
    }
    public string TanCorrect
    {
        get { return strTanCorrect; }
        set { strTanCorrect = value; }
    }
    public string IncomeCalculationCorrect
    {
        get { return strIncomeCalculationCorrect; }
        set { strIncomeCalculationCorrect = value; }
    }
    public string TaxCalculationCorrect
    {
        get { return strTaxCalculationCorrect; }
        set { strTaxCalculationCorrect = value; }
    }

    public string F16PaybleISCorrect
    {
        get { return strF16TaxPaybleISCorrect; }
        set { strF16TaxPaybleISCorrect = value; }
    }
    public string OkSendForVerification
    {
        get { return strSendForVerification; }
        set { strSendForVerification = value; }
    }
    public string SpellMistake
    {
        get { return strSpellMistake; }
        set { strSpellMistake = value; }
    }
    public string OtherVerification
    {
        get { return strOtherVerification; }
        set { strOtherVerification = value; }
    }
    public string NameOfPersonContacted
    {
        get { return strNameOfPersonContacted; }
        set { strNameOfPersonContacted = value; }
    }
    public string Cont_DesignationDepartment
    {
        get { return strDesignationDepartment; }
        set { strDesignationDepartment = value; }
     }
     
     public string strIspancardlogic;
     public string Ispancardlogic
     {
         get { return strIspancardlogic; }
         set { strIspancardlogic = value; }
     }

     public string strIsPancarddigit;
     public string IsPancarddigit
     {
         get { return strIsPancarddigit; }
         set { strIsPancarddigit = value; }
     }

     public string strIsPancardalphabet;
     public string IsPancardalphabet
     {
         get { return strIsPancardalphabet; }
         set { strIsPancardalphabet = value; }
     }

     public string strIsPancarddnumeric;
     public string IsPancarddnumeric
     {
         get { return strIsPancarddnumeric; }
         set { strIsPancarddnumeric = value; }
     }

     public string strIsPancardmatch;
     public string IsPancardmatch
     {
         get { return strIsPancardmatch; }
         set { strIsPancardmatch = value; }
     }

     public string strObservation;
     public string Observation
     {
         get { return strObservation; }
         set { strObservation = value; }
     }

     public string strVerifier;
     public string Verifier
     {
         get { return strVerifier; }
         set { strVerifier = value; }
     }

     public string strIspancardNoMatch;
     public string IspancardNoMatch
     {
         get { return strIspancardNoMatch; }
         set { strIspancardNoMatch = value; }
     }

     public string strIspancardholder;
     public string Ispancardholder
     {
         get { return strIspancardholder; }
         set { strIspancardholder = value; }
     }

     public string strIsfathermatch;
     public string Isfathermatch
     {
         get { return strIsfathermatch; }
         set { strIsfathermatch = value; }
     }

     public string strIsdateOfbirth;
     public string IsdateOfbirth
     {
         get { return strIsdateOfbirth; }
         set { strIsdateOfbirth = value; }
     }

     public string strsupervisorname;
     public string supervisorname
     {
         get { return strsupervisorname; }
         set { strsupervisorname = value; }
     }

     public string sCRef_No;
     public string CRef_No
     {
         get { return sCRef_No; }
         set { sCRef_No = value; }
     }
    
    public string ApplicantDesignation
    {
        get { return strApplicantDesignation; }
        set { strApplicantDesignation = value; }
    }
    public string ApplicationDepartment
    {
        get { return strApplicationDepartment; }
        set { strApplicationDepartment = value; }
    }
    public decimal ApplicantYearService
    {
        get { return decApplicantYearService; }
        set { decApplicantYearService = value; }
    }
    public decimal ApplicantGrossAnnualMonthlyIncome
    {
        get { return decApplicantGrossAnnualMonthlyIncome; }
        set { decApplicantGrossAnnualMonthlyIncome = value; }
    }
    public int NumberOfEmployeeinOrg
    {
        get { return iNumberOfEmployeeinOrg; }
        set { iNumberOfEmployeeinOrg = value; }
    }

    public string TypeOfOrg
    {
        get { return strTypeOfOrg; }
        set { strTypeOfOrg = value; }
    }
    public string DocumentConf
    {
        get { return strDocumentConf; }
        set { strDocumentConf = value; }
    }
    public string SealOfOrg
    {
        get { return strSealOfOrg; }
        set { strSealOfOrg = value; }
    }

    public string SigOfIssAuth
    {
        get { return strSigOfIssAuth; }
        set { strSigOfIssAuth = value; }
    }
    public string StanForOrg
    {
        get { return strStanForOrg; }
        set { strStanForOrg = value; }
    }
    public string DtSSSPSC
    {
        get { return strDtSSSPSC; }
        set { strDtSSSPSC = value; }
    }
    public string AmtSSSPSC
    {
        get { return strAmtSSSPSC; }
        set { strAmtSSSPSC = value; }
    }
    public string AppOffCorrect
    {
        get { return strAppOffCorrect; }
        set { strAppOffCorrect = value; }
    }
    public string BusinessActivitySeen
    {
        get { return strBusinessActivitySeen; }
        set { strBusinessActivitySeen = value; }
    }
    public string NoEmployess
    {
        get { return sNoEmployess; }
        set { sNoEmployess = value; }
    }
    public string Stock
    {
        get { return strStock; }
        set { strStock = value; }
    }

    public string NameBoard
    {
        get { return strNameBoard; }
        set { strNameBoard = value; }
    }
    public string FERemarks
    {
        get { return strFERemarks; }
        set { strFERemarks = value; }
    }
    public string Date1
    {
        get { return strDate1; }
        set { strDate1 = value; }
    }
    public string Time1
    {
        get { return strTime1; }
        set { strTime1 = value; }
    }
    public string Remarks1
    {
        get { return strRemarks1; }
        set { strRemarks1 = value; }
    }
    public string Status
    {
        get { return strStatus; }
        set { strStatus = value; }
    }
    public string FEName
    {
        get { return strFEName; }
        set { strFEName = value; }
    }
    public string SupName
    {
        get { return strSupName; }
        set { strSupName = value; }
    }
    public string VeriDate
    {
        get { return strVeriDate; }
        set { strVeriDate = value; }
    }
    
    public string OverallComputationCorrect
    {
        get { return strOverallComputationCorrect; }
        set { strOverallComputationCorrect = value; }
    }
    public string TeleRemarks
    {
        get { return strTeleremark; }
        set { strTeleremark = value; }
    }

    public string VerifierID
    {
        get { return strVerifierID ;}
        set { strVerifierID = value ;}
    }
    public string TellNo
    {
        get { return strTellNO; }
        set { strTellNO = value; }
    }
    public string TellPhoneRemark
    {
        get { return strTellRemark; }
        set { strTellRemark = value; }
    }
    public string AttempDateTime
    {
        get { return strAtemptDateTime; }
        set { strAtemptDateTime = value; }
    }
    public string strIsAcctCorrect;
    public string IsAcctCorrect
    {
        get { return strIsAcctCorrect; }
        set { strIsAcctCorrect = value; }
    }
    public string Salary
    {
        get { return strSalary; }
        set { strSalary = value; }
    }

    public string Supervisor_sign
    {
        get { return strSupervisor_sign; }
        set { strSupervisor_sign = value; }
    }
    public string strAreaID;
    public string AreaID
    {
        get { return strAreaID; }
        set { strAreaID = value; }
    }
    //added by hemangi kambli on 17/09/2007------
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


    
    //ADD By :Akanksha
    //Finacial(18/10/2014)
    //30/10/2014
    private string Caseid;
    private string CaseStatusid;
    private string strVerificationTypeid;
    private string strtxtAppName;
    private string strtxtCPARefNo;
    private DateTime strtxtInitiationDate;
    private string strtxtbankrefno;
    private string strtxtclientname;
    private string strtxtprodname;
    
    private Decimal strtxttotsale;
    private Decimal strtxttotcap;
    private Decimal strtxtfixass;
    private Decimal strtxtdebt;
    private Decimal strtxtcreditor;
    private Decimal strtxtclos;
    private Decimal strtxtdep;
    private Decimal strtxtnetprof;

    private string strtxtpanno;
    private string strtxtwhether;
  
    private string strddverification;
    private string strddstatus;
    private string strfinFERemarks;
    private string strVeriDate1;
    private string strSupervisor_sign1;
    public string strAreaID1;

    private string sAddedBy1;
    private string sModifiedBy1;
    private DateTime dtAdded1;
    private DateTime dtModify1;
    private string remark;
    private string assyear;


    public DateTime AddedOn1
    {
        get { return dtAdded1; }
        set { dtAdded1 = value; }
    }

    public string AddedBy1
    {
        get { return sAddedBy1; }
        set { sAddedBy1 = value; }
    }

    public DateTime ModifyOn1
    {
        get { return dtModify1; }
        set { dtModify1 = value; }
    }

    public string ModifyBy1
    {
        get { return sModifiedBy1; }
        set { sModifiedBy1 = value; }
    }
    
    public string CaseID1
    {
        get { return Caseid; }
        set { Caseid = value; }
    }

    public string CaseStatusID1
    {
        get { return CaseStatusid; }
        set { CaseStatusid = value; }
    }
    //-----
    public string VerificationTypeid
    {
        get { return strVerificationTypeid; }
        set { strVerificationTypeid = value; }
    }
    public string txtAppName
    {
        get { return strtxtAppName; }
        set { strtxtAppName = value; }
    }
    public string txtCPARefNo
    {
        get { return strtxtCPARefNo; }
        set { strtxtCPARefNo = value; }
    }
    public DateTime txtInitiationDate
    {
        get { return strtxtInitiationDate; }
        set { strtxtInitiationDate = value; }
    }
    public string txtbankrefno
    {
        get { return strtxtbankrefno; }
        set { strtxtbankrefno = value; }
    }

    
    public string txtclientname
    {
        get { return strtxtclientname; }
        set { strtxtclientname = value; }
    }

    public string txtprodname
    {
        get { return strtxtprodname; }
        set { strtxtprodname = value; }
    }
    public Decimal txttotsale
    {
        get { return strtxttotsale; }
        set { strtxttotsale = value; }
    }
    public Decimal txttotcap
       {
           get { return strtxttotcap; }
           set { strtxttotcap = value; }
       }
    //--

    public Decimal txtfixass
    {
        get { return strtxtfixass; }
        set { strtxtfixass = value; }
    }
    public Decimal txtdebt
    {
        get { return strtxtdebt; }
        set { strtxtdebt = value; }

    }
    public Decimal txtcreditor
    {
        get { return strtxtcreditor; }
        set { strtxtcreditor = value; }
    }
    public Decimal txtclos
    {
        get { return strtxtclos; }
        set { strtxtclos = value; }
    }

    public Decimal txtdep
    {
        get { return strtxtdep ; }
        set { strtxtdep = value; }
    }

    public Decimal txtnetprof
    {
        get { return strtxtnetprof; }
        set { strtxtnetprof = value; }
    }
    public string txtpanno
    {
        get { return strtxtpanno; }
        set { strtxtpanno = value; }
    }
    //--

    public string txtwhether
    {
        get { return strtxtwhether; }
        set { strtxtwhether = value; }
    }

  
    
    //--
    public string ddverification
    {
        get { return strddverification; }
        set { strddverification = value; }
    }

    public string ddstatus
    {
        get { return strddstatus; }
        set { strddstatus = value; }
    }

    public string finFERemarks
    {
        get { return strfinFERemarks; }
        set { strfinFERemarks = value; }
    }
    public string VeriDate1
    {
        get { return strVeriDate1; }
        set { strVeriDate1 = value; }
    }
    public string Supervisor_sign1
    {
        get { return strSupervisor_sign1; }
        set { strSupervisor_sign1 = value; }
    }
    public string AreaID1
    {
        get { return strAreaID1 ; }
        set {  strAreaID1 = value; }
    }
    public string Remark_new
    {
        get { return remark; }
        set { remark = value; }
    }

    public string txtassyear
    {
        get { return assyear; }
        set { assyear = value; }
    }
 
    //-----comp--//

    //---------------------------------------
    //added by hemangi kambli on 03/10/2007 ----
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
    private string strConfirmeddetalis;
    public string Confirmeddetalis
    {
        get { return strConfirmeddetalis; }
        set { strConfirmeddetalis = value; }
    }

    private string strAdderssmatch;
    public string Adderssmatch
    {
        get { return strAdderssmatch; }
        set { strAdderssmatch = value; }
    }
    private string strNumbermatch;
    public string Numbermatch
    {
        get { return strNumbermatch; }
        set { strNumbermatch = value; }
    }
    private string strBillmatch;
    public string Billmatch
    {
        get { return strBillmatch; }
        set { strBillmatch = value; }
    }

    private string strbackofficeremark;
    public string backofficeremark
    {
        get { return strbackofficeremark; }
        set { strbackofficeremark = value; }
    }
    private string strDateofissues;
    public string Dateofissues
    {
        get { return strDateofissues; }
        set { strDateofissues = value; }
    }
    private string strNameofseviceprovider;
    public string Nameofseviceprovider
    {
        get { return strNameofseviceprovider; }
        set { strNameofseviceprovider = value; }
    }
    private string strCPARef_No;
    public string CPARef_No
    {
        get { return strCPARef_No; }
        set { strCPARef_No = value; }
    }
    private string strVerificationNumber;
    public string VerificationNumber
    {
        get { return strVerificationNumber; }
        set { strVerificationNumber = value; }
    }
    ////------------------------------------------------
  //------------add by manswini------
    private string strcity_limy;
    public string city_limy
    {
        get { return strcity_limy; }
        set { strcity_limy = value; }
    }
//------------Comp--------

    #endregion Property Declaration

    public CIDocVerification()
	{
        oCmn = new CCommon();
		
	}

    //comment by: kanchan on 23/9/2014
   
    ////#region GetVerificationDetail()  

    ////public OleDbDataReader GetVerificationDetail(string sCaseId, string sVerifyType, string sClientId, string sCentreId)
    ////{
    ////    string sSql = "";
    ////    sSql = "select CD.Case_Id,CIDOC.Verification_type_id from  CPV_IDOC_CASE_DETAILS CD " +
    ////           " INNER JOIN CPV_IDOC_VERIFICATION_TYPE CIDOC ON CD.Case_ID=CIDOC.Case_ID " +
    ////           " WHERE CIDOC.case_id='" + sCaseId + "' " +
    ////           " And CIDOC.verification_type_id='" + sVerifyType + "'" +
    ////           " AND CD.Client_ID='" + sClientId + "'" +
    ////           " AND CD.Centre_Id='" + sCentreId + "'" +
    ////           " AND CD.SEND_DATETIME IS NULL ";

    ////    return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    ////}
    ////#endregion GetVerificationDetail()



    //Add by:Kanchan
    //Add date:23/9/2014
     #region GetVerificationDetail()

    public DataSet GetVerificationDetail(string sCaseId, string sVerifyType, string sClientId, string sCentreId)
    {
        SqlConnection con = new SqlConnection(oCmn.AppConnectionString);

        SqlCommand command = new SqlCommand("sp_VerificationView_GetVerificationDetail", con);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@case_id", sCaseId);
        command.Parameters.AddWithValue("@verification_type_id", sVerifyType);
        command.Parameters.AddWithValue("@Client_ID", sClientId);
        command.Parameters.AddWithValue("@Centre_Id", sCentreId);

        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = command;

        DataSet MyDs = new DataSet();
        sda.Fill(MyDs);
        con.Close();

        return MyDs;
    }
    #endregion GetVerificationDetail()

    //----comp---//

    //comment by kanchan on 2013


    ////# region GetIDOCsCaseDetail()  

    ////public OleDbDataReader GetIDOCsCaseDetail(string sCaseId)
    ////{
    ////    string sSql = "";
    ////    sSql = "select ISNULL(TITLE,'')+' ' +ISNULL(FIRST_NAME,'')+' ' +ISNULL(MIDDLE_NAME,'')+ ' ' +ISNULL(LAST_NAME,'') AS [FULL NAME], " +
    ////         " REF_NO,CASE_REC_DATETIME AS RECD_DATE,BANK_NAME,BANK_ADDRESS,BANK_PIN,BANK_CITY,Bank_AccountNo FROM CPV_IDOC_CASE_DETAILS " +
    ////         " WHERE CASE_ID='" + sCaseId + "'";
    ////    return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    ////}

    ////#endregion GetIDOCsCaseDetail()


    //add by:kanchan
    //add date:23/9/2014
    # region GetIDOCsCaseDetail()

    public DataSet GetIDOCsCaseDetail(string sCaseId)
    {

        SqlConnection con = new SqlConnection(oCmn.AppConnectionString);

        SqlCommand command = new SqlCommand("sp_IDOC_F16_GetIDOCsCaseDetail", con);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@CASE_ID", sCaseId);

        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = command;

        DataSet MyDs = new DataSet();
        sda.Fill(MyDs);

        con.Close();
        return MyDs;

    }

    #endregion GetIDOCsCaseDetail()

    //---------comp-----//

    //comment by kanchan on 23/9/2014
    ////#region GetFEAreaName()
    ////public OleDbDataReader GetFEAreaName(string sCaseId, string sVerifyType)
    ////{

    ////    string sSql = "";
    ////    sSql = "select PincodeArea_Name,PincodeArea_ID from  CPV_IDOC_VERIFICATION BVBT inner join FE_Area_Master FAM   " +
    ////           "on FAM.PincodeArea_ID=BVBT.AreaID where case_id='" + sCaseId + "' " +
    ////           "and Verification_Type_id='" + sVerifyType + "'";

    ////    return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    ////}
    ////#endregion GetFEAreaName()


    //add by:kanchan
    //add date:23/9/2014

    #region GetFEAreaName()

    public DataSet GetFEAreaName(string sCaseId, string sVerifyType)
    {

        SqlConnection con = new SqlConnection(oCmn.AppConnectionString);

        SqlCommand command = new SqlCommand("sp_IDOC_F16_GetFEAreaName", con);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@case_id", sCaseId);

        command.Parameters.AddWithValue("@Verification_Type_id", sVerifyType);

        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = command;

        DataSet MyDs = new DataSet();
        sda.Fill(MyDs);

        con.Close();

        return MyDs;

    }
    #endregion GetFEAreaName()
    //------comp-----//


    //comment by kanchan on 1/10/2014

    //////# region GetFEName()
    ////////Name              :   GetFEName
    ////////Create By			:	Hemangi Kambli
    ////////Create Date		:	1st June,2007
    
    //////public OleDbDataReader GetFEName(string sCaseId, string sVeriTypeId)
    //////{
    //////    string sSql = "";
    //////    sSql = "select distinct fullname,date_time, emp_id from fe_vw fv inner join CPV_IDOC_FE_CASE_MAPPING cifcm on(cifcm.fe_id=fv.emp_id)  where case_id='" + sCaseId + "' and Verification_Type_id='" + sVeriTypeId + "' order by fv.fullname";
    //////    return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    //////}

    //////#endregion GetFEName()



    # region GetFEName()
    //Name              :   GetFEName
    //Create By			:	Akanksha
    //Create Date		:	1/10/2014
    //sp_name           :  sp_IDOC_Paasport_GetFEName
    //method place     :  password,pancard

    public DataSet GetFEName(string sCaseId, string sVeriTypeId)
    {
        SqlConnection con = new SqlConnection(oCmn.AppConnectionString);

        SqlCommand command = new SqlCommand("sp_IDOC_Paasport_GetFEName", con);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@Case_ID", sCaseId);
        command.Parameters.AddWithValue("@VERIFICATION_TYPE_ID", sVeriTypeId);

        con.Open();
        SqlDataAdapter sd1 = new SqlDataAdapter();
        sd1.SelectCommand = command;

        DataSet DataSet = new DataSet();
        sd1.Fill(DataSet);

        con.Close();

        return DataSet;
    }


    #endregion GetFEName()


    //------------------comp-------------//

    //comment by:kanchan on 1/10/2014

    ////#region GetIDOCsCaseVerificationDetail()
    ////public OleDbDataReader GetIDOCsCaseVerificationDetail(string sCaseId,string sVerifyTypeId)
    ////{
    ////    string sSql = "";
    ////    sSql = "SELECT Person_contacted,Cont_Designation_dept,ACCOUNT_CORRECT,DOCUMENT_AS_PER_STANDARD, "+
    ////           " AMOUNT_ON_DOC,FE_REMARK,FE_VISIT_DATE,CASE_STATUS_ID,Supervisor_sign FROM CPV_IDOC_VERIFICATION " +
    ////           " WHERE CASE_ID='" + sCaseId + "' AND VERIFICATION_TYPE_ID='" + sVerifyTypeId + "'";
                     
    ////    return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    ////}
    ////#endregion GetIDOCsCaseVerificationDetail()




    //add by:Akanksha
    //add date:1/10/2014

    #region GetIDOCsCaseVerificationDetail()

    public DataSet GetIDOCsCaseVerificationDetail(string sCaseId, string sVerifyTypeId)
    {
        SqlConnection con = new SqlConnection(oCmn.AppConnectionString);

        SqlCommand command = new SqlCommand("sp_IDOC_BankStatementVerification_GetIDOCsCaseVerificationDetail_28Nov", con);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@Case_ID", sCaseId);
        command.Parameters.AddWithValue("@VERIFICATION_TYPE_ID", sVerifyTypeId);

        con.Open();
        SqlDataAdapter sd1 = new SqlDataAdapter();
        sd1.SelectCommand = command;

        DataSet Dset = new DataSet();
        sd1.Fill(Dset);

        con.Close();

        return Dset;



    }

    #endregion GetIDOCsCaseVerificationDetail()

    //-------------comp--------------------------------------------//

////------------------------------------------------------------------------------------------------------------

   // #region GetIDOCPancardVerificationDetail()
    //comment by kanchan on 24/9/2014
    ////public OleDbDataReader GetIDOCPancardVerificationDetail(string sCaseId, string sVerifyTypeId)
    ////{
    ////    string sSql = "";
    ////    sSql = "SELECT Ispancardlogic,IsPancarddigit,IsPancardalphabet,IsPancarddnumeric,IsPancardmatch,Observation,Verifier," +
    ////           "IspancardNoMatch,Ispancardholder,Isfathermatch,IsdateOfbirth,supervisorname,FE_REMARK,FE_VISIT_DATE,CASE_STATUS_ID,Ref_No FROM CPV_IDOC_VERIFICATION " +
    ////           " WHERE CASE_ID='" + sCaseId + "' AND VERIFICATION_TYPE_ID='" + sVerifyTypeId + "'";

    ////    return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    ////}


    //add by akanksha
    //add date:24/9/2014
    #region GetIDOCPancardVerificationDetail()
    public DataSet GetIDOCPancardVerificationDetail(string sCaseId, string sVerifyTypeId)
    {
        SqlConnection con = new SqlConnection(oCmn.AppConnectionString);
        
            SqlCommand command = new SqlCommand("sp_GetIDOCPancardVerificationDetail", con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Case_ID", sCaseId);
            command.Parameters.AddWithValue("@VERIFICATION_TYPE_ID", sVerifyTypeId);

            con.Open();
            SqlDataAdapter sd1 = new SqlDataAdapter();
            sd1.SelectCommand = command;

            DataSet DataSet = new DataSet();
            sd1.Fill(DataSet);

            con.Close();

            return DataSet;

        

    }  


    #endregion GetIDOCPancardVerificationDetail()
    //------------comp-------//


//--------------------------------------------------------------------------------------------------------------------//

    //comment by kanchan on 1/10/2014
    ////# region Get_IDOC_FORMATS()
    
    ////public OleDbDataReader Get_IDOC_FORMATS(string sCaseId, string sVerifyTypeId)
    ////{
    ////    string sSql = "";
    ////    sSql = "SELECT Ref_no,Nameofseviceprovider,Dateofissues,backofficeremark,Person_contacted,Cont_Designation_dept,Billmatch,Numbermatch, " +
    ////           "Adderssmatch,FE_REMARK,Confirmeddetalis,FE_VISIT_DATE,VerificationNumber,Supervisor_Sign FROM CPV_IDOC_VERIFICATION " +
    ////           " WHERE CASE_ID='" + sCaseId + "' AND VERIFICATION_TYPE_ID='" + sVerifyTypeId + "'";

    ////    return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    ////}

    ////  #endregion GetIDOCsCaseDetail()



    # region Get_IDOC_FORMATS()
    //Name              :   Get_IDOC_FORMATS()
    //Create By			:	Akanksha
    //Create Date		:	1/10/2014
    //Remarks 		    :	This return records of particular caseId.
    //sp_name           :   sp_IDOC_Paasport_Get_IDOC_FORMATS
    //method place     :   password

    public DataSet Get_IDOC_FORMATS(string sCaseId, string sVeriTypeId)
    {
        SqlConnection con = new SqlConnection(oCmn.AppConnectionString);

        SqlCommand command = new SqlCommand("sp_IDOC_Paasport_Get_IDOC_FORMATS", con);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@Case_ID", sCaseId);
        command.Parameters.AddWithValue("@VERIFICATION_TYPE_ID", sVeriTypeId);

        con.Open();
        SqlDataAdapter sd1 = new SqlDataAdapter();
        sd1.SelectCommand = command;

        DataSet DataSet = new DataSet();
        sd1.Fill(DataSet);

        con.Close();

        return DataSet;

    }

    #endregion GetIDOCsCaseDetail()


    //--------------comp---------//






//------------------------------------------------------------------------------------------------------------

    //comment by kanchan on 23/9/2014

    ////#region InsertIDocForm16()
    ////public string InsertIDocForm16()
    ////{
    ////    string sSql = "";
    ////    string sSql1 = "";
    ////    string sRetVal = "";
    ////    OleDbConnection sqlconn = new OleDbConnection(oCmn.ConnectionString);
    ////    sqlconn.Open();

    ////    OleDbTransaction sqlTrans = sqlconn.BeginTransaction();
    ////    try
    ////    {
    ////        sSql = "insert into cpv_idoc_verification(case_id,TOTAL_INCOME,Overwriting,Pan_correct,Tan_correcT,computation_correct,Calculation_correct,Tax_cal_correct,Tax_payble_correct,OK_field_verification,IS_spelling_mistake,Other_observation,Person_contacted,Cont_Designation_dept,APP_DESIGNATION,APP_DEPARTMENT,APP_YEAR_IN_SERVICE,MONTH_INCOME,NO_of_Employee,TYPE_OF_INDUSTRY,ORGANIZATION_SEAL,AUTHORITY_SIGNATURE,DOCUMENT_AS_PER_STANDARD,DATE_ON_DOC,AMOUNT_ON_DOC,APP_ADDRESS_CORRECT,BUSSINESS_ACTIVITY_SEEN,STOCK_SIGHTED,NO_OF_EMP_SEEN,NAME_BOARD_SEEN,FE_REMARK,TELE_REMARK,VERIFICATION_TYPE_ID,FE_VISIT_DATE,CASE_STATUS_ID,Gross_salary_Momthly_Annual_Income,ADD_BY,ADD_DATE,Supervisor_sign,AreaID) values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ";
            
    ////        OleDbParameter[] ParamVerification = new OleDbParameter[40];

    ////        ParamVerification[0] = new OleDbParameter("@CaseId", OleDbType.VarChar, 15);
    ////        ParamVerification[0].Value = CaseID;
    ////        ParamVerification[1] = new OleDbParameter("@TOTAL_INCOME", OleDbType.Decimal, 9);
    ////        ParamVerification[1].Value = TotalIncome;
    ////        ParamVerification[2] = new OleDbParameter("@Overwriting", OleDbType.VarChar, 10);
    ////        ParamVerification[2].Value = OverWritingTempring;
    ////        ParamVerification[3] = new OleDbParameter("@Pan_correct", OleDbType.VarChar, 10);
    ////        ParamVerification[3].Value = PanCorrect;
    ////        ParamVerification[4] = new OleDbParameter("@Tan_correct", OleDbType.VarChar, 10);
    ////        ParamVerification[4].Value = TanCorrect;
    ////        ParamVerification[5] = new OleDbParameter("@computation_correct", OleDbType.VarChar, 10);
    ////        ParamVerification[5].Value = OverallComputationCorrect;
    ////        ParamVerification[6] = new OleDbParameter("@Calculation_correct", OleDbType.VarChar, 10);
    ////        ParamVerification[6].Value = IncomeCalculationCorrect;
    ////        ParamVerification[7] = new OleDbParameter("@Tax_cal_correct", OleDbType.VarChar, 10);
    ////        ParamVerification[7].Value = TaxCalculationCorrect;
    ////        ParamVerification[8] = new OleDbParameter("@Tax_payble_correct", OleDbType.VarChar, 10);
    ////        ParamVerification[8].Value = F16PaybleISCorrect;
    ////        ParamVerification[9] = new OleDbParameter("@OK_field_verification", OleDbType.VarChar, 10);
    ////        ParamVerification[9].Value = OkSendForVerification;
    ////        ParamVerification[10] = new OleDbParameter("@IS_spelling_mistake", OleDbType.VarChar, 10);
    ////        ParamVerification[10].Value = SpellMistake;
    ////        ParamVerification[11] = new OleDbParameter("@Other_observation", OleDbType.VarChar, 255);
    ////        ParamVerification[11].Value = OtherVerification;
    ////        ParamVerification[12] = new OleDbParameter("@Person_contacted", OleDbType.VarChar, 100);
    ////        ParamVerification[12].Value = NameOfPersonContacted;
    ////        ParamVerification[13] = new OleDbParameter("@Cont_Designation_dept", OleDbType.VarChar, 100);
    ////        ParamVerification[13].Value = Cont_DesignationDepartment;
    ////        ParamVerification[14] = new OleDbParameter("@APP_DESIGNATION", OleDbType.VarChar, 100);
    ////        ParamVerification[14].Value = ApplicantDesignation;
    ////        ParamVerification[15] = new OleDbParameter("@APP_DEPARTMENT", OleDbType.VarChar, 100);
    ////        ParamVerification[15].Value = ApplicationDepartment;
    ////        ParamVerification[16] = new OleDbParameter("@APP_YEAR_IN_SERVICE", OleDbType.Decimal, 9);
    ////        ParamVerification[16].Value = ApplicantYearService;
    ////        ParamVerification[17] = new OleDbParameter("@MONTH_INCOME", OleDbType.Decimal, 9);
    ////        ParamVerification[17].Value = ApplicantGrossAnnualMonthlyIncome;
    ////        ParamVerification[18] = new OleDbParameter("@NO_of_Employee", OleDbType.Numeric, 9);
    ////        ParamVerification[18].Value = NumberOfEmployeeinOrg;
    ////        ParamVerification[19] = new OleDbParameter("@TYPE_OF_INDUSTRY", OleDbType.VarChar, 100);
    ////        ParamVerification[19].Value = TypeOfOrg;
    ////        ParamVerification[20] = new OleDbParameter("@ORGANIZATION_SEAL", OleDbType.VarChar, 15);
    ////        ParamVerification[20].Value = SealOfOrg;
    ////        ParamVerification[21] = new OleDbParameter("@AUTHORITY_SIGNATURE", OleDbType.VarChar, 15);
    ////        ParamVerification[21].Value = SigOfIssAuth;
    ////        ParamVerification[22] = new OleDbParameter("@DOCUMENT_AS_PER_STANDARD", OleDbType.VarChar, 15);
    ////        ParamVerification[22].Value = StanForOrg;
    ////        ParamVerification[23] = new OleDbParameter("@DATE_ON_DOC", OleDbType.VarChar, 15);
    ////        ParamVerification[23].Value = DtSSSPSC;
    ////        ParamVerification[24] = new OleDbParameter("@AMOUNT_ON_DOC", OleDbType.VarChar, 15);
    ////        ParamVerification[24].Value = AmtSSSPSC;
    ////        ParamVerification[25] = new OleDbParameter("@APP_ADDRESS_CORRECT", OleDbType.VarChar, 15);
    ////        ParamVerification[25].Value = AppOffCorrect;
    ////        ParamVerification[26] = new OleDbParameter("@BUSSINESS_ACTIVITY_SEEN", OleDbType.VarChar, 10);
    ////        ParamVerification[26].Value = BusinessActivitySeen;
    ////        ParamVerification[27] = new OleDbParameter("@STOCK_SIGHTED", OleDbType.VarChar, 255);
    ////        ParamVerification[27].Value = Stock;
    ////        ParamVerification[28] = new OleDbParameter("@NO_OF_EMP_SEEN", OleDbType.VarChar, 10);
    ////        ParamVerification[28].Value = NoEmployess;
    ////        ParamVerification[29] = new OleDbParameter("@NAME_BOARD_SEEN", OleDbType.VarChar, 10);
    ////        ParamVerification[29].Value = NameBoard;
    ////        ParamVerification[30] = new OleDbParameter("@FE_REMARK", OleDbType.VarChar, 2000);
    ////        ParamVerification[30].Value = FERemarks;
    ////        ParamVerification[31] = new OleDbParameter("@TELE_REMARK", OleDbType.VarChar, 2000);
    ////        ParamVerification[31].Value = TeleRemarks;
    ////        ParamVerification[32] = new OleDbParameter("@verification_type_id", OleDbType.VarChar, 255);
    ////        ParamVerification[32].Value = VerificationTypeId;
    ////        ParamVerification[33] = new OleDbParameter("@FE_VISIT_DATE", OleDbType.VarChar, 11);
    ////        ParamVerification[33].Value = VeriDate;
    ////        ParamVerification[34] = new OleDbParameter("@CASE_STATUS_ID", OleDbType.VarChar, 15);
    ////        ParamVerification[34].Value = CaseStatusID;
    ////        ParamVerification[35] = new OleDbParameter("@GrosssSalary", OleDbType.VarChar, 50);
    ////        ParamVerification[35].Value = Salary;
    ////        ParamVerification[36] = new OleDbParameter("@AddedBy", OleDbType.VarChar, 15);
    ////        ParamVerification[36].Value = AddedBy;
    ////        ParamVerification[37] = new OleDbParameter("@AddedOn", OleDbType.DBTimeStamp);
    ////        ParamVerification[37].Value = AddedOn;
    ////        ParamVerification[38] = new OleDbParameter("@Supervisor_sign", OleDbType.VarChar, 255);
    ////        ParamVerification[38].Value = Supervisor_sign;
    ////        ParamVerification[39] = new OleDbParameter("@AreaID", OleDbType.VarChar, 255);
    ////        ParamVerification[39].Value = AreaID;

    ////        OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql, ParamVerification);

    ////        //Start Insert into CASE_TRANSACTION_LOG -------------------
    ////        sSql = "";
    ////        sSql = "Insert into CASE_TRANSACTION_LOG(CASE_ID,VERIFICATION_TYPE_ID,USER_ID,TRANS_START,TRANS_END," +
    ////             "CENTRE_ID,PRODUCT_ID,CLIENT_ID) VALUES(?,?,?,?,?,?,?,?)";

    ////        OleDbParameter[] paramTransLog = new OleDbParameter[8];
    ////        paramTransLog[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
    ////        paramTransLog[0].Value = CaseID;
    ////        paramTransLog[1] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar, 15);
    ////        paramTransLog[1].Value = VerificationTypeId;
    ////        paramTransLog[2] = new OleDbParameter("@UserId", OleDbType.VarChar, 15);
    ////        paramTransLog[2].Value = UserId;
    ////        paramTransLog[3] = new OleDbParameter("@TransStart", OleDbType.DBTimeStamp);
    ////        paramTransLog[3].Value = TransStart;
    ////        paramTransLog[4] = new OleDbParameter("@TransEnd", OleDbType.DBTimeStamp);
    ////        paramTransLog[4].Value = TransEnd;
    ////        paramTransLog[5] = new OleDbParameter("@CentreId", OleDbType.VarChar, 15);
    ////        paramTransLog[5].Value = CentreId;
    ////        paramTransLog[6] = new OleDbParameter("@ProductId", OleDbType.VarChar, 15);
    ////        paramTransLog[6].Value = ProductId;
    ////        paramTransLog[7] = new OleDbParameter("@ClientId", OleDbType.VarChar, 15);
    ////        paramTransLog[7].Value = ClientId;

    ////        OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql, paramTransLog);

    ////        if (IsVerificationComplete(sqlTrans, CaseID) == "true")
    ////        {
    ////            VerificationComplete(sqlTrans, CaseID);
    ////            sRetVal += " Case verification data entry completed.";
    ////        }
    ////        /////
    ////        //End  Insert into CASE_TRANSACTION_LOG --------------------
    ////        sqlTrans.Commit();
    ////        sqlconn.Close();
    ////    }
    ////    catch (Exception ex)
    ////    {
    ////        sqlTrans.Rollback();
    ////        sqlconn.Close();
    ////        throw new Exception("An error occurred while executing the insert string", ex);
 
    ////    }
    ////    return sRetVal;
    ////}
    ////#endregion InsertIDocForm16()

    //comment by kanchan on 23/9/2014

    ////#region InsertTelelog()
    ////public void InsertTeleLog()
    ////{
    ////    string sSql1 = "";
    ////    OleDbConnection sqlconn = new OleDbConnection(oCmn.ConnectionString);
    ////    sqlconn.Open();
    ////    string sSql = "";
    ////    //sSql = "select verifier_id from CPV_IDOC_VERI_ATTEMPTS where case_id=" + CaseID;
    ////    //string sVerifierID = OleDbHelper.ExecuteScalar(sqlconn, CommandType.Text, sSql).ToString();
    ////    OleDbTransaction sqlTrans = sqlconn.BeginTransaction();
    ////    try
    ////    {
    ////        sSql1 = "insert into CPV_IDOC_VERI_ATTEMPTS (Case_id,ATTEMPT_DATE_TIME,TELEPHONE_NO,REMARK,VERIFICATION_TYPE_ID)Values(?,?,?,?,?)";
    ////        OleDbParameter[] ParamAttempt = new OleDbParameter[5];
    ////        ParamAttempt[0] = new OleDbParameter("@CaseId", OleDbType.VarChar, 15);
    ////        ParamAttempt[0].Value = CaseID;
           
    ////        ParamAttempt[1] = new OleDbParameter("@ATTEMPT_DATE_TIME", OleDbType.VarChar);
    ////        ParamAttempt[1].Value = AttempDateTime;
    ////        ParamAttempt[2] = new OleDbParameter("@TELEPHONE_NO", OleDbType.VarChar, 50);
    ////        ParamAttempt[2].Value = TellNo;
    ////        ParamAttempt[3] = new OleDbParameter("@REMARK", OleDbType.VarChar, 255);
    ////        ParamAttempt[3].Value = TellPhoneRemark;

    ////        ParamAttempt[4] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 255);
    ////        ParamAttempt[4].Value = VerificationTypeId;
    ////        OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql1, ParamAttempt);
    ////        sqlTrans.Commit();
    ////        sqlconn.Close();
    ////    }
    ////    catch (Exception ex)
    ////    {
    ////        sqlTrans.Rollback();
    ////        sqlconn.Close();
    ////        throw new Exception("An error occurred while executing the insert string", ex);

    ////    }

    ////}
    ////#endregion InsertTelelog()


    //add by kanchan on 23/9/2014
    #region InsertIDocForm16()
    public string InsertIDocForm16()//diss done
    {
        string sRetVal = "";

        try
        {

            //--------------------------------------------10/9/2014----------------------------------------------------


            using (SqlConnection con = new SqlConnection(oCmn.AppConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_IDOC_F16_InsertIDocForm16", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@case_id", CaseID);
                command.Parameters.AddWithValue("@TOTAL_INCOME", TotalIncome);
                command.Parameters.AddWithValue("@Overwriting", OverWritingTempring);
                command.Parameters.AddWithValue("@Pan_correct", PanCorrect);
                command.Parameters.AddWithValue("@Tan_correcT", TanCorrect);

                command.Parameters.AddWithValue("@computation_correct", OverallComputationCorrect);
                command.Parameters.AddWithValue("@Calculation_correct", IncomeCalculationCorrect);
                command.Parameters.AddWithValue("@Tax_cal_correct", TaxCalculationCorrect);
                command.Parameters.AddWithValue("@Tax_payble_correct", F16PaybleISCorrect);
                command.Parameters.AddWithValue("@OK_field_verification", OkSendForVerification);

                command.Parameters.AddWithValue("@IS_spelling_mistake", SpellMistake);
                command.Parameters.AddWithValue("@Other_observation", OtherVerification);
                command.Parameters.AddWithValue("@Person_contacted", NameOfPersonContacted);
                command.Parameters.AddWithValue("@Cont_Designation_dept", Cont_DesignationDepartment);
                command.Parameters.AddWithValue("@APP_DESIGNATION", ApplicantDesignation);

                command.Parameters.AddWithValue("@APP_DEPARTMENT", ApplicationDepartment);
                command.Parameters.AddWithValue("@APP_YEAR_IN_SERVICE", ApplicantYearService);
                command.Parameters.AddWithValue("@MONTH_INCOME", ApplicantGrossAnnualMonthlyIncome);
                command.Parameters.AddWithValue("@NO_of_Employee", NumberOfEmployeeinOrg);
                command.Parameters.AddWithValue("@TYPE_OF_INDUSTRY", TypeOfOrg);

                command.Parameters.AddWithValue("@ORGANIZATION_SEAL", SealOfOrg);
                command.Parameters.AddWithValue("@AUTHORITY_SIGNATURE", SigOfIssAuth);
                command.Parameters.AddWithValue("@DOCUMENT_AS_PER_STANDARD", StanForOrg);
                command.Parameters.AddWithValue("@DATE_ON_DOC", DtSSSPSC);
                command.Parameters.AddWithValue("@AMOUNT_ON_DOC", AmtSSSPSC);

                command.Parameters.AddWithValue("@APP_ADDRESS_CORRECT", AppOffCorrect);
                command.Parameters.AddWithValue("@BUSSINESS_ACTIVITY_SEEN", BusinessActivitySeen);
                command.Parameters.AddWithValue("@STOCK_SIGHTED", Stock);
                command.Parameters.AddWithValue("@NO_OF_EMP_SEEN", NoEmployess);
                command.Parameters.AddWithValue("@NAME_BOARD_SEEN", NameBoard);

                command.Parameters.AddWithValue("@FE_REMARK", FERemarks);
                command.Parameters.AddWithValue("@TELE_REMARK", TeleRemarks);
                command.Parameters.AddWithValue("@VERIFICATION_TYPE_ID", VerificationTypeId);
                command.Parameters.AddWithValue("@FE_VISIT_DATE", VeriDate);
                command.Parameters.AddWithValue("@CASE_STATUS_ID", CaseStatusID);

                command.Parameters.AddWithValue("@Gross_salary_Momthly_Annual_Income", Salary);
                command.Parameters.AddWithValue("@ADD_BY", AddedBy);
                command.Parameters.AddWithValue("@ADD_DATE", AddedOn);
                command.Parameters.AddWithValue("@Supervisor_sign", Supervisor_sign);
                command.Parameters.AddWithValue("@AreaID", AreaID);
               


                con.Open();
                int i = command.ExecuteNonQuery();
                con.Close();
            }

            //Start Insert into CASE_TRANSACTION_LOG -------------------           


            using (SqlConnection con = new SqlConnection(oCmn.AppConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_IDOC_F16_InsertIDocForm16_insert2", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@CASE_ID", CaseID);
                command.Parameters.AddWithValue("@VERIFICATION_TYPE_ID", VerificationTypeId);
                command.Parameters.AddWithValue("@USER_ID", UserId);
                command.Parameters.AddWithValue("@TRANS_START", TransStart);
                command.Parameters.AddWithValue("@TRANS_END", TransEnd);
                command.Parameters.AddWithValue("@CENTRE_ID", CentreId);
                command.Parameters.AddWithValue("@PRODUCT_ID", ProductId);
                command.Parameters.AddWithValue("@CLIENT_ID", ClientId);

                con.Open();
                int i = command.ExecuteNonQuery();
                con.Close();
            }
            
            if (IsVerificationComplete(CaseID) == "true")
            {

                VerificationComplete(CaseID);
                sRetVal += " Case verification data entry completed.";
            }
        }
        catch
        {

        }
        return sRetVal;
    }
    #endregion InsertIDocForm16()

    //-----comp-----//




    //add by:kanchan
    //add date:23/9/2014

    #region InsertTelelog()
    public void InsertTeleLog()
    {

        try
        {


            using (SqlConnection con = new SqlConnection(oCmn.AppConnectionString))
            {
            
                SqlCommand command = new SqlCommand("sp_IDOC_F16_InsertTeleLog", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Case_id", CaseID);
                command.Parameters.AddWithValue("@ATTEMPT_DATE_TIME", AttempDateTime);
                command.Parameters.AddWithValue("@TELEPHONE_NO", TellNo);
                command.Parameters.AddWithValue("@REMARK", TellPhoneRemark);
                command.Parameters.AddWithValue("@VERIFICATION_TYPE_ID", VerificationTypeId);

                con.Open();
                int i = command.ExecuteNonQuery();
                con.Close();
            }


        }
        catch (Exception ex)
        {

            throw new Exception("An error occurred while executing the insert string", ex);

        }

    }
    #endregion InsertTelelog()
    //-----comp----//


    //comment by kanchan on 29/9/2014

    ////#region InsertUpdateBankStatement()
    ////public string InsertUpdateBankStatement()
    ////{
    ////    OleDbConnection oledbConn = new OleDbConnection(oCmn.ConnectionString);
    ////    oledbConn.Open();
    ////    OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
    ////    string sRetVal = "";
    ////    try
    ////    {
    ////        string sSql = "";
    ////        string sSqlRead = "";
    ////        OleDbDataReader oledbRead;
    ////        sSqlRead = "SELECT CASE_ID FROM CPV_IDOC_VERIFICATION " +
    ////                   " WHERE CASE_ID='" + CaseID + "'" +
    ////                   " AND VERIFICATION_TYPE_ID='" + VerificationTypeId + "'";
    ////        oledbRead= OleDbHelper.ExecuteReader(oledbTrans, CommandType.Text, sSqlRead);

    ////        OleDbParameter[] paramBankStat = new OleDbParameter[14];
    ////        if (oledbRead.Read() == false)
    ////        {
    ////            sSql = "INSERT INTO CPV_IDOC_VERIFICATION(CASE_ID,VERIFICATION_TYPE_ID,Person_contacted," +
    ////                  "Cont_Designation_dept,ACCOUNT_CORRECT,DOCUMENT_AS_PER_STANDARD,AMOUNT_ON_DOC,FE_REMARK,FE_VISIT_DATE,CASE_STATUS_ID," +
    ////                  "ADD_BY,ADD_DATE,Supervisor_sign,AreaID) " +
    ////                  " VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

    ////            paramBankStat[0] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 15);
    ////            paramBankStat[0].Value = CaseID;
    ////            paramBankStat[1] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 10);
    ////            paramBankStat[1].Value = VerificationTypeId;
    ////            paramBankStat[2] = new OleDbParameter("@Person_contacted", OleDbType.VarChar, 100);
    ////            paramBankStat[2].Value = NameOfPersonContacted;
    ////            paramBankStat[3] = new OleDbParameter("@Cont_Designation_dept", OleDbType.VarChar, 200);
    ////            paramBankStat[3].Value = Cont_DesignationDepartment;
    ////            paramBankStat[4] = new OleDbParameter("@ACCOUNT_CORRECT", OleDbType.VarChar, 15);
    ////            paramBankStat[4].Value = IsAcctCorrect;
    ////            paramBankStat[5] = new OleDbParameter("@DOCUMENT_AS_PER_STANDARD", OleDbType.VarChar, 15);
    ////            paramBankStat[5].Value = StanForOrg;
    ////            paramBankStat[6] = new OleDbParameter("@AMOUNT_ON_DOC", OleDbType.VarChar, 15);
    ////            paramBankStat[6].Value = AmtSSSPSC;
    ////            paramBankStat[7] = new OleDbParameter("@FE_REMARK", OleDbType.VarChar, 2000);
    ////            paramBankStat[7].Value = FERemarks;
    ////            paramBankStat[8] = new OleDbParameter("@VeriDate", OleDbType.VarChar, 11);
    ////            paramBankStat[8].Value = VeriDate;
    ////            paramBankStat[9] = new OleDbParameter("@CaseStatusID", OleDbType.VarChar, 15);
    ////            paramBankStat[9].Value = CaseStatusID;
    ////            paramBankStat[10] = new OleDbParameter("@AddedBy", OleDbType.VarChar, 15);
    ////            paramBankStat[10].Value = AddedBy;
    ////            paramBankStat[11] = new OleDbParameter("@AddedOn", OleDbType.DBTimeStamp);
    ////            paramBankStat[11].Value = AddedOn;
    ////            paramBankStat[12] = new OleDbParameter("@Supervisor_sign", OleDbType.VarChar, 255);
    ////            paramBankStat[12].Value = Supervisor_sign;
    ////            paramBankStat[13] = new OleDbParameter("@AreaID", OleDbType.VarChar, 255);
    ////            paramBankStat[13].Value = AreaID;


    ////            sRetVal = "Record added successfully.";

    ////        }
    ////        else
    ////        {
    ////            sSql = "UPDATE CPV_IDOC_VERIFICATION SET Person_contacted=?," +
    ////                 " Cont_Designation_dept=?,ACCOUNT_CORRECT=?,DOCUMENT_AS_PER_STANDARD=?,AMOUNT_ON_DOC=?," +
    ////                 " FE_REMARK=?,FE_VISIT_DATE=?,CASE_STATUS_ID=?,MODIFY_BY=?,MODIFY_DATE=?,Supervisor_sign=?,AreaID=? " +
    ////                 " WHERE CASE_ID=? AND VERIFICATION_TYPE_ID=?";

    ////            paramBankStat[0] = new OleDbParameter("@Person_contacted", OleDbType.VarChar, 100);
    ////            paramBankStat[0].Value = NameOfPersonContacted;
    ////            paramBankStat[1] = new OleDbParameter("@Cont_Designation_dept", OleDbType.VarChar, 200);
    ////            paramBankStat[1].Value = Cont_DesignationDepartment;
    ////            paramBankStat[2] = new OleDbParameter("@ACCOUNT_CORRECT", OleDbType.VarChar, 15);
    ////            paramBankStat[2].Value = IsAcctCorrect;
    ////            paramBankStat[3] = new OleDbParameter("@DOCUMENT_AS_PER_STANDARD", OleDbType.VarChar, 15);
    ////            paramBankStat[3].Value = StanForOrg;
    ////            paramBankStat[4] = new OleDbParameter("@AMOUNT_ON_DOC", OleDbType.VarChar, 15);
    ////            paramBankStat[4].Value = AmtSSSPSC;
    ////            paramBankStat[5] = new OleDbParameter("@FE_REMARK", OleDbType.VarChar, 2000);
    ////            paramBankStat[5].Value = FERemarks;
    ////            paramBankStat[6] = new OleDbParameter("@VeriDate", OleDbType.VarChar, 11);
    ////            paramBankStat[6].Value = VeriDate;
    ////            paramBankStat[7] = new OleDbParameter("@CaseStatusID", OleDbType.VarChar, 15);
    ////            paramBankStat[7].Value = CaseStatusID;
    ////            paramBankStat[8] = new OleDbParameter("@ModifyBy", OleDbType.VarChar, 15);
    ////            paramBankStat[8].Value = ModifyBy;
    ////            paramBankStat[9] = new OleDbParameter("@ModifyOn", OleDbType.DBTimeStamp);
    ////            paramBankStat[9].Value = ModifyOn;
    ////            paramBankStat[10] = new OleDbParameter("@Supervisor_sign", OleDbType.VarChar, 255);
    ////            paramBankStat[10].Value = Supervisor_sign;
    ////            paramBankStat[11] = new OleDbParameter("@AreaID", OleDbType.VarChar, 255);
    ////            paramBankStat[11].Value = AreaID;
    ////            paramBankStat[12] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 15);
    ////            paramBankStat[12].Value = CaseID;
    ////            paramBankStat[13] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 11);
    ////            paramBankStat[13].Value = VerificationTypeId;

    ////            sRetVal = "Record updated successfully.";
    ////        }
    ////        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramBankStat);
    ////        //////////add by santosh shelar/////////////////////
    ////        //sSql = "Update CPV_IDOC_CASE_DETAILS SET IS_CASE_COMPLETE='Y' WHERE CASE_ID='" + CaseID + "'";
    ////        ///OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);
    ////        //Start Insert into CASE_TRANSACTION_LOG -------------------
    ////        sSql = "";
    ////        sSql = "Insert into CASE_TRANSACTION_LOG(CASE_ID,VERIFICATION_TYPE_ID,USER_ID,TRANS_START,TRANS_END," +
    ////             "CENTRE_ID,PRODUCT_ID,CLIENT_ID) VALUES(?,?,?,?,?,?,?,?)";

    ////        OleDbParameter[] paramTransLog = new OleDbParameter[8];
    ////        paramTransLog[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
    ////        paramTransLog[0].Value = CaseID;
    ////        paramTransLog[1] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar, 15);
    ////        paramTransLog[1].Value = VerificationTypeId;
    ////        paramTransLog[2] = new OleDbParameter("@UserId", OleDbType.VarChar, 15);
    ////        paramTransLog[2].Value = UserId;
    ////        paramTransLog[3] = new OleDbParameter("@TransStart", OleDbType.DBTimeStamp);
    ////        paramTransLog[3].Value = TransStart;
    ////        paramTransLog[4] = new OleDbParameter("@TransEnd", OleDbType.DBTimeStamp);
    ////        paramTransLog[4].Value = TransEnd;
    ////        paramTransLog[5] = new OleDbParameter("@CentreId", OleDbType.VarChar, 15);
    ////        paramTransLog[5].Value = CentreId;
    ////        paramTransLog[6] = new OleDbParameter("@ProductId", OleDbType.VarChar, 15);
    ////        paramTransLog[6].Value = ProductId;
    ////        paramTransLog[7] = new OleDbParameter("@ClientId", OleDbType.VarChar, 15);
    ////        paramTransLog[7].Value = ClientId;

    ////        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramTransLog);

    ////        //End  Insert into CASE_TRANSACTION_LOG --------------------
    ////        if (IsVerificationComplete(CaseID) == "true")
    ////        {
    ////            VerificationComplete(CaseID);
    ////            sRetVal += " Case verification data entry completed.";
    ////        }
    ////        /////
    ////        oledbTrans.Commit();
    ////        oledbConn.Close();

    ////        return sRetVal;
    ////    }
    ////    catch (Exception ex)
    ////    {
    ////        oledbTrans.Rollback();
    ////        oledbConn.Close();
    ////        throw new Exception("Error while Inserting Bank statement Detail " + ex.Message);
    ////    }
    ////}

    ////#endregion InsertBankStatement()
    //----------------------------------------------------------------------------------------------------------------------

    //add by: Akanksha
    //add date:29/9/2014


    #region InsertUpdateBankStatement()
    public string InsertUpdateBankStatement()
    {

        Int32 i = 0;
        string sRetVal = "";

        try
        {
            using (SqlConnection con = new SqlConnection(oCmn.AppConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_IDOC_BankStatementVerification_InsertUpdateBankStatement", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@CASE_ID", CaseID);
                command.Parameters.AddWithValue("@VERIFICATION_TYPE_ID", VerificationTypeId);

                command.Parameters.AddWithValue("@Person_contacted", NameOfPersonContacted);
                command.Parameters.AddWithValue("@Cont_Designation_dept", Cont_DesignationDepartment);

                command.Parameters.AddWithValue("@ACCOUNT_CORRECT", IsAcctCorrect);
                command.Parameters.AddWithValue("@DOCUMENT_AS_PER_STANDARD", StanForOrg);

                command.Parameters.AddWithValue("@AMOUNT_ON_DOC", AmtSSSPSC);
                command.Parameters.AddWithValue("@FE_REMARK", FERemarks);

                command.Parameters.AddWithValue("@FE_VISIT_DATE", VeriDate);
                command.Parameters.AddWithValue("@CASE_STATUS_ID", CaseStatusID);

                command.Parameters.AddWithValue("@ADD_BY", AddedBy);
                command.Parameters.AddWithValue("@ADD_DATE", AddedOn);

                command.Parameters.AddWithValue("@Supervisor_sign", Supervisor_sign);
                command.Parameters.AddWithValue("@AreaID", AreaID);

                command.Parameters.AddWithValue("@MODIFY_BY", ModifyBy);
                command.Parameters.AddWithValue("@MODIFY_DATE", ModifyOn);


                con.Open();
                i = command.ExecuteNonQuery();
                con.Close();
            }

        }
        catch
        {

        }

        //--CASE_TRANSACTION_LOG 

        try
        {
            using (SqlConnection con = new SqlConnection(oCmn.AppConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_IDOC_BankStatementVerification_CASE_TRANSACTION_LOG", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@CASE_ID", CaseID);
                command.Parameters.AddWithValue("@VERIFICATION_TYPE_ID", VerificationTypeId);

                command.Parameters.AddWithValue("@USER_ID", UserId);
                command.Parameters.AddWithValue("@TRANS_START", TransStart);

                command.Parameters.AddWithValue("@TRANS_END", TransEnd);
                command.Parameters.AddWithValue("@CENTRE_ID", CentreId);

                command.Parameters.AddWithValue("@PRODUCT_ID", ProductId);
                command.Parameters.AddWithValue("@CLIENT_ID", ClientId);

                //----Modify by:akanksha
                //----Modify Date : 15/09/2014

                if (IsVerificationComplete(CaseID) == "true")
                {
                    VerificationComplete(CaseID);
                    sRetVal += " Case verification data entry completed.";
                }

                con.Open();
                i = command.ExecuteNonQuery();
                con.Close();

            }

        }
        catch
        {

        }

        return sRetVal;


    }


    #endregion InsertUpdateBankStatement()


    //------comp-----//


//---------------------------------------------------------------------------------------------------------------------------------------------


    //comment by kanchan on 29/9/2014

    ////#region InsertPancardVerification()
    
    ////public string InsertPancardVerification()
    ////{

    ////    OleDbConnection oledbConn = new OleDbConnection(oCmn.ConnectionString);
    ////    oledbConn.Open();
    ////    OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
    ////    string sRetVal = "";
    ////    try
    ////    {
    ////        string sSql = "";
    ////        string sSqlRead = "";
    ////        OleDbDataReader oledbRead;
    ////        sSqlRead = "SELECT CASE_ID FROM CPV_IDOC_VERIFICATION " +
    ////                   " WHERE CASE_ID='" + CaseID + "'" +
    ////                   " AND VERIFICATION_TYPE_ID='" + VerificationTypeId + "'";
    ////        oledbRead = OleDbHelper.ExecuteReader(oledbTrans, CommandType.Text, sSqlRead);

    ////        OleDbParameter[] paramBankStat = new OleDbParameter[20];
    ////        if (oledbRead.Read() == false)
    ////        {
    ////            sSql = "INSERT INTO CPV_IDOC_VERIFICATION(CASE_ID,VERIFICATION_TYPE_ID,Ispancardlogic,IsPancarddigit,IsPancardalphabet,IsPancarddnumeric,IsPancardmatch," +
    ////                   "Observation,Verifier,IspancardNoMatch,Ispancardholder,Isfathermatch,IsdateOfbirth,supervisorname,FE_REMARK,FE_VISIT_DATE,CASE_STATUS_ID,Ref_no," +
    ////                   "ADD_BY,ADD_DATE) " +
    ////                   " VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

    ////            paramBankStat[0] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 15);
    ////            paramBankStat[0].Value = CaseID;
    ////            paramBankStat[1] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 10);
    ////            paramBankStat[1].Value = VerificationTypeId;
    ////            paramBankStat[2] = new OleDbParameter("@Ispancardlogic", OleDbType.VarChar, 10);
    ////            paramBankStat[2].Value = Ispancardlogic;
    ////            paramBankStat[3] = new OleDbParameter("@IsPancarddigit", OleDbType.VarChar, 10);
    ////            paramBankStat[3].Value = IsPancarddigit;
    ////            paramBankStat[4] = new OleDbParameter("@IsPancardalphabet", OleDbType.VarChar, 10);
    ////            paramBankStat[4].Value = IsPancardalphabet;
    ////            paramBankStat[5] = new OleDbParameter("@IsPancarddnumeric", OleDbType.VarChar, 10);
    ////            paramBankStat[5].Value = IsPancarddnumeric;
    ////            paramBankStat[6] = new OleDbParameter("@IsPancardmatch", OleDbType.VarChar, 10);
    ////            paramBankStat[6].Value = IsPancardmatch;
    ////            paramBankStat[7] = new OleDbParameter("@Observation", OleDbType.VarChar, 1000);
    ////            paramBankStat[7].Value = Observation;
    ////            paramBankStat[8] = new OleDbParameter("@Verifier", OleDbType.VarChar, 500);
    ////            paramBankStat[8].Value = Verifier;
    ////            paramBankStat[9] = new OleDbParameter("@IspancardNoMatch", OleDbType.VarChar, 10);
    ////            paramBankStat[9].Value = IspancardNoMatch;
    ////            paramBankStat[10] = new OleDbParameter("@Ispancardholder", OleDbType.VarChar, 10);
    ////            paramBankStat[10].Value = Ispancardholder;
    ////            paramBankStat[11] = new OleDbParameter("@Isfathermatch", OleDbType.VarChar, 10);
    ////            paramBankStat[11].Value = Isfathermatch;
    ////            paramBankStat[12] = new OleDbParameter("@IsdateOfbirth", OleDbType.VarChar, 10);
    ////            paramBankStat[12].Value = IsdateOfbirth;
    ////            paramBankStat[13] = new OleDbParameter("@supervisorname", OleDbType.VarChar, 500);
    ////            paramBankStat[13].Value = supervisorname;
    ////            paramBankStat[14] = new OleDbParameter("@FE_REMARK", OleDbType.VarChar, 2000);
    ////            paramBankStat[14].Value = FERemarks;
    ////            paramBankStat[15] = new OleDbParameter("@VeriDate", OleDbType.VarChar, 11);
    ////            paramBankStat[15].Value = VeriDate;
    ////            paramBankStat[16] = new OleDbParameter("@CaseStatusID", OleDbType.VarChar, 15);
    ////            paramBankStat[16].Value = CaseStatusID;
    ////            paramBankStat[17] = new OleDbParameter("@Ref_no", OleDbType.VarChar, 15);
    ////            paramBankStat[17].Value = CRef_No;
    ////            paramBankStat[18] = new OleDbParameter("@AddedBy", OleDbType.VarChar, 15);
    ////            paramBankStat[18].Value = AddedBy;
    ////            paramBankStat[19] = new OleDbParameter("@AddedOn", OleDbType.DBTimeStamp);
    ////            paramBankStat[19].Value = AddedOn;



    ////            sRetVal = "Record added successfully.";

    ////        }

    ////        else
    ////        {
    ////            sSql = "UPDATE CPV_IDOC_VERIFICATION SET Ispancardlogic=?,IsPancarddigit=?,IsPancardalphabet=?,IsPancarddnumeric=?,IsPancardmatch=?,Observation=?," +
    ////                   "Verifier=?,IspancardNoMatch=?,Ispancardholder=?,Isfathermatch=?,IsdateOfbirth=?,supervisorname=?," +
    ////                   "FE_REMARK=?,FE_VISIT_DATE=?,CASE_STATUS_ID=?,Ref_no=?,MODIFY_BY=?,MODIFY_DATE=?  " +
    ////                   " WHERE CASE_ID=? AND VERIFICATION_TYPE_ID=? ";


    ////            paramBankStat[0] = new OleDbParameter("@Ispancardlogic", OleDbType.VarChar, 10);
    ////            paramBankStat[0].Value = Ispancardlogic;
    ////            paramBankStat[1] = new OleDbParameter("@IsPancarddigit", OleDbType.VarChar, 10);
    ////            paramBankStat[1].Value = IsPancarddigit;
    ////            paramBankStat[2] = new OleDbParameter("@IsPancardalphabet", OleDbType.VarChar, 10);
    ////            paramBankStat[2].Value = IsPancardalphabet;
    ////            paramBankStat[3] = new OleDbParameter("@IsPancarddnumeric", OleDbType.VarChar, 10);
    ////            paramBankStat[3].Value = IsPancarddnumeric;
    ////            paramBankStat[4] = new OleDbParameter("@IsPancardmatch", OleDbType.VarChar, 10);
    ////            paramBankStat[4].Value = IsPancardmatch;
    ////            paramBankStat[5] = new OleDbParameter("@Observation", OleDbType.VarChar, 1000);
    ////            paramBankStat[5].Value = Observation;
    ////            paramBankStat[6] = new OleDbParameter("@Verifier", OleDbType.VarChar, 500);
    ////            paramBankStat[6].Value = Verifier;
    ////            paramBankStat[7] = new OleDbParameter("@IspancardNoMatch", OleDbType.VarChar, 10);
    ////            paramBankStat[7].Value = IspancardNoMatch;
    ////            paramBankStat[8] = new OleDbParameter("@Ispancardholder", OleDbType.VarChar, 10);
    ////            paramBankStat[8].Value = Ispancardholder;
    ////            paramBankStat[9] = new OleDbParameter("@Isfathermatch", OleDbType.VarChar, 10);
    ////            paramBankStat[9].Value = Isfathermatch;
    ////            paramBankStat[10] = new OleDbParameter("@IsdateOfbirth", OleDbType.VarChar, 10);
    ////            paramBankStat[10].Value = IsdateOfbirth;
    ////            paramBankStat[11] = new OleDbParameter("@supervisorname", OleDbType.VarChar, 500);
    ////            paramBankStat[11].Value = supervisorname;
    ////            paramBankStat[12] = new OleDbParameter("@FE_REMARK", OleDbType.VarChar, 2000);
    ////            paramBankStat[12].Value = FERemarks;
    ////            paramBankStat[13] = new OleDbParameter("@VeriDate", OleDbType.VarChar, 11);
    ////            paramBankStat[13].Value = VeriDate;
    ////            paramBankStat[14] = new OleDbParameter("@CaseStatusID", OleDbType.VarChar, 15);
    ////            paramBankStat[14].Value = CaseStatusID;
    ////            paramBankStat[15] = new OleDbParameter("@Ref_no", OleDbType.VarChar, 15);
    ////            paramBankStat[15].Value = CRef_No;
    ////            paramBankStat[16] = new OleDbParameter("@ModifyBy", OleDbType.VarChar, 15);
    ////            paramBankStat[16].Value = ModifyBy;
    ////            paramBankStat[17] = new OleDbParameter("@ModifyOn", OleDbType.DBTimeStamp);
    ////            paramBankStat[17].Value = ModifyOn;
    ////            paramBankStat[18] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
    ////            paramBankStat[18].Value = CaseID;
    ////            paramBankStat[19] = new OleDbParameter("@VerificationTypeId", OleDbType.VarChar, 11);
    ////            paramBankStat[19].Value = VerificationTypeId;

    ////            sRetVal = "Record updated successfully.";

    ////        }
    ////        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramBankStat);

    ////        sSql = "";

    ////        sSql = "Insert into CASE_TRANSACTION_LOG(CASE_ID,VERIFICATION_TYPE_ID,USER_ID,TRANS_START,TRANS_END," +
    ////             "CENTRE_ID,PRODUCT_ID,CLIENT_ID) VALUES(?,?,?,?,?,?,?,?)";

    ////        OleDbParameter[] paramTransLog = new OleDbParameter[8];
    ////        paramTransLog[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
    ////        paramTransLog[0].Value = CaseID;
    ////        paramTransLog[1] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar, 15);
    ////        paramTransLog[1].Value = VerificationTypeId;
    ////        paramTransLog[2] = new OleDbParameter("@UserId", OleDbType.VarChar, 15);
    ////        paramTransLog[2].Value = UserId;
    ////        paramTransLog[3] = new OleDbParameter("@TransStart", OleDbType.DBTimeStamp);
    ////        paramTransLog[3].Value = TransStart;
    ////        paramTransLog[4] = new OleDbParameter("@TransEnd", OleDbType.DBTimeStamp);
    ////        paramTransLog[4].Value = TransEnd;
    ////        paramTransLog[5] = new OleDbParameter("@CentreId", OleDbType.VarChar, 15);
    ////        paramTransLog[5].Value = CentreId;
    ////        paramTransLog[6] = new OleDbParameter("@ProductId", OleDbType.VarChar, 15);
    ////        paramTransLog[6].Value = ProductId;
    ////        paramTransLog[7] = new OleDbParameter("@ClientId", OleDbType.VarChar, 15);
    ////        paramTransLog[7].Value = ClientId;

    ////        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramTransLog);

    ////        if (IsVerificationComplete(CaseID) == "true")
    ////        {
    ////            VerificationComplete(CaseID);
    ////            sRetVal += " Case verification data entry completed.";
    ////        }

    ////        oledbTrans.Commit();
    ////        oledbConn.Close();

    ////        return sRetVal;

    ////    }
    ////    catch (Exception ex)
    ////    {
    ////        oledbTrans.Rollback();
    ////        oledbConn.Close();
    ////        throw new Exception("Error while Inserting Pan card Detail " + ex.Message);
    ////    }

    ////}
    ////#endregion InsertPancardVerification()

    //--------------------------------------------------------------------------------------------------------------------------------
    
    //Name       :InsertPancardVerification()
    //Modify by  :Akanksha
    //Modify date:29/09/2014
    //sp_name : sp_InsertPancardVerification

    #region InsertPancardVerification()

    public string InsertPancardVerification()
    {

        Int32 i = 0;
        string sRetVal = "";

        try
        {
            using (SqlConnection con = new SqlConnection(oCmn.AppConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_InsertPancardVerification", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@CASE_ID", CaseID);
                command.Parameters.AddWithValue("@VERIFICATION_TYPE_ID", VerificationTypeId);

                command.Parameters.AddWithValue("@Ispancardlogic", Ispancardlogic);
                command.Parameters.AddWithValue("@IsPancarddigit", IsPancarddigit);

                command.Parameters.AddWithValue("@IsPancardalphabet", IsPancardalphabet);
                command.Parameters.AddWithValue("@IsPancarddnumeric", IsPancarddnumeric);

                command.Parameters.AddWithValue("@IsPancardmatch", IsPancardmatch);
                command.Parameters.AddWithValue("@Observation", Observation);

                command.Parameters.AddWithValue("@Verifier", Verifier);
                command.Parameters.AddWithValue("@IspancardNoMatch", IspancardNoMatch);

                command.Parameters.AddWithValue("@Ispancardholder", Ispancardholder);
                command.Parameters.AddWithValue("@Isfathermatch", Isfathermatch);

                command.Parameters.AddWithValue("@IsdateOfbirth", IsdateOfbirth);
                command.Parameters.AddWithValue("@supervisorname", supervisorname);

                command.Parameters.AddWithValue("@FE_REMARK", FERemarks);
                command.Parameters.AddWithValue("@FE_VISIT_DATE", VeriDate);

                command.Parameters.AddWithValue("@CASE_STATUS_ID", CaseStatusID);
                command.Parameters.AddWithValue("@Ref_no", CRef_No);

                command.Parameters.AddWithValue("@ADD_BY", AddedBy);
                command.Parameters.AddWithValue("@ADD_DATE", AddedOn);

                command.Parameters.AddWithValue("@MODIFY_BY", ModifyBy);
                command.Parameters.AddWithValue("@MODIFY_DATE", ModifyOn);



                con.Open();
                i = command.ExecuteNonQuery();
                con.Close();
            }

        }
        catch
        {

        }

        //--CASE_TRANSACTION_LOG 

        try
        {
            using (SqlConnection con = new SqlConnection(oCmn.AppConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_IDOC_PancardVerfication_CASE_TRANSACTION_LOG", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@CASE_ID", CaseID);
                command.Parameters.AddWithValue("@VERIFICATION_TYPE_ID", VerificationTypeId);

                command.Parameters.AddWithValue("@USER_ID", UserId);
                command.Parameters.AddWithValue("@TRANS_START", TransStart);

                command.Parameters.AddWithValue("@TRANS_END", TransEnd);
                command.Parameters.AddWithValue("@CENTRE_ID", CentreId);

                command.Parameters.AddWithValue("@PRODUCT_ID", ProductId);
                command.Parameters.AddWithValue("@CLIENT_ID", ClientId);

                //----Modify by:akanksha
                //----Modify Date : 11/09/2014

                if (IsVerificationComplete(CaseID) == "true")
                {
                    VerificationComplete(CaseID);
                    sRetVal += " Case verification data entry completed.";
                }

                con.Open();
                i = command.ExecuteNonQuery();
                con.Close();

            }

        }
        catch
        {

        }

        return sRetVal;


    }
    #endregion InsertPancardVerification()


    //---------comp--------//

    //comment by kanchan on 29/9/2014

    ////#region InsertUpdateIDOCformat()
    
    ////public string InsertUpdateIDOCformat()
    ////{
    ////    OleDbConnection oledbConn = new OleDbConnection(oCmn.ConnectionString);
    ////    oledbConn.Open();
    ////    OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
    ////    string sRetVal = "";
    ////    try
    ////    {
    ////        string sSql = "";
    ////        string sSqlRead = "";
    ////        OleDbDataReader oledbRead;
    ////        sSqlRead = "SELECT CASE_ID FROM CPV_IDOC_VERIFICATION " +
    ////                   " WHERE CASE_ID='" + CaseID + "'" +
    ////                   " AND VERIFICATION_TYPE_ID='" + VerificationTypeId + "'";
    ////        oledbRead = OleDbHelper.ExecuteReader(oledbTrans, CommandType.Text, sSqlRead);

    ////        OleDbParameter[] paramBankStat = new OleDbParameter[19];
    ////        if (oledbRead.Read() == false)
    ////        {
    ////            sSql = "INSERT INTO CPV_IDOC_VERIFICATION(CASE_ID,VERIFICATION_TYPE_ID,Ref_no,Nameofseviceprovider,Dateofissues,backofficeremark," +
    ////                   "Person_contacted,Cont_Designation_dept,Billmatch,Numbermatch,Adderssmatch,FE_REMARK,Confirmeddetalis,FE_VISIT_DATE,CASE_STATUS_ID,VerificationNumber," +
    ////                   "ADD_BY,ADD_DATE,Supervisor_sign) " +
    ////                   "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

    ////            paramBankStat[0] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 15);
    ////            paramBankStat[0].Value = CaseID;
    ////            paramBankStat[1] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 10);
    ////            paramBankStat[1].Value = VerificationTypeId;
    ////            paramBankStat[2] = new OleDbParameter("@Ref_no", OleDbType.VarChar, 100);
    ////            paramBankStat[2].Value = CPARef_No;
    ////            paramBankStat[3] = new OleDbParameter("@Nameofseviceprovider", OleDbType.VarChar, 100);
    ////            paramBankStat[3].Value = Nameofseviceprovider;
    ////            paramBankStat[4] = new OleDbParameter("@Dateofissues", OleDbType.VarChar, 15);
    ////            paramBankStat[4].Value = Dateofissues;
    ////            paramBankStat[5] = new OleDbParameter("@backofficeremark", OleDbType.VarChar, 1000);
    ////            paramBankStat[5].Value = backofficeremark;
    ////            paramBankStat[6] = new OleDbParameter("@Person_contacted", OleDbType.VarChar, 100);
    ////            paramBankStat[6].Value = NameOfPersonContacted;
    ////            paramBankStat[7] = new OleDbParameter("@Cont_Designation_dept", OleDbType.VarChar, 100);
    ////            paramBankStat[7].Value = Cont_DesignationDepartment;
    ////            paramBankStat[8] = new OleDbParameter("@Billmatch", OleDbType.VarChar, 10);
    ////            paramBankStat[8].Value = Billmatch;
    ////            paramBankStat[9] = new OleDbParameter("@Numbermatch", OleDbType.VarChar, 10);
    ////            paramBankStat[9].Value = Numbermatch;
    ////            paramBankStat[10] = new OleDbParameter("@Adderssmatch", OleDbType.VarChar, 10);
    ////            paramBankStat[10].Value = Adderssmatch;
    ////            paramBankStat[11] = new OleDbParameter("@FE_REMARK", OleDbType.VarChar, 1000);
    ////            paramBankStat[11].Value = Remarks1;
    ////            paramBankStat[12] = new OleDbParameter("@Confirmeddetalis", OleDbType.VarChar, 1000);
    ////            paramBankStat[12].Value = Confirmeddetalis;
    ////            paramBankStat[13] = new OleDbParameter("@FE_VISIT_DATE", OleDbType.VarChar, 15);
    ////            paramBankStat[13].Value = VeriDate;
    ////            paramBankStat[14] = new OleDbParameter("@CaseStatusID", OleDbType.VarChar, 15);
    ////            paramBankStat[14].Value = CaseStatusID;
    ////            paramBankStat[15] = new OleDbParameter("@VerificationNumber", OleDbType.VarChar, 100);
    ////            paramBankStat[15].Value = VerificationNumber;
    ////            paramBankStat[16] = new OleDbParameter("@AddedBy", OleDbType.VarChar, 15);
    ////            paramBankStat[16].Value = AddedBy;
    ////            paramBankStat[17] = new OleDbParameter("@AddedOn", OleDbType.DBTimeStamp);
    ////            paramBankStat[17].Value = AddedOn;
    ////            paramBankStat[18] = new OleDbParameter("@Supervisor_sign", OleDbType.VarChar, 255);
    ////            paramBankStat[18].Value = Supervisor_sign;

    ////            sRetVal = "Record added successfully.";

    ////        }
    ////        else
    ////        {
    ////            sSql = "UPDATE CPV_IDOC_VERIFICATION SET Ref_no=?,Nameofseviceprovider=?, " +
    ////                   "Dateofissues=?,backofficeremark=?,Person_contacted=?,Cont_Designation_dept=?,Billmatch=?, " +
    ////                   "Numbermatch=?,Adderssmatch=?,FE_REMARK=?,Confirmeddetalis=?,FE_VISIT_DATE=?,CASE_STATUS_ID=?,VerificationNumber=?,MODIFY_BY=?,MODIFY_DATE=?,Supervisor_sign=?" +
    ////                   " WHERE CASE_ID=? AND VERIFICATION_TYPE_ID=?";

    ////            paramBankStat[0] = new OleDbParameter("@Ref_no", OleDbType.VarChar, 100);
    ////            paramBankStat[0].Value = CPARef_No;
    ////            paramBankStat[1] = new OleDbParameter("@Nameofseviceprovider", OleDbType.VarChar, 100);
    ////            paramBankStat[1].Value = Nameofseviceprovider;
    ////            paramBankStat[2] = new OleDbParameter("@Dateofissues", OleDbType.VarChar, 15);
    ////            paramBankStat[2].Value = Dateofissues;
    ////            paramBankStat[3] = new OleDbParameter("@backofficeremark", OleDbType.VarChar, 1000);
    ////            paramBankStat[3].Value = backofficeremark;
    ////            paramBankStat[4] = new OleDbParameter("@Person_contacted", OleDbType.VarChar, 100);
    ////            paramBankStat[4].Value = NameOfPersonContacted;
    ////            paramBankStat[5] = new OleDbParameter("@Cont_Designation_dept", OleDbType.VarChar, 100);
    ////            paramBankStat[5].Value = Cont_DesignationDepartment;
    ////            paramBankStat[6] = new OleDbParameter("@Billmatch", OleDbType.VarChar, 10);
    ////            paramBankStat[6].Value = Billmatch;
    ////            paramBankStat[7] = new OleDbParameter("@Numbermatch", OleDbType.VarChar, 10);
    ////            paramBankStat[7].Value = Numbermatch;
    ////            paramBankStat[8] = new OleDbParameter("@Adderssmatch", OleDbType.VarChar, 10);
    ////            paramBankStat[8].Value = Adderssmatch;
    ////            paramBankStat[9] = new OleDbParameter("@FE_REMARK", OleDbType.VarChar, 1000);
    ////            paramBankStat[9].Value = Remarks1;
    ////            paramBankStat[10] = new OleDbParameter("@Confirmeddetalis", OleDbType.VarChar, 1000);
    ////            paramBankStat[10].Value = Confirmeddetalis;
    ////            paramBankStat[11] = new OleDbParameter("@FE_VISIT_DATE", OleDbType.VarChar, 15);
    ////            paramBankStat[11].Value = VeriDate;
    ////            paramBankStat[12] = new OleDbParameter("@CASE_STATUS_ID", OleDbType.VarChar, 15);
    ////            paramBankStat[12].Value = CaseStatusID;
    ////            paramBankStat[13] = new OleDbParameter("@VerificationNumber", OleDbType.VarChar, 100);
    ////            paramBankStat[13].Value = VerificationNumber;
    ////            paramBankStat[14] = new OleDbParameter("@MODIFY_BY", OleDbType.VarChar, 15);
    ////            paramBankStat[14].Value = ModifyBy;
    ////            paramBankStat[15] = new OleDbParameter("@MODIFY_DATE", OleDbType.DBTimeStamp);
    ////            paramBankStat[15].Value = ModifyOn;

    ////            paramBankStat[16] = new OleDbParameter("@Supervisor_sign", OleDbType.VarChar, 255);
    ////            paramBankStat[16].Value = Supervisor_sign;

    ////            paramBankStat[17] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 15);
    ////            paramBankStat[17].Value = CaseID;
    ////            paramBankStat[18] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 11);
    ////            paramBankStat[18].Value = VerificationTypeId;

    ////            sRetVal = "Record updated successfully.";
    ////        }
    ////        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramBankStat);
    ////        sSql = "";
    ////        sSql = "Insert into CASE_TRANSACTION_LOG(CASE_ID,VERIFICATION_TYPE_ID,USER_ID,TRANS_START,TRANS_END," +
    ////             "CENTRE_ID,PRODUCT_ID,CLIENT_ID) VALUES(?,?,?,?,?,?,?,?)";

    ////        OleDbParameter[] paramTransLog = new OleDbParameter[8];
    ////        paramTransLog[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
    ////        paramTransLog[0].Value = CaseID;
    ////        paramTransLog[1] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar, 15);
    ////        paramTransLog[1].Value = VerificationTypeId;
    ////        paramTransLog[2] = new OleDbParameter("@UserId", OleDbType.VarChar, 15);
    ////        paramTransLog[2].Value = UserId;
    ////        paramTransLog[3] = new OleDbParameter("@TransStart", OleDbType.DBTimeStamp);
    ////        paramTransLog[3].Value = TransStart;
    ////        paramTransLog[4] = new OleDbParameter("@TransEnd", OleDbType.DBTimeStamp);
    ////        paramTransLog[4].Value = TransEnd;
    ////        paramTransLog[5] = new OleDbParameter("@CentreId", OleDbType.VarChar, 15);
    ////        paramTransLog[5].Value = CentreId;
    ////        paramTransLog[6] = new OleDbParameter("@ProductId", OleDbType.VarChar, 15);
    ////        paramTransLog[6].Value = ProductId;
    ////        paramTransLog[7] = new OleDbParameter("@ClientId", OleDbType.VarChar, 15);
    ////        paramTransLog[7].Value = ClientId;

    ////        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramTransLog);


    ////        if (IsVerificationComplete(CaseID) == "true")
    ////        {
    ////            VerificationComplete(CaseID);
    ////            sRetVal += " Case verification data entry completed.";
    ////        }
    ////        oledbTrans.Commit();
    ////        oledbConn.Close();

    ////        return sRetVal;

    ////    }
    ////    catch (Exception ex)
    ////    {
    ////        oledbTrans.Rollback();
    ////        oledbConn.Close();
    ////        throw new Exception("Error while Inserting Bank statement Detail " + ex.Message);
    ////    }

    ////}
    ////#endregion InsertUpdateIDOCformat()




    //Modify By:-Akanksha
    //Modify Date :- 29/9/2014

    #region InsertUpdateIDOCformat()


    public string InsertUpdateIDOCformat()
    {


        Int32 i = 0;
        string sRetVal = "";

        try
        {
            using (SqlConnection con = new SqlConnection(oCmn.AppConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_IDOC_Paasport_InsertUpdateIDOCformat", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@CASE_ID", CaseID);
                command.Parameters.AddWithValue("@VERIFICATION_TYPE_ID", VerificationTypeId);

                command.Parameters.AddWithValue("@Ref_no", CPARef_No);
                command.Parameters.AddWithValue("@Nameofseviceprovider", Nameofseviceprovider);

                command.Parameters.AddWithValue("@Dateofissues", Dateofissues);
                command.Parameters.AddWithValue("@backofficeremark", backofficeremark);

                command.Parameters.AddWithValue("@Person_contacted", NameOfPersonContacted);
                command.Parameters.AddWithValue("@Cont_Designation_dept", Cont_DesignationDepartment);

                command.Parameters.AddWithValue("@Billmatch", Billmatch);
                command.Parameters.AddWithValue("@Numbermatch", Numbermatch);

                command.Parameters.AddWithValue("@Adderssmatch", Adderssmatch);
                command.Parameters.AddWithValue("@FE_REMARK", Remarks1);

                command.Parameters.AddWithValue("@Confirmeddetalis", Confirmeddetalis);
                command.Parameters.AddWithValue("@FE_VISIT_DATE", VeriDate);

                command.Parameters.AddWithValue("@CASE_STATUS_ID", CaseStatusID);
                command.Parameters.AddWithValue("@VerificationNumber", VerificationNumber);

                command.Parameters.AddWithValue("@ADD_BY", AddedBy);
                command.Parameters.AddWithValue("@ADD_DATE", AddedOn);

                command.Parameters.AddWithValue("@Supervisor_sign", Supervisor_sign);

                command.Parameters.AddWithValue("@MODIFY_BY", ModifyBy);
                command.Parameters.AddWithValue("@MODIFY_DATE", ModifyOn);


                con.Open();
                i = command.ExecuteNonQuery();
                con.Close();
            }

        }
        catch
        {

        }

        try
        {
            using (SqlConnection con = new SqlConnection(oCmn.AppConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_CASE_TRANSACTION_LOG_InsertUpdateIDOCformat", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@CASE_ID", CaseID);
                command.Parameters.AddWithValue("@VERIFICATION_TYPE_ID", VerificationTypeId);

                command.Parameters.AddWithValue("@USER_ID", UserId);
                command.Parameters.AddWithValue("@TRANS_START", TransStart);

                command.Parameters.AddWithValue("@TRANS_END", TransEnd);
                command.Parameters.AddWithValue("@CENTRE_ID", CentreId);

                command.Parameters.AddWithValue("@PRODUCT_ID", ProductId);
                command.Parameters.AddWithValue("@CLIENT_ID", ClientId);


                if (IsVerificationComplete(CaseID) == "true")
                {
                    VerificationComplete(CaseID);
                    sRetVal += " Case verification data entry completed.";
                }

                con.Open();
                i = command.ExecuteNonQuery();
                con.Close();

            }

        }
        catch
        {

        }

        return sRetVal;


    }
    #endregion InsertUpdateIDOCformat()

    //---------------comp-----//









    //comment by kanchan on 23/9/2014

    ////#region GetVerifierID()
    ////public OleDbDataReader GetVerifierID(string sCaseId, string sVerifyType)
    ////{
    ////    string sSql = "";
    ////    sSql = "select FE_ID from CPV_IDOC_FE_CASE_MAPPING where case_id='" + sCaseId + "' " +
    ////         " And verification_type_id='" + sVerifyType + "'";

    ////    return OleDbHelper.ExecuteReader(oCmn.ConnectionString, CommandType.Text, sSql);
    ////}
    ////#endregion GetVerifierID()


    //add by:kanchan
    //add date:23/9/2014

    #region GetVerifierID()

    public DataSet GetVerifierID(string sCaseId, string sVerifyType)
    {

        SqlConnection con = new SqlConnection(oCmn.AppConnectionString);

        SqlCommand command = new SqlCommand("sp_VerificationView_GetVerifierID", con);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@case_id", sCaseId);
        command.Parameters.AddWithValue("@verification_type_id", sVerifyType);

        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = command;

        DataSet MyDs = new DataSet();
        sda.Fill(MyDs);

        con.Close();
        return MyDs;


    }
    #endregion GetVerifierID()
    //----comp----//

    //comment by kanchan on 23/9/2014

    ////public OleDbDataReader GetIdocVerification(string sCaseID, string sVerificationTypeID)
    ////{
    ////    OleDbConnection oledbConn = new OleDbConnection(oCmn.ConnectionString);
    ////    string sql = "select TOTAL_INCOME,Overwriting,Pan_correct,Tan_correcT,computation_correct," +
    ////    "Calculation_correct,Tax_cal_correct,Tax_payble_correct,OK_field_verification,IS_spelling_mistake," +
    ////    "Other_observation,Person_contacted,Cont_Designation_dept,APP_DESIGNATION,APP_DEPARTMENT," +
    ////    "APP_YEAR_IN_SERVICE,MONTH_INCOME,NO_of_Employee,TYPE_OF_INDUSTRY,ORGANIZATION_SEAL,AUTHORITY_SIGNATURE," +
    ////    "DOCUMENT_AS_PER_STANDARD,DATE_ON_DOC,AMOUNT_ON_DOC,APP_ADDRESS_CORRECT,BUSSINESS_ACTIVITY_SEEN,STOCK_SIGHTED," +
    ////    "NO_OF_EMP_SEEN,NAME_BOARD_SEEN,FE_REMARK,TELE_REMARK ,CASE_STATUS_ID,FE_VISIT_DATE,Gross_salary_Momthly_Annual_Income,Supervisor_sign from cpv_idoc_verification where CASE_ID=" + sCaseID + " and VERIFICATION_TYPE_ID=" + sVerificationTypeID;
    ////    return OleDbHelper.ExecuteReader(oledbConn, CommandType.Text, sql);

    ////}



    //add by: kanchan
    //add date:23/9/2014

    public DataSet GetIdocVerification(string sCaseID, string sVerificationTypeID)
    {

        SqlConnection con = new SqlConnection(oCmn.AppConnectionString);

        SqlCommand command = new SqlCommand("sp_IDOC_F16_GetIdocVerification", con);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@case_id", sCaseID);
        command.Parameters.AddWithValue("@verification_type_id", sVerificationTypeID);

        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = command;

        DataSet MyDs = new DataSet();
        sda.Fill(MyDs);

        con.Close();
        return MyDs;


    }
    //-----comp-----//

    //comment by kanchan on 23/9/2014

    ////public OleDbDataReader GetIdocVeriAttempt(string sCaseID, string sVerificationTypeID)
    ////{
    ////    OleDbConnection oledbConn = new OleDbConnection(oCmn.ConnectionString);
    ////    string sql = "select Attempt_date_time,TELEPHONE_NO,REMARK from CPV_IDOC_VERI_ATTEMPTS where case_id=" + sCaseID + " and verification_type_id=" + sVerificationTypeID;
    ////    return OleDbHelper.ExecuteReader(oledbConn, CommandType.Text, sql);

    ////}

    //add by:kanchan
    //add date:23/9/2014
    public DataSet GetIdocVeriAttempt(string sCaseID, string sVerificationTypeID)
    {

        SqlConnection con = new SqlConnection(oCmn.AppConnectionString);

        SqlCommand command = new SqlCommand("sp_IDOC_F16_GetIdocVeriAttempt", con);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@case_id", sCaseID);
        command.Parameters.AddWithValue("@verification_type_id", sVerificationTypeID);

        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = command;

        DataSet MyDs = new DataSet();
        sda.Fill(MyDs);

        con.Close();
        return MyDs;
    }


    //-----comp-----//

    //comment by kanchan on 23/9/2014

    ////public string UpdateIdocVerification(string sCaseID, string sVerificationTypeID)
    ////{ 
    ////    OleDbConnection sqlconn = new OleDbConnection(oCmn.ConnectionString);
    ////    sqlconn.Open();
    ////    string sRetVal = "";
    ////    OleDbTransaction sqlTrans = sqlconn.BeginTransaction();
    ////    try
    ////    {
    ////        string sSql = "update cpv_idoc_verification set TOTAL_INCOME=?,Overwriting=?,Pan_correct=?,Tan_correcT=?,computation_correct=?," +
    ////    "Calculation_correct=?,Tax_cal_correct=?,Tax_payble_correct=?,OK_field_verification=?,IS_spelling_mistake=?," +
    ////    "Other_observation=?,Person_contacted=?,Cont_Designation_dept=?,APP_DESIGNATION=?,APP_DEPARTMENT=?," +
    ////    "APP_YEAR_IN_SERVICE=?,MONTH_INCOME=?,NO_of_Employee=?,TYPE_OF_INDUSTRY=?,ORGANIZATION_SEAL=?,AUTHORITY_SIGNATURE=?," +
    ////    "DOCUMENT_AS_PER_STANDARD=?,DATE_ON_DOC=?,AMOUNT_ON_DOC=?,APP_ADDRESS_CORRECT=?,BUSSINESS_ACTIVITY_SEEN=?,STOCK_SIGHTED=?," +
    ////    "NO_OF_EMP_SEEN=?,NAME_BOARD_SEEN=?,FE_REMARK=?,TELE_REMARK=?,FE_VISIT_DATE=?,CASE_STATUS_ID=?,Gross_salary_Momthly_Annual_Income=?, "+
    ////    "MODIFY_BY=?,MODIFY_DATE=?,Supervisor_sign=?,AreaID=? " +
    ////    " where CASE_ID=" + sCaseID + " and VERIFICATION_TYPE_ID=" + sVerificationTypeID;

    ////        OleDbParameter[] ParamVerification = new OleDbParameter[38];
           
    ////        ParamVerification[0] = new OleDbParameter("@TOTAL_INCOME", OleDbType.Decimal, 9);
    ////        ParamVerification[0].Value = TotalIncome;
    ////        ParamVerification[1] = new OleDbParameter("@Overwriting", OleDbType.VarChar, 10);
    ////        ParamVerification[1].Value = OverWritingTempring;
    ////        ParamVerification[2] = new OleDbParameter("@Pan_correct", OleDbType.VarChar, 10);
    ////        ParamVerification[2].Value = PanCorrect;
    ////        ParamVerification[3] = new OleDbParameter("@Tan_correct", OleDbType.VarChar, 10);
    ////        ParamVerification[3].Value = TanCorrect;
    ////        ParamVerification[4] = new OleDbParameter("@computation_correct", OleDbType.VarChar, 10);
    ////        ParamVerification[4].Value = OverallComputationCorrect;
    ////        ParamVerification[5] = new OleDbParameter("@Calculation_correct", OleDbType.VarChar, 10);
    ////        ParamVerification[5].Value = IncomeCalculationCorrect;
    ////        ParamVerification[6] = new OleDbParameter("@Tax_cal_correct", OleDbType.VarChar, 10);
    ////        ParamVerification[6].Value = TaxCalculationCorrect;
    ////        ParamVerification[7] = new OleDbParameter("@Tax_payble_correct", OleDbType.VarChar, 10);
    ////        ParamVerification[7].Value = F16PaybleISCorrect;
    ////        ParamVerification[8] = new OleDbParameter("@OK_field_verification", OleDbType.VarChar, 10);
    ////        ParamVerification[8].Value = OkSendForVerification;
    ////        ParamVerification[9] = new OleDbParameter("@IS_spelling_mistake", OleDbType.VarChar, 10);
    ////        ParamVerification[9].Value = SpellMistake;
    ////        ParamVerification[10] = new OleDbParameter("@Other_observation", OleDbType.VarChar, 255);
    ////        ParamVerification[10].Value = OtherVerification;
    ////        ParamVerification[11] = new OleDbParameter("@Person_contacted", OleDbType.VarChar, 100);
    ////        ParamVerification[11].Value = NameOfPersonContacted;
    ////        ParamVerification[12] = new OleDbParameter("@Cont_Designation_dept", OleDbType.VarChar, 100);
    ////        ParamVerification[12].Value = Cont_DesignationDepartment;
    ////        ParamVerification[13] = new OleDbParameter("@APP_DESIGNATION", OleDbType.VarChar, 100);
    ////        ParamVerification[13].Value = ApplicantDesignation;
    ////        ParamVerification[14] = new OleDbParameter("@APP_DEPARTMENT", OleDbType.VarChar, 100);
    ////        ParamVerification[14].Value = ApplicationDepartment;
    ////        ParamVerification[15] = new OleDbParameter("@APP_YEAR_IN_SERVICE", OleDbType.Decimal, 9);
    ////        ParamVerification[15].Value = ApplicantYearService;
    ////        ParamVerification[16] = new OleDbParameter("@MONTH_INCOME", OleDbType.Decimal, 9);
    ////        ParamVerification[16].Value = ApplicantGrossAnnualMonthlyIncome;
    ////        ParamVerification[17] = new OleDbParameter("@NO_of_Employee", OleDbType.Numeric, 9);
    ////        ParamVerification[17].Value = NoEmployess;
    ////        ParamVerification[18] = new OleDbParameter("@TYPE_OF_INDUSTRY", OleDbType.VarChar, 100);
    ////        ParamVerification[18].Value = TypeOfOrg;
    ////        ParamVerification[19] = new OleDbParameter("@ORGANIZATION_SEAL", OleDbType.VarChar, 15);
    ////        ParamVerification[19].Value = SealOfOrg;
    ////        ParamVerification[20] = new OleDbParameter("@AUTHORITY_SIGNATURE", OleDbType.VarChar, 15);
    ////        ParamVerification[20].Value = SigOfIssAuth;
    ////        ParamVerification[21] = new OleDbParameter("@DOCUMENT_AS_PER_STANDARD", OleDbType.VarChar, 15);
    ////        ParamVerification[21].Value = StanForOrg;
    ////        ParamVerification[22] = new OleDbParameter("@DATE_ON_DOC", OleDbType.VarChar, 15);
    ////        ParamVerification[22].Value = DtSSSPSC;
    ////        ParamVerification[23] = new OleDbParameter("@AMOUNT_ON_DOC", OleDbType.VarChar, 15);
    ////        ParamVerification[23].Value = AmtSSSPSC;
    ////        ParamVerification[24] = new OleDbParameter("@APP_ADDRESS_CORRECT", OleDbType.VarChar, 15);
    ////        ParamVerification[24].Value = AppOffCorrect;
    ////        ParamVerification[25] = new OleDbParameter("@BUSSINESS_ACTIVITY_SEEN", OleDbType.VarChar, 10);
    ////        ParamVerification[25].Value = BusinessActivitySeen;
    ////        ParamVerification[26] = new OleDbParameter("@STOCK_SIGHTED", OleDbType.VarChar, 255);
    ////        ParamVerification[26].Value = Stock;
    ////        ParamVerification[27] = new OleDbParameter("@NO_OF_EMP_SEEN", OleDbType.VarChar, 10);
    ////        ParamVerification[27].Value = NumberOfEmployeeinOrg;
    ////        ParamVerification[28] = new OleDbParameter("@NAME_BOARD_SEEN", OleDbType.VarChar, 10);
    ////        ParamVerification[28].Value = NameBoard;
    ////        ParamVerification[29] = new OleDbParameter("@FE_REMARK", OleDbType.VarChar, 2000);
    ////        ParamVerification[29].Value = FERemarks;
    ////        ParamVerification[30] = new OleDbParameter("@TELE_REMARK", OleDbType.VarChar, 2000);
    ////        ParamVerification[30].Value = TeleRemarks;
    ////        ParamVerification[31] = new OleDbParameter("@FE_VISIT_DATE", OleDbType.VarChar, 255);
    ////        ParamVerification[31].Value = VeriDate;
    ////        ParamVerification[32] = new OleDbParameter("@CASE_STATUS_ID", OleDbType.VarChar, 255);
    ////        ParamVerification[32].Value = CaseStatusID;
    ////        ParamVerification[33] = new OleDbParameter("@Salary", OleDbType.VarChar, 50);
    ////        ParamVerification[33].Value = Salary;
    ////        ParamVerification[34] = new OleDbParameter("@ModifyBy", OleDbType.VarChar, 15);
    ////        ParamVerification[34].Value = ModifyBy;
    ////        ParamVerification[35] = new OleDbParameter("@ModifyOn", OleDbType.DBTimeStamp);
    ////        ParamVerification[35].Value = ModifyOn;
    ////        ParamVerification[36] = new OleDbParameter("@Supervisor_sign", OleDbType.VarChar, 255);
    ////        ParamVerification[36].Value = Supervisor_sign;
    ////        ParamVerification[37] = new OleDbParameter("@AreaID", OleDbType.VarChar, 255);
    ////        ParamVerification[37].Value = AreaID;

    ////        OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql, ParamVerification);

    ////        //////add by santosh shelar///////////////////////
          
    ////        sSql = "";
    ////        sSql = "Insert into CASE_TRANSACTION_LOG(CASE_ID,VERIFICATION_TYPE_ID,USER_ID,TRANS_START,TRANS_END," +
    ////             "CENTRE_ID,PRODUCT_ID,CLIENT_ID) VALUES(?,?,?,?,?,?,?,?)";

    ////        OleDbParameter[] paramTransLog = new OleDbParameter[8];
    ////        paramTransLog[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
    ////        paramTransLog[0].Value = CaseID;
    ////        paramTransLog[1] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar, 15);
    ////        paramTransLog[1].Value = VerificationTypeId;
    ////        paramTransLog[2] = new OleDbParameter("@UserId", OleDbType.VarChar, 15);
    ////        paramTransLog[2].Value = UserId;
    ////        paramTransLog[3] = new OleDbParameter("@TransStart", OleDbType.DBTimeStamp);
    ////        paramTransLog[3].Value = TransStart;
    ////        paramTransLog[4] = new OleDbParameter("@TransEnd", OleDbType.DBTimeStamp);
    ////        paramTransLog[4].Value = TransEnd;
    ////        paramTransLog[5] = new OleDbParameter("@CentreId", OleDbType.VarChar, 15);
    ////        paramTransLog[5].Value = CentreId;
    ////        paramTransLog[6] = new OleDbParameter("@ProductId", OleDbType.VarChar, 15);
    ////        paramTransLog[6].Value = ProductId;
    ////        paramTransLog[7] = new OleDbParameter("@ClientId", OleDbType.VarChar, 15);
    ////        paramTransLog[7].Value = ClientId;

    ////        OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql, paramTransLog);

    ////        //End  Insert into CASE_TRANSACTION_LOG --------------------
    ////        if (IsVerificationComplete(sqlTrans, CaseID) == "true")
    ////        {
    ////            VerificationComplete(sqlTrans, CaseID);
    ////            sRetVal += " Case verification data entry completed.";
    ////        }
    ////        /////
    ////        sqlTrans.Commit();
    ////        sqlconn.Close();

    ////    }
    ////    catch (Exception ex)
    ////    {
    ////        sqlTrans.Rollback();
    ////        sqlconn.Close();
    ////        throw new Exception("Error while updating Verrification " + ex.Message);
    ////    }
    ////    return sRetVal;
    ////}


    // add by :kanchan 
    //add date:23/9/2014

    public string UpdateIdocVerification(string sCaseID, string sVerificationTypeID)// diss done
    {
        string sRetVal = "";


        //---------------------------------------------10/9/2014--------------------------------------------

        try
        {
            using (SqlConnection con = new SqlConnection(oCmn.AppConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_IDOC_F16_UpdateIdocVerification1", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@TOTAL_INCOME", TotalIncome);
                command.Parameters.AddWithValue("@Overwriting", OverWritingTempring);
                //  command.Parameters.AddWithValue("@Overwriting", OverWritingTempring);
                command.Parameters.AddWithValue("@Pan_correct", PanCorrect);
                command.Parameters.AddWithValue("@Tan_correcT", TanCorrect);
                command.Parameters.AddWithValue("@computation_correct", OverallComputationCorrect);

                command.Parameters.AddWithValue("@Calculation_correct", IncomeCalculationCorrect);
                command.Parameters.AddWithValue("@Tax_cal_correct", TaxCalculationCorrect);
                command.Parameters.AddWithValue("@Tax_payble_correct", F16PaybleISCorrect);
                command.Parameters.AddWithValue("@OK_field_verification", OkSendForVerification);
                command.Parameters.AddWithValue("@IS_spelling_mistake", SpellMistake);

                command.Parameters.AddWithValue("@Other_observation", OtherVerification);
                command.Parameters.AddWithValue("@Person_contacted", NameOfPersonContacted);
                command.Parameters.AddWithValue("@Cont_Designation_dept", Cont_DesignationDepartment);
                command.Parameters.AddWithValue("@APP_DESIGNATION", ApplicantDesignation);
                command.Parameters.AddWithValue("@APP_DEPARTMENT", ApplicationDepartment);

                command.Parameters.AddWithValue("@APP_YEAR_IN_SERVICE", ApplicantYearService);
                command.Parameters.AddWithValue("@MONTH_INCOME", ApplicantGrossAnnualMonthlyIncome);
                command.Parameters.AddWithValue("@NO_of_Employee", NoEmployess);
                command.Parameters.AddWithValue("@TYPE_OF_INDUSTRY", TypeOfOrg);
                command.Parameters.AddWithValue("@ORGANIZATION_SEAL", SealOfOrg);

                command.Parameters.AddWithValue("@AUTHORITY_SIGNATURE", SigOfIssAuth);
                command.Parameters.AddWithValue("@DOCUMENT_AS_PER_STANDARD", StanForOrg);
                command.Parameters.AddWithValue("@DATE_ON_DOC", DtSSSPSC);
                command.Parameters.AddWithValue("@AMOUNT_ON_DOC", AmtSSSPSC);
                command.Parameters.AddWithValue("@APP_ADDRESS_CORRECT", AppOffCorrect);

                command.Parameters.AddWithValue("@BUSSINESS_ACTIVITY_SEEN", BusinessActivitySeen);
                command.Parameters.AddWithValue("@STOCK_SIGHTED", Stock);
                command.Parameters.AddWithValue("@NO_OF_EMP_SEEN", NumberOfEmployeeinOrg);
                command.Parameters.AddWithValue("@NAME_BOARD_SEEN", NameBoard);
                command.Parameters.AddWithValue("@FE_REMARK", FERemarks);

                command.Parameters.AddWithValue("@TELE_REMARK", TeleRemarks);
                command.Parameters.AddWithValue("@FE_VISIT_DATE", VeriDate);
                command.Parameters.AddWithValue("@CASE_STATUS_ID", CaseStatusID);
                command.Parameters.AddWithValue("@Gross_salary_Momthly_Annual_Income", Salary);
                command.Parameters.AddWithValue("@MODIFY_BY", ModifyBy);

                command.Parameters.AddWithValue("@MODIFY_DATE", ModifyOn);
                command.Parameters.AddWithValue("@Supervisor_sign", Supervisor_sign);
                command.Parameters.AddWithValue("@AreaID", AreaID);

                command.Parameters.AddWithValue("@CASE_ID", sCaseID);

                command.Parameters.AddWithValue("@VERIFICATION_TYPE_ID", sVerificationTypeID);


                con.Open();
                int i = command.ExecuteNonQuery();
                con.Close();
            }







            using (SqlConnection con = new SqlConnection(oCmn.AppConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_IDOC_F16_InsertIDocForm16_insert2", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@CASE_ID", CaseID);
                command.Parameters.AddWithValue("@VERIFICATION_TYPE_ID", VerificationTypeId);
                command.Parameters.AddWithValue("@USER_ID", UserId);
                command.Parameters.AddWithValue("@TRANS_START", TransStart);
                command.Parameters.AddWithValue("@TRANS_END", TransEnd);
                command.Parameters.AddWithValue("@CENTRE_ID", CentreId);
                command.Parameters.AddWithValue("@PRODUCT_ID", ProductId);
                command.Parameters.AddWithValue("@CLIENT_ID", ClientId);

                con.Open();
                int i = command.ExecuteNonQuery();
                con.Close();
            }




            if (IsVerificationComplete(CaseID) == "true")
            {
                //kanchan 23/9/2014
                VerificationComplete(CaseID);
                sRetVal += " Case verification data entry completed.";
            }




        }

        catch (Exception ex)
        {

            throw new Exception("Error while updating Verrification " + ex.Message);
        }
        return sRetVal;
    }

    //----comp---//


    //comment by kanchan on 23/9/2014
    ////public void updateVeriAttempt(string sCaseID, string sVerificationTypeID)
    ////{
    ////    OleDbConnection sqlconn = new OleDbConnection(oCmn.ConnectionString);

    ////    sqlconn.Open();
      
    ////    OleDbTransaction sqlTrans = sqlconn.BeginTransaction();
    ////    try
    ////    {
    ////        string sSql = "delete from  CPV_IDOC_VERI_ATTEMPTS where  case_id=" + sCaseID + " and   verification_type_id=" + sVerificationTypeID;
            
           
    ////        OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql);
    ////        sqlTrans.Commit();
    ////        sqlconn.Close();
    ////    }
    ////    catch (Exception ex)
    ////    {
    ////        sqlTrans.Rollback();
    ////        sqlconn.Close();
    ////        throw new Exception("Error while updating VerrificationAttempt " + ex.Message);
    ////    }
    ////}

    //add by kanchan
    //add date:23/9/2014
    public void updateVeriAttempt(string sCaseID, string sVerificationTypeID)
    {

        try
        {
            SqlConnection con = new SqlConnection(oCmn.AppConnectionString);

            SqlCommand command = new SqlCommand("sp_IDOC_F16_updateVeriAttempt", con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@case_id", sCaseID);
            command.Parameters.AddWithValue("@verification_type_id", sVerificationTypeID);

            con.Open();
            int i = command.ExecuteNonQuery();
            con.Close();


        }
        catch
        {

        }
    }
   

 

    //-----comp----//

    //comment by kanchan on 23/9/2014
    ////public object getveriAttemptRecord(string sCaseID1, string sAttempDateTime1, string sVerificationTypeId1, string sTellNo1, string sTellPhoneRemark1)
    ////{
    ////    OleDbConnection sqlconn = new OleDbConnection(oCmn.ConnectionString);

    ////    sqlconn.Open();
    ////    string sSql = "select count(*) from CPV_IDOC_VERI_ATTEMPTS where case_id=" + sCaseID1 + " and verification_type_id=" + sVerificationTypeId1 + " and ATTEMPT_DATE_TIME ='" + sAttempDateTime1 + "' and TELEPHONE_NO='" + sTellNo1 + "' and REMARK='" + sTellPhoneRemark1 + "' ";
    ////   return( OleDbHelper.ExecuteScalar(sqlconn, CommandType.Text, sSql));
    ////}

    //Add by :kanchan
    //Add Date : 23/09/2014

    public DataSet getveriAttemptRecord(string sCaseID1, string sAttempDateTime1, string sVerificationTypeId1, string sTellNo1, string sTellPhoneRemark1)// diss done
    {


        SqlConnection con = new SqlConnection(oCmn.AppConnectionString);

        SqlCommand command = new SqlCommand("sp_IDOC_F16_getveriAttemptRecord", con);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@case_id", sCaseID1);
        command.Parameters.AddWithValue("@verification_type_id", sVerificationTypeId1);
        command.Parameters.AddWithValue("@ATTEMPT_DATE_TIME", sAttempDateTime1);
        command.Parameters.AddWithValue("@TELEPHONE_NO", sTellNo1);
        command.Parameters.AddWithValue("@REMARK", sTellPhoneRemark1);

        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = command;

        DataSet MyDs = new DataSet();
        sda.Fill(MyDs);

        con.Close();

        return MyDs;

    }

    //-----comp----//

    //comment by kanchan on 23/9/2014

    ////#region IsVerificationComplete
    
    ////public string IsVerificationComplete(OleDbTransaction oledbTrans, string sCaseId)
    ////{
    ////    string sSql = "";
    ////    OleDbDataReader oledbRead;
    ////    string bComplete = "";
    ////    sSql = " Select case (select count(*) from CPV_IDOC_VERIFICATION_TYPE " +
    ////          " where case_id='" + sCaseId + "') " +
    ////          " when (select count(*) from (select distinct verification_type_id from " +
    ////          " IDOC_IODC_CASE_OUTPUT_VW where case_id='" + sCaseId + "') AS A )" +
    ////          " then 'true' else 'false' end as IsComplete";

    ////    oledbRead = OleDbHelper.ExecuteReader(oledbTrans, CommandType.Text, sSql);
    ////    if (oledbRead.Read() == true)
    ////        bComplete = oledbRead["IsComplete"].ToString();

    ////    return bComplete;
    ////}

    ////#endregion IsVerificationComplete

    ////#region VerificationComplete after completing verification IS_CASE_COMPLETE='Y'
    ////public void VerificationComplete(OleDbTransaction oledbTrans, string sCaseId)
    ////{
    ////    string sSql = "";
    ////    sSql = "Update CPV_IDOC_CASE_DETAILS SET IS_CASE_COMPLETE='Y' WHERE CASE_ID='" + sCaseId + "'";
    ////    OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);
    ////}
    ////#endregion VerificationComplete


//----------------------------------------------------------------------------------------------------------------

    //add by:kanchan 
    //add date:23/9/2014
   
    //sp_name:sp_CIDocVerification_IsVerificationComplete

    public string IsVerificationComplete(string sCaseId)
    {
        string bComplete = "";
        try
        {
            SqlConnection con;
            DataSet MyDataSet = new DataSet();
            SqlDataAdapter My_SQLDataAdapter = new SqlDataAdapter();
            con = new SqlConnection(oCmn.AppConnectionString);
            con.Open();
            SqlCommand command = new SqlCommand("sp_CIDocVerification_IsVerificationComplete", con);
            command.CommandType = CommandType.StoredProcedure;
            My_SQLDataAdapter.SelectCommand = command;

            command.Parameters.AddWithValue("@CASE_ID", sCaseId);
            My_SQLDataAdapter.Fill(MyDataSet);


            int count = MyDataSet.Tables[0].Rows.Count;


            if (count > 0)
            {
                bComplete = MyDataSet.Tables[0].Rows[0]["IsComplete"].ToString();
            }
            con.Close();

        }
        catch
        {

        }


        return bComplete;



    }

    public void VerificationComplete(string sCaseId)
    {

        try
        {

            using (SqlConnection con = new SqlConnection(oCmn.AppConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_VerificationComplete", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@CASE_ID", sCaseId);


                con.Open();
                int i = command.ExecuteNonQuery();
                con.Close();
            }

        }
        catch
        {

        }

    }


 
    //-----comp----//

    //ADD BY : Akanksha 
    //Finacial

    public string insertdatafinacial()
    {

        Int32 i = 0;
        string sMsg = "";
        try
        {

            using (SqlConnection con = new SqlConnection(oCmn.AppConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_finacial_insertdata_28Nov", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@CASE_ID", CaseID1);
                command.Parameters.AddWithValue("@VERIFICATION_TYPE_ID", VerificationTypeid);

                command.Parameters.AddWithValue("@FE_VISIT_DATE", VeriDate1);
                command.Parameters.AddWithValue("@CASE_STATUS_ID", CaseStatusID1);

                command.Parameters.AddWithValue("@FE_REMARK", finFERemarks);
                command.Parameters.AddWithValue("@MODIFY_BY", ModifyBy1);

                command.Parameters.AddWithValue("@MODIFY_DATE", ModifyOn1);
                command.Parameters.AddWithValue("@Supervisor_sign", Supervisor_sign1);

                command.Parameters.AddWithValue("@ADD_BY", AddedBy1);
                command.Parameters.AddWithValue("@ADD_DATE", AddedOn1);

                command.Parameters.AddWithValue("@AreaID", AreaID);
                command.Parameters.AddWithValue("@Applicant_name", txtAppName);

                command.Parameters.AddWithValue("@CPA_ref_no", txtCPARefNo);
                command.Parameters.AddWithValue("@bank_ref_no", txtbankrefno);

                command.Parameters.AddWithValue("@clientname", txtclientname);

                command.Parameters.AddWithValue("@productname", txtprodname);
                command.Parameters.AddWithValue("@totalsales", txttotsale);

                command.Parameters.AddWithValue("@totalcapital", txttotcap);
                command.Parameters.AddWithValue("@totalfixedasset", txtfixass);

                command.Parameters.AddWithValue("@totaldebtoramt", txtdebt);
                command.Parameters.AddWithValue("@totalcreditoramt", txtcreditor);

                command.Parameters.AddWithValue("@totalclosingstamt", txtclos);
                command.Parameters.AddWithValue("@totaladepamt", txtdep);

                command.Parameters.AddWithValue("@totalnetprofit", txtnetprof);
                command.Parameters.AddWithValue("@panno_fincial", txtpanno);

                command.Parameters.AddWithValue("@whetherfieldveri", txtwhether);

                command.Parameters.AddWithValue("@verification_donein", ddverification);
                command.Parameters.AddWithValue("@finalstatus", ddstatus);

                command.Parameters.AddWithValue("@Remark", Remark_new);
                command.Parameters.AddWithValue("@assyear", txtassyear);
                //---------add by manswini----
                command.Parameters.AddWithValue("@city_limy",city_limy);
                //----------comp--------


                con.Open();
                i = command.ExecuteNonQuery();
                con.Close();
            }

        }
        catch
        {

        }


        //--------------------------------comp-----------------------   


        // Add by :Akanksha 30/10/2014


        try
        {
            using (SqlConnection con = new SqlConnection(oCmn.AppConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_CASE_TRANSACTION_LOG_finacial", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@CASE_ID", CaseID1);
                command.Parameters.AddWithValue("@VERIFICATION_TYPE_ID", VerificationTypeid);

                command.Parameters.AddWithValue("@USER_ID", UserId);
                command.Parameters.AddWithValue("@TRANS_START", TransStart);

                command.Parameters.AddWithValue("@TRANS_END", TransEnd);
                command.Parameters.AddWithValue("@CENTRE_ID", CentreId);

                command.Parameters.AddWithValue("@PRODUCT_ID", ProductId);
                command.Parameters.AddWithValue("@CLIENT_ID", ClientId);

                if (IsVerificationComplete(CaseID1) == "true")
                {
                    VerificationComplete(CaseID1);
                    sMsg += " Case verification data entry completed.";
                }

            



                con.Open();
                i = command.ExecuteNonQuery();
                con.Close();

            }

        }
        catch
        {

        }

        return sMsg;

    }

    //-----comp---//
    

}
