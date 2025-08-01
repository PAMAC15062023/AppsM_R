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
/// Summary description for CsendToClient
/// </summary>
public class CsendToClient 
{
    CCommon connobj = new CCommon();
  
   public CsendToClient()
	{
		//
		// TODO: Add constructor logic here
		//
	}
   
    private string strSendDate;
    private string strSendTime;
    private string strSendTimeType;
    private string strcaseid;
    private string strtathrs;
    private string strsearchfromDate;
    private string strsearchtoDate;

    private string strVerificationType; //NEW added by SANKET

    public string VerificationType
    {
        get { return strVerificationType; }
        set { strVerificationType = value; }
    }


    public string SearchFromDate
    {
        get { return strsearchfromDate; }
        set { strsearchfromDate = value; }
    }

    public string SearchToDate
    {
        get { return strsearchtoDate; }
        set { strsearchtoDate = value; }
    }
   

    public string TATHRS
    {
        get { return strtathrs; }
        set { strtathrs = value; }
    }
    public string CaseId
    {
        get { return strcaseid; }
        set { strcaseid = value; }
    }
   

    public string SendDate
    {
        get { return strSendDate; }
        set { strSendDate = value; }
    }

    public string SendTime
    {
        get { return strSendTime; }
        set { strSendTime = value; }
    }

    public string SendTimeType
    {
        get { return strSendTimeType; }
        set { strSendTimeType = value; }
    }

    public DataTable GetTAT(DateTime sFromDate, DateTime sToDate)
    {
        
        DataTable d_table = new DataTable();
        DataSet ds = new DataSet();
        DateTime strSendDate ;
        DateTime strSendDate1;
        TimeSpan  ts1;
        double  Hrs,mins;
        string Hours="";
        string Minutes ="";
        string Total_Hours = "";
        DataRow drow;
        OleDbDataAdapter da = new OleDbDataAdapter();
        OleDbConnection conn = new OleDbConnection(connobj.ConnectionString);
        d_table.Columns.Add("REF_NO");
        d_table.Columns.Add("APPLICANT_NAME");
        d_table.Columns.Add("REC_DATE");
        d_table.Columns.Add("TAT_HRS");
        d_table.Columns.Add("CaseId");
       try
        {
            string strSql = "";
            strSql = " SELECT CD.CASE_ID, CD.REF_NO, (ISNULL(CD.FIRST_NAME,'')+''+ISNULL(CD.LAST_NAME,'')+''+ISNULL(CD.MIDDLE_NAME,''))AS APPLICANT_NAME, CD.CASE_REC_DATETIME AS REC_DATE FROM CPV_CC_CASE_DETAILS CD WHERE CD.SEND_DATETIME IS NULL AND CD.CENTRE_ID='" + HttpContext.Current.Session["CentreId"].ToString() + "' AND CD.CLIENT_ID='" + HttpContext.Current.Session["ClientId"].ToString() + "' AND CD.CASE_REC_DATETIME>= '" + sFromDate + "' AND CD.CASE_REC_DATETIME <'" + sToDate + "' AND CD.CASE_ID NOT IN (SELECT CASE_ID FROM CPV_CC_CASE_STATUS_NULL WHERE CENTRE_ID='" + HttpContext.Current.Session["CentreId"].ToString() + "' AND CLIENT_ID='" + HttpContext.Current.Session["ClientId"].ToString() + "' AND CASE_REC_DATETIME>='" + sFromDate + "' AND CASE_REC_DATETIME<'" + sToDate + "')";

            da = new OleDbDataAdapter(strSql, conn);
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
                    String s1 = Convert.ToDateTime(connobj.strDate(SendDate)).ToString("MM/dd/yyyy") + " " + SendTime.ToString() + " " + SendTimeType.ToString();
                    strSendDate = Convert.ToDateTime(s1.ToString());                   
                    ts1 = strSendDate.Subtract(strSendDate1);
                    Hrs = Convert.ToDouble(ts1.Days * 24 + ts1.Hours);
                    mins = Convert.ToDouble(ts1.Minutes);
                    Hours = Hrs.ToString();
                    Minutes = mins.ToString();
                    Total_Hours = Hours + ":" + Minutes;
                    drow[3] = Total_Hours.ToString();
                    drow[4] = ds.Tables["TAT"].Rows[i]["CASE_ID"];
                    d_table.Rows.Add(drow);
                }

            }

