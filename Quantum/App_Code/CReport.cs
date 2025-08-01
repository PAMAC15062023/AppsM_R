/*----------------------------------------------------------------------------------------
Scope of Program	:	
File Name			:	CReport.cs
Create By			:	Hemangi Kambli
Create Date		    :	16th May 2007
Remarks 		    :	This is class used for getting sql queries for all reports.
						
----------------------------------------------------------------------------------------*/
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

/// <summary>
/// Summary description for CReport
/// </summary>
public class CReport
{
    CCommon objCmn = new CCommon();
	public CReport()
	{
		//
		// TODO: Add constructor logic here
		//
    }
    private string svalue;
    private string sCaseType;
    public string value
    {
        get { return svalue; }
        set { svalue = value; }
    }
    public string CaseType
    {
        get { return sCaseType; }
        set { sCaseType = value; }
    }
    #region GetPendingReportList()
    //Name              :   GetPendingReportList
    //Create By			:	Hemangi Kambli
    //Create Date		:	16th May 2007
    //Remarks 		    :	This function is used to get records for PendingList report.

    public DataSet GetPendingReportList(string sFromDate, String sToDate, string sClientId, string sCentreId)
    {
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");
        string sSql = "";
        sSql = "SELECT distinct SR_NO,REF_NO, FIRST_NAME, LAST_NAME, MIDDLE_NAME," +
               " (ISNULL(FIRST_NAME + ' ', '') +ISNULL(MIDDLE_NAME + ' ', '') + ISNULL(LAST_NAME + ' ', '')) AS Name," +
               " CONVERT(VARCHAR(24), CASE_REC_DATETIME,103) As RECD_DATE , " +
               " (ISNULL(RES_ADD_LINE_1+' ','') + ISNULL(RES_ADD_LINE_2+' ','') + ISNULL(RES_ADD_LINE_3+' ','') + ISNULL(RES_CITY + ' ','') + ISNULL (RES_STATE + ' ','') + ISNULL(RES_PIN_CODE + ' ','')) AS [Residence Address], "+ 
               " (ISNULL(OFF_ADD_LINE_1+' ','') + ISNULL(OFF_ADD_LINE_2+' ','') + ISNULL(OFF_ADD_LINE_3+' ','')+ ISNULL(OFF_CITY + ' ','') + ISNULL(OFF_STATE + ' ','') + ISNULL(OFF_PIN_CODE +' ',''))AS[Office Address], "+
               " VERIFICATION_CODE as FV_REQUIRED,RES_CITY, OFF_NAME,CASE_ID,Res_Phone As Rv_Tel,Mobile,Off_Phone as Bv_Tel," +
               " '" +Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
               " '" +Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
               " 'PAMAC Online' as COMPANYNAME " +
               " ,(select distinct top 1 fw.fullname from CPV_CC_CASE_VERIFICATIONTYPE CCV left outer join CPV_CC_FE_CASE_MAPPING CCFM on(CCV.case_id=CCFM.case_id and CCFM.verification_type_id=1) "+
			   " left outer join FE_VW FW on(CCFM.FE_ID=FW.emp_id) where CCV. case_id=cd.case_id) as [RV-FEName], "+
               " (select distinct top 1 fw.fullname from CPV_CC_CASE_VERIFICATIONTYPE CCV left outer join CPV_CC_FE_CASE_MAPPING CCFM on(CCV.case_id=CCFM.case_id and CCFM.verification_type_id=2) " +
			   " left outer join FE_VW FW on(CCFM.FE_ID=FW.emp_id) where CCV. case_id=cd.case_id) as [BV-FEName] , "+
               " (select distinct top 1 fw.fullname from CPV_CC_CASE_VERIFICATIONTYPE CCV left outer join CPV_CC_FE_CASE_MAPPING CCFM on(CCV.case_id=CCFM.case_id and CCFM.verification_type_id=10) " +
               " left outer join FE_VW FW on(CCFM.FE_ID=FW.emp_id) where CCV. case_id=cd.case_id) as [PRV-FEName],CARD_TYPE  " + 
               " FROM  CPV_CC_CASE_DETAILS cd " +
               " WHERE (SEND_DATETIME IS NULL) " +
               " AND CASE_REC_DATETIME >= '" + sFromDate + "'" +
               " AND CASE_REC_DATETIME < '" + sToDate + "'" +
               " AND CLIENT_ID='" + sClientId + "'" +
               " AND CENTRE_ID='" + sCentreId + "'";

        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetClaimMISReport()

    #region GetIdocPendingReportList for IDOC
    public DataSet GetIdocPendingReportList(string sFromDate, String sToDate, string sClientId, string sCentreId)
    {
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");

          string sSql = "SELECT (vtm. VERIFICATION_type) As [Verification Type],cd.ref_no as[Ref no],cm.client_name as[Client name], cd.Case_ID as [Case ID], (isNull(cd.FIRST_NAME,'')+' '+isnull(cd.MIDDLE_NAME,'')+' '+isnull(cd.LAST_NAME,'')) as [Name]," +
                        "CONVERT(Varchar(24), cd.CASE_REC_DATETIME, 106) As  [Recieved on] , " +
                        "'" +Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
                        "'" +Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
                        "'PAMAC Online' as COMPANYNAME,fev.FULLNAME AS [FE Name]  FROM client_master cm inner join  CPV_IDOC_CASE_DETAILS cd on(cd.client_id=cm.client_id) inner join cpv_idoc_verification_type vt"+
                        " on(cd.case_id=vt.case_id) inner join verification_type_master vtm on(vt.verification_type_id=vtm.verification_type_id) left outer join CPV_IDOC_FE_CASE_MAPPING fem on(fem.VERIFICATION_TYPE_ID=vtm.verification_type_id and fem.case_id=vt.case_id) left outer join FE_VW fev on(fev.EMP_ID=fem.FE_ID ) WHERE (cd.SEND_DATETIME IS NULL)" +
                        "AND cd.CASE_REC_DATETIME >= '" + sFromDate + "' AND cd.CASE_REC_DATETIME < '" + sToDate + "' AND cd.CLIENT_ID='" + sClientId + "' " +
                        "AND CD.CENTRE_ID='" + sCentreId + "'";
        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion

    # region GetKYC_PendingListReport()
    public DataSet GetKYCPendingReportList(string sFromDate, String sToDate, string sClientId, string sCentreId)
    {
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");

        string sSql = "SELECT (vtm. VERIFICATION_type) As [Verification Type],cd.ref_no as[Ref no],cm.client_name as[Client name], cd.Case_ID as [Case ID], (isNull(cd.FIRST_NAME,'')+' '+isnull(cd.MIDDLE_NAME,'')+' '+isnull(cd.LAST_NAME,'')) as [Name]," +
                      "CONVERT(Varchar(24), cd.CASE_REC_DATETIME, 106) As  [Recieved on] , " +
                      "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
                      "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
                      "'PAMAC Online' as COMPANYNAME  FROM client_master cm inner join  CPV_KYC_CASE_DETAILS cd on(cd.client_id=cm.client_id) inner join cpv_KYC_verification_type vt on(cd.case_id=vt.case_id ) inner join verification_type_master vtm on(vt.verification_type_id=vtm.verification_type_id) WHERE (cd.SEND_DATETIME IS NULL)" +
                      "AND cd.CASE_REC_DATETIME >= '" + sFromDate + "' AND cd.CASE_REC_DATETIME < '" + sToDate + "' AND cd.CLIENT_ID='" + sClientId + "' " +
                      "AND CENTRE_ID='" + sCentreId + "'";
        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    # endregion GetKYC_PendingListReport()

    #region GetClaimMISReport()
    //Name              :   GetClaimMISReport
    //Create By			:	Gargi Srivastava
    //Create Date		:	16th May 2007
    //Remarks 		    :	This function is used to get records for Claim MIS report.

    public DataSet GetClaimMISReport(string sFromDate, String sToDate, string sClientId, string sCentreId)
    {
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");

        string sSql = "";
        sSql = " select distinct cd.case_id, cd.REF_NO AS REFNO,cm.client_name as [CLIENT NAME]," +
                "(isNull(cd.FIRST_NAME,'')+' '+isnull(cd.MIDDLE_NAME,'')+' '+isnull(cd.LAST_NAME,'')) as [Applicant Name]," +
                "Convert(varchar(24),cd.CASE_REC_DATETIME,103)as [Received Date] ," +
                "Convert(varchar(24),cd.SEND_DATETIME,103)as [Send Date]," +
                "case cd.WITHIN_TAT when 1 then 'Yes' else 'No' end as [WITHIN TAT] , cd.SEND_DATETIME, " +
                " (select count(cs.case_id) from cpv_cc_case_details cs inner join CPV_CC_CASE_VERIFICATIONTYPE CCV on(cs.case_id=CCV.case_id) "+
                " where verification_type_id ='1' and SEND_DATETIME >= '" + sFromDate + "' and SEND_DATETIME< '" + sToDate + "' and CLIENT_ID='" + sClientId + "' and CENTRE_ID='" + sCentreId + "') as CRV  , " +
                " case rv.verification_type_id when 1 then '1' else '0' end as [RV], " +
                " (select count(cs.case_id) from cpv_cc_case_details cs inner join CPV_CC_CASE_VERIFICATIONTYPE CCV on(cs.case_id=CCV.case_id) "+
                " where verification_type_id ='2' and SEND_DATETIME >= '" + sFromDate + "' and SEND_DATETIME< '" + sToDate + "' and CLIENT_ID='" + sClientId + "' and CENTRE_ID='" + sCentreId + "') as CBV  , " +
                " case bv.verification_type_id when 2 then '1' else '0' end as [BV], " +
                " (select count(cs.case_id) from cpv_cc_case_details cs inner join CPV_CC_CASE_VERIFICATIONTYPE CCV on(cs.case_id=CCV.case_id) "+
                " where verification_type_id ='10' and SEND_DATETIME >= '" + sFromDate + "' and SEND_DATETIME< '" + sToDate + "' and CLIENT_ID='" + sClientId + "' and CENTRE_ID='" + sCentreId + "') as CPRV , " +
                " case prv.verification_type_id when 10 then '1' else '0' end as [PRV], " +
                " (select count(cs.case_id) from cpv_cc_case_details cs inner join CPV_CC_CASE_VERIFICATIONTYPE CCV on(cs.case_id=CCV.case_id) "+
                " where verification_type_id ='4' and SEND_DATETIME >= '" + sFromDate + "' and SEND_DATETIME< '" + sToDate + "' and CLIENT_ID='" + sClientId + "' and CENTRE_ID='" + sCentreId + "') as  CRT , " +
                " case rt.verification_type_id when 4 then '1' else '0' end as [RT],  " +
                " (select count(cs.case_id) from cpv_cc_case_details cs inner join CPV_CC_CASE_VERIFICATIONTYPE CCV on(cs.case_id=CCV.case_id) "+
                " where verification_type_id ='3' and SEND_DATETIME >= '" + sFromDate + "' and SEND_DATETIME< '" + sToDate + "' and CLIENT_ID='" + sClientId + "' and CENTRE_ID='" + sCentreId + "')  as CBT ,  " +
                " case bt.verification_type_id when 3 then '1' else '0' end as [BT], " +
                "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FromDate, " +
                "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as Todate, " +
                "'Pamac Online' as CompanyName " +
                " From CPV_CC_CASE_DETAILS as cd " +
                " left outer join CPV_CC_CASE_VERIFICATIONTYPE as rv on cd.CASE_ID=rv.CASE_ID and rv.verification_type_id='1' "+
                " left outer join CPV_CC_CASE_VERIFICATIONTYPE as bv on cd.CASE_ID=bv.CASE_ID and bv.verification_type_id='2' "+
                " left outer join CPV_CC_CASE_VERIFICATIONTYPE as rt on cd.CASE_ID=rt.CASE_ID and rt.verification_type_id='4' "+
                " left outer join CPV_CC_CASE_VERIFICATIONTYPE as bt on cd.CASE_ID=bt.CASE_ID and bt.verification_type_id='3' "+
                " left outer join CPV_CC_CASE_VERIFICATIONTYPE as prv on cd.CASE_ID=prv.CASE_ID and prv.verification_type_id='10' "+ 
                " inner join CLIENT_MASTER as cm on cd.CLIENT_ID=cm.CLIENT_ID where cd.SEND_DATETIME >= " +
                "'" + sFromDate + "'" +
                "and cd.SEND_DATETIME < " +
                "'" + sToDate + "'" +
                "AND cd.CLIENT_ID='" + sClientId + "'" +
                "AND CENTRE_ID='" + sCentreId + "'" +
                "group by cd.REF_NO,cd.FIRST_NAME,cd.MIDDLE_NAME,cd.LAST_NAME,CASE_REC_DATETIME,cd.SEND_DATETIME,cd.WITHIN_TAT,cm.client_name,cd.case_id,rv.verification_type_id,bv.verification_type_id,rt.verification_type_id,bt.verification_type_id,prv.verification_type_id " +
                " order by cd.SEND_DATETIME ";
  

        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetClaimMISReport()

    #region GetClaimMISReport_RL()
    //Name              :   GetClaimMISReport_RL
    //Create By			:	Bipin Singh
    //Create Date		:	02/07/2007
    //Remarks 		    :	This function is used to get records for Claim MIS report.

    public DataSet GetClaimMISReport_RL(string sFromDate, String sToDate, string sClientId, string sCentreId)
    {
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");

        string sSql = "";
        sSql = " select distinct cd.case_id, cd.REF_NO AS REFNO,cm.client_name as [CLIENT NAME]," +
                "(isNull(cd.FIRST_NAME,'')+' '+isnull(cd.MIDDLE_NAME,'')+' '+isnull(cd.LAST_NAME,'')) as [Applicant Name]," +
                "Convert(varchar(24),cd.CASE_REC_DATETIME,103)as [Received Date] ," +
                "Convert(varchar(24),cd.SEND_DATETIME,103)as [Send Date]," +
                "case cd.WITHIN_TAT when 1 then 'Yes' else 'No' end as [WITHIN TAT] , cd.SEND_DATETIME, " +
                " (select count(cs.case_id) from cpv_RL_case_details cs inner join CPV_RL_CASE_VERIFICATIONTYPE CCV on(cs.case_id=CCV.case_id) " +
                " where verification_type_id ='1' and SEND_DATETIME >= '" + sFromDate + "' and SEND_DATETIME< '" + sToDate + "' and CLIENT_ID='" + sClientId + "' and CENTRE_ID='" + sCentreId + "') as CRV  , " +
				" case rv.verification_type_id when 1 then '1' else '0' end as [RV], " +
                " case rv.verification_type_id when 1 then '1' else '0' end as [VALUERV], " +
                " (select count(cs.case_id) from cpv_RL_case_details cs inner join CPV_RL_CASE_VERIFICATIONTYPE CCV on(cs.case_id=CCV.case_id) " +
                " where verification_type_id ='2' and SEND_DATETIME >= '" + sFromDate + "' and SEND_DATETIME< '" + sToDate + "' and CLIENT_ID='" + sClientId + "' and CENTRE_ID='" + sCentreId + "') as CBV  , " +
                " case bv.verification_type_id when 2 then '1' else '0' end as [BV], " +
                " (select count(cs.case_id) from cpv_RL_case_details cs inner join CPV_RL_CASE_VERIFICATIONTYPE CCV on(cs.case_id=CCV.case_id) " +
                " where verification_type_id ='10' and SEND_DATETIME >= '" + sFromDate + "' and SEND_DATETIME< '" + sToDate + "' and CLIENT_ID='" + sClientId + "' and CENTRE_ID='" + sCentreId + "') as CPRV , " +
                " case prv.verification_type_id when 10 then '1' else '0' end as [PRV], " +
                " (select count(cs.case_id) from cpv_RL_case_details cs inner join CPV_RL_CASE_VERIFICATIONTYPE CCV on(cs.case_id=CCV.case_id) " +
                " where verification_type_id ='4' and SEND_DATETIME >= '" + sFromDate + "' and SEND_DATETIME< '" + sToDate + "' and CLIENT_ID='" + sClientId + "' and CENTRE_ID='" + sCentreId + "') as  CRT , " +
                " case rt.verification_type_id when 4 then '1' else '0' end as [RT],  " +
                " (select count(cs.case_id) from cpv_RL_case_details cs inner join CPV_RL_CASE_VERIFICATIONTYPE CCV on(cs.case_id=CCV.case_id) " +
                " where verification_type_id ='3' and SEND_DATETIME >= '" + sFromDate + "' and SEND_DATETIME< '" + sToDate + "' and CLIENT_ID='" + sClientId + "' and CENTRE_ID='" + sCentreId + "')  as CBT ,  " +
                " case bt.verification_type_id when 3 then '1' else '0' end as [BT], " +

                " (select count(cs.case_id) from cpv_RL_case_details cs inner join CPV_RL_CASE_VERIFICATIONTYPE CCV on(cs.case_id=CCV.case_id) " +
                " where verification_type_id ='14' and SEND_DATETIME >= '" + sFromDate + "' and SEND_DATETIME< '" + sToDate + "' and CLIENT_ID='" + sClientId + "' and CENTRE_ID='" + sCentreId + "') as CRCO , " +
                " case rco.verification_type_id when 14 then '1' else '0' end as [RCO], " +

                " (select count(cs.case_id) from cpv_RL_case_details cs inner join CPV_RL_CASE_VERIFICATIONTYPE CCV on(cs.case_id=CCV.case_id) " +
                " where verification_type_id ='12' and SEND_DATETIME >= '" + sFromDate + "' and SEND_DATETIME< '" + sToDate + "' and CLIENT_ID='" + sClientId + "' and CENTRE_ID='" + sCentreId + "') as CREF1 , " +
                " case ref1.verification_type_id when 12 then '1' else '0' end as [REF1], " +

                " (select count(cs.case_id) from cpv_RL_case_details cs inner join CPV_RL_CASE_VERIFICATIONTYPE CCV on(cs.case_id=CCV.case_id) " +
                " where verification_type_id ='13' and SEND_DATETIME >= '" + sFromDate + "' and SEND_DATETIME< '" + sToDate + "' and CLIENT_ID='" + sClientId + "' and CENTRE_ID='" + sCentreId + "') as CREF2 , " +
                " case ref2.verification_type_id when 13 then '1' else '0' end as [REF2], " +


                "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FromDate, " +
                "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as Todate, " +
                "'Pamac Online' as CompanyName " +
                " From CPV_RL_CASE_DETAILS as cd " +
                " left outer join CPV_RL_CASE_VERIFICATIONTYPE as rv on cd.CASE_ID=rv.CASE_ID and rv.verification_type_id='1' " +
                " left outer join CPV_RL_CASE_VERIFICATIONTYPE as bv on cd.CASE_ID=bv.CASE_ID and bv.verification_type_id='2' " +
                " left outer join CPV_RL_CASE_VERIFICATIONTYPE as rt on cd.CASE_ID=rt.CASE_ID and rt.verification_type_id='4' " +
                " left outer join CPV_RL_CASE_VERIFICATIONTYPE as bt on cd.CASE_ID=bt.CASE_ID and bt.verification_type_id='3' " +
                " left outer join CPV_RL_CASE_VERIFICATIONTYPE as prv on cd.CASE_ID=prv.CASE_ID and prv.verification_type_id='10' " +
                " left outer join CPV_RL_CASE_VERIFICATIONTYPE as rco on cd.CASE_ID=rco.CASE_ID and rco.verification_type_id='14' " +
                " left outer join CPV_RL_CASE_VERIFICATIONTYPE as ref1 on cd.CASE_ID=ref1.CASE_ID and ref1.verification_type_id='12' " +
                " left outer join CPV_RL_CASE_VERIFICATIONTYPE as ref2 on cd.CASE_ID=ref2.CASE_ID and ref2.verification_type_id='13' " +
                " inner join CLIENT_MASTER as cm on cd.CLIENT_ID=cm.CLIENT_ID where cd.SEND_DATETIME >= " +
                "'" + sFromDate + "'" +
                "and cd.SEND_DATETIME < " +
                "'" + sToDate + "'" +
                "AND cd.CLIENT_ID='" + sClientId + "'" +
                "AND CENTRE_ID='" + sCentreId + "'" +
                "group by cd.REF_NO,cd.FIRST_NAME,cd.MIDDLE_NAME,cd.LAST_NAME,CASE_REC_DATETIME,cd.SEND_DATETIME,cd.WITHIN_TAT,cm.client_name,cd.case_id,rv.verification_type_id,bv.verification_type_id,rt.verification_type_id,bt.verification_type_id,prv.verification_type_id,rco.verification_type_id,ref1.verification_type_id,ref2.verification_type_id " +
                " order by cd.SEND_DATETIME ";


        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetClaimMISReport()

    # region GetConsolidatedTATMIS()
    public DataSet GetConsolidatedTATMIS(string sFromDate, String sToDate, string sClientId, string sCentreId)
    {

        DataSet ds = new DataSet();
        OleDbConnection con = new OleDbConnection(objCmn.ConnectionString);
        con.Open();
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");
        //CHECK ABOUT CLIENT..(THIS IS FOR CLIENT =1013)...........
       

        string str = "SELECT Convert(varchar(24),CASE_REC_DATETIME,103) as CASE_REC_DATETIME, COUNT(CASE_REC_DATETIME) AS NO, SUM(GRATER) AS WITHIN_TAT, SUM(STANDARD) AS GRATER_THAN_TAT, SUM(PENDING)AS PENDING, " +
                     "CAST((CAST(SUM(GRATER)AS DECIMAL(18,2))/CAST(COUNT(CASE_REC_DATETIME)AS DECIMAL(18,2)))* 100 AS DECIMAL(18,2)) AS PER_WITHIN, " +
                     "CAST(CAST(SUM(STANDARD)AS DECIMAL(18,2))/CAST(COUNT(CASE_REC_DATETIME)AS DECIMAL(18,2))* 100 AS DECIMAL(18,2)) AS PER_GRATER_TAT, " +
                      "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
                      "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
                     "CAST(CAST(SUM(PENDING)AS DECIMAL(18,2))/CAST(COUNT(CASE_REC_DATETIME)AS DECIMAL(18,2))* 100 AS DECIMAL(18,2)) AS PER_PENDING ,'PAMAC Online' as COMPANYNAME  FROM  " +
                     "(SELECT Convert(varchar(24),CASE_REC_DATETIME,103) as CASE_REC_DATETIME, CASE WITHIN_TAT WHEN 1 THEN 1 ELSE 0 END AS 'GRATER',  " +
                     "CASE WITHIN_TAT WHEN 0 THEN 1 ELSE 0 END AS 'STANDARD', SEND_DATETIME, CASE SEND_DATETIME WHEN ISNULL(SEND_DATETIME, '') THEN 0 ELSE 1 END AS 'PENDING' FROM CPV_CC_CASE_DETAILS  " +
                     "WHERE CASE_REC_DATETIME  >= '" + sFromDate + "' AND CASE_REC_DATETIME <'" + sToDate + "' and Client_Id='" + sClientId + "' and centre_id='" + sCentreId + "')AS DERIVETABLE_1  " +
                     "GROUP BY CASE_REC_DATETIME " +
                     "order by CASE_REC_DATETIME";
        ds = OleDbHelper.ExecuteDataset(con, CommandType.Text, str);
        return ds;
    }
    #endregion GetConsolidatedTATMIS()

    # region GetConsolidatedTATMIS_Cel()
    public DataSet GetConsolidatedTATMIS_Cel(string sFromDate, String sToDate, string sClientId, string sCentreId)
    {

        DataSet ds = new DataSet();
        OleDbConnection con = new OleDbConnection(objCmn.ConnectionString);
        con.Open();
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");
        //CHECK ABOUT CLIENT..(THIS IS FOR CLIENT =1013)...........


        string str = "SELECT Convert(varchar(24),CASE_REC_DATETIME,103) as CASE_REC_DATETIME, COUNT(CASE_REC_DATETIME) AS NO, SUM(GRATER) AS WITHIN_TAT, SUM(STANDARD) AS GRATER_THAN_TAT, SUM(PENDING)AS PENDING, " +
                     "CAST((CAST(SUM(GRATER)AS DECIMAL(18,2))/CAST(COUNT(CASE_REC_DATETIME)AS DECIMAL(18,2)))* 100 AS DECIMAL(18,2)) AS PER_WITHIN, " +
                     "CAST(CAST(SUM(STANDARD)AS DECIMAL(18,2))/CAST(COUNT(CASE_REC_DATETIME)AS DECIMAL(18,2))* 100 AS DECIMAL(18,2)) AS PER_GRATER_TAT, " +
                      "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
                      "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
                     "CAST(CAST(SUM(PENDING)AS DECIMAL(18,2))/CAST(COUNT(CASE_REC_DATETIME)AS DECIMAL(18,2))* 100 AS DECIMAL(18,2)) AS PER_PENDING ,'PAMAC Online' as COMPANYNAME  FROM  " +
                     "(SELECT Convert(varchar(24),CASE_REC_DATETIME,103) as CASE_REC_DATETIME, CASE WITHIN_TAT WHEN 1 THEN 1 ELSE 0 END AS 'GRATER',  " +
                     "CASE WITHIN_TAT WHEN 0 THEN 1 ELSE 0 END AS 'STANDARD', SEND_DATETIME, CASE SEND_DATETIME WHEN ISNULL(SEND_DATETIME, '') THEN 0 ELSE 1 END AS 'PENDING' FROM CPV_Cellular_CASES  " +
                     "WHERE CASE_REC_DATETIME  >= '" + sFromDate + "' AND CASE_REC_DATETIME <'" + sToDate + "' and Client_Id='" + sClientId + "' and centre_id='" + sCentreId + "')AS DERIVETABLE_1  " +
                     "GROUP BY CASE_REC_DATETIME " +
                     "order by CASE_REC_DATETIME";
        ds = OleDbHelper.ExecuteDataset(con, CommandType.Text, str);
        return ds;
    }
    #endregion GetConsolidatedTATMIS_Cel()

    # region GetKYC_TATMIS()
    public DataSet GetKYC_TATMIS(string sFromDate, String sToDate, string sClientId, string sCentreId)
    {

        DataSet ds = new DataSet();
        OleDbConnection con = new OleDbConnection(objCmn.ConnectionString);
        con.Open();
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");
        //CHECK ABOUT CLIENT..(THIS IS FOR CLIENT =1013)...........
        string str = "SELECT Convert(varchar(24),CASE_REC_DATETIME,103) as CASE_REC_DATETIME,SEND_DATETIME, COUNT(CASE_REC_DATETIME) AS NO, SUM(GRATER) AS WITHIN_TAT, SUM(STANDARD) AS GRATER_THAN_TAT, SUM(PENDING)AS PENDING, " +
                     "CAST((CAST(SUM(GRATER)AS DECIMAL(18,2))/CAST(COUNT(CASE_REC_DATETIME)AS DECIMAL(18,2)))* 100 AS DECIMAL(18,2)) AS PER_WITHIN, " +
                     "CAST(CAST(SUM(STANDARD)AS DECIMAL(18,2))/CAST(COUNT(CASE_REC_DATETIME)AS DECIMAL(18,2))* 100 AS DECIMAL(18,2)) AS PER_GRATER_TAT, " +
                      "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
                      "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
                     "CAST(CAST(SUM(PENDING)AS DECIMAL(18,2))/CAST(COUNT(CASE_REC_DATETIME)AS DECIMAL(18,2))* 100 AS DECIMAL(18,2)) AS PER_PENDING ,'PAMAC Online' as COMPANYNAME  FROM  " +
                     "(SELECT Convert(varchar(24),CASE_REC_DATETIME,103) as CASE_REC_DATETIME, CASE WITHIN_TAT WHEN 0 THEN 1 ELSE 0 END AS 'GRATER',  " +
                     "CASE WITHIN_TAT WHEN 1 THEN 1 ELSE 0 END AS 'STANDARD', SEND_DATETIME, CASE SEND_DATETIME WHEN ISNULL(SEND_DATETIME, '') THEN 0 ELSE 1 END AS 'PENDING' FROM CPV_KYC_CASE_DETAILS  " +
                     "WHERE CASE_REC_DATETIME >= '" + sFromDate + "' AND   CASE_REC_DATETIME  <'" + sToDate + "' and Client_Id='" + sClientId + "' and centre_id='" + sCentreId + "')AS DERIVETABLE_1  " +
                     "GROUP BY CASE_REC_DATETIME, SEND_DATETIME " +
                     "order by CASE_REC_DATETIME";
        ds = OleDbHelper.ExecuteDataset(con, CommandType.Text, str);
        return ds;
    }
    #endregion GetKYC_TATMIS()

    # region GetConsolidatedTATMIS_RL()
    public DataSet GetConsolidatedTATMIS_RL(string sFromDate, string sToDate, string sClientId, string sCentreId)
    {

        DataSet ds = new DataSet();
        OleDbConnection con = new OleDbConnection(objCmn.ConnectionString);
        con.Open();
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");
        //CHECK ABOUT CLIENT..(THIS IS FOR CLIENT =1013)...........
        string str = "SELECT Convert(varchar(24),CASE_REC_DATETIME,103) as CASE_REC_DATETIME , COUNT(CASE_REC_DATETIME) AS NO, SUM(GRATER) AS WITHIN_TAT, SUM(STANDARD) AS GRATER_THAN_TAT, SUM(PENDING)AS PENDING, " +
                     "CAST((CAST(SUM(GRATER)AS DECIMAL(18,2))/CAST(COUNT(CASE_REC_DATETIME)AS DECIMAL(18,2)))* 100 AS DECIMAL(18,2)) AS PER_WITHIN, " +
                     "CAST(CAST(SUM(STANDARD)AS DECIMAL(18,2))/CAST(COUNT(CASE_REC_DATETIME)AS DECIMAL(18,2))* 100 AS DECIMAL(18,2)) AS PER_GRATER_TAT, " +
                      "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
                      "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
                     "CAST(CAST(SUM(PENDING)AS DECIMAL(18,2))/CAST(COUNT(CASE_REC_DATETIME)AS DECIMAL(18,2))* 100 AS DECIMAL(18,2)) AS PER_PENDING ,'PAMAC Online' as COMPANYNAME   FROM  " +
                     "(SELECT CLIENT_ID,Convert(varchar(24),CASE_REC_DATETIME,103) as CASE_REC_DATETIME, CASE WITHIN_TAT WHEN 1 THEN 1 ELSE 0 END AS 'GRATER',  " +
                     "CASE WITHIN_TAT WHEN 0 THEN 1 ELSE 0 END AS 'STANDARD', SEND_DATETIME, CASE SEND_DATETIME WHEN ISNULL(SEND_DATETIME, '') THEN 0 ELSE 1 END AS 'PENDING' FROM CPV_RL_CASE_DETAILS as cd   " +
                     "WHERE CASE_REC_DATETIME >= '" + sFromDate + "' AND   CASE_REC_DATETIME <'" + sToDate + "' and cd.Client_Id='" + sClientId + "' and centre_id='" + sCentreId + "') AS DERIVETABLE_1     " +
                     "GROUP BY CASE_REC_DATETIME " +
                     "order by CASE_REC_DATETIME";

        
        ds = OleDbHelper.ExecuteDataset(con, CommandType.Text, str);
        return ds;
    }
    #endregion GetConsolidatedTATMIS_RL()

    //----Added by kamal matekar....for Axis Merchant........
    public DataTable GetAxisMerchant_BV(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_AxisMerchantBank_BV_PDFExport", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }




    //----Added by kamal matekar....for KodusFinance RL... RV.....
    public DataTable GetKodusVerification_RV(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_KodusVerification_RV_PDFExport", Resi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable Get_EBC_NEW_Details_Summary(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@Case_Id", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_EBC_SummaryReport", Resi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable Get_EBC_NEW_Details_Summary_Other(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@Case_Id", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_EBC_SummaryReport_Other", Resi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    //--added by kamal_matekar for EBC_NEW Process

    public DataTable Get_EBC_NEW_Details(string strWhere, string StoredProcedureName)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Education = new OleDbParameter[1];
        Education[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Education[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, StoredProcedureName, Education);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    //----Added by kamal matekar....for KodusFinance RL......BV..
    public DataTable GetKodusVerification_BV(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_KudosFinance_BV_PDFExport", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    //--added by kamal_matekar for EBC_NEW Process_For Crystal Report

    public DataTable Get_EBC_Other_Details_For_RV(string strWhere, int VerificationID, int DetailId, int SubVeriID, string StoredProcedureName)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] ResiOther = new OleDbParameter[4];
        ResiOther[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        ResiOther[0].Value = strWhere;

        ResiOther[1] = new OleDbParameter("@Verification_ID", OleDbType.VarChar, 15);
        ResiOther[1].Value = VerificationID;

        ResiOther[2] = new OleDbParameter("@Detail_ID", OleDbType.VarChar, 15);
        ResiOther[2].Value = DetailId;

        ResiOther[3] = new OleDbParameter("@SubVerification_ID", OleDbType.VarChar, 15);
        ResiOther[3].Value = SubVeriID;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, StoredProcedureName, ResiOther);


        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;


    }

    public OleDbDataReader GetRefNoByCaseIdIdoc(string sCaseId)
    {
        string sSql = "SELECT Case_id+'_'+Full_Name as REF_NO from CPV_IDOC_CASE_DETAILS where case_id='" + sCaseId + "'";
        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }

    public DataTable GetCaseIdforReportIdoc(string strWhere)
    {

        DataSet ds = new DataSet();
        //string strSQL = "Select count(v.case_id) as verified, Case_Id from CPV_CC_CASE_DETAILS c, CPV_CC_VERI_OTHER_DETAILS v WHERE (CASE_ID in(" + strWhere + ")) ";
        string strSQL = "Select count(*) as verified, Case_Id from CPV_IDOC_VERIFICATION_TYPE where case_id in(" + strWhere + ") group by case_id";
        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, strSQL);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;

    }

    public DataTable GetIdocIrtCase(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_IdocIrtExport", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }


       //----added by kamal matekar for CPV_CC
    #region CCBifurcationOfCases for CC
    public DataSet CCBifurcationOfCases(string sFromDate, String sToDate, string sClientId, string sCentreId)
    {
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");

        DataSet ds = new DataSet();
        OleDbConnection con = new OleDbConnection(objCmn.ConnectionString);
        con.Open();

        string str = "SELECT " +
                     "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
                     "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
                     "'PAMAC Online' as [COMPANYNAME], " +
                     " CONVERT(VARCHAR,CASE_REC_DATETIME,103) as [RECD DATE]," +
                     " CONVERT(VARCHAR,DATEADD(DAY,1,CASE_REC_DATETIME),103) AS DATE1, " +
                     " CONVERT(VARCHAR,DATEADD(DAY,2,CASE_REC_DATETIME),103) AS DATE2, " +
                     " CONVERT(VARCHAR,DATEADD(DAY,3,CASE_REC_DATETIME),103) AS DATE3, " +
                     " CONVERT(VARCHAR,DATEADD(DAY,4,CASE_REC_DATETIME),103) AS DATE4, " +
                     " CONVERT(VARCHAR,DATEADD(DAY,5,CASE_REC_DATETIME),103) AS DATE5, " +
                     " CONVERT(VARCHAR,DATEADD(DAY,6,CASE_REC_DATETIME),103) AS DATE6, " +
                     " CONVERT(VARCHAR,DATEADD(DAY,7,CASE_REC_DATETIME),103) AS DATE7, " +
                     " CONVERT(VARCHAR,DATEADD(DAY,8,CASE_REC_DATETIME),103) AS DATE8, " +
                     " CONVERT(VARCHAR,DATEADD(DAY,9,CASE_REC_DATETIME),103) AS DATE9, " +
                     " count(case_id) as [RECD CASES],SUM(Day0)as day0, SUM(Day1)as day1,SUM(Day2)as day2," +
                     " SUM(Day3)as day3,SUM(Day4)as day4,SUM(Day5)as day5,  SUM(Day6)as day6,SUM(Day7)as day7, " +
                     " SUM(Day8)as day8,SUM(Day9)as day9,SUM(After9Day) as after9day,SUM(PENDING)as pending " +
                     " FROM " +
                     " (SELECT CASE_REC_DATETIME,SEND_DATETIME,CASE_ID, " +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME))= 0 THEN 1 ELSE 0  END as 'Day0', " +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME))= 1 THEN 1 ELSE 0  END as 'Day1', " +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 2 THEN 1 ELSE 0 END as 'Day2', " +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME))= 3 THEN 1 ELSE 0  END as 'Day3', " +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 4 THEN 1 ELSE 0 END as 'Day4', " +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 5 THEN 1 ELSE 0 END as 'Day5', " +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 6 THEN 1 ELSE 0 END as 'Day6', " +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 7 THEN 1 ELSE 0 END as 'Day7', " +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 8 THEN 1 ELSE 0 END as 'Day8', " +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 9 THEN 1 ELSE 0 END as 'Day9', " +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) > 9 THEN 1 ELSE 0 END as 'After9Day', " +
                     " CASE SEND_DATETIME WHEN ISNULL(SEND_DATETIME, '') THEN 0 ELSE 1 END AS 'PENDING' " +
                     " FROM CPV_CC_CASE_DETAILS " +
                     " WHERE CASE_REC_DATETIME >= '" + sFromDate + "' AND  CASE_REC_DATETIME <'" + sToDate + "'" +
                     " AND Client_Id='" + sClientId + "'and centre_id='" + sCentreId + "') AS EXP1 " +
                     " GROUP BY " +
                     " CONVERT(VARCHAR,CASE_REC_DATETIME,103)," +
                     " CONVERT(VARCHAR,DATEADD(DAY,1,CASE_REC_DATETIME),103)," +
                     " CONVERT(VARCHAR,DATEADD(DAY,2,CASE_REC_DATETIME),103)," +
                     " CONVERT(VARCHAR,DATEADD(DAY,3,CASE_REC_DATETIME),103)," +
                     " CONVERT(VARCHAR,DATEADD(DAY,4,CASE_REC_DATETIME),103)," +
                     " CONVERT(VARCHAR,DATEADD(DAY,5,CASE_REC_DATETIME),103)," +
                     " CONVERT(VARCHAR,DATEADD(DAY,6,CASE_REC_DATETIME),103)," +
                     " CONVERT(VARCHAR,DATEADD(DAY,7,CASE_REC_DATETIME),103)," +
                     " CONVERT(VARCHAR,DATEADD(DAY,8,CASE_REC_DATETIME),103)," +
                     " CONVERT(VARCHAR,DATEADD(DAY,9,CASE_REC_DATETIME),103) ";

        ds = OleDbHelper.ExecuteDataset(con, CommandType.Text, str);
        return ds;
    }
    #endregion

    #region GetFEWiseReport
    public DataSet GetFeReport(string sFromDate, string sToDate, string sClientId, string sCentreId)
    {
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");
        string sSql = "";
        sSql= "SELECT count(cd.case_id) NOOFCASES,(isnull(EM.FIRSTNAME,' ')+' '+isnull(EM.Middlename,' ')+' '+isnull(EM.lastname,' '))"+
              "as FENAME , VM.verification_type_code as VERIFICATIONTYPE , " +
                 "'" +Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
               "'" +Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
                " 'PAMAC Online' as COMPANYNAME " +
              "FROM CPV_CC_FE_CASE_MAPPING FE INNER JOIN CPV_CC_CASE_DETAILS CD ON FE.CASE_ID = CD.CASE_ID "+ 
              "INNER JOIN VERIFICATION_TYPE_MASTER VM ON FE.VERIFICATION_TYPE_ID = VM.VERIFICATION_TYPE_ID "+
              "INNER JOIN EMPLOYEE_MASTER EM ON FE.FE_ID = EM.EMP_ID "+
              "WHERE CD.CLIENT_ID='" + sClientId + "' AND CD.CENTRE_ID='" + sCentreId + "'" +
              "AND fe.date_time >='" + sFromDate + "' AND fe.date_time <'" + sToDate + "'" +
              "group by VM.verification_type_code,EM.FIRSTNAME,EM.Middlename,EM.lastname "+
              "order by EM.FIRSTNAME";
        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetFEWiseReport

    #region StandardOutputReport(Verification) Report
    public DataTable GetBusinessVerificationDtl(string strWhere)
    {
       
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;
        //strSQL = "SELECT  TOP 100 PERCENT vd.VERIFICATION_TYPE_ID, ISNULL(cd.FIRST_NAME + ' ', '') + ISNULL(cd.MIDDLE_NAME + ' ', '') + ISNULL(cd.LAST_NAME + ' ', '') " +
        //              "AS APPLICANT_NAME, cd.REF_NO,d3.AGENCY_NAME, cd.OFF_ADD_LINE_1 AS RES_ADD_LINE_1, cd.OFF_ADD_LINE_2 AS RES_ADD_LINE_2, cd.OFF_ADD_LINE_3 AS RES_ADD_LINE_3, cd.OFF_PIN_CODE AS RES_PIN_CODE, " +
        //              "cd.OFF_PHONE AS RES_PHONE, cd.MOBILE, cd.CASE_ID, d2.DESIGNATION, d2.COMPANY_NAME, d1.OFFICE_TELEPHONE, d2.OFFICE_EXT, d1.LOCALITY, " +
        //              "d1.PORTRAIT, cd.CENTRE_ID, cd.CLIENT_ID, d2.CONTACTED_PERSON_NAME, d2.CONTACTED_PERSON_DESIGN, d2.OFFICE_SIZE, " +
        //              "d2.BUSINESS_TYPE, d2.BUSINESS_ACTIVITY_SEEN, d2.NO_OF_EMP_SIGHTED_IN_PERMISES, d2.CO_APP_NAME, d2.NO_CUSTOMER_PERDAY, " +
        //              "d2.APPLICANT_JOB_TRANSFERABLE, d2.CONSTRUCTION_OFFICE, d2.NO_CUSTOMER_SEEN, d2.DESIGNATION as [JOB_DESC], d2.EMP_JOB_TYPE as JOB_TYPE,d2.OFFICE_IS_IN as [OFFICE_TYPE], " +
        //              "d2.PARTICULARS, d1.PROOF_OF_VISIT_COLLECTED as [VISITING_CARD_OBTAINED],d1.LOCATING_ADDRESS as [EASE_OF_LOCATING_OFFICE], d2.ITEM_SEEN_IN_PERMISES, " +
        //              "d3.OFF_NAME_ON_BOARD as [BUSINESS_BOARD_SEEN_OUTSIDE_BUILDING], CONVERT(char(24), MAX(cvt.ATTEMPT_DATE_TIME), 103) AS VisitDate, " +
        //              "SUBSTRING(CONVERT(varchar(24), MAX(cvt.ATTEMPT_DATE_TIME), 100), 12, 12) AS Time_Of_calling, cvt.VERIFIER_ID, " +
        //              "EMPLOYEE_MASTER.FULLNAME AS Verifier_Name,d2.BUSINESS_PERMISES as OFFICE_OWNERSHIP, d1.BRANCH, d1.APPROXIMATE_AREA,cs.status_name as [RECOMENDATION_NO], " +
        //              "d2.NO_OF_EMP, d2.BUSINESS_NATURE, d2.AVG_MONTH_TURNOVER, d2.OFFICE_LOCALITY, d1.VERIFIED_NEIGHBOUR as [APPLICANT_NAME_VERIFIED_FROM], " +
        //              "d1.ADRESS_CONFIRMATION, d1.INTERIOR, d1.EXTERIOR,d2.TIME_AT_CURRENT_EMPLOYMENT,d2.AFFILATION_POLITICAL_PARTY_SEEN,d2.FE_REMARK, " +
        //              "d1.TPC_DETAILS,d1.ANY_OTHER_INFO_OBT,vd.DECLINED_REASON,vd.SUPERVISOR_REMARKS,d2.TIME_AT_CURRENT_EMPLOYMENT as [NoYrs], " +
        //              "d2.TYPE_OF_OFFICE,d2.APP_WORKING_AS,DCM.DESCRIPTION AS DECLINED_CODE " +
        //              "FROM  EMPLOYEE_MASTER INNER JOIN " +
        //              "CPV_CC_VERI_ATTEMPTS AS cvt ON EMPLOYEE_MASTER.EMP_ID = cvt.VERIFIER_ID RIGHT OUTER JOIN " +
        //              "CPV_CC_VERI_DETAILS AS vd INNER JOIN " +
        //              "CPV_CC_CASE_DETAILS AS cd ON vd.CASE_ID = cd.CASE_ID LEFT OUTER JOIN " +
        //              "CASE_STATUS_MASTER AS cs ON vd.CASE_STATUS_ID = cs.CASE_STATUS_ID LEFT OUTER JOIN " +
        //              "VERIFICATION_TYPE_MASTER AS vt ON vd.VERIFICATION_TYPE_ID = vt.VERIFICATION_TYPE_ID LEFT OUTER JOIN " +
        //              "CPV_CC_VERI_DESCRIPTION AS d1 ON vd.CASE_ID = d1.CASE_ID AND vd.VERIFICATION_TYPE_ID = d1.VERIFICATION_TYPE_ID LEFT OUTER JOIN " +
        //              "CPV_CC_VERI_DESCRIPTION1 AS d2 ON vd.CASE_ID = d2.CASE_ID AND vd.VERIFICATION_TYPE_ID = d2.VERIFICATION_TYPE_ID LEFT OUTER JOIN " +
        //              "CPV_CC_VERI_OTHER_DETAILS AS d3 ON vd.CASE_ID = d3.CASE_ID AND vd.VERIFICATION_TYPE_ID = d3.VERIFICATION_TYPE_ID ON  " +
        //              "cvt.CASE_ID = d3.CASE_ID AND cvt.VERIFICATION_TYPE_ID = vd.VERIFICATION_TYPE_ID " +
        //              " LEFT OUTER JOIN DECLINED_CODE_MASTER DCM ON VD.DECLINED_CODE=DCM.DECLINED_CODE " +
        //              "WHERE (cd.CASE_ID IN (" + strWhere + ")) AND (vt.VERIFICATION_TYPE_CODE = 'BV') " +
        //              "GROUP BY vd.VERIFICATION_TYPE_ID, ISNULL(cd.FIRST_NAME + ' ', '') + ISNULL(cd.MIDDLE_NAME + ' ', '') + ISNULL(cd.LAST_NAME + ' ', ''), cd.REF_NO,  " +
        //              "d3.AGENCY_NAME, cd.OFF_ADD_LINE_1, cd.OFF_ADD_LINE_2, cd.OFF_ADD_LINE_3, cd.OFF_PIN_CODE,cd.OFF_PHONE, cd.MOBILE, cd.CASE_ID,  " +
        //              "d2.DESIGNATION, d2.COMPANY_NAME, d1.OFFICE_TELEPHONE, d2.OFFICE_EXT, d1.LOCALITY, d1.PORTRAIT, cd.CENTRE_ID, cd.CLIENT_ID,  " +
        //              "d2.CONTACTED_PERSON_NAME, d2.CONTACTED_PERSON_DESIGN, d2.OFFICE_SIZE, d2.BUSINESS_TYPE, d2.BUSINESS_ACTIVITY_SEEN,  " +
        //              "d2.NO_OF_EMP_SIGHTED_IN_PERMISES, d2.CO_APP_NAME, d2.NO_CUSTOMER_PERDAY, d2.APPLICANT_JOB_TRANSFERABLE, " +
        //              "d2.CONSTRUCTION_OFFICE, d2.NO_CUSTOMER_SEEN, d2.JOB_DESC, d2.EMP_JOB_TYPE, d2.OFFICE_TYPE, d2.PARTICULARS, " +
        //              "d2.VISITING_CARD_OBTAINED, d2.EASE_OF_LOCATING_OFFICE, d2.ITEM_SEEN_IN_PERMISES," +
        //              "cvt.VERIFIER_ID, EMPLOYEE_MASTER.FULLNAME, d2.OFFICE_OWNERSHIP, d1.BRANCH, d1.APPROXIMATE_AREA, d2.RECOMENDATION_NO,  " +
        //              "d2.NO_OF_EMP, d2.BUSINESS_NATURE, d2.AVG_MONTH_TURNOVER, d2.OFFICE_LOCALITY, d2.APPLICANT_NAME_VERIFIED_FROM, " +
        //              "d1.ADRESS_CONFIRMATION, cd.DESIGNATION,d1.INTERIOR, d1.EXTERIOR, d2.TIME_AT_CURRENT_EMPLOYMENT,d3.OFF_NAME_ON_BOARD, " +
        //              "d1.LOCATING_ADDRESS,d2.AFFILATION_POLITICAL_PARTY_SEEN,d1.VERIFIED_NEIGHBOUR,d1.PROOF_OF_VISIT_COLLECTED,d2.DESIGNATION,"+
        //              "d2.OFFICE_IS_IN,cs.status_name,d2.FE_REMARK,d1.TPC_DETAILS,d1.ANY_OTHER_INFO_OBT,"+
        //              "vd.DECLINED_REASON,vd.SUPERVISOR_REMARKS,d2.BUSINESS_PERMISES,d2.TYPE_OF_OFFICE ,d2.APP_WORKING_AS,DCM.DESCRIPTION  ";

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetBusinessVerificationDtl", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetBusinessVerificationDtl_DLB(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetBusinessVerificationDtl_DLB", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetBusinessVerificationDtl_Qc(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;
        //strSQL = "SELECT  TOP 100 PERCENT vd.VERIFICATION_TYPE_ID, ISNULL(cd.FIRST_NAME + ' ', '') + ISNULL(cd.MIDDLE_NAME + ' ', '') + ISNULL(cd.LAST_NAME + ' ', '') " +
        //              "AS APPLICANT_NAME, cd.REF_NO,d3.AGENCY_NAME, cd.OFF_ADD_LINE_1 AS RES_ADD_LINE_1, cd.OFF_ADD_LINE_2 AS RES_ADD_LINE_2, cd.OFF_ADD_LINE_3 AS RES_ADD_LINE_3, cd.OFF_PIN_CODE AS RES_PIN_CODE, " +
        //              "cd.OFF_PHONE AS RES_PHONE, cd.MOBILE, cd.CASE_ID, d2.DESIGNATION, d2.COMPANY_NAME, d1.OFFICE_TELEPHONE, d2.OFFICE_EXT, d1.LOCALITY, " +
        //              "d1.PORTRAIT, cd.CENTRE_ID, cd.CLIENT_ID, d2.CONTACTED_PERSON_NAME, d2.CONTACTED_PERSON_DESIGN, d2.OFFICE_SIZE, " +
        //              "d2.BUSINESS_TYPE, d2.BUSINESS_ACTIVITY_SEEN, d2.NO_OF_EMP_SIGHTED_IN_PERMISES, d2.CO_APP_NAME, d2.NO_CUSTOMER_PERDAY, " +
        //              "d2.APPLICANT_JOB_TRANSFERABLE, d2.CONSTRUCTION_OFFICE, d2.NO_CUSTOMER_SEEN, d2.DESIGNATION as [JOB_DESC], d2.EMP_JOB_TYPE as JOB_TYPE,d2.OFFICE_IS_IN as [OFFICE_TYPE], " +
        //              "d2.PARTICULARS, d1.PROOF_OF_VISIT_COLLECTED as [VISITING_CARD_OBTAINED],d1.LOCATING_ADDRESS as [EASE_OF_LOCATING_OFFICE], d2.ITEM_SEEN_IN_PERMISES, " +
        //              "d3.OFF_NAME_ON_BOARD as [BUSINESS_BOARD_SEEN_OUTSIDE_BUILDING], CONVERT(char(24), MAX(cvt.ATTEMPT_DATE_TIME), 103) AS VisitDate, " +
        //              "SUBSTRING(CONVERT(varchar(24), MAX(cvt.ATTEMPT_DATE_TIME), 100), 12, 12) AS Time_Of_calling, cvt.VERIFIER_ID, " +
        //              "EMPLOYEE_MASTER.FULLNAME AS Verifier_Name,d2.BUSINESS_PERMISES as OFFICE_OWNERSHIP, d1.BRANCH, d1.APPROXIMATE_AREA,cs.status_name as [RECOMENDATION_NO], " +
        //              "d2.NO_OF_EMP, d2.BUSINESS_NATURE, d2.AVG_MONTH_TURNOVER, d2.OFFICE_LOCALITY, d1.VERIFIED_NEIGHBOUR as [APPLICANT_NAME_VERIFIED_FROM], " +
        //              "d1.ADRESS_CONFIRMATION, d1.INTERIOR, d1.EXTERIOR,d2.TIME_AT_CURRENT_EMPLOYMENT,d2.AFFILATION_POLITICAL_PARTY_SEEN,d2.FE_REMARK, " +
        //              "d1.TPC_DETAILS,d1.ANY_OTHER_INFO_OBT,vd.DECLINED_REASON,vd.SUPERVISOR_REMARKS,d2.TIME_AT_CURRENT_EMPLOYMENT as [NoYrs], " +
        //              "d2.TYPE_OF_OFFICE,d2.APP_WORKING_AS,DCM.DESCRIPTION AS DECLINED_CODE " +
        //              "FROM  EMPLOYEE_MASTER INNER JOIN " +
        //              "CPV_CC_VERI_ATTEMPTS AS cvt ON EMPLOYEE_MASTER.EMP_ID = cvt.VERIFIER_ID RIGHT OUTER JOIN " +
        //              "CPV_CC_VERI_DETAILS AS vd INNER JOIN " +
        //              "CPV_CC_CASE_DETAILS AS cd ON vd.CASE_ID = cd.CASE_ID LEFT OUTER JOIN " +
        //              "CASE_STATUS_MASTER AS cs ON vd.CASE_STATUS_ID = cs.CASE_STATUS_ID LEFT OUTER JOIN " +
        //              "VERIFICATION_TYPE_MASTER AS vt ON vd.VERIFICATION_TYPE_ID = vt.VERIFICATION_TYPE_ID LEFT OUTER JOIN " +
        //              "CPV_CC_VERI_DESCRIPTION AS d1 ON vd.CASE_ID = d1.CASE_ID AND vd.VERIFICATION_TYPE_ID = d1.VERIFICATION_TYPE_ID LEFT OUTER JOIN " +
        //              "CPV_CC_VERI_DESCRIPTION1 AS d2 ON vd.CASE_ID = d2.CASE_ID AND vd.VERIFICATION_TYPE_ID = d2.VERIFICATION_TYPE_ID LEFT OUTER JOIN " +
        //              "CPV_CC_VERI_OTHER_DETAILS AS d3 ON vd.CASE_ID = d3.CASE_ID AND vd.VERIFICATION_TYPE_ID = d3.VERIFICATION_TYPE_ID ON  " +
        //              "cvt.CASE_ID = d3.CASE_ID AND cvt.VERIFICATION_TYPE_ID = vd.VERIFICATION_TYPE_ID " +
        //              " LEFT OUTER JOIN DECLINED_CODE_MASTER DCM ON VD.DECLINED_CODE=DCM.DECLINED_CODE " +
        //              "WHERE (cd.CASE_ID IN (" + strWhere + ")) AND (vt.VERIFICATION_TYPE_CODE = 'BV') " +
        //              "GROUP BY vd.VERIFICATION_TYPE_ID, ISNULL(cd.FIRST_NAME + ' ', '') + ISNULL(cd.MIDDLE_NAME + ' ', '') + ISNULL(cd.LAST_NAME + ' ', ''), cd.REF_NO,  " +
        //              "d3.AGENCY_NAME, cd.OFF_ADD_LINE_1, cd.OFF_ADD_LINE_2, cd.OFF_ADD_LINE_3, cd.OFF_PIN_CODE,cd.OFF_PHONE, cd.MOBILE, cd.CASE_ID,  " +
        //              "d2.DESIGNATION, d2.COMPANY_NAME, d1.OFFICE_TELEPHONE, d2.OFFICE_EXT, d1.LOCALITY, d1.PORTRAIT, cd.CENTRE_ID, cd.CLIENT_ID,  " +
        //              "d2.CONTACTED_PERSON_NAME, d2.CONTACTED_PERSON_DESIGN, d2.OFFICE_SIZE, d2.BUSINESS_TYPE, d2.BUSINESS_ACTIVITY_SEEN,  " +
        //              "d2.NO_OF_EMP_SIGHTED_IN_PERMISES, d2.CO_APP_NAME, d2.NO_CUSTOMER_PERDAY, d2.APPLICANT_JOB_TRANSFERABLE, " +
        //              "d2.CONSTRUCTION_OFFICE, d2.NO_CUSTOMER_SEEN, d2.JOB_DESC, d2.EMP_JOB_TYPE, d2.OFFICE_TYPE, d2.PARTICULARS, " +
        //              "d2.VISITING_CARD_OBTAINED, d2.EASE_OF_LOCATING_OFFICE, d2.ITEM_SEEN_IN_PERMISES," +
        //              "cvt.VERIFIER_ID, EMPLOYEE_MASTER.FULLNAME, d2.OFFICE_OWNERSHIP, d1.BRANCH, d1.APPROXIMATE_AREA, d2.RECOMENDATION_NO,  " +
        //              "d2.NO_OF_EMP, d2.BUSINESS_NATURE, d2.AVG_MONTH_TURNOVER, d2.OFFICE_LOCALITY, d2.APPLICANT_NAME_VERIFIED_FROM, " +
        //              "d1.ADRESS_CONFIRMATION, cd.DESIGNATION,d1.INTERIOR, d1.EXTERIOR, d2.TIME_AT_CURRENT_EMPLOYMENT,d3.OFF_NAME_ON_BOARD, " +
        //              "d1.LOCATING_ADDRESS,d2.AFFILATION_POLITICAL_PARTY_SEEN,d1.VERIFIED_NEIGHBOUR,d1.PROOF_OF_VISIT_COLLECTED,d2.DESIGNATION,"+
        //              "d2.OFFICE_IS_IN,cs.status_name,d2.FE_REMARK,d1.TPC_DETAILS,d1.ANY_OTHER_INFO_OBT,"+
        //              "vd.DECLINED_REASON,vd.SUPERVISOR_REMARKS,d2.BUSINESS_PERMISES,d2.TYPE_OF_OFFICE ,d2.APP_WORKING_AS,DCM.DESCRIPTION  ";

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetBusinessVerificationDtl_Qc", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    public DataTable GetBusinessVerificationDtlKyc(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;
     
        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetBusinessVerificationDtlKyc", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetBusinessVerificationDtlKyc_Curr(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetBusinessVerificationDtlKyc_Curr", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetBusinessVerificationDtlKycTCM(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetBusinessVerificationDtlTCM", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetHrPaySlip(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@EmpId", OleDbType.VarChar, 100);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_HrSalaryView13_new_April2022", buisi); // Get_HrSalaryView13_new_April2019
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetBusinessVerificationDtlKycTCM_Qc(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetBusinessVerificationDtlTCM_Qc", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    public DataTable GetBusiVeriDtlRL(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetBusinessVerificationDtlRL", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetBusiVeriDtlRL_Qc(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetBusinessVerificationDtlRL_Qc", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    public DataTable GetBusiVeriDtlKycScbAcOp(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetbussVeriDtlKycScb", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    public DataTable GetCaVeriDtlKycScbAcOp(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetCaVeriDtlKycScb", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    public DataTable GetBusiVeriDtlRLubi(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetBusiVeriDtlRLubi", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetBusiVeriDtlCCubi(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetBusiVeriDtlCCubi", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetBusiVeriDtlRLgicHL(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetBusiVeriDtlRLgicHL", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    //--Added by Kamal Matekar..For HDFC_HL_RL....
    public DataTable GetBusiVeriDtl_Hdfc_HL_RL(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetBusinessVerificationHdfc_HL_RL", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetPropertyDtlKarvyFinancial(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetPropertyDtl_KarvyFinancial", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetResiVeriDtlKarvyFinancial(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetResiVeriDtl_KarvyFinancial", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetBusiVeriDtlRLgicHL_SS(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetBusiVeriDtlRLgicHL_SS", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetItrDtlRLgicHL(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetItrDtlRLgicHL", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetITRVerificationDetails(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] ITR = new OleDbParameter[2];
        ITR[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        ITR[0].Value = strWhere;

        ITR[1] = new OleDbParameter("@Verification_type_id", OleDbType.VarChar, 15);
        ITR[1].Value = "34";

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "GetData_ForITRVerificationReport", ITR);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetBusiVeriDtlRLubi_Qc(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetBusiVeriDtlRLubi_Qc", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    //New Addition : 27/06/2008
    public DataTable GetBusinessVerificationDtlRL(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        //OleDbParameter[] buisi = new OleDbParameter[1];
        //buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        //buisi[0].Value = strWhere;
        strSQL = "Select Cd.Case_Id,ISNULL(Cd.FIRST_NAME + ' ', '') + ISNULL(Cd.MIDDLE_NAME + ' ', '') + ISNULL(Cd.LAST_NAME + ' ', '') AS Applicant_Name, " +
                    " Convert(varchar(10),Cd.Case_Rec_Datetime,103) As recd_Dt,'' As DSA, " +
                    " ISNULL(Cd.Off_Add_Line_1 + ' ', '') + ISNULL(Cd.Off_Add_Line_2 + ' ', '') + ISNULL(Cd.Off_Add_Line_3 + ' ', '')+ ISNULL(Cd.Off_City + ' ', '')+ ISNULL(Cd.Off_Pin_Code + ' ', '') AS Off_Add, " +
                    " Cd.Off_Phone As Off_Tel,Cd.Mobile,Cd.Off_Extn, " +
                    " '' As Loan_Type,'' As Loan_Amt,'' As Loan_Tenure,'' As Loan_Month, " +
                    " Vd.Type_Office As Off_Type,Vd.Type_Organization As Type_Of_Business, " +
                    " Nam_Plate_Sighted As Board_Seen,Vd.Locality As Location,Vd.Ownership,Vd.Nature_Business As Nature_Of_Business, " +
                    " Vd.No_Year_Service As No_Of_Years,Vd.Aprox_Area As Area_SqFt,'' As Approx_Value,Vd.Total_No_Employee As No_Of_Emp,Vd.No_Of_Emp_Seen As No_Of_Emp_Seen, " +
                    " Vd.Assets_Seen As Assets,'' As Observation,Vd.Furniture_Seen As Off_Structure,''As Employee, " +
                    " Vd.Equipment_Stock_Sighted As Equiment,Stock_Seen As Stock, Vd.Person_Contacted,Vd.Designation_Contacted_Person As Relationship, " +
                    " '' As Vechile_Used,'' As Vechile_Finan,Vd.Business_Activity_Seen As Business_Activity, Vd.Exterior_Conditions As Exterior,Vd.Interior_Conditions As Interior, " +
                    " '' As TPC,'' As TPC_Name,'' As TPC_Relation,'' As Fact_Nature,'' As Fact_Non_Nature,'' As Any_Varition, " +
                    " '' As Reject,Vd.Verifier_Comment As Remark, Cs.Status_Code As Status From " +
                    " Cpv_Rl_Case_Details Cd Inner Join Cpv_Rl_Verification_BvBt Vd On Cd.Case_id=Vd.Case_id Left Outer Join CASE_STATUS_MASTER Cs On Vd.Overall_Verification=Cs.Case_Status_Id where CD.CASE_ID = '"+ strWhere +"' AND VD.VERIFICATION_TYPE_ID = '2'";
        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text,strSQL);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    // End 
    public DataTable GetResidenceVerificationDtl(string strWhere)
    {
        
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;
        //strSQL = "SELECT TOP 100 PERCENT vd.VERIFICATION_TYPE_ID, ISNULL(cd.FIRST_NAME + ' ', '') + ISNULL(cd.MIDDLE_NAME + ' ', '') + ISNULL(cd.LAST_NAME + ' ', '') " +
        //              "AS APPLICANT_NAME, cd.REF_NO, d3.AGENCY_NAME, cd.RES_ADD_LINE_1, cd.RES_ADD_LINE_2, cd.RES_ADD_LINE_3, cd.RES_PIN_CODE, " +
        //              "d2.LAND_MARK_OBSERVED as [RES_LAND_MARK], cd.RES_PHONE, cd.MOBILE, d2.PINCODE, cd.CASE_ID, cd.DOB, d1.MARITAL_STATUS, d1.NO_OF_DEPENDENT, " +
        //              "d2.DESIGNATION,d1.QUALIFICATION,d1.APPLICANT_AVAILABILITY, d1.IS_SPOUSE_WORKING, d1.VERIFIED_NEIGHBOUR, d1.LOCALITY, d1.ASSETS_VISIBLE, " +
        //              "d1.PORTRAIT, d3.IS_OCL, cd.CENTRE_ID, cd.CLIENT_ID, ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') " +
        //              "+ ISNULL(cd.OFF_ADD_LINE_3 + ' ', '') AS OFF_ADD_LINE, d2.CONTACTED_PERSON_NAME, d2.CONTACTED_PERSON_DESIGN, " +
        //              "d3.PERSON_CONTACTED, d3.REL_WITH_APPLICANT, d2.DOB_APPLICANT, d2.APPLICANT_IS_AVAILABLE_AT, d1.APPLICANT_AGE, d2.SPK_TO, " +
        //              "d2.APPLICANT_NAME_VERIFIED_FROM, d2.APP_QUALIFICATION, d2.NAME_OF_PERSON_CONTACTED, d1.PERSON_CONTACTED_MET, " +
        //              "d1.CUSTOMER_COOPERATION, d1.COMMENTS_EXTERIORS as [EXTERIOR], d1.FAMILY_MEMBERS, d1.NO_OF_EARNING_FAMILY_MEMBER, d1.INTERIOR, " +
        //              "d1.APP_DOB_APPROX_AGE,cs.Status_name as [RECOMMENDATION], CONVERT(char(24), MAX(cvt.ATTEMPT_DATE_TIME), 103) AS VisitDate, " +
        //              "SUBSTRING(CONVERT(varchar(24), MAX(cvt.ATTEMPT_DATE_TIME), 100), 12, 12) AS Time_Of_calling, cvt.VERIFIER_ID, " +
        //              "EMPLOYEE_MASTER.FULLNAME AS Verifier_Name, d2.SPECIAL_INSTRUCTIONS, d1.IS_CREDIT_CARD, d1.CARD_TYPE, d1.CARD_NO, " +
        //              "d1.CARD_LIMIT, d1.CARD_EXPIRY, d1.ISSUING_BANK, d2.RECOMENDATION_NO, d2.NEIGHBOUR_REFERENCE, " +
        //              "d2.CURRENT_RESIDENCE_PERIOD, cd.SPL_INSTRUCTION, d2.RELATION_PERSON_CONTACTED, d1.TIME_AT_CURR_RESIDANCE, " +
        //              "d1.APPROXIMATE_AREA, d1.LOCATING_ADDRESS, d1.CONSTRUCTION_OF_RESIDANCE, d1.APPLICANT_STAYED_RESIDANCE,d1.ADRESS_CONFIRMATION," +
        //              "d3.RES_TYPE as [RESI_TYPE],d2.RESIDANCE_IS as [RESIDANCE_STATUS],d1.TPC_DETAILS,d1.ANY_OTHER_INFO_OBT,d2.FE_REMARK,"+
        //              "vd.DECLINED_REASON,vd.SUPERVISOR_REMARKS,d1.WORKING,d1.CHILDREN,DCM.DESCRIPTION AS DECLINED_CODE " +
        //              "FROM EMPLOYEE_MASTER INNER JOIN " +
        //              "CPV_CC_VERI_ATTEMPTS AS cvt ON EMPLOYEE_MASTER.EMP_ID = cvt.VERIFIER_ID RIGHT OUTER JOIN " +
        //              "CPV_CC_VERI_DETAILS AS vd INNER JOIN " +
        //              "CPV_CC_CASE_DETAILS AS cd ON vd.CASE_ID = cd.CASE_ID LEFT OUTER JOIN " +
        //              "CASE_STATUS_MASTER AS cs ON vd.CASE_STATUS_ID = cs.CASE_STATUS_ID LEFT OUTER JOIN " +
        //              "VERIFICATION_TYPE_MASTER AS vt ON vd.VERIFICATION_TYPE_ID = vt.VERIFICATION_TYPE_ID LEFT OUTER JOIN " +
        //              "CPV_CC_VERI_DESCRIPTION AS d1 ON vd.CASE_ID = d1.CASE_ID AND vd.VERIFICATION_TYPE_ID = d1.VERIFICATION_TYPE_ID LEFT OUTER JOIN " +
        //              "CPV_CC_VERI_DESCRIPTION1 AS d2 ON vd.CASE_ID = d2.CASE_ID AND vd.VERIFICATION_TYPE_ID = d2.VERIFICATION_TYPE_ID LEFT OUTER JOIN " +
        //              "CPV_CC_VERI_OTHER_DETAILS AS d3 ON vd.CASE_ID = d3.CASE_ID AND vd.VERIFICATION_TYPE_ID = d3.VERIFICATION_TYPE_ID ON  " +
        //              "cvt.CASE_ID = d3.CASE_ID AND cvt.VERIFICATION_TYPE_ID = vd.VERIFICATION_TYPE_ID " +
        //              " LEFT OUTER JOIN DECLINED_CODE_MASTER DCM ON VD.DECLINED_CODE=DCM.DECLINED_CODE " +
        //              "WHERE (cd.CASE_ID IN (" + strWhere + ")) AND (vt.VERIFICATION_TYPE_CODE = 'RV') " +
        //              "GROUP BY vd.VERIFICATION_TYPE_ID, ISNULL(cd.FIRST_NAME + ' ', '') + ISNULL(cd.MIDDLE_NAME + ' ', '') + ISNULL(cd.LAST_NAME + ' ', ''), cd.REF_NO,  " +
        //              "d3.AGENCY_NAME, cd.RES_ADD_LINE_1, cd.RES_ADD_LINE_2, cd.RES_ADD_LINE_3, cd.RES_PIN_CODE, cd.RES_LAND_MARK, cd.RES_PHONE,  " +
        //              "cd.MOBILE, d2.PINCODE, cd.CASE_ID, cd.DOB, d1.MARITAL_STATUS, d1.NO_OF_DEPENDENT, d2.DESIGNATION,d1.QUALIFICATION, d1.APPLICANT_AVAILABILITY, " +
        //              "d1.IS_SPOUSE_WORKING, d1.VERIFIED_NEIGHBOUR, d1.LOCALITY, d1.ASSETS_VISIBLE, d1.PORTRAIT, d3.IS_OCL, cd.CENTRE_ID, cd.CLIENT_ID, " +
        //              "ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', ''), d2.CONTACTED_PERSON_NAME, " +
        //              "d2.CONTACTED_PERSON_DESIGN, d3.PERSON_CONTACTED, d3.REL_WITH_APPLICANT, d2.DOB_APPLICANT, d2.APPLICANT_IS_AVAILABLE_AT, " +
        //              "d1.APPLICANT_AGE, d2.SPK_TO, d2.APPLICANT_NAME_VERIFIED_FROM, d2.APP_QUALIFICATION, d2.NAME_OF_PERSON_CONTACTED, " +
        //              "d1.PERSON_CONTACTED_MET, d1.CUSTOMER_COOPERATION, d1.COMMENTS_EXTERIORS, d1.FAMILY_MEMBERS, " +
        //              "d1.NO_OF_EARNING_FAMILY_MEMBER, d1.INTERIOR, d1.EXTERIOR, d1.APP_DOB_APPROX_AGE, d1.RECOMMENDATION, cvt.VERIFIER_ID, " +
        //              "EMPLOYEE_MASTER.FULLNAME, d2.SPECIAL_INSTRUCTIONS, d1.IS_CREDIT_CARD, d1.CARD_TYPE, d1.CARD_NO, d1.CARD_LIMIT, " +
        //              "d1.CARD_EXPIRY, d1.ISSUING_BANK, d2.RECOMENDATION_NO, d2.NEIGHBOUR_REFERENCE, " +
        //              "d2.CURRENT_RESIDENCE_PERIOD, cd.SPL_INSTRUCTION, d2.RELATION_PERSON_CONTACTED, d1.TIME_AT_CURR_RESIDANCE, " +
        //              "d1.APPROXIMATE_AREA, d1.LOCATING_ADDRESS, d1.CONSTRUCTION_OF_RESIDANCE, d1.APPLICANT_STAYED_RESIDANCE,d1.ADRESS_CONFIRMATION," +
        //              "d3.RES_TYPE,cs.Status_name,d2.RESIDANCE_IS, " +
        //              "d1.TPC_DETAILS,d1.ANY_OTHER_INFO_OBT,d2.FE_REMARK,vd.SUPERVISOR_REMARKS,vd.DECLINED_REASON,"+
        //              "d2.LAND_MARK_OBSERVED,d1.WORKING,d1.CHILDREN,DCM.DESCRIPTION ";

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetResidenceVerificationDtl", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetResidenceVerificationDtl_Ebc(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;
        
        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetResidenceVerificationDtl_Ebc", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    //addedd by RZ
    public DataTable Get_SCB_RV_details(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetResidenceVerificationDtl_Ebc", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetResidenceVerificationDtl_DLB(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;
        
        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetResidenceVerificationDtl_DLB", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetResidenceVerificationDtl_Qc(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;
        //strSQL = "SELECT TOP 100 PERCENT vd.VERIFICATION_TYPE_ID, ISNULL(cd.FIRST_NAME + ' ', '') + ISNULL(cd.MIDDLE_NAME + ' ', '') + ISNULL(cd.LAST_NAME + ' ', '') " +
        //              "AS APPLICANT_NAME, cd.REF_NO, d3.AGENCY_NAME, cd.RES_ADD_LINE_1, cd.RES_ADD_LINE_2, cd.RES_ADD_LINE_3, cd.RES_PIN_CODE, " +
        //              "d2.LAND_MARK_OBSERVED as [RES_LAND_MARK], cd.RES_PHONE, cd.MOBILE, d2.PINCODE, cd.CASE_ID, cd.DOB, d1.MARITAL_STATUS, d1.NO_OF_DEPENDENT, " +
        //              "d2.DESIGNATION,d1.QUALIFICATION,d1.APPLICANT_AVAILABILITY, d1.IS_SPOUSE_WORKING, d1.VERIFIED_NEIGHBOUR, d1.LOCALITY, d1.ASSETS_VISIBLE, " +
        //              "d1.PORTRAIT, d3.IS_OCL, cd.CENTRE_ID, cd.CLIENT_ID, ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') " +
        //              "+ ISNULL(cd.OFF_ADD_LINE_3 + ' ', '') AS OFF_ADD_LINE, d2.CONTACTED_PERSON_NAME, d2.CONTACTED_PERSON_DESIGN, " +
        //              "d3.PERSON_CONTACTED, d3.REL_WITH_APPLICANT, d2.DOB_APPLICANT, d2.APPLICANT_IS_AVAILABLE_AT, d1.APPLICANT_AGE, d2.SPK_TO, " +
        //              "d2.APPLICANT_NAME_VERIFIED_FROM, d2.APP_QUALIFICATION, d2.NAME_OF_PERSON_CONTACTED, d1.PERSON_CONTACTED_MET, " +
        //              "d1.CUSTOMER_COOPERATION, d1.COMMENTS_EXTERIORS as [EXTERIOR], d1.FAMILY_MEMBERS, d1.NO_OF_EARNING_FAMILY_MEMBER, d1.INTERIOR, " +
        //              "d1.APP_DOB_APPROX_AGE,cs.Status_name as [RECOMMENDATION], CONVERT(char(24), MAX(cvt.ATTEMPT_DATE_TIME), 103) AS VisitDate, " +
        //              "SUBSTRING(CONVERT(varchar(24), MAX(cvt.ATTEMPT_DATE_TIME), 100), 12, 12) AS Time_Of_calling, cvt.VERIFIER_ID, " +
        //              "EMPLOYEE_MASTER.FULLNAME AS Verifier_Name, d2.SPECIAL_INSTRUCTIONS, d1.IS_CREDIT_CARD, d1.CARD_TYPE, d1.CARD_NO, " +
        //              "d1.CARD_LIMIT, d1.CARD_EXPIRY, d1.ISSUING_BANK, d2.RECOMENDATION_NO, d2.NEIGHBOUR_REFERENCE, " +
        //              "d2.CURRENT_RESIDENCE_PERIOD, cd.SPL_INSTRUCTION, d2.RELATION_PERSON_CONTACTED, d1.TIME_AT_CURR_RESIDANCE, " +
        //              "d1.APPROXIMATE_AREA, d1.LOCATING_ADDRESS, d1.CONSTRUCTION_OF_RESIDANCE, d1.APPLICANT_STAYED_RESIDANCE,d1.ADRESS_CONFIRMATION," +
        //              "d3.RES_TYPE as [RESI_TYPE],d2.RESIDANCE_IS as [RESIDANCE_STATUS],d1.TPC_DETAILS,d1.ANY_OTHER_INFO_OBT,d2.FE_REMARK,"+
        //              "vd.DECLINED_REASON,vd.SUPERVISOR_REMARKS,d1.WORKING,d1.CHILDREN,DCM.DESCRIPTION AS DECLINED_CODE " +
        //              "FROM EMPLOYEE_MASTER INNER JOIN " +
        //              "CPV_CC_VERI_ATTEMPTS AS cvt ON EMPLOYEE_MASTER.EMP_ID = cvt.VERIFIER_ID RIGHT OUTER JOIN " +
        //              "CPV_CC_VERI_DETAILS AS vd INNER JOIN " +
        //              "CPV_CC_CASE_DETAILS AS cd ON vd.CASE_ID = cd.CASE_ID LEFT OUTER JOIN " +
        //              "CASE_STATUS_MASTER AS cs ON vd.CASE_STATUS_ID = cs.CASE_STATUS_ID LEFT OUTER JOIN " +
        //              "VERIFICATION_TYPE_MASTER AS vt ON vd.VERIFICATION_TYPE_ID = vt.VERIFICATION_TYPE_ID LEFT OUTER JOIN " +
        //              "CPV_CC_VERI_DESCRIPTION AS d1 ON vd.CASE_ID = d1.CASE_ID AND vd.VERIFICATION_TYPE_ID = d1.VERIFICATION_TYPE_ID LEFT OUTER JOIN " +
        //              "CPV_CC_VERI_DESCRIPTION1 AS d2 ON vd.CASE_ID = d2.CASE_ID AND vd.VERIFICATION_TYPE_ID = d2.VERIFICATION_TYPE_ID LEFT OUTER JOIN " +
        //              "CPV_CC_VERI_OTHER_DETAILS AS d3 ON vd.CASE_ID = d3.CASE_ID AND vd.VERIFICATION_TYPE_ID = d3.VERIFICATION_TYPE_ID ON  " +
        //              "cvt.CASE_ID = d3.CASE_ID AND cvt.VERIFICATION_TYPE_ID = vd.VERIFICATION_TYPE_ID " +
        //              " LEFT OUTER JOIN DECLINED_CODE_MASTER DCM ON VD.DECLINED_CODE=DCM.DECLINED_CODE " +
        //              "WHERE (cd.CASE_ID IN (" + strWhere + ")) AND (vt.VERIFICATION_TYPE_CODE = 'RV') " +
        //              "GROUP BY vd.VERIFICATION_TYPE_ID, ISNULL(cd.FIRST_NAME + ' ', '') + ISNULL(cd.MIDDLE_NAME + ' ', '') + ISNULL(cd.LAST_NAME + ' ', ''), cd.REF_NO,  " +
        //              "d3.AGENCY_NAME, cd.RES_ADD_LINE_1, cd.RES_ADD_LINE_2, cd.RES_ADD_LINE_3, cd.RES_PIN_CODE, cd.RES_LAND_MARK, cd.RES_PHONE,  " +
        //              "cd.MOBILE, d2.PINCODE, cd.CASE_ID, cd.DOB, d1.MARITAL_STATUS, d1.NO_OF_DEPENDENT, d2.DESIGNATION,d1.QUALIFICATION, d1.APPLICANT_AVAILABILITY, " +
        //              "d1.IS_SPOUSE_WORKING, d1.VERIFIED_NEIGHBOUR, d1.LOCALITY, d1.ASSETS_VISIBLE, d1.PORTRAIT, d3.IS_OCL, cd.CENTRE_ID, cd.CLIENT_ID, " +
        //              "ISNULL(cd.OFF_ADD_LINE_1 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_2 + ' ', '') + ISNULL(cd.OFF_ADD_LINE_3 + ' ', ''), d2.CONTACTED_PERSON_NAME, " +
        //              "d2.CONTACTED_PERSON_DESIGN, d3.PERSON_CONTACTED, d3.REL_WITH_APPLICANT, d2.DOB_APPLICANT, d2.APPLICANT_IS_AVAILABLE_AT, " +
        //              "d1.APPLICANT_AGE, d2.SPK_TO, d2.APPLICANT_NAME_VERIFIED_FROM, d2.APP_QUALIFICATION, d2.NAME_OF_PERSON_CONTACTED, " +
        //              "d1.PERSON_CONTACTED_MET, d1.CUSTOMER_COOPERATION, d1.COMMENTS_EXTERIORS, d1.FAMILY_MEMBERS, " +
        //              "d1.NO_OF_EARNING_FAMILY_MEMBER, d1.INTERIOR, d1.EXTERIOR, d1.APP_DOB_APPROX_AGE, d1.RECOMMENDATION, cvt.VERIFIER_ID, " +
        //              "EMPLOYEE_MASTER.FULLNAME, d2.SPECIAL_INSTRUCTIONS, d1.IS_CREDIT_CARD, d1.CARD_TYPE, d1.CARD_NO, d1.CARD_LIMIT, " +
        //              "d1.CARD_EXPIRY, d1.ISSUING_BANK, d2.RECOMENDATION_NO, d2.NEIGHBOUR_REFERENCE, " +
        //              "d2.CURRENT_RESIDENCE_PERIOD, cd.SPL_INSTRUCTION, d2.RELATION_PERSON_CONTACTED, d1.TIME_AT_CURR_RESIDANCE, " +
        //              "d1.APPROXIMATE_AREA, d1.LOCATING_ADDRESS, d1.CONSTRUCTION_OF_RESIDANCE, d1.APPLICANT_STAYED_RESIDANCE,d1.ADRESS_CONFIRMATION," +
        //              "d3.RES_TYPE,cs.Status_name,d2.RESIDANCE_IS, " +
        //              "d1.TPC_DETAILS,d1.ANY_OTHER_INFO_OBT,d2.FE_REMARK,vd.SUPERVISOR_REMARKS,vd.DECLINED_REASON,"+
        //              "d2.LAND_MARK_OBSERVED,d1.WORKING,d1.CHILDREN,DCM.DESCRIPTION ";

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetResidenceVerificationDtl", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetResidenceVerificationDtlKyc(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;
     
        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetResidenceVerificationDtlKyc", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetResidenceVerificationDtlKyc_Curr(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetResidenceVerificationDtlKyc_Curr", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetResiVeriDtlRL(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetResidenceVerificationDtlRL", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetResiVeriDtlRL_Qc(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetResidenceVerificationDtlRL_Qc", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    public DataTable GetResiVeriDtlKycScbAcOp(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetResiVeriDtlKycScb", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetResiVeriDtlRLgicHL(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetResiVeriDtlRLgicHL", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetResiVeriDtl_DeutscheMorLoan(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_DeutscheBankMorLoanRV", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    //--Added by kamal matekar.....for HDFC_HL_RL.....
    public DataTable GetResiVeriDtl_Volks(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_ExportVolksRV", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetDhanLaxmi_RTBT_VerifyDetails(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] RTBT = new OleDbParameter[1];
        RTBT[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        RTBT[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetRT_BT_DhanLaxmi_RL", RTBT);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetBussVeriDtl_DeutscheMorLoan(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_DeutscheBankMorLoanBV", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    //--Added by MAnoj
    public DataTable GetBussVeriDtl_Indiabulls(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "GetBusIndiabulls", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    public DataTable GetResiVeriDtl_Indiabulls(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "GetResindiabulls", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    //--Ended by Manoj
    public DataTable GetBussVeriDtlSal_Volks(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_ExportVolksBvSal", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetTeleVeriDtl_DeutscheMorLoan(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_DeutscheBankMorLoanTV", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }


    public DataTable GetBussVeriDtlSelf_Volks(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_ExportVolksBvSelf", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetResiVeriDtl_HDFC_HL_RL(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetResiVeriDetails_Hdfc_HL_RL", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    
    public DataTable GetResiVeriDtlRLubi(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetResiVeriDtlRLubi", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetResiVeriDtlCCubi(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetResiVeriDtlCCubi", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetResiVeriDtlRLubi_Qc(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetResiVeriDtlRLubi_Qc", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    public DataTable GetResiTeleDtlRLubi(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetResiTeleDtlRLubi", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetResiTeleDtlCCubi(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetResiTeleDtlCCubi", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetTeleDtlRLgicHL(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetTeleDtlRLgicHL", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    public DataTable GetResiTeleDtlRLubi_Qc(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetResiTeleDtlRLubi", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    // New Addition : 27/06/2008
    public DataTable GetResidenceVerificationDtlRL(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        //OleDbParameter[] buisi = new OleDbParameter[1];
        //buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        //buisi[0].Value = strWhere;
        strSQL = "Select Cd.Case_Id,ISNULL(Cd.FIRST_NAME + ' ', '') + ISNULL(Cd.MIDDLE_NAME + ' ', '') + ISNULL(Cd.LAST_NAME + ' ', '') AS Applicant_Name, " +
                  " Convert(varchar(10),Cd.Case_Rec_Datetime,103) As recd_Dt,'' As DSA, " +
                  " ISNULL(Cd.Res_Add_Line_1 + ' ', '') + ISNULL(Cd.Res_Add_Line_2 + ' ', '') + ISNULL(Cd.Res_Add_Line_3 + ' ', '')+ ISNULL(Cd.Res_City + ' ', '')+ ISNULL(Cd.Res_Pin_Code + ' ', '') AS Resi_Add, " +
                  " Cd.Res_Phone As Resi_Tel,Cd.Off_Phone As Off_Tel,Cd.Off_Extn, " +
                  " '' As Loan_Type,'' As Loan_Amt,'' As Loan_Tenure,'' As Loan_Month, " +
                  " Vd.Type_Accmodation As Resi_Type,Vd.Name_Society_Board As Society_Board,Vd.Nameplate_On_Door As Name_Plate, " +
                  " Vd.Ownership_Residence As Resi_Owner,Vd.Permanent_Address As Pmt_Add,Vd.Years_At_Residence As No_Of_Yrs,Vd.Number_Rooms As No_Of_Rooms, " +
                  " Vd.Area_of_House As Area_SqFt,Vd.Approximate_Value As Approx_Value,Vd.Bachelor_Accomodation As Bachelor_Accom, " +
                  " Vd.Locality,Vd.Assets,Vd.Marital_Status As Marital,Vd.No_Of_Dependent As No_Of_Dependent, " +
                  " Vd.Person_Contacted,Vd.Relationship,Vd.Vehicles_Used As Vechicle_Used,Vd.Vehicles_Financed As Vechicle_Finan, " +
                  " Vd.Detail_Furniture_Seen As Other_Assets,Vd.Exterior_Premises As Exterior,Vd.Interior_Premises As Interior, " +
                  " Vd.Confirm_Neighbour1 As TPC,Vd.Name_Neighbour1 As TPC_Name,Vd.Add_Neighbour1 As TPC_Where, " +
                  " '' As Any_Veri,'' As Reject,Vd.Verifier_Comments As Remark, Cs.Status_Code As Status " +
                  " From Cpv_Rl_Case_Details Cd Inner Join Cpv_Rl_Verification_RvRt Vd On Cd.Case_id=Vd.Case_id " +
                  " Left Outer Join CASE_STATUS_MASTER Cs On Vd.Verification_Status=Cs.Case_Status_Id where CD.CASE_ID = '"+ strWhere +"' AND VD.VERIFICATION_TYPE_ID = '1'";
        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text,strSQL);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    // End
    public DataTable GetResidenceTeleDtl(string strWhere)
    {
        
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;
        

        //strSQL = " select TOP 100 PERCENT REF_NO,o.CASE_ID, CENTRE_ID, CLIENT_ID,RES_ADD_LINE as [RES_ADD_LINE_1], " +
        //         " Expr1 as [PMT_ADD_LINE_1], RES_PHONE, APPLICANT_NAME, SPECIAL_INSTRUCTIONS,PERSON_CONTACTED," +
        //         " REL_WITH_APPLICANT,APPLICANT_NAME_CONFIRMED_AT_GIVEN_NO," +
        //         " CONVERT(char(24), ATTEMPT_DATE_TIME, 103) AS VisitDate, "+
        //         " SUBSTRING(CONVERT(varchar(24), ATTEMPT_DATE_TIME, 100), 12, 12) AS Time_Of_calling, " +
        //         " RESIDANCE_IS,Remark,SPK_TO,Any_Info as TCRemark,VERIFIER_ID, FULLNAME AS Verifier_Name,  " +
        //         " status_name as [TELE_VERIFICATION_RESULT],TIME_AT_CURRENT_EMPL_Y_M,DECLINED_REASON,SUPERVISOR_REMARKS " +
        //         " from CPV_CC_CASE_OUTPUT_VW o left join CPV_CC_VERI_ATTEMPTS a on o.case_id=a.case_id " +
        //         " and o.verification_type_id=a.verification_type_id  " +
        //          " where o.case_id IN ('" + strWhere + "') and o.verification_type_id=4 ";

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetResidenceTeleDtl", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetResidenceTeleDtl_DLB(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetResidenceTeleDtl_DLB", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetItrSs_CC(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetItrDtlCC", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }


    public DataTable GetResidenceTeleDtl_Qc(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;


        //strSQL = " select TOP 100 PERCENT REF_NO,o.CASE_ID, CENTRE_ID, CLIENT_ID,RES_ADD_LINE as [RES_ADD_LINE_1], " +
        //         " Expr1 as [PMT_ADD_LINE_1], RES_PHONE, APPLICANT_NAME, SPECIAL_INSTRUCTIONS,PERSON_CONTACTED," +
        //         " REL_WITH_APPLICANT,APPLICANT_NAME_CONFIRMED_AT_GIVEN_NO," +
        //         " CONVERT(char(24), ATTEMPT_DATE_TIME, 103) AS VisitDate, "+
        //         " SUBSTRING(CONVERT(varchar(24), ATTEMPT_DATE_TIME, 100), 12, 12) AS Time_Of_calling, " +
        //         " RESIDANCE_IS,Remark,SPK_TO,Any_Info as TCRemark,VERIFIER_ID, FULLNAME AS Verifier_Name,  " +
        //         " status_name as [TELE_VERIFICATION_RESULT],TIME_AT_CURRENT_EMPL_Y_M,DECLINED_REASON,SUPERVISOR_REMARKS " +
        //         " from CPV_CC_CASE_OUTPUT_VW o left join CPV_CC_VERI_ATTEMPTS a on o.case_id=a.case_id " +
        //         " and o.verification_type_id=a.verification_type_id  " +
        //          " where o.case_id IN ('" + strWhere + "') and o.verification_type_id=4 ";

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetResidenceTeleDtl_Qc", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    // NEW ADDITION : 27/06/2008
    public DataTable GetResidenceTeleDtlRL(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        //OleDbParameter[] buisi = new OleDbParameter[1];
        //buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        //buisi[0].Value = strWhere;
        strSQL = "Select CD.Case_id, ISNULL(Cd.FIRST_NAME + ' ', '') + ISNULL(Cd.MIDDLE_NAME + ' ', '') + ISNULL(Cd.LAST_NAME + ' ', '') AS Applicant_Name, " +
                 " Convert(varchar(10),Cd.Case_Rec_Datetime,103) As recd_Dt,Cd.Res_Phone as Tele_Phone,Cd.Mobile,Cd.Department, " +
                 " Vd.Ownership_Residence As Ownership,Vd.Staying_Since As Number_Of_Yrs,Vd.PP_Number As PP_No,Vd.Staying_Whom As Staying_With, " +
                 " Vd.Any_Other_Resi_Phone As Alt_Resi_Number,Vd.Person_Contacted As Person_Contacted,Vd.Relationship as relationship, " +
                 " Vd.Applicant_Availbility As Applicant_Availbility,Vd.Verifier_Comments as remark,Vd.Dir_Check As DirCheck,Vd.Name_of_Applicant_Conf As Name_ConFirm, " +
                 " Convert(varchar(10),Tl.Attempt_Datetime,103) As Date_Call,Left(Convert(varchar(10),Tl.Attempt_Datetime,114),5) As Date_Time, " +
                 " Tl.Attempt_Remark As Tele_Status, Cs.Status_Code As Status " +
                 " From Cpv_Rl_Case_Details Cd Inner Join Cpv_Rl_Verification_RvRt Vd On Cd.Case_id=Vd.Case_id " +
                 " Inner Join CPV_RL_VERIFICATION_ATTEMPT Tl On Cd.Case_id=Tl.Case_id Inner Join CASE_STATUS_MASTER Cs On Vd.Verification_Status=Cs.Case_Status_Id " +
                 " Where CD.CASE_ID = '"+ strWhere +"' And Tl.Verification_Type_Id='4'";        
        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, strSQL);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    // END
    public DataSet GetDateTimeCalling(string strWhere)
    {
        
        DataSet ds = new DataSet();
        string strSQL = "";
        strSQL = "SELECT CASE_ID, VERIFICATION_TYPE_ID, CONVERT(char(24), ATTEMPT_DATE_TIME, 103) AS Date_Of_Calling, SUBSTRING(CONVERT(varchar(24), " +
                "ATTEMPT_DATE_TIME, 100), 12, 12) AS Time_Of_calling " +
                "FROM CPV_CC_VERI_ATTEMPTS " +
                "WHERE (CPV_CC_VERI_ATTEMPTS.CASE_ID in(" + strWhere + "))AND (VERIFICATION_TYPE_ID = 4) ";
        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, strSQL);
        return ds;
    }

    public DataTable GetOfficeTeleDtl(string strWhere)
    {
        
        DataSet ds = new DataSet();
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        //string strSQL = "select TOP 100 PERCENT REF_NO,o.CASE_ID, CENTRE_ID, CLIENT_ID,OFF_PHONE,OFFICE_EXT as [OFF_EXTN]," +
        //               " APPLICANT_NAME, TIME_AT_CURRENT_EMPL_Y_M,InputDesignation as DESIGNATION, DEPARTMENT, " +
        //               " FOR_SELF_EMPLOYED_TYPE_OF_ORGANIZATION,COMPANY_NAME as COMPANYNAME, " +
        //               " ISNULL(OFF_ADD_LINE_1, ' ') + ' ' + ISNULL(OFF_ADD_LINE_2, ' ') + ' '+ ISNULL(OFF_ADD_LINE_3,' ') + ' ' + ISNULL(OFF_PIN_CODE, ' ') " +
        //               " as OFF_ADD_LINE_1,LAND_MARK_OBSERVED as LANDMARK,SPECIAL_INSTRUCTIONS, " +
        //               " PERSON_CONTACTED,OTHER_CONTACTED_DESIGNATION as First_Name,REL_WITH_APPLICANT, " +
        //               " APPLICANT_NAME_CONFIRMED_AT_GIVEN_NO, SPK_TO," +
        //               " CONVERT(char(24), ATTEMPT_DATE_TIME, 103) AS VisitDate, " +
        //               " SUBSTRING(CONVERT(varchar(24), ATTEMPT_DATE_TIME, 100), 12, 12) AS Time_Of_calling," +
        //               " Remark AS REMARKS, Any_Info as TCRemark,VERIFIER_ID, FULLNAME AS Verifier_Name, " +
        //               " status_name as [TELE_VERIFICATION_RESULT],TIME_AT_CURRENT_EMPL_Y_M,OTHER_NATURE_OF_BUSINESS," +
        //               " ADDITIONAL_REMARK,OVERALL_ASSESMENT_REASON as DECLINED_REASON,SUPERVISOR_REMARKS " +
        //               " from CPV_CC_CASE_OUTPUT_VW o left join CPV_CC_VERI_ATTEMPTS a on o.case_id=a.case_id " +
        //               " and o.verification_type_id=a.verification_type_id " +
        //               " where o.case_id IN ('" + strWhere + "') and o.verification_type_id=3 ";

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetOfficeTeleDtl", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetOfficeTeleDtl_DLB(string strWhere)
    {

        DataSet ds = new DataSet();
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        
        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetOfficeTeleDtl_DLB", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetOfficeTeleDtl_Qc(string strWhere)
    {

        DataSet ds = new DataSet();
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        //string strSQL = "select TOP 100 PERCENT REF_NO,o.CASE_ID, CENTRE_ID, CLIENT_ID,OFF_PHONE,OFFICE_EXT as [OFF_EXTN]," +
        //               " APPLICANT_NAME, TIME_AT_CURRENT_EMPL_Y_M,InputDesignation as DESIGNATION, DEPARTMENT, " +
        //               " FOR_SELF_EMPLOYED_TYPE_OF_ORGANIZATION,COMPANY_NAME as COMPANYNAME, " +
        //               " ISNULL(OFF_ADD_LINE_1, ' ') + ' ' + ISNULL(OFF_ADD_LINE_2, ' ') + ' '+ ISNULL(OFF_ADD_LINE_3,' ') + ' ' + ISNULL(OFF_PIN_CODE, ' ') " +
        //               " as OFF_ADD_LINE_1,LAND_MARK_OBSERVED as LANDMARK,SPECIAL_INSTRUCTIONS, " +
        //               " PERSON_CONTACTED,OTHER_CONTACTED_DESIGNATION as First_Name,REL_WITH_APPLICANT, " +
        //               " APPLICANT_NAME_CONFIRMED_AT_GIVEN_NO, SPK_TO," +
        //               " CONVERT(char(24), ATTEMPT_DATE_TIME, 103) AS VisitDate, " +
        //               " SUBSTRING(CONVERT(varchar(24), ATTEMPT_DATE_TIME, 100), 12, 12) AS Time_Of_calling," +
        //               " Remark AS REMARKS, Any_Info as TCRemark,VERIFIER_ID, FULLNAME AS Verifier_Name, " +
        //               " status_name as [TELE_VERIFICATION_RESULT],TIME_AT_CURRENT_EMPL_Y_M,OTHER_NATURE_OF_BUSINESS," +
        //               " ADDITIONAL_REMARK,OVERALL_ASSESMENT_REASON as DECLINED_REASON,SUPERVISOR_REMARKS " +
        //               " from CPV_CC_CASE_OUTPUT_VW o left join CPV_CC_VERI_ATTEMPTS a on o.case_id=a.case_id " +
        //               " and o.verification_type_id=a.verification_type_id " +
        //               " where o.case_id IN ('" + strWhere + "') and o.verification_type_id=3 ";

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetOfficeTeleDtl_Qc", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    // New Addition : 27/06/2008
    public DataTable GetOfficeTeleDtlRL(string strWhere)
    {

        DataSet ds = new DataSet();
        //OleDbParameter[] buisi = new OleDbParameter[1];
        //buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        //buisi[0].Value = strWhere;
        string strSQL;

        strSQL = "Select CD.Case_id, ISNULL(Cd.FIRST_NAME + ' ', '') + ISNULL(Cd.MIDDLE_NAME + ' ', '') + ISNULL(Cd.LAST_NAME + ' ', '') AS Applicant_Name, " +
                  " Convert(varchar(10),Cd.Case_Rec_Datetime,103) As recd_Dt, " +
                  " Cd.Off_Phone,Cd.Mobile,Cd.Department,Cd.Off_Extn, " +
                  " Vd.Office_Ownership As Ownership,Cd.Off_Name As Name_Of_Company, " +
                  " Vd.Designation,Vd.Type_Office,Vd.Nature_Business As Nature_of_Business,'' As Alt_Off_Number, " +
                  " Vd.Person_Contacted As Person_Contacted,Vd.Designation_Contacted_Person As relationship, " +
                  " Vd.Applicant_Availbility As Applicant_Availbility,Vd.Remarks As remark,Vd.Dir_Check As DirCheck, " +
                  " Vd.Person_Confirm_Address As Name_Confirm, " +
                  " Convert(varchar(10),Tl.Attempt_Datetime,103) As Date_Call,Left(Convert(varchar(10),Tl.Attempt_Datetime,114),5) As Date_Time, " +
                  " Tl.Attempt_Remark As Tele_Status,Cs.Status_Code As Status " +
                  " From Cpv_Rl_Case_Details Cd Inner Join Cpv_Rl_Verification_BvBt Vd On Cd.Case_id=Vd.Case_id  " +
                  " Inner Join CPV_RL_VERIFICATION_ATTEMPT Tl On Cd.Case_id=Tl.Case_id " + 
                  " Inner Join CASE_STATUS_MASTER Cs On Vd.Rating=Cs.Case_Status_Id " +
                  " Where Tl.Verification_Type_Id='3' and Cd.CASE_ID = '"+ strWhere +"'";

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, strSQL);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    // End
    public DataTable GetCaseIdforReport(string strWhere)
    {
        
        DataSet ds = new DataSet();
        //string strSQL = "Select count(v.case_id) as verified, Case_Id from CPV_CC_CASE_DETAILS c, CPV_CC_VERI_OTHER_DETAILS v WHERE (CASE_ID in(" + strWhere + ")) ";
        string strSQL = "Select count(*) as verified, Case_Id from CPV_CC_VERI_OTHER_DETAILS where case_id in(" + strWhere + ") group by case_id";
        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, strSQL);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;

    }
    
    public DataTable GetCaseIdforReport_Ebc(string strWhere)
    {
        
        DataSet ds = new DataSet();
        //string strSQL = "Select count(v.case_id) as verified, Case_Id from CPV_CC_CASE_DETAILS c, CPV_CC_VERI_OTHER_DETAILS v WHERE (CASE_ID in(" + strWhere + ")) ";
        string strSQL = "Select count(*) as verified, Case_Id from CPV_EBC_VERIFICATION where case_id in(" + strWhere + ") group by case_id";
        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, strSQL);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;

    }

    public DataTable GetBusinessVerificationDtl_Mashreq(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "GetExportRec_Mushreq_Dubai_ForBankformat", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetBusinessVerificationDtl_Mashreq_ExcelToPDF(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 50);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "MashBank_ExcelToPDF", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetResiVeriKYC_CRP_ClientSpecific(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_CRPTechnology_Data", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

  
    //---------Added by Manoj
    public DataTable getIDOCpancard(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] SalCert = new OleDbParameter[1];
        SalCert[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        SalCert[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_IDOC_PancardDetails", SalCert);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    //-----Ended by Manoj 

    //----Added By Kamal Matekar On 16June2012 For IDOC Salary Certificate 11

    public DataTable getIDOCSalaryCertificate(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] SalCert = new OleDbParameter[2];
        SalCert[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        SalCert[0].Value = strWhere;

        SalCert[1] = new OleDbParameter("@Verification_Type_id", OleDbType.VarChar, 15);
        SalCert[1].Value = "11";

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "GetIDOC_SalaryCertificateDetails", SalCert);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    //----Added By Kamal Matekar On 16June2012 For IDOC SalarySlip 5

    public DataTable getIDOCSalarySlip(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] SalCert = new OleDbParameter[2];
        SalCert[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        SalCert[0].Value = strWhere;

        SalCert[1] = new OleDbParameter("@Verification_Type_id", OleDbType.VarChar, 15);
        SalCert[1].Value = "5";

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "GetIDOC_SalaryCertificateDetails", SalCert);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    //----Added By Kamal Matekar On 16June2012 For IDOC Form 16   8

    public DataTable getIDOCForm16(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] SalCert = new OleDbParameter[2];
        SalCert[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        SalCert[0].Value = strWhere;

        SalCert[1] = new OleDbParameter("@Verification_Type_id", OleDbType.VarChar, 15);
        SalCert[1].Value = "8";

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "GetIDOC_SalaryCertificateDetails", SalCert);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    //----Added By Kamal Matekar On 16June2012 For IDOC Bank Statement

    public DataTable getIDOCBS(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] SalCert = new OleDbParameter[1];
        SalCert[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        SalCert[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_IDOC_BankStatementDetails", SalCert);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    //----Added By Kamal Matekar On 16June2012 For IDOC RC
    public DataTable getIDOCRC(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] SalCert = new OleDbParameter[1];
        SalCert[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        SalCert[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "GetIDOC_RC", SalCert);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable getIDOCPD(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] SalCert = new OleDbParameter[1];
        SalCert[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        SalCert[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "GetIDOC_PD", SalCert);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetCaseIdforReportKyc(string strWhere)
    {

        DataSet ds = new DataSet();
        //string strSQL = "Select count(v.case_id) as verified, Case_Id from CPV_CC_CASE_DETAILS c, CPV_CC_VERI_OTHER_DETAILS v WHERE (CASE_ID in(" + strWhere + ")) ";
        string strSQL = "Select count(*) as verified, Case_Id from CPV_KYC_CASE_VERIFICATION where case_id in('" + strWhere + "') group by case_id";
        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, strSQL);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;

    }
    //Add  by Manoj for Deuhbank  
    public DataTable GetRV_Deuhchbankkyc_Vetting(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_Deutschebankaccount", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
   

    //Added by kamal matekar for Atom_Tech_Facilitator
    public DataTable GetBV_POS_Merchant_Vetting(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_AtomTechBvExport_POS", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    //Added by kamal matekar for Atom_Tech_Facilitator
    public DataTable GetBV_MOS_Merchant_Vetting(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_AtomTechBvExport_MSP", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetYesBankRvInfo(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_YesBankRvInfo", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    public DataTable GetYesBankBvInfo(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_YesBankBvInfo", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetSvcITR(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] ITR = new OleDbParameter[2];
        ITR[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        ITR[0].Value = strWhere;

        ITR[1] = new OleDbParameter("@Verification_type_id", OleDbType.VarChar, 15);
        ITR[1].Value = "34";

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "GetData_ForITRVerificationReport", ITR);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetSvcBankStat(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetRL_BankStatement", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetSvcForm16(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGet_SS_DtlRL_PNB_HL", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetSvcBV_Self(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetSvcBV_Self", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetSvcBV_Sal(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetSvcBV_Sal", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetSvcRV(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetSvcRV", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    //Added by Manoj for ..... Indusand bank
    public DataTable GetBusinessVerificationIndusandKyc_Curr(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "GetIndusandbank_BV", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    //Ended by Manoj
    public DataTable GetCaseIdforReportRL1(string strWhere)
    {

        DataSet ds = new DataSet();
        //string strSQL = "Select count(v.case_id) as verified, Case_Id from CPV_CC_CASE_DETAILS c, CPV_CC_VERI_OTHER_DETAILS v WHERE (CASE_ID in(" + strWhere + ")) ";
        string strSQL = "Select count(*) as verified, Case_Id from CPV_RL_CASE_VERIFICATIONTYPE where case_id in(" + strWhere + ") group by case_id";
        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, strSQL);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;

    }
    // Nikhil Lad
    public DataTable GetFederalRL_BV(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_FederalRL_BV_PDFExport", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    //Nikhil Lad
    public DataTable GetFederalRL_RV(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_FederalRL_RV_PDFExport", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    //--Added by Manoj
    public DataTable GetResiVeriDtl_yesbank(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_Resyesbank", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    public DataTable GetBussVeriDtl_yesbank(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "GetBusyesbank", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    //Ended by Manoj
    public DataTable GetFullertonVerifyDetails(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] CaseId = new OleDbParameter[1];
        CaseId[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        CaseId[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_FullertonExport", CaseId);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetResiVeriDtl_PNBHL_App(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetResiVeriDtlFor_PNBHL", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetBusiVeriDtlRL_PNB_App(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetBusiVeriDtlFor_PNBHL_BV", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable Get_ITR_DtlRL_PNB_HL(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] ITR = new OleDbParameter[1];
        ITR[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        ITR[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "GetData_ForITRVerificationReport_PNB", ITR);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    public DataTable Get_SS_DtlRL_PNB_HL(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGet_SS_DtlRL_PNB_HL", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable Get_BankStat_DtlRL_PNB_HL(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetRL_BankStatement", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    //----Added by kamal matekar....for federal Finance........
    public DataTable GetFederalFinance_RVBV(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "FederalBankRL_RVBV_PDFFormat", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    //---added by kamal matekar....................for Barclay Finance PDF Report.........
    public DataTable GetBarclayFinancePL_BV(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_BarclayFinancePL_BV_PDFExport", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetBajajLapPsbl_BV(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "GetBussVeriDtl_BajajLapPsbl", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetBajajCE_BV(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "GetBussVeriDtl_BajajCE", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetSrei_BV(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_SreiFinEqupBvExport", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }    

    public DataTable GetBarclayFinancePL_RV(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_BarclayFinancePL_RV_PDFExport", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetSrei_RV(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_SreiFinEqupRvExport", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetBajajLapPsbl_RV(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "GetResiVeriDtl_BajajLapPsbl", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetBajajCE_RV(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "GetResiVeriDtl_BajajCE", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetVendor_Hdfcltd(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetVendorInfo_HDFCltd", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetDeutchRV(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetDeutschRV", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetDeutchBV(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetDeutschBV", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetDeutchRTBT(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetDeutschRTBT", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetNOC_Hdfcltd(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetNOCInfo_HDFCltd", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    //New Addition : 27/06/2008
    public DataTable GetCaseIdforReportRL(string strWhere)
    {
        DataSet ds = new DataSet();
        //string strSQL = "Select count(v.case_id) as verified, Case_Id from CPV_CC_CASE_DETAILS c, CPV_CC_VERI_OTHER_DETAILS v WHERE (CASE_ID in(" + strWhere + ")) ";
        string strSQL = "Select count(*) as verified, Case_Id from CPV_RL_Verification_RVRT where case_id in(" + strWhere + ") group by case_id";
        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, strSQL);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    //End
    public OleDbDataReader GetRefNoByCaseId(string sCaseId)
    {
        string sSql = "SELECT Replace(Replace(Ref_no,'\','_'),'/','_') as REF_NO from CPV_CC_CASE_DETAILS where case_id='" + sCaseId + "'";
        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }

    public OleDbDataReader GetRefNoByCaseId_Ebc(string sCaseId)
    {
        string sSql = "SELECT REF_NO,Case_ID from CPV_EBC_CASE_DETAILS where case_id='" + sCaseId + "'";
        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }

    public OleDbDataReader GetRefNoByCaseId_Qc(string sCaseId)
    {
        string sSql = "SELECT Replace(Replace(Ref_no,'\','_'),'/','_') as REF_NO from CPV_QC_CASE_DETAILS where case_id='" + sCaseId + "'";
        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    public DataTable GetBusiVeriDtlKycScbAcOp_Qc(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;
        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetbussVeriDtlKycScb_Qc", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetBVAxisMerchntbank(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SP_GET_AxisMerchant_CC_BV_Details", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }



    //Added by Manoj for City bank
    public DataTable GetResiVeriCitybank(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_CCCityBankResidence", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    public DataTable GetBusiVeriDtlCCSCB(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];

        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SP_GET_SCB_CC_BV_Details", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear(); 
        ds.Clear();
        return dt;
    }

     public DataTable GetResiVeriDtlCCSCB(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];

        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SP_GET_SCB_CC_RV_Details", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetResiVeriDtlKycScbAcOp_Qc(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;
        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetResiVeriDtlKycScb_Qc", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    //public OleDbDataReader GetRefNoByCaseIdKyc_Qc(string sCaseId)
    //{
    //    string sSql = "SELECT REF_NO from CPV_QC_CASE_DETAILS where case_id='" + sCaseId + "'";
    //    return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    //}

    public DataTable GetBusinessVerificationDtlKyc_Qc(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetBusinessVerificationDtlKyc_Qc", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetResidenceVerificationDtlKyc_Qc(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "SpGetResidenceVerificationDtlKyc_Qc", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    public OleDbDataReader GetRefNoByCaseIdKyc(string sCaseId)
    {
        string sSql = "SELECT Replace(Replace(Ref_no,'\','_'),'/','_') as REF_NO,Case_id from CPV_KYC_CASE_DETAILS where case_id='" + sCaseId + "'";
        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }
  
    //public OleDbDataReader GetRefNoByCaseIdIdoc(string sCaseId)
    //{
    //    string sSql = "SELECT Case_id+'_'+REF_NO as REF_NO from CPV_IDOC_CASE_DETAILS where case_id='" + sCaseId + "'";
    //    return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    //}
    public OleDbDataReader GetEmpCode(string sUId)
    {
        string sSql = "SELECT emp_id from Employee_master where emp_id='" + sUId + "'";
        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    public OleDbDataReader GetRefNoByCaseIdKyc_Qc(string sCaseId)
    {
        string sSql = "SELECT Replace(Replace(Ref_no,'\','_'),'/','_') as REF_NO from CPV_QC_CASE_DETAILS where case_id='" + sCaseId + "'";
        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    //public OleDbDataReader GetRefNoByCaseIdRL(string sCaseId)
    //{
    //    string sSql = "SELECT REF_NO from CPV_RL_CASE_DETAILS where case_id='" + sCaseId + "'";
    //    return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    //}
    //New Addition : 27/06/2008
    public OleDbDataReader GetRefNoByCaseIdRL(string sCaseId)
    {
        string sSql = "SELECT Case_id,Replace(Replace(Ref_no,'\','_'),'/','_') as REF_NO from CPV_RL_CASE_DETAILS where case_id='" + sCaseId + "'";
        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    public OleDbDataReader GetAppnameBycaseIDRL(string sCaseId)
    {
        string sSql = "SELECT  First_NAme as App_Name from CPV_RL_CASE_DETAILS where case_id='" + sCaseId + "'";
        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    public OleDbDataReader GetAppTypeBycaseIDRL(string sCaseId)
    {
        string sSql = "SELECT  Verification_Code as Verificode from CPV_RL_CASE_DETAILS where case_id='" + sCaseId + "'";
        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }

    public OleDbDataReader GetRefNoByCaseIdRL_Qc(string sCaseId)
    {
        string sSql = "SELECT Case_id from CPV_Qc_CASE_DETAILS where case_id='" + sCaseId + "'";
        return OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    //End
    #endregion StandardOutputReport(Verification) Report

    #region getRecords() for CoverLetter Report
    public DataSet getRecords(string sFromDate, String sToDate, string sClientId, string sCentreId)
    {
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");
       string sqlRecords = "";
       sqlRecords = "SELECT DISTINCT(CD.VERIFICATION_CODE) as VERIFICATIONCODE,CD.CASE_ID,CD.REF_NO as REFNO ,Convert(varchar(24),CD.CASE_REC_DATETIME,103)+ ' ' +  LTRIM(SUBSTRING(CONVERT( VARCHAR(20),CD.CASE_REC_DATETIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20), CD.CASE_REC_DATETIME, 22), 3))as CASERECDATETIME, ";
       sqlRecords += "(ISNULL(FIRST_NAME,'') + ' ' + ISNULL(MIDDLE_NAME,'') + ' ' + ISNULL(LAST_NAME,'')) as NAME,Convert(varchar(24),CD.SEND_DATETIME,103)+ ' ' + LTRIM(SUBSTRING(CONVERT( VARCHAR(20),CD.SEND_DATETIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20), CD.SEND_DATETIME, 22), 3)) as SENDDATETIME, ";
        sqlRecords += "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FromDate, ";
        sqlRecords += "'" +Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as Todate, ";
        sqlRecords += "'Pamac Online' as CompanyName ";
        sqlRecords += " FROM CPV_CC_CASE_DETAILS CD INNER JOIN CPV_CC_CASE_VERIFICATIONTYPE VT ";
        sqlRecords += " ON VT.CASE_ID=CD.CASE_ID INNER JOIN VERIFICATION_TYPE_MASTER VTM ";
        sqlRecords += " ON VT.VERIFICATION_TYPE_ID=VTM.VERIFICATION_TYPE_ID ";
        sqlRecords += " WHERE CD.SEND_DATETIME >= '" + sFromDate + "' AND CD.SEND_DATETIME < '" + sToDate + "' AND CD.SEND_DATETIME IS NOT NULL ";
        sqlRecords += " AND CD.CLIENT_ID='" + sClientId + "' AND CD.CENTRE_ID='" + sCentreId + "' ";
        sqlRecords += " ORDER BY CASERECDATETIME ,CD.CASE_ID,SENDDATETIME ";
        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sqlRecords);
    }
    #endregion getRecords() for CoverLetter Report

    #region GetIDOCCoveringLetterDtl() for CoverLetter Report
    public DataSet GetIDOCCoveringLetterDtl(string sFromDate, String sToDate, string sClientId, string sCentreId,string sVeriTypeID)
    {
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");
        
        string sSql = "";
        string strveriid="";
        if (sVeriTypeID != "All")
        {
            sSql = "SELECT  DISTINCT(CD.CASE_ID) as [Case ID],CD.REF_NO AS [Ref no],CD.REF_NO as REFNO ,CD.CASE_REC_DATETIME " +
                    " as CASERECDATETIME ,cm.client_name as [Client name], (ISNULL(FIRST_NAME,'') + ' ' + ISNULL(MIDDLE_NAME,'') + ' ' + ISNULL(LAST_NAME,'')) as NAME" +
                    " ,CD.SEND_DATETIME as SENDDATETIME,'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "'  as FromDate" +
                    " , '" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as Todate, 'Pamac Online' as [Company Name] " +
                    " ,csm.status_name as Status,VTM.VERIFICATION_TYPE AS Verification " +
                    " ,cd.ASST_YEAR as AssetYear,CIV.FE_REMARK as Remark " +
                    " FROM   client_master cm inner join  CPV_IDOC_CASE_DETAILS CD on(cd.client_id=cm.client_id) INNER JOIN " +
                    " CPV_IDOC_VERIFICATION CIV ON CD.CASE_ID = CIV.CASE_ID INNER JOIN " +
                    " CPV_IDOC_VERIFICATION_TYPE VT ON CD.CASE_ID = VT.CASE_ID INNER JOIN " +
                    " CASE_STATUS_MASTER CSM ON CIV.CASE_STATUS_ID = CSM.CASE_STATUS_ID INNER JOIN " +
                    " VERIFICATION_TYPE_MASTER VTM ON " +
                    " CIV.VERIFICATION_TYPE_ID = VTM.VERIFICATION_TYPE_ID AND " +
                    " VT.VERIFICATION_TYPE_ID = VTM.VERIFICATION_TYPE_ID " +
                    " WHERE CD.SEND_DATETIME >= '" + sFromDate + "' AND CD.SEND_DATETIME < '" + sToDate + "' " +
                    " AND CD.SEND_DATETIME IS NOT NULL AND CD.CLIENT_ID='" + sClientId + "' AND CD.CENTRE_ID='" + sCentreId + "' " +
                    " AND VT.VERIFICATION_TYPE_ID = '" + sVeriTypeID + "' ORDER BY CD.CASE_REC_DATETIME ASC ,CD.CASE_ID,CD.SEND_DATETIME";
        }
        else
        {
            sSql = "SELECT  DISTINCT(CD.CASE_ID) as [Case ID],CD.REF_NO AS [Ref no],CD.REF_NO as REFNO ,CD.CASE_REC_DATETIME " +
                    " as CASERECDATETIME ,cm.client_name as [Client name], (ISNULL(FIRST_NAME,'') + ' ' + ISNULL(MIDDLE_NAME,'') + ' ' + ISNULL(LAST_NAME,'')) as NAME" +
                    " ,CD.SEND_DATETIME as SENDDATETIME,'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "'  as FromDate" +
                    " , '" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as Todate, 'Pamac Online' as [Company Name] " +
                    " ,csm.status_name as Status, VTM.VERIFICATION_TYPE AS Verification " +
                    " FROM   client_master cm inner join  CPV_IDOC_CASE_DETAILS CD on(cd.client_id=cm.client_id) INNER JOIN " +
                    " CPV_IDOC_VERIFICATION CIV ON CD.CASE_ID = CIV.CASE_ID INNER JOIN " +
                    " CPV_IDOC_VERIFICATION_TYPE VT ON CD.CASE_ID = VT.CASE_ID INNER JOIN " +
                    " CASE_STATUS_MASTER CSM ON CIV.CASE_STATUS_ID = CSM.CASE_STATUS_ID INNER JOIN " +
                    " VERIFICATION_TYPE_MASTER VTM ON " +
                    " CIV.VERIFICATION_TYPE_ID = VTM.VERIFICATION_TYPE_ID AND " +
                    " VT.VERIFICATION_TYPE_ID = VTM.VERIFICATION_TYPE_ID " +
                    " WHERE CD.SEND_DATETIME >= '" + sFromDate + "' AND CD.SEND_DATETIME < '" + sToDate + "' " +
                    " AND CD.SEND_DATETIME IS NOT NULL AND CD.CLIENT_ID='" + sClientId + "' AND CD.CENTRE_ID='" + sCentreId + "' " +
                    " ORDER BY CD.CASE_REC_DATETIME ASC ,CD.CASE_ID,CD.SEND_DATETIME";
        }

        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetIDOCCoveringLetterDtl() for CoverLetter Report

    #region GetEBCCoveringLetterDtl() for CoverLetter Report

    public DataSet GetEBCCoveringLetterDtl_New(string sFromDate, String sToDate, string sClientId, string sCentreId, string sVeriTypeID)
    {
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");

        string sSql = "";
        string strveriid = "";
        if (sVeriTypeID != "--All--")
        {
            sSql = "SELECT  CD.CASE_ID as [Case ID],CD.REF_NO AS [Ref no],Convert(varchar(24),CD.CASE_REC_DATETIME,103) " +
                      " as ReceivedDate ,cm.client_name as [Client name], (ISNULL(FIRST_NAME,'') + ' ' + ISNULL(MIDDLE_NAME,'') + ' ' + ISNULL(LAST_NAME,'')) as NAME" +
                      " ,Convert(varchar(24),CD.SEND_DATETIME,103) as SentDate,'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "'  as FromDate" +
                      " , '" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as Todate, 'Pamac Online' as [Company Name] " +
                      " ,VTM.VERIFICATION_TYPE AS Verification ,CNM.CENTRE_NAME AS CenterName " +
                      " from CPV_EBC_CASE_DETAILS CD inner join client_master cm on cd.client_id=cm.client_id left outer join cpv_ebc_vaerification_type veriType " +
                      " on cd.Case_id=veriType.Case_id INNER JOIN  VERIFICATION_TYPE_MASTER VTM ON veriType.VERIFICATION_TYPE_ID = VTM.VERIFICATION_TYPE_ID " + 
                      " INNER JOIN  CENTRE_MASTER CNM ON CD.CENTRE_ID=CNM.CENTRE_ID " +
                      " WHERE CD.SEND_DATETIME >= '" + sFromDate + "' AND CD.SEND_DATETIME < '" + sToDate + "' " +
                      " AND CD.SEND_DATETIME IS NOT NULL AND CD.CLIENT_ID='" + sClientId + "' AND CD.CENTRE_ID='" + sCentreId + "' " +
                      " AND veriType.VERIFICATION_TYPE_ID = '" + sVeriTypeID + "' ORDER BY ReceivedDate ASC ,CD.CASE_ID,SentDate";
        }
        else
        {
            sSql = "SELECT  DISTINCT(CD.CASE_ID) as [Case ID],CD.REF_NO AS [Ref no],CD.REF_NO as REFNO ,CD.CASE_REC_DATETIME " +
                    " as ReceivedDate ,cm.client_name as [Client name], (ISNULL(FIRST_NAME,'') + ' ' + ISNULL(MIDDLE_NAME,'') + ' ' + ISNULL(LAST_NAME,'')) as NAME" +
                    " ,CD.SEND_DATETIME as SentDate,'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "'  as FromDate" +
                    " , '" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as Todate, 'Pamac Online' as [Company Name] " +
                    " ,Verification_Type from CPV_EBC_CASE_DETAILS CD inner join client_master cm on cd.client_id=cm.client_id " +
                    " left outer join cpv_ebc_vaerification_type veriType on cd.Case_id=veriType.Case_id INNER JOIN  VERIFICATION_TYPE_MASTER VTM  " + 
                    " ON veriType.VERIFICATION_TYPE_ID = VTM.VERIFICATION_TYPE_ID INNER JOIN  CENTRE_MASTER CNM ON CD.CENTRE_ID=CNM.CENTRE_ID " +
                    " WHERE CD.SEND_DATETIME >= '" + sFromDate + "' AND CD.SEND_DATETIME < '" + sToDate + "' " +
                    " AND CD.SEND_DATETIME IS NOT NULL AND CD.CLIENT_ID='" + sClientId + "' AND CD.CENTRE_ID='" + sCentreId + "' " +
                    " ORDER BY CD.CASE_REC_DATETIME ASC ,CD.CASE_ID,CD.SEND_DATETIME";
        }

        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }

    public DataSet GetEBCCoveringLetterDtl(string sFromDate, String sToDate, string sClientId, string sCentreId, string sVeriTypeID)
    {
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");

        string sSql = "";
        string strveriid = "";
        if (sVeriTypeID != "All")
        {
            sSql = "SELECT  DISTINCT(CD.CASE_ID) as [Case ID],CD.REF_NO AS [Ref no],CD.REF_NO as REFNO ,Convert(varchar(24),CD.CASE_REC_DATETIME,103) " +
                      " as ReceivedDate ,cm.client_name as [Client name], (ISNULL(FIRST_NAME,'') + ' ' + ISNULL(MIDDLE_NAME,'') + ' ' + ISNULL(LAST_NAME,'')) as NAME" +
                      " ,Convert(varchar(24),CD.SEND_DATETIME,103) as SentDate,'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "'  as FromDate" +
                      " , '" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as Todate, 'Pamac Online' as [Company Name] " +
                      " ,csm.status_name as Status,VTM.VERIFICATION_TYPE AS Verification " +
                      ",CNM.CENTRE_NAME AS CenterName "+
                      " FROM  client_master cm inner join  CPV_EBC_CASE_DETAILS CD on(cd.client_id=cm.client_id) INNER JOIN " +
                      " CPV_EBC_VERIFICATION CIV ON CD.CASE_ID = CIV.CASE_ID INNER JOIN " +
                      " CPV_EBC_VAERIFICATION_TYPE VT ON CD.CASE_ID = VT.CASE_ID INNER JOIN " +
                      " CASE_STATUS_MASTER CSM ON CIV.CASE_STATUS_ID = CSM.CASE_STATUS_ID INNER JOIN " +
                      " VERIFICATION_TYPE_MASTER VTM ON " +
                      " CIV.VERIFICATION_TYPE_ID = VTM.VERIFICATION_TYPE_ID AND " +
                      " VT.VERIFICATION_TYPE_ID = VTM.VERIFICATION_TYPE_ID INNER JOIN " +
                      " CENTRE_MASTER CNM ON CD.CENTRE_ID=CNM.CENTRE_ID " +
                      " WHERE CD.SEND_DATETIME >= '" + sFromDate + "' AND CD.SEND_DATETIME < '" + sToDate + "' " +
                      " AND CD.SEND_DATETIME IS NOT NULL AND CD.CLIENT_ID='" + sClientId + "' AND CD.CENTRE_ID='" + sCentreId + "' " +
                      " AND VT.VERIFICATION_TYPE_ID = '" + sVeriTypeID + "' ORDER BY ReceivedDate ASC ,CD.CASE_ID,SentDate";
         
        }
        else
        {
            sSql = "SELECT  DISTINCT(CD.CASE_ID) as [Case ID],CD.REF_NO AS [Ref no],CD.REF_NO as REFNO ,CD.CASE_REC_DATETIME " +
                    " as ReceivedDate ,cm.client_name as [Client name], (ISNULL(FIRST_NAME,'') + ' ' + ISNULL(MIDDLE_NAME,'') + ' ' + ISNULL(LAST_NAME,'')) as NAME" +
                    " ,CD.SEND_DATETIME as SentDate,'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "'  as FromDate" +
                    " , '" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as Todate, 'Pamac Online' as [Company Name] " +
                    " ,csm.status_name as Status, 'All' AS Verification " +
                    " FROM   client_master cm inner join  CPV_EBC_CASE_DETAILS CD on(cd.client_id=cm.client_id) INNER JOIN " +
                    " CPV_EBC_VERIFICATION CIV ON CD.CASE_ID = CIV.CASE_ID INNER JOIN " +
                    " CPV_EBC_VERIFICATION_TYPE VT ON CD.CASE_ID = VT.CASE_ID INNER JOIN " +
                    " CASE_STATUS_MASTER CSM ON CIV.CASE_STATUS_ID = CSM.CASE_STATUS_ID INNER JOIN " +
                    " VERIFICATION_TYPE_MASTER VTM ON " +
                    " CIV.VERIFICATION_TYPE_ID = VTM.VERIFICATION_TYPE_ID AND " +
                    " VT.VERIFICATION_TYPE_ID = VTM.VERIFICATION_TYPE_ID " +
                    " WHERE CD.SEND_DATETIME >= '" + sFromDate + "' AND CD.SEND_DATETIME < '" + sToDate + "' " +
                    " AND CD.SEND_DATETIME IS NOT NULL AND CD.CLIENT_ID='" + sClientId + "' AND CD.CENTRE_ID='" + sCentreId + "' " +
                    " ORDER BY CD.CASE_REC_DATETIME ASC ,CD.CASE_ID,CD.SEND_DATETIME";
        }

        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetEBCCoveringLetterDtl() for CoverLetter Report

    #region GetKYCCoveringLetterDtl() for CoverLetter Report
    public DataSet GetKYCCoveringLetterDtl(string sFromDate, String sToDate, string sClientId, string sCentreId)
    {
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");

        string sSql = "";
        string strveriid = "";
        
            sSql = "SELECT  DISTINCT(CD.CASE_ID) as [Case ID],CD.REF_NO AS [Ref no],CD.REF_NO as REFNO ,CD.CASE_REC_DATETIME " +
                    " as CASERECDATETIME ,cm.client_name as [Client name], (ISNULL(FIRST_NAME,'') + ' ' + ISNULL(MIDDLE_NAME,'') + ' ' + ISNULL(LAST_NAME,'')) as NAME" +
                    " ,CD.SEND_DATETIME as SENDDATETIME,'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "'  as FromDate" +
                    " , '" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as Todate, 'Pamac Online' as [Company Name] " +
                    " ,csm.status_name as Status,VTM.VERIFICATION_TYPE AS Verification " +
                    " FROM   client_master cm inner join  CPV_KYC_CASE_DETAILS CD on(cd.client_id=cm.client_id) INNER JOIN " +
                    " CPV_KYC_CASE_VERIFICATION CIV ON CD.CASE_ID = CIV.CASE_ID INNER JOIN " +
                    " CPV_KYC_VERIFICATION_TYPE VT ON CD.CASE_ID = VT.CASE_ID INNER JOIN " +
                    " CASE_STATUS_MASTER CSM ON CD.CASE_STATUS_ID = CSM.CASE_STATUS_ID INNER JOIN " +
                    " VERIFICATION_TYPE_MASTER VTM ON " +
                    " CIV.VERIFICATION_TYPE_ID = VTM.VERIFICATION_TYPE_ID AND " +
                    " VT.VERIFICATION_TYPE_ID = VTM.VERIFICATION_TYPE_ID " +
                    " WHERE CD.SEND_DATETIME >= '" + sFromDate + "' AND CD.SEND_DATETIME < '" + sToDate + "' " +
                    " AND CD.SEND_DATETIME IS NOT NULL AND CD.CLIENT_ID='" + sClientId + "' AND CD.CENTRE_ID='" + sCentreId + "' " +
                    " ORDER BY CD.CASE_REC_DATETIME ASC ,CD.CASE_ID,CD.SEND_DATETIME";
        
        
        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetKYCCoveringLetterDtl() for CoverLetter Report

    # region GetBifurcationOfCases()
    public DataSet GetBifurcationOfCases(string sFromDate, String sToDate, string sClientId, string sCentreId)
    {
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");

        DataSet ds = new DataSet();
        OleDbConnection con = new OleDbConnection(objCmn.ConnectionString);
        con.Open();
        string sCaseCondition = "";
        if (CaseType != "0")
        {
            sCaseCondition = "AND VTM.VERIFICATION_TYPE_ID=" + CaseType + " ";
        }

        string str = "SELECT " +
                     "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
                     "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
                     "'PAMAC Online' as [COMPANYNAME],CONVERT(VARCHAR,CASE_REC_DATETIME,103) as [RECDATE], " +
                     " convert(varchar,CASE_REC_DATETIME,103) as [RECD DATE],count(case_id) as [RECD CASES],SUM(Day0)as day0," +
                     " SUM(Day1)as day1,SUM(Day2)as day2,SUM(Day3)as day3,SUM(Day4)as day4,SUM(Day5)as day5, " +
                     " SUM(Day6)as day6,SUM(Day7)as day7,SUM(Day8)as day8,SUM(Day9)as day9," +
                     " SUM(After9Day) as after9day,SUM(PENDING)as pending , " +
                     "convert(varchar,dateAdd(day,1,CASE_REC_DATETIME),103) as date1, " +
                     "convert(varchar,dateAdd(day,2,CASE_REC_DATETIME),103) as date2, " +
                     "convert(varchar,dateAdd(day,3,CASE_REC_DATETIME),103) as date3, " +
                     "convert(varchar,dateAdd(day,4,CASE_REC_DATETIME),103) as date4, " +
                     "convert(varchar,dateAdd(day,5,CASE_REC_DATETIME),103) as date5, " +
                     "convert(varchar,dateAdd(day,6,CASE_REC_DATETIME),103) as date6, " +
                     "convert(varchar,dateAdd(day,7,CASE_REC_DATETIME),103) as date7, " +
                     "convert(varchar,dateAdd(day,8,CASE_REC_DATETIME),103) as date8, " +
                     "convert(varchar,dateAdd(day,9,CASE_REC_DATETIME),103) as date9 " +
                     " FROM (SELECT CASE_REC_DATETIME,SEND_DATETIME,CASE_ID, " +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME))= 0 THEN 1 ELSE 0  END as 'Day0', " +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME))= 1 THEN 1 ELSE 0  END as 'Day1', " +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 2 THEN 1 ELSE 0  END as 'Day2'," +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME))= 3 THEN 1 ELSE 0  END as 'Day3'," +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 4 THEN 1 ELSE 0  END as 'Day4'," +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 5 THEN 1 ELSE 0  END as 'Day5'," +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 6 THEN 1 ELSE 0  END as 'Day6'," +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 7 THEN 1 ELSE 0  END as 'Day7'," +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 8 THEN 1 ELSE 0  END as 'Day8'," +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 9 THEN 1 ELSE 0  END as 'Day9'," +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) > 9 THEN 1 ELSE 0  END as 'After9Day', " +
                     " CASE SEND_DATETIME WHEN ISNULL(SEND_DATETIME, '') THEN 0 ELSE 1 END AS 'PENDING' " +
                     " FROM CPV_IDOC_CASE_DETAILS CS RIGHT OUTER JOIN VERIFICATION_TYPE_MASTER VTM ON(CS.VERIFICATION_CODE=VTM.VERIFICATION_TYPE_CODE) " +
                     " WHERE CASE_REC_DATETIME >= '" + sFromDate + "' AND  CASE_REC_DATETIME <'" + sToDate + "' " + sCaseCondition + " " +
                     " AND Client_Id='" + sClientId + "'and centre_id='" + sCentreId + "') AS EXP1 " +
                     " GROUP BY convert(varchar,CASE_REC_DATETIME,103)  ,convert(varchar,dateAdd(day,1,CASE_REC_DATETIME),103), " +
                     "convert(varchar,dateAdd(day,2,CASE_REC_DATETIME),103),convert(varchar,dateAdd(day,3,CASE_REC_DATETIME),103), " +
                     "convert(varchar,dateAdd(day,4,CASE_REC_DATETIME),103),convert(varchar,dateAdd(day,5,CASE_REC_DATETIME),103), " +
                     "convert(varchar,dateAdd(day,6,CASE_REC_DATETIME),103),convert(varchar,dateAdd(day,7,CASE_REC_DATETIME),103), " +
                     "convert(varchar,dateAdd(day,8,CASE_REC_DATETIME),103),convert(varchar,dateAdd(day,9,CASE_REC_DATETIME),103) ";

        ds = OleDbHelper.ExecuteDataset(con, CommandType.Text, str);
        return ds;
    }
    #endregion GetBifurcationOfCases()

    # region GetIDOC_FESearchReport()
    public DataSet GetIdocFESearch(string sFromDate, string sToDate, string sClientId, string sCentreId)
    {
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");
        string sSql = "";
        sSql = "SELECT count(cd.case_id) NOOFCASES,(isnull(EM.FIRSTNAME,' ')+' '+isnull(EM.Middlename,' ')+' '+isnull(EM.lastname,' '))" +
              "as FENAME , VM.VERIFICATION_TYPE as VERIFICATIONTYPE, cm.client_name as Client , " +
                 "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
               "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
                " 'PAMAC Online' as COMPANYNAME " +
              "FROM CPV_idoc_FE_CASE_MAPPING FE INNER JOIN CPV_idoc_CASE_DETAILS CD ON FE.CASE_ID = CD.CASE_ID " +
              "INNER JOIN VERIFICATION_TYPE_MASTER VM ON FE.VERIFICATION_TYPE_ID = VM.VERIFICATION_TYPE_ID " +
              "INNER JOIN EMPLOYEE_MASTER EM ON FE.FE_ID = EM.EMP_ID  inner join client_master cm on(cm.client_id=cd.client_id) "+
              "WHERE CD.CLIENT_ID='" + sClientId + "' AND CD.CENTRE_ID='" + sCentreId + "'" +
              "AND fe.date_time >='" + sFromDate + "' AND fe.date_time <'" + sToDate + "'" +
              "group by VM.verification_type,EM.FIRSTNAME,EM.Middlename,EM.lastname,cm.client_name " +
              "order by EM.FIRSTNAME";
        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    # endregion GetIDOC_FESearchReport()

    # region GetIDOC_claimMISReport()
    public DataSet GetIDOCClaimMISReport(string sFromDate, String sToDate, string sClientId, string sCentreId)
    {
        string sSql = "";

        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");
        sSql = "select distinct Convert(varchar(24),cd.CASE_REC_DATETIME,103)as [Received Date], cd.CASE_ID as [CASE ID],cd.REF_NO as BANK_REF_NO," +
                "(isNull(cd.FIRST_NAME,'')+' '+isnull(cd.MIDDLE_NAME,'')+' '+isnull(cd.LAST_NAME,'')) as [Applicant Name]," +
                "Convert(varchar(24),cd.SEND_DATETIME,103)as [Send Date],vtm.VERIFICATION_TYPE_CODE as [VARIFICATION TYPE CODE],vtm.VERIFICATION_TYPE as [VARIFICATION TYPE],cd.VERIFICATION_CHARGES as [VARIFICATION CHARGES]," +
                "csm.status_name as [STATUS NAME], " +
                "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FromDate, " +
                "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as Todate, " +
                "'Pamac Online' as CompanyName,cm.CLIENT_NAME as CLIENTNAME  " +
                ",cd.ASST_YEAR as AssetYear,civ.FE_REMARK as Remark " +
                " From CPV_IDOC_CASE_DETAILS as cd  " +
                " inner join CPV_IDOC_VERIFICATION_TYPE as cvt on cd.CASE_ID=cvt.CASE_ID inner join VERIFICATION_TYPE_MASTER as vtm  " +
                " on cvt.VERIFICATION_TYPE_ID=vtm.VERIFICATION_TYPE_ID inner join CPV_IDOC_VERIFICATION as civ on civ.case_id=cd.case_id  " +
                " inner join CASE_STATUS_MASTER as csm on civ.case_status_id=csm.case_status_id inner join CLIENT_MASTER as cm on cd.CLIENT_ID=cm.CLIENT_ID  " +
                " where cd.SEND_DATETIME >= " +
                "'" + sFromDate + "'" +
                " and cd.SEND_DATETIME < " +
                "'" + sToDate + "'" +
                " AND cd.CLIENT_ID='" + sClientId + "'" +
                " AND cd.CENTRE_ID='" + sCentreId + "'";


        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    # endregion GetIDOC_claimMISReport()

    # region GetKYC_claimMISReport()
    public DataSet GetKYCClaimMISReport(string sFromDate, String sToDate, string sClientId, string sCentreId)
    {
        string sSql = "";

        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");
        sSql = "select distinct Convert(varchar(24),cd.CASE_REC_DATETIME,103)as [Received Date], cd.CASE_ID as [CASE ID],cd.REF_NO as BANK_REF_NO," +
                "(isNull(cd.FIRST_NAME,'')+' '+isnull(cd.MIDDLE_NAME,'')+' '+isnull(cd.LAST_NAME,'')) as [Applicant Name]," +
                "Convert(varchar(24),cd.SEND_DATETIME,103)as [Send Date],vtm.VERIFICATION_TYPE_CODE as [VARIFICATION TYPE CODE],vtm.VERIFICATION_TYPE as [VARIFICATION TYPE],cd.VERIFICATION_CHARGES as [VARIFICATION CHARGES]," +
                "csm.status_name as [STATUS NAME], " +
                "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FromDate, " +
                "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as Todate, " +
                "'Pamac Online' as CompanyName,cm.CLIENT_NAME as CLIENTNAME  " +
                " From CPV_KYC_CASE_DETAILS as cd  " +
                " inner join CPV_KYC_VERIFICATION_TYPE as cvt on cd.CASE_ID=cvt.CASE_ID inner join VERIFICATION_TYPE_MASTER as vtm  " +
                " on cvt.VERIFICATION_TYPE_ID=vtm.VERIFICATION_TYPE_ID inner join CPV_KYC_CASE_VERIFICATION as civ on civ.case_id=cd.case_id  " +
                " inner join CASE_STATUS_MASTER as csm on cd.case_status_id=csm.case_status_id inner join CLIENT_MASTER as cm on cd.CLIENT_ID=cm.CLIENT_ID  " +
                " where cd.SEND_DATETIME >= " +
                "'" + sFromDate + "'" +
                " and cd.SEND_DATETIME < " +
                "'" + sToDate + "'" +
                " AND cd.CLIENT_ID='" + sClientId + "'" +
                " AND cd.CENTRE_ID='" + sCentreId + "'";


        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }

    # endregion GetKYC_claimMISReport()

    #region Cell_GetPendingList for Cellular

    public DataSet Cell_GetPendingList(string sFromDate, String sToDate, string sClientId, string sCentreId)
    {
        string sSql = "";
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");
        string scondition = "";
        if (value == "true")
        {
            scondition = " CS.SEND_DATETIME IS NULL";
        }
        else
        {
            scondition = "CS.CASE_REC_FROM_FE='N' and CS.SEND_DATETIME IS NULL ";
        }
        //sSql = "select cc.SR_NO as SrNo,cc. REF_NO as RefNo,cc.CELLNO as CellNo,(ISNULL(cc.APP_FNAME + ' ', '') +ISNULL(cc.APP_MNAME + ' ', '') + ISNULL(cc.APP_LNAME + ' ', '')) AS Name," +
        //       "CONVERT(VARCHAR(24),cc. CASE_REC_DATETIME,103) As RECD_DATE,CC.COMP_NAME as CompName,CC.APP_PINCODE AS ZipCode,ccm.customer_class_code as customerClass," +
        //       "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
        //       "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE,cc.APP_PHONE1 as PhNo1,cc.APP_PHONE2 PhNo2," +
        //        "'PAMAC Online' as COMPANYNAME ,cm.client_name as Client ," +
        //       "(ISNULL(cc.APP_ADDR1+' ','') + ISNULL(cc.APP_ADDR2+' ','') + ISNULL(cc.APP_ADDR3+' ','') + ISNULL(cc.APP_CITY + ' ','') + ISNULL (cc.APP_STREET + ' ','')) AS ResidenceAddres,fev.FULLNAME AS [FE Name]" +
        //       " from client_master cm inner join CPV_CELLULAR_CASES cc on(cm.client_id=cc.client_id)  inner join  CPV_CELLULAR_CUSTOMER_CLASS_MASTER ccm on(ccm.CUSTOMER_CLASS_name=cc.CUSTOMER_CLASS) " +
        //       " inner join CPV_CELLULAR_CASES cd on(cc.CASE_ID=cd.CASE_ID) inner join CPV_CELLULAR_CASE_VERIFICATIONTYPE vt on(cd.CASE_ID=vt.CASE_ID) inner join VERIFICATION_TYPE_MASTER vtm on(vt.verification_type_id=vtm.verification_type_id) inner join CPV_CELLULAR_FE_CASE_MAPPING fem on(fem.VERIFICATION_TYPE_ID=vtm.verification_type_id) inner join FE_VW fev on(fev.EMP_ID=fem.FE_ID )" +
        //       "  WHERE (" + scondition + ") " +
        //       " AND cc.CASE_REC_DATETIME >= '" + sFromDate + "'" +
        //       " AND cc.CASE_REC_DATETIME < '" + sToDate + "'" +
        //       " AND cc.CLIENT_ID='" + sClientId + "'" +
        //       " AND cc.CENTRE_ID='" + sCentreId + "'";
        string sCaseCondition="" ;
        if (CaseType != "0")
        {
             sCaseCondition = "AND CTM.CASE_TYPE_ID=" + CaseType + "";
        }
        sSql = " SELECT CTM.CASE_TYPE_CODE, CS.CASE_ID, CS.CASE_TYPE_ID,CS.CELLNO as CellNo, CS.CUSTOMER_CLASS,CS.SR_NO as SrNo, REF_NO as RefNo,  FE_VW.FULLNAME AS [FE Name], " +
             "(ISNULL(CS.APP_FNAME + ' ', '') +ISNULL(CS.APP_MNAME + ' ', '') + ISNULL(CS.APP_LNAME + ' ', '')) AS Name," +
             "CONVERT(VARCHAR(24),CS. CASE_REC_DATETIME,103) As RECD_DATE,CS.COMP_NAME as CompName,CS.APP_PINCODE AS ZipCode,ccm.customer_class_code as customerClass, " +
             "CS.APP_PHONE1 as PhNo1,CS.APP_PHONE2 PhNo2, " +
              "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
              "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
              "'PAMAC Online' as COMPANYNAME ," +
              "(ISNULL(CS.APP_ADDR1+' ','') + ISNULL(CS.APP_ADDR2+' ','') + ISNULL(CS.APP_ADDR3+' ','') + ISNULL(CS.APP_CITY + ' ','') + ISNULL (CS.APP_STREET + ' ','')) AS ResidenceAddres "+
             
             "FROM  CPV_CELLULAR_FE_CASE_MAPPING AS CFE INNER JOIN " +
             "FE_VW ON CFE.FE_ID = FE_VW.EMP_ID RIGHT OUTER JOIN " +
             "CPV_CELLULAR_CASES AS CS INNER JOIN " +
             "CPV_CELLULAR_CASE_TYPE_MASTER AS CTM ON CS.CASE_TYPE_ID = CTM.CASE_TYPE_ID ON CFE.CASE_ID = CS.CASE_ID LEFT OUTER JOIN " +
             "CPV_CELLULAR_VERI_ATTEMPTS AS CVA ON CS.CASE_ID = CVA.CASE_ID LEFT OUTER JOIN " +
             "CPV_CELLULAR_DISCONNECTED_CODE AS CD RIGHT OUTER JOIN " +
             "CPV_CELLULAR_VERIFICATION AS CV ON CD.DISCONNECTED_CODE_ID = CV.DISCONNECT_CODE_ID ON CS.CASE_ID = CV.CASE_ID LEFT OUTER JOIN " +
             "CPV_CELLULAR_CUSTOMER_CLASS_MASTER AS CCM ON CS.CUSTOMER_CLASS = CCM.CUSTOMER_CLASS_NAME "+
             "  WHERE (" + scondition + ")  " +
             " AND CS.CASE_REC_DATETIME >= '" + sFromDate + "' " + sCaseCondition + " " +
             " AND CS.CASE_REC_DATETIME < '" + sToDate + "' " +
             " AND CS.CLIENT_ID='" + sClientId + "' " +
             " AND CS.CENTRE_ID='" + sCentreId + "' ";
        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion

    #region Cell_GetBifercationReport for Cellular
    public DataSet Cell_GetBifercationReport(string sFromDate, string sToDate, string sClientId, string sCentreId)
    {
        string sSql = "";
        string dtToDate;
        string sCaseCondition = "";
        if (CaseType != "0")
        {
            sCaseCondition = "AND CTM.CASE_TYPE_ID=" + CaseType + " ";
        }
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");
        sSql = "SELECT  '" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, '" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE " +
             ", 'PAMAC Online' as [COMPANYNAME],  convert(varchar,CASE_REC_DATETIME,103) " +
            "as [RECD DATE],count(case_id) as [RECD CASES],SUM(Day0)as day0, SUM(Day1)as day1,SUM(Day2)as day2,SUM(Day3)as day3,SUM(Day4)as day4,SUM(Day5)as day5,  SUM(Day6)as day6,SUM(Day7)as day7,SUM(Day8)as day8,SUM(Day9)as day9, SUM(After9Day) as after9day,SUM(PENDING)as pending , " +
            "convert(varchar,dateAdd(day,1,CASE_REC_DATETIME),103) as date1, " +
            "convert(varchar,dateAdd(day,2,CASE_REC_DATETIME),103) as date2, " +
            "convert(varchar,dateAdd(day,3,CASE_REC_DATETIME),103) as date3, " +
            "convert(varchar,dateAdd(day,4,CASE_REC_DATETIME),103) as date4, " +
            "convert(varchar,dateAdd(day,5,CASE_REC_DATETIME),103) as date5, " +
            "convert(varchar,dateAdd(day,6,CASE_REC_DATETIME),103) as date6, " +
            "convert(varchar,dateAdd(day,7,CASE_REC_DATETIME),103) as date7, " +
            "convert(varchar,dateAdd(day,8,CASE_REC_DATETIME),103) as date8, " +
            "convert(varchar,dateAdd(day,9,CASE_REC_DATETIME),103) as date9 " +
            " FROM (SELECT CASE_REC_DATETIME,SEND_DATETIME,CASE_ID, " +
            
            "CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME))= 0 THEN 1 ELSE 0  END as  'Day0', " +
            "CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME))= 1 THEN 1 ELSE 0  END as  'Day1', " +
            "CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 2 THEN 1 ELSE 0  END as 'Day2', " +
            "CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME))= 3 THEN 1 ELSE 0  END as  'Day3', " +
            "CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 4 THEN 1 ELSE 0  END as 'Day4', " +
            "CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 5 THEN 1 ELSE 0  END as 'Day5', " +
            "CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 6 THEN 1 ELSE 0  END as 'Day6', " +
            "CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 7 THEN 1 ELSE 0  END as 'Day7', " +
            "CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 8 THEN 1 ELSE 0  END as 'Day8', " +
            "CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 9 THEN 1 ELSE 0  END as 'Day9', " +
            "CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) > 9 THEN 1 ELSE 0  END as 'After9Day', " +
            "CASE SEND_DATETIME WHEN ISNULL(SEND_DATETIME, '') THEN 0 ELSE 1 END AS 'PENDING' " +
            " FROM CPV_CELLULAR_CASES CS RIGHT OUTER JOIN CPV_CELLULAR_CASE_TYPE_MASTER CTM ON(CS.CASE_TYPE_ID=CTM.CASE_TYPE_ID) WHERE  " +
            " CASE_REC_DATETIME >= '" + sFromDate + "'" +
            " AND CASE_REC_DATETIME < '" + sToDate + "' " + sCaseCondition + " " +
            " AND CS.Client_Id='" + sClientId + "' and centre_id='" + sCentreId + "') " +
            "AS EXP1  GROUP BY convert(varchar,CASE_REC_DATETIME,103),convert(varchar,dateAdd(day,1,CASE_REC_DATETIME),103), " +
            "convert(varchar,dateAdd(day,2,CASE_REC_DATETIME),103),convert(varchar,dateAdd(day,3,CASE_REC_DATETIME),103), " +
            "convert(varchar,dateAdd(day,4,CASE_REC_DATETIME),103),convert(varchar,dateAdd(day,5,CASE_REC_DATETIME),103), " +
            "convert(varchar,dateAdd(day,6,CASE_REC_DATETIME),103),convert(varchar,dateAdd(day,7,CASE_REC_DATETIME),103), " +
            "convert(varchar,dateAdd(day,8,CASE_REC_DATETIME),103),convert(varchar,dateAdd(day,9,CASE_REC_DATETIME),103) " ;
           return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
       }
    #endregion

    #region CELL_Fewise_Report for Cellular
       public DataSet CELL_Fewise_Report(string sFromDate, string sToDate, string sClientId, string sCentreId)
    {
        string dtToDate;
        string sCaseCondition = "";
        if (CaseType != "0")
        {
            sCaseCondition = "AND CTM.CASE_TYPE_ID=" + CaseType + " ";
        }
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");
        string sSql = "";
        sSql = "SELECT count(cd.case_id) NOOFCASES,(isnull(EM.FIRSTNAME,' ')+' '+isnull(EM.Middlename,' ')+' '+isnull(EM.lastname,' '))" +
               "as FENAME , VM.VERIFICATION_TYPE_CODE as VERIFICATIONTYPE, cm.client_name as Client , " +
                  "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
                "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
                 " 'PAMAC Online' as COMPANYNAME " +
               "FROM CPV_CELLULAR_FE_CASE_MAPPING FE INNER JOIN CPV_CELLULAR_CASES CD ON FE.CASE_ID = CD.CASE_ID RIGHT OUTER JOIN CPV_CELLULAR_CASE_TYPE_MASTER CTM ON(CTM.CASE_TYPE_ID=CD.CASE_TYPE_ID)" +
               "INNER JOIN VERIFICATION_TYPE_MASTER VM ON FE.VERIFICATION_TYPE_ID = VM.VERIFICATION_TYPE_ID " +
               "INNER JOIN EMPLOYEE_MASTER EM ON FE.FE_ID = EM.EMP_ID  inner join client_master cm on(cm.client_id=cd.client_id) " +
               "WHERE CD.CLIENT_ID='" + sClientId + "' AND CD.CENTRE_ID='" + sCentreId + "' " + sCaseCondition + " " +
               "AND fe.date_time >='" + sFromDate + "' AND fe.date_time <'" + sToDate + "'" +
               "group by VM.VERIFICATION_TYPE_CODE,EM.FIRSTNAME,EM.Middlename,EM.lastname,cm.client_name " +
               "order by EM.FIRSTNAME";

        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion

    #region RLCoverLetter for RL
    public DataSet RLCoverLetter(string sFromDate, String sToDate, string sClientId, string sCentreId)
    {
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");
        string sqlRecords = "";
        //sqlRecords = "SELECT DISTINCT(CD.VERIFICATION_CODE) as VERIFICATIONCODE,CD.CASE_ID,CD.REF_NO as REFNO ,Convert(varchar(24),CD.CASE_REC_DATETIME,103)+ ' ' +  LTRIM(SUBSTRING(CONVERT( VARCHAR(20),CD.CASE_REC_DATETIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20), CD.CASE_REC_DATETIME, 22), 3))as CASERECDATETIME, ";
        //sqlRecords += "(ISNULL(FIRST_NAME,'') + ' ' + ISNULL(MIDDLE_NAME,'') + ' ' + ISNULL(LAST_NAME,'')) as NAME,Convert(varchar(24),SEND_DATETIME,103)+ ' ' + LTRIM(SUBSTRING(CONVERT( VARCHAR(20),CD.SEND_DATETIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20), CD.SEND_DATETIME, 22), 3)) as SENDDATETIME, ";
        //sqlRecords += "Channel_name as [Channel Name], case_type as [Case Type],  ";
        //sqlRecords += "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FromDate, ";
        //sqlRecords += "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as Todate, ";
        //sqlRecords += "'Pamac Online' as CompanyName ";
        //sqlRecords += " FROM CPV_RL_CASE_DETAILS CD INNER JOIN CPV_RL_CASE_VERIFICATIONTYPE VT ";
        //sqlRecords += " ON VT.CASE_ID=CD.CASE_ID INNER JOIN VERIFICATION_TYPE_MASTER VTM ";
        //sqlRecords += " ON VT.VERIFICATION_TYPE_ID=VTM.VERIFICATION_TYPE_ID ";
        //sqlRecords += " WHERE CD.SEND_DATETIME >= '" + sFromDate + "' AND CD.SEND_DATETIME < '" + sToDate + "' AND CD.SEND_DATETIME IS NOT NULL ";
        //sqlRecords += " AND CD.CLIENT_ID='" + sClientId + "' AND CD.CENTRE_ID='" + sCentreId + "' ";
        //sqlRecords += " ORDER BY CASERECDATETIME ,CD.CASE_ID,SENDDATETIME ";

        sqlRecords = "select  case_id as CASEID ,appname as APPLICANTNAME, ref_no as REFNO, VERIFICATION_TYPE_CODE as VERIFICATIONTYPECODE,Channel_Name as CHANNELNAME ,Case_Type as CASETYPE,convert(varchar(12),Case_Rec_DateTime,103) as CASERECDATETIME,convert(varchar(12),Send_DateTime,103) as SENDDATETIME, " +
                    "status_name as STATUSNAME,Unsatisfactory_Reason as UNSATISFACTORYREASON,Person_Contacted as PERSONCONTACTED, " + "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FromDate, " +
                    "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as Todate, " +
                    "'Pamac Online' as CompanyName from CPV_RL_CoveringLetter_View  " +
                    "WHERE Send_DateTime >= '" + sFromDate + "' AND Send_DateTime < '" + sToDate + "' AND Send_DateTime IS NOT NULL " +
                    "AND CLIENT_ID='" + sClientId + "' AND CENTRE_ID='" + sCentreId + "'  " +
                    "order by case_id,Case_Rec_DateTime,Send_DateTime ";
        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sqlRecords);
    }
    #endregion

    #region GetRLPendingReportList for RL
    public DataSet GetRLPendingReportList(string sFromDate, String sToDate, string sClientId, string sCentreId)
    {
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");
        string sSql = "";
        sSql = "SELECT distinct cd.SR_NO, cd.case_id,cd.REF_NO, cd.FIRST_NAME, cd.LAST_NAME, cd.MIDDLE_NAME," +
               " (ISNULL(cd.FIRST_NAME + ' ', '') +ISNULL(cd.MIDDLE_NAME + ' ', '') + ISNULL(cd.LAST_NAME + ' ', '')) AS Name," +
               " CONVERT(VARCHAR(24), cd.CASE_REC_DATETIME,103) As RECD_DATE , " +
               " (ISNULL(cd.RES_ADD_LINE_1+' ','') + ISNULL(cd.RES_ADD_LINE_2+' ','') + ISNULL(cd.RES_ADD_LINE_3+' ','') + ISNULL(cd.RES_CITY + ' ','')  + ISNULL(cd.RES_PIN_CODE + ' ','')) AS [Residence Address], " +
               " (ISNULL(cd.OFF_ADD_LINE_1+' ','') + ISNULL(cd.OFF_ADD_LINE_2+' ','') + ISNULL(cd.OFF_ADD_LINE_3+' ','')+ ISNULL(cd.OFF_CITY + ' ','')  + ISNULL(cd.OFF_PIN_CODE +' ',''))AS[Office Address], " +
               " cd.VERIFICATION_CODE as FV_REQUIRED,RES_CITY, " +
               "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
               "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
               "'PAMAC Online' as COMPANYNAME, " +
               " (select distinct top 1 fw.fullname from CPV_RL_CASE_VERIFICATIONTYPE CCV left outer join CPV_RL_CASE_FE_MAPPING CCFM on(CCV.case_id=CCFM.case_id and CCFM.verification_type_id=1) " +
			   " left outer join FE_VW FW on(CCFM.FE_ID=FW.emp_id) where CCV. case_id=cd.case_id) as [RV-FEName], "+
               "(select distinct top 1 fw.fullname from CPV_RL_CASE_VERIFICATIONTYPE CCV left outer join CPV_RL_CASE_FE_MAPPING CCFM on(CCV.case_id=CCFM.case_id and CCFM.verification_type_id=2) " +
			   " left outer join FE_VW FW on(CCFM.FE_ID=FW.emp_id) where CCV. case_id=cd.case_id) as [BV-FEName], "+
               "(select distinct top 1 fw.fullname from CPV_RL_CASE_VERIFICATIONTYPE CCV left outer join CPV_RL_CASE_FE_MAPPING CCFM on(CCV.case_id=CCFM.case_id and CCFM.verification_type_id=10) " +
               " left outer join FE_VW FW on(CCFM.FE_ID=FW.emp_id) where CCV. case_id=cd.case_id) as [PRV-FEName], " +
               "(select distinct top 1 fw.fullname from CPV_RL_CASE_VERIFICATIONTYPE CCV left outer join CPV_RL_CASE_FE_MAPPING CCFM on(CCV.case_id=CCFM.case_id and CCFM.verification_type_id=14) " +
               " left outer join FE_VW FW on(CCFM.FE_ID=FW.emp_id) where CCV. case_id=cd.case_id) as [RCO-FEName] " +
               " FROM  CPV_RL_CASE_DETAILS cd  inner join CPV_RL_CASE_VERIFICATIONTYPE vt on(cd.CASE_ID=vt.CASE_ID) "+
               "inner join VERIFICATION_TYPE_MASTER vtm on(vt.verification_type_id=vtm.verification_type_id) "+
               " WHERE (SEND_DATETIME IS NULL) " +
               " AND CASE_REC_DATETIME >= '" + sFromDate + "'" +
               " AND CASE_REC_DATETIME < '" + sToDate + "'" +
               " AND CLIENT_ID='" + sClientId + "'" +
               " AND CD.CENTRE_ID='" + sCentreId + "'";

        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion


    #region RL_FeReport form RL
    public DataSet RL_FeReport(string sFromDate, string sToDate, string sClientId, string sCentreId)
    {
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");
        string sSql = "";
        sSql = "SELECT count(cd.case_id) NOOFCASES,(isnull(EM.FIRSTNAME,' ')+' '+isnull(EM.Middlename,' ')+' '+isnull(EM.lastname,' '))" +
              "as FENAME , VM.verification_type_code as VERIFICATIONTYPE , " +
                 "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
               "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
                " 'PAMAC Online' as COMPANYNAME " +
              "FROM CPV_RL_CASE_FE_MAPPING FE INNER JOIN CPV_RL_CASE_DETAILS CD ON FE.CASE_ID = CD.CASE_ID " +
              "INNER JOIN VERIFICATION_TYPE_MASTER VM ON FE.VERIFICATION_TYPE_ID = VM.VERIFICATION_TYPE_ID " +
              "INNER JOIN EMPLOYEE_MASTER EM ON FE.FE_ID = EM.EMP_ID " +
              "WHERE CD.CLIENT_ID='" + sClientId + "' AND CD.CENTRE_ID='" + sCentreId + "'" +
              "AND fe.ASSIGN_DATETIME >='" + sFromDate + "' AND fe.ASSIGN_DATETIME <'" + sToDate + "'" +
              "group by VM.verification_type_code,EM.FIRSTNAME,EM.Middlename,EM.lastname " +
              "order by EM.FIRSTNAME";
        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion

    #region RLBifurcationOfCases for RL
    public DataSet RLBifurcationOfCases(string sFromDate, String sToDate, string sClientId, string sCentreId)
    {
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");

        DataSet ds = new DataSet();
        OleDbConnection con = new OleDbConnection(objCmn.ConnectionString);
        con.Open();       

        string str = "SELECT " +
                     "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
                     "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
                     "'PAMAC Online' as [COMPANYNAME], " +
                     " CONVERT(VARCHAR,CASE_REC_DATETIME,103) as [RECD DATE]," +
                     " CONVERT(VARCHAR,DATEADD(DAY,1,CASE_REC_DATETIME),103) AS DATE1, " +
                     " CONVERT(VARCHAR,DATEADD(DAY,2,CASE_REC_DATETIME),103) AS DATE2, " +
                     " CONVERT(VARCHAR,DATEADD(DAY,3,CASE_REC_DATETIME),103) AS DATE3, " +
                     " CONVERT(VARCHAR,DATEADD(DAY,4,CASE_REC_DATETIME),103) AS DATE4, " +
                     " CONVERT(VARCHAR,DATEADD(DAY,5,CASE_REC_DATETIME),103) AS DATE5, " +
                     " CONVERT(VARCHAR,DATEADD(DAY,6,CASE_REC_DATETIME),103) AS DATE6, " +
                     " CONVERT(VARCHAR,DATEADD(DAY,7,CASE_REC_DATETIME),103) AS DATE7, " +
                     " CONVERT(VARCHAR,DATEADD(DAY,8,CASE_REC_DATETIME),103) AS DATE8, " +
                     " CONVERT(VARCHAR,DATEADD(DAY,9,CASE_REC_DATETIME),103) AS DATE9, " +
                     " count(case_id) as [RECD CASES],SUM(Day0)as day0, SUM(Day1)as day1,SUM(Day2)as day2," +
                     " SUM(Day3)as day3,SUM(Day4)as day4,SUM(Day5)as day5,  SUM(Day6)as day6,SUM(Day7)as day7, " +
                     " SUM(Day8)as day8,SUM(Day9)as day9,SUM(After9Day) as after9day,SUM(PENDING)as pending " +
                     " FROM " +
                     " (SELECT CASE_REC_DATETIME,SEND_DATETIME,CASE_ID, " +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME))= 0 THEN 1 ELSE 0  END as 'Day0', " +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME))= 1 THEN 1 ELSE 0  END as 'Day1', " +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 2 THEN 1 ELSE 0 END as 'Day2', " +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME))= 3 THEN 1 ELSE 0  END as 'Day3', " +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 4 THEN 1 ELSE 0 END as 'Day4', " +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 5 THEN 1 ELSE 0 END as 'Day5', " +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 6 THEN 1 ELSE 0 END as 'Day6', " +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 7 THEN 1 ELSE 0 END as 'Day7', " +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 8 THEN 1 ELSE 0 END as 'Day8', " +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 9 THEN 1 ELSE 0 END as 'Day9', " +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) > 9 THEN 1 ELSE 0 END as 'After9Day', " +
                     " CASE SEND_DATETIME WHEN ISNULL(SEND_DATETIME, '') THEN 0 ELSE 1 END AS 'PENDING' " +
                     " FROM CPV_RL_CASE_DETAILS " +
                     " WHERE CASE_REC_DATETIME >= '" + sFromDate + "' AND  CASE_REC_DATETIME <'" + sToDate + "'" +
                     " AND Client_Id='" + sClientId + "'and centre_id='" + sCentreId + "') AS EXP1 " +
                     " GROUP BY " +
                     " CONVERT(VARCHAR,CASE_REC_DATETIME,103)," +
                     " CONVERT(VARCHAR,DATEADD(DAY,1,CASE_REC_DATETIME),103)," +
                     " CONVERT(VARCHAR,DATEADD(DAY,2,CASE_REC_DATETIME),103)," +
                     " CONVERT(VARCHAR,DATEADD(DAY,3,CASE_REC_DATETIME),103)," +
                     " CONVERT(VARCHAR,DATEADD(DAY,4,CASE_REC_DATETIME),103)," +
                     " CONVERT(VARCHAR,DATEADD(DAY,5,CASE_REC_DATETIME),103)," +
                     " CONVERT(VARCHAR,DATEADD(DAY,6,CASE_REC_DATETIME),103)," +
                     " CONVERT(VARCHAR,DATEADD(DAY,7,CASE_REC_DATETIME),103)," +
                     " CONVERT(VARCHAR,DATEADD(DAY,8,CASE_REC_DATETIME),103)," +
                     " CONVERT(VARCHAR,DATEADD(DAY,9,CASE_REC_DATETIME),103) ";
        
        ds = OleDbHelper.ExecuteDataset(con, CommandType.Text, str);
        return ds;
    }
    #endregion

    #region GetEBCPendingReport

    public DataSet GetEBCPendingReportList_New(string sFromDate, String sToDate, string sClientId, string sCentreId)
    {
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");

        string sSql = "SELECT distinct (vtm. VERIFICATION_type) As [Verification Type],cd.ref_no as[Ref no],cm.client_name as[Client name], cd.Case_ID as [Case ID], (isNull(cd.FIRST_NAME,'')+' '+isnull(cd.MIDDLE_NAME,'')+' '+isnull(cd.LAST_NAME,'')) as [Name]," +
                      "CONVERT(Varchar(24), cd.CASE_REC_DATETIME, 106) As  [Recieved on] , " +
                      "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
                      "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
                      "'PAMAC Online' as COMPANYNAME,fev.FULLNAME AS [FE Name]  FROM client_master cm inner join  CPV_EBC_CASE_DETAILS cd on(cd.client_id=cm.client_id) inner join CPV_EBC_VAERIFICATION_TYPE vt on(cd.case_id=vt.case_id) inner join VERIFICATION_TYPE_MASTER vtm on(vt.verification_type_id=vtm.verification_type_id) left outer join CPV_EBC_FE_MAPPING fem on(fem.VERIFICATION_TYPE_ID=vtm.verification_type_id and fem.case_id=vt.case_id) left outer join FE_VW fev on(fev.EMP_ID=fem.FE_ID) WHERE (cd.SEND_DATETIME IS NULL)" +
                      "AND cd.CASE_REC_DATETIME >= '" + sFromDate + "' AND cd.CASE_REC_DATETIME < '" + sToDate + "' AND cd.CLIENT_ID='" + sClientId + "' " +
                      "AND CD.CENTRE_ID='" + sCentreId + "'";
        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }

    public DataSet GetEBCPendingReportList(string sFromDate, String sToDate, string sClientId, string sCentreId)
    {
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");

        string sSql = "SELECT (vtm. VERIFICATION_type) As [Verification Type],cd.ref_no as[Ref no],cm.client_name as[Client name], cd.Case_ID as [Case ID], (isNull(cd.FIRST_NAME,'')+' '+isnull(cd.MIDDLE_NAME,'')+' '+isnull(cd.LAST_NAME,'')) as [Name]," +
                      "CONVERT(Varchar(24), cd.CASE_REC_DATETIME, 106) As  [Recieved on] , " +
                      "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
                      "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
                      "'PAMAC Online' as COMPANYNAME,fev.FULLNAME AS [FE Name]  FROM client_master cm inner join  CPV_EBC_CASE_DETAILS cd on(cd.client_id=cm.client_id) inner join CPV_EBC_VAERIFICATION_TYPE vt on(cd.case_id=vt.case_id) inner join VERIFICATION_TYPE_MASTER vtm on(vt.verification_type_id=vtm.verification_type_id) left outer join CPV_EBC_FE_MAPPING fem on(fem.VERIFICATION_TYPE_ID=vtm.verification_type_id and fem.case_id=vt.case_id) left outer join FE_VW fev on(fev.EMP_ID=fem.FE_ID) WHERE (cd.SEND_DATETIME IS NULL)" +
                      "AND cd.CASE_REC_DATETIME >= '" + sFromDate + "' AND cd.CASE_REC_DATETIME < '" + sToDate + "' AND cd.CLIENT_ID='" + sClientId + "' " +
                      "AND CD.CENTRE_ID='" + sCentreId + "'";
        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetEBCPendingRepo
    #region GetEBCFESearch
    public DataSet GetEBCFESearch(string sFromDate, string sToDate, string sClientId, string sCentreId)
    {
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");
        string sSql = "";
        sSql = "SELECT count(cd.case_id) NOOFCASES,(isnull(EM.FIRSTNAME,' ')+' '+isnull(EM.Middlename,' ')+' '+isnull(EM.lastname,' '))" +
              "as FENAME , VM.VERIFICATION_TYPE as VERIFICATIONTYPE, cm.client_name as Client , " +
                 "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
               "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
                " 'PAMAC Online' as COMPANYNAME " +
              "FROM CPV_EBC_FE_MAPPING FE INNER JOIN CPV_EBC_CASE_DETAILS CD ON FE.CASE_ID = CD.CASE_ID " +
              "INNER JOIN VERIFICATION_TYPE_MASTER VM ON FE.VERIFICATION_TYPE_ID = VM.VERIFICATION_TYPE_ID " +
              "INNER JOIN EMPLOYEE_MASTER EM ON FE.FE_ID = EM.EMP_ID  inner join client_master cm on(cm.client_id=cd.client_id) " +
              "WHERE CD.CLIENT_ID='" + sClientId + "' AND CD.CENTRE_ID='" + sCentreId + "'" +
              "AND fe.date_time >='" + sFromDate + "' AND fe.date_time <'" + sToDate + "'" +
              "group by VM.verification_type,EM.FIRSTNAME,EM.Middlename,EM.lastname,cm.client_name " +
              "order by EM.FIRSTNAME";
        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion GetEBCFESearch

    #region GetEBCClaimMISReport form EBC
    public DataSet GetEBCClaimMISReport(string sFromDate, String sToDate, string sClientId, string sCentreId)
    {
        string sSql = "";

        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");
        sSql = "select distinct Convert(varchar(24),cd.CASE_REC_DATETIME,103)as [Received Date], cd.CASE_ID as [CASE ID],cd.REF_NO as BANK_REF_NO," +
                "(isNull(cd.FIRST_NAME,'')+' '+isnull(cd.MIDDLE_NAME,'')+' '+isnull(cd.LAST_NAME,'')) as [Applicant Name]," +
                "Convert(varchar(24),cd.SEND_DATETIME,103)as [Send Date],vtm.VERIFICATION_TYPE_CODE as [VARIFICATION TYPE CODE],vtm.VERIFICATION_TYPE as [VARIFICATION TYPE]," +
                "csm.status_name as [STATUS NAME], " +
                "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FromDate, " +
                "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as Todate, " +
                "'Pamac Online' as CompanyName,cm.CLIENT_NAME as CLIENTNAME  " +
                " From CPV_EBC_CASE_DETAILS as cd  " +
                " inner join CPV_EBC_VAERIFICATION_TYPE as cvt on cd.CASE_ID=cvt.CASE_ID inner join VERIFICATION_TYPE_MASTER as vtm  " +
                " on cvt.VERIFICATION_TYPE_ID=vtm.VERIFICATION_TYPE_ID inner join CPV_EBC_VERIFICATION as civ on civ.case_id=cd.case_id  " +
                " inner join CASE_STATUS_MASTER as csm on civ.case_status_id=csm.case_status_id inner join CLIENT_MASTER as cm on cd.CLIENT_ID=cm.CLIENT_ID  " +
                " where cd.SEND_DATETIME >= " +
                "'" + sFromDate + "'" +
                " and cd.SEND_DATETIME < " +
                "'" + sToDate + "'" +
                " AND cd.CLIENT_ID='" + sClientId + "'" +
                " AND cd.CENTRE_ID='" + sCentreId + "'";


        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion

    # region GetEBCBifurcationOfCases() for EBC
    public DataSet GetEBCBifurcationOfCases(string sFromDate, String sToDate, string sClientId, string sCentreId)
    {
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");

        DataSet ds = new DataSet();
        OleDbConnection con = new OleDbConnection(objCmn.ConnectionString);
        con.Open();

        string str = "SELECT " +
                     "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
                     "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
                     "'PAMAC Online' as [COMPANYNAME],CONVERT(VARCHAR,CASE_REC_DATETIME,103) as [RECDATE], " +
                     " convert(varchar,CASE_REC_DATETIME,103) as [RECD DATE],count(case_id) as [RECD CASES],SUM(Day0)as day0," +
                     " SUM(Day1)as day1,SUM(Day2)as day2,SUM(Day3)as day3,SUM(Day4)as day4,SUM(Day5)as day5, " +
                     " SUM(Day6)as day6,SUM(Day7)as day7,SUM(Day8)as day8,SUM(Day9)as day9," +
                     " SUM(After9Day) as after9day,SUM(PENDING)as pending , " +
                     "convert(varchar,dateAdd(day,1,CASE_REC_DATETIME),103) as date1, " +
                     "convert(varchar,dateAdd(day,2,CASE_REC_DATETIME),103) as date2, " +
                     "convert(varchar,dateAdd(day,3,CASE_REC_DATETIME),103) as date3, " +
                     "convert(varchar,dateAdd(day,4,CASE_REC_DATETIME),103) as date4, " +
                     "convert(varchar,dateAdd(day,5,CASE_REC_DATETIME),103) as date5, " +
                     "convert(varchar,dateAdd(day,6,CASE_REC_DATETIME),103) as date6, " +
                     "convert(varchar,dateAdd(day,7,CASE_REC_DATETIME),103) as date7, " +
                     "convert(varchar,dateAdd(day,8,CASE_REC_DATETIME),103) as date8, " +
                     "convert(varchar,dateAdd(day,9,CASE_REC_DATETIME),103) as date9 " +
                     " FROM (SELECT CASE_REC_DATETIME,SEND_DATETIME,CASE_ID, " +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME))= 0 THEN 1 ELSE 0  END as 'Day0', " +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME))= 1 THEN 1 ELSE 0  END as 'Day1', " +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 2 THEN 1 ELSE 0  END as 'Day2'," +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME))= 3 THEN 1 ELSE 0  END as 'Day3'," +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 4 THEN 1 ELSE 0  END as 'Day4'," +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 5 THEN 1 ELSE 0  END as 'Day5'," +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 6 THEN 1 ELSE 0  END as 'Day6'," +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 7 THEN 1 ELSE 0  END as 'Day7'," +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 8 THEN 1 ELSE 0  END as 'Day8'," +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) = 9 THEN 1 ELSE 0  END as 'Day9'," +
                     " CASE WHEN (datediff(day,CASE_REC_DATETIME,SEND_DATETIME)) > 9 THEN 1 ELSE 0  END as 'After9Day', " +
                     " CASE SEND_DATETIME WHEN ISNULL(SEND_DATETIME, '') THEN 0 ELSE 1 END AS 'PENDING' " +
                     " FROM CPV_EBC_CASE_DETAILS " +
                     " WHERE CASE_REC_DATETIME >= '" + sFromDate + "' AND  CASE_REC_DATETIME <'" + sToDate + "'" +
                     " AND Client_Id='" + sClientId + "'and centre_id='" + sCentreId + "') AS EXP1 " +
                     " GROUP BY convert(varchar,CASE_REC_DATETIME,103)  ,convert(varchar,dateAdd(day,1,CASE_REC_DATETIME),103), " +
                     "convert(varchar,dateAdd(day,2,CASE_REC_DATETIME),103),convert(varchar,dateAdd(day,3,CASE_REC_DATETIME),103), " +
                     "convert(varchar,dateAdd(day,4,CASE_REC_DATETIME),103),convert(varchar,dateAdd(day,5,CASE_REC_DATETIME),103), " +
                     "convert(varchar,dateAdd(day,6,CASE_REC_DATETIME),103),convert(varchar,dateAdd(day,7,CASE_REC_DATETIME),103), " +
                     "convert(varchar,dateAdd(day,8,CASE_REC_DATETIME),103),convert(varchar,dateAdd(day,9,CASE_REC_DATETIME),103) ";

        ds = OleDbHelper.ExecuteDataset(con, CommandType.Text, str);
        return ds;
    }
    #endregion GetBifurcationOfCases()



    #region Cell_GetVerifierMIS for Cellular

    public DataSet Cell_GetVerifierMIS(string sCentreId,string sFromDate,string sToDate,string caseType,string feID)
    {
        string sSql = "";
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");
        sSql = "SELECT FULLNAME AS [Name of Verifiers], " +
               "SUM(CAST(WV AS INTEGER)) AS WV, " +
               "SUM(CAST(HFP AS INTEGER)) AS HFP, " +
               "(SUM(CAST(WV AS INTEGER))+SUM(CAST(HFP AS INTEGER))) AS [No of cases Done], " +
               "SUM(CAST(SEC_CODE AS INTEGER)) AS [Total SEC Codes Obtained],  " +
               "(SUM(CAST(SEC_CODE AS DECIMAL(9,2)))* 100 /(SUM(CAST(WV AS DECIMAL(9,2)))+SUM(CAST(HFP AS DECIMAL(9,2))))) AS [%age SEC Codes Obtained] , " +

               "SUM(CAST(DOC_SIGHTED AS INTEGER)) AS [Documents sighted], " +
               "(SUM(CAST(DOC_SIGHTED AS DECIMAL(9,2)))* 100 /(SUM(CAST(WV AS DECIMAL(9,2)))+SUM(CAST(HFP AS DECIMAL(9,2))))) AS [%age Documents sighted], " +

               "SUM(CAST(APP_MET AS INTEGER)) AS [Subscriber met], " +
               "(SUM(CAST(APP_MET AS DECIMAL(9,2)))* 100 /(SUM(CAST(WV AS DECIMAL(9,2)))+SUM(CAST(HFP AS DECIMAL(9,2))))) AS [%age Subscriber met],  " +

               "SUM(CAST(APP_NOT_MET AS INTEGER)) AS [Subscriber not met], " +
               "(SUM(CAST(APP_NOT_MET AS DECIMAL(9,2)))* 100 /(SUM(CAST(WV AS DECIMAL(9,2)))+SUM(CAST(HFP AS DECIMAL(9,2))))) AS [%age Subscriber not met], " +

               "SUM(CAST(NM AS INTEGER)) AS [NM], " +
               "(SUM(CAST(NM AS DECIMAL(9,2)))* 100 /(SUM(CAST(WV AS DECIMAL(9,2)))+SUM(CAST(HFP AS DECIMAL(9,2))))) AS [%age NM], " +

               "SUM(CAST(TARIF_PLAN AS INTEGER)) AS [TARIF PLAN], " +
               "(SUM(CAST(TARIF_PLAN AS DECIMAL(9,2))) * 100 /(SUM(CAST(WV AS DECIMAL(9,2)))+SUM(CAST(HFP AS DECIMAL(9,2))))) AS [%age TARIFPLAN], " +

               "SUM(CAST(FIRST_Bill_EXP AS INTEGER)) AS [Bill Explaination], " +
               "(SUM(CAST(FIRST_Bill_EXP AS DECIMAL(9,2)))* 100 /(SUM(CAST(WV AS DECIMAL(9,2)))+SUM(CAST(HFP AS DECIMAL(9,2))))) AS [%age Bill Explaination], " +

               "SUM(CAST(DDB AS INTEGER)) AS [DDB], " +
               "(SUM(CAST(DDB AS DECIMAL(9,2)))* 100 /(SUM(CAST(WV AS DECIMAL(9,2)))+SUM(CAST(HFP AS DECIMAL(9,2))))) AS [%age Bill DDB],  " +


               "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
               "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
               "'PAMAC Online' as COMPANYNAME,  " +

               "(SELECT COUNT(FE_WISE_MIS.FE_ID) FROM FE_WISE_MIS AS IN_FE_WISE_MIS WHERE IN_FE_WISE_MIS.FE_ID=FE_WISE_MIS.FE_ID GROUP BY IN_FE_WISE_MIS.FE_ID)AS TotalCase " +

               "FROM FE_WISE_MIS " +
               "WHERE CENTRE_ID='" + sCentreId + "'  "; 
              


            if (((sFromDate != "") && (sFromDate != null)) && ((sToDate != "") && (sToDate != null)))
            {
                sSql += " AND CASE_REC_DATETIME>= '" + sFromDate + "'  " +
                        " AND CASE_REC_DATETIME < '" + sToDate + "'  ";
            }
            if ((caseType != "") && (caseType != null))
            {
                if (caseType == "0")
                {
                    sSql += " AND CASE_TYPE_ID IN (1,3) ";
                }
                if (caseType == "1")
                {
                    sSql += " AND CASE_TYPE_ID IN (1) ";
                }
                if (caseType == "3")
                {
                    sSql += " AND CASE_TYPE_ID IN (3) ";
                }
            }
            if ((feID != "") && (feID != null))
            {
                if (feID!="0")
                {
                    sSql += " AND FE_ID='" + feID + "' ";
                }
            }
            sSql += " GROUP BY FULLNAME,FE_WISE_MIS.FE_ID ";

                        

        
             
        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }
    #endregion


     #region Cell_GetClaimMISBilling for Cellular

    public DataSet Cell_GetClaimMISBilling(string sFromDate, string sToDate, string sClientId, string sCentreId)
    {
        string sSql = "";
        string dtToDate;
        dtToDate = Convert.ToDateTime(sToDate).AddDays(-1.0).ToString("dd-MMM-yyyy");

        sSql = "select 'IP' as CaseType,ISNULL(SUM(CAST(TotalCount AS INTEGER)),0) as TotalCount,ISNULL(SUM(CAST(APP_MET AS INTEGER)),0) as APP_MET, " +
                "ISNULL(SUM(CAST(APP_NOT_MET AS INTEGER)),0) as APP_NOT_MET, " +
                "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
                "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
                "'PAMAC Online' as COMPANYNAME  " +
                "from Cellular_ClaimMIS_View where ID='IP' " +
                "AND  CASE_REC_DATETIME>='" + sFromDate + "'  " +
                "AND CASE_REC_DATETIME < '" + sToDate + "'  " +
                "AND Centre_ID='" + sCentreId + "'  " +
                "AND Client_ID='" + sClientId + "'  " +
                "union all  " +
                "select 'WV' as CaseType,ISNULL(SUM(CAST(TotalCount AS INTEGER)),0) as TotalCount,ISNULL(SUM(CAST(APP_MET AS INTEGER)),0) as APP_MET, " +
                "ISNULL(SUM(CAST(APP_NOT_MET AS INTEGER)),0) as APP_NOT_MET,  " +
                "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
                "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
                "'PAMAC Online' as COMPANYNAME  " +
                "from Cellular_ClaimMIS_View where ID='WV' " +
                "AND  CASE_REC_DATETIME>='" + sFromDate + "'  " +
                "AND CASE_REC_DATETIME < '" + sToDate + "'  " +
                "AND Centre_ID='" + sCentreId + "'  " +
                "AND Client_ID='" + sClientId + "'  " +
                "union all  " +
                "select 'HFP' as CaseType, ISNULL(SUM(CAST(TotalCount AS INTEGER)),0) as TotalCount,ISNULL(SUM(CAST(APP_MET AS INTEGER)),0) as APP_MET, " +
                "ISNULL(SUM(CAST(APP_NOT_MET AS INTEGER)),0) as APP_NOT_MET,  " +
                "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
                "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
                "'PAMAC Online' as COMPANYNAME  " +
                "from Cellular_ClaimMIS_View where ID='HFP' " +
                "AND  CASE_REC_DATETIME>='" + sFromDate + "'  " +
                "AND CASE_REC_DATETIME < '" + sToDate + "'  " +
                "AND Centre_ID='" + sCentreId + "'  " +
                "AND Client_ID='" + sClientId + "'  " +
                "union all " +
                "select 'RP' as CaseType,ISNULL(SUM(CAST(TotalCount AS INTEGER)),0) as TotalCount,ISNULL(SUM(CAST(APP_MET AS INTEGER)),0) as APP_MET, " +
                "ISNULL(SUM(CAST(APP_NOT_MET AS INTEGER)),0) as APP_NOT_MET, " +
                "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
                "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
                "'PAMAC Online' as COMPANYNAME  " +
                "from Cellular_ClaimMIS_View where ID='RP' " +
                "AND  CASE_REC_DATETIME>='" + sFromDate + "'  " +
                "AND CASE_REC_DATETIME < '" + sToDate + "'  " +
                "AND Centre_ID='" + sCentreId + "'  " +
                "AND Client_ID='" + sClientId + "'  " +
                "union all " +
                "select 'FT' as CaseType,ISNULL(SUM(CAST(TotalCount AS INTEGER)),0) as TotalCount,ISNULL(SUM(CAST(APP_MET AS INTEGER)),0) as APP_MET, " +
                "ISNULL(SUM(CAST(APP_NOT_MET AS INTEGER)),0) as APP_NOT_MET, " +
                "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
                "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
                "'PAMAC Online' as COMPANYNAME  " +
                "from Cellular_ClaimMIS_View where ID='FT' " +
                "AND  CASE_REC_DATETIME>='" + sFromDate + "'  " +
                "AND CASE_REC_DATETIME < '" + sToDate + "'  " +
                "AND Centre_ID='" + sCentreId + "'  " +
                "AND Client_ID='" + sClientId + "'  " +
                "union all " +
                "select 'UC' as CaseType,ISNULL(SUM(CAST(TotalCount AS INTEGER)),0) as TotalCount,ISNULL(SUM(CAST(APP_MET AS INTEGER)),0) as APP_MET, " +
                "ISNULL(SUM(CAST(APP_NOT_MET AS INTEGER)),0) as APP_NOT_MET,   " +
                "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
                "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
                "'PAMAC Online' as COMPANYNAME  " +
                "from Cellular_ClaimMIS_View where ID='UC' " +
                "AND  CASE_REC_DATETIME>='" + sFromDate + "'  " +
                "AND CASE_REC_DATETIME < '" + sToDate + "'  " +
                "AND Centre_ID='" + sCentreId + "'  " +
                "AND Client_ID='" + sClientId + "'  " +
                "union all " +
                "select 'EMCOA' as CaseType,ISNULL(SUM(CAST(TotalCount AS INTEGER)),0) as TotalCount,ISNULL(SUM(CAST(APP_MET AS INTEGER)),0) as APP_MET, " +
                "ISNULL(SUM(CAST(APP_NOT_MET AS INTEGER)),0) as APP_NOT_MET,  " +
                "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
                "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
                "'PAMAC Online' as COMPANYNAME  " +
                "from Cellular_ClaimMIS_View where ID='EMCOA' " +
                "AND  CASE_REC_DATETIME>='" + sFromDate + "'  " +
                "AND CASE_REC_DATETIME < '" + sToDate + "'  " +
                "AND Centre_ID='" + sCentreId + "'  " +
                "AND Client_ID='" + sClientId + "'  " +
                "union all " +
                "select 'RV' as CaseType,ISNULL(SUM(CAST(TotalCount AS INTEGER)),0) as TotalCount,ISNULL(SUM(CAST(APP_MET AS INTEGER)),0) as APP_MET, " +
                "ISNULL(SUM(CAST(APP_NOT_MET AS INTEGER)),0) as APP_NOT_MET, " +
                "'" + Convert.ToDateTime(sFromDate).ToString("dd/MM/yyyy") + "' as FROMDATE, " +
                "'" + Convert.ToDateTime(dtToDate).ToString("dd/MM/yyyy") + "' as TODATE, " +
                "'PAMAC Online' as COMPANYNAME  " +
                "from Cellular_ClaimMIS_View where ID='RV' " +
                "AND  CASE_REC_DATETIME>='" + sFromDate + "'  " +
                "AND CASE_REC_DATETIME < '" + sToDate + "'  " +
                "AND Centre_ID='" + sCentreId + "'  " +
                "AND Client_ID='" + sClientId + "'  "; 

        return OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
    }
     #endregion


    public DataTable GetShriramHF_RV(string p)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = p;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_ShriramHF_RL_RV_PDFExport", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
        // Nikhil Lad
    }

    public DataTable GetShriramHF_BVself(string p)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = p;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "GetShriramHF_RL_BVself", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
        // Nikhil Lad
    }

    public DataTable GetShriramHF_BVsal(string p)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = p;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "GetShriramHF_RL_BVsal", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
        // Nikhil Lad
    }
    public DataTable GetBussVeriDtl_AdityaBirlaFinBV(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_AdityaBirlaFinance_RL_BV", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    public DataTable GetResiVeriDtl_AdityaBirlaFinRV(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_AdityaBirlaFinance_RL_RV", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    //--Added by Manoj for Ratanakar bank
    public DataTable GetRatanakarRV(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "GetResRatanakarbank", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetRatanakarBV(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_BusRatanakarBank", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetRatanakarRTBT(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_RTBTRatanakarbanks", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    //Ended by MAnoj

    public DataTable GetDeutscheRtlRV(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_DeutscheRtlRV", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetDeutscheRtlRTBT(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_DeutscheRtlTV", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetDeutscheRtlBV(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_DeutscheRtlBV", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    public DataTable GetFuturebank_RV(string p)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = p;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_ResidenceFutureBank", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;

    }

    public DataTable GetGetFuturebank_BVself(string p)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = p;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_SelfEmployeeFutureBank", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;

    }

    public DataTable GetFuturebank_BVsal(string p)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = p;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_salariedFutureBank", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;

    }
    public DataTable GetResiVeriDtl_PNB_RL(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_PNB_RL_RV", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetBusiVeriDtl_PNB_RL(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_PNB_RL_BV", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetShamrao_BVsal(string p)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = p;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_Shamrao_RL_BVsal", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
        // Nikhil Lad
    }

    public DataTable GetShamrao_BVself(string p)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = p;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_Shamrao_RL_BVself", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
        // Nikhil Lad
    }
    //Added by Manoj for...yes bank auto loan
    public DataTable GetYesbankautoloan_BVsal(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_yesbankautoloansal", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }



    public DataTable GetYesbankautoloan_BVself(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_yesbankautoloanself", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }


    public DataTable GetYesbankautoloan_RV(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_YesbankAutoLoanRV", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }



    public DataTable GetYesbankautoLoan_Tele(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_YesbankAutoLoanTV", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    //Ended by Manoj
    //Added by MAnoj
    public DataTable GetResiVeriDtl_CityBank(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "GetResCityBank", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    public DataTable GetBusVeriDtl_CityBank(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "GetBusCityBank", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    //Ended by Manoj
    //Add by MAnoj for oriented bank 
    public DataTable GetResiVeriDtl_OreintalRV(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_ResidenceOBCBank", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetBussVeriDtl_OreintalBV(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_ResOBCbank", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    //Ended by manoj
    //Added by MAnoj for... HDFC Ltd
    public DataTable GetHDFC_BVsal(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_HDFCsal", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }



    public DataTable GetHDFC_BVself(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_HDFCSelf", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }


    public DataTable GetHDFC_RV(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_HDFCRV", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    //Ended by Manoj
    public DataTable GetShamrao_RV(string p)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];
        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = p;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_Shamrao_RL_RV", buisi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
        // Nikhil Lad
    }

    public DataTable GetResiVeriDtl_Uforia_RV(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_UforiaHomeFinance_RL_RV", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetBussVeriDtl_Uforia_BV(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_UforiaHomeFinance_RL_BV", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetBusiVeriDubaiSamba(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_CC_DubaiSamba", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetBusiVeriDubaiADCB(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_CC_DubaiADCB", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetBusiVeriDubaiMB(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_CC_DubaiMB", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetBusiVeriDubaiSCB(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_CC_DubaiSCB", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    
    public DataTable GetBusiVeriCitiSal(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_CC_DubaiCITIsal", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetBusiVeriCitiBusi(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_CC_DubaiCITIbusi", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetBusiVeriDubaiENBD(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_CC_DubaiENBD", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    public DataTable GetResiVeriDtl_ReligareRV(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_ReligareFinvestRV", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    public DataTable GetBussVeriDtl_ReligareBV(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_ReligareFinvestBV", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    //Added by Manoj for Axis bank Change Address
    public DataTable GetBusiVeriDtlCCAxisbankchangeaddress(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];

        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_AxisbankchangeAddressBV", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    public DataTable GetResiVeriDtlCCAxisbankchangeaddress(string strWhere)
    {

        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];

        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_AxisbankchangeAddressRV", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetIngVysyaRV(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];

        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_IngVysyaRV", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetIngVysyaBV(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];

        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_IngVysyaBV", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetIngVysyaTV(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] buisi = new OleDbParameter[1];

        buisi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        buisi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_IngVysyaTV", buisi);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetResiVeriDtl_ShubhamHF_RV(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_ShubhamHF_RL_RV", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetBusiVeriDtlCCFirstgalfbankCC(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_FirstgulfbankRV", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }

    public DataTable GetBussVeriDtl_ShubhamHF_BV(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_ShubhamHF_RL_BV", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
    public DataTable Get_ShamraovitthalRVBV(string strWhere)
    {
        DataSet ds = new DataSet();
        string strSQL = "";
        OleDbParameter[] Resi = new OleDbParameter[1];
        Resi[0] = new OleDbParameter("@CaseID", OleDbType.VarChar, 15);
        Resi[0].Value = strWhere;

        ds = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.StoredProcedure, "Get_ShamraovittalBankRVBV", Resi);

        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        ds.Tables.Clear();
        ds.Clear();
        return dt;
    }
}

