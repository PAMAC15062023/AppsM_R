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
/// Summary description for CIDOC_RC_Verification
/// </summary>
public class CIDOC_RC_Verification
{private CCommon objCon;
	public CIDOC_RC_Verification()
	{
        objCon = new CCommon();

		//
		// TODO: Add constructor logic here
		//
    }
    #region Properties Declaration
    private string strCaseID;
    private string strVerificationTypeID;
    private string strDateOfReceipt;
    private string strCPAReferenceNumber;
    private string strBankReferenceNumber;
    private string strNameOfApplicant;
    private string strRegistrationNumberOfVehicle;
    private string strRTOOffice;
    private string strAddressFallsUnderJurisdictionOfRTO;
    private string strOtherObservation;
    private string strRCDetailsConfirmedWith;
    private string strRegistrationNumberOfVehicleIsCorrect;
    private string strWhetherTheVehicleIsPersonalCommercial;
    private string strIsVehicleHypothecated;
    private string strIfYesNameOfFinancer;
    private string strDateOfRegistrationAsPerRCRegister;
    private string strDetailsOfTransferIfAny;
    private string strFinalStatus;
    private string strRemark;
    private string strNameOfVerifier;
    private string strDate;

    //added by hemangi kambli on 03/10/2007 ----
    private DateTime dtTransStart;
    private DateTime dtTransEnd;
    private string sUserId;
    private string sCentreId;
    private string sProductId;
    private string sClientId;
    private string strSupervisor_sign;


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