            return d_table;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
       
  
    }

    //New.....
    public string GetTAT_New(DateTime sFromDate, DateTime sToDate)
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
        OleDbDataAdapter da = new OleDbDataAdapter();
        OleDbConnection conn = new OleDbConnection(connobj.ConnectionString);
        d_table.Columns.Add("REF_NO");
        d_table.Columns.Add("APPLICANT_NAME");
        d_table.Columns.Add("REC_DATE");
        d_table.Columns.Add("TAT_HRS");
        d_table.Columns.Add("CaseId");
        try
        {
            string strSql = "";
            strSql = " SELECT CD.CASE_ID, CD.REF_NO, (ISNULL(CD.FIRST_NAME,'')+''+ISNULL(CD.LAST_NAME,'')+''+ISNULL(CD.MIDDLE_NAME,''))AS APPLICANT_NAME, CD.CASE_REC_DATETIME AS REC_DATE FROM CPV_CC_CASE_DETAILS CD WHERE CD.SEND_DATETIME IS NULL AND CD.CENTRE_ID='" + HttpContext.Current.Session["CentreId"].ToString() + "' AND CD.CLIENT_ID='" + HttpContext.Current.Session["ClientId"].ToString() + "' AND CD.CASE_REC_DATETIME>= '" + sFromDate + "' AND CD.CASE_REC_DATETIME <'" + sToDate + "' AND CD.CASE_ID NOT IN (SELECT CASE_ID FROM CPV_CC_CASE_STATUS_NULL WHERE CENTRE_ID='" + HttpContext.Current.Session["CentreId"].ToString() + "' AND CLIENT_ID='" + HttpContext.Current.Session["ClientId"].ToString() + "' AND CASE_REC_DATETIME>='" + sFromDate + "' AND CASE_REC_DATETIME<'" + sToDate + "')and CD.CASE_ID="+CaseId+"";

            da = new OleDbDataAdapter(strSql, conn);
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
                    String s1 = Convert.ToDateTime(connobj.strDate(SendDate)).ToString("MM/dd/yyyy") + " " + SendTime.ToString() + " " + SendTimeType.ToString();
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
   //End...



    public DataTable GetClientDCR(DateTime sFromDate, DateTime sToDate)
    {

        DataTable d_table = new DataTable();
        DataSet ds = new DataSet();
        DataRow drow;
        OleDbDataAdapter da = new OleDbDataAdapter();
        OleDbConnection conn = new OleDbConnection(connobj.ConnectionString);
        d_table.Columns.Add("Lead_id");
        d_table.Columns.Add("Cust_Fullname");
        d_table.Columns.Add("receiveddate");
        try
        {
            string strSql = "";
            strSql = " SELECT CD.CASE_ID, CD.Lead_id,Cust_Fullname,receiveddate FROM DCR_IMPORT_CASE_DETAILS CD WHERE CD.SEND_DATETIME IS NULL AND CD.CENTRE_ID='" + HttpContext.Current.Session["CentreId"].ToString() + "' AND CD.CLIENT_ID='" + HttpContext.Current.Session["ClientId"].ToString() + "' AND CD.CASE_receiveddateTIME>= '" + sFromDate + "' AND CD.CASE_receiveddateTIME<'" + sToDate + "' AND CD.CASE_ID NOT IN (SELECT CASE_ID FROM CPV_CC_CASE_STATUS_NULL WHERE CENTRE_ID='" + HttpContext.Current.Session["CentreId"].ToString() + "' AND CLIENT_ID='" + HttpContext.Current.Session["ClientId"].ToString() + "' AND CASE_receiveddateTIME>='" + sFromDate + "' AND CASE_receiveddateTIME<'" + sToDate + "')";
            da = new OleDbDataAdapter(strSql, conn);
            da.Fill(ds, "TAT");
            if (ds.Tables["TAT"].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables["TAT"].Rows.Count; i++)
                {
                    drow = d_table.NewRow();
                    drow[0] = ds.Tables["TAT"].Rows[i]["Lead_id"];
                    drow[1] = ds.Tables["TAT"].Rows[i]["Cust_Fullname"];
                    drow[2] = Convert.ToDateTime(ds.Tables["TAT"].Rows[i]["receiveddate"].ToString()).ToString("dd/MM/yyyy hh:mm tt");
                    d_table.Rows.Add(drow);
                }

            }

            return d_table;
        }

        catch (Exception ex)
        {
            throw new Exception("Error While Searching " + ex.Message);
        }

    }


    public void insertGridFields(DateTime strSendDate, string chkb)
    {
        OleDbConnection conn = new OleDbConnection(connobj.ConnectionString);
        conn.Open();
        OleDbTransaction oledbTrans = conn.BeginTransaction();
        string sql = "";
        try
        {

            sql = "";
            sql = "UPDATE  CPV_CC_CASE_DETAILS SET SEND_DATETIME=?,TAT_HRS=?, " +
                  "WITHIN_TAT=?  WHERE CASE_ID=?";
            OleDbParameter[] paramGrid = new OleDbParameter[4];
            paramGrid[0] = new OleDbParameter("@SEND_DATETIME", OleDbType.VarChar);
            paramGrid[0].Value = strSendDate;
            paramGrid[1] = new OleDbParameter("@TAT_HRS", OleDbType.VarChar);
            paramGrid[1].Value = TATHRS;
            paramGrid[2] = new OleDbParameter("@WITHIN_TAT", OleDbType.VarChar);
            paramGrid[2].Value = chkb;
            paramGrid[3] = new OleDbParameter("@CASE_ID", OleDbType.VarChar);
            paramGrid[3].Value = CaseId;
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql, paramGrid);
            oledbTrans.Commit();
            conn.Close();
        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            conn.Close();
            throw new Exception("Error While Sending " + ex.Message);
        }

    }

    public DataTable GetClient(DateTime sFromDate, DateTime sToDate)
    {
      
        DataTable d_table = new DataTable();
        DataSet ds = new DataSet();       
        DataRow drow;
        OleDbDataAdapter da = new OleDbDataAdapter();
        OleDbConnection conn = new OleDbConnection(connobj.ConnectionString);
        d_table.Columns.Add("REF_NO");
        d_table.Columns.Add("APPLICANT_NAME");
        d_table.Columns.Add("REC_DATE");
        try
        {
            string strSql = "";            
            strSql = " SELECT CD.CASE_ID, CD.REF_NO, (ISNULL(CD.FIRST_NAME,'')+''+ISNULL(CD.LAST_NAME,'')+''+ISNULL(CD.MIDDLE_NAME,''))AS APPLICANT_NAME, CD.CASE_REC_DATETIME AS REC_DATE FROM CPV_CC_CASE_DETAILS CD WHERE CD.SEND_DATETIME IS NULL AND CD.CENTRE_ID='" + HttpContext.Current.Session["CentreId"].ToString() + "' AND CD.CLIENT_ID='" + HttpContext.Current.Session["ClientId"].ToString() + "' AND CD.CASE_REC_DATETIME>= '" + sFromDate + "' AND CD.CASE_REC_DATETIME<'" + sToDate + "' AND CD.CASE_ID NOT IN (SELECT CASE_ID FROM CPV_CC_CASE_STATUS_NULL WHERE CENTRE_ID='" + HttpContext.Current.Session["CentreId"].ToString() + "' AND CLIENT_ID='" + HttpContext.Current.Session["ClientId"].ToString() + "' AND CASE_REC_DATETIME>='" + sFromDate + "' AND CASE_REC_DATETIME<'" + sToDate + "')";
            da = new OleDbDataAdapter(strSql, conn);
            da.Fill(ds, "TAT");
            if (ds.Tables["TAT"].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables["TAT"].Rows.Count; i++)
                {
                    drow = d_table.NewRow();
                    drow[0] = ds.Tables["TAT"].Rows[i]["REF_NO"];
                    drow[1] = ds.Tables["TAT"].Rows[i]["APPLICANT_NAME"];                    
                    drow[2] = Convert.ToDateTime(ds.Tables["TAT"].Rows[i]["REC_DATE"].ToString()).ToString("dd/MM/yyyy hh:mm tt");
                    d_table.Rows.Add(drow);
                }

            }

            return d_table;
        }

        catch (Exception ex)
        {
            throw new Exception("Error While Searching " + ex.Message);
        }

    }

    public string GerStandardTatHour()
    {


        OleDbConnection conn = new OleDbConnection(connobj.ConnectionString);
        conn.Open();
        OleDbTransaction oledbTrans = conn.BeginTransaction();
       
        string sSql = "";
        string STD_HRS = "";
        sSql = "SELECT STD_HRS1,STD_HRS2,STD_HRS3 from STANDARD_TAT_HOURS  WHERE ACTIVITY_ID='" + HttpContext.Current.Session["ActivityId"].ToString() + "' AND CLIENT_ID='" + HttpContext.Current.Session["ClientId"].ToString() + "' AND PRODUCT_ID='" + HttpContext.Current.Session["ProductId"].ToString() + "'";
        DataSet ds = OleDbHelper.ExecuteDataset(oledbTrans, CommandType.Text, sSql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            STD_HRS = ds.Tables[0].Rows[0]["STD_HRS1"].ToString();
        }
        oledbTrans.Commit();
        conn.Close();
        return STD_HRS;
   




    }

    public string FixDate(string strToConver)
    {
        string strData;
        strData = strToConver.Replace("-", " ");
        return strData;
    }


    public DataSet GetRecordsPD(string strClientId, string strClusterID, string strCentreId, DateTime strFromDate, DateTime strToDate)
    {

        OleDbConnection oledbConn = new OleDbConnection(connobj.ConnectionString);

        //Declaration of Parameters
        OleDbParameter[] SPara = new OleDbParameter[5];


        SPara[0] = new OleDbParameter("@ClientID", OleDbType.VarChar, 50);
        SPara[0].Value = strClientId;

        SPara[1] = new OleDbParameter("@ClusterID", OleDbType.VarChar, 50);
        SPara[1].Value = strClusterID;

        SPara[2] = new OleDbParameter("@CentreID", OleDbType.VarChar, 50);
        SPara[2].Value = strCentreId;

        SPara[3] = new OleDbParameter("@FromDate", OleDbType.VarChar, 50);
        SPara[3].Value = strFromDate;

        SPara[4] = new OleDbParameter("@ToDate", OleDbType.VarChar, 50);
        SPara[4].Value = strToDate;

        string sSql = "PD_SendToClient_New";
        return OleDbHelper.ExecuteDataset(connobj.ConnectionString, CommandType.StoredProcedure, sSql, SPara);

    }

    public DataSet GetRecordsPDCR(string strClientId, string strClusterID, string strCentreId, DateTime strFromDate, DateTime strToDate)
    {

        OleDbConnection oledbConn = new OleDbConnection(connobj.ConnectionString);

        //Declaration of Parameters
        OleDbParameter[] SPara = new OleDbParameter[5];


        SPara[0] = new OleDbParameter("@ClientID", OleDbType.VarChar, 50);
        SPara[0].Value = strClientId;

        SPara[1] = new OleDbParameter("@ClusterID", OleDbType.VarChar, 50);
        SPara[1].Value = strClusterID;

        SPara[2] = new OleDbParameter("@CentreID", OleDbType.VarChar, 50);
        SPara[2].Value = strCentreId;

        SPara[3] = new OleDbParameter("@FromDate", OleDbType.VarChar, 50);
        SPara[3].Value = strFromDate;

        SPara[4] = new OleDbParameter("@ToDate", OleDbType.VarChar, 50);
        SPara[4].Value = strToDate;

        string sSql = "DCR_SendToClient_New";
        return OleDbHelper.ExecuteDataset(connobj.ConnectionString, CommandType.StoredProcedure, sSql, SPara);

    }

    public DataSet GetRecords(string strClientId, string strCentreId, DateTime strFromDate, DateTime strToDate)
    {
        //string sSql = "SELECT CD.CASE_ID as CaseId,CD.REF_NO, (ISNULL(CD.FIRST_NAME,'')+''+ISNULL(CD.LAST_NAME,'')+''+ " +
        //            " ISNULL(CD.MIDDLE_NAME,''))AS APPLICANT_NAME,CD.CASE_REC_DATETIME AS REC_DATE,Null as TAT_HRS FROM CPV_CC_CASE_DETAILS CD " +
        //            " WHERE CD.SEND_DATETIME IS NULL AND (CD.CLIENT_ID='" + strClientId + "') AND " +
        //            " (CD.CENTRE_ID='" + strCentreId + "') " +
        //            " AND (CD.CASE_REC_DATETIME>='" + strFromDate + "') AND (CD.CASE_REC_DATETIME<='" + strToDate + "')" +
        //            " AND CD.CASE_ID NOT IN(SELECT DISTINCT CD.CASE_ID" +
        //            " FROM CPV_CC_CASE_DETAILS CD INNER JOIN " +
        //            " CPV_CC_CASE_VERIFICATIONTYPE CV ON CD.CASE_ID = CV.CASE_ID LEFT OUTER JOIN " +
        //            " CPV_CC_VERI_DETAILS VD ON CV.CASE_ID = VD.CASE_ID " +
        //            " AND CV.VERIFICATION_TYPE_ID = VD.VERIFICATION_TYPE_ID " +
        //            " WHERE (CD.SEND_DATETIME IS NULL) AND (VD.CASE_STATUS_ID IS NULL)" +
        //            " AND (CD.CLIENT_ID='" + strClientId + "') AND (CD.CENTRE_ID='" + strCentreId + "')" +
        //            " AND (CD.CASE_REC_DATETIME>='" + strFromDate + "') AND (CD.CASE_REC_DATETIME<='" + strToDate + "'))" +
        //            " ORDER BY CD.CASE_ID";

        string sSql = "SELECT CD.CASE_ID as CaseId,CD.REF_NO, (ISNULL(CD.FIRST_NAME,'')+''+ISNULL(CD.LAST_NAME,'')+''+ " +
                   " ISNULL(CD.MIDDLE_NAME,''))AS APPLICANT_NAME,CD.CASE_REC_DATETIME AS REC_DATE,Null as TAT_HRS FROM CPV_CC_CASE_DETAILS CD " +
                   " WHERE CD.SEND_DATETIME IS NULL AND (CD.CLIENT_ID='" + strClientId + "') AND " +
                   " (CD.CENTRE_ID='" + strCentreId + "') " +
                   " AND (CD.CASE_REC_DATETIME>='" + strFromDate + "') AND (CD.CASE_REC_DATETIME<='" + strToDate + "')" +
                   " AND IS_CASE_COMPLETE='Y'";
                  

       return OleDbHelper.ExecuteDataset(connobj.ConnectionString, CommandType.Text, sSql);
    }

    public DataTable CalculateTAT(DateTime sFromDate, DateTime sToDate, string strClientId, string strCentreId)
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
        OleDbDataAdapter da = new OleDbDataAdapter();
        OleDbConnection conn = new OleDbConnection(connobj.ConnectionString);
        d_table.Columns.Add("CaseId");
        d_table.Columns.Add("REF_NO");
        d_table.Columns.Add("APPLICANT_NAME");
        d_table.Columns.Add("REC_DATE");
        d_table.Columns.Add("TAT_HRS");
        
        try
        {
            string strSql = "";
            //strSql = " SELECT CD.CASE_ID, CD.REF_NO, (ISNULL(CD.FIRST_NAME,'')+''+ISNULL(CD.LAST_NAME,'')+''+ISNULL(CD.MIDDLE_NAME,''))AS APPLICANT_NAME, CD.CASE_REC_DATETIME AS REC_DATE FROM CPV_CC_CASE_DETAILS CD WHERE CD.SEND_DATETIME IS NULL AND CD.CENTRE_ID='" + HttpContext.Current.Session["CentreId"].ToString() + "' AND CD.CLIENT_ID='" + HttpContext.Current.Session["ClientId"].ToString() + "' AND CD.CASE_REC_DATETIME>= '" + sFromDate + "' AND CD.CASE_REC_DATETIME <'" + sToDate + "' AND CD.CASE_ID NOT IN (SELECT CASE_ID FROM CPV_CC_CASE_STATUS_NULL WHERE CENTRE_ID='" + HttpContext.Current.Session["CentreId"].ToString() + "' AND CLIENT_ID='" + HttpContext.Current.Session["ClientId"].ToString() + "' AND CASE_REC_DATETIME>='" + sFromDate + "' AND CASE_REC_DATETIME<'" + sToDate + "')";

            strSql = "SELECT CD.CASE_ID as CaseId,CD.REF_NO, (ISNULL(CD.FIRST_NAME,'')+''+ISNULL(CD.LAST_NAME,'')+''+ " +
                   " ISNULL(CD.MIDDLE_NAME,''))AS APPLICANT_NAME,CD.CASE_REC_DATETIME AS REC_DATE,Null as TAT_HRS FROM CPV_CC_CASE_DETAILS CD " +
                   " WHERE CD.SEND_DATETIME IS NULL AND (CD.CLIENT_ID='" + strClientId + "') AND " +
                   " (CD.CENTRE_ID='" + strCentreId + "') " +
                   " AND (CD.CASE_REC_DATETIME>='" + sFromDate + "') AND (CD.CASE_REC_DATETIME<='" + sToDate + "')" +
                   " AND IS_CASE_COMPLETE='Y'";

            da = new OleDbDataAdapter(strSql, conn);
            da.Fill(ds, "TAT");
            if (ds.Tables["TAT"].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables["TAT"].Rows.Count; i++)
                {
                    drow = d_table.NewRow();
                    drow[0] = ds.Tables["TAT"].Rows[i]["CASE_ID"];
                    drow[1] = ds.Tables["TAT"].Rows[i]["REF_NO"];
                    drow[2] = ds.Tables["TAT"].Rows[i]["APPLICANT_NAME"];

                    drow[3] = Convert.ToDateTime(ds.Tables["TAT"].Rows[i]["REC_DATE"].ToString()).ToString("dd/MM/yyyy hh:mm tt");
                    String s = ds.Tables["TAT"].Rows[i]["REC_DATE"].ToString();
                    strSendDate1 = Convert.ToDateTime(s.ToString());
                    String s1 = Convert.ToDateTime(connobj.strDate(SendDate)).ToString("MM/dd/yyyy") + " " + SendTime.ToString() + " " + SendTimeType.ToString();
                    strSendDate = Convert.ToDateTime(s1.ToString());
                    ts1 = strSendDate.Subtract(strSendDate1);
                    Hrs = Convert.ToDouble(ts1.Days * 24 + ts1.Hours);
                    mins = Convert.ToDouble(ts1.Minutes);
                    Hours = Hrs.ToString();
                    Minutes = mins.ToString();
                    Total_Hours = Hours + ":" + Minutes;
                    drow[4] = Total_Hours.ToString();
                    
                    d_table.Rows.Add(drow);
                }

            }

            return d_table;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }


    }

}
