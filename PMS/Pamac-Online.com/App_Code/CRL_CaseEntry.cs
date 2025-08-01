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
using System.IO;
using System.Collections;

/// <summary>
/// Summary description for CRL_CaseEntry
/// </summary>
public sealed class CRL_CaseEntry : CCPVDetail
{
    private CCommon objCon;
	public CRL_CaseEntry()
	{
        objCon = new CCommon();
	}
    #region Property Declaration

    private string sVerTypeId;
    private string sDeclineCode;
    private string sDeclineReason;
    private string sVerifierID;
    private string sVerificationTypeId;
    private string sAttemptDateTime;
    private string sAttemptRemark;
    private string sCaseStatusID;
    private string sChannelName;


    public string CaseStatusID
    {
        get { return sCaseStatusID; }
        set { sCaseStatusID = value; }
    }

    public string DeclineCode
    {
        get { return sDeclineCode; }
        set { sDeclineCode = value; }
    }

    public string DeclineReason
    {
        get { return sDeclineReason; }
        set { sDeclineReason = value; }
    }

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
    public string ChannelName
    {
        get { return sChannelName; }
        set { sChannelName = value; }
    }
    #endregion Property Declaration
    public DataSet GetCaseVerificationType(string sActivityD)
    {
        string sSql = "";
        sSql = "Select Verification_Type_Id, Verification_Type_code from Verification_Type_Master where ACTIVITY_ID='" + sActivityD + "'" +
                " AND VERIFICATION_TYPE_ID IN(1,2,4,3,10,14,12,13,31,32,34,35,36,42) ";
        return OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
    }
    public string GetCaseIdByRefNo(string sRefNo, OleDbTransaction oledbTrans)
    {
        string sSql = "";

        sSql = "Select Case_Id from CPV_RL_CASE_DETAILS where Ref_No='" + sRefNo + "'";
        DataSet ds = OleDbHelper.ExecuteDataset(oledbTrans, CommandType.Text, sSql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            CaseId = ds.Tables[0].Rows[0]["Case_Id"].ToString();
        }

        return CaseId;
    }
    public DataSet GetAllVerificationId(string sCaseID)
    {
        string sSql = "";
        sSql = "Select Verification_Type_ID from CPV_RL_CASE_VERIFICATIONTYPE where Case_Id='" + sCaseID + "'";

        return OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
    }
    public OleDbDataReader GetRLCase(string sCaseID)
    {
        string sSql = "";
        sSql = "Select Case_Id from CPV_RL_CASE_DETAILS where Case_ID='" + sCaseID + "'";

        return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    }
    public DataSet GetRLCaseEntry(string sCaseID, string sCentreId, string sClientId)
    {
        string sSql = "";

        sSql = "Select Ref_No,CASE_TYPE,Case_Rec_dateTime,Title,First_Name,Middle_Name,Last_Name,DOB," +
                "RES_ADD_LINE_1, RES_ADD_LINE_2,RES_ADD_LINE_3,RES_City,Res_Pin_code,Res_Land_Mark," +
                "Res_Phone,MOBILE,OFF_NAME,OFF_ADD_LINE_1,  OFF_ADD_LINE_2,OFF_ADD_LINE_3,Off_city," +
                "Off_Pin_Code,Off_Phone,Off_Extn,Designation,(ISNULL(RES_ADD_LINE_1,'') + ' ' + " +
                "ISNULL(RES_ADD_LINE_2,'')+ ' ' + ISNULL(RES_ADD_LINE_3,'')+' ' + ISNULL(Res_Land_Mark,'')" +
                "+' '+ISNULL(RES_City,'')+ ' ' + ISNULL(Res_Pin_code,'')) AS ADDRESS," +
                "ISNULL(First_Name,'')+ ' '+ISNULL(Middle_Name,'')+ ' '+ISNULL(Last_Name,'') + ' ' " +
                "+ISNULL(RES_ADD_LINE_1,'')+' '+ISNULL(RES_ADD_LINE_2,'')+' '+ISNULL(RES_ADD_LINE_3,'')+' '" +
                "+ISNULL(RES_LAND_MARK,'')+' ' + ISNULL(RES_CITY,'')+ ' ' +ISNULL(RES_PIN_CODE,'')" +
                "as SMSContent, Department,Full_Name as Name,Occupation,PRIORITY,REGION,SPL_INSTRUCTION,PRIORITY, " +
                " REGION,SPL_INSTRUCTION,PRODUCT_TYPE,PRODUCT_NAME,PRODUCT_PRICE,EMPLOYEE_TYPE,REFERENCE1,REFERENCE1_TEL,REFERENCE2,REFERENCE2_TEL,channel_name,App_Type " +
                "from CPV_RL_CASE_DETAILS Where Case_ID='" + sCaseID + "'" +
                " AND SEND_DATETIME IS NULL " +
                " AND CENTRE_ID='" + sCentreId + "'" +
                " AND CLIENT_ID='" + sClientId + "'" +
                " ORDER BY CASE_ID DESC";

       
        return OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, sSql);
    }
    public string GetRLCaseEntry(string sCentreId, string sClientId)
    {
        string sSql = "";

        sSql = "Select CASE_TYPE,Case_ID,Ref_No,Case_Rec_dateTime,Title,(ISNULL(First_Name,'')+ ' '+ISNULL(Middle_Name,'')+ ' '+ISNULL(Last_Name,'')) as Name,DOB,RES_ADD_LINE_1," +
               " RES_ADD_LINE_2,RES_ADD_LINE_3,RES_City,Res_Pin_code,Res_Land_Mark,Res_Phone,Mobile,OFF_NAME,OFF_ADD_LINE_1, " +
               " OFF_ADD_LINE_2,OFF_ADD_LINE_3,Off_city,Off_Pin_Code,Off_Phone,Off_Extn,Designation," +
               " (ISNULL(First_Name,'')+ ' '+ISNULL(Middle_Name,'')+ ' '+ISNULL(Last_Name,'') + ' ' +ISNULL(RES_ADD_LINE_1,'')+' '+ISNULL(RES_ADD_LINE_2,'')+' '+ISNULL(RES_ADD_LINE_3,'')+' '+ISNULL(RES_LAND_MARK,'')+' ' + ISNULL(RES_CITY,'')+ ' ' +ISNULL(RES_PIN_CODE,'')) as SMSContent, " +
               " Department,Occupation,PRIORITY,REGION,SPL_INSTRUCTION,PRODUCT_TYPE,PRODUCT_NAME,PRODUCT_PRICE,EMPLOYEE_TYPE,REFERENCE1,REFERENCE1_TEL,REFERENCE2,REFERENCE2_TEL,channel_name,App_Type " +
               " from CPV_RL_CASE_DETAILS " +
               " WHERE SEND_DATETIME IS NULL" +
               " AND CENTRE_ID='" + sCentreId + "'" +
               " AND CLIENT_ID='" + sClientId + "'" +
               " ORDER BY CASE_ID DESC ";

        return sSql;
    }

    public string GetRLCaseEntry(string sRefNo, string sName, bool bChecked, string sFrom, string sTo, string sCentreId, string sClientId)
    {
        string sSql = "";
        string FromDate = "";
        string ToDate = "";

        sSql = "Select CASE_TYPE,Case_ID,Ref_No,Case_Rec_dateTime,Title,(ISNULL(First_Name,'')+ ' '+ISNULL(Middle_Name,'')+ ' '+ISNULL(Last_Name,'')) as Name,DOB,RES_ADD_LINE_1," +
               " RES_ADD_LINE_2,RES_ADD_LINE_3,RES_City,Res_Pin_code,Res_Land_Mark,Res_Phone,MOBILE,OFF_NAME,OFF_ADD_LINE_1, " +
               " OFF_ADD_LINE_2,OFF_ADD_LINE_3,Off_city,Off_Pin_Code,Off_Phone,Off_Extn,Designation,PRIORITY,REGION ," +
               " (ISNULL(First_Name,'')+ ' '+ISNULL(Middle_Name,'')+ ' '+ISNULL(Last_Name,'') + ' ' +ISNULL(RES_ADD_LINE_1,'')+' '+ISNULL(RES_ADD_LINE_2,'')+' '+ISNULL(RES_ADD_LINE_3,'')+' '+ISNULL(RES_LAND_MARK,'')+' ' + ISNULL(RES_CITY,'')+ ' ' +ISNULL(RES_PIN_CODE,'')) as SMSContent, " +
               " Department,Occupation,Priority,Region,SPL_INSTRUCTION,PRODUCT_TYPE,PRODUCT_NAME,PRODUCT_PRICE,EMPLOYEE_TYPE,REFERENCE1,REFERENCE1_TEL,REFERENCE2,REFERENCE2_TEL,App_type from CPV_RL_CASE_DETAILS WHERE (SEND_DATETIME IS NULL)" +
               " AND CENTRE_ID='" + sCentreId + "'" +
               " AND CLIENT_ID='" + sClientId + "'" +
               " AND CLUSTER_ID='" + HttpContext.Current.Session["ClusterId"] + "'";


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
            //ToDate = Convert.ToDateTime(objCon.strDate(sFrom)).AddDays(1.0).ToString("dd-MMM-yyyy");
            //FromDate = objCon.strDate(sTo);
            ToDate = Convert.ToDateTime(objCon.strDate(sTo)).AddDays(1.0).ToString("dd-MMM-yyyy");
        }
        if (FromDate != "" && ToDate != "")
            sSql += " AND (Case_Rec_dateTime >='" + objCon.FixQuotes(FromDate) + "'" + "and Case_Rec_dateTime<'" + objCon.FixQuotes(ToDate) + "')";

        sSql += " ORDER BY CASE_ID DESC";

        return sSql;
    }
    public Int32 DeleteRLCaseEntry(string sCaseID)
    {
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        Int32 nretVal = 0;
        string sSql = "";
        try
        {
            sSql = "Delete from CPV_RL_CASE_VERIFICATIONTYPE WHERE Case_Id='" + sCaseID + "'";
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);

            sSql = "Delete from CPV_RL_CASE_DETAILS WHERE Case_ID='" + sCaseID + "'";
            nretVal = OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);

            oledbTrans.Commit();
            oledbConn.Close();

            return nretVal;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error while deleting CaseCreditCardEntry " + ex.Message);
        }

    }
    public Int32 UpdateRLCaseEntry(ArrayList arrCaseVerType, string sCaseID)
    {

        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        Int32 nretVal = 0;
        string sSql = "";
        try
        {
            CaseId = sCaseID;
            sSql = "Update CPV_RL_CASE_DETAILS SET CASE_TYPE=?,Case_Rec_dateTime=?, " +
                  "Title=?,First_Name=?,Middle_Name=?,Last_Name=?,Full_Name=?,DOB=?,RES_ADD_LINE_1=?,RES_ADD_LINE_2=?," +
                  "RES_ADD_LINE_3=?,RES_City=?,Res_Pin_code=?,Res_Land_Mark=?,Res_Phone=?,Mobile=?,OFF_NAME=?,OFF_ADD_LINE_1=?,OFF_ADD_LINE_2=?," +
                  "OFF_ADD_LINE_3=?,Off_city=?,Off_Pin_Code=?,Off_Phone=?,Off_Extn=?,Designation=?,Department=?,Occupation=?,Priority=?,Region=?,Spl_Instruction=?," +
                  "Modify_By=?,Modify_Date=?,VERIFICATION_CODE=?,PRODUCT_TYPE=?,PRODUCT_NAME=?,PRODUCT_PRICE=?,EMPLOYEE_TYPE=?,REFERENCE1=?,REFERENCE2=?,REFERENCE1_TEL=?,REFERENCE2_TEL=?,Channel_Name= ?,App_Type=?,Ref_No=? " +
                  " WHERE Case_Id=?";

            OleDbParameter[] paramRL = new OleDbParameter[45];
            paramRL[0] = new OleDbParameter("@CASE_TYPE", OleDbType.VarChar, 10);
            paramRL[0].Value = CaseType;
            paramRL[1] = new OleDbParameter("@Case_Recv_dateTime", OleDbType.DBTimeStamp,8);
            paramRL[1].Value = ReceivedDateTime;
            paramRL[2] = new OleDbParameter("@Title", OleDbType.VarChar, 20);
            paramRL[2].Value = Title;
            paramRL[3] = new OleDbParameter("@First_Name", OleDbType.VarChar,500);
            paramRL[3].Value = FirstName;
            paramRL[4] = new OleDbParameter("@Middle_Name", OleDbType.VarChar,100);
            paramRL[4].Value = MiddleName;
            paramRL[5] = new OleDbParameter("@Last_Name", OleDbType.VarChar,100);
            paramRL[5].Value = LastName;
            paramRL[6] = new OleDbParameter("@Full_Name", OleDbType.VarChar,350);
            paramRL[6].Value = FullName;
            paramRL[7] = new OleDbParameter("@DOB", OleDbType.VarChar,50);
            paramRL[7].Value = DOB;
            paramRL[8] = new OleDbParameter("@RES_ADD_LINE_1", OleDbType.VarChar,100);
            paramRL[8].Value = ResAdd1;
            paramRL[9] = new OleDbParameter("@RES_ADD_LINE_2", OleDbType.VarChar,50);
            paramRL[9].Value = ResAdd2;
            paramRL[10] = new OleDbParameter("@RES_ADD_LINE_3", OleDbType.VarChar,50);
            paramRL[10].Value = ResAdd3;
            paramRL[11] = new OleDbParameter("@RES_City", OleDbType.VarChar,100);
            paramRL[11].Value = ResCity;
           
            paramRL[12] = new OleDbParameter("@Res_Pin_code", OleDbType.VarChar,10);
            paramRL[12].Value = ResPin;
            paramRL[13] = new OleDbParameter("@Res_Land_Mark", OleDbType.VarChar, 100);
            paramRL[13].Value = ResLandMark;
            paramRL[14] = new OleDbParameter("@Res_Phone", OleDbType.VarChar, 100);
            paramRL[14].Value = ResPhone;
            paramRL[15] = new OleDbParameter("@MOBILE", OleDbType.VarChar, 100);
            paramRL[15].Value = ResMobile;
            paramRL[16] = new OleDbParameter("@OFF_NAME", OleDbType.VarChar, 100);
            paramRL[16].Value = OfficeName;
            paramRL[17] = new OleDbParameter("@OFF_ADD_LINE_1", OleDbType.VarChar,100);
            paramRL[17].Value = OfficeAdd1;
            paramRL[18] = new OleDbParameter("@OFF_ADD_LINE_2", OleDbType.VarChar,100);
            paramRL[18].Value = OfficeAdd2;
            paramRL[19] = new OleDbParameter("@OFF_ADD_LINE_3", OleDbType.VarChar,100);
            paramRL[19].Value = OfficeAdd3;
            paramRL[20] = new OleDbParameter("@OFF_CITY", OleDbType.VarChar,100);
            paramRL[20].Value = OfficeCity;
           
            paramRL[21] = new OleDbParameter("@OFF_PIN_CODE", OleDbType.VarChar,50);
            paramRL[21].Value = OfficePin;
            paramRL[22] = new OleDbParameter("@OFF_PHONE", OleDbType.VarChar,50);
            paramRL[22].Value = OfficePhone;
            paramRL[23] = new OleDbParameter("@OFF_EXTN", OleDbType.VarChar,10);
            paramRL[23].Value = OfficeExtn;
            paramRL[24] = new OleDbParameter("@Designation", OleDbType.VarChar,100);
            paramRL[24].Value = Designation;
            paramRL[25] = new OleDbParameter("@DEPARTMENT", OleDbType.VarChar,100);
            paramRL[25].Value = Department;
            paramRL[26] = new OleDbParameter("@OCCUPATION", OleDbType.VarChar,100);
            paramRL[26].Value = Occupation;
            paramRL[27] = new OleDbParameter("@Priority", OleDbType.VarChar,10);
            paramRL[27].Value = Priority;
            paramRL[28] = new OleDbParameter("@REGION", OleDbType.VarChar,50);
            paramRL[28].Value = Region;
            paramRL[29] = new OleDbParameter("@SPL_INSTRUCTION", OleDbType.VarChar,255);
            paramRL[29].Value = SplInstruction;
          
         
            /*--------------------------end---------------------------*/
            paramRL[30] = new OleDbParameter("@Modify_By", OleDbType.VarChar,15);
            paramRL[30].Value = ModifyBy;
            paramRL[31] = new OleDbParameter("@Modify_Date", OleDbType.DBTimeStamp,8);
            paramRL[31].Value = ModifyOn;
            paramRL[32] = new OleDbParameter("@VerificationCode", OleDbType.VarChar,100);
            paramRL[32].Value = VerificationCode;


            paramRL[33] = new OleDbParameter("@Product_Type", OleDbType.VarChar, 100);
            paramRL[33].Value = ProductType;
            paramRL[34] = new OleDbParameter("@Product_name", OleDbType.VarChar, 100);
            paramRL[34].Value = ProductName;
            paramRL[35] = new OleDbParameter("@Product_Price", OleDbType.VarChar, 100);
            paramRL[35].Value = ProductPrice;
            paramRL[36] = new OleDbParameter("@Employee_Type", OleDbType.VarChar,100);
            paramRL[36].Value = EmployeeType;
            paramRL[37] = new OleDbParameter("@Reference1", OleDbType.VarChar,50);
            paramRL[37].Value = Reference1;
            paramRL[38] = new OleDbParameter("@Reference2", OleDbType.VarChar,50);
            paramRL[38].Value = Reference2;
            paramRL[39] = new OleDbParameter("@Telphone1", OleDbType.VarChar,50);
            paramRL[39].Value = Telephone1;
            paramRL[40] = new OleDbParameter("@Telphone2", OleDbType.VarChar,50);
            paramRL[40].Value = Telephone2;
            paramRL[41] = new OleDbParameter("@ChannelName", OleDbType.VarChar, 100);
            paramRL[41].Value = ChannelName;
            paramRL[42] = new OleDbParameter("@AppType", OleDbType.VarChar, 100);
            paramRL[42].Value = AppType;

            paramRL[43] = new OleDbParameter("@RefNo", OleDbType.VarChar, 15);
            paramRL[43].Value = RefNo;

            paramRL[44] = new OleDbParameter("@Case_Id", OleDbType.VarChar,15);
            paramRL[44].Value = CaseId;

            if (arrCaseVerType.Count > 0)
                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramRL);
            else
                nretVal = OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramRL);


            sSql = "Delete from CPV_RL_CASE_VERIFICATIONTYPE WHERE Case_Id='" + CaseId + "'";
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);

            foreach (string item in arrCaseVerType)
            {
                sVerTypeId = item;
                sSql = "";

                sSql = "";
                sSql = "Insert into CPV_RL_CASE_VERIFICATIONTYPE(Case_Id,Verification_Type_ID)" +
                       "Values(?,?)";

                OleDbParameter[] paramCaseVerType = new OleDbParameter[2];
                paramCaseVerType[0] = new OleDbParameter("@CaseId", OleDbType.VarChar);
                paramCaseVerType[0].Value = CaseId;
                paramCaseVerType[1] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar);
                paramCaseVerType[1].Value = VerficationTypeID;

                nretVal = OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramCaseVerType);
            }
            oledbTrans.Commit();
            oledbConn.Close();

            return nretVal;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error while updating Retail Loan Entry " + ex.Message);
        }
    }
    public Int32 InsertRLCaseEntry(ArrayList arrCaseVerType, string strPrefix)
    {
        OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
        oledbConn.Open();
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        Int32 nretVal = 0;
        try
        {
            CaseId = objCon.GetUniqueID("CPV_RL_CASE_DETAILS", strPrefix).ToString();

            string sSql = "";
            //sSql = "Insert into CPV_CC_CASE_DETAILS(Case_Id,Cluster_Id,Centre_Id,Ref_No,Case_Recv_date, " +
            //      "Title,First_Name,Middle_Name,Last_Name,DOB,RES_ADD_LINE_1,RES_ADD_LINE_2," +
            //      "RES_ADD_LINE_3,RES_City,Res_Pin_code,Res_Land_Mark,Res_Phone,OFF_ADD_LINE_1,OFF_ADD_LINE_2," +
            //      "OFF_ADD_LINE_3,Off_city,Off_Pin_Code,Off_Phone,Off_Extn,Designation,Department,Occupation,Add_By,Add_Date) " +
            //      "Values(?CaseID,?Cluster_Id,?Centre_Id,?Ref_No,?Case_Recv_date, " +
            //      "?Title,?First_Name,?Middle_Name,?Last_Name,?DOB,?RES_ADD_LINE_1,?RES_ADD_LINE_2," +
            //      "?RES_ADD_LINE_3,?RES_City,?Res_Pin_code,?Res_Land_Mark,?Res_Phone,?OFF_ADD_LINE_1,?OFF_ADD_LINE_2," +
            //      "?OFF_ADD_LINE_3,?Off_city,?Off_Pin_Code,?Off_Phone,?Off_Extn,?Designation,?Department,?Occupation,?AddedBy,?AddedOn)";

            sSql = "Insert into CPV_RL_CASE_DETAILS( Case_Id,Cluster_Id,Centre_Id,Ref_No,CASE_TYPE,Case_Rec_dateTime, " +
                  "Title,First_Name,Middle_Name,Last_Name,Full_Name,DOB,RES_ADD_LINE_1,RES_ADD_LINE_2," +
                  "RES_ADD_LINE_3,RES_City,Res_Pin_code,Res_Land_Mark,Res_Phone,Mobile,OFF_NAME,EMPLOYEE_TYPE,OFF_ADD_LINE_1,OFF_ADD_LINE_2," +
                  "OFF_ADD_LINE_3,Off_city,PRODUCT_TYPE,Off_Pin_Code,Off_Phone,Off_Extn,Designation,Department,Occupation,Priority,Region," +
                  "SPL_Instruction, " +
                  "Add_By,PRODUCT_NAME,Add_Date,PRODUCT_PRICE,Client_Id,VERIFICATION_CODE,REFERENCE1,REFERENCE1_TEL,REFERENCE2,REFERENCE2_TEL,Channel_Name,App_Type) " +
                  "Values(?,?,?,?,?,?, " +
                  "?,?,?,?,?,?,?,?," +
                  "?,?,?,?,?,?,?,?,?,?," +
                  "?,?,?,?,?,?,?,?,?,?,?," +
                  "?,?,?,?,?,?,?,?,?,?,?,?,? )";


            OleDbParameter[] paramRL = new OleDbParameter[48];

            paramRL[0] = new OleDbParameter("@Case_Id", OleDbType.VarChar, 15);
            paramRL[0].Value = CaseId;
            paramRL[1] = new OleDbParameter("@Cluster_Id", OleDbType.VarChar, 15);
            paramRL[1].Value = ClusterId;
            paramRL[2] = new OleDbParameter("@Centre_Id", OleDbType.VarChar, 15);
            paramRL[2].Value = CentreId;
            paramRL[3] = new OleDbParameter("@Ref_No", OleDbType.VarChar, 50);
            paramRL[3].Value = RefNo;
            paramRL[4] = new OleDbParameter("@CASE_TYPE", OleDbType.VarChar, 10);
            paramRL[4].Value = CaseType;
            paramRL[5] = new OleDbParameter("@Case_Rec_dateTime", OleDbType.DBTimeStamp,8);
            paramRL[5].Value = ReceivedDateTime;
            paramRL[6] = new OleDbParameter("@Title", OleDbType.VarChar, 20);
            paramRL[6].Value = Title;
            paramRL[7] = new OleDbParameter("@First_Name", OleDbType.VarChar,500);
            paramRL[7].Value = FirstName;
            paramRL[8] = new OleDbParameter("@Middle_Name", OleDbType.VarChar,100);
            paramRL[8].Value = MiddleName;
            paramRL[9] = new OleDbParameter("@Last_Name", OleDbType.VarChar,100);
            paramRL[9].Value = LastName;
            paramRL[10] = new OleDbParameter("@Full_Name", OleDbType.VarChar,350);
            paramRL[10].Value = FullName;
            paramRL[11] = new OleDbParameter("@DOB", OleDbType.VarChar, 50);
            paramRL[11].Value = DOB;
            paramRL[12] = new OleDbParameter("@RES_ADD_LINE_1", OleDbType.VarChar, 100);
            paramRL[12].Value = ResAdd1;
            paramRL[13] = new OleDbParameter("@RES_ADD_LINE_2", OleDbType.VarChar,50);
            paramRL[13].Value = ResAdd2;
            paramRL[14] = new OleDbParameter("@RES_ADD_LINE_3", OleDbType.VarChar,50);
            paramRL[14].Value = ResAdd3;
            paramRL[15] = new OleDbParameter("@RES_City", OleDbType.VarChar, 100);
            paramRL[15].Value = ResCity;

            paramRL[16] = new OleDbParameter("@Res_Pin_code", OleDbType.VarChar,10);
            paramRL[16].Value = ResPin;
            paramRL[17] = new OleDbParameter("@Res_Land_Mark", OleDbType.VarChar, 100);
            paramRL[17].Value = ResLandMark;
            paramRL[18] = new OleDbParameter("@Res_Phone", OleDbType.VarChar, 100);
            paramRL[18].Value = ResPhone;
            /*......................adding by chinu...............................*/
            paramRL[19] = new OleDbParameter("@Mobile", OleDbType.VarChar, 100);
            paramRL[19].Value = ResMobile;
            paramRL[20] = new OleDbParameter("@OFF_NAME", OleDbType.VarChar, 100);
            paramRL[20].Value = OfficeName;
            paramRL[21] = new OleDbParameter("@Employee_Type", OleDbType.VarChar,100);
            paramRL[21].Value = EmployeeType;
            /*..........................end..........................................*/
            paramRL[22] = new OleDbParameter("@OFF_ADD_LINE_1", OleDbType.VarChar, 100);
            paramRL[22].Value = OfficeAdd1;
            paramRL[23] = new OleDbParameter("@OFF_ADD_LINE_2", OleDbType.VarChar,100);
            paramRL[23].Value = OfficeAdd2;
            paramRL[24] = new OleDbParameter("@OFF_ADD_LINE_3", OleDbType.VarChar,100);
            paramRL[24].Value = OfficeAdd3;
            paramRL[25] = new OleDbParameter("@Off_city", OleDbType.VarChar,100);
            paramRL[25].Value = OfficeCity;
            paramRL[26] = new OleDbParameter("@Product_Type", OleDbType.VarChar,100);
            paramRL[26].Value = ProductType;
            paramRL[27] = new OleDbParameter("@OfficePin", OleDbType.VarChar,50);
            paramRL[27].Value = OfficePin;
            paramRL[28] = new OleDbParameter("@OfficePhone", OleDbType.VarChar,50);
            paramRL[28].Value = OfficePhone;
            paramRL[29] = new OleDbParameter("@OfficeExtn", OleDbType.VarChar,10);
            paramRL[29].Value = OfficeExtn;
            paramRL[30] = new OleDbParameter("@Designation", OleDbType.VarChar,100);
            paramRL[30].Value = Designation;
            paramRL[31] = new OleDbParameter("@Department", OleDbType.VarChar,100);
            paramRL[31].Value = Department;
            paramRL[32] = new OleDbParameter("@Occupation", OleDbType.VarChar);
            paramRL[32].Value = Occupation;
            /*..............................Adding by chinu...............................*/
            paramRL[33] = new OleDbParameter("@Priority", OleDbType.VarChar,100);
            paramRL[33].Value = Priority;
            paramRL[34] = new OleDbParameter("@Region", OleDbType.VarChar,50);
            paramRL[34].Value = Region;
            paramRL[35] = new OleDbParameter("@SplInstruction", OleDbType.VarChar,255);
            paramRL[35].Value = SplInstruction;
            /*......................Adding by chinu(permanent Address)..............................*/


            paramRL[36] = new OleDbParameter("@AddedBy", OleDbType.VarChar,15);
            paramRL[36].Value = AddedBy;
            paramRL[37] = new OleDbParameter("@ProductName", OleDbType.VarChar, 100);
            paramRL[37].Value = ProductName;
            paramRL[38] = new OleDbParameter("@AddedOn", OleDbType.DBTimeStamp,8);
            paramRL[38].Value = AddedOn;

            paramRL[39] = new OleDbParameter("@ProductPrice", OleDbType.VarChar, 100);
            paramRL[39].Value = ProductPrice;

            paramRL[40] = new OleDbParameter("@ClientId", OleDbType.VarChar,15);
            paramRL[40].Value = ClientId;
            paramRL[41] = new OleDbParameter("@VerificationCode", OleDbType.VarChar,100);
            paramRL[41].Value = VerificationCode;
            paramRL[42] = new OleDbParameter("@Reference1", OleDbType.VarChar,50);
            paramRL[42].Value =Reference1;

            paramRL[43] = new OleDbParameter("@Telephone1", OleDbType.VarChar,50);
            paramRL[43].Value =Telephone1;
            paramRL[44] = new OleDbParameter("@Reference2", OleDbType.VarChar,50);
            paramRL[44].Value = Reference2;

            paramRL[45] = new OleDbParameter("@Telephone2", OleDbType.VarChar,50);
            paramRL[45].Value = Telephone2;
            paramRL[46] = new OleDbParameter("@ChannelName", OleDbType.VarChar, 100);
            paramRL[46].Value = ChannelName;
            paramRL[47] = new OleDbParameter("@AppType", OleDbType.VarChar, 100);
            paramRL[47].Value = AppType; 
            if (arrCaseVerType.Count > 0)
                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramRL);
            else
                nretVal = OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramRL);

            foreach (string item in arrCaseVerType)
            {
                sVerTypeId = item;
                sSql = "";
                sSql = "Insert into CPV_RL_CASE_VERIFICATIONTYPE(Case_Id,Verification_Type_ID)" +
                       "Values(?,?)";

                OleDbParameter[] paramCaseVerType = new OleDbParameter[2];
                paramCaseVerType[0] = new OleDbParameter("@CaseId", OleDbType.VarChar);
                paramCaseVerType[0].Value = CaseId;
                paramCaseVerType[1] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar);
                paramCaseVerType[1].Value = VerficationTypeID;

                nretVal = OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql, paramCaseVerType);
            }
            oledbTrans.Commit();
            oledbConn.Close();

            return nretVal;
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            oledbConn.Close();
            throw new Exception("Error while Inserting Retail Loan Entry " + ex.Message);
        }
    }

}
