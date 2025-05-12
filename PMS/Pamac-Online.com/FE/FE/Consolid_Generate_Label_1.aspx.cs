using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


public partial class Consolid_Generate_Label_1 : System.Web.UI.Page
{

    CCommon objconn = new CCommon();

    OleDbDataAdapter da = new OleDbDataAdapter();  
    DataTable d_table = new DataTable();
    int icount = 0;

  
          
    string strVerification_Type_Code = "";
    string strAdditional1 = "";
    string strAdditional2 = "";
    string blnSR_NO = "";
    string blnLabelPrintingDate = "";
    string blnAllVerificationType = "";
    string strTableName = "";
    int nPrevSRNO = 0;
    int nSRNO = 0;
    int nForField = 0;
    string strSQL = "";
    string strSQLT = "";
    string strCC;
    string strRL;
    string strKYC;
    string strEBC;
    string strIDOC;
    string str1 ;
    string str2 ;
    string str3 ;
    string str4 ;
    string str5 ;
    string strSQLE;
    string strSQLK;
    string strSQLI;
    string strSQLR;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            string todate = "";
            CCreditCardGenerateLabel obcCLPrinting = new CCreditCardGenerateLabel();
            obcCLPrinting.Fromdate = Session["fromdate"].ToString();
            obcCLPrinting.Todate = Session["todate"].ToString();
            if (Context.Request.QueryString["IsLotWise"] != null && Context.Request.QueryString["IsLotWise"] != "")
            {
                if (Context.Request.QueryString["IsLotWise"] == "Y")
                    todate = obcCLPrinting.Todate;
                else if (Context.Request.QueryString["IsLotWise"] == "N")
                    todate = Convert.ToDateTime(obcCLPrinting.Todate).AddDays(1.0).ToString("dd-MMM-yyyy");
            }
            obcCLPrinting.Activity_ID = Session["ActivityId"].ToString();
            obcCLPrinting.Product_ID = Session["ProductId"].ToString();
            obcCLPrinting.Client_ID = Session["ClientId"].ToString();

            obcCLPrinting.Verification_Type_ID = Session["VerificationId"].ToString();
            obcCLPrinting.Centre_Id = Session["CentreId"].ToString();
            obcCLPrinting.Product_ID = Session["productID"].ToString();
            obcCLPrinting.Emp_ID=Session["EMPID"].ToString();
            
            string strSQLE1;
            string P = "0";
            if (obcCLPrinting.Emp_ID == P)
            {
                strSQLE1 = "select EMP_ID from  FE_VW ";
                DataSet ds1 = new DataSet();
                ds1 = OleDbHelper.ExecuteDataset(objconn.ConnectionString, CommandType.Text, strSQLE1);
                DataTable td = ds1.Tables[0];
                strSQLE1 = "";
                for (int i = 0; i < td.Rows.Count; i++)
                {
                    if (i != td.Rows.Count)
                    {
                        strSQLE1 += td.Rows[i]["EMP_ID"].ToString() + ",";

                    }
                }
                strSQLE1 = strSQLE1.TrimEnd(',');

            }
            else
            {
                strSQLE1 = obcCLPrinting.Emp_ID;
            }
           ds = obcCLPrinting.getTemplate1();

  



            string fdate = Session["fromdate"].ToString();
            string tdate = Session["todate"].ToString();



                    if (ds != null && obcCLPrinting.Product_ID == "1011")
                    {
                       
                        strCC =Get_database(ds);
                
                    }
                    if (ds != null && obcCLPrinting.Product_ID == "1012")
                    {
                      
                        strRL = Get_database(ds);
                    }
                    if (ds != null && obcCLPrinting.Product_ID == "1015")
                    {
                    
                        strKYC = Get_database(ds);

                    }
                    if (ds != null && obcCLPrinting.Product_ID == "1016")
                    {
                      
                        strEBC = Get_database(ds);

                    }
                    if (ds != null && obcCLPrinting.Product_ID == "1018")
                    {
                 
                        strIDOC = Get_database(ds);

                    }
           


                    string strquery1 = "";

                    string selectCriteria = "";

                    string strResult = "true";
                    string strResult1 = "true";
                    string strResult2 = "true";
                    string strResult3 = "true";
                    string strResult4 = "true";


