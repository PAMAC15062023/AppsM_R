using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for CProductiveMIS_FE
/// </summary>
public class CProductiveMIS_FE
{
    CCommon connobj = new CCommon();
	public CProductiveMIS_FE()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private string strFromDate;
    public string FromDate
    {
        get { return strFromDate; }
        set { strFromDate = value; }
    }

    private string strToDate;
    public string ToDate
    {
        get { return strToDate; }
        set { strToDate = value; }
    }
    public DataTable FEProductiveMIS(string CentreID, string ClientID, string FEID, string FromDate, string ToDate)
    {
        OleDbConnection con;
        con = new OleDbConnection(connobj.ConnectionString);
        string str = "SELECT FE_ID,(ISNULL (EM.FIRSTNAME,'') +' '+ ISNULL (EM.MIDDLENAME,'') +' '+ ISNULL (EM.LASTNAME,'')) AS [FE Name], " +
          "SUM(TOTAL_CASES) AS [Total Cases],Cast(CAST(SUM(TOTAL_CASES) AS DECIMAL)/CAST(SUM(ASSIGNED_CASES) AS DECIMAL)as decimal(18,2)) AS [AVG PER CASE],CMD.CENTRE_ID,CM.CENTRE_NAME as [Centre Name] ,CMD.CLIENT_ID,CLM.CLIENT_NAME as [Client Name] " +
          "FROM(SELECT A.Total_Cases, A.FE_ID, A.CENTRE_ID, A.CLIENT_ID, B.ASSIGNED_CASES from( " +
          "SELECT  SUM(CASES) as Total_Cases, FE_ID, CENTRE_ID, CLIENT_ID FROM( " +
          "SELECT COUNT(CFEM.CASE_ID) AS CASES,  CFEM.FE_ID,CD.CENTRE_ID,CD.CLIENT_ID " +
          "FROM CPV_CC_FE_CASE_MAPPING AS CFEM INNER JOIN CPV_CC_CASE_DETAILS AS CD ON CFEM.CASE_ID = CD.CASE_ID  " +
          "WHERE CD.CLIENT_ID IN (" + ClientID + ") AND CD.CENTRE_ID IN (" + CentreID + ") AND CFEM.FE_ID IN (" + FEID + ") " +
          "AND CFEM.DATE_TIME >=" + FromDate + " AND CFEM.DATE_TIME <" + ToDate + " GROUP BY  CFEM.FE_ID,CD.CENTRE_ID, CD.CLIENT_ID )a GROUP BY FE_ID, CENTRE_ID, CLIENT_ID ) A, " +
          "(SELECT COUNT(FE_ID) as ASSIGNED_CASES, FE_ID,CENTRE_ID,CLIENT_ID from( " +
          "SELECT    CFEM.FE_ID,CD.CENTRE_ID,CD.CLIENT_ID, CONVERT(VARCHAR(10),CFEM.DATE_TIME,103) AS DATE_TIME " +
          "FROM CPV_CC_FE_CASE_MAPPING AS CFEM INNER JOIN CPV_CC_CASE_DETAILS AS CD ON CFEM.CASE_ID = CD.CASE_ID  " +
          "WHERE CD.CLIENT_ID IN (" + ClientID + ") AND CD.CENTRE_ID IN ( " + CentreID + ") AND CFEM.FE_ID IN (" + FEID + ") " +
          "AND CFEM.DATE_TIME >=" + FromDate + " AND CFEM.DATE_TIME <" + ToDate + " GROUP BY CFEM.FE_ID,CD.CENTRE_ID, CD.CLIENT_ID , CONVERT(VARCHAR(10),CFEM.DATE_TIME,103) " +
          ") a GROUP BY FE_ID,CENTRE_ID, CLIENT_ID ) B " +
          "WHERE A.CLIENT_ID= B.CLIENT_ID and A.CENTRE_ID= B.CENTRE_ID AND A.FE_ID=B.FE_ID " +
          "UNION ALL " +
          "SELECT A.Total_Cases, A.FE_ID, A.CENTRE_ID, A.CLIENT_ID, B.ASSIGNED_CASES from( " +
          "SELECT  SUM(CASES) as Total_Cases, FE_ID, CENTRE_ID, CLIENT_ID " +
          "FROM(SELECT COUNT(CFEM.CASE_ID) AS CASES,  CFEM.FE_ID,CD.CENTRE_ID,CD.CLIENT_ID " +
          "FROM  CPV_RL_CASE_FE_MAPPING AS CFEM INNER JOIN CPV_RL_CASE_DETAILS AS CD ON CFEM.CASE_ID = CD.CASE_ID  " +
          "WHERE CD.CLIENT_ID IN (" + ClientID + ") AND CD.CENTRE_ID IN ( " + CentreID + ") AND CFEM.FE_ID IN (" + FEID + ") " +
          "AND CFEM.ASSIGN_DATETIME >=" + FromDate + " AND CFEM.ASSIGN_DATETIME <" + ToDate + " GROUP BY  CFEM.FE_ID,CD.CENTRE_ID, CD.CLIENT_ID )a GROUP BY FE_ID, CENTRE_ID, CLIENT_ID ) A, " +
          "(SELECT COUNT(FE_ID) as ASSIGNED_CASES, FE_ID,CENTRE_ID,CLIENT_ID from( SELECT    CFEM.FE_ID,CD.CENTRE_ID,CD.CLIENT_ID, CONVERT(VARCHAR(10),CFEM.ASSIGN_DATETIME,103) AS ASSIGN_DATETIME " +
          "FROM CPV_RL_CASE_FE_MAPPING AS CFEM INNER JOIN CPV_RL_CASE_DETAILS AS CD ON CFEM.CASE_ID = CD.CASE_ID  " +
          "WHERE CD.CLIENT_ID IN (" + ClientID + ") AND CD.CENTRE_ID IN ( " + CentreID + ") AND CFEM.FE_ID IN (" + FEID + ") " +
          "AND CFEM.ASSIGN_DATETIME >=" + FromDate + " AND CFEM.ASSIGN_DATETIME <" + ToDate + " GROUP BY CFEM.FE_ID,CD.CENTRE_ID, CD.CLIENT_ID , CONVERT(VARCHAR(10),CFEM.ASSIGN_DATETIME,103)) a GROUP BY FE_ID,CENTRE_ID, CLIENT_ID ) B " +
          "WHERE A.CLIENT_ID= B.CLIENT_ID and A.CENTRE_ID= B.CENTRE_ID AND A.FE_ID=B.FE_ID " +
          "UNION ALL " +
          "SELECT A.Total_Cases, A.FE_ID, A.CENTRE_ID, A.CLIENT_ID, B.ASSIGNED_CASES from( " +
          "SELECT  SUM(CASES) as Total_Cases, FE_ID, CENTRE_ID, CLIENT_ID " +
          "FROM(SELECT COUNT(CFEM.CASE_ID) AS CASES,  CFEM.FE_ID,CD.CENTRE_ID,CD.CLIENT_ID " +
          "FROM CPV_EBC_FE_MAPPING AS CFEM INNER JOIN CPV_EBC_CASE_DETAILS AS CD ON CFEM.CASE_ID = CD.CASE_ID  " +
          "WHERE CD.CLIENT_ID IN (" + ClientID + ") AND CD.CENTRE_ID IN ( " + CentreID + ") AND CFEM.FE_ID IN ( " + FEID + ") " +
          "AND CFEM.DATE_TIME >=" + FromDate + " AND CFEM.DATE_TIME <" + ToDate + " GROUP BY  CFEM.FE_ID,CD.CENTRE_ID, CD.CLIENT_ID )a " +
          "GROUP BY FE_ID, CENTRE_ID, CLIENT_ID ) A, " +
          "(SELECT COUNT(FE_ID) as ASSIGNED_CASES, FE_ID,CENTRE_ID,CLIENT_ID from(SELECT    CFEM.FE_ID,CD.CENTRE_ID,CD.CLIENT_ID, CONVERT(VARCHAR(10),CFEM.DATE_TIME,103) AS DATE_TIME " +
          "FROM CPV_EBC_FE_MAPPING AS CFEM INNER JOIN CPV_EBC_CASE_DETAILS AS CD ON CFEM.CASE_ID = CD.CASE_ID  " +
          "WHERE CD.CLIENT_ID IN (" + ClientID + ") AND CD.CENTRE_ID IN ( " + CentreID + ") AND CFEM.FE_ID IN (" + FEID + ") " +
          "AND CFEM.DATE_TIME >=" + FromDate + " AND CFEM.DATE_TIME <" + ToDate + " " +
          "GROUP BY CFEM.FE_ID,CD.CENTRE_ID, CD.CLIENT_ID , CONVERT(VARCHAR(10),CFEM.DATE_TIME,103)) a GROUP BY FE_ID,CENTRE_ID, CLIENT_ID ) B " +
          "WHERE A.CLIENT_ID= B.CLIENT_ID and A.CENTRE_ID= B.CENTRE_ID AND A.FE_ID=B.FE_ID " +
          "UNION ALL " +
          "SELECT A.Total_Cases, A.FE_ID, A.CENTRE_ID, A.CLIENT_ID, B.ASSIGNED_CASES from(SELECT  SUM(CASES) as Total_Cases, FE_ID, CENTRE_ID, CLIENT_ID " +
          "FROM(SELECT     COUNT(CFEM.CASE_ID) AS CASES,  CFEM.FE_ID,CD.CENTRE_ID,CD.CLIENT_ID " +
          "FROM  CPV_KYC_FE_MAPPING AS CFEM INNER JOIN CPV_KYC_CASE_DETAILS AS CD ON CFEM.CASE_ID = CD.CASE_ID  " +
          "WHERE CD.CLIENT_ID IN (" + ClientID + ") AND CD.CENTRE_ID IN ( " + CentreID + ") AND CFEM.FE_ID IN (" + FEID + ") " +
          "AND CFEM.DATE_TIME >=" + FromDate + " AND CFEM.DATE_TIME <" + ToDate + " GROUP BY  CFEM.FE_ID,CD.CENTRE_ID, CD.CLIENT_ID )a GROUP BY FE_ID, CENTRE_ID, CLIENT_ID ) A, " +
          "(SELECT COUNT(FE_ID) as ASSIGNED_CASES, FE_ID,CENTRE_ID,CLIENT_ID from( SELECT    CFEM.FE_ID,CD.CENTRE_ID,CD.CLIENT_ID, CONVERT(VARCHAR(10),CFEM.DATE_TIME,103) AS DATE_TIME " +
          "FROM  CPV_KYC_FE_MAPPING AS CFEM INNER JOIN CPV_KYC_CASE_DETAILS AS CD ON CFEM.CASE_ID = CD.CASE_ID  " +
          "WHERE CD.CLIENT_ID IN (" + ClientID + ") AND CD.CENTRE_ID IN ( " + CentreID + ") AND CFEM.FE_ID IN (" + FEID + ") " +
          "AND CFEM.DATE_TIME >=" + FromDate + " AND CFEM.DATE_TIME <" + ToDate + " GROUP BY CFEM.FE_ID,CD.CENTRE_ID, CD.CLIENT_ID , CONVERT(VARCHAR(10),CFEM.DATE_TIME,103)) a GROUP BY FE_ID,CENTRE_ID, CLIENT_ID ) B " +
          "WHERE A.CLIENT_ID= B.CLIENT_ID and A.CENTRE_ID= B.CENTRE_ID AND A.FE_ID=B.FE_ID " +
          "union all " +
          "SELECT A.Total_Cases, A.FE_ID, A.CENTRE_ID, A.CLIENT_ID, B.ASSIGNED_CASES from( " +
          "SELECT  SUM(CASES) as Total_Cases, FE_ID, CENTRE_ID, CLIENT_ID FROM( " +
          "SELECT     COUNT(CFEM.CASE_ID) AS CASES,  CFEM.FE_ID,CD.CENTRE_ID,CD.CLIENT_ID FROM CPV_IDOC_FE_CASE_MAPPING AS CFEM INNER JOIN CPV_IDOC_CASE_DETAILS AS CD ON CFEM.CASE_ID = CD.CASE_ID  " +
          "WHERE CD.CLIENT_ID IN (" + ClientID + ") AND CD.CENTRE_ID IN ( " + CentreID + ") " +
          "AND CFEM.FE_ID IN (" + FEID + ") AND CFEM.DATE_TIME >=" + FromDate + " AND CFEM.DATE_TIME <" + ToDate + " GROUP BY  CFEM.FE_ID,CD.CENTRE_ID, CD.CLIENT_ID )a " +
          "GROUP BY FE_ID, CENTRE_ID, CLIENT_ID ) A, " +
          "(SELECT COUNT(FE_ID) as ASSIGNED_CASES, FE_ID,CENTRE_ID,CLIENT_ID from( " +
          "SELECT    CFEM.FE_ID,CD.CENTRE_ID,CD.CLIENT_ID, CONVERT(VARCHAR(10),CFEM.DATE_TIME,103) AS DATE_TIME " +
          "FROM CPV_IDOC_FE_CASE_MAPPING AS CFEM INNER JOIN CPV_IDOC_CASE_DETAILS AS CD ON CFEM.CASE_ID = CD.CASE_ID  " +
          "WHERE CD.CLIENT_ID IN (" + ClientID + ") AND CD.CENTRE_ID IN ( " + CentreID + ") AND CFEM.FE_ID IN (" + FEID + ") " +
          "AND CFEM.DATE_TIME >=" + FromDate + " AND CFEM.DATE_TIME <" + ToDate + " GROUP BY CFEM.FE_ID,CD.CENTRE_ID, CD.CLIENT_ID , CONVERT(VARCHAR(10),CFEM.DATE_TIME,103)) a " +
          "GROUP BY FE_ID,CENTRE_ID, CLIENT_ID ) B " +
          "WHERE A.CLIENT_ID= B.CLIENT_ID and A.CENTRE_ID= B.CENTRE_ID AND A.FE_ID=B.FE_ID " +
          "union all " +
          "SELECT A.Total_Cases, A.FE_ID, A.CENTRE_ID, A.CLIENT_ID, B.ASSIGNED_CASES from( " +
          "SELECT  SUM(CASES) as Total_Cases, FE_ID, CENTRE_ID, CLIENT_ID " +
          "FROM(SELECT     COUNT(CFEM.CASE_ID) AS CASES,  CFEM.FE_ID,CD.CENTRE_ID,CD.CLIENT_ID " +
          "FROM CPV_CELLULAR_FE_CASE_MAPPING AS CFEM INNER JOIN CPV_CELLULAR_CASES AS CD ON CFEM.CASE_ID = CD.CASE_ID  " +
          "WHERE CD.CLIENT_ID IN (" + ClientID + ") AND CD.CENTRE_ID IN ( " + CentreID + ") AND CFEM.FE_ID IN (" + FEID + ") " +
          "AND CFEM.DATE_TIME >=" + FromDate + " AND CFEM.DATE_TIME <" + ToDate + " GROUP BY  CFEM.FE_ID,CD.CENTRE_ID, CD.CLIENT_ID )a " +
          "GROUP BY FE_ID, CENTRE_ID, CLIENT_ID ) A, " +
          "(SELECT COUNT(FE_ID) as ASSIGNED_CASES, FE_ID,CENTRE_ID,CLIENT_ID from( " +
          "SELECT CFEM.FE_ID,CD.CENTRE_ID,CD.CLIENT_ID, CONVERT(VARCHAR(10),CFEM.DATE_TIME,103) AS DATE_TIME " +
          "FROM CPV_CELLULAR_FE_CASE_MAPPING AS CFEM INNER JOIN CPV_CELLULAR_CASES AS CD ON CFEM.CASE_ID = CD.CASE_ID  " +
          "WHERE CD.CLIENT_ID IN (" + ClientID + ") AND CD.CENTRE_ID IN ( " + CentreID + ") AND CFEM.FE_ID IN (" + FEID + ") " +
          "AND CFEM.DATE_TIME >=" + FromDate + " AND CFEM.DATE_TIME <" + ToDate + " GROUP BY CFEM.FE_ID,CD.CENTRE_ID, CD.CLIENT_ID , CONVERT(VARCHAR(10),CFEM.DATE_TIME,103) ) a GROUP BY FE_ID,CENTRE_ID, CLIENT_ID ) B " +
          "WHERE A.CLIENT_ID= B.CLIENT_ID and A.CENTRE_ID= B.CENTRE_ID AND A.FE_ID=B.FE_ID) CMD " +
          "INNER JOIN EMPLOYEE_MASTER AS EM ON CMD.FE_ID = EM.EMP_ID INNER JOIN " +
          "CENTRE_MASTER AS CM ON CMD.CENTRE_ID = CM.CENTRE_ID INNER JOIN CLIENT_MASTER AS CLM ON CMD.CLIENT_ID = CLM.CLIENT_ID " +
          "GROUP BY FE_ID,CMD.CENTRE_ID,CMD.CLIENT_ID,CLIENT_NAME, CENTRE_NAME,  " +
          "(ISNULL (EM.FIRSTNAME,'') +' '+ ISNULL (EM.MIDDLENAME,'') +' '+ ISNULL (EM.LASTNAME,'')) ORDER BY FE_ID ";
        DataTable dt = new DataTable();
        dt = OleDbHelper.ExecuteDataset(con, CommandType.Text, str).Tables[0];
        return dt;
    }



