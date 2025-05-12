using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Data.OleDb;
using System.Collections;
using System.IO;
using System.Data.SqlClient;


public class BGC
{
    private CCommon objCon;
    String strDate;
	
	public BGC()
	{
		 objCon = new CCommon();
         strDate = System.DateTime.Now.ToString();
	}
    private string strtodate;
    private string strfromdate;
    private string sCenterId;
    private string sClientId;
    private String strVerificationType;
    public String[] arrCaseID;
    private String strAssignedTo;
    private String strAssignedBy;
    private string strClinetId;
    private string sCaseID;
    private string sVerificationDateTime;
    private string sNameOfPersonContacted;
    private string sRespondentDesignation;
    private string sInstitutionName;
    private string sEmployeeDates;
    private string sDatesAttented;
    private string sQualificationGained;
    private string sOrganisationName;
    private string sLastposition;
    private string sReportingManager;
    private string sGapIdentified;
    private string sPeriodOfGap;
    private string sReasonOfGap;
    private string sAddressDuringGap;
    private string spoliceVerificationGap;
    private string sPoliceVerification;
    private string sTelephoneno1;
    private string sNumberOfYear;
    private string sResidenceType;
    private string sLandmark;
    private string sAccessbility;
    private string sFamilyMember;
    private string sRelationshipToEmp;
    private string spermanentAdd;
    private string sPreviousJobDetail;
    private string sLocality;
    private string sNeighbourName;
    private string sNeighbourFeedbackOnEmp;
    private string sTelephone2;
    private string sRemark;
    private string sStatus;
    private string sMarritalStatus;
    private string sApplicantAge;
    private DateTime dtTransStart;
    private DateTime dtTransEnd;
    private string sProductId;
    private string sRelatioship;
    private string sOccupation;
    private string strcaseid;
    private string strSendDate;
    private string strSendTime;
    private string strSendTimeType;
    private string strtathrs;
    private string strActivity_ID;
    private string strProduct_ID;
    private string strClient_ID;
    private string strVerification_Type_ID;
    private string strcentre_id;

    public string Centre_Id
    {
        get { return strcentre_id; }
        set { strcentre_id = value; }
    }
    public string Verification_Type_ID
    {
        get { return strVerification_Type_ID; }
        set { strVerification_Type_ID = value; }
    }

    public string Client_ID
    {
        get { return strClient_ID; }
        set { strClient_ID = value; }
    }
    public string Product_ID
    {
        get { return strProduct_ID; }
        set { strProduct_ID = value; }
    }
    public string Activity_ID
    {
        get { return strActivity_ID; }
        set { strActivity_ID = value; }
    }
    public string Todate
    {
        get { return strtodate; }
        set { strtodate = value; }
    }
    public string Fromdate
    {
        get { return strfromdate; }
        set { strfromdate = value; }
    }
    public string TATHRS
    {
        get { return strtathrs; }
        set { strtathrs = value; }
    }
    public string SendTimeType
    {
        get { return strSendTimeType; }
        set { strSendTimeType = value; }
    }
    public string SendTime
    {
        get { return strSendTime; }
        set { strSendTime = value; }
    }
    public string SendDate
    {
        get { return strSendDate; }
        set { strSendDate = value; }
    }
    public string CaseId
    {
        get { return strcaseid; }
        set { strcaseid = value; }
    }

    public string Occupation
    {
        get { return sOccupation; }
        set { sOccupation = value; }
    }

    public string Relationship
    {
        get { return sRelatioship; }
        set { sRelatioship = value; }
    }
    public string ProductId
    {
        get { return sProductId; }
        set { sProductId = value; }
    }
    public DateTime TransEnd
    {
        get { return dtTransEnd; }
        set { dtTransEnd = value; }
    }
    public DateTime TransStart
    {
        get { return dtTransStart; }
        set { dtTransStart = value; }
    }
    //add by kanchan

    private string strErrorLog;
    public string ErrorLog
    {
        get { return strErrorLog; }
        set { strErrorLog = value; }
    }

    private string strErrorRemark;
    public string ErrorRemark
    {
        get { return strErrorRemark; }
        set { strErrorRemark = value; }
    }



    private Object sFileUpload1;
    public Object FileUpload1
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
    private Array sFileUpload2;
    public Array FileUpload2
    {
        get
        {
            return sFileUpload2;
        }
        set
        {
            sFileUpload2 = value;
        }

    }
    private Array sFileUpload3;
    public Array FileUpload3
    {
        get
        {
            return sFileUpload3;
        }
        set
        {
            sFileUpload3 = value;
        }

    }
    private Array sFileUpload4;
    public Array FileUpload4
    {
        get
        {
            return sFileUpload4;
        }
        set
        {
            sFileUpload4 = value;
        }

    }
    private Array sFileUpload5;
    public Array FileUpload5
    {
        get
        {
            return sFileUpload5;
        }
        set
        {
            sFileUpload5 = value;
        }

    }



    //-------comp-----//
    private string sUserId;
    public string UserId
    {
        get { return sUserId; }
        set { sUserId = value; }
    }

    public string ApplicantAge
    {
        get { return sApplicantAge; }
        set { sApplicantAge = value; }
    }

    public string MarritalStatus
    {
        get { return sMarritalStatus; }
        set { sMarritalStatus = value; }
    }
    public string Status
    {
        get { return sStatus; }
        set { sStatus = value; }
    }
    public string Remark
    {
        get { return sRemark; }
        set { sRemark = value; }
    }

    public string TelephoneNo2
    {
        get { return sTelephone2; }
        set { sTelephone2 = value; }
    }
    public string NeighbourName
    {
        get { return sNeighbourName; }
        set { sNeighbourName = value; }
    }
    public string NeighbourFeedBackOfEmp
    {
        get { return sNeighbourFeedbackOnEmp; }
        set { sNeighbourFeedbackOnEmp = value; }
    }

    public string previosJobDetail
    {
        get { return sPreviousJobDetail; }
        set { sPreviousJobDetail = value; }
    }
    public string Locality
    {
        get { return sLocality; }
        set { sLocality = value; }
    }
    public string PemanentAdd
    {
        get { return spermanentAdd; }
        set { spermanentAdd = value; }
    }
    public string RelationshipToEmp
    {
        get { return sRelationshipToEmp; }
        set { sRelationshipToEmp = value; }
    }
    public string Accessbility
    {
        get { return sAccessbility; }
        set { sAccessbility = value; }
    }
    public string FamilyMember
    {
        get { return sFamilyMember; }
        set { sFamilyMember = value; }
    }

    public string ResidenceType
    {
        get { return sResidenceType; }
        set { sResidenceType = value; }
    }
    public string LandMark
    {
        get { return sLandmark; }
        set { sLandmark = value; }
    }

    public string TelephoneNo1
    {
        get { return sTelephoneno1; }
        set { sTelephoneno1 = value; }
    }
    public string NumberOfYear
    {
        get { return sNumberOfYear; }
        set { sNumberOfYear = value; }
    }

    public string policaVerification
    {
        get { return sPoliceVerification; }
        set { sPoliceVerification = value; }
    }
    public string policaVerificationGap
    {
        get { return spoliceVerificationGap; }
        set { spoliceVerificationGap = value; }
    }
    public string AddressDuringGap
    {
        get { return sAddressDuringGap; }
        set { sAddressDuringGap = value; }
    }
    public string ReasoinOfGap
    {
        get { return sReasonOfGap; }
        set { sReasonOfGap = value; }
    }
    public string PeriodOfGap
    {
        get { return sPeriodOfGap; }
        set { sPeriodOfGap = value; }
    }