    public string Supervisor_sign
    {
        get
        {
            return strSupervisor_sign;
        }
        set
        {
            strSupervisor_sign = value;
        }
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
    public string DateOfReceipt
    {
        get
        {
            return strDateOfReceipt;
        }
        set
        {
            strDateOfReceipt = value;
        }
    }
    public string CPAReferenceNumber
    {
        get
        {
            return strCPAReferenceNumber;
        }
        set
        {
            strCPAReferenceNumber = value;
        }
    }
    public string BankReferenceNumber
    {
        get
        {
            return strBankReferenceNumber;
        }
        set
        {
            strBankReferenceNumber = value;
        }
    }
    public string NameOfApplicant
    {
        get
        {
            return strNameOfApplicant;
        }
        set
        {
            strNameOfApplicant = value;
        }
    }
    public string RegistrationNumberOfVehicle
    {
        get
        {
            return strRegistrationNumberOfVehicle;
        }
        set
        {
            strRegistrationNumberOfVehicle = value;
        }
    }
    public string RTOOffice
    {
        get
        {
            return strRTOOffice;
        }
        set
        {
            strRTOOffice = value;
        }
    }
    public string AddressFallsUnderJurisdictionOfRTO
    {
        get
        {
            return strAddressFallsUnderJurisdictionOfRTO;
        }
        set
        {
            strAddressFallsUnderJurisdictionOfRTO = value;
        }
    }

    public string OtherObservation
    {
        get
        {
            return strOtherObservation;
        }
        set
        {
            strOtherObservation = value;
        }
    }
    public string WhetherTheVehicleIsPersonalCommercial
    {
        get
        {
            return strWhetherTheVehicleIsPersonalCommercial;
        }
        set
        {
            strWhetherTheVehicleIsPersonalCommercial = value;
        }
    }
    public string RCDetailsConfirmedWith
    {
        get
        {
            return strRCDetailsConfirmedWith;
        }
        set
        {
            strRCDetailsConfirmedWith = value;
        }
    }
    public string RegistrationNumberOfVehicleIsCorrect
    {
        get
        {
            return strRegistrationNumberOfVehicleIsCorrect;
        }
        set
        {
            strRegistrationNumberOfVehicleIsCorrect = value;
        }
    }
    public string IsVehicleHypothecated
    {
        get
        {
            return strIsVehicleHypothecated;
        }
        set
        {
            strIsVehicleHypothecated = value;
        }
    }
    public string IfYesNameOfFinancer
    {
        get
        {
            return strIfYesNameOfFinancer;
        }
        set
        {
            strIfYesNameOfFinancer = value;
        }
    }
    public string DateOfRegistrationAsPerRCRegister
    {
        get
        {
            return strDateOfRegistrationAsPerRCRegister;
        }
        set
        {
            strDateOfRegistrationAsPerRCRegister = value;
        }
    }
    public string DetailsOfTransferIfAny
    {
        get
        {
            return strDetailsOfTransferIfAny;
        }
        set
        {
            strDetailsOfTransferIfAny = value;
        }
    }
    public string FinalStatus
    {
        get
        {
            return strFinalStatus;
        }
        set
        {
            strFinalStatus = value;
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
    public string NameOfVerifier
    {
        get
        {
            return strNameOfVerifier;
        }
        set
        {
            strNameOfVerifier = value;
        }
    }
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
    
    #endregion Properties Declaration

    //comment by:kanchan on 29/9/2014
    

    ////public string InsertIDOCVerificationDetail()
    ////{
    ////    OleDbConnection oledbConn = new OleDbConnection(objCon.ConnectionString);
    ////    oledbConn.Open();
    ////    OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
    ////    OleDbDataReader oledbDR;
    ////    string sqlQuery = "";
    ////    string sql = "";
    ////    string sMsg ="";
    ////    try
    ////    {
    ////        sqlQuery = "Select Case_id,VERIFICATION_TYPE_ID from CPV_IDOC_VERIFICATION_DETAIL " +
    ////                   " where Case_id ='" + CaseID + "'" + "and VERIFICATION_TYPE_ID='" + VerificationTypeID + "'";
    ////        oledbDR = OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sqlQuery);
    ////        OleDbParameter[] oledbParam = new OleDbParameter[10];
    ////        if (oledbDR.Read() == false)
    ////        {
    ////            sql = "Insert into CPV_IDOC_VERIFICATION_DETAIL (Case_id,VERIFICATION_TYPE_ID,RC_Details_Confirmed_With," +
    ////                "Is_Correct_Registration_No_Of_Vehicle,Is_Vehicle_Personal_Commercial,Is_Vehicle_Hypothecated,Fuinancer_Name," +
    ////                "Registration_Date_As_Per_RC_Register,Transfer_Details,Address_Falls_Under_Jurisdiction_RTO) values (?,?,?,?,?,?,?,?,?,?)";

    ////            oledbParam[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
    ////            oledbParam[0].Value=CaseID;

    ////            oledbParam[1] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 10);
    ////            oledbParam[1].Value = VerificationTypeID;

    ////            oledbParam[2] = new OleDbParameter("@RCDetailsConfirmedWith", OleDbType.VarChar, 50);
    ////            oledbParam[2].Value = RCDetailsConfirmedWith;

    ////            oledbParam[3] = new OleDbParameter("@RegistrationNumberOfVehicleIsCorrect", OleDbType.VarChar, 50);
    ////            oledbParam[3].Value = RegistrationNumberOfVehicleIsCorrect;

    ////            oledbParam[4] = new OleDbParameter("@WhetherTheVehicleIsPersonalCommercial", OleDbType.VarChar, 50);
    ////            oledbParam[4].Value = WhetherTheVehicleIsPersonalCommercial;

    ////            oledbParam[5] = new OleDbParameter("@IsVehicleHypothecated", OleDbType.VarChar, 50);
    ////            oledbParam[5].Value = IsVehicleHypothecated;

    ////            oledbParam[6] = new OleDbParameter("@IfYesNameOfFinancer", OleDbType.VarChar, 50);
    ////            oledbParam[6].Value = IfYesNameOfFinancer;

    ////            oledbParam[7] = new OleDbParameter("@DateOfRegistrationAsPerRCRegister", OleDbType.VarChar, 50);
    ////            oledbParam[7].Value = DateOfRegistrationAsPerRCRegister ;

    ////            oledbParam[8] = new OleDbParameter("@DetailsOfTransferIfAny", OleDbType.VarChar, 50);
    ////            oledbParam[8].Value = DetailsOfTransferIfAny;

    ////            oledbParam[9] = new OleDbParameter("@AddressFallsUnderJurisdictionOfRTO", OleDbType.VarChar, 50);
    ////            oledbParam[9].Value = AddressFallsUnderJurisdictionOfRTO;

    ////            sMsg = "Record Added successfully.";


    ////        }
    ////        else
    ////        {
    ////            sql = "Update CPV_IDOC_VERIFICATION_DETAIL set RC_Details_Confirmed_With=?,Is_Correct_Registration_No_Of_Vehicle=?," +
    ////                "Is_Vehicle_Personal_Commercial=?,Is_Vehicle_Hypothecated=?,Fuinancer_Name=?,Registration_Date_As_Per_RC_Register=?," +
    ////                "Transfer_Details=?,Address_Falls_Under_Jurisdiction_RTO=? where Case_id=? and VERIFICATION_TYPE_ID=?";


    ////            oledbParam[0] = new OleDbParameter("@RCDetailsConfirmedWith", OleDbType.VarChar, 50);
    ////            oledbParam[0].Value = RCDetailsConfirmedWith;

    ////            oledbParam[1] = new OleDbParameter("@RegistrationNumberOfVehicleIsCorrect", OleDbType.VarChar, 50);
    ////            oledbParam[1].Value = RegistrationNumberOfVehicleIsCorrect;

    ////            oledbParam[2] = new OleDbParameter("@WhetherTheVehicleIsPersonalCommercial", OleDbType.VarChar, 50);
    ////            oledbParam[2].Value = WhetherTheVehicleIsPersonalCommercial;

    ////            oledbParam[3] = new OleDbParameter("@IsVehicleHypothecated", OleDbType.VarChar, 50);
    ////            oledbParam[3].Value = IsVehicleHypothecated;

    ////            oledbParam[4] = new OleDbParameter("@IfYesNameOfFinancer", OleDbType.VarChar, 50);
    ////            oledbParam[4].Value = IfYesNameOfFinancer;

    ////            oledbParam[5] = new OleDbParameter("@DateOfRegistrationAsPerRCRegister", OleDbType.VarChar, 50);
    ////            oledbParam[5].Value = DateOfRegistrationAsPerRCRegister;

    ////            oledbParam[6] = new OleDbParameter("@DetailsOfTransferIfAny", OleDbType.VarChar, 50);
    ////            oledbParam[6].Value = DetailsOfTransferIfAny;

    ////            oledbParam[7] = new OleDbParameter("@AddressFallsUnderJurisdictionOfRTO", OleDbType.VarChar, 50);
    ////            oledbParam[7].Value = AddressFallsUnderJurisdictionOfRTO;


    ////            oledbParam[8] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
    ////            oledbParam[8].Value = CaseID;

    ////            oledbParam[9] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 10);
    ////            oledbParam[9].Value = VerificationTypeID;

    ////            sMsg = "Record updated successfully.";
 
    ////        }
    ////        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql, oledbParam);

    ////        //////////////////////////////Inserting in table CPV_IDOC_VERIFICATION

    ////        sqlQuery = "Select CASE_ID,VERIFICATION_TYPE_ID from CPV_IDOC_VERIFICATION " +
    ////                         "where CASE_ID='" + CaseID + "'" + "and VERIFICATION_TYPE_ID='" + VerificationTypeID + "'";
    ////        oledbDR = OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sqlQuery);
    ////        OleDbParameter[] oledbParamVeri = new OleDbParameter[9];
    ////        if (oledbDR.Read() == false)
    ////        {
    ////            sql = " Insert into CPV_IDOC_VERIFICATION (CASE_ID,VERIFICATION_TYPE_ID, " +
    ////                       " Other_observation,FE_VISIT_DATE," +
    ////                       " CASE_STATUS_ID,FE_REMARK,ADD_BY,ADD_DATE,Supervisor_sign)" +
    ////                        " Values(?,?,?,?,?,?,?,?,?)";


    ////            oledbParamVeri[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
    ////            oledbParamVeri[0].Value = CaseID;

    ////            oledbParamVeri[1] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 10);
    ////            oledbParamVeri[1].Value = VerificationTypeID;

    ////            oledbParamVeri[2] = new OleDbParameter("@OtherObservation", OleDbType.VarChar, 255);
    ////            oledbParamVeri[2].Value = OtherObservation;

    ////            oledbParamVeri[3] = new OleDbParameter("@Date", OleDbType.VarChar, 11);
    ////            oledbParamVeri[3].Value = Date;

    ////            oledbParamVeri[4] = new OleDbParameter("@FinalStatus", OleDbType.VarChar, 15);
    ////            oledbParamVeri[4].Value = FinalStatus;

    ////            oledbParamVeri[5] = new OleDbParameter("@Remark", OleDbType.VarChar, 2000);
    ////            oledbParamVeri[5].Value = Remark;

    ////            oledbParamVeri[6] = new OleDbParameter("@AddedBy", OleDbType.VarChar, 15);
    ////            oledbParamVeri[6].Value = HttpContext.Current.Session["UserId"];

    ////            oledbParamVeri[7] = new OleDbParameter("@AddedDate", OleDbType.DBTimeStamp, 8);
    ////            oledbParamVeri[7].Value = System.DateTime.Now;

    ////            oledbParamVeri[8] = new OleDbParameter("@Supervisor_sign", OleDbType.VarChar, 255);
    ////            oledbParamVeri[8].Value = Supervisor_sign;



    ////            sMsg = "Record added successfully.";
    ////        }
    ////        else
    ////        {
    ////            //////////////////////////////Updating in table CPV_IDOC_VERIFICATION
    ////            sql = "Update CPV_IDOC_VERIFICATION set " +
    ////                       "Other_observation=?,FE_VISIT_DATE=?, " +
    ////                       "CASE_STATUS_ID=?,FE_REMARK=?,MODIFY_BY=?,MODIFY_DATE=?,Supervisor_sign=?  " +
    ////                       "where CASE_ID=? and VERIFICATION_TYPE_ID=?";


    ////            oledbParamVeri[0] = new OleDbParameter("@OtherObservation", OleDbType.VarChar, 255);
    ////            oledbParamVeri[0].Value = OtherObservation;

    ////            oledbParamVeri[1] = new OleDbParameter("@Date", OleDbType.VarChar, 11);
    ////            oledbParamVeri[1].Value = Date;

    ////            oledbParamVeri[2] = new OleDbParameter("@FinalStatus", OleDbType.VarChar, 15);
    ////            oledbParamVeri[2].Value = FinalStatus;

    ////            oledbParamVeri[3] = new OleDbParameter("@Remark", OleDbType.VarChar, 2000);
    ////            oledbParamVeri[3].Value = Remark;


    ////            oledbParamVeri[4] = new OleDbParameter("@ModifiedBy", OleDbType.VarChar, 15);
    ////            oledbParamVeri[4].Value = HttpContext.Current.Session["UserId"];

    ////            oledbParamVeri[5] = new OleDbParameter("@ModifiedDate", OleDbType.DBTimeStamp, 8);
    ////            oledbParamVeri[5].Value = System.DateTime.Now;

    ////            oledbParamVeri[6] = new OleDbParameter("@Supervisor_sign", OleDbType.VarChar, 255);
    ////            oledbParamVeri[6].Value = Supervisor_sign;

    ////            oledbParamVeri[7] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
    ////            oledbParamVeri[7].Value = CaseID;

    ////            oledbParamVeri[8] = new OleDbParameter("@VerificationTypeID", OleDbType.VarChar, 10);
    ////            oledbParamVeri[8].Value = VerificationTypeID;

    ////            sMsg = "Record updated successfully.";

    ////        }
    ////        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql, oledbParamVeri);
            
    ////        //Start Insert into CASE_TRANSACTION_LOG -------------------
    ////        sql = "";
    ////        sql = "Insert into CASE_TRANSACTION_LOG(CASE_ID,VERIFICATION_TYPE_ID,USER_ID,TRANS_START,TRANS_END," +
    ////             "CENTRE_ID,PRODUCT_ID,CLIENT_ID) VALUES(?,?,?,?,?,?,?,?)";

    ////        OleDbParameter[] paramTransLog = new OleDbParameter[8];
    ////        paramTransLog[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
    ////        paramTransLog[0].Value = CaseID;
    ////        paramTransLog[1] = new OleDbParameter("@VerficationTypeID", OleDbType.VarChar, 15);
    ////        paramTransLog[1].Value = VerificationTypeID;
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

            
    ////        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql, paramTransLog);

    ////        //End  Insert into CASE_TRANSACTION_LOG --------------------
    ////        //Update CPV_CC_Case_details with status 'Y' ---------------
    ////        if (IsVerificationComplete(oledbTrans, CaseID, ClientId, CentreId) == "true")
    ////        {
    ////            VerificationComplete(oledbTrans, CaseID);
    ////            sMsg += " Case verification data entry completed.";
    ////        }
    ////        /////////////////////////////////////////////////////////////////////////////////////////////

            
    ////        oledbTrans.Commit();
    ////        oledbConn.Close();
    ////        return sMsg;
    ////    }
    ////    catch (Exception ex)
    ////    {
    ////        oledbTrans.Rollback();
    ////        oledbConn.Close();
    ////        throw new Exception("error found during inseration" + ex.Message);
    ////    }
    ////}


    //---------------------------------------------------------------------------------------------------------------

    //ADD By :Akanksha
    //ADD date : 29/09/2014

    public string InsertIDOCVerificationDetail()
    {
        Int32 i = 0;
        string sRetVal = "";

        try
        {
            using (SqlConnection con = new SqlConnection(objCon.AppConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_IDOC_RCVerification_InsertIDOCVerificationDetail", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Case_id", CaseID);
                command.Parameters.AddWithValue("@VERIFICATION_TYPE_ID", VerificationTypeID);

                command.Parameters.AddWithValue("@RC_Details_Confirmed_With", RCDetailsConfirmedWith);
                command.Parameters.AddWithValue("@Is_Correct_Registration_No_Of_Vehicle", RegistrationNumberOfVehicleIsCorrect);

                command.Parameters.AddWithValue("@Is_Vehicle_Personal_Commercial", WhetherTheVehicleIsPersonalCommercial);
                command.Parameters.AddWithValue("@Is_Vehicle_Hypothecated", IsVehicleHypothecated);

                command.Parameters.AddWithValue("@Fuinancer_Name", IfYesNameOfFinancer);
                command.Parameters.AddWithValue("@Registration_Date_As_Per_RC_Register", DateOfRegistrationAsPerRCRegister);

                command.Parameters.AddWithValue("@Transfer_Details", DetailsOfTransferIfAny);
                command.Parameters.AddWithValue("@Address_Falls_Under_Jurisdiction_RTO", AddressFallsUnderJurisdictionOfRTO);



                con.Open();
                i = command.ExecuteNonQuery();
                con.Close();
            }

        }
        catch
        {

        }


        //////////////////////////////Inserting in table CPV_IDOC_VERIFICATION

        try
        {
            using (SqlConnection con = new SqlConnection(objCon.AppConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_IDOC_RCVerification_CPV_IDOC_VERIFICATION_InsertIDOCVerificationDetail", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@CASE_ID", CaseID);
                command.Parameters.AddWithValue("@VERIFICATION_TYPE_ID", VerificationTypeID);

                command.Parameters.AddWithValue("@Other_observation", OtherObservation);
                command.Parameters.AddWithValue("@FE_VISIT_DATE", Date);

                command.Parameters.AddWithValue("@CASE_STATUS_ID", FinalStatus);
                command.Parameters.AddWithValue("@FE_REMARK", Remark);

                command.Parameters.AddWithValue("@ADD_BY", HttpContext.Current.Session["UserId"]);
                command.Parameters.AddWithValue("@ADD_DATE", System.DateTime.Now);

                command.Parameters.AddWithValue("@Supervisor_sign", Supervisor_sign);
                command.Parameters.AddWithValue("@MODIFY_BY", HttpContext.Current.Session["UserId"]);

                command.Parameters.AddWithValue("@MODIFY_DATE", System.DateTime.Now);

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
            using (SqlConnection con = new SqlConnection(objCon.AppConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_CASE_TRANSACTION_LOG_InsertUpdateIDOCformat", con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@CASE_ID", CaseID);
                command.Parameters.AddWithValue("@VERIFICATION_TYPE_ID", VerificationTypeID);

                command.Parameters.AddWithValue("@USER_ID", UserId);
                command.Parameters.AddWithValue("@TRANS_START", TransStart);

                command.Parameters.AddWithValue("@TRANS_END", TransEnd);
                command.Parameters.AddWithValue("@CENTRE_ID", CentreId);

                command.Parameters.AddWithValue("@PRODUCT_ID", ProductId);
                command.Parameters.AddWithValue("@CLIENT_ID", ClientId);

                //----Modify by:akanksha
                //----Modify Date : 11/09/2014

                if (IsVerificationComplete(CaseID, ClientId, CentreId) == "true")
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
    //----------------comp----------------------



    //---------------------------------------------------------------------------------------------------------------------


    //comment by kanchan on 1/10/2014
    ////public OleDbDataReader GetIDOCVerificationDetail(string sCaseID,string sVerificationTypeID)
    ////{
    ////    string sql = "";
    ////    sql = "Select RC_Details_Confirmed_With,Is_Correct_Registration_No_Of_Vehicle,Is_Vehicle_Personal_Commercial,"+
    ////           "Is_Vehicle_Hypothecated,Fuinancer_Name,Registration_Date_As_Per_RC_Register,Transfer_Details,Address_Falls_Under_Jurisdiction_RTO from CPV_IDOC_VERIFICATION_DETAIL " +
    ////           " where CASE_ID='" + sCaseID + "'" + "and VERIFICATION_TYPE_ID='" + sVerificationTypeID + "'";
    ////    return OleDbHelper.ExecuteReader(objCon.ConnectionString,CommandType.Text,sql);
 
    ////}

    // ADD by :Akanksha
    // ADD date : 1/10/2014
    public DataSet GetIDOCVerificationDetail(string sCaseID, string sVerificationTypeID)
    {
        SqlConnection con = new SqlConnection(objCon.AppConnectionString);

        SqlCommand command = new SqlCommand("sp_IDOC_RCVerification_GetIDOCVerificationDetail", con);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@Case_ID", sCaseID);
        command.Parameters.AddWithValue("@VERIFICATION_TYPE_ID", sVerificationTypeID);

        con.Open();
        SqlDataAdapter sd1 = new SqlDataAdapter();
        sd1.SelectCommand = command;

        DataSet DataSet = new DataSet();
        sd1.Fill(DataSet);

        con.Close();

        return DataSet;



    }

    //------------------comp----------------



    //comment by kanchan on 1/10/2014
    ////public OleDbDataReader GetIDOCCaseDetail(string sCaseId)
    ////{
    ////    string sSql = "";
    ////    sSql = "SELECT (ISNULL(TITLE,'')+' '+isNull(FIRST_NAME,'')+' '+isnull(MIDDLE_NAME,'')+' '+isnull(LAST_NAME,'')) as FULL_NAME,REF_NO," +
    ////           "Vehicle_Registration_Number,RTO_Office,Case_REC_DATETIME FROM CPV_IDOC_CASE_DETAILS WHERE CASE_ID='" + sCaseId + "'";
    ////    return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    ////}


    // ADD by :Akanksha
    // ADD date : 1/10/2014


    public DataSet GetIDOCCaseDetail(string sCaseId)
    {
        SqlConnection con = new SqlConnection(objCon.AppConnectionString);

        SqlCommand command = new SqlCommand("sp_IDOC_RCVerification_GetIDOCCaseDetail", con);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@Case_ID", sCaseId);


        con.Open();
        SqlDataAdapter sd1 = new SqlDataAdapter();
        sd1.SelectCommand = command;

        DataSet DataSet = new DataSet();
        sd1.Fill(DataSet);

        con.Close();

        return DataSet;



    }


    //--------------comp--------------------

    



    //comment by kanchan on 1/10/2014

    ////public OleDbDataReader GetFEName(string sCaseID, string sVerifyType)
    ////{
    ////    string sSql = "";
    ////    DataTable dt = new DataTable();
    ////    sSql = "Select FULLNAME ,DATE_TIME from FE_VW as v inner join CPV_IDOC_FE_CASE_MAPPING as cm on v.EMP_ID=cm.FE_ID where CASE_ID='" + sCaseID + "'" +
    ////            " And verification_type_id='" + sVerifyType + "'";
    ////    return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
        
    
    ////}



    // Add by :Akanksha
    // Add date : 1/10/2014

    public DataSet GetFEName(string sCaseID, string sVerifyType)
    {
        SqlConnection con = new SqlConnection(objCon.AppConnectionString);

        SqlCommand command = new SqlCommand("sp_IDOC_RCVerification_GetFEName", con);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@Case_ID", sCaseID);
        command.Parameters.AddWithValue("@VERIFICATION_TYPE_ID", sVerifyType);
        con.Open();
        SqlDataAdapter sd1 = new SqlDataAdapter();
        sd1.SelectCommand = command;

        DataSet DataSet = new DataSet();
        sd1.Fill(DataSet);

        con.Close();

        return DataSet;

        
    }


    //--------------comp--------------------


    //comment by kanchan on 1/10/2014
    ////public OleDbDataReader GetIDOCVerification(string sCaseID, string sVerificationTypeID)
    ////{
    ////    string sSql = "";

    ////    sSql = "SELECT Other_observation,FE_VISIT_DATE," +
    ////           "CASE_STATUS_ID,FE_REMARK,Supervisor_sign from CPV_IDOC_VERIFICATION " +
    ////           " where CASE_ID='" + sCaseID + "'" + "and VERIFICATION_TYPE_ID='" + sVerificationTypeID + "'";
    ////    return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);
    ////}


    // ADD by :Akanksha
    // ADD date : 1/10/2014

    public DataSet GetIDOCVerification(string sCaseID, string sVerificationTypeID)
    {
        SqlConnection con = new SqlConnection(objCon.AppConnectionString);

        SqlCommand command = new SqlCommand("sp_IDOC_RCVerification_GetIDOCVerificationReport", con);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@Case_ID", sCaseID);
        command.Parameters.AddWithValue("@VERIFICATION_TYPE_ID", sVerificationTypeID);
        con.Open();
        SqlDataAdapter sd1 = new SqlDataAdapter();
        sd1.SelectCommand = command;

        DataSet DataSet1 = new DataSet();
        sd1.Fill(DataSet1);

        con.Close();

        return DataSet1;


    }


    //--------------comp--------------------



    //----------------------------------------------------------------------------------------------------------------------------------
    //public OleDbDataReader GetIDOCATTEMPTS(string sCaseID, string sVerificationTypeID)
    //{
    //    string sSql = "";
    //    sSql = "SELECT Remark from CPV_IDOC_VERI_ATTEMPTS " +
    //          " where CASE_ID='" + sCaseID + "'" + "and VERIFICATION_TYPE_ID='" + sVerificationTypeID + "'";
    //    return OleDbHelper.ExecuteReader(objCon.ConnectionString, CommandType.Text, sSql);

    //}

    //------------------------------------------------------------------------------------------------------------------------------

    //comment by Kanchan on 29/9/2014
    //// #region IsVerificationComplete
    
    ////public string IsVerificationComplete(OleDbTransaction oledbTrans, string sCaseId, string sClientId, string sCenterId)
    ////{
    ////    string sSql = "";
    ////    OleDbDataReader oledbRead;
    ////    string bComplete = "";
    ////    //sSql = " Select * from CPV_RL_CASE_STATUS_NULL " +
    ////    //       " where case_id='" + sCaseId + "' and Client_id='" + sClientId + "'" +
    ////    //       " and Centre_id='" + sCenterId + "'";

    ////    //sSql = "Select case (select count(*) from CPV_IDOC_VERIFICATION_TYPE " +
    ////    //       " where case_id='" + sCaseId + "') " +
    ////    //       " when (select count(*) from IDOC_IODC_CASE_OUTPUT_VW where case_id='" + sCaseId + "') " +
    ////    //       " then 'true' else 'false' end as IsComplete";

    ////    //modified by hemangi kambli on 15-Nov-2007
    ////    sSql = " Select case (select count(*) from CPV_IDOC_VERIFICATION_TYPE " +
    ////         " where case_id='" + sCaseId + "') " +
    ////         " when (select count(*) from (select distinct verification_type_id from " +
    ////         " IDOC_IODC_CASE_OUTPUT_VW where case_id='" + sCaseId + "') AS A )" +
    ////         " then 'true' else 'false' end as IsComplete";

    ////    oledbRead = OleDbHelper.ExecuteReader(oledbTrans, CommandType.Text, sSql);
    ////    if (oledbRead.Read() == true)
    ////        bComplete = oledbRead["IsComplete"].ToString();

    ////    return bComplete;
    ////}

    ////#endregion IsVerificationComplete


    //-----------------------------------------------------------------------------------------------------------

    #region IsVerificationComplete

    //modify by:Akanksha
    //date : 29/09/2014 
    //sp_name:sp_CIDocVerification_IsVerificationComplete


    public string IsVerificationComplete(string sCaseId, string sClientId, string sCenterId)
    {
        string bComplete = "";
        try
        {
            SqlConnection con;
            DataSet MyDataSet = new DataSet();
            SqlDataAdapter My_SQLDataAdapter = new SqlDataAdapter();
            con = new SqlConnection(objCon.AppConnectionString);
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

    #endregion IsVerificationComplete
    //---------------comp-------//


    //-------------------------------------------------------------------------------------------------------------


    // comment by kanchan on 29/9/2014 


    ////#region VerificationComplete after completing verification IS_CASE_COMPLETE='Y'
    ////public void VerificationComplete(OleDbTransaction oledbTrans, string sCaseId)
    ////{
    ////    string sSql = "";
    ////    sSql = "Update CPV_IDOC_CASE_DETAILS SET IS_CASE_COMPLETE='Y' WHERE CASE_ID='" + sCaseId + "'";
    ////    OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sSql);
    ////}
    ////#endregion VerificationComplete


    //modify by:Akanksha
    //date : 29/09/2014 

    #region VerificationComplete after completing verification IS_CASE_COMPLETE='Y'


    public void VerificationComplete(string sCaseId)
    {

        try
        {

            using (SqlConnection con = new SqlConnection(objCon.AppConnectionString))
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

    #endregion VerificationComplete

    //------------------------comp---------------------
}