                    string strCaseID1 = "";
                    string strFEAssi = "";
                    if (obcCLPrinting.Verification_Type_ID.Trim() != "3" && obcCLPrinting.Verification_Type_ID.Trim() != "4")
                    {
                        if (obcCLPrinting.Product_ID == "1011")
                        {
                            strFEAssi = " select case (select count(*) from CPV_CC_CASE_VERIFICATIONTYPE ccv inner join cpv_cc_case_details cd  on(cd.case_id=ccv.case_id) where verification_type_id='" + obcCLPrinting.Verification_Type_ID + "' and cd.CASE_REC_DATETIME >='" + obcCLPrinting.Fromdate + "' and cd.CASE_REC_DATETIME<'" + todate + "' and cd.Centre_id = " + obcCLPrinting.Centre_Id + ") " +
                                        " when (select count(*) from CPV_CC_FE_CASE_MAPPING ccf left outer join cpv_cc_case_details cd on (ccf.case_id=cd.case_id)  where verification_type_id='" + obcCLPrinting.Verification_Type_ID + "' and cd.CASE_REC_DATETIME >='" + obcCLPrinting.Fromdate + "' and cd.CASE_REC_DATETIME<'" + todate + "' and cd.Centre_id = " + obcCLPrinting.Centre_Id + " )" +
                                        " then 'true' else 'false' end  as Result";

                            strResult = (string)(OleDbHelper.ExecuteScalar(objconn.ConnectionString, CommandType.Text, strFEAssi));
                        }
                        if (obcCLPrinting.Product_ID == "1012")
                        {
                            strFEAssi = " select case (select count(*) from CPV_RL_CASE_VERIFICATIONTYPE ccv inner join CPV_RL_CASE_DETAILS cd  on(cd.case_id=ccv.case_id) where verification_type_id='" + obcCLPrinting.Verification_Type_ID + "' and cd.CASE_REC_DATETIME >='" + obcCLPrinting.Fromdate + "' and cd.CASE_REC_DATETIME<'" + todate + "' and cd.Centre_id = " + obcCLPrinting.Centre_Id + ") " +
                                        " when (select count(*) from CPV_RL_CASE_FE_MAPPING ccf left outer join CPV_RL_CASE_DETAILS cd on (ccf.case_id=cd.case_id)  where verification_type_id='" + obcCLPrinting.Verification_Type_ID + "' and cd.CASE_REC_DATETIME >='" + obcCLPrinting.Fromdate + "' and cd.CASE_REC_DATETIME<'" + todate + "' and cd.Centre_id = " + obcCLPrinting.Centre_Id + " )" +
                                        " then 'true' else 'false' end  as Result";
                            strResult1 = (string)(OleDbHelper.ExecuteScalar(objconn.ConnectionString, CommandType.Text, strFEAssi));
                        }
                        if (obcCLPrinting.Product_ID == "1015")
                        {
                            strFEAssi = " select case (select count(*) from CPV_EBC_VAERIFICATION_TYPE ccv inner join CPV_EBC_CASE_DETAILS cd  on(cd.case_id=ccv.case_id) where verification_type_id='" + obcCLPrinting.Verification_Type_ID + "' and cd.CASE_REC_DATETIME >='" + obcCLPrinting.Fromdate + "' and cd.CASE_REC_DATETIME<'" + todate + "' and cd.Centre_id = " + obcCLPrinting.Centre_Id + ") " +
                                        " when (select count(*) from CPV_EBC_FE_MAPPING ccf left outer join CPV_EBC_CASE_DETAILS cd on (ccf.case_id=cd.case_id)  where verification_type_id='" + obcCLPrinting.Verification_Type_ID + "' and cd.CASE_REC_DATETIME >='" + obcCLPrinting.Fromdate + "' and cd.CASE_REC_DATETIME<'" + todate + "' and cd.Centre_id = " + obcCLPrinting.Centre_Id + " )" +
                                        " then 'true' else 'false' end  as Result";
                            strResult2 = (string)(OleDbHelper.ExecuteScalar(objconn.ConnectionString, CommandType.Text, strFEAssi));
                        }
                        if (obcCLPrinting.Product_ID == "1016")
                        {
                            strFEAssi = " select case (select count(*) from CPV_KYC_CASE_DETAILS ccv inner join CPV_KYC_CASE_DETAILS cd  on(cd.case_id=ccv.case_id) where cd.verification_type_id='" + obcCLPrinting.Verification_Type_ID + "' and cd.CASE_REC_DATETIME >='" + obcCLPrinting.Fromdate + "' and cd.CASE_REC_DATETIME<'" + todate + "' and cd.Centre_id = " + obcCLPrinting.Centre_Id + ") " +
                                        " when (select count(*) from CPV_KYC_FE_MAPPING ccf left outer join CPV_KYC_CASE_DETAILS cd on (ccf.case_id=cd.case_id)  where cd.verification_type_id='" + obcCLPrinting.Verification_Type_ID + "' and cd.CASE_REC_DATETIME >='" + obcCLPrinting.Fromdate + "' and cd.CASE_REC_DATETIME<'" + todate + "' and cd.Centre_id = " + obcCLPrinting.Centre_Id + " )" +
                                        " then 'true' else 'false' end  as Result";
                            strResult3 = (string)(OleDbHelper.ExecuteScalar(objconn.ConnectionString, CommandType.Text, strFEAssi));
                        }
                        if (obcCLPrinting.Product_ID == "1018")
                        {
                            strFEAssi = " select case (select count(*) from CPV_IDOC_VERIFICATION_TYPE ccv inner join CPV_IDOC_CASE_DETAILS cd  on(cd.case_id=ccv.case_id) where verification_type_id='" + obcCLPrinting.Verification_Type_ID + "' and cd.CASE_REC_DATETIME >='" + obcCLPrinting.Fromdate + "' and cd.CASE_REC_DATETIME<'" + todate + "' and cd.Centre_id = " + obcCLPrinting.Centre_Id + ") " +
                                        " when (select count(*) from CPV_IDOC_FE_CASE_MAPPING ccf left outer join CPV_IDOC_CASE_DETAILS cd on (ccf.case_id=cd.case_id)  where verification_type_id='" + obcCLPrinting.Verification_Type_ID + "' and cd.CASE_REC_DATETIME >='" + obcCLPrinting.Fromdate + "' and cd.CASE_REC_DATETIME<'" + todate + "' and cd.Centre_id = " + obcCLPrinting.Centre_Id + " )" +
                                        " then 'true' else 'false' end  as Result";

                            strResult4 = (string)(OleDbHelper.ExecuteScalar(objconn.ConnectionString, CommandType.Text, strFEAssi));
                        }
                    }

