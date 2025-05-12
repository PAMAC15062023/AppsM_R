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
/// Summary description for CCreditCardGenerateLabel
/// </summary>
public class CCreditCardGenerateLabel
{
    CCommon oCom = new CCommon();
    private string strActivity_ID;
    private string strProduct_ID;
    private string strVerification_Type_ID;
    private string strClient_ID;
    private string strfromdate;
    private string strtodate;
    private string strverification_Type;
    private string strcentre_id;
    private string strEMP_ID;



    public string Centre_Id
    {
        get { return strcentre_id; }
        set { strcentre_id = value; }
    }
    public string Fromdate
    {
        get { return strfromdate; }
        set { strfromdate = value; }
    }

    public string Todate
    {
        get { return strtodate; }
        set { strtodate = value; }
    }

    public string Verification_Type
    {
        get { return strverification_Type; }
        set { strverification_Type = value; }
    }

    public string Activity_ID
    {
        get { return strActivity_ID; }
        set { strActivity_ID = value; }
    }

    public string Product_ID
    {
        get { return strProduct_ID; }
        set { strProduct_ID = value; }
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
    public string Emp_ID
    {
        get { return strEMP_ID; }
        set { strEMP_ID = value; }
    }
    public CCreditCardGenerateLabel()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    //Added by Manoj Jadhav
    public DataSet getTemplate1()
    {
        string P = "0";
        if (strEMP_ID == P)
        {
            strEMP_ID = "select EMP_ID from  FE_VW ";
            DataSet ds = new DataSet();
            ds = OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strEMP_ID);
            DataTable td = ds.Tables[0];
            strEMP_ID = "";
            for (int i = 0; i < td.Rows.Count; i++)
            {
                if (i != td.Rows.Count)
                {
                    strEMP_ID += td.Rows[i]["EMP_ID"].ToString() + ",";

                }
            }
            strEMP_ID = strEMP_ID.TrimEnd(',');

        }

        string strSQL = " SELECT Distinct VTM.VERIFICATION_TYPE_CODE, client_name As ADDITIONAL1, LPTM.ADDITIONAL2, LPTM.SR_NO,";
        strSQL = strSQL + " LPTM.LABEL_PRINTING_DATE, LPTM.ALL_VERIFICATION_TYPE,LPTD.TABLE_NAME, ";
        strSQL = strSQL + " LPTD.SELECTED_FIELD, LPTD.SERIAL_NO, LPTD.LINE_NO";
        strSQL = strSQL + " FROM LABEL_PRINTING_TEMPLATE_MASTER LPTM ";
        strSQL = strSQL + " INNER JOIN LABEL_PRINTING_TEMPLATE_DETAILS LPTD ";
        strSQL = strSQL + " ON (LPTM.LABEL_TEMPLATE_ID=LPTD.LABEL_TEMPLATE_ID)";
        strSQL = strSQL + " INNER JOIN VERIFICATION_TYPE_MASTER VTM";
        strSQL = strSQL + " ON (LPTM.VERIFICATION_TYPE_ID=VTM.VERIFICATION_TYPE_ID)";
        strSQL = strSQL + " INNER JOIN client_master CLM on LPTM.client_id=CLM.client_id ";
        //strSQL = strSQL + " WHERE LPTM.ACTIVITY_ID='" + strActivity_ID + "'";
        strSQL = strSQL + " WHERE LPTM.PRODUCT_ID in('" + strProduct_ID + "')";
        strSQL = strSQL + " AND LPTM.VERIFICATION_TYPE_ID='" + strVerification_Type_ID + "' and LpTM.Centre_ID='" + strcentre_id + "' and LPTM.Template_For='L'";
        strSQL = strSQL + " ORDER BY client_name,LPTD.SERIAL_NO,LPTM.ALL_VERIFICATION_TYPE ";
        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);

    }
    //ended by Manoj

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
        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);

    }

    public DataSet getLabel(string strSQL)
    {

        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);

    }
    //public DataSet getGridValue(string CentreId, string strClient_ID, string strProduct_ID)
    //{
    //    string strSQL = "";
    //    if (strProduct_ID == "1017")
    //    {
    //         strSQL = "SELECT SR_NO, ISNULL(FIRST_NAME, '') + '' + ISNULL(MIDDLE_NAME, '') + '' + ISNULL(LAST_NAME, '') AS APPLICANT_NAME " +
    //                         "FROM CPV_IDOC_CASE_DETAILS WHERE case_rec_datetime >= '" + strfromdate + "' AND case_rec_datetime <  '" + strtodate + "' " +
    //                         "AND [CENTRE_ID]='" + CentreId + "' AND [CLIENT_ID]='" + strClient_ID + "'";
    //        //return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);
    //    }
    //    if (strProduct_ID == "1014")
    //    {
    //         strSQL = "SELECT SR_NO, ISNULL(APP_FNAME, '') + '' + ISNULL(APP_MNAME, '') + '' + ISNULL(APP_LNAME, '') AS APPLICANT_NAME "+
    //                        "FROM CPV_CELLULAR_CASES WHERE case_rec_datetime >= '" + strfromdate + "' AND case_rec_datetime <  '" + strtodate + "' "+
    //                        "AND [CENTRE_ID]='" + CentreId + "' AND [CLIENT_ID]='" + strClient_ID + "'";              
    //        //return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);
    //    }
    //    if (strProduct_ID == "1011")
    //    {
    //        strSQL = "SELECT [SR_nO],[REF_NO],(ISNULL(FIRST_NAME,'')+''+ISNULL(MIDDLE_NAME,'')+''+ISNULL(LAST_NAME,'')) AS APPLICANT_NAME FROM CPV_CC_CASE_DETAILS";
    //        strSQL = strSQL + " WHERE case_rec_datetime >= '" + strfromdate + "' AND case_rec_datetime <  '" + strtodate + "' ";
    //        strSQL = strSQL + " AND [CENTRE_ID]='" + CentreId + "' AND [CLIENT_ID]='" + strClient_ID + "'";
    //        //return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);
    //    }
    //    return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);
    //}
    public DataSet getGridValue_IDOC(string CentreId, string strClient_ID)
    {
        string strSQL = "";
        strSQL = "SELECT SR_NO, ISNULL(FIRST_NAME, '') + '' + ISNULL(MIDDLE_NAME, '') + '' + ISNULL(LAST_NAME, '') AS APPLICANT_NAME " +
                            "FROM CPV_IDOC_CASE_DETAILS WHERE case_rec_datetime >= '" + strfromdate + "' AND case_rec_datetime <  '" + strtodate + "' " +
                            "AND [CENTRE_ID]='" + CentreId + "' AND [CLIENT_ID]='" + strClient_ID + "'";
        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);
    }
    public DataSet getGridValue_Cellular(string CentreId, string strClient_ID)
    {
        string strSQL = "";
        strSQL = "SELECT SR_NO, ISNULL(APP_FNAME, '') + '' + ISNULL(APP_MNAME, '') + '' + ISNULL(APP_LNAME, '') AS APPLICANT_NAME " +
                               "FROM CPV_CELLULAR_CASES WHERE case_rec_datetime >= '" + strfromdate + "' AND case_rec_datetime <  '" + strtodate + "' " +
                               "AND [CENTRE_ID]='" + CentreId + "' AND [CLIENT_ID]='" + strClient_ID + "'";
        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);
    }
    public DataSet getGridValue_Cellular_QC(string CentreId, string strClient_ID)
    {
        string strSQL = "";
        strSQL = "SELECT SR_NO, ISNULL(APP_FNAME, '') + '' + ISNULL(APP_MNAME, '') + '' + ISNULL(APP_LNAME, '') AS APPLICANT_NAME " +
                               "FROM CPV_QC_Case_Details qc_case left outer join CPV_CELLULAR_CASES cel_case on qc_case.case_id=cel_case.case_id where qc_case.case_received_date >= '" + strfromdate + "' AND qc_case.case_received_date <  '" + strtodate + "' " +
                               "AND qc_case.CENTRE_ID='" + CentreId + "' AND qc_case.CLIENT_ID='" + strClient_ID + "'";
        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);
    }
    public DataSet getGridValue_CC_Qc(string CentreId, string strClient_ID)
    {
        string strSQL = "";
        strSQL = "SELECT [SR_nO] as [Sr No],qc.REF_NO,(ISNULL(FIRST_NAME,'')+''+ISNULL(MIDDLE_NAME,'')+''+ISNULL(LAST_NAME,'')) AS APPLICANT_NAME FROM CPV_QC_CASE_DETAILS qc";
        strSQL = strSQL + " left outer join CPV_CC_CASE_DETAILS cc on qc.case_id=cc.case_id ";
        strSQL = strSQL + " WHERE case_received_date >= '" + strfromdate + "' AND case_received_date <  '" + strtodate + "' ";
        strSQL = strSQL + " AND qc.CENTRE_ID ='" + CentreId + "' AND qc.CLIENT_ID ='" + strClient_ID + "'";
        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);
    }
    public DataSet getGridValue_CC(string CentreId, string strClient_ID)
    {
        string strSQL = "";
        strSQL = "SELECT [SR_nO] as [Sr No],REF_NO,(ISNULL(FIRST_NAME,'')+''+ISNULL(MIDDLE_NAME,'')+''+ISNULL(LAST_NAME,'')) AS APPLICANT_NAME FROM CPV_CC_CASE_DETAILS";
        strSQL = strSQL + " WHERE case_rec_datetime >= '" + strfromdate + "' AND case_rec_datetime <  '" + strtodate + "' ";
        strSQL = strSQL + " AND [CENTRE_ID]='" + CentreId + "' AND [CLIENT_ID]='" + strClient_ID + "'";
        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);
    }
    //public DataSet getGridValue_EBC(string CentreId, string strClient_ID)
    //{
    //    string strSQL = "";
    //    strSQL = "SELECT SR_NO,[REF_NO],(ISNULL(FIRST_NAME,'')+''+ISNULL(MIDDLE_NAME,'')+''+ISNULL(LAST_NAME,'')) AS APPLICANT_NAME FROM CPV_EBC_CASE_DETAILS";
    //    strSQL = strSQL + " WHERE CONVERT(CHAR(9), CASE_REC_DATETIME, 3) + LTRIM(SUBSTRING(CONVERT( VARCHAR(20),CASE_REC_DATETIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20), CASE_REC_DATETIME, 22), 3)) >= '" + strfromdate + "' AND CONVERT(CHAR(9), CASE_REC_DATETIME, 3) + LTRIM(SUBSTRING(CONVERT( VARCHAR(20),CASE_REC_DATETIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20), CASE_REC_DATETIME, 22), 3)) <  '" + strtodate + "' ";
    //    strSQL = strSQL + " AND [CENTRE_ID]='" + CentreId + "' AND [CLIENT_ID]='" + strClient_ID + "'";
    //    return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);
    //}
    public DataSet getGridValue_EBC(string CentreId, string strClient_ID)
    {
        string strSQL = "";
        strSQL = "SELECT SR_NO,[REF_NO],(ISNULL(FIRST_NAME,'')+''+ISNULL(MIDDLE_NAME,'')+''+ISNULL(LAST_NAME,'')) AS APPLICANT_NAME FROM CPV_EBC_CASE_DETAILS";
        strSQL = strSQL + " WHERE CASE_REC_DATETIME >= '" + strfromdate + "' AND  CASE_REC_DATETIME <  '" + strtodate + "' ";
        strSQL = strSQL + " AND [CENTRE_ID]='" + CentreId + "' AND [CLIENT_ID]='" + strClient_ID + "'";
        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);
    }
    public DataSet getGridValue_RL(string CentreId, string strClient_ID)
    {
        string strSQL = "";
        strSQL = "SELECT [SR_nO],[REF_NO],(ISNULL(FIRST_NAME,'')+''+ISNULL(MIDDLE_NAME,'')+''+ISNULL(LAST_NAME,'')) AS APPLICANT_NAME FROM CPV_RL_CASE_DETAILS";
        strSQL = strSQL + " WHERE case_rec_datetime >= '" + strfromdate + "' AND case_rec_datetime <  '" + strtodate + "' ";
        strSQL = strSQL + " AND [CENTRE_ID]='" + CentreId + "' AND [CLIENT_ID]='" + strClient_ID + "'";
        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);
    }

    public DataSet getGridValue_RL_Qc(string CentreId, string strClient_ID)
    {
        string strSQL = "";
        strSQL = "SELECT [SR_nO],qc.REF_NO,(ISNULL(FIRST_NAME,'')+''+ISNULL(MIDDLE_NAME,'')+''+ISNULL(LAST_NAME,'')) AS APPLICANT_NAME FROM CPV_QC_CASE_DETAILS qc";
        strSQL = strSQL + " left outer join CPV_RL_CASE_DETAILS cc on qc.case_id=cc.case_id ";
        strSQL = strSQL + " WHERE case_received_date >= '" + strfromdate + "' AND case_received_date <  '" + strtodate + "' ";
        strSQL = strSQL + " AND qc.CENTRE_ID ='" + CentreId + "' AND qc.CLIENT_ID ='" + strClient_ID + "'";
        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);
    }

    //modify by hemangi kambli on 27/06/2007---------------
    public DataSet getGridValue_KYC(string CentreId, string strClient_ID)
    {
        string strSQL = "";
        strSQL = "SELECT [REF_NO],(ISNULL(FIRST_NAME,'')+''+ISNULL(MIDDLE_NAME,'')+''+ISNULL(LAST_NAME,'')) AS APPLICANT_NAME FROM CPV_KYC_CASE_DETAILS";
        strSQL = strSQL + " WHERE case_rec_datetime >= '" + strfromdate + "' AND  case_rec_datetime <  '" + strtodate + "' ";
        
        //CONVERT(CHAR(9), case_rec_datetime, 3) + LTRIM(SUBSTRING(CONVERT( VARCHAR(20), case_rec_datetime, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20), case_rec_datetime, 22), 3))
        
        strSQL = strSQL + " AND [CENTRE_ID]='" + CentreId + "' AND [CLIENT_ID]='" + strClient_ID + "'";
        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);
    }

    public DataSet getGridValue_KYC_Qc(string CentreId, string strClient_ID)
    {
        string strSQL = "";
        strSQL = "SELECT qc.REF_NO,(ISNULL(FIRST_NAME,'')+''+ISNULL(MIDDLE_NAME,'')+''+ISNULL(LAST_NAME,'')) AS APPLICANT_NAME FROM CPV_QC_CASE_DETAILS qc";
        strSQL = strSQL + " left outer join CPV_KYC_CASE_DETAILS cc on qc.case_id=cc.case_id ";
        strSQL = strSQL + " WHERE case_received_date >= '" + strfromdate + "' AND  case_received_date <  '" + strtodate + "' ";
        strSQL = strSQL + " AND qc.CENTRE_ID ='" + CentreId + "' AND qc.CLIENT_ID ='" + strClient_ID + "'";
        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);
    }

    public DataSet GetVerificationType_CC(string activityid)
    {

        string strSQL = " select VERIFICATION_TYPE_CODE,VERIFICATION_TYPE_ID FROM verification_type_master   WHERE  ACTIVITY_ID= '" + activityid + "'" +
                         " AND VERIFICATION_TYPE_ID IN(1,2,4,3,10) ";
        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);
    }

    public DataSet GetVerificationType_CC_Qc(string activityid)
    {

        string strSQL = " select VERIFICATION_TYPE_CODE,VERIFICATION_TYPE_ID FROM verification_type_master WHERE  ACTIVITY_ID= '" + activityid + "'" +
                         " AND VERIFICATION_TYPE_ID IN(25,26) ";
        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);
    }
    public DataSet GetVerificationType_CC_Dcr(string activityid)
    {

        string strSQL = " select VERIFICATION_TYPE_CODE,VERIFICATION_TYPE_ID FROM verification_type_master WHERE  ACTIVITY_ID= '" + activityid + "'" +
                         " AND VERIFICATION_TYPE_ID IN(20,37,38,39,40,41) ";
        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);
    }
    public DataSet GetVerificationType_EBC(string activityid)
    {

        string strSQL = " select VERIFICATION_TYPE_CODE,VERIFICATION_TYPE_ID FROM verification_type_master   WHERE  ACTIVITY_ID= '" + activityid + "'" +
                         " AND VERIFICATION_TYPE_ID IN(1,15,16,17,18) ";
        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);
    }

    public DataSet GetVerificationType_KYC(string activityid)
    {

        string strSQL = " select VERIFICATION_TYPE_CODE,VERIFICATION_TYPE_ID FROM verification_type_master   WHERE  ACTIVITY_ID= '" + activityid + "'" +
                         " AND VERIFICATION_TYPE_ID IN(1,2,19) ";
        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);
    }

    public DataSet GetVerificationType_KYC_Qc(string activityid)
    {

        string strSQL = " select VERIFICATION_TYPE_CODE,VERIFICATION_TYPE_ID FROM verification_type_master   WHERE  ACTIVITY_ID= '" + activityid + "'" +
                         " AND VERIFICATION_TYPE_ID IN(25,26) ";
        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);
    }

    public DataSet GetVerificationType_IDOC(string activityid)
    {

        string strSQL = " select VERIFICATION_TYPE_CODE,VERIFICATION_TYPE_ID FROM verification_type_master   WHERE  ACTIVITY_ID= '" + activityid + "'" +
                         " AND VERIFICATION_TYPE_ID IN(5,6,7,8,9,11) ";
        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);
    }
    public DataSet GetVerificationType_RL(string activityid)
    {

        string strSQL = " select VERIFICATION_TYPE_CODE,VERIFICATION_TYPE_ID FROM verification_type_master   WHERE  ACTIVITY_ID= '" + activityid + "'" +
                         " AND VERIFICATION_TYPE_ID IN(1,2,3,4,10,12,13,14,31,32,36) ";
        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);
    }

    public DataSet GetVerificationType_RL_Qc(string activityid)
    {

        string strSQL = " select VERIFICATION_TYPE_CODE,VERIFICATION_TYPE_ID FROM verification_type_master   WHERE  ACTIVITY_ID= '" + activityid + "'" +
                         " AND VERIFICATION_TYPE_ID IN(25,26) ";
        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);
    }

    //-------------------------------------------------------
    //Added by Manoj Jadhav
    public DataSet GetVerificationType_ConsolidLabel(string activityid)
    {

        string strSQL = " select VERIFICATION_TYPE_CODE,VERIFICATION_TYPE_ID FROM verification_type_master   WHERE " +
                         " VERIFICATION_TYPE_ID IN(1,2,11,5,6,7,8,9) ";
        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);
    }
    public DataSet getGridValue_CC1(string CentreId, string Emp_code, string productID)
    {
        string strSQL1;
        string P = "0";

        if (Emp_code == P)
        {
            strSQL1 = "select EMP_ID from  FE_VW";
            DataSet ds = new DataSet();
            ds = OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL1);
            DataTable td = ds.Tables[0];
            strSQL1 = "";
            for (int i = 0; i < td.Rows.Count; i++)
            {
                if (i != td.Rows.Count)
                {
                    strSQL1 += td.Rows[i]["EMP_ID"].ToString() + ",";

                }
            }
            strSQL1 = strSQL1.TrimEnd(',');
        }
        else
        {
            strSQL1 = Emp_code;
        }
        string strSQL = "";

        if (productID == "0")
        {
            strSQL = "SELECT distinct [SR_nO] as [Sr No],REF_NO,(ISNULL(FIRST_NAME,'')+''+ISNULL(MIDDLE_NAME,'')+''+ISNULL(LAST_NAME,'')) AS APPLICANT_NAME,'CC' as Product FROM CPV_CC_CASE_DETAILS CD inner join  CPV_CC_FE_CASE_MAPPING mapp on mapp.case_id=CD.case_id  left outer join FE_VW FE on FE.Emp_id=mapp.FE_ID ";
            strSQL = strSQL + " WHERE case_rec_datetime >= '" + strfromdate + "' AND case_rec_datetime <  '" + strtodate + "' ";
            strSQL = strSQL + " AND CD.CENTRE_ID = '" + CentreId + "' AND mapp.FE_ID in( " + strSQL1 + " ) ";

            strSQL = strSQL + "Union all";


            strSQL = strSQL + " SELECT distinct [SR_nO] as [Sr No],REF_NO,(ISNULL(FIRST_NAME,'')+''+ISNULL(MIDDLE_NAME,'')+''+ISNULL(LAST_NAME,'')) AS APPLICANT_NAME,'RL' as Product FROM CPV_RL_CASE_DETAILS CD inner join  CPV_RL_CASE_FE_MAPPING mapp on mapp.case_id=CD.case_id  left outer join FE_VW FE on FE.Emp_id=mapp.FE_ID ";
            strSQL = strSQL + " WHERE case_rec_datetime >= '" + strfromdate + "' AND case_rec_datetime <  '" + strtodate + "' ";
            strSQL = strSQL + " AND CD.CENTRE_ID = '" + CentreId + "' AND mapp.FE_ID in( " + strSQL1 + " ) ";

            strSQL = strSQL + "Union all";


            strSQL = strSQL + "  SELECT distinct [SR_nO] as [Sr No],REF_NO,(ISNULL(FIRST_NAME,'')+''+ISNULL(MIDDLE_NAME,'')+''+ISNULL(LAST_NAME,'')) AS APPLICANT_NAME,'KYC' as Product FROM CPV_KYC_CASE_DETAILS CD inner join  CPV_KYC_FE_MAPPING mapp on mapp.case_id=CD.case_id  left outer join FE_VW FE on FE.Emp_id=mapp.FE_ID ";
            strSQL = strSQL + " WHERE case_rec_datetime >= '" + strfromdate + "' AND case_rec_datetime <  '" + strtodate + "' ";
            strSQL = strSQL + " AND CD.CENTRE_ID = '" + CentreId + "' AND mapp.FE_ID in( " + strSQL1 + " ) ";

            strSQL = strSQL + "Union all";


            strSQL = strSQL + " SELECT distinct [SR_nO] as [Sr No],REF_NO,(ISNULL(FIRST_NAME,'')+''+ISNULL(MIDDLE_NAME,'')+''+ISNULL(LAST_NAME,'')) AS APPLICANT_NAME,'IDOC' as Product FROM CPV_IDOC_CASE_DETAILS CD inner join  CPV_IDOC_FE_CASE_MAPPING mapp on mapp.case_id=CD.case_id  left outer join FE_VW FE on FE.Emp_id=mapp.FE_ID ";
            strSQL = strSQL + " WHERE case_rec_datetime >= '" + strfromdate + "' AND case_rec_datetime <  '" + strtodate + "' ";
            strSQL = strSQL + " AND CD.CENTRE_ID = '" + CentreId + "' AND mapp.FE_ID in( " + strSQL1 + " ) ";

            strSQL = strSQL + "Union all";


            strSQL = strSQL + " SELECT distinct [SR_nO] as [Sr No],REF_NO,(ISNULL(FIRST_NAME,'')+''+ISNULL(MIDDLE_NAME,'')+''+ISNULL(LAST_NAME,'')) AS APPLICANT_NAME,'EBC' as Product FROM CPV_EBC_CASE_DETAILS CD inner join  CPV_EBC_FE_MAPPING mapp on mapp.case_id=CD.case_id  left outer join FE_VW FE on FE.Emp_id=mapp.FE_ID ";
            strSQL = strSQL + " WHERE case_rec_datetime >= '" + strfromdate + "' AND case_rec_datetime <  '" + strtodate + "' ";
            strSQL = strSQL + " AND CD.CENTRE_ID = '" + CentreId + "' AND mapp.FE_ID in( " + strSQL1 + " ) ";

            return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);

        }
        else
        {
            if (productID == "1011")
            {
                strSQL = "SELECT distinct [SR_nO] as [Sr No],REF_NO,(ISNULL(FIRST_NAME,'')+''+ISNULL(MIDDLE_NAME,'')+''+ISNULL(LAST_NAME,'')) AS APPLICANT_NAME,'CC' as Product FROM CPV_CC_CASE_DETAILS CD inner join  CPV_CC_FE_CASE_MAPPING mapp on mapp.case_id=CD.case_id  left outer join FE_VW FE on FE.Emp_id=mapp.FE_ID ";
                strSQL = strSQL + " WHERE case_rec_datetime >= '" + strfromdate + "' AND case_rec_datetime <  '" + strtodate + "' ";
                strSQL = strSQL + " AND CD.CENTRE_ID = '" + CentreId + "' And mapp.FE_ID in( " + strSQL1 + " ) ";
            }

            //strSQL = strSQL + "Union all";
            if (productID == "1012")
            {
                strSQL = strSQL + "  SELECT distinct [SR_nO] as [Sr No],REF_NO,(ISNULL(FIRST_NAME,'')+''+ISNULL(MIDDLE_NAME,'')+''+ISNULL(LAST_NAME,'')) AS APPLICANT_NAME,'RL' as Product FROM CPV_RL_CASE_DETAILS CD inner join  CPV_RL_CASE_FE_MAPPING mapp on mapp.case_id=CD.case_id  left outer join FE_VW FE on FE.Emp_id=mapp.FE_ID ";
                strSQL = strSQL + " WHERE case_rec_datetime >= '" + strfromdate + "' AND case_rec_datetime <  '" + strtodate + "' ";
                strSQL = strSQL + " AND CD.CENTRE_ID = '" + CentreId + "' And mapp.FE_ID in( " + strSQL1 + " ) ";
            }

            //strSQL = strSQL + "Union all";
            if (productID == "1015")
            {
                strSQL = strSQL + "  SELECT distinct [SR_nO] as [Sr No],REF_NO,(ISNULL(FIRST_NAME,'')+''+ISNULL(MIDDLE_NAME,'')+''+ISNULL(LAST_NAME,'')) AS APPLICANT_NAME,'KYC' as Product FROM CPV_KYC_CASE_DETAILS CD inner join  CPV_KYC_FE_MAPPING mapp on mapp.case_id=CD.case_id  left outer join FE_VW FE on FE.Emp_id=mapp.FE_ID ";
                strSQL = strSQL + " WHERE case_rec_datetime >= '" + strfromdate + "' AND case_rec_datetime <  '" + strtodate + "' ";
                strSQL = strSQL + " AND CD.CENTRE_ID = '" + CentreId + "' And mapp.FE_ID in( " + strSQL1 + " ) ";
            }

            //strSQL = strSQL + "Union all";
            if (productID == "1018")
            {
                strSQL = strSQL + "  SELECT distinct [SR_nO] as [Sr No],REF_NO,(ISNULL(FIRST_NAME,'')+''+ISNULL(MIDDLE_NAME,'')+''+ISNULL(LAST_NAME,'')) AS APPLICANT_NAME,'IDOC' as Product FROM CPV_IDOC_CASE_DETAILS CD inner join  CPV_IDOC_FE_CASE_MAPPING mapp on mapp.case_id=CD.case_id  left outer join FE_VW FE on FE.Emp_id=mapp.FE_ID ";
                strSQL = strSQL + " WHERE case_rec_datetime >= '" + strfromdate + "' AND case_rec_datetime <  '" + strtodate + "' ";
                strSQL = strSQL + " AND CD.CENTRE_ID = '" + CentreId + "' And mapp.FE_ID in( " + strSQL1 + " ) ";
            }

            //strSQL = strSQL + "Union all";
            if (productID == "1016")
            {
                strSQL = strSQL + "  SELECT distinct [SR_nO] as [Sr No],REF_NO,(ISNULL(FIRST_NAME,'')+''+ISNULL(MIDDLE_NAME,'')+''+ISNULL(LAST_NAME,'')) AS APPLICANT_NAME,'EBC' as product FROM CPV_EBC_CASE_DETAILS CD inner join  CPV_EBC_FE_MAPPING mapp on mapp.case_id=CD.case_id  left outer join FE_VW FE on FE.Emp_id=mapp.FE_ID ";
                strSQL = strSQL + " WHERE case_rec_datetime >= '" + strfromdate + "' AND case_rec_datetime <  '" + strtodate + "' ";
                strSQL = strSQL + " AND CD.CENTRE_ID = '" + CentreId + "' And mapp.FE_ID in( " + strSQL1 + " ) ";
            }
            return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, strSQL);
        }
    }
    public bool FunctioncompareDate(string strFromDate,string strToDate)
    {
        DateTime sFromDate;
        DateTime sToDate;
        sFromDate = Convert.ToDateTime(oCom.strDate(strFromDate));
        sToDate = Convert.ToDateTime(oCom.strDate(strToDate));

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
}