    public string GapIdentified
    {
        get { return sGapIdentified; }
        set { sGapIdentified = value; }
    }

    public string ReportingManager
    {
        get { return sReportingManager; }
        set { sReportingManager = value; }
    }
    public string LastPosition
    {
        get { return sLastposition; }
        set { sLastposition = value; }
    }
    public string OrganisationName
    {
        get { return sOrganisationName; }
        set { sOrganisationName = value; }
    }
    public string QualificationGained
    {
        get { return sQualificationGained; }
        set { sQualificationGained = value; }
    }
    public string DatesAttended
    {
        get { return sDatesAttented; }
        set { sDatesAttented = value; }
    }
    public string EmployeeDates
    {
        get { return sEmployeeDates; }
        set { sEmployeeDates = value; }
    }
    public string InstitutionName
    {
        get { return sInstitutionName; }
        set { sInstitutionName = value; }
    }
    public string RespondentDesignation
    {
        get { return sRespondentDesignation; }
        set { sRespondentDesignation = value; }
    }
    public string NameOfPersonContated
    {
        get { return sNameOfPersonContacted; }
        set { sNameOfPersonContacted = value; }
    }
    public string VerificationDateTime
    {
        get { return sVerificationDateTime; }
        set { sVerificationDateTime = value; }
    }
    public string CaseID
    {
        get { return sCaseID; }
        set { sCaseID = value; }
    }

    public string AssignedBy
    {
        get { return strAssignedBy; }
        set { strAssignedBy = value; }
    }
    public string CentreId
    {
        get { return sCenterId; }
        set { sCenterId = value; }
    }
    public string ClientId
    {
        get { return sClientId; }
        set { sClientId = value; }
    }

    public string VerificationType
    {
        get { return strVerificationType; }
        set { strVerificationType = value; }
    }

    public string AssignedTo
    {
        get { return strAssignedTo; }
        set { strAssignedTo = value; }
    }

    //---------------------------------------------------------Verificationview  Page code-----------------------------------------------//
    public string GetUniqueIDBGC(string sTableNm, string sPrefix, string strCentreName)
    {
        Int32 iUniqueId = 0;
        int d = 0;
        SqlConnection con = new SqlConnection(objCon.AppConnectionString);

        SqlCommand command = new SqlCommand("sp_GetUniqueIDBGC11", con);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@table_name", sTableNm);
        command.Parameters.AddWithValue("@prefix", sPrefix);
        command.Parameters.AddWithValue("@centre_name", strCentreName);

        con.Open();

        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = command;

        DataSet MyDataSet = new DataSet();
        sda.Fill(MyDataSet);

        con.Close();

        iUniqueId = Convert.ToInt32(MyDataSet.Tables[0].Rows[0]["Last_id"].ToString());



        return sPrefix + iUniqueId;

    }


    //public string GetUniqueIDBGC(string sTableNm, string sPrefix,string strCentreName)
    //{
    //    Int32 iUniqueId = 0;
    //    int d = 0;
    //    SqlConnection con = new SqlConnection(objCon.AppConnectionString);

    //    SqlCommand command = new SqlCommand("sp_GetUniqueIDBGC", con);
    //    command.CommandType = CommandType.StoredProcedure;

    //    command.Parameters.AddWithValue("@table_name", sTableNm);
    //    command.Parameters.AddWithValue("@prefix", sPrefix);
    //    command.Parameters.AddWithValue("@centre_name", strCentreName);

    //    con.Open();

    //    //o1 = command.ExecuteScalar();

    //    SqlDataAdapter sda = new SqlDataAdapter();
    //    sda.SelectCommand = command;

    //    DataSet MyDataSet = new DataSet();
    //    sda.Fill(MyDataSet);

    //    con.Close();
    //    if (MyDataSet.Tables[0].Rows.Count > 0)
    //    {
    //        iUniqueId = Convert.ToInt32(MyDataSet.Tables[0].Rows[0]["Last_id"].ToString());
    //        d = iUniqueId + 1;
    //    }

    //    else
    //    {
    //        int i;
    //        SqlConnection con1 = new SqlConnection(objCon.AppConnectionString);

    //        SqlCommand command1 = new SqlCommand("sp_cc_InsertIDOCCaseEntry_GetUniqueIDInsert", con1);
    //        command1.CommandType = CommandType.StoredProcedure;

    //        command1.Parameters.AddWithValue("@table_name", sTableNm);
    //        command1.Parameters.AddWithValue("@prefix", sPrefix);
    //        con1.Open();
    //        i = command1.ExecuteNonQuery();
    //        con1.Close();
    //        iUniqueId = 1;
    //    }

    //    SqlConnection con2 = new SqlConnection(objCon.AppConnectionString);

    //    //SqlCommand command2 = new SqlCommand("sp_cc_InsertIDOCCaseEntry_GetUniqueIDUpdate", con2);
    //    SqlCommand command2 = new SqlCommand("sp_cc_InsertIDOCCaseEntry_GetUniqueIDUpdate11", con2);
    //    command2.CommandType = CommandType.StoredProcedure;

    //    //command2.Parameters.AddWithValue("@Last_id", iUniqueId + 1);
    //    command2.Parameters.AddWithValue("@Last_id", d);
    //    command2.Parameters.AddWithValue("@table_name", sTableNm);
    //    command2.Parameters.AddWithValue("@prefix", sPrefix);
    //    command2.Parameters.AddWithValue("@centre_name", strCentreName);
    //    con2.Open();
    //    int i2 = command2.ExecuteNonQuery();
    //    con2.Close();

    //    return sPrefix + d;

    //}
    public DataSet GetVerificationDetailBGC(string sCaseId, string sClientId, string sCentreId)
    {


        SqlConnection con = new SqlConnection(objCon.AppConnectionString);

        SqlCommand command = new SqlCommand("sp_GetVerificationDetailBGC", con);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@case_id",sCaseId);
        command.Parameters.AddWithValue("@Client_ID",sClientId);
        command.Parameters.AddWithValue("@Centre_Id", sCentreId);

        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = command;
        DataSet MyDataSet = new DataSet();

        sda.Fill(MyDataSet);

        con.Close();


        return MyDataSet;
    }

    //sp done
    ////public OleDbDataReader GetVerifierIDBGC(string sCaseId)
    ////{
    ////    string sSql = "";
    ////    sSql = "select FE_ID from CPV_EBC_FE_MAPPING where case_id='" + sCaseId + "' ";


    ////    return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    ////}

    public DataSet GetVerifierIDBGC(string sCaseId)
    {


        SqlConnection con = new SqlConnection(objCon.AppConnectionString);

        SqlCommand command = new SqlCommand("sp_GetVerifierIDBGC", con);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@case_id", sCaseId);   

        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = command;
        DataSet MyDataSet = new DataSet();

        sda.Fill(MyDataSet);

        con.Close();

        return MyDataSet;
    }



    //------------------------------------------------------comp------------------------------------------------------------//





        //---------------------------------------------------------Case view  Page code-----------------------------------------------//