                    int k = 0;
                    if (strResult == "true" && strResult1 == "true" && strResult2 == "true" && strResult3 == "true" && strResult4 == "true")
                    {

                        strCC = "+ ISNULL(DEPARTMENT,'') AS Field1,ISNULL(FIRST_NAME,'') AS Field2,CASE WHEN MOBILE IS NULL OR RTRIM(LTRIM(MOBILE)) = '' THEN NULL ELSE +'(M:) '+ MOBILE END  AS Field3,ISNULL(REF_NO,'') AS Field4,ISNULL(RES_ADD_LINE_1,'') AS Field5,ISNULL(RES_ADD_LINE_2,'') AS Field6,ISNULL(RES_ADD_LINE_3,'') AS Field7,ISNULL(RES_CITY,'') AS Field8,ISNULL(RES_LAND_MARK,'') AS Field9,CASE WHEN RES_PHONE IS NULL OR RTRIM(LTRIM(RES_PHONE)) = '' THEN NULL ELSE +'(RP:) '+ RES_PHONE END AS Field10,ISNULL(RES_PIN_CODE,'') AS Field11,'' AS Field12,SR_NO,VERIFICATION_CODE,Convert(varchar(11),CASE_REC_DATETIME,103) as CASE_REC_DATETIME, A.CASE_ID";

                        strKYC = "+ ISNULL(DEPARTMENT,'') AS Field1,ISNULL(FIRST_NAME,'') AS Field2,CASE WHEN MOBILE IS NULL OR RTRIM(LTRIM(MOBILE)) = '' THEN NULL ELSE +'(M:) '+ MOBILE END  AS Field3,ISNULL(REF_NO,'') AS Field4,ISNULL(RES_ADD_LINE_1,'') AS Field5,ISNULL(RES_ADD_LINE_2,'') AS Field6,ISNULL(RES_ADD_LINE_3,'') AS Field7,ISNULL(RES_CITY,'') AS Field8,ISNULL(RES_LAND_MARK,'') AS Field9,CASE WHEN RES_PHONE IS NULL OR RTRIM(LTRIM(RES_PHONE)) = '' THEN NULL ELSE +'(RP:) '+ RES_PHONE END AS Field10,ISNULL(RES_PIN_CODE,'') AS Field11,'' AS Field12,SR_NO,Verification_Type_Code as VERIFICATION_CODE,Convert(varchar(11),CASE_REC_DATETIME,103) as CASE_REC_DATETIME, A.CASE_ID";

                      
                        strRL = "+ ISNULL(DEPARTMENT,'') AS Field1,ISNULL(FIRST_NAME,'') AS Field2,CASE WHEN MOBILE IS NULL OR RTRIM(LTRIM(MOBILE)) = '' THEN NULL ELSE +'(M:) '+ MOBILE END  AS Field3,ISNULL(REF_NO,'') AS Field4,ISNULL(RES_ADD_LINE_1,'') AS Field5,ISNULL(RES_ADD_LINE_2,'') AS Field6,ISNULL(RES_ADD_LINE_3,'') AS Field7,ISNULL(RES_CITY,'') AS Field8,ISNULL(RES_LAND_MARK,'') AS Field9,CASE WHEN RES_PHONE IS NULL OR RTRIM(LTRIM(RES_PHONE)) = '' THEN NULL ELSE +'(RP:) '+ RES_PHONE END AS Field10,ISNULL(RES_PIN_CODE,'') AS Field11,'' AS Field12,SR_NO,VERIFICATION_CODE,Convert(varchar(11),CASE_REC_DATETIME,103) as CASE_REC_DATETIME, A.CASE_ID";

                        strIDOC = "+ ISNULL(DEPARTMENT,'') AS Field1,ISNULL(FIRST_NAME,'') AS Field2,CASE WHEN MOBILE IS NULL OR RTRIM(LTRIM(MOBILE)) = '' THEN NULL ELSE +'(M:) '+ MOBILE END  AS Field3,ISNULL(REF_NO,'') AS Field4,ISNULL(RES_ADD_LINE_1,'') AS Field5,ISNULL(RES_ADD_LINE_2,'') AS Field6,ISNULL(RES_ADD_LINE_3,'') AS Field7,ISNULL(RES_CITY,'') AS Field8,ISNULL(RES_LAND_MARK,'') AS Field9,CASE WHEN RES_PHONE IS NULL OR RTRIM(LTRIM(RES_PHONE)) = '' THEN NULL ELSE +'(RP:) '+ RES_PHONE END AS Field10,ISNULL(RES_PIN_CODE,'') AS Field11,'' AS Field12,SR_NO,VERIFICATION_CODE,Convert(varchar(11),CASE_REC_DATETIME,103) as CASE_REC_DATETIME, A.CASE_ID";

                        strEBC = "+ ISNULL(DEPARTMENT,'') AS Field1,ISNULL(FIRST_NAME,'') AS Field2,CASE WHEN MOBILE IS NULL OR RTRIM(LTRIM(MOBILE)) = '' THEN NULL ELSE +'(M:) '+ MOBILE END  AS Field3,ISNULL(REF_NO,'') AS Field4,ISNULL(RES_ADD_LINE_1,'') AS Field5,ISNULL(RES_ADD_LINE_2,'') AS Field6,ISNULL(RES_ADD_LINE_3,'') AS Field7,ISNULL(RES_CITY,'') AS Field8,ISNULL(RES_LAND_MARK,'') AS Field9,CASE WHEN RES_PHONE IS NULL OR RTRIM(LTRIM(RES_PHONE)) = '' THEN NULL ELSE +'(RP:) '+ RES_PHONE END AS Field10,ISNULL(RES_PIN_CODE,'') AS Field11,'' AS Field12,SR_NO,VERIFICATION_CODE,Convert(varchar(11),CASE_REC_DATETIME,103) as CASE_REC_DATETIME, A.CASE_ID";


                        if (Session["RoleId"].ToString() == "2")
                        {
                            strquery1 = "select count(*) from CPV_CC_CASE_VERIFICATIONTYPE where  IS_LABLE_PRINT='N' ";
                            object o = OleDbHelper.ExecuteScalar(objconn.ConnectionString, CommandType.Text, strquery1);
                            if (Convert.ToInt32(o) != 0)
                            {
                                selectCriteria = " AND IS_LABLE_PRINT='N'";
                            }
                              strSQL = " SELECT FW.fullname as fe_name,(FW.fullname +'-'+ FW.EMP_CODE) as fe_code,FW.EMP_CODE as fe_code,dbo.GetPrBarCode(" + Session["ProductId"].ToString() + ")+a.case_id+dbo.GetVeriBarCode(" + obcCLPrinting.Verification_Type_ID + ") as BrCode, " +
                                     " (a.case_id +'~'+'" + obcCLPrinting.Verification_Type_ID + "' +'~'+'" + Session["ProductId"].ToString() + "'+'~'+'" + Session["ClientId"].ToString() + "') as BarCode, " + strSQL + " FROM " + strTableName + " A INNER JOIN CPV_CC_CASE_VERIFICATIONTYPE B ON A.CASE_ID=B.CASE_ID " +
                                     " left outer join CPV_CC_FE_CASE_MAPPING CFECM on(CFECM.case_id=a.case_id and CFECM.VERIFICATION_TYPE_ID='" + obcCLPrinting.Verification_Type_ID + "') " +
                                     " left outer join FE_VW FW on(CFECM.FE_ID=FW.EMP_id)  " +
                                     " WHERE b.VERIFICATION_TYPE_ID='" + obcCLPrinting.Verification_Type_ID + "' AND case_rec_datetime >= '" + obcCLPrinting.Fromdate + "'  and " +
                                     " case_rec_datetime < '" + todate + "' and a.Centre_id = " + obcCLPrinting.Centre_Id + " and  Client_id =" + obcCLPrinting.Client_ID + " " + selectCriteria + " order by FW.fullname";
                        }
                        else
                        {
                            string strC = "";
                            if (strCC == "")
                            {
                                strC = "";
                            }
                            else
                            {
                                strC = ",";
                            }
                            //-----------
                            string strR = "";
                            if (strRL == "")
                            {
                                strR = "";
                            }
                            else
                            {
                                strR = ",";
                            }
                            //-----------
                            string strI = "";
                            if (strIDOC == "")
                            {
                                strI = "";
                            }
                            else
                            {
                                strI = ",";
                            }
                            //--------------
                            string strK = "";
                            if (strKYC == "")
                            {
                                strK = "";
                            }
                            else
                            {
                                strK = ",";
                            }
                            //--------------
                            string strE = "";
                            if (strEBC == "")
                            {
                                strE = "";
                            }
                            else
                            {
                                strE = ",";
                            }
                            if (obcCLPrinting.Product_ID == "1011")
                            {
                                         strSQL = " SELECT (FW.fullname +'-'+ FW.EMP_CODE) as fe_code,dbo.GetPrBarCode(" + obcCLPrinting.Product_ID + ")+a.case_id+dbo.GetVeriBarCode(" + obcCLPrinting.Verification_Type_ID + ") as BrCode, " +
                                         " (a.case_id +'~'+'" + obcCLPrinting.Verification_Type_ID + "' +'~'+'" + obcCLPrinting.Product_ID + "'+'~'+ CM.Client_id ) as BarCode,CM.Client_Name as fe_name  " + strC + strCC +

                                         " FROM  CPV_CC_CASE_DETAILS  A INNER JOIN CPV_CC_CASE_VERIFICATIONTYPE B ON A.CASE_ID=B.CASE_ID " +
                                         " left outer join CPV_CC_FE_CASE_MAPPING CFECM on(CFECM.case_id=a.case_id and CFECM.VERIFICATION_TYPE_ID='" + obcCLPrinting.Verification_Type_ID + "') " +
                                         " left outer join FE_VW FW on(CFECM.FE_ID=FW.EMP_id) left outer join Client_Master CM on CM.Client_id=A.Client_ID  " +
                                         " WHERE b.VERIFICATION_TYPE_ID='" + obcCLPrinting.Verification_Type_ID + "' AND case_rec_datetime >= '" + obcCLPrinting.Fromdate + "'  and " +
                                         " case_rec_datetime < '" + todate + "' and a.Centre_id = '" + obcCLPrinting.Centre_Id + "'And CFECM.FE_ID in( " + strSQLE1 + ")" + selectCriteria + " order by FW.fullname ";
                            }

                            //string strSQLR;
                            //strSQL += " UNION ALL ";
                            if (obcCLPrinting.Product_ID == "1012")
                            {
                                strSQLR = "SELECT (FW.fullname +'-'+ FW.EMP_CODE) as fe_code,dbo.GetPrBarCode(" + obcCLPrinting.Product_ID + ")+a.case_id+dbo.GetVeriBarCode(" + obcCLPrinting.Verification_Type_ID + ") as BrCode, " +
                                        " (a.case_id +'~'+'" + obcCLPrinting.Verification_Type_ID + "' +'~'+'" + obcCLPrinting.Product_ID + "'+'~'+ CM.Client_id ) as BarCode,CM.Client_Name as fe_name  " + strR + strRL +
                                        " FROM  CPV_RL_CASE_DETAILS  A INNER JOIN CPV_RL_CASE_VERIFICATIONTYPE B ON A.CASE_ID=B.CASE_ID left outer join Client_Master CM on CM.Client_id=A.Client_ID  " +
                                        " left outer join CPV_RL_CASE_FE_MAPPING CFECM on(CFECM.case_id=a.case_id and CFECM.VERIFICATION_TYPE_ID='" + obcCLPrinting.Verification_Type_ID + "') " +
                                        " left outer join FE_VW FW on(CFECM.FE_ID=FW.EMP_id)  " +
                                        " WHERE b.VERIFICATION_TYPE_ID='" + obcCLPrinting.Verification_Type_ID + "' AND case_rec_datetime >= '" + obcCLPrinting.Fromdate + "'  and " +
                                        " case_rec_datetime < '" + todate + "' and a.Centre_id = '" + obcCLPrinting.Centre_Id + "'And CFECM.FE_ID in( " + strSQLE1 + ")" + selectCriteria + " order by FW.fullname ";
                            }
                            //string strSQLI;
                            //strSQL += " UNION ALL";
                            if (obcCLPrinting.Product_ID == "1015")
                            {
                    
                                strSQLK = "SELECT (FW.fullname +'-'+ FW.EMP_CODE) as fe_code,dbo.GetPrBarCode(" + obcCLPrinting.Product_ID + ")+a.case_id+dbo.GetVeriBarCode(" + obcCLPrinting.Verification_Type_ID + ") as BrCode, " +
                                          " (a.case_id +'~'+'" + obcCLPrinting.Verification_Type_ID + "' +'~'+'" + obcCLPrinting.Product_ID + "'+'~'+CM.Client_id ) as BarCode,CM.Client_Name as fe_name " + strK + strKYC +
                                          " FROM  CPV_KYC_CASE_DETAILS A  INNER JOIN CPV_KYC_VERIFICATION_TYPE B ON A.CASE_ID=B.CASE_ID " +
                                          " left outer join CPV_KYC_FE_MAPPING CFECM on(CFECM.case_id=a.case_id and CFECM.VERIFICATION_TYPE_ID='" + obcCLPrinting.Verification_Type_ID + "') " +
                                          " left outer join FE_VW FW on(CFECM.FE_ID=FW.EMP_id) left outer join Client_Master CM on CM.Client_id=A.Client_ID left outer join verification_Type_Master VM on VM.VERIFICATION_TYPE_ID=CFECM.VERIFICATION_TYPE_ID " +
                                          " WHERE b.VERIFICATION_TYPE_ID='" + obcCLPrinting.Verification_Type_ID + "' AND case_rec_datetime >= '" + obcCLPrinting.Fromdate + "'  and " +
                                          " case_rec_datetime < '" + todate + "' and a.Centre_id = '" + obcCLPrinting.Centre_Id + "'And CFECM.FE_ID in ( " + strSQLE1 + ")" + selectCriteria + " order by FW.fullname ";
                            }
                            //strSQL += " UNION ALL";
                            //string strSQLK;Ods.Tables[0].Rows.Count == 0
                            if (obcCLPrinting.Product_ID == "1016")
                            {
                            strSQLE = "SELECT FW.fullname as fe_name,(FW.fullname +'-'+ FW.EMP_CODE) as fe_code,dbo.GetPrBarCode(" + obcCLPrinting.Product_ID + ")+a.case_id+dbo.GetVeriBarCode(" + obcCLPrinting.Verification_Type_ID + ") as BrCode, " +
                                      " (a.case_id +'~'+'" + obcCLPrinting.Verification_Type_ID + "' +'~'+'" + obcCLPrinting.Product_ID + "'+'~'+ CM.Client_id ) as BarCode,CM.Client_Name as fe_name " + strE + strEBC +
                                      " FROM  CPV_EBC_CASE_DETAILS  A INNER JOIN CPV_EBC_VAERIFICATION_TYPE B ON A.CASE_ID=B.CASE_ID " +
                                      " left outer join CPV_EBC_FE_MAPPING CFECM on(CFECM.case_id=a.case_id and CFECM.VERIFICATION_TYPE_ID='" + obcCLPrinting.Verification_Type_ID + "') " +
                                      " left outer join FE_VW FW on(CFECM.FE_ID=FW.EMP_id) left outer join Client_Master CM on CM.Client_id=A.Client_ID " +
                                      " WHERE b.VERIFICATION_TYPE_ID='" + obcCLPrinting.Verification_Type_ID + "' AND case_rec_datetime >= '" + obcCLPrinting.Fromdate + "'  and " +
                                      " case_rec_datetime < '" + todate + "' and a.Centre_id = '" + obcCLPrinting.Centre_Id + "'And CFECM.FE_ID in ( " + strSQLE1 + ")" + selectCriteria + " order by FW.fullname ";
                         
                            }
                            //strSQL += " UNION ALL";
                            //string strSQLE;
                            if (obcCLPrinting.Product_ID == "1018")
                            {
                                strSQLI = "SELECT FW.fullname as fe_name,(FW.fullname +'-'+ FW.EMP_CODE) as fe_code,dbo.GetPrBarCode(" + obcCLPrinting.Product_ID + ")+a.case_id+dbo.GetVeriBarCode(" + obcCLPrinting.Verification_Type_ID + ") as BrCode, " +
                                          " (a.case_id +'~'+'" + obcCLPrinting.Verification_Type_ID + "' +'~'+'" + obcCLPrinting.Product_ID + "'+'~'+ CM.Client_id ) as BarCode,CM.Client_Name as fe_name " + strI + strIDOC +
                                          " FROM  CPV_IDOC_CASE_DETAILS  A INNER JOIN CPV_IDOC_VERIFICATION_TYPE B ON A.CASE_ID=B.CASE_ID " +
                                          " left outer join CPV_IDOC_FE_CASE_MAPPING CFECM on(CFECM.case_id=a.case_id and CFECM.VERIFICATION_TYPE_ID='" + obcCLPrinting.Verification_Type_ID + "') " +
                                          " left outer join FE_VW FW on(CFECM.FE_ID=FW.EMP_id) left outer join Client_Master CM on CM.Client_id=A.Client_ID  " +
                                          " WHERE b.VERIFICATION_TYPE_ID='" + obcCLPrinting.Verification_Type_ID + "' AND case_rec_datetime >= '" + obcCLPrinting.Fromdate + "'  and " +
                                          " case_rec_datetime < '" + todate + "' and a.Centre_id = '" + obcCLPrinting.Centre_Id + "'And CFECM.FE_ID in ( " + strSQLE1 + ")" + selectCriteria + " order by FW.fullname ";

                        }


                        }

                    }
                    else
                    {
                        lblMsg.Text = "Ensure 100% FE Asssignment for label printing.";
                        k = 1;
                    }


