using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;



/// <summary>
///Code Added By Avinash Wankhede [2009 June 06]
/// Purpose : Generate Export File As per Client Request.
/// </summary>
public class GESBI_ExportGenX
{
	public GESBI_ExportGenX()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int strClientId;

    public int ClientId
    {
        get { return strClientId; }
        set { strClientId = value; }
    }

    private int strCentreID;

    public int CentreID
    {
        get { return strCentreID; }
        set { strCentreID = value; }
    }
    

    public string strString = "";

    public string GenerateCode(int pClient, string pFrmDate, string pToDate, string pCaseIdList)
    {
        string ActualFileWithPath = "";

        try
        {

            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Generate_ExportListFor_GESBI";
            sqlCom.CommandTimeout = 0;

            SqlParameter ClientID = new SqlParameter();
            ClientID.SqlDbType = SqlDbType.Int;
            ClientID.ParameterName = "@ClientID";
            ClientID.Value = pClient;//1013;
            sqlCom.Parameters.Add(ClientID);


            SqlParameter FrmDate = new SqlParameter();
            FrmDate.SqlDbType = SqlDbType.VarChar;
            FrmDate.ParameterName = "@FrmDate";
            FrmDate.Value = pFrmDate; //"20090420";
            sqlCom.Parameters.Add(FrmDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.SqlDbType = SqlDbType.VarChar;
            ToDate.ParameterName = "@ToDate";
            ToDate.Value = pToDate;//"20090420";
            sqlCom.Parameters.Add(ToDate);

            SqlParameter CaseIdList = new SqlParameter();
            CaseIdList.SqlDbType = SqlDbType.VarChar;
            CaseIdList.ParameterName = "@CaseIdList";
            CaseIdList.Value = pCaseIdList;
            sqlCom.Parameters.Add(CaseIdList);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataSet ds = new DataSet();
            sqlDA.Fill(ds);
            sqlcon.Close();



            int i = 0;
            if (ds.Tables.Count > 0)
            {
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    if (ds.Tables[0].Rows[i]["VERIFICATION_TYPE_CODE"].ToString().Trim() == "RV")
                    {

                        GeneFile_ForRV(strString, GetData_For_Excel("Get_DataForExport", ds.Tables[0].Rows[i]["Case_Id"].ToString()));

                    }
                    else if (ds.Tables[0].Rows[i]["VERIFICATION_TYPE_CODE"].ToString().Trim() == "BV")
                    {
                        if (ds.Tables[0].Rows[i]["Occupation"].ToString().Trim() == "S")
                        {
                            GeneFile_ForBVS(strString, GetData_For_Excel("Get_DataForExport_BVS", ds.Tables[0].Rows[i]["Case_Id"].ToString()));
                        }
                        else
                        {
                            GeneFile_ForBVE(strString, GetData_For_Excel("Get_DataForExport_BVSE", ds.Tables[0].Rows[i]["Case_Id"].ToString()));
                            
                        }

                    }
                    else if (ds.Tables[0].Rows[i]["VERIFICATION_TYPE_CODE"].ToString().Trim() == "RT")
                    {
                        GeneFile_ForRT(strString, GetData_For_Excel("Get_DataForExport_RT", ds.Tables[0].Rows[i]["Case_Id"].ToString().Trim()));

                    }

                    else if (ds.Tables[0].Rows[i]["VERIFICATION_TYPE_CODE"].ToString().Trim() == "BT")
                    {
                        GeneFile_ForBT(strString, GetData_For_Excel("Get_DataForExport_BT", ds.Tables[0].Rows[i]["Case_Id"].ToString().Trim()));

                    }
                }

                string FileName = "";
                string FileSAVEPath = "";

                FileName = GetExportFileName();
                FileSAVEPath = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["GESBI_ExportFilePath"]);
                ActualFileWithPath = FileSAVEPath + FileName + ".drt";

                TextWriter tw = new StreamWriter(ActualFileWithPath);
                tw.WriteLine(strString);
                tw.Close();


            }
            return ActualFileWithPath;
        }
        catch (Exception ex)
        {

            return "Error:" + ex.Message;
        }

    }


    private string GeneFile_ForRV(string strWrite, DataTable dt)
    { 

        int i;
        for (i = 0; i <= dt.Rows.Count - 1; i++)
        {


            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["AGENCY_NAME"]), 1, 10);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["VERIFICATION_TYPE_CODE"]), 1, 5);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Ref_No"]), 1, 15);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["CustomerName"]), 1, 30);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["ADRESS_CONFIRMATION"]), 1, 1);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["RES_ADD_LINE"]), 1, 100);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["CASE_REC_DATETIME"]), 1, 10);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["CustomerName"]), 1, 30);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["PERSON_CONTACTED_MET"]), 1, 30);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["RELATION_PERSON_CONTACTED"]), 1, 30);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["APPLICANT_AGE"]), 1, 10);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["FAMILY_MEMBERS"]), 0, 5);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["NO_OF_EARNING_FAMILY_MEMBER"]), 0, 5);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["RESIDANCE_STATUS"]), 1, 30);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["varown"]), 1, 12);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Off_Name"]), 1, 100);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Off_add_line_1"]), 1, 100);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["OCCUPATION"]), 1, 35);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["DESIGNATION"]), 1, 20);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["DEFAULTED_WITH"]), 1, 35);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["BRANCH"]), 1, 35);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["PERMANENT_ADDRESS"]), 1, 100);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["off_phone"]), 0, 15);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Mobile"]), 0, 15);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["YEARS_LIVE_AT_ADD2"]), 1, 20);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Make_and_Type"]), 1, 40);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["ADDRESS_CONFIRMED_BY"]), 1, 40);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["LAND_MARK_OBSERVED"]), 1, 50);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["LOCATING_ADDRESS"]), 1, 40);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["LOCALITY"]), 1, 15);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Standard_of_Living"]), 1, 15);
            //strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["RES_TYPE"]), 1, 15);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["ACCOMODATION"]), 1, 20);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["APPROXIMATE_AREA"]), 1, 10);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["INTERIOR"]), 1, 40);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["VerifierId"]), 1, 20);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Auth_sign"]), 1, 30);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["ASSETS_VISIBLE"]), 1, 60);

            if (dt.Rows[i]["PROOF_OF_VISIT_COLLECTED"].ToString() != "")
            {
                strWrite = strWrite + Trim_TEXT("Y", 1, 1);
            }
            else
            {
                strWrite = strWrite + Trim_TEXT("N", 1, 1);
            }

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Type_Of_Proof"]), 1, 15);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["VERIFICATION_CONDUCTED_AT"]), 1, 30);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["ADRESS_CONFIRMATION"]), 1, 1);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["result"]), 1, 15);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["DECLINED_CODE"]), 1, 4);


            string strAttemptDate1 = "";
            string strAttemptTime1 = "";

            string strAttemptDate2 = "";
            string strAttemptTime2 = "";

            string strAttemptDate3 = "";
            string strAttemptTime3 = "";

            if (dt.Rows[i]["Attempt1"].ToString() != "")
            {
                strAttemptDate1 = Convert.ToString(dt.Rows[i]["Attempt1"]).Substring(0, 10);
                strAttemptTime1 = Convert.ToString(dt.Rows[i]["Attempt1"]).Substring(11, 5);
            }
            if (dt.Rows[i]["Attempt2"].ToString() != "")
            {
                strAttemptDate2 = Convert.ToString(dt.Rows[i]["Attempt2"]).Substring(0, 10);
                strAttemptTime2 = Convert.ToString(dt.Rows[i]["Attempt2"]).Substring(11, 5);
            }
            if (dt.Rows[i]["Attempt3"].ToString() != "")
            {

                strAttemptDate3 = Convert.ToString(dt.Rows[i]["Attempt3"]).Substring(0, 10);
                strAttemptTime3 = Convert.ToString(dt.Rows[i]["Attempt3"]).Substring(11, 5);
            }



            strWrite = strWrite + Trim_TEXT(strAttemptDate1, 1, 10);
            strWrite = strWrite + Trim_TEXT(strAttemptTime1.Replace(":", "."), 1, 25);

            strWrite = strWrite + Trim_TEXT(strAttemptDate2, 1, 10);
            strWrite = strWrite + Trim_TEXT(strAttemptTime2.Replace(":", "."), 1, 25);


            strWrite = strWrite + Trim_TEXT(strAttemptDate3, 1, 10);
            strWrite = strWrite + Trim_TEXT(strAttemptTime3.Replace(":", "."), 1, 25);

            //strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Attempt1"]), 1, 35);
            //strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Attempt2"]), 1, 35);
            //strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Attempt3"]), 1, 35);


            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["update1"]), 1, 1);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["veri_score"]), 1, 5);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["UNREACHABLE_REASON"]), 1, 100);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["RESULT_CALLING"]), 1, 100);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["ADDRESS_BELONG"]), 1, 50);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["IS_APP_KNOWN_PERSON"]), 1, 1); 

            strWrite = strWrite + Trim_TEXT(dt.Rows[i]["DIRECTORY_CHECK"].ToString(), 1, 35);
            strWrite = strWrite + "\r\n";
            strWrite = strWrite + "REMARKS";
            strWrite = strWrite + "\r\n";
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["FE_remark"]), 1, 1000);
            strWrite = strWrite + "\r\n";
            strWrite = strWrite + "SUPERVISOR REMARKS";
            strWrite = strWrite + "\r\n";
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["SUPERVISOR_REMARKS"]), 1, 1000);
            strWrite = strWrite + "\r\n";
            strWrite = strWrite + "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            strWrite = strWrite + "\r\n";

        }


        strString = strWrite;
        return strString;

    }
    private string GeneFile_ForBVS(string strWrite, DataTable dt)
    {



        int i;

        for (i = 0; i <= dt.Rows.Count - 1; i++)
        {


            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["AGENCY_NAME"]), 1, 10);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["VERIFICATION_TYPE_CODE"]), 1, 4);
            strWrite = strWrite + Trim_TEXT(Convert.ToString("S"), 1, 1);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Ref_No"]), 1, 15);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["CustomerName"]), 1, 30);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["ADRESS_CONFIRMATION"]), 1, 1);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["OFFICE_ADDRESS"]), 1, 100);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Batch_Date"]), 1, 10);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["VERIFIED_NEIGHBOUR"]), 1, 40);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Contacted_Person_Name"]), 1, 30);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["RELATION_PERSON_CONTACTED"]), 1, 30);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["APPLICANT_AGE"]), 1, 10);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["NO_OF_EMP"]), 0, 5);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["BRANCH"]), 0, 5);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["NO_OF_YEARS_AT_CURRENT_EMPLOYMENT"]), 0, 5);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Impression_Of_Office"]), 1, 15);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["COMPANY_NAME"]), 1, 50);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["OFFICE_ADDRESS"]), 1, 100);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["OFFICE_TELEPHONE"]), 1, 15);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["OFFICE_EXT"]), 1, 15);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Change_In_Phone_No"]), 1, 15);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["C_EMPLOYER_DEPT"]), 1, 15);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["DESIGNATION"]), 1, 15);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["IS_APPLICANT_FULL_TIME"]), 1, 1);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Business_Type"]), 1, 20);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Nature_Business"]), 1, 20);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["LOCATING_ADDRESS"]), 1, 40);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["OFFICE_LOCALITY"]), 1, 30);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["BUSINESS_BOARD_SEEN_OUTSIDE_BUILDING"]), 1, 1);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["APPROXIMATE_AREA"]), 1, 10);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["land_mark_observed"]), 1, 50);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["VERIFIER_Name"]), 1, 20);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["VERIFICATION_CONDUCTED_At"]), 1, 20);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["ADRESS_CONFIRMATION"]), 1, 1);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["DETAILS_PROOF_COLLECTED"]), 1, 15);

            string strAttemptDate1 = "";
            string strAttemptTime1 = "";

            string strAttemptDate2 = "";
            string strAttemptTime2 = "";

            string strAttemptDate3 = "";
            string strAttemptTime3 = "";


            if (dt.Rows[i]["Attempt1"].ToString() != "")
            {
                strAttemptDate1 = Convert.ToString(dt.Rows[i]["Attempt1"]).Substring(0, 10);
                strAttemptTime1 = Convert.ToString(dt.Rows[i]["Attempt1"]).Substring(11, 5);
            }
            if (dt.Rows[i]["Attempt2"].ToString() != "")
            {
                strAttemptDate2 = Convert.ToString(dt.Rows[i]["Attempt2"]).Substring(0, 10);
                strAttemptTime2 = Convert.ToString(dt.Rows[i]["Attempt2"]).Substring(11, 5);
            }
            if (dt.Rows[i]["Attempt3"].ToString() != "")
            {

                strAttemptDate3 = Convert.ToString(dt.Rows[i]["Attempt3"]).Substring(0, 10);
                strAttemptTime3 = Convert.ToString(dt.Rows[i]["Attempt3"]).Substring(11, 5);
            }




            strWrite = strWrite + Trim_TEXT(strAttemptDate1, 1, 10);
            strWrite = strWrite + Trim_TEXT(strAttemptTime1.Replace(":", "."), 1, 25);

            strWrite = strWrite + Trim_TEXT(strAttemptDate2, 1, 10);
            strWrite = strWrite + Trim_TEXT(strAttemptTime2.Replace(":", "."), 1, 25);


            strWrite = strWrite + Trim_TEXT(strAttemptDate3, 1, 10);
            strWrite = strWrite + Trim_TEXT(strAttemptTime3.Replace(":", "."), 1, 25);



            //strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Attempt1"]), 1, 35);
            //strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Attempt2"]), 1, 35);
            //strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Attempt2"]), 1, 35);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["C_AUTH_SIGN"]), 1, 30);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["C_Update"]), 1, 1);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["RECOMMENDATION"]), 1, 15);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Office_locality_untrace"]), 1, 10);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["c_veri_score"]), 1, 5);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["UNREACHABLE_REASON"]), 1, 100);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["RESULT_CALLING"]), 1, 100);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["ADDRESS_BELONG"]), 1, 50);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["DECLINED_CODE"]), 1, 4);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["DIRECTORY_CHECK"]), 1, 35);


            strWrite = strWrite + "\r\n";
            strWrite = strWrite + "REMARKS";
            strWrite = strWrite + "\r\n";
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["FE_remark"]), 1, 1000);
            strWrite = strWrite + "\r\n";
            strWrite = strWrite + "SUPERVISOR REMARKS";
            strWrite = strWrite + "\r\n";
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["SUPERVISOR_REMARKS"]), 1, 1000);
            strWrite = strWrite + "\r\n";
            strWrite = strWrite + "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            strWrite = strWrite + "\r\n";

        }

        strString = strWrite;
        return strString;



    }
    private string GeneFile_ForBVE(string strWrite, DataTable dt)
    {

        int i;
        for (i = 0; i <= dt.Rows.Count - 1; i++)
        {


            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Agency_Name"]), 1, 10);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["VERIFICATION_TYPE_CODE"]), 1, 4);
            strWrite = strWrite + Trim_TEXT(Convert.ToString("E"), 1, 1);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Ref_No"]), 1, 15);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["CustomerName"]), 1, 30);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["ADRESS_CONFIRMATION"]), 1, 1);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Off_Add"]), 1, 100);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Batch_Date"]), 1, 10);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["VERIFIED_NEIGHBOUR"]), 1, 40);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Contacted_Person_Name"]), 1, 30);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["RELATION_PERSON_CONTACTED"]), 1, 20);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["APPLICANT_AGE"]), 1, 10);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["NO_OF_EMP"]), 1, 5);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["BRANCH"]), 1, 5);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["CO_ESTABLISHED_IN"]), 1, 5);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Impression_Of_Office"]), 1, 15);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Company_name"]), 1, 50);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["OFFICE_ADDRESS"]), 1, 100);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["OFFICE_TELEPHONE"]), 1, 15);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["OFFICE_EXT"]), 1, 15);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Change_In_Phone_No"]), 1, 15);


            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Business_Desc"]), 1, 30);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["DESIGNATION"]), 1, 15);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["BUSINESS_TYPE"]), 1, 20);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Business_nature"]), 1, 20);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Impression_Of_Office"]), 1, 15);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["RES_TYPE"]), 1, 10);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["LOCATING_ADDRESS"]), 1, 40);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["OFFICE_LOCALITY"]), 1, 15);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["C_Customer1"]), 1, 30);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["C_Customer2"]), 1, 30);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["C_Customer3"]), 1, 30);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["BUSINESS_BOARD_SEEN_OUTSIDE_BUILDING"]), 1, 1);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["BUSINESS_ACTIVITY_SEEN"]), 1, 1);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["BUSINESS_STOCK_SEEN"]), 1, 1);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["ASSETS_VISIBLE"]), 1, 50);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["APPROXIMATE_AREA"]), 1, 10);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["land_mark_observed"]), 1, 50);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Verifier_Id"]), 1, 20);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["VERIFICATION_CONDUCTED_At"]), 1, 20);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["ADRESS_CONFIRMATION2"]), 1, 1);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["DETAILS_PROOF_COLLECTED"]), 1, 15);

            string strAttemptDate1 = "";
            string strAttemptTime1 = "";

            string strAttemptDate2 = "";
            string strAttemptTime2 = "";

            string strAttemptDate3 = "";
            string strAttemptTime3 = "";

            if (dt.Rows[i]["Attempt1"].ToString() != "")
            {
                strAttemptDate1 = Convert.ToString(dt.Rows[i]["Attempt1"]).Substring(0, 10);
                strAttemptTime1 = Convert.ToString(dt.Rows[i]["Attempt1"]).Substring(11, 5);
            }
            if (dt.Rows[i]["Attempt2"].ToString() != "")
            {
                strAttemptDate2 = Convert.ToString(dt.Rows[i]["Attempt2"]).Substring(0, 10);
                strAttemptTime2 = Convert.ToString(dt.Rows[i]["Attempt2"]).Substring(11,5);
            }
            if (dt.Rows[i]["Attempt3"].ToString() != "")
            {

                strAttemptDate3 = Convert.ToString(dt.Rows[i]["Attempt3"]).Substring(0, 10);
                strAttemptTime3 = Convert.ToString(dt.Rows[i]["Attempt3"]).Substring(11, 5);
            }



 



            strWrite = strWrite + Trim_TEXT(strAttemptDate1, 1, 10);
            strWrite = strWrite + Trim_TEXT(strAttemptTime1.Replace(":", "."), 1, 25);

            strWrite = strWrite + Trim_TEXT(strAttemptDate2, 1, 10);
            strWrite = strWrite + Trim_TEXT(strAttemptTime2.Replace(":", "."), 1, 25);


            strWrite = strWrite + Trim_TEXT(strAttemptDate3, 1, 10);
            strWrite = strWrite + Trim_TEXT(strAttemptTime3.Replace(":", "."), 1, 25);


            //--------------------------
 


            //strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Attempt1"]), 1, 35);
            //strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Attempt2"]), 1, 35);
            //strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Attempt2"]), 1, 35);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["C_AUTH_SIGN"]), 1, 30);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["C_Update"]), 1, 1);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["RECOMMENDATION"]), 1, 15);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["c_veri_score"]), 1, 5);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["UNREACHABLE_REASON"]), 1, 100);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["RESULT_CALLING"]), 1, 100);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["ADDRESS_BELONG"]), 1, 50);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["DECLINED_CODE"]), 1, 1);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["DIRECTORY_CHECK"]), 1, 35);


            strWrite = strWrite + "\r\n";
            strWrite = strWrite + "REMARKS";
            strWrite = strWrite + "\r\n";
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["FE_remark"]), 1, 1000);
            strWrite = strWrite + "\r\n";
            strWrite = strWrite + "SUPERVISOR REMARKS";
            strWrite = strWrite + "\r\n";
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["SUPERVISOR_REMARKS"]), 1, 1000);
            strWrite = strWrite + "\r\n";
            strWrite = strWrite + "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            strWrite = strWrite + "\r\n";

        }

        strString = strWrite;
        return strString;



    }
    private string GeneFile_ForBT(string strWrite, DataTable dt)
    {
        int i;

        for (i = 0; i <= dt.Rows.Count - 1; i++)
        {


            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["AGENCY_NAME"]), 1, 10);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["VERIFICATION_TYPE_CODE"]), 1, 5);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Ref_No"]), 1, 15);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["CustomerName"]), 1, 30);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["CallUP"]), 1, 20);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["SPECIAL_INSTRUCTIONS"]), 1, 30);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["OFF_ADD_LINE_1"]), 1, 100);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["SPK_TO"]), 1, 30);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["DESIG_AND_DEPT_OF_CONTACTED_PERSON"]), 1, 15);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Employer_Address"]), 1, 100);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["APP_DOB_APPROX_AGE"]), 1, 10);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["DESIGNATION"]), 1, 15);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Appli_Dept"]), 1, 15);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["NATURE_BUSINESS_RESI_CUM_OFF"]), 1, 15);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["NO_OF_YEARS_AT_CURRENT_EMPLOYMENT"]), 1, 10);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["VEHICLE_OTHER"]), 1, 100);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["RSIDENCE_PHONE_NO"]), 1, 40);

            string strAttemptDate1 = "";
            string strAttemptTime1 = "";

            string strAttemptDate2 = "";
            string strAttemptTime2 = "";

            string strAttemptDate3 = "";
            string strAttemptTime3 = "";

            string strAttemptDate4 = "";
            string strAttemptTime4 = "";

            string strAttemptDate5 = "";
            string strAttemptTime5 = "";

            if (dt.Rows[i]["Attempt1"].ToString() != "")
            {
                strAttemptDate1 = Convert.ToString(dt.Rows[i]["Attempt1"]).Substring(0, 10);
                strAttemptTime1 = Convert.ToString(dt.Rows[i]["Attempt1"]).Substring(11, 5);
            }
            if (dt.Rows[i]["Attempt2"].ToString() != "")
            {
                strAttemptDate2 = Convert.ToString(dt.Rows[i]["Attempt2"]).Substring(0, 10);
                strAttemptTime2 = Convert.ToString(dt.Rows[i]["Attempt2"]).Substring(11, 5);
            }
            if (dt.Rows[i]["Attempt3"].ToString() != "")
            {

                strAttemptDate3 = Convert.ToString(dt.Rows[i]["Attempt3"]).Substring(0, 10);
                strAttemptTime3 = Convert.ToString(dt.Rows[i]["Attempt3"]).Substring(11, 5);
            }

            if (dt.Rows[i]["Attempt4"].ToString() != "")
            {

                strAttemptDate4 = Convert.ToString(dt.Rows[i]["Attempt4"]).Substring(0, 10);
                strAttemptTime4 = Convert.ToString(dt.Rows[i]["Attempt4"]).Substring(11, 5);
            }

            if (dt.Rows[i]["Attempt5"].ToString() != "")
            {

                strAttemptDate5 = Convert.ToString(dt.Rows[i]["Attempt5"]).Substring(0, 10);
                strAttemptTime5 = Convert.ToString(dt.Rows[i]["Attempt5"]).Substring(11, 5);
            }


            // strWrite = strWrite + Trim_TEXT(strAttemptDate1, 1, 9);
            //strWrite = strWrite + Trim_TEXT(strAttemptTime1, 1, 26);

            //  strWrite = strWrite + Trim_TEXT(strAttemptDate2, 1, 9);
            // strWrite = strWrite + Trim_TEXT(strAttemptTime2, 1, 26);


            // strWrite = strWrite + Trim_TEXT(strAttemptDate3, 1, 9);
            // strWrite = strWrite + Trim_TEXT(strAttemptTime3, 1, 26);

            // strWrite = strWrite + Trim_TEXT(strAttemptDate4, 1, 9);
            //strWrite = strWrite + Trim_TEXT(strAttemptTime4, 1, 26);


            //strWrite = strWrite + Trim_TEXT(strAttemptDate5, 1, 9);
            //strWrite = strWrite + Trim_TEXT(strAttemptTime5, 1, 26);

            //Contactable
            //Cont. Enganaged
            //No Response
            //Answering Machine

            //strOutCome1
            string strOutCome1, strOutCome2, strOutCome3,  strOutCome4, strOutCome5 = "";
            strOutCome1 = dt.Rows[i]["OutCome1"].ToString();
            strOutCome2 = dt.Rows[i]["OutCome2"].ToString();
            strOutCome3 = dt.Rows[i]["OutCome3"].ToString();
            strOutCome4 = dt.Rows[i]["OutCome4"].ToString();
            strOutCome5 = dt.Rows[i]["OutCome5"].ToString();

            //string strOutCome1 = "";
            //if (dt.Rows[i]["OutCome1"].ToString() == "Contactable")
            //{
            //    strOutCome1 = "CR";
            //}
            //else if (dt.Rows[i]["OutCome1"].ToString() == "Cont. Enganaged")
            //{
            //    strOutCome1 = "PE";
            //}
            //else if (dt.Rows[i]["OutCome1"].ToString() == "No Response")
            //{
            //    strOutCome1 = "NR";
            //}
            //else if (dt.Rows[i]["OutCome1"].ToString() == "Answering Machine")
            //{
            //    strOutCome1 = "AM";
            //}

            //////-------------strOutCome2
            //string strOutCome2 = "";
            //if (dt.Rows[i]["OutCome2"].ToString() == "Contactable")
            //{
            //    strOutCome2 = "CR";
            //}
            //else if (dt.Rows[i]["OutCome2"].ToString() == "Cont. Enganaged")
            //{
            //    strOutCome2 = "PE";
            //}
            //else if (dt.Rows[i]["OutCome2"].ToString() == "No Response")
            //{
            //    strOutCome2 = "NR";
            //}
            //else if (dt.Rows[i]["OutCome2"].ToString() == "Answering Machine")
            //{
            //    strOutCome2 = "AM";
            //}
            ////--OutCome3
            //string strOutCome3 = "";
            //if (dt.Rows[i]["OutCome3"].ToString() == "Contactable")
            //{
            //    strOutCome3 = "CR";
            //}
            //else if (dt.Rows[i]["OutCome3"].ToString() == "Cont. Enganaged")
            //{
            //    strOutCome3 = "PE";
            //}
            //else if (dt.Rows[i]["OutCome3"].ToString() == "No Response")
            //{
            //    strOutCome3 = "NR";
            //}
            //else if (dt.Rows[i]["OutCome3"].ToString() == "Answering Machine")
            //{
            //    strOutCome3 = "AM";
            //}
            ////--OutCome4
            //string strOutCome4 = "";
            //if (dt.Rows[i]["OutCome4"].ToString() == "Contactable")
            //{
            //    strOutCome4 = "CR";
            //}
            //else if (dt.Rows[i]["OutCome4"].ToString() == "Cont. Enganaged")
            //{
            //    strOutCome4 = "PE";
            //}
            //else if (dt.Rows[i]["OutCome4"].ToString() == "No Response")
            //{
            //    strOutCome4 = "NR";
            //}
            //else if (dt.Rows[i]["OutCome4"].ToString() == "Answering Machine")
            //{
            //    strOutCome4 = "AM";
            //}

            ////--OutCome5
            //string strOutCome5 = "";
            //if (dt.Rows[i]["OutCome5"].ToString() == "Contactable")
            //{
            //    strOutCome5 = "CR";
            //}
            //else if (dt.Rows[i]["OutCome5"].ToString() == "Cont. Enganaged")
            //{
            //    strOutCome5 = "PE";
            //}
            //else if (dt.Rows[i]["OutCome5"].ToString() == "No Response")
            //{
            //    strOutCome5 = "NR";
            //}
            //else if (dt.Rows[i]["OutCome5"].ToString() == "Answering Machine")
            //{
            //    strOutCome5 = "AM";
            //}

            strWrite = strWrite + Trim_TEXT(strOutCome1, 1, 10);
            strWrite = strWrite + Trim_TEXT(strOutCome2, 1, 10);
            strWrite = strWrite + Trim_TEXT(strOutCome3, 1, 10);
            strWrite = strWrite + Trim_TEXT(strOutCome4, 1, 10);
            strWrite = strWrite + Trim_TEXT(strOutCome5, 1, 10);

            strWrite = strWrite + Trim_TEXT(strAttemptDate1, 1, 10);
            strWrite = strWrite + Trim_TEXT(strAttemptDate2, 1, 10);
            strWrite = strWrite + Trim_TEXT(strAttemptDate3, 1, 10);
            strWrite = strWrite + Trim_TEXT(strAttemptDate4, 1, 10);
            strWrite = strWrite + Trim_TEXT(strAttemptDate5, 1, 10);

            strWrite = strWrite + Trim_TEXT(strAttemptTime1.Replace(":", "."), 1, 25);
            strWrite = strWrite + Trim_TEXT(strAttemptTime2.Replace(":", "."), 1, 25);
            strWrite = strWrite + Trim_TEXT(strAttemptTime3.Replace(":", "."), 1, 25);
            strWrite = strWrite + Trim_TEXT(strAttemptTime4.Replace(":", "."), 1, 25);
            strWrite = strWrite + Trim_TEXT(strAttemptTime5.Replace(":", "."), 1, 25);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["APPLICANT_HOME_COUNTRY_PHONE"]), 1, 1);


            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Auth_Sign"]), 1, 30);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["COMPANY_NAME"]), 1, 30);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["VERIFIER_Name"]), 1, 30);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["IS_RESIDANT"]), 1, 100);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["RESIDANCE_STATUS2"]), 1, 30);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["result"]), 1, 10);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["DECLINED_CODE"]), 1, 4);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["IF_OFFICE_ADD_IS_IN_NEGATIVE_AREA"]), 1, 1);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["IS_RESI_ADD_IS_IN_NEGATIVE_AREA"]), 1, 1);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["DIR_CHECK"]), 1, 35);

            strWrite = strWrite + "\r\n";
            strWrite = strWrite + "REMARKS";
            strWrite = strWrite + "\r\n";
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["FE_remark"]), 1, 1000);
            strWrite = strWrite + "\r\n";
            strWrite = strWrite + "SUPERVISOR REMARKS";
            strWrite = strWrite + "\r\n";
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["SUPERVISOR_REMARKS"]), 1, 1000);
            strWrite = strWrite + "\r\n";
            strWrite = strWrite + "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            strWrite = strWrite + "\r\n";


        }


        strString = strWrite;
        return strString;



    }
    private DataTable GetData_For_Excel(string pProcedureName, string pCaseId)
    {
       CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

        sqlcon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlcon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = pProcedureName;//"Get_DataForExport";

        SqlParameter ClientID = new SqlParameter();
        ClientID.SqlDbType = SqlDbType.Int;
        ClientID.ParameterName = "@ClientID";
        ClientID.Value = strClientId;
        sqlCom.Parameters.Add(ClientID);

        SqlParameter CaseId = new SqlParameter();
        CaseId.SqlDbType = SqlDbType.VarChar;
        CaseId.ParameterName = "@CaseId";
        CaseId.Value = pCaseId;
        sqlCom.Parameters.Add(CaseId);

        sqlCom.CommandTimeout = 0;

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlcon.Close();

        return dt;


    }
    private string Trim_TEXT(string strTEXT, int IsNumeric, int Lenth)
    {
        string strFinalTEXT = "";
        int i = 0;
        int Len = strTEXT.Length;
        //for (i = 0; i <= Lenth; i++)
        //{
        //    strFinalTEXT = strFinalTEXT + " ";
        //}
        int Start = 0;


        if (IsNumeric == 1)
        {
            for (i = 0; i <= Lenth; i++)
            {
                strFinalTEXT = strFinalTEXT + " ";

            }
            strTEXT = strTEXT + strFinalTEXT;
            strFinalTEXT = strTEXT.Substring(Start, Lenth);

        }
        else
        {
            Start = 1;

            for (i = 0; i <= Lenth - 1; i++)
            {
                strFinalTEXT = "0" + strFinalTEXT;

            }
            strTEXT = strFinalTEXT + strTEXT;
            strFinalTEXT = strTEXT.Substring(Len, Lenth);

        }



        return strFinalTEXT;
    }
    private string GeneFile_ForRT(string strWrite, DataTable dt)
    {
        int i;

        for (i = 0; i <= dt.Rows.Count - 1; i++)
        {


            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["AGENCY_NAME"]), 1, 10);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["VERIFICATION_TYPE_CODE"]), 1, 5);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Ref_No"]), 1, 15);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["CustomerName"]), 1, 30);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["CALLED_UP_ON_RESIDANCE_TEL_NO"]), 1, 20);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["SPECIAL_INSTRUCTIONS"]), 1, 30);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Resi_Add"]), 1, 100);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["SPK_TO"]), 1, 30);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["REL_WITH_APPLICANT"]), 1, 15);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Off_Add"]), 1, 100);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["APPLICANT_AGE"]), 1, 10);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["DESIGNATION"]), 1, 15);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["C_NOCOMPANY"]), 1, 15);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["NO_OF_YEARS_AT_CURRENT_EMPLOYMENT"]), 1, 10);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Resi_Add1"]), 1, 100);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["OFFICE_EXT"]), 1, 40);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["FAMILY_MEMBERS"]), 1, 3);

            string strAttemptDate1 = "";
            string strAttemptTime1 = "";

            string strAttemptDate2 = "";
            string strAttemptTime2 = "";

            string strAttemptDate3 = "";
            string strAttemptTime3 = "";

            string strAttemptDate4 = "";
            string strAttemptTime4 = "";

            string strAttemptDate5 = "";
            string strAttemptTime5 = "";

            if (dt.Rows[i]["Attempt1"].ToString() != "")
            {
                strAttemptDate1 = Convert.ToString(dt.Rows[i]["Attempt1"]).Substring(0, 10);
                strAttemptTime1 = Convert.ToString(dt.Rows[i]["Attempt1"]).Substring(11, 5);
            }
            if (dt.Rows[i]["Attempt2"].ToString() != "")
            {
                strAttemptDate2 = Convert.ToString(dt.Rows[i]["Attempt2"]).Substring(0, 10);
                strAttemptTime2 = Convert.ToString(dt.Rows[i]["Attempt2"]).Substring(11, 5);
            }
            if (dt.Rows[i]["Attempt3"].ToString() != "")
            {

                strAttemptDate3 = Convert.ToString(dt.Rows[i]["Attempt3"]).Substring(0, 10);
                strAttemptTime3 = Convert.ToString(dt.Rows[i]["Attempt3"]).Substring(11, 5);
            }

            if (dt.Rows[i]["Attempt4"].ToString() != "")
            {

                strAttemptDate4 = Convert.ToString(dt.Rows[i]["Attempt4"]).Substring(0, 10);
                strAttemptTime4 = Convert.ToString(dt.Rows[i]["Attempt4"]).Substring(11, 5);
            }

            if (dt.Rows[i]["Attempt5"].ToString() != "")
            {

                strAttemptDate5 = Convert.ToString(dt.Rows[i]["Attempt5"]).Substring(0, 10);
                strAttemptTime5 = Convert.ToString(dt.Rows[i]["Attempt5"]).Substring(11, 5);
            }



            
            string strOutCome1,strOutCome2,strOutCome3,strOutCome4,strOutCome5="";
            strOutCome1 = dt.Rows[i]["OutCome1"].ToString();
            strOutCome2 = dt.Rows[i]["OutCome2"].ToString();
            strOutCome3 = dt.Rows[i]["OutCome3"].ToString();
            strOutCome4 = dt.Rows[i]["OutCome4"].ToString();
            strOutCome5 = dt.Rows[i]["OutCome5"].ToString();

             
          //strOutCome1
            //if (dt.Rows[i]["OutCome1"].ToString() == "Contactable")
            //{
            //    strOutCome1 = "CR";
            //}
            //else if (dt.Rows[i]["OutCome1"].ToString() == "Cont. Enganaged")
            //{
            //    strOutCome1 = "PE";
            //}
            //else if (dt.Rows[i]["OutCome1"].ToString() == "No Response")
            //{
            //    strOutCome1 = "NR";
            //}
            //else if (dt.Rows[i]["OutCome1"].ToString() == "Answering Machine")
            //{
            //    strOutCome1 = "AM";
            //}

            ////-------------strOutCome2
            //if (dt.Rows[i]["OutCome2"].ToString() == "Contactable")
            //{
            //    strOutCome2 = "CR";
            //}
            //else if (dt.Rows[i]["OutCome2"].ToString() == "Cont. Enganaged")
            //{
            //    strOutCome2 = "PE";
            //}
            //else if (dt.Rows[i]["OutCome2"].ToString() == "No Response")
            //{
            //    strOutCome2 = "NR";
            //}
            //else if (dt.Rows[i]["OutCome2"].ToString() == "Answering Machine")
            //{
            //    strOutCome2 = "AM";
            //}
            ////--OutCome3
            //string strOutCome3 = "";
            //if (dt.Rows[i]["OutCome3"].ToString() == "Contactable")
            //{
            //    strOutCome3 = "CR";
            //}
            //else if (dt.Rows[i]["OutCome3"].ToString() == "Cont. Enganaged")
            //{
            //    strOutCome3 = "PE";
            //}
            //else if (dt.Rows[i]["OutCome3"].ToString() == "No Response")
            //{
            //    strOutCome3 = "NR";
            //}
            //else if (dt.Rows[i]["OutCome3"].ToString() == "Answering Machine")
            //{
            //    strOutCome3 = "AM";
            //}
            ////--OutCome4
            //string strOutCome4 = "";
            //if (dt.Rows[i]["OutCome4"].ToString() == "Contactable")
            //{
            //    strOutCome4 = "CR";
            //}
            //else if (dt.Rows[i]["OutCome4"].ToString() == "Cont. Enganaged")
            //{
            //    strOutCome4 = "PE";
            //}
            //else if (dt.Rows[i]["OutCome4"].ToString() == "No Response")
            //{
            //    strOutCome4 = "NR";
            //}
            //else if (dt.Rows[i]["OutCome4"].ToString() == "Answering Machine")
            //{
            //    strOutCome4 = "AM";
            //}

            ////--OutCome5
            //string strOutCome5 = "";
            //if (dt.Rows[i]["OutCome5"].ToString() == "Contactable")
            //{
            //    strOutCome5 = "CR";
            //}
            //else if (dt.Rows[i]["OutCome5"].ToString() == "Cont. Enganaged")
            //{
            //    strOutCome5 = "PE";
            //}
            //else if (dt.Rows[i]["OutCome5"].ToString() == "No Response")
            //{
            //    strOutCome5 = "NR";
            //}
            //else if (dt.Rows[i]["OutCome5"].ToString() == "Answering Machine")
            //{
            //    strOutCome5 = "AM";
            //}

            strWrite = strWrite + Trim_TEXT(strOutCome1, 1, 10);
            strWrite = strWrite + Trim_TEXT(strOutCome2, 1, 10);
            strWrite = strWrite + Trim_TEXT(strOutCome3, 1, 10);
            strWrite = strWrite + Trim_TEXT(strOutCome4, 1, 10);
            strWrite = strWrite + Trim_TEXT(strOutCome5, 1, 10);

            strWrite = strWrite + Trim_TEXT(strAttemptDate1, 1, 10);
            strWrite = strWrite + Trim_TEXT(strAttemptDate2, 1, 10);
            strWrite = strWrite + Trim_TEXT(strAttemptDate3, 1, 10);
            strWrite = strWrite + Trim_TEXT(strAttemptDate4, 1, 10);
            strWrite = strWrite + Trim_TEXT(strAttemptDate5, 1, 10);

            strWrite = strWrite + Trim_TEXT(strAttemptTime1.Replace(":", "."), 1, 25);
            strWrite = strWrite + Trim_TEXT(strAttemptTime2.Replace(":", "."), 1, 25);
            strWrite = strWrite + Trim_TEXT(strAttemptTime3.Replace(":", "."), 1, 25);
            strWrite = strWrite + Trim_TEXT(strAttemptTime4.Replace(":", "."), 1, 25);
            strWrite = strWrite + Trim_TEXT(strAttemptTime5.Replace(":", "."), 1, 25);



            //strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Attempt1"]), 1, 35);
            //strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Attempt2"]), 1, 35);
            //strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Attempt3"]), 1, 35);
            //strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Attempt4"]), 1, 35);
            //strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Attempt5"]), 1, 35);
            //strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["OutCome1"]), 1, 10);
            //strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["OutCome2"]), 1, 10);
            //strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["OutCome3"]), 1, 10);
            //strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["OutCome4"]), 1, 10);
            //strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["OutCome5"]), 1, 10);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["APPLICANT_HOME_COUNTRY_PHONE"]), 1, 1);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Company_Name"]), 1, 30);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["TELE_CALLER_NAME"]), 1, 30);

            strWrite = strWrite + Trim_TEXT("Y", 1, 1);
            strWrite = strWrite + Trim_TEXT("Y", 1, 1);

            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["ADDRESS_MATCH"]), 1, 100);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["RESIDANCE_STATUS"]), 1, 30);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["Auth_Sign"]), 1, 30);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["result"]), 1, 10);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["DECLINED_CODE"]), 1, 4);


            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["IF_OFFICE_ADD_IS_IN_NEGATIVE_AREA"]), 1, 1);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["IS_RESI_ADD_IS_IN_NEGATIVE_AREA"]), 1, 1);
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["DIRECTORY_CHECK"]), 1, 35);

            strWrite = strWrite + "\r\n";
            strWrite = strWrite + "REMARKS";
            strWrite = strWrite + "\r\n";
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["FE_REMARK"]), 1, 1000);
            strWrite = strWrite + "\r\n";
            strWrite = strWrite + "SUPERVISOR REMARKS";
            strWrite = strWrite + "\r\n";
            strWrite = strWrite + Trim_TEXT(Convert.ToString(dt.Rows[i]["SUPERVISOR_REMARKS"]), 1, 1000);
            strWrite = strWrite + "\r\n";
            strWrite = strWrite + "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            strWrite = strWrite + "\r\n";


        }


        strString = strWrite;
        return strString;



    }
    private string GetExportFileName()
    {

        try
        {
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_Series_Gen";
            sqlCom.CommandTimeout = 0;

            SqlParameter CentreId = new SqlParameter();
            CentreId.SqlDbType = SqlDbType.Int;
            CentreId.ParameterName = "@CentreId";
            CentreId.Value = CentreID;//1011;
            sqlCom.Parameters.Add(CentreId);


            SqlParameter TransType = new SqlParameter();
            TransType.SqlDbType = SqlDbType.VarChar;
            TransType.ParameterName = "@TransType";
            TransType.Value = "GESBI";
            sqlCom.Parameters.Add(TransType);

            SqlParameter varSeries = new SqlParameter();
            varSeries.SqlDbType = SqlDbType.VarChar;
            varSeries.ParameterName = "@varSeries";
            varSeries.Value = "";

            sqlCom.Parameters.Add(varSeries);

            string FileName = sqlCom.ExecuteScalar().ToString();

            sqlcon.Close();
            return FileName;
        }
        catch (Exception ex)
        {
            return "";
        }
    }          
}