    //not done sp
    public string GetEBCCaseEntry(string sRefNo, string sName, bool bChecked, string sFrom, string sTo)
    {
        string sSql = "";
        string FromDate = "";
        string ToDate = "";
        sSql = "Select Case_ID,Ref_No,Case_Rec_dateTime,Title,(First_Name+ ' '+Middle_Name+ ' '+Last_Name) as Name,DOB,ADD_LINE_1," +
               " ADD_LINE_2,ADD_LINE_3,City,Pin_code,Phone1,Phone2,Emp_Code,Location,Emp_code " +
               "DATE_OF_JOINING,LOCATION,DESIGNATION,FATHER_NAME,STAFF_NAME, " +
               "Previous_Employer_Name,Previous_Employer_Address,Previous_Designation,Reference_Name_Number,Project " +
               " from CPV_EBC_CASE_DETAILS WHERE  Centre_id='" + CentreId + "' AND Client_id='" + ClientId + "' AND SEND_DATETIME IS NULL";

        if (sRefNo != "")
        {
            sSql += " AND Ref_No LIKE '%" + objCon.FixQuotes(sRefNo) + "%'";
        }

        if (sName != "")
        {
            if (bChecked == true)
            {
                sSql += " and ((ISNULL(First_Name,'')+ ' '+ ISNULL(Middle_Name,'')+ ' '+ISNULL(Last_Name,'')) ='" + objCon.FixQuotes(sName) + "')";
            }
            else
            {
                sSql += " and ((ISNULL(First_Name,'')+ ' '+ ISNULL(Middle_Name,'')+ ' '+ISNULL(Last_Name,'')) LIKE '%" + objCon.FixQuotes(sName) + "%')";
            }
        }

       
        if (sFrom != "" && sTo != "")
        {
            FromDate = Convert.ToDateTime(objCon.strDate(sFrom)).ToString("dd-MMM-yyyy");
            
            ToDate = Convert.ToDateTime(objCon.strDate(sTo)).AddDays(1.0).ToString("dd-MMM-yyyy");
        }
        if (FromDate != "" && ToDate != "")
            sSql += " AND (Case_Rec_dateTime >='" + objCon.FixQuotes(FromDate) + "'" + "and Case_Rec_dateTime<'" + objCon.FixQuotes(ToDate) + "')";

        sSql += " ORDER BY CASE_ID DESC";
        return sSql;
        return sSql;
    }

    //sp done
    ////public Int32 DeleteEBCaseEntry(string sCaseID)
    ////{
    ////    OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
    ////    oledbConn.Open();
    ////    OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
    ////    Int32 nretVal = 0;
    ////    string sSql = "";
    ////    try
    ////    {
    ////        sSql = "Delete from CPV_EBC_CASE_DETAILS WHERE Case_ID='" + sCaseID + "'";
    ////        nretVal = OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);

    ////        oledbTrans.Commit();
    ////        oledbConn.Close();

    ////        return nretVal;
    ////    }
    ////    catch (Exception ex)
    ////    {
    ////        oledbTrans.Rollback();
    ////        oledbConn.Close();
    ////        throw new Exception("Error while deleting CaseEBCEntry " + ex.Message);
    ////    }

    ////}