                    //End of Code for restriction about Supervisor //

                    OleDbConnection con = new OleDbConnection(objconn.ConnectionString);//kamal
                    {

                        ParameterField p1 = new ParameterField();
                        ParameterDiscreteValue d1 = new ParameterDiscreteValue();
                        ParameterField p2 = new ParameterField();
                        ParameterDiscreteValue d2 = new ParameterDiscreteValue();
                        ParameterField p3 = new ParameterField();
                        ParameterDiscreteValue d3 = new ParameterDiscreteValue();
                        ParameterFields parcol = new ParameterFields();
                        p1.Name = "Verification_Type";
                        d1.Value = Session["Verification_Type"];
                        p1.CurrentValues.Add(d1);
                        parcol.Add(p1);

                        p2.Name = "add1";
                        d2.Value = strAdditional1;
                        p2.CurrentValues.Add(d2);
                        parcol.Add(p2);

                        p3.Name = "add2";
                        d3.Value = strAdditional2;
                        p3.CurrentValues.Add(d3);
                        parcol.Add(p3);

                        Session["ParameterCollection"] = parcol;
                        DataSet Ods = new DataSet();
                        con.Open();
               

                        bool flag1 = true;
                        if (k == 0)
                        {
                            if (obcCLPrinting.Product_ID == "1011")
                            {
                                OleDbDataAdapter da = new OleDbDataAdapter(strSQL, con);
                                da.Fill(Ods);
                                Ods.Tables[0].TableName = "LblPrinting";
                                Session["dataset"] = Ods;
                            }
                            if (obcCLPrinting.Product_ID == "1012")
                            {
                                OleDbDataAdapter da1 = new OleDbDataAdapter(strSQLR, con);
                                da1.Fill(Ods);
                                Ods.Tables[0].TableName = "LblPrinting";
                                Session["dataset"] = Ods;
                            }
                            if (obcCLPrinting.Product_ID == "1015")
                            {
                               

                                OleDbDataAdapter da3 = new OleDbDataAdapter(strSQLK, con);
                                da3.Fill(Ods);
                                Ods.Tables[0].TableName = "LblPrinting";
                                Session["dataset"] = Ods;
                            }
                            if (obcCLPrinting.Product_ID == "1016")
                            {
                                OleDbDataAdapter da4 = new OleDbDataAdapter(strSQLE, con);
                                da4.Fill(Ods);
                                Ods.Tables[0].TableName = "LblPrinting";
                                Session["dataset"] = Ods;
                            }
                            if (obcCLPrinting.Product_ID == "1018")
                            {
                                OleDbDataAdapter da2 = new OleDbDataAdapter(strSQLI, con);
                                da2.Fill(Ods);
                                Ods.Tables[0].TableName = "LblPrinting";
                                Session["dataset"] = Ods;
                            }

                 
                            if (Session["RoleId"].ToString() == "2")
                            {
                                OleDbDataReader dr;
                                string strquery2 = "";
                                string strCaseID = "";
                                bool flag = false;
                                if (obcCLPrinting.Verification_Type_ID != "3" && obcCLPrinting.Verification_Type_ID != "4")
                                {
                                    strquery2 = " select   ccv.case_id from CPV_CC_CASE_VERIFICATIONTYPE ccv inner join cpv_cc_case_details cd " +
                                                " on(cd.case_id=ccv.case_id) left  outer join CPV_CC_FE_CASE_MAPPING ccfm " +
                                                " on(ccv.case_id=ccfm.case_id and ccv.verification_type_id=ccfm.verification_type_id) " +
                                                " where ccv.IS_LABLE_PRINT='N' and  ccfm.VERIFICATION_TYPE_ID ='" + obcCLPrinting.Verification_Type_ID + "' AND case_rec_datetime >= '" + obcCLPrinting.Fromdate + "' AND " +
                                                " case_rec_datetime < '" + todate + "' and Centre_id = " + Session["CentreId"].ToString() + " group by ccv.case_id ";
                                }
                                else
                                {
                                    strquery2 = " select   ccv.case_id from CPV_CC_CASE_VERIFICATIONTYPE ccv inner join cpv_cc_case_details cd " +
                                                " on(cd.case_id=ccv.case_id) " +
                                                " where ccv.IS_LABLE_PRINT='N' and  ccv.VERIFICATION_TYPE_ID ='" + obcCLPrinting.Verification_Type_ID + "' AND case_rec_datetime >= '" + obcCLPrinting.Fromdate + "' AND " +
                                                " case_rec_datetime < '" + todate + "' and Centre_id = " + Session["CentreId"].ToString() + " group by ccv.case_id ";
                                }
                                dr = OleDbHelper.ExecuteReader(objconn.ConnectionString, CommandType.Text, strquery2);
                                while (dr.Read())
                                {
                                    strCaseID = strCaseID + dr["case_id"].ToString() + ',';
                                    flag = true;
                                }
                                dr.Close();

                                if (flag == true)
                                {
                                    string strUpdate = "";
                                    //strUpdate = "update CPV_CC_CASE_VERIFICATIONTYPE set user_id=" + Session["UserId"].ToString() + " , " +
                                    //            "IS_LABLE_PRINT ='Y' where IS_LABLE_PRINT = 'N' and VERIFICATION_TYPE_ID=" + obcCLPrinting.Verification_Type_ID + " and case_id in (" + strCaseID.TrimEnd(',') + ")";

                                    //komal matekar change above code for remove user id ///////////////////////
                                    strUpdate = "update CPV_CC_CASE_VERIFICATIONTYPE set " +
                                                "IS_LABLE_PRINT ='Y' where IS_LABLE_PRINT = 'N' and VERIFICATION_TYPE_ID=" + obcCLPrinting.Verification_Type_ID + " and case_id in (" + strCaseID.TrimEnd(',') + ")";
                                    OleDbHelper.ExecuteNonQuery(objconn.ConnectionString, CommandType.Text, strUpdate);

                                }
                              
                                  if (Ods.Tables[0].Rows.Count == 0)
                                  {
                                    lblMsg.Text = "You are not authorise to reprint the label ";
                                    flag1 = false;
                                  }
                                }


                                if (Ods.Tables.Count != 0)
                                {
                                    if (Ods.Tables[0].Rows.Count == 0 && flag1 == true)
                                    {
                                        lblMsg.Text = "No record found.";
                                        flag1 = false;
                                    }
                                }
                                else
                                {
                                        lblMsg.Text = "No record found.";
                                        flag1 = false;
                                }
                            if (flag1 == true)
                            {
                                Session["Path"] = Server.MapPath("CRTest.rpt");
                                Response.Redirect("../../CrystalReportViewer.aspx?bckPgURL=FE\\FE\\Consolid_LabelPrint.aspx");
                            }


                        }

                    }
                //}
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();
        }
    }
    public string Get_database(DataSet ds)
    {

        DataSet dsLabelQuery = ds.Copy();
        
        strSQLT = "";
        strSQL = "";
        nForField = 0;
        strTableName="";
        blnAllVerificationType="";
        blnLabelPrintingDate="";
        blnSR_NO="";
        strAdditional2="";
        strAdditional1="";
        strVerification_Type_Code = "";

        try
        {
            if (dsLabelQuery.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsLabelQuery.Tables[0].Rows.Count; i++)
                {
                    strVerification_Type_Code = dsLabelQuery.Tables[0].Rows[i]["VERIFICATION_TYPE_CODE"].ToString();
                    strAdditional1 = dsLabelQuery.Tables[0].Rows[i]["ADDITIONAL1"].ToString();
                    strAdditional2 = dsLabelQuery.Tables[0].Rows[i]["ADDITIONAL2"].ToString();
                    blnSR_NO = dsLabelQuery.Tables[0].Rows[i]["SR_NO"].ToString();
                    blnLabelPrintingDate = dsLabelQuery.Tables[0].Rows[i]["LABEL_PRINTING_DATE"].ToString();
                    blnAllVerificationType = dsLabelQuery.Tables[0].Rows[i]["ALL_VERIFICATION_TYPE"].ToString();
                    strTableName = dsLabelQuery.Tables[0].Rows[i]["TABLE_NAME"].ToString();

                    nSRNO = Convert.ToInt32(dsLabelQuery.Tables[0].Rows[i]["LINE_NO"].ToString());


                    if (nPrevSRNO == nSRNO)
                    {
                        if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "MOBILE")
                        {

                            strSQL = strSQL + "+IsNull(CASE WHEN MOBILE IS NULL OR RTRIM(LTRIM(MOBILE)) = '' THEN NULL ELSE +'(M:) '+ MOBILE END,'')";
                        }
                        else if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "OFF_PHONE")
                        {
                            strSQL = strSQL + "+IsNull(CASE WHEN OFF_PHONE IS NULL OR RTRIM(LTRIM(OFF_PHONE)) = '' THEN NULL ELSE +'(OP:) '+ OFF_PHONE END,'')";
                        }
                        else if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "RES_PHONE")
                        {
                            strSQL = strSQL + "+IsNull(CASE WHEN RES_PHONE IS NULL OR RTRIM(LTRIM(RES_PHONE)) = '' THEN NULL ELSE +'(RP:) '+ RES_PHONE END,'')";
                        }
                        else
                        {
                            strSQL = strSQL + "+ ' ' +ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                        }
                    }
                    else if (nPrevSRNO == 0)
                    {

                        if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "MOBILE")
                        {

                            strSQL = strSQL + "+IsNull(CASE WHEN MOBILE IS NULL OR RTRIM(LTRIM(MOBILE)) = '' THEN NULL ELSE +'(M:) '+ MOBILE END,'')";
                        }
                        else if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "OFF_PHONE")
                        {
                            strSQL = strSQL + "+IsNull(CASE WHEN OFF_PHONE IS NULL OR RTRIM(LTRIM(OFF_PHONE)) = '' THEN NULL ELSE +'(OP:) '+ OFF_PHONE END,'')";
                        }
                        else if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "RES_PHONE")
                        {
                            strSQL = strSQL + "+IsNull(CASE WHEN RES_PHONE IS NULL OR RTRIM(LTRIM(RES_PHONE)) = '' THEN NULL ELSE +'(RP:) '+ RES_PHONE END,'')";
                        }
                        else if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "OFF_NAME")
                        {
                            strSQL = strSQL + "+ISNULL(CASE OFF_NAME WHEN ''THEN ''ELSE '(CO) '+OFF_NAME END,'')";
                        }

                        else
                        {
                            strSQL = strSQL + "+ ' ' +ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                        }
                    }
                    else if (nPrevSRNO != nSRNO)
                    {
                        bool flage = false;
                        if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "MOBILE")
                        {
                            flage = true;
                  
                            nForField++;
                            strSQL = strSQL + " AS Field" + nForField + ",IsNull(CASE WHEN MOBILE IS NULL OR RTRIM(LTRIM(MOBILE)) = '' THEN NULL ELSE +'(M:) '+ MOBILE END,'') ";
                        }
                        if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "OFF_PHONE")
                        {
                            flage = true;
                     
                            nForField++;
                            strSQL = strSQL + " AS Field" + nForField + ",IsNull(CASE WHEN OFF_PHONE IS NULL OR RTRIM(LTRIM(OFF_PHONE)) = '' THEN NULL ELSE +'(OP:) '+ OFF_PHONE END,'') ";
                        }
                        if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "RES_PHONE")
                        {
                            flage = true;
               
                            nForField++;
                            strSQL = strSQL + " AS Field" + nForField + ",IsNull(CASE WHEN RES_PHONE IS NULL OR RTRIM(LTRIM(RES_PHONE)) = '' THEN NULL ELSE +'(RP:) '+ RES_PHONE END,'')";
                        }
                        if (Convert.ToString(dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"]) == "OFF_NAME")
                        {
                            flage = true;
                            nForField++;
                          
                            strSQL = strSQL + " AS Field" + nForField + ",CASE WHEN OFF_NAME IS NULL OR RTRIM(LTRIM(OFF_NAME)) = '' THEN NULL ELSE +'(Co:) '+ OFF_NAME END";
                        }

                        if (flage == false)
                        {
                            nForField++;

                            if (strSQL == "")
                            {
                                strSQL = "ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                            }
                            else
                            {
                                strSQL = strSQL + " AS Field" + nForField + ",ISNULL(" + dsLabelQuery.Tables[0].Rows[i]["SELECTED_FIELD"].ToString() + ",'')";
                            }
                         }
                        //}
                    }

                    nPrevSRNO = nSRNO;

                }



                nForField++;
                strSQL = strSQL + " AS Field" + nForField;


                if (nForField <= 12)
                {
                    for (int i = ++nForField; i <= 12; i++)
                    {
                        strSQL = strSQL + ",'' AS Field" + i;
                    }
                }
                if (blnSR_NO == "Y")
                {

                    strSQL = strSQL + "," + "SR_NO";
                }
                if (strTableName != "CPV_KYC_CASE_DETAILS")
                {
                    if (blnAllVerificationType == "Y")
                    {
                        strSQL = strSQL + "," + "VERIFICATION_CODE";
                    }
                }
                else
                {
                    strSQL = strSQL + ",' ' as VERIFICATION_CODE";
                }
                if (blnLabelPrintingDate == "Y")
                {
                    strSQL = strSQL + "," + "Convert(varchar(11),CASE_REC_DATETIME,103) as CASE_REC_DATETIME";
                }
                strSQL = strSQL + "," + " A.CASE_ID";


                strSQLT = strSQL;
               

            }

            else if (dsLabelQuery.Tables[0].Rows.Count == 0)
            {
                icount = 1;
   
            }


        }
        catch (Exception ex)
        {
            Response.Write(ex.Message.ToString());
        }
 
        return strSQLT;
  
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Consolid_LabelPrint.aspx");
    }
}
    
 

   
    
    