    public DataTable FEProductiveMIS_1(string CentreID, string ClientID, string FEID)
    {
        OleDbConnection con;
        con = new OleDbConnection(connobj.ConnectionString);
        string wherestr = "";
            
        //    " Where";
        //wherestr+=" date between '" + FromDate + "' AND "+ToDate+"'";
        if (ClientID!="0")
            wherestr+=" and client_id='"+ClientID+"'";
        if (CentreID != "0")
            wherestr += " and centre_id='" + CentreID + "'";
        if (FEID != "0")
            wherestr += " and m.fe_id='" + FEID + "'";
        
     

        //string str = "select e.fullname as 'Fe Name',count(case_id) as 'Total Cases',CLM.CLIENT_NAME as 'Client Name',CM.CENTRE_NAME as 'Centre Name' from " +
        //            "(select  m.fe_id,m.case_id,c.centre_id,c.client_id from " +
        //            "CPV_CC_FE_CASE_MAPPING m " +
        //            "join CPV_CC_VERI_ATTEMPTS a on m.case_id=a.case_id and m.verification_type_id=a.verification_type_id " +
        //            " Left Outer join CPV_CC_CASE_DETAILS c on m.case_id=c.case_id " +
        //            "where m.DATE_TIME >='" + FromDate + "' AND m.DATE_TIME <'" + ToDate + "'" + wherestr +
        //            " union all " +

        //            "select  m.fe_id,m.case_id,c.centre_id,c.client_id from " +
        //            "CPV_RL_CASE_FE_MAPPING m  " +
        //            "join CPV_RL_VERIFICATION_ATTEMPT a on m.case_id=a.case_id and m.verification_type_id=a.verification_type_id " +
        //            " Left Outer join CPV_rl_CASE_DETAILS c on m.case_id=c.case_id " +
        //            "where m.ASSIGN_DATETIME >='" + FromDate + "' AND m.ASSIGN_DATETIME <'" + ToDate + "'" + wherestr +
        //            " union all " +

        //            "select  m.fe_id,m.case_id,c.centre_id,c.client_id from " +
        //            "CPV_EBC_FE_MAPPING  m  " +
        //            "join CPV_EBC_VERI_ATTEMPTS a on m.case_id=a.case_id and m.verification_type_id=a.verification_type_id " +
        //            " Left Outer join CPV_ebc_CASE_DETAILS c on m.case_id=c.case_id " +
        //            "where m.DATE_TIME >='" + FromDate + "' AND m.DATE_TIME <'" + ToDate + "'" + wherestr +
        //            " union all " +

        //            "select  m.fe_id,m.case_id,c.centre_id,c.client_id from " +
        //            "CPV_kyC_FE_MAPPING  m " +
        //            "join CPV_KYC_VERI_ATTEMPTS a on m.case_id=a.case_id  and m.verification_type_id=a.verification_type_id " +
        //            "Left Outer join CPV_KYC_CASE_DETAILS c on m.case_id=c.case_id " +
        //            "where m.DATE_TIME >='" + FromDate + "' AND m.DATE_TIME <'" + ToDate + "'" + wherestr +
        //            " union all " +

        //            "select  m.fe_id,m.case_id,c.centre_id,c.client_id from " +
        //            "CPV_IDOC_FE_CASE_MAPPING m  " +
        //             "join CPV_IDOC_VERI_ATTEMPTS a on m.case_id=a.case_id  and m.verification_type_id=a.verification_type_id " +
        //             " Left Outer join CPV_IDOC_CASE_DETAILS c on m.case_id=c.case_id " +
        //             "where m.DATE_TIME >='" + FromDate + "' AND m.DATE_TIME <'" + ToDate + "'" + wherestr +
        //            " union all " +

        //            "select  m.fe_id,m.case_id,c.centre_id,c.client_id from " +
        //            "CPV_CELLULAR_FE_CASE_MAPPING  m  " +
        //            "join CPV_CELLULAR_VERI_ATTEMPTS a on m.case_id=a.case_id  and m.verification_type_id=a.verification_type_id " +
        //             " Left Outer join CPV_CELLULAR_CASES c on m.case_id=c.case_id " +
        //            "where m.DATE_TIME >='" + FromDate + "' AND m.DATE_TIME <'" + ToDate + "'" + wherestr +
        //            ") mis " +
        //            "join employee_master e on mis.fe_id=e.emp_id " +
        //            "JOIN CENTRE_MASTER AS CM ON mis.CENTRE_ID = CM.CENTRE_ID " +
        //            "JOIN CLIENT_MASTER AS CLM ON mis.CLIENT_ID = CLM.CLIENT_ID " +
        //            "group by e.fullname,CM.CENTRE_NAME,CLM.CLIENT_NAME ";


        string str = "select e.fullname as 'Fe Name',count(case_id) as 'Total Cases',CLM.CLIENT_NAME as 'Client Name',CM.CENTRE_NAME as 'Centre Name' from " +
          "(select  m.fe_id,m.case_id,c.centre_id,c.client_id from " +
          "CPV_CC_FE_CASE_MAPPING m " +
            //"join CPV_CC_VERI_ATTEMPTS a on m.case_id=a.case_id and m.verification_type_id=a.verification_type_id " +
          " Left Outer join CPV_CC_CASE_DETAILS c on m.case_id=c.case_id " +
          "where Send_datetime is not null And  m.DATE_TIME >='" + FromDate + "' AND m.DATE_TIME <'" + ToDate + "'" + wherestr +
          " union all " +

          "select  m.fe_id,m.case_id,c.centre_id,c.client_id from " +
          "CPV_RL_CASE_FE_MAPPING m  " +
            //"join CPV_RL_VERIFICATION_ATTEMPT a on m.case_id=a.case_id and m.verification_type_id=a.verification_type_id " +
          " Left Outer join CPV_rl_CASE_DETAILS c on m.case_id=c.case_id " +
          "where Send_datetime is not null And m.ASSIGN_DATETIME >='" + FromDate + "' AND m.ASSIGN_DATETIME <'" + ToDate + "'" + wherestr +
          " union all " +

          "select  m.fe_id,m.case_id,c.centre_id,c.client_id from " +
          "CPV_EBC_FE_MAPPING  m  " +
            //"join CPV_EBC_VERI_ATTEMPTS a on m.case_id=a.case_id and m.verification_type_id=a.verification_type_id " +
          " Left Outer join CPV_ebc_CASE_DETAILS c on m.case_id=c.case_id " +
          "where Send_datetime is not null And  m.DATE_TIME >='" + FromDate + "' AND m.DATE_TIME <'" + ToDate + "'" + wherestr +
          " union all " +

          "select  m.fe_id,m.case_id,c.centre_id,c.client_id from " +
          "CPV_kyC_FE_MAPPING  m " +
            //"join CPV_KYC_VERI_ATTEMPTS a on m.case_id=a.case_id  and m.verification_type_id=a.verification_type_id " +
          "Left Outer join CPV_KYC_CASE_DETAILS c on m.case_id=c.case_id " +
          "where Send_datetime is not null And m.DATE_TIME >='" + FromDate + "' AND m.DATE_TIME <'" + ToDate + "'" + wherestr +
          " union all " +

          "select  m.fe_id,m.case_id,c.centre_id,c.client_id from " +
          "CPV_IDOC_FE_CASE_MAPPING m  " +
            //"join CPV_IDOC_VERI_ATTEMPTS a on m.case_id=a.case_id  and m.verification_type_id=a.verification_type_id " +
           " Left Outer join CPV_IDOC_CASE_DETAILS c on m.case_id=c.case_id " +
           "where Send_datetime is not null And m.DATE_TIME >='" + FromDate + "' AND m.DATE_TIME <'" + ToDate + "'" + wherestr +
          " union all " +

          "select  m.fe_id,m.case_id,c.centre_id,c.client_id from " +
          "CPV_CELLULAR_FE_CASE_MAPPING  m  " +
            //"join CPV_CELLULAR_VERI_ATTEMPTS a on m.case_id=a.case_id  and m.verification_type_id=a.verification_type_id " +
           " Left Outer join CPV_CELLULAR_CASES c on m.case_id=c.case_id " +
          "where Send_datetime is not null And  m.DATE_TIME >='" + FromDate + "' AND m.DATE_TIME <'" + ToDate + "'" + wherestr +
          ") mis " +
          "join employee_master e on mis.fe_id=e.emp_id " +
          "JOIN CENTRE_MASTER AS CM ON mis.CENTRE_ID = CM.CENTRE_ID " +
          "JOIN CLIENT_MASTER AS CLM ON mis.CLIENT_ID = CLM.CLIENT_ID " +
          "group by e.fullname,CM.CENTRE_NAME,CLM.CLIENT_NAME ";




           // "SELECT FE_ID,(ISNULL (EM.FIRSTNAME,'') +' '+ ISNULL (EM.MIDDLENAME,'') +' '+ ISNULL (EM.LASTNAME,'')) AS [FE Name], " +
        //  "SUM(TOTAL_CASES) AS [Total Cases],Cast(CAST(SUM(TOTAL_CASES) AS DECIMAL)/CAST(SUM(ASSIGNED_CASES) AS DECIMAL)as decimal(18,2)) AS [AVG PER CASE],CMD.CENTRE_ID,CM.CENTRE_NAME as [Centre Name] ,CMD.CLIENT_ID,CLM.CLIENT_NAME as [Client Name] " +
        //  "FROM(SELECT A.Total_Cases, A.FE_ID, A.CENTRE_ID, A.CLIENT_ID, B.ASSIGNED_CASES from( " +
        //  "SELECT  SUM(CASES) as Total_Cases, FE_ID, CENTRE_ID, CLIENT_ID FROM( " +
        //  "SELECT COUNT(CFEM.CASE_ID) AS CASES,  CFEM.FE_ID,CD.CENTRE_ID,CD.CLIENT_ID " +
        //  "FROM CPV_CC_FE_CASE_MAPPING AS CFEM INNER JOIN CPV_CC_CASE_DETAILS AS CD ON CFEM.CASE_ID = CD.CASE_ID  " +
        //  "WHERE CD.CLIENT_ID IN (" + ClientID + ") AND CD.CENTRE_ID IN (" + CentreID + ") AND CFEM.FE_ID IN (" + FEID + ") " +
        //  "AND CFEM.DATE_TIME >='" + FromDate + "' AND CFEM.DATE_TIME <'" + ToDate + "' GROUP BY  CFEM.FE_ID,CD.CENTRE_ID, CD.CLIENT_ID )a GROUP BY FE_ID, CENTRE_ID, CLIENT_ID ) A, " +
        //  "(SELECT COUNT(FE_ID) as ASSIGNED_CASES, FE_ID,CENTRE_ID,CLIENT_ID from( " +
        //  "SELECT    CFEM.FE_ID,CD.CENTRE_ID,CD.CLIENT_ID, CONVERT(VARCHAR(10),CFEM.DATE_TIME,103) AS DATE_TIME " +
        //  "FROM CPV_CC_FE_CASE_MAPPING AS CFEM INNER JOIN CPV_CC_CASE_DETAILS AS CD ON CFEM.CASE_ID = CD.CASE_ID  " +
        //  "WHERE CD.CLIENT_ID IN (" + ClientID + ") AND CD.CENTRE_ID IN ( " + CentreID + ") AND CFEM.FE_ID IN (" + FEID + ") " +
        //  "AND CFEM.DATE_TIME >='" + FromDate + "' AND CFEM.DATE_TIME <'" + ToDate + "' GROUP BY CFEM.FE_ID,CD.CENTRE_ID, CD.CLIENT_ID , CONVERT(VARCHAR(10),CFEM.DATE_TIME,103) " +
        //  ") a GROUP BY FE_ID,CENTRE_ID, CLIENT_ID ) B " +
        //  "WHERE A.CLIENT_ID= B.CLIENT_ID and A.CENTRE_ID= B.CENTRE_ID AND A.FE_ID=B.FE_ID " +
        //  "UNION ALL " +
        //  "SELECT A.Total_Cases, A.FE_ID, A.CENTRE_ID, A.CLIENT_ID, B.ASSIGNED_CASES from( " +
        //  "SELECT  SUM(CASES) as Total_Cases, FE_ID, CENTRE_ID, CLIENT_ID " +
        //  "FROM(SELECT COUNT(CFEM.CASE_ID) AS CASES,  CFEM.FE_ID,CD.CENTRE_ID,CD.CLIENT_ID " +
        //  "FROM  CPV_RL_CASE_FE_MAPPING AS CFEM INNER JOIN CPV_RL_CASE_DETAILS AS CD ON CFEM.CASE_ID = CD.CASE_ID  " +
        //  "WHERE CD.CLIENT_ID IN (" + ClientID + ") AND CD.CENTRE_ID IN ( " + CentreID + ") AND CFEM.FE_ID IN (" + FEID + ") " +
        //  "AND CFEM.ASSIGN_DATETIME >='" + FromDate + "' AND CFEM.ASSIGN_DATETIME <'" + ToDate + "' GROUP BY  CFEM.FE_ID,CD.CENTRE_ID, CD.CLIENT_ID )a GROUP BY FE_ID, CENTRE_ID, CLIENT_ID ) A, " +
        //  "(SELECT COUNT(FE_ID) as ASSIGNED_CASES, FE_ID,CENTRE_ID,CLIENT_ID from( SELECT    CFEM.FE_ID,CD.CENTRE_ID,CD.CLIENT_ID, CONVERT(VARCHAR(10),CFEM.ASSIGN_DATETIME,103) AS ASSIGN_DATETIME " +
        //  "FROM CPV_RL_CASE_FE_MAPPING AS CFEM INNER JOIN CPV_RL_CASE_DETAILS AS CD ON CFEM.CASE_ID = CD.CASE_ID  " +
        //  "WHERE CD.CLIENT_ID IN (" + ClientID + ") AND CD.CENTRE_ID IN ( " + CentreID + ") AND CFEM.FE_ID IN (" + FEID + ") " +
        //  "AND CFEM.ASSIGN_DATETIME >='" + FromDate + "' AND CFEM.ASSIGN_DATETIME <'" + ToDate + "' GROUP BY CFEM.FE_ID,CD.CENTRE_ID, CD.CLIENT_ID , CONVERT(VARCHAR(10),CFEM.ASSIGN_DATETIME,103)) a GROUP BY FE_ID,CENTRE_ID, CLIENT_ID ) B " +
        //  "WHERE A.CLIENT_ID= B.CLIENT_ID and A.CENTRE_ID= B.CENTRE_ID AND A.FE_ID=B.FE_ID " +
        //  "UNION ALL " +
        //  "SELECT A.Total_Cases, A.FE_ID, A.CENTRE_ID, A.CLIENT_ID, B.ASSIGNED_CASES from( " +
        //  "SELECT  SUM(CASES) as Total_Cases, FE_ID, CENTRE_ID, CLIENT_ID " +
        //  "FROM(SELECT COUNT(CFEM.CASE_ID) AS CASES,  CFEM.FE_ID,CD.CENTRE_ID,CD.CLIENT_ID " +
        //  "FROM CPV_EBC_FE_MAPPING AS CFEM INNER JOIN CPV_EBC_CASE_DETAILS AS CD ON CFEM.CASE_ID = CD.CASE_ID  " +
        //  "WHERE CD.CLIENT_ID IN (" + ClientID + ") AND CD.CENTRE_ID IN ( " + CentreID + ") AND CFEM.FE_ID IN ( " + FEID + ") " +
        //  "AND CFEM.DATE_TIME >='" + FromDate + "' AND CFEM.DATE_TIME <'" + ToDate + "' GROUP BY  CFEM.FE_ID,CD.CENTRE_ID, CD.CLIENT_ID )a " +
        //  "GROUP BY FE_ID, CENTRE_ID, CLIENT_ID ) A, " +
        //  "(SELECT COUNT(FE_ID) as ASSIGNED_CASES, FE_ID,CENTRE_ID,CLIENT_ID from(SELECT    CFEM.FE_ID,CD.CENTRE_ID,CD.CLIENT_ID, CONVERT(VARCHAR(10),CFEM.DATE_TIME,103) AS DATE_TIME " +
        //  "FROM CPV_EBC_FE_MAPPING AS CFEM INNER JOIN CPV_EBC_CASE_DETAILS AS CD ON CFEM.CASE_ID = CD.CASE_ID  " +
        //  "WHERE CD.CLIENT_ID IN (" + ClientID + ") AND CD.CENTRE_ID IN ( " + CentreID + ") AND CFEM.FE_ID IN (" + FEID + ") " +
        //  "AND CFEM.DATE_TIME >='" + FromDate + "' AND CFEM.DATE_TIME <'" + ToDate + "' " +
        //  "GROUP BY CFEM.FE_ID,CD.CENTRE_ID, CD.CLIENT_ID , CONVERT(VARCHAR(10),CFEM.DATE_TIME,103)) a GROUP BY FE_ID,CENTRE_ID, CLIENT_ID ) B " +
        //  "WHERE A.CLIENT_ID= B.CLIENT_ID and A.CENTRE_ID= B.CENTRE_ID AND A.FE_ID=B.FE_ID " +
        //  "UNION ALL " +
        //  "SELECT A.Total_Cases, A.FE_ID, A.CENTRE_ID, A.CLIENT_ID, B.ASSIGNED_CASES from(SELECT  SUM(CASES) as Total_Cases, FE_ID, CENTRE_ID, CLIENT_ID " +
        //  "FROM(SELECT     COUNT(CFEM.CASE_ID) AS CASES,  CFEM.FE_ID,CD.CENTRE_ID,CD.CLIENT_ID " +
        //  "FROM  CPV_KYC_FE_MAPPING AS CFEM INNER JOIN CPV_KYC_CASE_DETAILS AS CD ON CFEM.CASE_ID = CD.CASE_ID  " +
        //  "WHERE CD.CLIENT_ID IN (" + ClientID + ") AND CD.CENTRE_ID IN ( " + CentreID + ") AND CFEM.FE_ID IN (" + FEID + ") " +
        //  "AND CFEM.DATE_TIME >='" + FromDate + "' AND CFEM.DATE_TIME <'" + ToDate + "' GROUP BY  CFEM.FE_ID,CD.CENTRE_ID, CD.CLIENT_ID )a GROUP BY FE_ID, CENTRE_ID, CLIENT_ID ) A, " +
        //  "(SELECT COUNT(FE_ID) as ASSIGNED_CASES, FE_ID,CENTRE_ID,CLIENT_ID from( SELECT    CFEM.FE_ID,CD.CENTRE_ID,CD.CLIENT_ID, CONVERT(VARCHAR(10),CFEM.DATE_TIME,103) AS DATE_TIME " +
        //  "FROM  CPV_KYC_FE_MAPPING AS CFEM INNER JOIN CPV_KYC_CASE_DETAILS AS CD ON CFEM.CASE_ID = CD.CASE_ID  " +
        //  "WHERE CD.CLIENT_ID IN (" + ClientID + ") AND CD.CENTRE_ID IN ( " + CentreID + ") AND CFEM.FE_ID IN (" + FEID + ") " +
        //  "AND CFEM.DATE_TIME >='" + FromDate + "' AND CFEM.DATE_TIME <'" + ToDate + "' GROUP BY CFEM.FE_ID,CD.CENTRE_ID, CD.CLIENT_ID , CONVERT(VARCHAR(10),CFEM.DATE_TIME,103)) a GROUP BY FE_ID,CENTRE_ID, CLIENT_ID ) B " +
        //  "WHERE A.CLIENT_ID= B.CLIENT_ID and A.CENTRE_ID= B.CENTRE_ID AND A.FE_ID=B.FE_ID " +
        //  "union all " +
        //  "SELECT A.Total_Cases, A.FE_ID, A.CENTRE_ID, A.CLIENT_ID, B.ASSIGNED_CASES from( " +
        //  "SELECT  SUM(CASES) as Total_Cases, FE_ID, CENTRE_ID, CLIENT_ID FROM( " +
        //  "SELECT     COUNT(CFEM.CASE_ID) AS CASES,  CFEM.FE_ID,CD.CENTRE_ID,CD.CLIENT_ID FROM CPV_IDOC_FE_CASE_MAPPING AS CFEM INNER JOIN CPV_IDOC_CASE_DETAILS AS CD ON CFEM.CASE_ID = CD.CASE_ID  " +
        //  "WHERE CD.CLIENT_ID IN (" + ClientID + ") AND CD.CENTRE_ID IN ( " + CentreID + ") " +
        //  "AND CFEM.FE_ID IN (" + FEID + ") AND CFEM.DATE_TIME >='" + FromDate + "' AND CFEM.DATE_TIME <'" + ToDate + "' GROUP BY  CFEM.FE_ID,CD.CENTRE_ID, CD.CLIENT_ID )a " +
        //  "GROUP BY FE_ID, CENTRE_ID, CLIENT_ID ) A, " +
        //  "(SELECT COUNT(FE_ID) as ASSIGNED_CASES, FE_ID,CENTRE_ID,CLIENT_ID from( " +
        //  "SELECT    CFEM.FE_ID,CD.CENTRE_ID,CD.CLIENT_ID, CONVERT(VARCHAR(10),CFEM.DATE_TIME,103) AS DATE_TIME " +
        //  "FROM CPV_IDOC_FE_CASE_MAPPING AS CFEM INNER JOIN CPV_IDOC_CASE_DETAILS AS CD ON CFEM.CASE_ID = CD.CASE_ID  " +
        //  "WHERE CD.CLIENT_ID IN (" + ClientID + ") AND CD.CENTRE_ID IN ( " + CentreID + ") AND CFEM.FE_ID IN (" + FEID + ") " +
        //  "AND CFEM.DATE_TIME >='" + FromDate + "' AND CFEM.DATE_TIME <'" + ToDate + "' GROUP BY CFEM.FE_ID,CD.CENTRE_ID, CD.CLIENT_ID , CONVERT(VARCHAR(10),CFEM.DATE_TIME,103)) a " +
        //  "GROUP BY FE_ID,CENTRE_ID, CLIENT_ID ) B " +
        //  "WHERE A.CLIENT_ID= B.CLIENT_ID and A.CENTRE_ID= B.CENTRE_ID AND A.FE_ID=B.FE_ID " +
        //  "union all " +
        //  "SELECT A.Total_Cases, A.FE_ID, A.CENTRE_ID, A.CLIENT_ID, B.ASSIGNED_CASES from( " +
        //  "SELECT  SUM(CASES) as Total_Cases, FE_ID, CENTRE_ID, CLIENT_ID " +
        //  "FROM(SELECT     COUNT(CFEM.CASE_ID) AS CASES,  CFEM.FE_ID,CD.CENTRE_ID,CD.CLIENT_ID " +
        //  "FROM CPV_CELLULAR_FE_CASE_MAPPING AS CFEM INNER JOIN CPV_CELLULAR_CASES AS CD ON CFEM.CASE_ID = CD.CASE_ID  " +
        //  "WHERE CD.CLIENT_ID IN (" + ClientID + ") AND CD.CENTRE_ID IN ( " + CentreID + ") AND CFEM.FE_ID IN (" + FEID + ") " +
        //  "AND convert(varchar,CFEM.DATE_TIME,103) >='" + FromDate + "' AND convert(varchar,CFEM.DATE_TIME,103) <'" + ToDate + "' GROUP BY  CFEM.FE_ID,CD.CENTRE_ID, CD.CLIENT_ID )a " +
        //  "GROUP BY FE_ID, CENTRE_ID, CLIENT_ID ) A, " +
        //  "(SELECT COUNT(FE_ID) as ASSIGNED_CASES, FE_ID,CENTRE_ID,CLIENT_ID from( " +
        //  "SELECT CFEM.FE_ID,CD.CENTRE_ID,CD.CLIENT_ID, CONVERT(VARCHAR(10),CFEM.DATE_TIME,103) AS DATE_TIME " +
        //  "FROM CPV_CELLULAR_FE_CASE_MAPPING AS CFEM INNER JOIN CPV_CELLULAR_CASES AS CD ON CFEM.CASE_ID = CD.CASE_ID  " +
        //  "WHERE CD.CLIENT_ID IN (" + ClientID + ") AND CD.CENTRE_ID IN ( " + CentreID + ") AND CFEM.FE_ID IN (" + FEID + ") " +
        //  "AND convert(varchar,CFEM.DATE_TIME,103) >='" + FromDate + "' AND convert(varchar,CFEM.DATE_TIME,103) <'" + ToDate + "' GROUP BY CFEM.FE_ID,CD.CENTRE_ID, CD.CLIENT_ID , CONVERT(VARCHAR(10),CFEM.DATE_TIME,103) ) a GROUP BY FE_ID,CENTRE_ID, CLIENT_ID ) B " +
        //  "WHERE A.CLIENT_ID= B.CLIENT_ID and A.CENTRE_ID= B.CENTRE_ID AND A.FE_ID=B.FE_ID) CMD " +
        //  "INNER JOIN EMPLOYEE_MASTER AS EM ON CMD.FE_ID = EM.EMP_ID INNER JOIN " +
        //  "CENTRE_MASTER AS CM ON CMD.CENTRE_ID = CM.CENTRE_ID INNER JOIN CLIENT_MASTER AS CLM ON CMD.CLIENT_ID = CLM.CLIENT_ID " +
        //  "GROUP BY FE_ID,CMD.CENTRE_ID,CMD.CLIENT_ID,CLIENT_NAME, CENTRE_NAME,  " +
        //  "(ISNULL (EM.FIRSTNAME,'') +' '+ ISNULL (EM.MIDDLENAME,'') +' '+ ISNULL (EM.LASTNAME,'')) ORDER BY FE_ID ";
        DataTable dt = new DataTable();
        dt = OleDbHelper.ExecuteDataset(con, CommandType.Text, str).Tables[0];
        return dt;
    }
}