    public Int32 DeleteEBCaseEntry(string sCaseID)
    {
        Int32 nretVal = 0;
        try
        {
            SqlConnection con = new SqlConnection(objCon.AppConnectionString);

            SqlCommand command = new SqlCommand("sp_DeleteEBCaseEntryBGC", con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Case_ID", sCaseID);

            con.Open();
            nretVal = command.ExecuteNonQuery();
            con.Close();
            return nretVal;
        }
         catch (Exception ex)
        {            
            throw new Exception("Error while deleting CaseEBCEntry " + ex.Message);
        }
        
    }







    //sp done
    ////public string GetEBCCaseEntry()
    ////{
    ////    string sSql = "";

    ////    sSql = "Select Case_ID,Ref_No,Case_Rec_dateTime,Title,First_Name,Middle_Name,Last_Name, Full_Name as Name,DOB,ADD_LINE_1," +
    ////       " ADD_LINE_2,ADD_LINE_3,City,Pin_code,Phone1,Phone2,Emp_Code,Location,Emp_Code,DATE_OF_JOINING,LOCATION,DESIGNATION,FATHER_NAME,STAFF_NAME, " +
    ////       "Previous_Employer_Name,Previous_Employer_Address,Previous_Designation,Reference_Name_Number,Project " +
    ////       " from CPV_EBC_CASE_DETAILS where Centre_id='" + CentreId + "' AND Client_id='" + ClientId + "' AND SEND_DATETIME IS NULL";
    ////    return sSql;
    ////}

    public string GetEBCCaseEntry()
    {

        string sSql = "";
        SqlConnection con = new SqlConnection(objCon.AppConnectionString);

        SqlCommand command = new SqlCommand("sp_GetEBCCaseEntryBGC", con);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@Centre_id",CentreId);
        command.Parameters.AddWithValue("@Client_id", ClientId);

        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = command;
        DataSet MyDataSet = new DataSet();

        sda.Fill(MyDataSet);

        con.Close();

        return sSql;
    }





    //------------------------------------------------------comp------------------------------------//



    //----------------------------------------------------------BGC Export Page code Report----------------------------------------------
    public DataTable GetPDFReportNew(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] EBC = new OleDbParameter[1];
        EBC[0] = new OleDbParameter("@case_id", OleDbType.VarChar, 15);
        EBC[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.StoredProcedure, "sp_GetImage", EBC);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    public DataSet GetPDFName(string strCaseId)
    {
        string sSql = "";
        SqlConnection con = new SqlConnection(objCon.AppConnectionString);

        SqlCommand command = new SqlCommand("sp_GetPDFName", con);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@case_id", strCaseId);
       

        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = command;
        DataSet MyDataSet = new DataSet();

        sda.Fill(MyDataSet);

        con.Close();

        return MyDataSet;
    
    }

    //----------------------------------------------------------comp-------------------------------------------------------------




    //----------------------------------------------------------BGC FE Assignment Page code----------------------------------------------
   
    
    public void InsertFeCaseMapping(string strCaseIds, string IsRef)
    {
        arrCaseID = strClinetId.Split(',');
        InsertFeCaseMapping("'" + strClinetId + "'");
    }


    ////public void InsertFeCaseMapping(string strCaseIds)
    ////{
    ////    OleDbConnection conn = new OleDbConnection(objCon.ConnectionString);
    ////    conn.Open();
    ////    OleDbTransaction trans = conn.BeginTransaction();
    ////    try
    ////    {
    ////        //ap_done
    ////        //sp_GetEBCCaseEntryBGC_delete
    ////        String sQuery1 = "DELETE FROM CPV_EBC_FE_MAPPING WHERE VERIFICATION_TYPE_ID='" + VerificationType + "' AND CASE_ID IN (" + strCaseIds + " )";
    ////        OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery1);

    ////        //sp_GetEBCCaseEntryBGC_delete1
    ////        String rDelete = "DELETE from CPV_EBC_VERIFICATION where verification_type_id='" + VerificationType + "' and case_id in (" + strCaseIds + ") and fe_response = 'Reject'";
    ////        OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, rDelete);
    ////        //sp_GetEBCCaseEntryBGC_Insert
    ////        String sQuery = "INSERT INTO CPV_EBC_FE_MAPPING (CASE_ID, FE_ID, VERIFICATION_TYPE_ID, DATE_TIME,AddBy,AddDate) VALUES(?, ?, ?, ?,?,?)";
    ////        foreach (string sCaseID in arrCaseID)
    ////        {


    ////            OleDbParameter[] paramFEAssign = new OleDbParameter[6];
    ////            paramFEAssign[0] = new OleDbParameter("@CASE_ID", OleDbType.VarChar, 15);
    ////            paramFEAssign[0].Value = sCaseID;
    ////            paramFEAssign[1] = new OleDbParameter("@FE_ID", OleDbType.VarChar, 15);
    ////            paramFEAssign[1].Value = AssignedTo;
    ////            paramFEAssign[2] = new OleDbParameter("@VERIFICATION_TYPE_ID", OleDbType.VarChar, 15);
    ////            paramFEAssign[2].Value = VerificationType;
    ////            paramFEAssign[3] = new OleDbParameter("@DATE_TIME", OleDbType.Date, 8);
    ////            paramFEAssign[3].Value = strDate;
    ////            paramFEAssign[4] = new OleDbParameter("@AssignedBy", OleDbType.VarChar, 15);
    ////            paramFEAssign[4].Value = AssignedBy;
    ////            paramFEAssign[5] = new OleDbParameter("@AddDate", OleDbType.Date, 8);
    ////            paramFEAssign[5].Value = strDate;
    ////            OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery, paramFEAssign);
    ////        }
    ////        trans.Commit();
    ////        conn.Close();
    ////    }
    ////    catch (Exception exp)
    ////    {
    ////        trans.Rollback();
    ////        conn.Close();
    ////        throw new Exception("An error occurred ", exp);
    ////    }
    ////}

    public void InsertFeCaseMapping(string strCaseIds)
    {
        OleDbConnection conn = new OleDbConnection(objCon.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {


            using (SqlConnection con = new SqlConnection(objCon.AppConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_GetEBCCaseEntryBGC_delete", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@VERIFICATION_TYPE_ID", VerificationType);
                command.Parameters.AddWithValue("@CASE_ID", strCaseIds);
                con.Open();
                int i = command.ExecuteNonQuery();
                con.Close();
            }


            using (SqlConnection con1 = new SqlConnection(objCon.AppConnectionString))
            {
                SqlCommand command1 = new SqlCommand("sp_GetEBCCaseEntryBGC_delete1", con1);
                command1.CommandType = CommandType.StoredProcedure;
                command1.Parameters.AddWithValue("@VERIFICATION_TYPE_ID", VerificationType);
                command1.Parameters.AddWithValue("@CASE_ID", strCaseIds);
                con1.Open();
                int i1 = command1.ExecuteNonQuery();
                con1.Close();
            }

            SqlConnection con2 = new SqlConnection(objCon.AppConnectionString);
            
                SqlCommand command2 = new SqlCommand("sp_GetEBCCaseEntryBGC_Insert", con2);
                command2.CommandType = CommandType.StoredProcedure;
                foreach (string sCaseID in arrCaseID)
                {
                    command2.Parameters.AddWithValue("@CASE_ID", sCaseID);
                    command2.Parameters.AddWithValue("@FE_ID", AssignedTo);
                    command2.Parameters.AddWithValue("@VERIFICATION_TYPE_ID", VerificationType);
                    command2.Parameters.AddWithValue("@DATE_TIME", strDate);
                    command2.Parameters.AddWithValue("@AddBy", AssignedBy);
                    command2.Parameters.AddWithValue("@AddDate", strDate);
                    con2.Open();
                    int i2 = command2.ExecuteNonQuery();
                    con2.Close();

                
            }
          
        }
        catch (Exception exp)
        {

            throw new Exception("An error occurred ", exp);
        }
    }

    //----------------------------------------------------------comp-------------------------------------------------------------
    
    //----------------------------------------------------------BGC send to client final Page code----------------------------------------------


    //to search data in gridview
    public DataSet GetRecordsEBC1(string strClientId, string strCentreId, string strProductId, DateTime strFromDate, DateTime strToDate, string strTableName)
    {
        //to search data in gridview    
         

        SqlConnection con = new SqlConnection(objCon.AppConnectionString);

        SqlCommand command = new SqlCommand("sp_GetRecordsEBC123", con);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@CLIENT_ID", strClientId);
        command.Parameters.AddWithValue("@CENTRE_ID", strCentreId);
        command.Parameters.AddWithValue("@Fromdate", strFromDate);
        command.Parameters.AddWithValue("@Todate", strToDate);
        command.Parameters.AddWithValue("@PRODUCT_ID", strProductId);

        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = command;
        DataSet MyDataSet = new DataSet();
        sda.Fill(MyDataSet);
        con.Close();
        return MyDataSet;

    }
   
    public string GerStandardTatHourBGC(string strClientId, string strActivityId, string strProductId)
    {
        string STD_HRS = "";
        SqlConnection con = new SqlConnection(objCon.AppConnectionString);
        SqlCommand command = new SqlCommand("sp_GerStandardTatHour", con);
        command.CommandType = CommandType.StoredProcedure;


        command.Parameters.AddWithValue("@ACTIVITY_ID", strActivityId);
        command.Parameters.AddWithValue("@CLIENT_ID", strClientId);
        command.Parameters.AddWithValue("@PRODUCT_ID", strProductId);


        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = command;

        DataSet MyDs = new DataSet();
        sda.Fill(MyDs);


        //return MyDs;

        if (MyDs.Tables[0].Rows.Count > 0)
        {
            STD_HRS = MyDs.Tables[0].Rows[0]["STD_HRS1"].ToString();
        }
        //oledbTrans.Commit();
        con.Close();
        return STD_HRS;

    }


    //comment by kanchan on 4/11/2014
    ////public string CalulateTATHrsBGC(DateTime sFromDate, DateTime sToDate, string strClientId, string strCentreId, string strTableName)
    ////{
    ////    DataTable d_table = new DataTable();
    ////    DataSet ds = new DataSet();
    ////    DateTime strSendDate;
    ////    DateTime strSendDate1;
    ////    TimeSpan ts1;
    ////    double Hrs, mins;
    ////    string Hours = "";
    ////    string Minutes = "";
    ////    string Total_Hours = "";
    ////    DataRow drow;
    ////    OleDbDataAdapter da = new OleDbDataAdapter();
    ////    OleDbConnection conn = new OleDbConnection(objCon.ConnectionString);
    ////    d_table.Columns.Add("REF_NO");
    ////    d_table.Columns.Add("APPLICANT_NAME");
    ////    d_table.Columns.Add("REC_DATE");
    ////    d_table.Columns.Add("TAT_HRS");
    ////    d_table.Columns.Add("CaseId");
    ////    try
    ////    {

    ////        string sSql = " SELECT CD.CASE_ID as CaseId,CD.REF_NO, (ISNULL(CD.FIRST_NAME,'')+''+ISNULL(CD.LAST_NAME,'')+''+ " +
    ////                       " ISNULL(CD.MIDDLE_NAME,''))AS APPLICANT_NAME,CD.CASE_REC_DATETIME AS REC_DATE,Null as TAT_HRS " +
    ////                       " FROM " + strTableName + " CD " +
    ////                       " WHERE CD.CASE_ID='" + CaseId + "'";

    ////        da = new OleDbDataAdapter(sSql, conn);
    ////        da.Fill(ds, "TAT");
    ////        if (ds.Tables["TAT"].Rows.Count > 0)
    ////        {
    ////            for (int i = 0; i < ds.Tables["TAT"].Rows.Count; i++)
    ////            {
    ////                drow = d_table.NewRow();
    ////                drow[0] = ds.Tables["TAT"].Rows[i]["REF_NO"];
    ////                drow[1] = ds.Tables["TAT"].Rows[i]["APPLICANT_NAME"];

    ////                drow[2] = Convert.ToDateTime(ds.Tables["TAT"].Rows[i]["REC_DATE"].ToString()).ToString("dd/MM/yyyy hh:mm tt");
    ////                String s = ds.Tables["TAT"].Rows[i]["REC_DATE"].ToString();
    ////                strSendDate1 = Convert.ToDateTime(s.ToString());
    ////                String s1 = Convert.ToDateTime(objCon.strDate(SendDate)).ToString("MM/dd/yyyy") + " " + SendTime.ToString() + " " + SendTimeType.ToString();
    ////                strSendDate = Convert.ToDateTime(s1.ToString());
    ////                ts1 = strSendDate.Subtract(strSendDate1);
    ////                Hrs = Convert.ToDouble(ts1.Days * 24 + ts1.Hours);
    ////                mins = Convert.ToDouble(ts1.Minutes);
    ////                Hours = Hrs.ToString();
    ////                Minutes = mins.ToString();
    ////                Total_Hours = Hours + ":" + Minutes;

    ////            }

    ////        }
    ////        return Total_Hours;

    ////    }
    ////    catch (Exception ex)
    ////    {
    ////        throw new Exception(ex.Message);
    ////    }
    ////}

    public string CalulateTATHrsBGC(DateTime sFromDate, DateTime sToDate, string strClientId, string strCentreId, string strTableName)
    {
        DataTable d_table = new DataTable();
        DataSet ds = new DataSet();
        DateTime strSendDate;
        DateTime strSendDate1;
        TimeSpan ts1;
        double Hrs, mins;
        string Hours = "";
        string Minutes = "";
        string Total_Hours = "";
        DataRow drow;
        //OleDbDataAdapter da = new OleDbDataAdapter();
        SqlDataAdapter da = new SqlDataAdapter();
        //OleDbConnection conn = new OleDbConnection(objCon.ConnectionString);
        SqlConnection con = new SqlConnection(objCon.AppConnectionString);
        d_table.Columns.Add("REF_NO");
        d_table.Columns.Add("APPLICANT_NAME");
        d_table.Columns.Add("REC_DATE");
        d_table.Columns.Add("TAT_HRS");
        d_table.Columns.Add("CaseId");
        try
        {
            SqlCommand command = new SqlCommand("sp_CalulateTATHrsBGC", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CASE_ID",CaseId);          

            con.Open();           
            da.SelectCommand = command;
            da.Fill(ds, "TAT");


            if (ds.Tables["TAT"].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables["TAT"].Rows.Count; i++)
                {
                    drow = d_table.NewRow();
                    drow[0] = ds.Tables["TAT"].Rows[i]["REF_NO"];
                    drow[1] = ds.Tables["TAT"].Rows[i]["APPLICANT_NAME"];

                    drow[2] = Convert.ToDateTime(ds.Tables["TAT"].Rows[i]["REC_DATE"].ToString()).ToString("dd/MM/yyyy hh:mm tt");
                    String s = ds.Tables["TAT"].Rows[i]["REC_DATE"].ToString();
                    strSendDate1 = Convert.ToDateTime(s.ToString());
                    String s1 = Convert.ToDateTime(objCon.strDate(SendDate)).ToString("MM/dd/yyyy") + " " + SendTime.ToString() + " " + SendTimeType.ToString();
                    strSendDate = Convert.ToDateTime(s1.ToString());
                    ts1 = strSendDate.Subtract(strSendDate1);
                    Hrs = Convert.ToDouble(ts1.Days * 24 + ts1.Hours);
                    mins = Convert.ToDouble(ts1.Minutes);
                    Hours = Hrs.ToString();
                    Minutes = mins.ToString();
                    Total_Hours = Hours + ":" + Minutes;

                }

            }
            return Total_Hours;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }    


    //----------------------------------------------------------comp-------------------------------------------------------------
    
    
    
    
    //----------------------------------------------------------BGC Verification Page code----------------------------------------------
    //public string GetVerificationTypeID1(string sCaseID)
    //{
    //    //sp_GetVerificationTypeID1
    //    string sql = " select verification_type_id from CPV_EBC_VAERIFICATION_TYPE where case_id='" + sCaseID + "' ";
    //    string str = (string)OleDbHelper.ExecuteScalar(objCon.ConnectionString, CommandType.Text, sql);
    //    return str;
    //}

    public string GetVerificationTypeID1(string sCaseID)
    {
  string o4;
        SqlConnection con = new SqlConnection(objCon.AppConnectionString);

        SqlCommand command = new SqlCommand("sp_GetVerificationTypeID1", con);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@case_id", sCaseID);    

        con.Open();
        o4 =(string)command.ExecuteScalar();
        return o4;
       

    }


    ////public OleDbDataReader GetEBCDetail(string sCaseId)
    ////{
    ////    string sSql = "";
    ////    sSql = "select * from CPV_EBC_VERIFICATION where case_id='" + sCaseId + "' ";
    ////    return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    ////}
    public DataSet GetEBCDetail(string sCaseId)
    {

        SqlConnection con = new SqlConnection(objCon.AppConnectionString);

        SqlCommand command = new SqlCommand("sp_GetEBCDetailBGC", con);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@case_id", sCaseId);    

        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = command;
        DataSet MyDataSet = new DataSet();
        sda.Fill(MyDataSet);
        con.Close();
        return MyDataSet;
    }



    ////public OleDbDataReader GetCASEDetail(string sCaseId)
    ////{
    ////    string sSql = "";
    ////    sSql = "SELECT CD.REF_NO," +
    ////           " CONVERT(CHAR(10), cd.CASE_REC_DATETIME,103) + ' ' + " +
    ////           " LTRIM(SUBSTRING(CONVERT( VARCHAR(210),cd.CASE_REC_DATETIME, 22), 10, 5) + " +
    ////           " RIGHT(CONVERT(VARCHAR(20), cd.CASE_REC_DATETIME, 22), 3)) as CASE_REC_DATETIME, " +
    ////           " ISNULL(CD.FIRST_NAME,'') + ' ' + ISNULL(CD.MIDDLE_NAME,'')+ISNULL(CD.LAST_NAME,'') AS NAME, " +
    ////           " ISNULL(CD.ADD_LINE_1,'') + ' ' + ISNULL(CD.ADD_LINE_2,'')+ISNULL(CD.ADD_LINE_3,'') AS Address, EMP_CODE,DOB,CASE_REC_DATETIME" +
    ////           " FROM CPV_EBC_CASE_DETAILS CD  INNER JOIN " +
    ////           " CPV_EBC_VAERIFICATION_TYPE CV ON CD.CASE_ID = CV.CASE_ID " +
    ////           " where CV.case_id='" + sCaseId + "' ";


    ////    return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    ////}

    public DataSet GetCASEDetail(string sCaseId)
    {

        SqlConnection con = new SqlConnection(objCon.AppConnectionString);

        SqlCommand command = new SqlCommand("sp_GetCASEDetail", con);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@case_id", sCaseId);

        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = command;
        DataSet MyDataSet = new DataSet();
        sda.Fill(MyDataSet);
        con.Close();
        return MyDataSet;
    }



    ////public OleDbDataReader GetFEName(string sCaseId)
    ////{
    ////    string sSql = "";
    ////    sSql = "select distinct fullname,FE_ID from fe_vw fv inner join CPV_EBC_FE_MAPPING cifcm on(cifcm.fe_id=fv.emp_id)  where case_id='" + sCaseId + "'  order by fv.fullname";
    ////    return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    ////}
    public DataSet GetFEName(string sCaseId)
    {
      SqlConnection con = new SqlConnection(objCon.AppConnectionString);

      SqlCommand command = new SqlCommand("sp_GetFEName", con);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@case_id", sCaseId);

        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = command;
        DataSet MyDataSet = new DataSet();
        sda.Fill(MyDataSet);
        con.Close();
        return MyDataSet;
    }


    public OleDbDataReader GetRelationship(string sCaseID)
    {
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        string sSql = "";

        sSql = "select Relationship,Occupation from CPV_EBC_RELATIONSHIP where case_id='" + sCaseID + "' ";
        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }

    ////public DataSet GetRelationship(string sCaseID)
    ////{
    ////    SqlConnection con = new SqlConnection(objCon.AppConnectionString);

    ////    SqlCommand command = new SqlCommand("sp_GetRelationship", con);
    ////    command.CommandType = CommandType.StoredProcedure;
    ////    command.Parameters.AddWithValue("@case_id", sCaseID);

    ////    con.Open();
    ////    SqlDataAdapter sda = new SqlDataAdapter();
    ////    sda.SelectCommand = command;
    ////    DataSet MyDataSet = new DataSet();
    ////    sda.Fill(MyDataSet);
    ////    con.Close();
    ////    return MyDataSet;
    ////}


    ////public string GetVerificationTypeID()
    ////{
    ////    string sql = " select verification_type_id from CPV_EBC_VAERIFICATION_TYPE where case_id='" + CaseID + "' ";
    ////    string str = (string)OleDbHelper.ExecuteScalar(objCon.ConnectionString, CommandType.Text, sql);
    ////    return str;
    ////}

    public string GetVerificationTypeID()
    {
         
        SqlConnection con = new SqlConnection(objCon.AppConnectionString);

        SqlCommand command = new SqlCommand("sp_GetVerificationTypeID", con);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@case_id", CaseID);

        con.Open();
       string o2;
        o2 = (string)command.ExecuteScalar();
        con.Close();       
        return o2;
    }

    public string InsertEBCVerificationType()
    {
        string sSql = "";
        string sSql1 = "";
        OleDbConnection sqlconn = new OleDbConnection(objCon.ConnectionString);
        sqlconn.Open();

        //OleDbTransaction sqlTrans = sqlconn.BeginTransaction();
        string sRetVal = "";
        try
        {
             string msg = "";
             SqlConnection con1 = new SqlConnection(objCon.AppConnectionString);

            SqlCommand command1 = new SqlCommand("sp_InsertEBCVerificationType_Select", con1);
            command1.CommandType = CommandType.StoredProcedure;

            command1.Parameters.AddWithValue("@Case_ID", CaseID);

            con1.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = command1;

            DataSet MyDs = new DataSet();
            sda.Fill(MyDs);

            con1.Close();

            //----comp----//


            using (SqlConnection con = new SqlConnection(objCon.AppConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_InsertEBCVerificationType_Update", con);
                command.CommandType = CommandType.StoredProcedure;



                command.Parameters.AddWithValue("@case_id", CaseID);
                command.Parameters.AddWithValue("@verification_type_id", GetVerificationTypeID());
                command.Parameters.AddWithValue("@verification_datetime", VerificationDateTime);
                command.Parameters.AddWithValue("@Contact_person", NameOfPersonContated);
                command.Parameters.AddWithValue("@Contact_person_designation", RespondentDesignation);
                command.Parameters.AddWithValue("@Institute_name", InstitutionName);
                command.Parameters.AddWithValue("@Employment_Date", EmployeeDates);
                command.Parameters.AddWithValue("@Date_attend", DatesAttended);
                command.Parameters.AddWithValue("@Qulaification_gained", QualificationGained);
                command.Parameters.AddWithValue("@Organization_name", OrganisationName);
                command.Parameters.AddWithValue("@Last_Position_Held", LastPosition);
                command.Parameters.AddWithValue("@Reporting_Manager", ReportingManager);
                ////for family members
                command.Parameters.AddWithValue("@Gap_Identified", GapIdentified);
                command.Parameters.AddWithValue("@Period_Of_Gap", PeriodOfGap);
                command.Parameters.AddWithValue("@Reason_Of_Gap", ReasoinOfGap);
                command.Parameters.AddWithValue("@Address_Gap", AddressDuringGap);
                command.Parameters.AddWithValue("@Police_Verification_GAP", policaVerificationGap);
                command.Parameters.AddWithValue("@Police_Verification", policaVerification);
                command.Parameters.AddWithValue("@Telephone_No", TelephoneNo1);
                //////for period of stay
                command.Parameters.AddWithValue("@Year_At_Residence", NumberOfYear);
                command.Parameters.AddWithValue("@Residence_Type", ResidenceType);
                command.Parameters.AddWithValue("@Landmark", LandMark);
                command.Parameters.AddWithValue("@Accessibility", Accessbility);
                command.Parameters.AddWithValue("@Family_relation_Ocupation", FamilyMember);
                command.Parameters.AddWithValue("@Relationship", RelationshipToEmp);
                command.Parameters.AddWithValue("@Permanent_Address", PemanentAdd);
                ////for Neighbour Confirmation 2
                command.Parameters.AddWithValue("@Previous_job_Detail", previosJobDetail);
                //////for Type Of Accomodation
                command.Parameters.AddWithValue("@Locality", Locality);
                command.Parameters.AddWithValue("@Neighbour_Name", NeighbourName);
                ///// for Neighbour Confirmation 1
                command.Parameters.AddWithValue("@Neighbour_Feedback", NeighbourFeedBackOfEmp);
                command.Parameters.AddWithValue("@Tel_No2", TelephoneNo2);
                //////for Additional Comment
                command.Parameters.AddWithValue("@Remark", Remark);
                command.Parameters.AddWithValue("@CASE_STATUS_ID", Status);
                command.Parameters.AddWithValue("@MODIFY_BY", HttpContext.Current.Session["UserId"].ToString());
                command.Parameters.AddWithValue("@MODIFY_DATE", System.DateTime.Now);
                command.Parameters.AddWithValue("@Marrital_Status", MarritalStatus);
                command.Parameters.AddWithValue("@Applicant_Age", ApplicantAge);
                //////add new by kanchan  new fields

                command.Parameters.AddWithValue("@ErrorLog", ErrorLog);
                command.Parameters.AddWithValue("@ErrorRemark", ErrorRemark);
                command.Parameters.AddWithValue("@UploadImg1", FileUpload1);
                command.Parameters.AddWithValue("@UploadImg2", FileUpload2);
                command.Parameters.AddWithValue("@UploadImg3", FileUpload3);
                command.Parameters.AddWithValue("@UploadImg4", FileUpload4);
                command.Parameters.AddWithValue("@UploadImg5", FileUpload5);

                ///-----------new fields comp-------//


                con.Open();
                int i = command.ExecuteNonQuery();
                con.Close();
            }


            //////----comp---//


            sRetVal = "Record added successfully.";
         



            //sp_sp_InsertEBCVerificationType_Update1

            ////sSql1 = "update CPV_EBC_CASE_DETAILS set CASE_STATUS_ID= " + Status + " Where case_id=" + CaseID + " ";
            ////OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql1);

            SqlConnection con2 = new SqlConnection(objCon.AppConnectionString);

            SqlCommand command2 = new SqlCommand("sp_sp_InsertEBCVerificationType_Update1", con2);
            command2.CommandType = CommandType.StoredProcedure;

            command2.Parameters.AddWithValue("@CASE_STATUS_ID",Status );
            command2.Parameters.AddWithValue("@case_id", CaseID);          

            con2.Open();
           int nretVal = command2.ExecuteNonQuery();
            con2.Close();
            





            sSql = "";
            //sp_sp_InsertEBCVerificationType_Insert1
            ////sSql = "Insert into CASE_TRANSACTION_LOG(CASE_ID,VERIFICATION_TYPE_ID,USER_ID,TRANS_START,TRANS_END," +
            ////     "CENTRE_ID,PRODUCT_ID,CLIENT_ID) VALUES(?,?,?,?,?,?,?,?)";

            ////OleDbParameter[] paramTransLog = new OleDbParameter[8];
            ////paramTransLog[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
            ////paramTransLog[0].Value = CaseID.Trim();
            ////paramTransLog[1] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar, 15);
            ////paramTransLog[1].Value = GetVerificationTypeID();
            ////paramTransLog[2] = new OleDbParameter("@UserId", OleDbType.VarChar, 15);
            ////paramTransLog[2].Value = UserId;
            ////paramTransLog[3] = new OleDbParameter("@TransStart", OleDbType.DBTimeStamp);
            ////paramTransLog[3].Value = TransStart;
            ////paramTransLog[4] = new OleDbParameter("@TransEnd", OleDbType.DBTimeStamp);
            ////paramTransLog[4].Value = TransEnd;
            ////paramTransLog[5] = new OleDbParameter("@CentreId", OleDbType.VarChar, 15);
            ////paramTransLog[5].Value = CentreId;
            ////paramTransLog[6] = new OleDbParameter("@ProductId", OleDbType.VarChar, 15);
            ////paramTransLog[6].Value = ProductId;
            ////paramTransLog[7] = new OleDbParameter("@ClientId", OleDbType.VarChar, 15);
            ////paramTransLog[7].Value = ClientId;
            ////OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql, paramTransLog);

            SqlConnection con3 = new SqlConnection(objCon.AppConnectionString);

            SqlCommand command3 = new SqlCommand("sp_sp_InsertEBCVerificationType_Insert1", con3);
            command3.CommandType = CommandType.StoredProcedure;

            command3.Parameters.AddWithValue("@CASE_ID", CaseID.Trim());
            command3.Parameters.AddWithValue("@VERIFICATION_TYPE_ID",GetVerificationTypeID());
             command3.Parameters.AddWithValue("@USER_ID",UserId);
             command3.Parameters.AddWithValue("@TRANS_START",TransStart);
             command3.Parameters.AddWithValue("@TRANS_END",TransEnd);
             command3.Parameters.AddWithValue("@CENTRE_ID",CentreId);
             command3.Parameters.AddWithValue("@PRODUCT_ID",ProductId);
             command3.Parameters.AddWithValue("@CLIENT_ID",ClientId);
            con3.Open();
            int i2 = command3.ExecuteNonQuery();
            con3.Close();


            
            if (IsVerificationComplete(CaseID) == "true")
            {
                VerificationComplete(CaseID);
                sRetVal += " Case verification data entry completed.";
            }
            

           
         
            return sRetVal;
        }
        catch (Exception ex)
        {
               
            throw new Exception("Error while Inserting/updating Verification entry. " + ex.Message);
        }
    }

    ////public void DeleteRelatioship()
    ////{
    ////    //sp_DeleteRelatioship
    ////    OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
    ////    oledbConn.Open();
    ////    OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
    ////    string sSql1 = "";
    ////    try
    ////    {
    ////        sSql1 = "delete from CPV_EBC_RELATIONSHIP where case_id='" + CaseID + "' ";
    ////        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql1);
    ////        oledbTrans.Commit();
    ////        oledbConn.Close();
    ////    }
    ////    catch (Exception ex)
    ////    {
    ////        oledbTrans.Rollback();
    ////        oledbConn.Close();
    ////        throw new Exception("An error occurred while Deleting the value of Qualification", ex);
    ////    }
    ////}

    public void DeleteRelatioship()
    {
        //sp_DeleteRelatioship
       
        try
        {
            SqlConnection con = new SqlConnection(objCon.AppConnectionString);

            SqlCommand command = new SqlCommand("sp_DeleteRelatioship", con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@case_id", CaseID);
       
            con.Open();
            int i2 = command.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
            
            throw new Exception("An error occurred while Deleting the value of Qualification", ex);
        }
    }

    ////public void InsertFamilyRecord()
    ////{
    ////    //sp_InsertFamilyRecordBGC
    ////    OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
    ////    oledbConn.Open();
    ////    OleDbTransaction oledbTrans = oledbConn.BeginTransaction();

    ////    string sSql = "";

    ////    try
    ////    {
    ////        sSql = "insert into CPV_EBC_RELATIONSHIP (case_id,verification_type_id,Relationship,Occupation) values(?,?,?,?)";
    ////        OleDbParameter[] paramRelationship = new OleDbParameter[4];
    ////        paramRelationship[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
    ////        paramRelationship[0].Value = CaseID;
    ////        paramRelationship[1] = new OleDbParameter("@Qualification", OleDbType.VarChar, 15);
    ////        paramRelationship[1].Value = GetVerificationTypeID();
    ////        paramRelationship[2] = new OleDbParameter("@Specilization", OleDbType.VarChar, 100);
    ////        paramRelationship[2].Value = Relationship;
    ////        paramRelationship[3] = new OleDbParameter("@University", OleDbType.VarChar, 100);
    ////        paramRelationship[3].Value = Occupation;

    ////        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramRelationship);
    ////        oledbTrans.Commit();
    ////        oledbConn.Close();
    ////    }
    ////    catch (Exception ex)
    ////    {
    ////        oledbTrans.Rollback();
    ////        oledbConn.Close();
    ////        throw new Exception("An error occurred while inserting the value of Qualification", ex);
    ////    }
    ////}



    public void InsertFamilyRecord()
    {
        //sp_InsertFamilyRecordBGC      


        try
        {
            SqlConnection con = new SqlConnection(objCon.AppConnectionString);

            SqlCommand command = new SqlCommand("sp_InsertFamilyRecordBGC", con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@case_id",CaseID);
             command.Parameters.AddWithValue("@verification_type_id",GetVerificationTypeID());
             command.Parameters.AddWithValue("@Relationship",Relationship);
             command.Parameters.AddWithValue("@Occupation", Occupation);

            con.Open();
            int i2 = command.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception ex)
        {
           
            throw new Exception("An error occurred while inserting the value of Qualification", ex);
        }
    }

    #region IsVerificationComplete
   
    ////public string IsVerificationComplete(OleDbTransaction oledbTrans, string sCaseId)
    ////{
    ////    string sSql = "";
    ////    OleDbDataReader oledbRead;
    ////    string bComplete = "";
    ////    sSql = " Select case (select count(*) from CPV_EBC_VAERIFICATION_TYPE " +
    ////          " where case_id='" + sCaseId + "') " +
    ////          " when (select count(*) from CPV_EBC_CASE_OUTPUT_VW where case_id='" + sCaseId + "') " +
    ////          " then 'true' else 'false' end as IsComplete";

    ////    oledbRead = OleDbHelper.ExecuteReader(oledbTrans, CommandType.Text, sSql);
    ////    if (oledbRead.Read() == true)
    ////        bComplete = oledbRead["IsComplete"].ToString();

    ////    return bComplete;
    ////}

    public string IsVerificationComplete(string sCaseId)
    {
        ////string sSql = "";
        string bComplete = "";

        ////string bComplete = "";
        ////sSql = " Select case (select count(*) from CPV_EBC_VAERIFICATION_TYPE " +
        ////      " where case_id='" + sCaseId + "') " +
        ////      " when (select count(*) from CPV_EBC_CASE_OUTPUT_VW where case_id='" + sCaseId + "') " +
        ////      " then 'true' else 'false' end as IsComplete";

        ////oledbRead = OleDbHelper.ExecuteReader(oledbTrans, CommandType.Text, sSql);


        SqlConnection con = new SqlConnection(objCon.AppConnectionString);

        SqlCommand command = new SqlCommand("sp_IsVerificationCompleteBGC", con);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@case_id", sCaseId);

        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = command;
        DataSet MyDataSet = new DataSet();
        sda.Fill(MyDataSet);
        con.Close();


        if (MyDataSet.Tables[0].Rows.Count>0)
            bComplete = MyDataSet.Tables[0].Rows[0]["IsComplete"].ToString();

        return bComplete;
    }

    #endregion IsVerificationComplete

    #region VerificationComplete after completing verification IS_CASE_COMPLETE='Y'
    
    
    //sp_VerificationCompleteBGC
    ////public void VerificationComplete(OleDbTransaction oledbTrans, string sCaseId)
    ////{
    ////    string sSql = "";
    ////    sSql = "Update CPV_EBC_CASE_DETAILS SET IS_CASE_COMPLETE='Y' WHERE CASE_ID='" + sCaseId + "'";
    ////    OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);
    ////}
    public void VerificationComplete(string sCaseId)
    {
        SqlConnection con = new SqlConnection(objCon.AppConnectionString);

        SqlCommand command = new SqlCommand("sp_VerificationCompleteBGC", con);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@CASE_ID", sCaseId);
    
        con.Open();
        int i2 = command.ExecuteNonQuery();
        con.Close();  
    }

    #endregion VerificationComplete



    public void insertGridFieldsBGC(DateTime strSendDate, string chkb, string Verification_type_id)
    {
        SqlConnection con = new SqlConnection(objCon.AppConnectionString);
        try
        {


            SqlCommand command = new SqlCommand("sp_insertGridFieldsBGC", con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@SEND_DATETIME", strSendDate);
            command.Parameters.AddWithValue("@TAT_HRS", TATHRS);
            command.Parameters.AddWithValue("@WITHIN_TAT", chkb);
            command.Parameters.AddWithValue("@CASE_ID", CaseId);
            command.Parameters.AddWithValue("@verification_type_id", Verification_type_id);

            con.Open();
            int i = command.ExecuteNonQuery();
            con.Close();

        }



        catch (Exception ex)
        {

            con.Close();
            throw new Exception("Error While Sending " + ex.Message);
        }
    }


    //------------------------------------------------comp-----------------------------------------------------//


    //-----------------------------------------------------------label printing--------------------------------------------------



    public DataSet getGridValue_BGC(string CentreId, string strClient_ID)
    {
        string strSQL = "";
        strSQL = "SELECT SR_NO,[REF_NO],(ISNULL(FIRST_NAME,'')+''+ISNULL(MIDDLE_NAME,'')+''+ISNULL(LAST_NAME,'')) AS APPLICANT_NAME FROM CPV_EBC_CASE_DETAILS";
        strSQL = strSQL + " WHERE CASE_REC_DATETIME >= '" + strfromdate + "' AND  CASE_REC_DATETIME <  '" + strtodate + "' ";
        strSQL = strSQL + " AND [CENTRE_ID]='" + CentreId + "' AND [CLIENT_ID]='" + strClient_ID + "'";
        return OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, strSQL);
    }
    //public DataSet GetVerificationType_BGC(string activityid)
    //{
    //    //sp_GetVerificationType_BGC

    //    string strSQL = " select VERIFICATION_TYPE_CODE,VERIFICATION_TYPE_ID FROM verification_type_master   WHERE  ACTIVITY_ID= '" + activityid + "'" +
    //                     " AND VERIFICATION_TYPE_ID IN(1,15,16,17,18) ";
    //    return OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, strSQL);
    //}

    public DataSet GetVerificationType_BGC(string activityid)
    {
        SqlConnection con = new SqlConnection(objCon.AppConnectionString);

        SqlCommand command = new SqlCommand("sp_GetVerificationType_BGC", con);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@ACTIVITY_ID", activityid);

        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = command;
        DataSet MyDataSet = new DataSet();
        sda.Fill(MyDataSet);
        con.Close();
        return MyDataSet;
    }
    public bool FunctioncompareDate(string strFromDate, string strToDate)
    {
        DateTime sFromDate;
        DateTime sToDate;
        sFromDate = Convert.ToDateTime(objCon.strDate(strFromDate));
        sToDate = Convert.ToDateTime(objCon.strDate(strToDate));

        bool bReturn = true;
        if (sFromDate > sToDate)
        {
            bReturn = false;
        }
        else
        {
            bReturn = true;


        }
        return bReturn;
    }

    public DataSet getTemplate()
    {

        string strSQL = " SELECT Distinct VTM.VERIFICATION_TYPE_CODE, client_name As ADDITIONAL1, LPTM.ADDITIONAL2, LPTM.SR_NO,";
        strSQL = strSQL + " LPTM.LABEL_PRINTING_DATE, LPTM.ALL_VERIFICATION_TYPE,LPTD.TABLE_NAME, ";
        strSQL = strSQL + " LPTD.SELECTED_FIELD, LPTD.SERIAL_NO, LPTD.LINE_NO";
        strSQL = strSQL + " FROM LABEL_PRINTING_TEMPLATE_MASTER LPTM ";
        strSQL = strSQL + " INNER JOIN LABEL_PRINTING_TEMPLATE_DETAILS LPTD ";
        strSQL = strSQL + " ON (LPTM.LABEL_TEMPLATE_ID=LPTD.LABEL_TEMPLATE_ID)";
        strSQL = strSQL + " INNER JOIN VERIFICATION_TYPE_MASTER VTM";
        strSQL = strSQL + " ON (LPTM.VERIFICATION_TYPE_ID=VTM.VERIFICATION_TYPE_ID)";
        strSQL = strSQL + " INNER JOIN client_master CLM on LPTM.client_id=CLM.client_id ";
        strSQL = strSQL + " WHERE LPTM.CLIENT_ID='" + strClient_ID + "' AND LPTM.ACTIVITY_ID='" + strActivity_ID + "'";
        strSQL = strSQL + " AND LPTM.PRODUCT_ID='" + strProduct_ID + "'";
        strSQL = strSQL + " AND LPTM.VERIFICATION_TYPE_ID='" + strVerification_Type_ID + "' and LPTM.Template_For='L'";
        strSQL = strSQL + " ORDER BY LPTD.SERIAL_NO ";
        return OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, strSQL);

    }
    //----------------------------------------------------------comp-------------------------------------------------------------

    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    //for ebc not in use
    //    public DataSet GetRecordsBGC(string strClientId, string strCentreId, string strProductId, DateTime strFromDate, DateTime strToDate, string strTableName)
    //    {
    //        //above method is same as getrecords only name is change
    ////public DataSet GetRecords(string strClientId, string strCentreId, string strProductId, DateTime strFromDate, DateTime strToDate, string strTableName)

    //        SqlConnection con = new SqlConnection(connobj.AppConnectionString);

    //        SqlCommand command = new SqlCommand("sp_GetRecordsBGC", con);
    //        command.CommandType = CommandType.StoredProcedure;


    //        command.Parameters.AddWithValue("@CLIENT_ID", strClientId);
    //        command.Parameters.AddWithValue("@CENTRE_ID", strCentreId);
    //        command.Parameters.AddWithValue("@Fromdate", strFromDate);
    //        command.Parameters.AddWithValue("@Todate", strToDate);
    //        command.Parameters.AddWithValue("@PRODUCT_ID", strProductId);

    //        con.Open();
    //        SqlDataAdapter sda = new SqlDataAdapter();
    //        sda.SelectCommand = command;
    //        DataSet MyDataSet = new DataSet();

    //        sda.Fill(MyDataSet);

    //        con.Close();
    //        return MyDataSet;


    //    }

}
