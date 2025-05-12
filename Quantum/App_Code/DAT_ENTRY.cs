
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
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Summary description for DAT_ENTRY
/// </summary>
public class DAT_ENTRY
{
    CCommon con = new CCommon();
    DataSet ds = new DataSet();

    bool bColumnFlag;
    public bool ColumnFlag
    {
        get { return bColumnFlag; }
        set { bColumnFlag = value; }
    }
    string strMessage;
    public string Message
    {
        get { return strMessage; }
        set { strMessage = value; }
    }

    string strSubCentreID;
    public string SubCentreID
    {
        get { return strSubCentreID; }
        set { strSubCentreID = value; }
    }

    string strCentreID;
    public string CentreID
    {
        get { return strCentreID; }
        set { strCentreID = value; }
    }

    string strClusterID;
    public string ClusterID
    {
        get { return strClusterID; }
        set { strClusterID = value; }
    }
    private string strEMPCODE;
    public string EMPCODE
    {
        get { return strEMPCODE; }
        set { strEMPCODE = value; }
    }

    private string strDepartment1;
    public string Department1
    {
        get { return strDepartment1; }
        set { strDepartment1 = value; }
    }

    private string strEMPNAME;
    public string EMPNAME
    {
        get { return strEMPNAME; }
        set { strEMPNAME = value; }
    }
    private string strEMP_ID;
    public string Emp_ID
    {
        get { return strEMP_ID; }
        set { strEMP_ID = value; }
    }
    private string _fromdate;
    public string FromDate
    {
        get { return _fromdate; }
        set { _fromdate = value; }
    }
    private string _Todate;
    public string ToDate
    {
        get { return _Todate; }
        set { _Todate = value; }
    }
    private string strRSM_EMPCode;
    public string RSM_EMPCode
    {
        get { return strRSM_EMPCode; }
        set { strRSM_EMPCode = value; }
    }
    private List<string> _RM;
    public List<string> RM
    {
        get { return _RM; }
        set { _RM = value; }
    }

    private List<string> _RSM;
    public List<string> RSM
    {
        get { return _RSM; }
        set { _RSM = value; }
    }

    private string strAdmin;
    public string Admin_EMPCODE
    {
        get { return strAdmin; }
        set { strAdmin = value; }
    }

    private string StrDate;
    public string Date
    {
        get { return StrDate; }
        set { StrDate = value; }
    }
    public DAT_ENTRY()
    {

    }
    //public DataSet Fill_Grid()
    //{
    //    DataSet ds1 = new DataSet();
    //    string sqlStr = "";

    //    string strselectcriteria = "";


    //    string strselectcriteria1 = "";

    //    string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
    //    string str = strTime.Remove(2);
    //    string str1 = strTime.Remove(0, 3);

    //    //if ((Convert.ToInt32(str) <= 24) && (Convert.ToInt32(str1) > 00))
    //    //{
    //    //    strselectcriteria1 = "And Shift='First Shift'";
    //    //}
    //    //if ((Convert.ToInt32(str) >= 24) && (Convert.ToInt32(str1) > 00))
    //    //{
    //    //    strselectcriteria1 = "And Shift='Second Shift'";
    //    //}
    //    if ((CentreID == "10172") && (Convert.ToInt32(str) <= 24) && (Convert.ToInt32(str1) > 00))
    //    {
    //        strselectcriteria1 = "And Shift='First Shift'";
    //    }


    //    if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0")
    //    {
    //        strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "'";

    //    }
    //    if (SubCentreID == "0" && CentreID != "0" && ClusterID != "0")
    //    {
    //        strselectcriteria = " and EM.centre_id='" + CentreID + "'  and cm.cluster_id='" + ClusterID + "'";
    //    }
    //    if (SubCentreID == "0" && CentreID == "0" && ClusterID != "0")
    //    {
    //        strselectcriteria = "  and cm.cluster_id='" + ClusterID + "'";
    //    }
    //    if (SubCentreID != "0" && CentreID == "0" && ClusterID != "0")
    //    {
    //        strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
    //    }
    //    if (SubCentreID != "0" && CentreID != "0" && ClusterID == "0")
    //    {
    //        strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
    //    }
    //    if (EMPCODE != null)
    //    {
    //        strselectcriteria += " and em.emp_code='" + EMPCODE + "'";
    //    }
    //    if (EMPNAME != null)
    //    {
    //        strselectcriteria += " and ( ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '') like '%" + EMPNAME + "%') ";
    //    }
    //    if (DateTime.Now.Day <= 24)
    //    {
    //        sqlStr = " DECLARE @current_month CHAR(6) " +
    //                " DECLARE @previous_month CHAR(6) " +
    //                " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
    //                " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
    //                " select  distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(FIRSTNAME +' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) AS Pamecian, " +
    //                " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM  " +
    //                " left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
    //                " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
    //                //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
    //                //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
    //                " Inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
    //                " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
    //                " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
    //                " where department_id=" + strDepartment1 + "  and  1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
    //                " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)";
    //    }
    //    else
    //    {
    //        sqlStr = " DECLARE @current_month CHAR(6) " +
    //               " DECLARE @previous_month CHAR(6) " +
    //               " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
    //               " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
    //               " select  distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(FIRSTNAME +' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) AS Pamecian, " +
    //               " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM  " +
    //               " left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
    //               " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
    //                //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
    //                //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
    //                " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
    //               " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
    //               " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
    //               " where department_id=" + strDepartment1 + "  and  1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and cm.cluster_id='" + ClusterID + "' and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
    //               " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)";
    //    }
    //    ds = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
    //    if (ds.Tables[0].Rows.Count == 0)
    //    {
    //        if (DateTime.Now.Day <= 24)
    //        {
    //            sqlStr = " DECLARE @current_month CHAR(6) " +
    //                      " DECLARE @previous_month CHAR(6) " +
    //                      " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
    //                      " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
    //                      " select distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) " +
    //                      " AS Pamecian,DE.ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master  EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id) inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)" +
    //                       " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
    //                                    //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
    //                                      //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
    //                      " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
    //                      " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
    //                      " where department_id=" + strDepartment1 + "  and  1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
    //                     " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and  DOJ<=CAST(@previous_month + '21' AS datetime)";
    //        }
    //        else
    //        {
    //            sqlStr = " DECLARE @current_month CHAR(6) " +
    //                     " DECLARE @previous_month CHAR(6) " +
    //                     " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
    //                     " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
    //                     " select distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) " +
    //                     " AS Pamecian,DE.ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id) inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)" +
    //                      " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
    //                      //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
    //                        //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
    //                     " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
    //                     " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
    //                     " where department_id=" + strDepartment1 + "  and  1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
    //                    " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and  DOJ<=CAST(@current_month + '21' AS datetime)";
    //        }
    //        ds1 = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
    //    }
    //    if (ds.Tables[0].Rows.Count != 0)
    //    { 
    //    return ds;
    //    }
    //    else
    //    return ds1;
    //}

    //add by rani
    //21-03-2016
    //public DataSet Fill_Grid()
    //{
    //    DataSet ds1 = new DataSet();
    //    string sqlStr = "";

    //    string strselectcriteria = "";


    //    string strselectcriteria1 = "";

    //    string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
    //    string str = strTime.Remove(2);
    //    string str1 = strTime.Remove(0, 3);

    //    //if ((Convert.ToInt32(str) <= 24) && (Convert.ToInt32(str1) > 00))
    //    //{
    //    //    strselectcriteria1 = "And Shift='First Shift'";
    //    //}
    //    //if ((Convert.ToInt32(str) >= 24) && (Convert.ToInt32(str1) > 00))
    //    //{
    //    //    strselectcriteria1 = "And Shift='Second Shift'";
    //    //}
    //    if ((CentreID == "10172") && (Convert.ToInt32(str) <= 24) && (Convert.ToInt32(str1) > 00))
    //    {
    //        strselectcriteria1 = "And Shift='First Shift'";
    //    }


    //    if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0" &&  Emp_ID=="" )
    //    {
    //        strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "'";

    //    }
    //    else if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0" && Emp_ID == "0")
    //    {
    //        strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "'";

    //    }
    //    else if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0" && Emp_ID != "" && Emp_ID != null && Emp_ID != "0")
    //    {
    //        strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "' and  em.Rm_empcode='" + Emp_ID + "'";

    //    }

    //    else if (SubCentreID == "0" && CentreID != "0" && ClusterID != "0" && Emp_ID != "" && Emp_ID != null && Emp_ID != "0")
    //    {
    //        strselectcriteria = " and EM.centre_id='" + CentreID + "' and cm.cluster_id='" + ClusterID + "' and  em.Rm_empcode='" + Emp_ID + "'";

    //    }
    //    else if (SubCentreID == "0" && CentreID == "0" && ClusterID != "0" && Emp_ID != "" && Emp_ID != null && Emp_ID!="0")
    //    {
    //        strselectcriteria = "  and cm.cluster_id='" + ClusterID + "' and  em.Rm_empcode='" + Emp_ID + "'";

    //    }
    //    else if ( RM!=null && SubCentreID == "0" && CentreID == "0" && ClusterID != "0" && RM.Count != 0 && Emp_ID == "0" && RSM.Count== 0)
    //    {
    //        strselectcriteria = " and cm.cluster_id='" + ClusterID + "' and ( em.Rm_empcode in ( ";
    //        for (int a = 0; a < RM.Count; a++)
    //        {
    //            strselectcriteria += " '" + RM[a].Substring(0, 7).ToString() + "'";
    //            if (a != RM.Count - 1) 
    //            strselectcriteria += ",";
    //            if (a == RM.Count - 1)
    //            {

    //                strselectcriteria += "  )  ) ";
    //            }
    //        }
    //    }
    //    else if (RM != null && SubCentreID == "0" && CentreID == "0" && ClusterID != "0" && RM.Count != 0 && Emp_ID == "0" && RSM.Count != 0)
    //    {
    //        if (RSM_EMPCode == "0")
    //        {
    //            strselectcriteria = " and cm.cluster_id='" + ClusterID + "' and ( em.Rm_empcode in ( ";
    //            for (int a = 0; a < RM.Count; a++)
    //            {
    //                strselectcriteria += " '" + RM[a].Substring(0, 7).ToString() + "'";
    //                if (a != RM.Count - 1)
    //                    strselectcriteria += ",";
    //                if (a == RM.Count - 1)
    //                {

    //                    strselectcriteria += "  )  ) ";
    //                }
    //            }

    //        }
    //        else
    //        {
    //            strselectcriteria = "and em.RSM_empcode='" + RSM_EMPCode + "'  and cm.cluster_id='" + ClusterID + "' and ( em.Rm_empcode in ( ";
    //            for (int a = 0; a < RM.Count; a++)
    //            {
    //                strselectcriteria += " '" + RM[a].Substring(0, 7).ToString() + "'";
    //                if (a != RM.Count - 1)
    //                    strselectcriteria += ",";
    //                if (a == RM.Count - 1)
    //                {

    //                    strselectcriteria += "  )  ) ";
    //                }
    //            }

    //        }


    //    }

    //    else
    //    {
    //        strselectcriteria = "  and cm.cluster_id='" + ClusterID + "' ";
    //    }

    //    //if (SubCentreID == "0" && CentreID == "0" && ClusterID != "0" && RM.Count != 0 && Emp_ID == "0")
    //    //{
    //    //    strselectcriteria = " and cm.cluster_id='" + ClusterID + "' and ( em.Rm_empcode in ( ";
    //    //    for (int a = 0; a < RM.Count; a++)
    //    //    {
    //    //        strselectcriteria += " '" + RM[a].Substring(0, 7).ToString() + "'";
    //    //        if (a != RM.Count - 1) 
    //    //        strselectcriteria += ",";
    //    //        if (a == RM.Count - 1)
    //    //        {

    //    //            strselectcriteria += "  )  ) ";
    //    //        }
    //    //    }
    //    //}



    //    //if (SubCentreID == "0" && CentreID != "0" && ClusterID != "0")
    //    //{
    //    //    strselectcriteria = " and EM.centre_id='" + CentreID + "'  and cm.cluster_id='" + ClusterID + "'";
    //    //}
    //    //if (SubCentreID == "0" && CentreID == "0" && ClusterID != "0")
    //    //{
    //    //    strselectcriteria = "  and cm.cluster_id='" + ClusterID + "'";
    //    //}
    //    if (SubCentreID != "0" && CentreID == "0" && ClusterID != "0")
    //    {
    //        strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
    //    }
    //    if (SubCentreID != "0" && CentreID != "0" && ClusterID == "0")
    //    {
    //        strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
    //    }
    //    if (EMPCODE != null)
    //    {
    //        strselectcriteria += " and em.emp_code='" + EMPCODE + "'";
    //    }
    //    if (EMPNAME != null)
    //    {
    //        strselectcriteria += " and ( ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '') like '%" + EMPNAME + "%') ";
    //    }
    //    if (DateTime.Now.Day <= 24)
    //    {
    //        sqlStr = " DECLARE @current_month CHAR(6) " +
    //                " DECLARE @previous_month CHAR(6) " +
    //                " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
    //                " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
    //                " select  distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(Fullname +' ', '')) AS Pamecian, " + //(ISNULL(FIRSTNAME +' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) AS Pamecian, " +
    //                " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,Centre_name,SubcentreName from employee_master EM  " +
    //               // " left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE] ='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
    //               " left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "')  " +
    //                " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
    //            //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
    //            //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
    //                " Inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
    //                " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
    //                " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
    //            //" where department_id=" + strDepartment1 +and
    //                " where   1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
    //                " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)";
    //    }
    //    else
    //    {
    //        sqlStr = " DECLARE @current_month CHAR(6) " +
    //               " DECLARE @previous_month CHAR(6) " +
    //               " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
    //               " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
    //               " select  distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(Fullname +' ', '')) AS Pamecian, " +// +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) AS Pamecian, " +
    //               " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,Centre_name,SubcentreName from employee_master EM  " +
    //               " left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
    //               " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
    //            //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
    //            //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
    //                " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
    //               " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
    //               " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
    //            // " where department_id=" + strDepartment1 + "  and 
    //                 " where 1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and cm.cluster_id='" + ClusterID + "' and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
    //               " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)";
    //    }
    //    ds = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
    //    if (ds.Tables[0].Rows.Count == 0)
    //    {
    //        if (DateTime.Now.Day <= 24)
    //        {
    //            sqlStr = " DECLARE @current_month CHAR(6) " +
    //                      " DECLARE @previous_month CHAR(6) " +
    //                      " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
    //                      " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
    //                      " select distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(Fullname +' ', '')) AS Pamecian, " +//(ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) " +
    //                      "DE.ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName from employee_master  EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id) inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)" +
    //                       " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
    //                //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
    //                //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
    //                      " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
    //                      " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
    //                //" where department_id=" + strDepartment1 + "  and 
    //                     " where   1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
    //                     " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and  DOJ<=CAST(@previous_month + '21' AS datetime)";
    //        }
    //        else
    //        {
    //            sqlStr = " DECLARE @current_month CHAR(6) " +
    //                     " DECLARE @previous_month CHAR(6) " +
    //                     " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
    //                     " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
    //                     " select distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(Fullname +' ', '')) AS Pamecian, " +//(ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) " +
    //                     " DE.ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id) inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)" +
    //                      " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
    //                //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
    //                //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
    //                     " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
    //                     " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
    //                //" where department_id=" + strDepartment1 + "  and  
    //                     " where 1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
    //                    " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and  DOJ<=CAST(@current_month + '21' AS datetime)";
    //        }
    //        ds1 = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
    //    }
    //    if (ds.Tables[0].Rows.Count != 0)
    //    {
    //        return ds;
    //    }
    //    else
    //        return ds1;
    //}
    public DataSet Fill_Grid1()
    {
        DataSet ds1 = new DataSet();
        string sqlStr = "";

        string strselectcriteria = "";


        string strselectcriteria1 = "";

        string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
        string str = strTime.Remove(2);
        string str1 = strTime.Remove(0, 3);

        //if ((Convert.ToInt32(str) <= 24) && (Convert.ToInt32(str1) > 00))
        //{
        //    strselectcriteria1 = "And Shift='First Shift'";
        //}
        //if ((Convert.ToInt32(str) >= 24) && (Convert.ToInt32(str1) > 00))
        //{
        //    strselectcriteria1 = "And Shift='Second Shift'";
        //}
        if ((CentreID == "10172") && (Convert.ToInt32(str) <= 24) && (Convert.ToInt32(str1) > 00))
        {
            strselectcriteria1 = "And Shift='First Shift'";
        }
        if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0" && Emp_ID == "")
        {
            strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "'";

        }
        else if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0" && Emp_ID == "0")
        {
            strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "'";

        }
        else if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0" && Emp_ID != "" && Emp_ID != null && Emp_ID != "0")
        {
            strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "' and  em.Rm_empcode='" + Emp_ID + "'";

        }

        else if (SubCentreID == "0" && CentreID != "0" && ClusterID != "0" && Emp_ID != "" && Emp_ID != null && Emp_ID != "0")
        {
            strselectcriteria = " and EM.centre_id='" + CentreID + "' and cm.cluster_id='" + ClusterID + "' and  em.Rm_empcode='" + Emp_ID + "'";

        }
        else if (SubCentreID == "0" && CentreID == "0" && ClusterID != "0" && Emp_ID != "" && Emp_ID != null && Emp_ID != "0")
        {
            strselectcriteria = "  and cm.cluster_id='" + ClusterID + "' and  em.Rm_empcode='" + Emp_ID + "'";

        }
        else if (RM != null && SubCentreID == "0" && CentreID == "0" && ClusterID != "0" && RM.Count != 0 && Emp_ID == "0" && RSM.Count == 0)
        {
            strselectcriteria = " and cm.cluster_id='" + ClusterID + "' and ( em.Rm_empcode in ( ";
            for (int a = 0; a < RM.Count; a++)
            {
                strselectcriteria += " '" + RM[a].Substring(0, 7).ToString() + "'";
                if (a != RM.Count - 1)
                    strselectcriteria += ",";
                if (a == RM.Count - 1)
                {

                    strselectcriteria += "  )  ) ";
                }
            }
        }
        else if (RM != null && SubCentreID == "0" && CentreID == "0" && ClusterID != "0" && RM.Count != 0 && Emp_ID == "0" && RSM.Count != 0)
        {
            if (RSM_EMPCode == "0")
            {
                strselectcriteria = " and cm.cluster_id='" + ClusterID + "' and ( em.Rm_empcode in ( ";
                for (int a = 0; a < RM.Count; a++)
                {
                    strselectcriteria += " '" + RM[a].Substring(0, 7).ToString() + "'";
                    if (a != RM.Count - 1)
                        strselectcriteria += ",";
                    if (a == RM.Count - 1)
                    {

                        strselectcriteria += "  )  ) ";
                    }
                }

            }
            else
            {
                strselectcriteria = "and em.RSM_empcode='" + RSM_EMPCode + "'  and cm.cluster_id='" + ClusterID + "' and ( em.Rm_empcode in ( ";
                for (int a = 0; a < RM.Count; a++)
                {
                    strselectcriteria += " '" + RM[a].Substring(0, 7).ToString() + "'";
                    if (a != RM.Count - 1)
                        strselectcriteria += ",";
                    if (a == RM.Count - 1)
                    {

                        strselectcriteria += "  )  ) ";
                    }
                }

            }


        }


        else
        {
            strselectcriteria = "  and cm.cluster_id='" + ClusterID + "' ";
        }

        //if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0")
        //{
        //    strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "'";

        //}
        //if (SubCentreID == "0" && CentreID != "0" && ClusterID != "0")
        //{
        //    strselectcriteria = " and EM.centre_id='" + CentreID + "'  and cm.cluster_id='" + ClusterID + "'";
        //}
        //if (SubCentreID == "0" && CentreID == "0" && ClusterID != "0")
        //{
        //    strselectcriteria = "  and cm.cluster_id='" + ClusterID + "'";
        //}
        if (SubCentreID != "0" && CentreID == "0" && ClusterID != "0")
        {
            strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
        }
        if (SubCentreID != "0" && CentreID != "0" && ClusterID == "0")
        {
            strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
        }
        if (EMPCODE != null)
        {
            strselectcriteria += " and em.emp_code='" + EMPCODE + "'";
        }
        if (EMPNAME != null)
        {
            strselectcriteria += " and ( ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '') like '%" + EMPNAME + "%') ";
        }
        if (DateTime.Now.Day <= 24)
        {
            if (Date == "")
                sqlStr = " DECLARE @current_month CHAR(6) " +
                        " DECLARE @previous_month CHAR(6) " +
                        " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                        " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
                        " select  distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(FULLNAME +' ', ''))AS Pamecian, " +//(ISNULL(FIRSTNAME +' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) AS Pamecian, " +
                        " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM  " +
                        " left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
                        " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
                    //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
                    //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
                        " Inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                        " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
                        " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                    //" where department_id=" + strDepartment1 +and
                        " where   1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
                        " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)";
            else
            {
                sqlStr = " DECLARE @current_month CHAR(6) " +
                       " DECLARE @previous_month CHAR(6) " +
                       " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                       " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
                       " select  distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(FULLNAME +' ', ''))AS Pamecian, " +//(ISNULL(FIRSTNAME +' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) AS Pamecian, " +
                       " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM  " +
                       " left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + Convert.ToDateTime(Date).ToString("dd-MMM-yyyy") + "') " +
                       " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
                    //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
                    //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
                       " Inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                       " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
                       " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                    //" where department_id=" + strDepartment1 +and
                       " where   1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
                       " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)";
            }
        }
        else
        {
            if (Date == "")
                sqlStr = " DECLARE @current_month CHAR(6) " +
                       " DECLARE @previous_month CHAR(6) " +
                       " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                       " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
                       " select  distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(FULLNAME +' ', ''))AS Pamecian, " +//(ISNULL(FIRSTNAME +' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) AS Pamecian, " +
                       " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM  " +
                       " left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
                       " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
                    //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
                    //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
                        " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                       " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
                       " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                    // " where department_id=" + strDepartment1 + "  and 
                         " where 1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and cm.cluster_id='" + ClusterID + "' and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
                       " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)";
            else
            {
                sqlStr = " DECLARE @current_month CHAR(6) " +
                      " DECLARE @previous_month CHAR(6) " +
                      " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                      " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
                      " select  distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(FULLNAME +' ', ''))AS Pamecian, " +//(ISNULL(FIRSTNAME +' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) AS Pamecian, " +
                      " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM  " +
                      " left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + Convert.ToDateTime(Date).ToString("dd-MMM-yyyy") + "') " +
                      " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
                    //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
                    //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
                       " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                      " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
                      " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                    // " where department_id=" + strDepartment1 + "  and 
                        " where 1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and cm.cluster_id='" + ClusterID + "' and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
                      " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)";
            }
        }
        ds = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
        if (ds.Tables[0].Rows.Count == 0)
        {
            if (DateTime.Now.Day <= 24)
            {
                sqlStr = " DECLARE @current_month CHAR(6) " +
                          " DECLARE @previous_month CHAR(6) " +
                          " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                          " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
                          " select distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(FULLNAME +' ', ''))AS Pamecian, " +//(ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) " +
                          " AS Pamecian,DE.ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master  EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id) inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)" +
                           " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                    //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
                    //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
                          " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                          " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                    //" where department_id=" + strDepartment1 + "  and 
                         " where   1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
                         " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and  DOJ<=CAST(@previous_month + '21' AS datetime)";
            }
            else
            {
                sqlStr = " DECLARE @current_month CHAR(6) " +
                         " DECLARE @previous_month CHAR(6) " +
                         " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                         " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
                         " select distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(FULLNAME +' ', ''))AS Pamecian, " +//(ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) " +
                         " AS Pamecian,DE.ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id) inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)" +
                          " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                    //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
                    //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
                         " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                         " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                    //" where department_id=" + strDepartment1 + "  and  
                         " where 1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
                        " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and  DOJ<=CAST(@current_month + '21' AS datetime)";
            }
            ds1 = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
        }
        if (ds.Tables[0].Rows.Count != 0)
        {
            return ds;
        }
        else
            return ds1;
    }

    public DataSet Fill_Grid()
    {
        DataSet ds1 = new DataSet();
        string sqlStr = "";

        string strselectcriteria = "";


        string strselectcriteria1 = "";

        string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
        string str = strTime.Remove(2);
        string str1 = strTime.Remove(0, 3);


        if ((CentreID == "10172") && (Convert.ToInt32(str) <= 24) && (Convert.ToInt32(str1) > 00))
        {
            strselectcriteria1 = "And Shift='First Shift'";
        }


        if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0" && Emp_ID == "")
        {
            strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "'";

        }
        else if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0" && Emp_ID == "0")
        {
            strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "'";

        }
        else if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0" && Emp_ID != "" && Emp_ID != null && Emp_ID != "0")
        {
            strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "' and  em.Rm_empcode='" + Emp_ID + "'";

        }

        else if (SubCentreID == "0" && CentreID != "0" && ClusterID != "0" && Emp_ID != "" && Emp_ID != null && Emp_ID != "0")
        {
            strselectcriteria = " and EM.centre_id='" + CentreID + "' and cm.cluster_id='" + ClusterID + "' and  em.Rm_empcode='" + Emp_ID + "'";

        }
        else if (SubCentreID == "0" && CentreID != "0" && ClusterID != "0" && Emp_ID == "0")
        {
            strselectcriteria = " and EM.centre_id='" + CentreID + "'  and cm.cluster_id='" + ClusterID + "'";// and  em.Rm_empcode='" + Emp_ID + "'";

        }
        else if (SubCentreID == "0" && CentreID == "0" && ClusterID != "0" && Emp_ID != "" && Emp_ID != null && Emp_ID != "0")
        {
            strselectcriteria = "  and cm.cluster_id='" + ClusterID + "' and  em.Rm_empcode='" + Emp_ID + "'";

        }
        else if (RM != null && SubCentreID == "0" && CentreID == "0" && ClusterID != "0" && RM.Count != 0 && Emp_ID == "0" && RSM.Count == 0)
        {
            strselectcriteria = " and cm.cluster_id='" + ClusterID + "' and ( em.Rm_empcode in ( ";
            for (int a = 0; a < RM.Count; a++)
            {
                strselectcriteria += " '" + RM[a].Substring(0, 7).ToString() + "'";
                if (a != RM.Count - 1)
                    strselectcriteria += ",";
                if (a == RM.Count - 1)
                {

                    strselectcriteria += "  )  ) ";
                }
            }
        }
        else if (RM != null && SubCentreID == "0" && CentreID == "0" && ClusterID != "0" && RM.Count != 0 && Emp_ID == "0" && RSM.Count != 0)
        {
            if (RSM_EMPCode == "0")
            {
                strselectcriteria = " and cm.cluster_id='" + ClusterID + "' and ( em.Rm_empcode in ( ";
                for (int a = 0; a < RM.Count; a++)
                {
                    strselectcriteria += " '" + RM[a].Substring(0, 7).ToString() + "'";
                    if (a != RM.Count - 1)
                        strselectcriteria += ",";
                    if (a == RM.Count - 1)
                    {

                        strselectcriteria += "  )  ) ";
                    }
                }

            }
            else
            {
                strselectcriteria = "and em.RSM_empcode='" + RSM_EMPCode + "'  and cm.cluster_id='" + ClusterID + "' and ( em.Rm_empcode in ( ";
                for (int a = 0; a < RM.Count; a++)
                {
                    strselectcriteria += " '" + RM[a].Substring(0, 7).ToString() + "'";
                    if (a != RM.Count - 1)
                        strselectcriteria += ",";
                    if (a == RM.Count - 1)
                    {

                        strselectcriteria += "  )  ) ";
                    }
                }

            }


        }

        else
        {
            strselectcriteria = "  and cm.cluster_id='" + ClusterID + "' ";
        }


        if (SubCentreID != "0" && CentreID == "0" && ClusterID != "0")
        {
            strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
        }
        if (SubCentreID != "0" && CentreID != "0" && ClusterID == "0")
        {
            strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
        }
        if (EMPCODE != null)
        {
            strselectcriteria += " and em.emp_code='" + EMPCODE + "'";
        }
        if (EMPNAME != null)
        {
            strselectcriteria += " and ( ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '') like '%" + EMPNAME + "%') ";
        }
        if (DateTime.Now.Day <= 24)
        {
            if ((ToDate == null || ToDate == "") && (FromDate == null || FromDate == ""))
            //if ((ToDate != null || ToDate != "") && (FromDate != null || FromDate !=""))
            {
                sqlStr = " DECLARE @current_month CHAR(6) " +
                " DECLARE @previous_month CHAR(6) " +
                " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
                "select  * from(" +
                " select  distinct em.emp_id,em.emp_code as[Emp Code],Fullname as Pamecian, " +
                " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,Centre_name,SubcentreName,date from employee_master EM  " +
                " left outer join DATILY_ATTENDANCE DE on de.emp_id=em.emp_id  " +
                " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
                    //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
                    //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
                " Inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
                " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                    //" where department_id=" + strDepartment1 +and
                " where   1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
                " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)" +
                " and  ( date <= cast( (Convert(varchar,  '" + System.DateTime.Now + "',103)) as datetime)   and  date >= cast ((convert(varchar,'" + System.DateTime.Now.AddDays(-15) + "' ,103)) as datetime) or date is null)" +
                " ) abc pivot ( max(ATTENDANCE) " +
                " for  date in ( ";
                for (int a = 14; a >= 0; a--)
                {
                    sqlStr += "[";
                    if (System.DateTime.Now.AddDays(-a).ToString().Length == 20)
                        sqlStr += System.DateTime.Now.AddDays(-a).ToString().Substring(0, 9) + " 00:00:00:000";
                    else if (System.DateTime.Now.AddDays(-a).ToString().Length == 19)
                        sqlStr += System.DateTime.Now.AddDays(-a).ToString().Substring(0, 9) + " 00:00:00:000";
                    else
                        sqlStr += System.DateTime.Now.AddDays(-a).ToString().Substring(0, 10) + " 00:00:00:000";
                    if (a == 0)
                        sqlStr += "]";
                    else
                        sqlStr += "],";
                }
                sqlStr += ")) as pvt";

            }
            else
            {
                TimeSpan d = TimeSpan.Zero;

                if (ToDate != "" && FromDate != "")
                    d = Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)) - Convert.ToDateTime(DateTime.ParseExact(FromDate, "dd/MM/yyyy", null));
                int Diff = Convert.ToInt32(d.TotalDays);
                sqlStr = " DECLARE @current_month CHAR(6) " +
                " DECLARE @previous_month CHAR(6) " +
                " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
                "select  * from(" +
                " select  distinct em.emp_id,em.emp_code as[Emp Code],Fullname as Pamecian, " +
                " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,Centre_name,SubcentreName,date from employee_master EM  " +
                " left outer join DATILY_ATTENDANCE DE on de.emp_id=em.emp_id  " +
                " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
                    //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
                    //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
                " Inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
                " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                    //" where department_id=" + strDepartment1 +and
                " where   1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
                " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)" +
                " and  ( date <= cast( (Convert(varchar,  '" + Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)) + "',103)) as datetime)   and  date >= cast ((convert(varchar,'" + Convert.ToDateTime(DateTime.ParseExact(FromDate, "dd/MM/yyyy", null)) + "' ,103)) as datetime)  or date is null)" +
                " ) abc pivot ( max(ATTENDANCE) " +
                " for  date in ( ";
                for (int a = Diff; a >= 0; a--)
                {
                    sqlStr += "[";
                    if (Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)).AddDays(-a).ToString().Length == 20)
                        sqlStr += Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)).AddDays(-a).ToString().Substring(0, 9) + "00:00:00:000";
                    else if (Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)).AddDays(-a).ToString().Length == 19)
                        sqlStr += Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)).AddDays(-a).ToString().Substring(0, 9) + " 00:00:00:000";
                    else
                        sqlStr += Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)).AddDays(-a).ToString().Substring(0, 10) + "00:00:00:000";
                    if (a == 0)
                        sqlStr += "]";
                    else
                        sqlStr += "],";
                }
                sqlStr += ")) as pvt";
            }

        }
        else
        {
            if ((ToDate == null || ToDate == "") && (FromDate == null || FromDate == ""))
            //if ((ToDate != null || ToDate != "") && (FromDate != null || FromDate !=""))
            {
                sqlStr = " DECLARE @current_month CHAR(6) " +
                       " DECLARE @previous_month CHAR(6) " +
                       " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                       " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +

                       "select  * from(" +
                    " select  distinct em.emp_id,em.emp_code as[Emp Code],Fullname as Pamecian, " +
                    " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,Centre_name,SubcentreName,date from employee_master EM  " +
                    " left outer join DATILY_ATTENDANCE DE on de.emp_id=em.emp_id  " +
                    " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
                    //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
                    //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
                    " Inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                    " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
                    " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                    //" where department_id=" + strDepartment1 +and
                    " where   1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
                    " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)" +
                    " and  ( date <= cast( (Convert(varchar,  '" + System.DateTime.Now + "',103)) as datetime)   and  date >= cast ((convert(varchar,'" + System.DateTime.Now.AddDays(-15) + "' ,103)) as datetime)  or date is null)" +
                    " ) abc pivot ( max(ATTENDANCE) " +
                    " for  date in ( ";
                for (int a = 14; a >= 0; a--)
                {
                    sqlStr += "[";
                    if (System.DateTime.Now.AddDays(-a).ToString().Length == 20)
                        sqlStr += System.DateTime.Now.AddDays(-a).ToString().Substring(0, 9) + " 00:00:00:000";
                    else if (System.DateTime.Now.AddDays(-a).ToString().Length == 19)
                        sqlStr += System.DateTime.Now.AddDays(-a).ToString().Substring(0, 9) + " 00:00:00:000";
                    else
                        sqlStr += System.DateTime.Now.AddDays(-a).ToString().Substring(0, 10) + " 00:00:00:000";
                    if (a == 0)
                        sqlStr += "]";
                    else
                        sqlStr += "],";
                }
                sqlStr += ")) as pvt";
            }

            else
            {
                TimeSpan d = TimeSpan.Zero;

                if (ToDate != "" && FromDate != "")
                    d = Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)) - Convert.ToDateTime(DateTime.ParseExact(FromDate, "dd/MM/yyyy", null));
                int Diff = Convert.ToInt32(d.TotalDays);
                sqlStr = " DECLARE @current_month CHAR(6) " +
                       " DECLARE @previous_month CHAR(6) " +
                       " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                       " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
                "select  * from(" +
                " select  distinct em.emp_id,em.emp_code as[Emp Code],Fullname as Pamecian, " +
                " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,Centre_name,SubcentreName,date from employee_master EM  " +
                " left outer join DATILY_ATTENDANCE DE on de.emp_id=em.emp_id  " +
                " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
                    //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
                    //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
                " Inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
                " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                    //" where department_id=" + strDepartment1 +and
                " where   1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
                " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)" +
                " and  ( date <= cast( (Convert(varchar,  '" + Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)) + "',103)) as datetime)   and  date >= cast ((convert(varchar,'" + Convert.ToDateTime(DateTime.ParseExact(FromDate, "dd/MM/yyyy", null)) + "' ,103)) as datetime)  or date is null)" +
                " ) abc pivot ( max(ATTENDANCE) " +
                " for  date in ( ";
                for (int a = Diff; a >= 0; a--)
                {
                    sqlStr += "[";
                    if (Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)).AddDays(-a).ToString().Length == 20)
                        sqlStr += Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)).AddDays(-a).ToString().Substring(0, 9) + "00:00:00:000";
                    else if (Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)).AddDays(-a).ToString().Length == 19)
                        sqlStr += Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)).AddDays(-a).ToString().Substring(0, 9) + " 00:00:00:000";
                    else
                        sqlStr += Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)).AddDays(-a).ToString().Substring(0, 10) + "00:00:00:000";
                    if (a == 0)
                        sqlStr += "]";
                    else
                        sqlStr += "],";
                }
                sqlStr += ")) as pvt";

            }
            //   " select  distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(Fullname +' ', '')) AS Pamecian, " +// +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) AS Pamecian, " +
            //   " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,Centre_name,SubcentreName from employee_master EM  " +
            //   " left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
            //   " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
            ////" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
            ////" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
            //    " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
            //   " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
            //   " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
            //// " where department_id=" + strDepartment1 + "  and 
            //     " where 1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and cm.cluster_id='" + ClusterID + "' and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
            //   " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)";
        }
        ds = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
        if (ds.Tables[0].Rows.Count == 0)
        {
            if (DateTime.Now.Day <= 24)
            {
                if ((ToDate == null || ToDate == "") && (FromDate == null || FromDate == ""))
                //if ((ToDate != null || ToDate != "") && (FromDate != null || FromDate !=""))
                {
                    sqlStr = " DECLARE @current_month CHAR(6) " +
                              " DECLARE @previous_month CHAR(6) " +
                              " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                              " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +

                                "select  * from(" +
                    " select  distinct em.emp_id,em.emp_code as[Emp Code],Fullname as Pamecian, " +
                    " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,Centre_name,SubcentreName,date from employee_master EM  " +
                    " left outer join DATILY_ATTENDANCE DE on de.emp_id=em.emp_id and date is null " +
                    " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
                        //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
                        //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
                    " Inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                    " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
                    " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                        //" where department_id=" + strDepartment1 +and
                    " where   1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
                    " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)" +
                    " and  ( date <= cast( (Convert(varchar,  '" + System.DateTime.Now + "',103)) as datetime)   and  date >= cast ((convert(varchar,'" + System.DateTime.Now.AddDays(-15) + "' ,103)) as datetime) or date is null)" +
                    " ) abc pivot ( max(ATTENDANCE) " +
                    " for  date in ( ";
                    for (int a = 14; a >= 0; a--)
                    {
                        sqlStr += "[";
                        if (System.DateTime.Now.AddDays(-a).ToString().Length == 20)
                            sqlStr += System.DateTime.Now.AddDays(-a).ToString().Substring(0, 9) + " 00:00:00:000";
                        else if (System.DateTime.Now.AddDays(-a).ToString().Length == 19)
                            sqlStr += System.DateTime.Now.AddDays(-a).ToString().Substring(0, 9) + " 00:00:00:000";
                        else
                            sqlStr += System.DateTime.Now.AddDays(-a).ToString().Substring(0, 10) + " 00:00:00:000";
                        if (a == 0)
                            sqlStr += "]";
                        else
                            sqlStr += "],";
                    }
                    sqlStr += ")) as pvt";
                }

                else
                {
                    TimeSpan d = TimeSpan.Zero;

                    if (ToDate != "" && FromDate != "")
                        d = Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)) - Convert.ToDateTime(DateTime.ParseExact(FromDate, "dd/MM/yyyy", null));
                    int Diff = Convert.ToInt32(d.TotalDays);
                    sqlStr = " DECLARE @current_month CHAR(6) " +
                              " DECLARE @previous_month CHAR(6) " +
                              " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                              " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +

                                "select  * from(" +
                    " select  distinct em.emp_id,em.emp_code as[Emp Code],Fullname as Pamecian, " +
                    " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,Centre_name,SubcentreName,date from employee_master EM  " +
                    " left outer join DATILY_ATTENDANCE DE on de.emp_id=em.emp_id and date is null " +
                    " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
                        //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
                        //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
                    " Inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                    " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
                    " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                      " where   1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
                " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)" +
                " and  ( date <= cast( (Convert(varchar,  '" + Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)) + "',103)) as datetime)   and  date >= cast ((convert(varchar,'" + Convert.ToDateTime(DateTime.ParseExact(FromDate, "dd/MM/yyyy", null)) + "' ,103)) as datetime)  or date is null)" +
                " ) abc pivot ( max(ATTENDANCE) " +
                " for  date in ( ";
                    for (int a = Diff; a >= 0; a--)
                    {
                        sqlStr += "[";
                        if (Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)).AddDays(-a).ToString().Length == 20)
                            sqlStr += Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)).AddDays(-a).ToString().Substring(0, 9) + "00:00:00:000";
                        else if (Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)).AddDays(-a).ToString().Length == 19)
                            sqlStr += Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)).AddDays(-a).ToString().Substring(0, 9) + " 00:00:00:000";
                        else
                            sqlStr += Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)).AddDays(-a).ToString().Substring(0, 10) + "00:00:00:000";
                        if (a == 0)
                            sqlStr += "]";
                        else
                            sqlStr += "],";
                    }
                    sqlStr += ")) as pvt";

                }
                // " select distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(Fullname +' ', '')) AS Pamecian, " +//(ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) " +
                // "DE.ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName from employee_master  EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id) inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)" +
                //  " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                //   //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
                //   //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
                // " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                // " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                //   //" where department_id=" + strDepartment1 + "  and 
                //" where   1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
                //" (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and  DOJ<=CAST(@previous_month + '21' AS datetime)";
            }
            else
            {
                if ((ToDate == null || ToDate == "") && (FromDate == null || FromDate == ""))
                //i
                {
                    sqlStr = " DECLARE @current_month CHAR(6) " +
                             " DECLARE @previous_month CHAR(6) " +
                             " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                             " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
                        //     " select distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(Fullname +' ', '')) AS Pamecian, " +//(ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) " +
                        //     " DE.ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id) inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)" +
                        //      " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                        ////" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
                        ////" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
                        //     " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                        //     " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                        ////" where department_id=" + strDepartment1 + "  and  
                        //     " where 1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
                        //    " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and  DOJ<=CAST(@current_month + '21' AS datetime)";
                            "select  * from(" +
                        " select  distinct em.emp_id,em.emp_code as[Emp Code],Fullname as Pamecian, " +
                        " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,Centre_name,SubcentreName,date from employee_master EM  " +
                        " left outer join DATILY_ATTENDANCE DE on de.emp_id=em.emp_id  and date is null " +
                        " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
                        //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
                        //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
                        " Inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                        " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
                        " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                        //" where department_id=" + strDepartment1 +and
                        " where   1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
                        " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)" +
                        " and  ( date <= cast( (Convert(varchar,  '" + System.DateTime.Now + "',103)) as datetime)   and  date >= cast ((convert(varchar,'" + System.DateTime.Now.AddDays(-15) + "' ,103)) as datetime) or date is null)" +
                        " ) abc pivot ( max(ATTENDANCE) " +
                        " for  date in ( ";
                    for (int a = 14; a >= 0; a--)
                    {
                        sqlStr += "[";
                        if (System.DateTime.Now.AddDays(-a).ToString().Length == 20)
                            sqlStr += System.DateTime.Now.AddDays(-a).ToString().Substring(0, 9) + " 00:00:00:000";
                        else if (System.DateTime.Now.AddDays(-a).ToString().Length == 19)
                            sqlStr += System.DateTime.Now.AddDays(-a).ToString().Substring(0, 9) + " 00:00:00:000";
                        else
                            sqlStr += System.DateTime.Now.AddDays(-a).ToString().Substring(0, 10) + " 00:00:00:000";
                        if (a == 0)
                            sqlStr += "]";
                        else
                            sqlStr += "],";
                    }
                    sqlStr += ")) as pvt";
                }
                else
                {

                    TimeSpan d = TimeSpan.Zero;

                    if (ToDate != "" && FromDate != "")
                        d = Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)) - Convert.ToDateTime(DateTime.ParseExact(FromDate, "dd/MM/yyyy", null));
                    int Diff = Convert.ToInt32(d.TotalDays);
                    sqlStr = " DECLARE @current_month CHAR(6) " +
                               " DECLARE @previous_month CHAR(6) " +
                               " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                               " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +

                                 "select  * from(" +
                      " select  distinct em.emp_id,em.emp_code as[Emp Code],Fullname as Pamecian, " +
                      " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,Centre_name,SubcentreName,date from employee_master EM  " +
                      " left outer join DATILY_ATTENDANCE DE on de.emp_id=em.emp_id and date is null " +
                      " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
                        //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
                        //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
                      " Inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                      " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
                      " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                        " where   1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
                  " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)" +
                  " and  ( date <= cast( (Convert(varchar,  '" + Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)) + "',103)) as datetime)   and  date >= cast ((convert(varchar,'" + Convert.ToDateTime(DateTime.ParseExact(FromDate, "dd/MM/yyyy", null)) + "' ,103)) as datetime)  or date is null)" +
                  " ) abc pivot ( max(ATTENDANCE) " +
                  " for  date in ( ";
                    for (int a = Diff; a >= 0; a--)
                    {
                        sqlStr += "[";
                        if (Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)).AddDays(-a).ToString().Length == 20)
                            sqlStr += Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)).AddDays(-a).ToString().Substring(0, 9) + "00:00:00:000";
                        else if (Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)).AddDays(-a).ToString().Length == 19)
                            sqlStr += Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)).AddDays(-a).ToString().Substring(0, 9) + " 00:00:00:000";
                        else
                            sqlStr += Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)).AddDays(-a).ToString().Substring(0, 10) + "00:00:00:000";
                        if (a == 0)
                            sqlStr += "]";
                        else
                            sqlStr += "],";
                    }
                    sqlStr += ")) as pvt";
                }
            }
            ds1 = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
        }
        if (ds.Tables[0].Rows.Count != 0)
        {
            return ds;
        }
        else
            return ds1;
    }

    public DataSet EditGrid(string sdate)
    {
        DataSet ds1 = new DataSet();
        string sqlStr = "";
        string strselectcriteria = "";
        if (EMPCODE != null)
        {
            strselectcriteria += " and em.emp_code='" + EMPCODE + "'";
        }
        if (EMPNAME != null)
        {
            strselectcriteria += " and ( ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '') like '%" + EMPNAME + "%') ";
        }



        sqlStr = " DECLARE @current_month CHAR(6) " +
                      " DECLARE @previous_month CHAR(6) " +
                      " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                      " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
                      " select distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(Fullname +' ', '')) AS Pamecian, " +//(ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) " +
                      " ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id  and [DATE]='" + sdate + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)" +
                       " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                      " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                      " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                      " where department_id=" + strDepartment1 + "  and   EM.centre_id=Case Isnull('" + CentreID + "',0) When 0 Then Em.centre_id Else '" + CentreID + "'  End   and SUBCENTRE_ID=Case Isnull('" + SubCentreID + "',0) When 0 Then subcentre_id Else '" + SubCentreID + "'  End  and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
                     " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) ";


        ds = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
        if (ds.Tables[0].Rows.Count == 0)
        {

            sqlStr = " DECLARE @current_month CHAR(6) " +
                     " DECLARE @previous_month CHAR(6) " +
                     " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                     " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
                    " select distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(Fullname +' ', '')) AS Pamecian, " +//(ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) " +
                    " ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id  and [DATE]='" + sdate + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)" +
                     " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                    " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                    " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                    " where department_id=" + strDepartment1 + "  and   EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "'   and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
                   " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) ";


            ds1 = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);

        }
        if (ds.Tables[0].Rows.Count != 0)
        {
            return ds;
        }
        else
            return ds1;
    }

    //public DataSet GetToDayAttenance()
    //{
    //    DataSet ds1 = new DataSet();
    //    string sqlStr = "";
    //    string strselectcriteria = "";
    //    if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0")
    //    {
    //        strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "'";

    //    }
    //    if (SubCentreID == "0" && CentreID != "0" && ClusterID != "0")
    //    {
    //        strselectcriteria = " and EM.centre_id='" + CentreID + "'  and cm.cluster_id='" + ClusterID + "'";
    //    }
    //    if (SubCentreID == "0" && CentreID == "0" && ClusterID != "0")
    //    {
    //        strselectcriteria = "  and cm.cluster_id='" + ClusterID + "'";
    //    }
    //    if (SubCentreID != "0" && CentreID == "0" && ClusterID != "0")
    //    {
    //        strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
    //    }
    //    if (SubCentreID != "0" && CentreID != "0" && ClusterID == "0")
    //    {
    //        strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
    //    }
    //    if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() != "Sunday")
    //    {
    //        if (DateTime.Now.Day <= 20)
    //        {
    //            sqlStr = " DECLARE @current_month CHAR(6) " +
    //                     " DECLARE @previous_month CHAR(6) " +
    //                     " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
    //                     " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
    //                     " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
    //                      " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
    //                     " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
    //                     " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
    //                     " where department_id=" + strDepartment1 + "  and  1=1 " + strselectcriteria + "  and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
    //                    " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)";
    //        }
    //        else
    //        {
    //            sqlStr = " DECLARE @current_month CHAR(6) " +
    //                     " DECLARE @previous_month CHAR(6) " +
    //                     " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
    //                     " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
    //                     " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
    //                      " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
    //                     " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
    //                     " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
    //                     " where department_id=" + strDepartment1 + "  and  1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
    //                    " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)";
    //        }
    //    }
    //    else
    //    {
    //        if (DateTime.Now.Day <= 20)
    //        {
    //            sqlStr = " DECLARE @current_month CHAR(6) " +
    //                     " DECLARE @previous_month CHAR(6) " +
    //                     " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
    //                     " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
    //                     " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-2).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
    //                      " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
    //                     " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
    //                     " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
    //                     " where department_id=" + strDepartment1 + "  and  1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
    //                    " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)";
    //        }
    //        else
    //        {
    //            sqlStr = " DECLARE @current_month CHAR(6) " +
    //                    " DECLARE @previous_month CHAR(6) " +
    //                    " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
    //                    " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
    //                    " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-2).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
    //                     " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
    //                    " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
    //                    " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
    //                    " where department_id=" + strDepartment1 + "  and  1=1 " + strselectcriteria + "  and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
    //                   " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)";
    //        }
    //    }
    //    ds1 = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
    //    return ds1;
    //}

    //add by Rani
    public DataSet GetToDayAttenance1()
    {
        DataSet ds1 = new DataSet();
        string sqlStr = "";
        string strselectcriteria = "";
        //if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0" && Emp_ID == "0")
        //{
        //    strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "'";

        //}
        //if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0" && Emp_ID != "0")
        //{
        //    strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "' and  em.user_id_activityManager='" + Emp_ID + "'";

        //}
        if (SubCentreID == "0" && CentreID != "0" && ClusterID != "0")
        {
            strselectcriteria = " and EM.centre_id='" + CentreID + "'  and cm.cluster_id='" + ClusterID + "'";
        }
        if (SubCentreID == "0" && CentreID == "0" && ClusterID != "0")
        {
            strselectcriteria = "  and cm.cluster_id='" + ClusterID + "'";
        }
        if (SubCentreID != "0" && CentreID == "0" && ClusterID != "0")
        {
            strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
        }
        if (SubCentreID != "0" && CentreID != "0" && ClusterID == "0")
        {
            strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
        }
        if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() != "Sunday")
        {
            if (DateTime.Now.Day <= 20)
            {
                //if ((ToDate != null && FromDate != null))
                //{
                //    sqlStr = " DECLARE @current_month CHAR(6) " +
                //             " DECLARE @previous_month CHAR(6) " +
                //             " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                //             " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +

                //            " select  emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date  from (" +

                //             "select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date " +
                //            "from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id )" +
                //             "inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)  " +
                //             "inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                //             "left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                //             "left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                //             " where 1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL)" +
                //             "and (DOL >=  '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)" +
                //             ") ABC " +
                //             "where  date <= cast( (Convert(varchar(10),  '" + Convert.ToDateTime(ToDate).Date.ToString("yyyy-MM-dd HH:mm:SS") + "' ,103)) as datetime) and date >= cast ((convert(varchar(10), '" + Convert.ToDateTime(FromDate).Date.ToString("yyyy-MM-dd HH:mm:SS") + "'  ,103)) as datetime) " +

                //             "group by emp_id ,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName, date";
                //}
                //else
                //{
                sqlStr = " DECLARE @current_month CHAR(6) " +
                        " DECLARE @previous_month CHAR(6) " +
                        " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                        " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +

                       " select  emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date  from (" +

                        "select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date " +
                       "from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id )" +
                        "inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)  " +
                        "inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                        "left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                        "left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                        " where 1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL)" +
                        "and (DOL >=  '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)" +
                        ") ABC " +
                        "where  date <= cast( (Convert(varchar(10),  '" + System.DateTime.Now + "',103)) as datetime)   and  date >= cast ((convert(varchar(10),'" + System.DateTime.Now.AddDays(-14) + "' ,103)) as datetime) " +

                        "group by emp_id ,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName, date";
                //}

                //     " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(0).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
                //      " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                //     " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                //     " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                ////" where department_id=" + strDepartment1 + "  and 
                //     " where 1=1 " + strselectcriteria + "  and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
                //    " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)";
            }

            else
            {
                sqlStr = " DECLARE @current_month CHAR(6) " +
                         " DECLARE @previous_month CHAR(6) " +
                         " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                         " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
                         " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
                          " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                         " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                         " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                    // " where department_id=" + strDepartment1 + "  and  
                         " where 1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
                        " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)";
            }
        }
        else
        {
            if (DateTime.Now.Day <= 20)
            {
                sqlStr = " DECLARE @current_month CHAR(6) " +
                         " DECLARE @previous_month CHAR(6) " +
                         " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                         " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
                         " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-2).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
                          " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                         " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                         " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                    // " where department_id=" + strDepartment1 + "  and 
                         " where  1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
                        " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)";
            }
            else
            {
                sqlStr = " DECLARE @current_month CHAR(6) " +
                        " DECLARE @previous_month CHAR(6) " +
                        " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                        " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
                        " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-2).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
                         " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                        " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                        " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                    //   " where department_id=" + strDepartment1 + "  and  
                       "where  1=1 " + strselectcriteria + "  and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
                       " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)";
            }
        }
        ds1 = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
        return ds1;
    }
    public DataSet GetToDayAttenance2()
    {
        DataSet ds1 = new DataSet();
        string sqlStr = "";
        string strselectcriteria = "";
        if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0")
        {
            strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "'";

        }
        if (SubCentreID == "0" && CentreID != "0" && ClusterID != "0")
        {
            strselectcriteria = " and EM.centre_id='" + CentreID + "'  and cm.cluster_id='" + ClusterID + "'";
        }
        if (SubCentreID == "0" && CentreID == "0" && ClusterID != "0")
        {
            strselectcriteria = "  and cm.cluster_id='" + ClusterID + "'";
        }
        if (SubCentreID != "0" && CentreID == "0" && ClusterID != "0")
        {
            strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
        }
        if (SubCentreID != "0" && CentreID != "0" && ClusterID == "0")
        {
            strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
        }
        if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() != "Sunday")
        {
            if (DateTime.Now.Day <= 20)
            {
                sqlStr = " DECLARE @current_month CHAR(6) " +
                         " DECLARE @previous_month CHAR(6) " +
                         " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                         " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
                         " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
                          " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                         " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                         " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                    //" where department_id=" + strDepartment1 + "  and 
                         " where 1=1 " + strselectcriteria + "  and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
                        " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)";
            }
            else
            {
                sqlStr = " DECLARE @current_month CHAR(6) " +
                         " DECLARE @previous_month CHAR(6) " +
                         " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                         " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
                         " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
                          " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                         " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                         " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                    // " where department_id=" + strDepartment1 + "  and  
                         " where 1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
                        " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)";
            }
        }
        else
        {
            if (DateTime.Now.Day <= 20)
            {
                sqlStr = " DECLARE @current_month CHAR(6) " +
                         " DECLARE @previous_month CHAR(6) " +
                         " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                         " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
                         " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-2).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
                          " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                         " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                         " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                    // " where department_id=" + strDepartment1 + "  and 
                         " where  1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
                        " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)";
            }
            else
            {
                sqlStr = " DECLARE @current_month CHAR(6) " +
                        " DECLARE @previous_month CHAR(6) " +
                        " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                        " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
                        " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-2).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
                         " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                        " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                        " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                    //   " where department_id=" + strDepartment1 + "  and  
                       "where  1=1 " + strselectcriteria + "  and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
                       " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)";
            }
        }
        ds1 = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
        return ds1;
    }
    public DataSet GetToDayAttenance()
    {
        DataSet ds1 = new DataSet();
        string sqlStr = "";
        string strselectcriteria = "";
        //if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0" && Emp_ID == "0")
        //{
        //    strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "'";

        //}
        //if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0" && Emp_ID != "0")
        //{
        //    strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "' and  em.user_id_activityManager='" + Emp_ID + "'";

        //}
        if (SubCentreID == "0" && CentreID != "0" && ClusterID != "0")
        {
            strselectcriteria = " and EM.centre_id='" + CentreID + "'  and cm.cluster_id='" + ClusterID + "'";
        }
        if (SubCentreID == "0" && CentreID == "0" && ClusterID != "0")
        {
            strselectcriteria = "  and cm.cluster_id='" + ClusterID + "'";
        }
        if (SubCentreID != "0" && CentreID == "0" && ClusterID != "0")
        {
            strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
        }
        if (SubCentreID != "0" && CentreID != "0" && ClusterID == "0")
        {
            strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
        }
        if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() != "Sunday")
        {
            if (DateTime.Now.Day <= 20)
            {
                if ((ToDate == null || ToDate == "") && (FromDate == null || FromDate == ""))
                //if ((ToDate != null || ToDate != "") && (FromDate != null || FromDate !=""))
                {
                    sqlStr = " DECLARE @current_month CHAR(6) " +
                           " DECLARE @previous_month CHAR(6) " +
                           " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                           " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +

                          " select  emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date  from (" +

                           "select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date " +
                          "from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id )" +
                           "inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)  " +
                           "inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                           "left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                           "left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                           " where 1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL)" +
                           "and (DOL >=  '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)" +
                           ") ABC " +
                           "where  date <= cast( (Convert(varchar,  '" + System.DateTime.Now + "',103)) as datetime)   and  date >= cast ((convert(varchar,'" + System.DateTime.Now.AddDays(-14) + "' ,103)) as datetime) " +

                           "group by emp_id ,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName, date";
                }
                else
                {
                    sqlStr = " DECLARE @current_month CHAR(6) " +
                            " DECLARE @previous_month CHAR(6) " +
                            " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                            " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +

                           " select  emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date  from (" +

                            "select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date " +
                           "from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id )" +
                            "inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)  " +
                            "inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                            "left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                            "left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                            " where 1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL)" +
                            "and (DOL >=  '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)" +
                            ") ABC " +
                            "where  date <= cast( (Convert(varchar,  '" + Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)).Date.ToString("yyyy-MM-dd HH:mm") + "' ,103)) as datetime) and date >= cast ((convert(varchar, '" + Convert.ToDateTime(DateTime.ParseExact(FromDate, "dd/MM/yyyy", null)).Date.ToString("yyyy-MM-dd HH:mm") + "'  ,103)) as datetime) " +

                            "group by emp_id ,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName, date";

                }

                //     " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(0).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
                //      " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                //     " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                //     " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                ////" where department_id=" + strDepartment1 + "  and 
                //     " where 1=1 " + strselectcriteria + "  and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
                //    " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)";
            }

            else
            {
                if ((ToDate == null || ToDate == "") && (FromDate == null || FromDate == ""))
                //if ((ToDate != null || ToDate != "") && (FromDate != null || FromDate !=""))
                {
                    sqlStr = " DECLARE @current_month CHAR(6) " +
                           " DECLARE @previous_month CHAR(6) " +
                           " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                           " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +

                          " select  emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date  from (" +

                           "select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date " +
                          "from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id )" +
                           "inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)  " +
                           "inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                           "left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                           "left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                           " where 1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL)" +
                           "and (DOL >=  '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)" +
                           ") ABC " +
                           "where  date <= cast( (Convert(varchar,  '" + System.DateTime.Now + "',103)) as datetime)   and  date >= cast ((convert(varchar,'" + System.DateTime.Now.AddDays(-14) + "' ,103)) as datetime) " +

                           "group by emp_id ,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName, date";
                }
                else
                {
                    sqlStr = " DECLARE @current_month CHAR(6) " +
                            " DECLARE @previous_month CHAR(6) " +
                            " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                            " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
                           " select  emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date  from (" +

                            "select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date " +
                           "from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id )" +
                            "inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)  " +
                            "inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                            "left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                            "left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                            " where 1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL)" +
                            "and (DOL >=  '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)" +
                            ") ABC " +
                            "where  date <= cast( (Convert(varchar,  '" + Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)).Date.ToString("yyyy-MM-dd HH:mm") + "' ,103)) as datetime) and date >= cast ((convert(varchar, '" + Convert.ToDateTime(DateTime.ParseExact(FromDate, "dd/MM/yyyy", null)).Date.ToString("yyyy-MM-dd HH:mm") + "'  ,103)) as datetime) " +

                            "group by emp_id ,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName, date";

                }

                //sqlStr = " DECLARE @current_month CHAR(6) " +
                //         " DECLARE @previous_month CHAR(6) " +
                //         " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                //         " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
                //         " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
                //          " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                //         " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                //         " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                //    // " where department_id=" + strDepartment1 + "  and  
                //         " where 1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
                //        " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)";
            }
        }
        else
        {
            if (DateTime.Now.Day <= 20)
            {
                if ((ToDate == null || ToDate == "") && (FromDate == null || FromDate == ""))
                //if ((ToDate != null || ToDate != "") && (FromDate != null || FromDate !=""))
                {
                    sqlStr = " DECLARE @current_month CHAR(6) " +
                           " DECLARE @previous_month CHAR(6) " +
                           " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                           " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +

                          " select  emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date  from (" +

                           "select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date " +
                          "from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id )" +
                           "inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)  " +
                           "inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                           "left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                           "left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                           " where 1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL)" +
                           "and (DOL >=  '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)" +
                           ") ABC " +
                           "where  date <= cast( (Convert(varchar,  '" + System.DateTime.Now + "',103)) as datetime)   and  date >= cast ((convert(varchar,'" + System.DateTime.Now.AddDays(-14) + "' ,103)) as datetime) " +

                           "group by emp_id ,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName, date";
                }
                else
                {
                    sqlStr = " DECLARE @current_month CHAR(6) " +
                            " DECLARE @previous_month CHAR(6) " +
                            " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                            " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +

                           " select  emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date  from (" +

                            "select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date " +
                           "from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id )" +
                            "inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)  " +
                            "inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                            "left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                            "left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                            " where 1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL)" +
                            "and (DOL >=  '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)" +
                            ") ABC " +
                            "where  date <= cast( (Convert(varchar,  '" + Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)).Date.ToString("yyyy-MM-dd HH:mm") + "' ,103)) as datetime) and date >= cast ((convert(varchar, '" + Convert.ToDateTime(DateTime.ParseExact(FromDate, "dd/MM/yyyy", null)).Date.ToString("yyyy-MM-dd HH:mm") + "'  ,103)) as datetime) " +

                            "group by emp_id ,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName, date";

                }
                //sqlStr = " DECLARE @current_month CHAR(6) " +
                //         " DECLARE @previous_month CHAR(6) " +
                //         " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                //         " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
                //         " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-2).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
                //          " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                //         " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                //         " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                //    // " where department_id=" + strDepartment1 + "  and 
                //         " where  1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
                //        " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)";
            }
            else
            {
                if ((ToDate == null || ToDate == "") && (FromDate == null || FromDate == ""))
                //if ((ToDate != null || ToDate != "") && (FromDate != null || FromDate !=""))
                {
                    sqlStr = " DECLARE @current_month CHAR(6) " +
                           " DECLARE @previous_month CHAR(6) " +
                           " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                           " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +

                          " select  emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date  from (" +

                           "select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date " +
                          "from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id )" +
                           "inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)  " +
                           "inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                           "left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                           "left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                           " where 1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL)" +
                           "and (DOL >=  '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)" +
                           ") ABC " +
                           "where  date <= cast( (Convert(varchar,  '" + System.DateTime.Now + "',103)) as datetime)   and  date >= cast ((convert(varchar,'" + System.DateTime.Now.AddDays(-14) + "' ,103)) as datetime) " +

                           "group by emp_id ,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName, date";
                }
                else
                {
                    sqlStr = " DECLARE @current_month CHAR(6) " +
                            " DECLARE @previous_month CHAR(6) " +
                            " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                            " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
                           " select  emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date  from (" +

                            "select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date " +
                           "from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id )" +
                            "inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)  " +
                            "inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                            "left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                            "left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                            " where 1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL)" +
                            "and (DOL >=  '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)" +
                            ") ABC " +
                            "where  date <= cast( (Convert(varchar,  '" + Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)).Date.ToString("yyyy-MM-dd HH:mm") + "' ,103)) as datetime) and date >= cast ((convert(varchar, '" + Convert.ToDateTime(DateTime.ParseExact(FromDate, "dd/MM/yyyy", null)).Date.ToString("yyyy-MM-dd HH:mm") + "'  ,103)) as datetime) " +

                            "group by emp_id ,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName, date";

                }
                //sqlStr = " DECLARE @current_month CHAR(6) " +
                //        " DECLARE @previous_month CHAR(6) " +
                //        " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
                //        " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
                //        " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-2).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
                //         " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
                //        " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
                //        " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
                //    //   " where department_id=" + strDepartment1 + "  and  
                //       "where  1=1 " + strselectcriteria + "  and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
                //       " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)";
            }
        }
        ds1 = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
        return ds1;
    }
    public void InsertAttendence2(ArrayList ArrListEmp, ArrayList ArrListAtten, ArrayList ArrPreAtten, string AlistCreBy, DateTime AlistCreDate)
    {
        if (Date != "" && Date != null)
        {
            OleDbParameter[] paramGrid = new OleDbParameter[5];

            OleDbParameter[] paramGrid1 = new OleDbParameter[5];

            for (int i = 0; i <= ArrListEmp.Count - 1; i++)
            {

                string strSql = "";
                OleDbConnection conn = new OleDbConnection(con.ConnectionString);
                conn.Open();
                OleDbTransaction oledbTrans = conn.BeginTransaction();
                int k = 0;
                try
                {


                    strSql = " select count(emp_id) from DATILY_ATTENDANCE where [Date]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' and emp_id=" + ArrListEmp[i].ToString() + "";
                    k = Convert.ToInt32(OleDbHelper.ExecuteScalar(oledbTrans, CommandType.Text, strSql));

                    if (k == 0)
                    {
                        strSql = "insert into DATILY_ATTENDANCE (EMP_ID,[DATE],ATTENDANCE,CreateBy,CreateDate) values(?,?,?,?,?)";
                        paramGrid[0] = new OleDbParameter("@EMP_ID", OleDbType.VarChar);
                        paramGrid[0].Value = ArrListEmp[i].ToString();
                        paramGrid[1] = new OleDbParameter("@[DATE]", OleDbType.Date);
                        paramGrid[1].Value = System.DateTime.Now.ToShortDateString();
                        paramGrid[2] = new OleDbParameter("@ATTENDANCE", OleDbType.VarChar);
                        paramGrid[2].Value = ArrListAtten[i].ToString();
                        paramGrid[3] = new OleDbParameter("@CreateBy", OleDbType.VarChar);
                        paramGrid[3].Value = AlistCreBy.ToString();
                        paramGrid[4] = new OleDbParameter("@CreateDate", OleDbType.Date);
                        paramGrid[4].Value = System.DateTime.Now.ToShortDateString();
                        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, strSql, paramGrid);
                        Message = "Saved successfully !!!";
                    }
                    else
                    {
                        strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrListAtten[i].ToString() + "',CreateBy='" + AlistCreBy.ToString() + "',CreateDate='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' where    [Date]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' and emp_id=" + ArrListEmp[i].ToString() + " ";

                        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, strSql);
                        Message = "Updated successfully !!!";
                    }
                    oledbTrans.Commit();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    oledbTrans.Rollback();
                    conn.Close();
                    Message = ex.Message;
                }
                if (ColumnFlag == true)
                {
                    OleDbConnection conn1 = new OleDbConnection(con.ConnectionString);
                    conn.Open();
                    OleDbTransaction oledbTrans1 = conn.BeginTransaction();
                    try
                    {


                        if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() != "Sunday")
                        {
                            strSql = " select count(emp_id) from DATILY_ATTENDANCE where   [DATE]='" + System.DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy") + "'  and emp_id=" + ArrListEmp[i].ToString() + " ";
                        }
                        else
                            strSql = " select count(emp_id) from DATILY_ATTENDANCE where   [DATE]='" + System.DateTime.Now.AddDays(-2).ToString("dd-MMM-yyyy") + "'  and emp_id=" + ArrListEmp[i].ToString() + " ";
                        k = Convert.ToInt32(OleDbHelper.ExecuteScalar(oledbTrans1, CommandType.Text, strSql));

                        if (k == 0)
                        {
                            strSql = "insert into DATILY_ATTENDANCE (EMP_ID,[DATE],ATTENDANCE,CreateBy,CreateDate) values(?,?,?,?,?)";
                            paramGrid1[0] = new OleDbParameter("@EMP_ID", OleDbType.VarChar);
                            paramGrid1[0].Value = ArrListEmp[i].ToString();
                            paramGrid1[1] = new OleDbParameter("@[DATE]", OleDbType.Date);
                            paramGrid1[1].Value = System.DateTime.Now.ToShortDateString();
                            paramGrid1[3] = new OleDbParameter("@CreateBy", OleDbType.VarChar);
                            paramGrid1[3].Value = AlistCreBy.ToString();
                            paramGrid1[4] = new OleDbParameter("@CreateDate", OleDbType.Date);
                            paramGrid1[4].Value = System.DateTime.Now.ToShortDateString();
                            if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() != "Sunday")
                            {
                                paramGrid1[1].Value = System.DateTime.Now.AddDays(-1).ToShortDateString();
                            }
                            else
                                paramGrid1[1].Value = System.DateTime.Now.AddDays(-2).ToShortDateString();
                            paramGrid1[2] = new OleDbParameter("@ATTENDANCE", OleDbType.VarChar);
                            paramGrid1[2].Value = ArrPreAtten[i].ToString();
                            OleDbHelper.ExecuteNonQuery(oledbTrans1, CommandType.Text, strSql, paramGrid1);
                            Message = "Saved successfully !!!";
                        }
                        else
                        {
                            if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() != "Sunday")
                            {
                                strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrPreAtten[i].ToString() + "',CreateBy='" + AlistCreBy.ToString() + "',CreateDate='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' where   [DATE]>='" + System.DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy") + "' and [DATE]<'" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' AND EMP_ID=" + ArrListEmp[i].ToString() + " ";
                            }
                            else
                                strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrPreAtten[i].ToString() + "',CreateBy='" + AlistCreBy.ToString() + "',CreateDate='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' where   [DATE]>='" + System.DateTime.Now.AddDays(-2).ToString("dd-MMM-yyyy") + "' and [DATE]<'" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' AND EMP_ID=" + ArrListEmp[i].ToString() + " ";

                            OleDbHelper.ExecuteNonQuery(oledbTrans1, CommandType.Text, strSql);
                            Message = "Updated successfully !!!";
                        }
                        oledbTrans1.Commit();
                        conn1.Close();
                    }
                    catch (Exception ex)
                    {
                        oledbTrans1.Rollback();
                        conn1.Close();
                        Message = ex.Message;
                    }
                }
            }

        }
        else
        {

            OleDbParameter[] paramGrid = new OleDbParameter[5];

            OleDbParameter[] paramGrid1 = new OleDbParameter[5];

            for (int i = 0; i <= ArrListEmp.Count - 1; i++)
            {

                string strSql = "";
                OleDbConnection conn = new OleDbConnection(con.ConnectionString);
                conn.Open();
                OleDbTransaction oledbTrans = conn.BeginTransaction();
                int k = 0;
                try
                {


                    strSql = " select count(emp_id) from DATILY_ATTENDANCE where [Date]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' and emp_id=" + ArrListEmp[i].ToString() + "";
                    k = Convert.ToInt32(OleDbHelper.ExecuteScalar(oledbTrans, CommandType.Text, strSql));

                    if (k == 0)
                    {
                        strSql = "insert into DATILY_ATTENDANCE (EMP_ID,[DATE],ATTENDANCE,CreateBy,CreateDate) values(?,?,?,?,?)";
                        paramGrid[0] = new OleDbParameter("@EMP_ID", OleDbType.VarChar);
                        paramGrid[0].Value = ArrListEmp[i].ToString();
                        paramGrid[1] = new OleDbParameter("@[DATE]", OleDbType.Date);
                        paramGrid[1].Value = System.DateTime.Now.ToShortDateString();
                        paramGrid[2] = new OleDbParameter("@ATTENDANCE", OleDbType.VarChar);
                        paramGrid[2].Value = ArrListAtten[i].ToString();
                        paramGrid[3] = new OleDbParameter("@CreateBy", OleDbType.VarChar);
                        paramGrid[3].Value = AlistCreBy.ToString();
                        paramGrid[4] = new OleDbParameter("@CreateDate", OleDbType.Date);
                        paramGrid[4].Value = System.DateTime.Now.ToShortDateString();
                        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, strSql, paramGrid);
                        Message = "Saved successfully !!!";
                    }
                    else
                    {
                        strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrListAtten[i].ToString() + "',CreateBy='" + AlistCreBy.ToString() + "',CreateDate='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' where    [Date]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' and emp_id=" + ArrListEmp[i].ToString() + " ";

                        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, strSql);
                        Message = "Updated successfully !!!";
                    }
                    oledbTrans.Commit();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    oledbTrans.Rollback();
                    conn.Close();
                    Message = ex.Message;
                }
                if (ColumnFlag == true)
                {
                    OleDbConnection conn1 = new OleDbConnection(con.ConnectionString);
                    conn.Open();
                    OleDbTransaction oledbTrans1 = conn.BeginTransaction();
                    try
                    {


                        if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() != "Sunday")
                        {
                            strSql = " select count(emp_id) from DATILY_ATTENDANCE where   [DATE]='" + System.DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy") + "'  and emp_id=" + ArrListEmp[i].ToString() + " ";
                        }
                        else
                            strSql = " select count(emp_id) from DATILY_ATTENDANCE where   [DATE]='" + System.DateTime.Now.AddDays(-2).ToString("dd-MMM-yyyy") + "'  and emp_id=" + ArrListEmp[i].ToString() + " ";
                        k = Convert.ToInt32(OleDbHelper.ExecuteScalar(oledbTrans1, CommandType.Text, strSql));

                        if (k == 0)
                        {
                            strSql = "insert into DATILY_ATTENDANCE (EMP_ID,[DATE],ATTENDANCE,CreateBy,CreateDate) values(?,?,?,?,?)";
                            paramGrid1[0] = new OleDbParameter("@EMP_ID", OleDbType.VarChar);
                            paramGrid1[0].Value = ArrListEmp[i].ToString();
                            paramGrid1[1] = new OleDbParameter("@[DATE]", OleDbType.Date);
                            paramGrid1[1].Value = System.DateTime.Now.ToShortDateString();
                            paramGrid1[3] = new OleDbParameter("@CreateBy", OleDbType.VarChar);
                            paramGrid1[3].Value = AlistCreBy.ToString();
                            paramGrid1[4] = new OleDbParameter("@CreateDate", OleDbType.Date);
                            paramGrid1[4].Value = System.DateTime.Now.ToShortDateString();
                            if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() != "Sunday")
                            {
                                paramGrid1[1].Value = System.DateTime.Now.AddDays(-1).ToShortDateString();
                            }
                            else
                                paramGrid1[1].Value = System.DateTime.Now.AddDays(-2).ToShortDateString();
                            paramGrid1[2] = new OleDbParameter("@ATTENDANCE", OleDbType.VarChar);
                            paramGrid1[2].Value = ArrPreAtten[i].ToString();
                            OleDbHelper.ExecuteNonQuery(oledbTrans1, CommandType.Text, strSql, paramGrid1);
                            Message = "Saved successfully !!!";
                        }
                        else
                        {
                            if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() != "Sunday")
                            {
                                strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrPreAtten[i].ToString() + "',CreateBy='" + AlistCreBy.ToString() + "',CreateDate='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' where   [DATE]>='" + System.DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy") + "' and [DATE]<'" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' AND EMP_ID=" + ArrListEmp[i].ToString() + " ";
                            }
                            else
                                strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrPreAtten[i].ToString() + "',CreateBy='" + AlistCreBy.ToString() + "',CreateDate='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' where   [DATE]>='" + System.DateTime.Now.AddDays(-2).ToString("dd-MMM-yyyy") + "' and [DATE]<'" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' AND EMP_ID=" + ArrListEmp[i].ToString() + " ";

                            OleDbHelper.ExecuteNonQuery(oledbTrans1, CommandType.Text, strSql);
                            Message = "Updated successfully !!!";
                        }
                        oledbTrans1.Commit();
                        conn1.Close();
                    }
                    catch (Exception ex)
                    {
                        oledbTrans1.Rollback();
                        conn1.Close();
                        Message = ex.Message;
                    }
                }
            }
        }
    }

    public void InsertAttendence(ArrayList ArrListEmp, ArrayList ArrListAtten, ArrayList ArrPreAtten, string AlistCreBy, DateTime AlistCreDate, int p)
    {

        OleDbParameter[] paramGrid = new OleDbParameter[5];

        OleDbParameter[] paramGrid1 = new OleDbParameter[5];
        if ((ToDate == null || ToDate == "") && (FromDate == null || FromDate == ""))
        {
            for (int i = 0; i <= ArrListEmp.Count - 1; i++)
            {

                string strSql = "";
                //OleDbConnection conn = new OleDbConnection(con.ConnectionString);
                //conn.Open();
                //OleDbTransaction oledbTrans = conn.BeginTransaction();
                int k = 0;
                //try
                //{
                //    strSql = " select count(emp_id) from DATILY_ATTENDANCE where [Date]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' and emp_id=" + ArrListEmp[i].ToString() + "";
                //    k = Convert.ToInt32(OleDbHelper.ExecuteScalar(oledbTrans, CommandType.Text, strSql));

                //    if (k == 0)
                //    {
                //        strSql = "insert into DATILY_ATTENDANCE (EMP_ID,[DATE],ATTENDANCE,CreateBy,CreateDate) values(?,?,?,?,?)";
                //        paramGrid[0] = new OleDbParameter("@EMP_ID", OleDbType.VarChar);
                //        paramGrid[0].Value = ArrListEmp[i].ToString();
                //        paramGrid[1] = new OleDbParameter("@[DATE]", OleDbType.Date);
                //        paramGrid[1].Value = System.DateTime.Now.ToShortDateString();
                //        paramGrid[2] = new OleDbParameter("@ATTENDANCE", OleDbType.VarChar);
                //        paramGrid[2].Value = ArrListAtten[i].ToString();
                //        paramGrid[3] = new OleDbParameter("@CreateBy", OleDbType.VarChar);
                //        paramGrid[3].Value = AlistCreBy.ToString();
                //        paramGrid[4] = new OleDbParameter("@CreateDate", OleDbType.Date);
                //        paramGrid[4].Value = System.DateTime.Now.ToShortDateString();
                //        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, strSql, paramGrid);
                //        Message = "Saved successfully !!!";
                //    }
                //    else
                //    {
                //        strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrListAtten[i].ToString() + "',CreateBy='" + AlistCreBy.ToString() + "',CreateDate='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' where    [Date]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' and emp_id=" + ArrListEmp[i].ToString() + " ";

                //        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, strSql);
                //        Message = "Updated successfully !!!";
                //    }
                //    oledbTrans.Commit();
                //conn.Close();
                //}
                //catch (Exception ex)
                //{
                //    oledbTrans.Rollback();
                //    conn.Close();
                //    Message = ex.Message;
                //}
                if (ColumnFlag == true)
                {
                    OleDbConnection conn1 = new OleDbConnection(con.ConnectionString);
                    conn1.Open();
                    OleDbTransaction oledbTrans1 = conn1.BeginTransaction();
                    try
                    {
                        int s = p + 1;

                        //if (System.DateTime.Now.AddDays(-p).DayOfWeek.ToString() != "Sunday")
                        //{
                        strSql = " select count(emp_id) from DATILY_ATTENDANCE where   [DATE]='" + System.DateTime.Now.AddDays(-p).ToString("dd-MMM-yyyy") + "'  and emp_id=" + ArrListEmp[i].ToString() + " ";
                        //}
                        //else
                        //    strSql = " select count(emp_id) from DATILY_ATTENDANCE where   [DATE]='" + System.DateTime.Now.AddDays(-s).ToString("dd-MMM-yyyy") + "'  and emp_id=" + ArrListEmp[i].ToString() + " ";
                        k = Convert.ToInt32(OleDbHelper.ExecuteScalar(oledbTrans1, CommandType.Text, strSql));

                        if (k == 0)
                        {
                            strSql = "insert into DATILY_ATTENDANCE (EMP_ID,[DATE],ATTENDANCE,CreateBy,CreateDate) values(?,?,?,?,?)";
                            paramGrid1[0] = new OleDbParameter("@EMP_ID", OleDbType.VarChar);
                            paramGrid1[0].Value = ArrListEmp[i].ToString();
                            paramGrid1[1] = new OleDbParameter("@[DATE]", OleDbType.Date);
                            paramGrid1[1].Value = System.DateTime.Now.ToShortDateString();
                            paramGrid1[3] = new OleDbParameter("@CreateBy", OleDbType.VarChar);
                            paramGrid1[3].Value = AlistCreBy.ToString();
                            paramGrid1[4] = new OleDbParameter("@CreateDate", OleDbType.Date);
                            paramGrid1[4].Value = System.DateTime.Now.ToShortDateString();
                            //if (System.DateTime.Now.AddDays(-p).DayOfWeek.ToString() != "Sunday")
                            //{
                            paramGrid1[1].Value = System.DateTime.Now.AddDays(-p).ToShortDateString();
                            //}
                            //else
                            //    paramGrid1[1].Value = System.DateTime.Now.AddDays(-s).ToShortDateString();

                            paramGrid1[2] = new OleDbParameter("@ATTENDANCE", OleDbType.VarChar);
                            paramGrid1[2].Value = ArrListAtten[i].ToString();
                            OleDbHelper.ExecuteNonQuery(oledbTrans1, CommandType.Text, strSql, paramGrid1);
                            Message = "Saved successfully !!!";
                        }
                        else
                        {
                            //if (System.DateTime.Now.AddDays(-p).DayOfWeek.ToString() != "Sunday")
                            //{
                            strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrListAtten[i].ToString() + "',CreateBy='" + AlistCreBy.ToString() + "',CreateDate='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' where   [DATE]='" + System.DateTime.Now.AddDays(-p).ToString("dd-MMM-yyyy") + "' AND EMP_ID=" + ArrListEmp[i].ToString() + " ";
                            //}
                            //else
                            //    strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrPreAtten[i].ToString() + "',CreateBy='" + AlistCreBy.ToString() + "',CreateDate='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' where   [DATE]='" + System.DateTime.Now.AddDays(-s).ToString("dd-MMM-yyyy") + "' AND EMP_ID=" + ArrListEmp[i].ToString() + " ";

                            OleDbHelper.ExecuteNonQuery(oledbTrans1, CommandType.Text, strSql);
                            Message = "Updated successfully !!!";
                        }
                        oledbTrans1.Commit();
                        conn1.Close();
                    }
                    catch (Exception ex)
                    {
                        oledbTrans1.Rollback();
                        conn1.Close();
                        Message = ex.Message;
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i <= ArrListEmp.Count - 1; i++)
            {

                string strSql = "";
                //OleDbConnection conn = new OleDbConnection(con.ConnectionString);
                //conn.Open();
                //OleDbTransaction oledbTrans = conn.BeginTransaction();
                int k = 0;
                //try
                //{
                //    strSql = " select count(emp_id) from DATILY_ATTENDANCE where [Date]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' and emp_id=" + ArrListEmp[i].ToString() + "";
                //    k = Convert.ToInt32(OleDbHelper.ExecuteScalar(oledbTrans, CommandType.Text, strSql));

                //    if (k == 0)
                //    {
                //        strSql = "insert into DATILY_ATTENDANCE (EMP_ID,[DATE],ATTENDANCE,CreateBy,CreateDate) values(?,?,?,?,?)";
                //        paramGrid[0] = new OleDbParameter("@EMP_ID", OleDbType.VarChar);
                //        paramGrid[0].Value = ArrListEmp[i].ToString();
                //        paramGrid[1] = new OleDbParameter("@[DATE]", OleDbType.Date);
                //        paramGrid[1].Value = System.DateTime.Now.ToShortDateString();
                //        paramGrid[2] = new OleDbParameter("@ATTENDANCE", OleDbType.VarChar);
                //        paramGrid[2].Value = ArrListAtten[i].ToString();
                //        paramGrid[3] = new OleDbParameter("@CreateBy", OleDbType.VarChar);
                //        paramGrid[3].Value = AlistCreBy.ToString();
                //        paramGrid[4] = new OleDbParameter("@CreateDate", OleDbType.Date);
                //        paramGrid[4].Value = System.DateTime.Now.ToShortDateString();
                //        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, strSql, paramGrid);
                //        Message = "Saved successfully !!!";
                //    }
                //    else
                //    {
                //        strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrListAtten[i].ToString() + "',CreateBy='" + AlistCreBy.ToString() + "',CreateDate='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' where    [Date]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' and emp_id=" + ArrListEmp[i].ToString() + " ";

                //        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, strSql);
                //        Message = "Updated successfully !!!";
                //    }
                //    oledbTrans.Commit();
                //conn.Close();
                //}
                //catch (Exception ex)
                //{
                //    oledbTrans.Rollback();
                //    conn.Close();
                //    Message = ex.Message;
                //}
                if (ColumnFlag == true)
                {
                    OleDbConnection conn1 = new OleDbConnection(con.ConnectionString);
                    conn1.Open();
                    OleDbTransaction oledbTrans1 = conn1.BeginTransaction();
                    try
                    {
                        int s = p + 1;
                        //if (Convert.ToDateTime(ToDate).AddDays(-p).DayOfWeek.ToString() != "Sunday")
                        //// if (System.DateTime.Now.AddDays(-p).DayOfWeek.ToString() != "Sunday")
                        //{
                        strSql = " select count(emp_id) from DATILY_ATTENDANCE where   [DATE]='" + Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)).AddDays(-p).Date.ToString("yyyy-MM-dd HH:mm") + "'  and emp_id=" + ArrListEmp[i].ToString() + " ";
                        //}
                        //else
                        //    strSql = " select count(emp_id) from DATILY_ATTENDANCE where   [DATE]='" + Convert.ToDateTime(ToDate).AddDays(-s).ToString("yyyy-MM-dd HH:mm") + "'  and emp_id=" + ArrListEmp[i].ToString() + " ";
                        k = Convert.ToInt32(OleDbHelper.ExecuteScalar(oledbTrans1, CommandType.Text, strSql));

                        if (k == 0)
                        {
                            strSql = "insert into DATILY_ATTENDANCE (EMP_ID,[DATE],ATTENDANCE,CreateBy,CreateDate) values(?,?,?,?,?)";
                            paramGrid1[0] = new OleDbParameter("@EMP_ID", OleDbType.VarChar);
                            paramGrid1[0].Value = ArrListEmp[i].ToString();
                            paramGrid1[1] = new OleDbParameter("@[DATE]", OleDbType.Date);
                            paramGrid1[1].Value = Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)).AddDays(-p).Date.ToString("yyyy-MM-dd HH:mm");
                            paramGrid1[3] = new OleDbParameter("@CreateBy", OleDbType.VarChar);
                            paramGrid1[3].Value = AlistCreBy.ToString();
                            paramGrid1[4] = new OleDbParameter("@CreateDate", OleDbType.Date);
                            paramGrid1[4].Value = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                            //if (Convert.ToDateTime(ToDate).AddDays(-p).Date.DayOfWeek.ToString("yyyy-MM-dd HH:mm:SS") != "Sunday")
                            //{
                            paramGrid1[1].Value = Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)).AddDays(-p).Date.ToString("yyyy-MM-dd HH:mm");
                            //}
                            //else
                            //    paramGrid1[1].Value = Convert.ToDateTime(ToDate).AddDays(-s).Date.ToString("yyyy-MM-dd HH:mm");

                            paramGrid1[2] = new OleDbParameter("@ATTENDANCE", OleDbType.VarChar);
                            paramGrid1[2].Value = ArrListAtten[i].ToString();
                            OleDbHelper.ExecuteNonQuery(oledbTrans1, CommandType.Text, strSql, paramGrid1);
                            Message = "Saved successfully !!!";
                        }
                        else
                        {
                            //if (Convert.ToDateTime(ToDate).AddDays(-p).Date.DayOfWeek.ToString() != "Sunday")
                            //{
                            strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrListAtten[i].ToString() + "',CreateBy='" + AlistCreBy.ToString() + "',CreateDate='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' where   [DATE]='" + Convert.ToDateTime(DateTime.ParseExact(ToDate, "dd/MM/yyyy", null)).AddDays(-p).Date.ToString("yyyy-MM-dd HH:mm") + "' AND EMP_ID=" + ArrListEmp[i].ToString() + " ";
                            //}
                            //else
                            //    strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrPreAtten[i].ToString() + "',CreateBy='" + AlistCreBy.ToString() + "',CreateDate='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' where   [DATE]='" + Convert.ToDateTime(ToDate).AddDays(-s).ToString("yyyy-MM-dd HH:mm") + "' AND EMP_ID=" + ArrListEmp[i].ToString() + " ";

                            OleDbHelper.ExecuteNonQuery(oledbTrans1, CommandType.Text, strSql);
                            Message = "Updated successfully !!!";
                        }
                        oledbTrans1.Commit();
                        conn1.Close();
                    }
                    catch (Exception ex)
                    {
                        oledbTrans1.Rollback();
                        conn1.Close();
                        Message = ex.Message;
                    }
                }
            }
        }
    }

    public DataSet GetHier()
    {
        DataSet ds = new DataSet();
        string strSql = "";
        strSql = " select cm.CENTRE_NAME,clm.cluster_name,SubCentreName from  centre_master cm " +
                        " inner join SubCentreMaster scb on(cm.CENTRE_ID=scb.CentreId) " +
                        " inner join cluster_master clm on(clm.cluster_id=cm.cluster_id) where SubCentreId = " + SubCentreID + " ";
        if (SubCentreID == "" || SubCentreID == null)
        {
            strSql = " select cm.CENTRE_NAME,clm.cluster_name from  centre_master cm " +

                          " inner join cluster_master clm on(clm.cluster_id=cm.cluster_id) where centre_id = " + CentreID + " ";
        }
        ds = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, strSql);
        return ds;
    }

    public void UpdateAttendaceByHO(ArrayList ArrListEmp, ArrayList ArrListAtten, string Date, string AlistCreBy, DateTime AlistCreDate, string AlistModBy, DateTime AlistModDate)
    {
        OleDbConnection conn = new OleDbConnection(con.ConnectionString);
        conn.Open();
        OleDbTransaction oledbTrans = conn.BeginTransaction();
        OleDbParameter[] paramGrid = new OleDbParameter[7];
        string strSql = "";

        try
        {
            for (int i = 0; i <= ArrListEmp.Count - 1; i++)
            {
                strSql = " select count(da.emp_id) from DATILY_ATTENDANCE DA  inner join employee_master em on (em.emp_id=da.emp_id) where   [DATE]='" + Date + "' and SUBCENTRE_ID=" + SubCentreID + " and da.emp_id='" + ArrListEmp[i].ToString() + "'";
                int k = (int)OleDbHelper.ExecuteScalar(oledbTrans, CommandType.Text, strSql);
                if (k != 0)
                {
                    strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrListAtten[i].ToString() + "',ModifyBy='" + AlistModBy.ToString() + "',ModifyDate='" + System.DateTime.Now.ToShortDateString() + "' where [DATE]='" + Date + "' AND EMP_ID=" + ArrListEmp[i].ToString() + "  ";
                    OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, strSql);
                    Message = "Updated successfully !!!";
                }
                else
                {
                    strSql = "insert into DATILY_ATTENDANCE (EMP_ID,[DATE],ATTENDANCE,CreateBy,CreateDate,ModifyBy,ModifyDate) values(?,?,?,?,?,?,?)";
                    paramGrid[0] = new OleDbParameter("@EMP_ID", OleDbType.VarChar);
                    paramGrid[0].Value = ArrListEmp[i].ToString();
                    paramGrid[1] = new OleDbParameter("@[DATE]", OleDbType.VarChar);
                    paramGrid[1].Value = Date;
                    paramGrid[2] = new OleDbParameter("@ATTENDANCE", OleDbType.VarChar);
                    paramGrid[2].Value = ArrListAtten[i].ToString();
                    paramGrid[3] = new OleDbParameter("@ModifyBy", OleDbType.VarChar);
                    paramGrid[3].Value = AlistModBy.ToString();
                    paramGrid[4] = new OleDbParameter("@ModifyDate", OleDbType.Date);
                    paramGrid[4].Value = System.DateTime.Now.ToShortDateString();
                    paramGrid[5] = new OleDbParameter("@CreateBy", OleDbType.VarChar);
                    paramGrid[5].Value = AlistCreBy.ToString();
                    paramGrid[6] = new OleDbParameter("@CreateDate", OleDbType.Date);
                    paramGrid[6].Value = System.DateTime.Now.ToShortDateString();
                    OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, strSql, paramGrid);
                    Message = "Saved successfully !!!";
                }


            }
            oledbTrans.Commit();
            conn.Close();

        }
        catch (Exception ex)
        {
            oledbTrans.Rollback();
            conn.Close();
            Message = ex.Message;
        }
    }
}

//using System;
//using System.Data;
//using System.Configuration;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;
//using System.Data.OleDb;
//using System.Collections;
//using System.Collections.Generic;

///// <summary>
///// Summary description for DAT_ENTRY
///// </summary>
//public class DAT_ENTRY
//{
//    CCommon con = new CCommon();
//    DataSet ds = new DataSet();

//    bool bColumnFlag;
//    public bool ColumnFlag
//    {
//        get { return bColumnFlag; }
//        set { bColumnFlag = value; }
//    }
//    string strMessage;
//    public string Message
//    {
//        get { return strMessage; }
//        set { strMessage = value; }
//    }

//    string strSubCentreID;
//    public string SubCentreID
//    {
//        get { return strSubCentreID; }
//        set { strSubCentreID = value; }
//    }

//    string strCentreID;
//    public string CentreID
//    {
//        get { return strCentreID; }
//        set { strCentreID = value; }
//    }

//    string strClusterID;
//    public string ClusterID
//    {
//        get { return strClusterID; }
//        set { strClusterID = value; }
//    }
//    private string strEMPCODE;
//    public string EMPCODE
//    {
//        get { return strEMPCODE; }
//        set { strEMPCODE = value; }
//    }

//    private string strDepartment1;
//    public string Department1
//    {
//        get { return strDepartment1; }
//        set { strDepartment1 = value; }
//    }

//    private string strEMPNAME;
//    public string EMPNAME
//    {
//        get { return strEMPNAME; }
//        set { strEMPNAME = value; }
//    }
//    private string strEMP_ID;
//    public string Emp_ID
//    {
//        get { return strEMP_ID; }
//        set { strEMP_ID = value; }
//    }
//    private string _fromdate;
//    public string FromDate
//    {
//        get { return _fromdate; }
//        set { _fromdate = value; }
//    }
//    private string _Todate;
//    public string ToDate
//    {
//        get { return _Todate; }
//        set { _Todate = value; }
//    }
//    private string strRSM_EMPCode;
//    public string RSM_EMPCode
//    {
//        get { return strRSM_EMPCode; }
//        set { strRSM_EMPCode = value; }
//    }
//    private List<string> _RM;
//    public List<string> RM
//    {
//        get { return _RM; }
//        set { _RM = value; }
//    }

//    private List<string> _RSM;
//    public List<string> RSM
//    {
//        get { return _RSM; }
//        set { _RSM = value; }
//    }

//    private string strAdmin;
//    public string Admin_EMPCODE
//    {
//        get { return strAdmin; }
//        set { strAdmin = value; }
//    }

//    private string StrDate;
//    public string Date
//    {
//        get { return StrDate; }
//        set { StrDate = value; }
//    }
//    public DAT_ENTRY()
//    {

//    }
//    //public DataSet Fill_Grid()
//    //{
//    //    DataSet ds1 = new DataSet();
//    //    string sqlStr = "";

//    //    string strselectcriteria = "";


//    //    string strselectcriteria1 = "";

//    //    string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
//    //    string str = strTime.Remove(2);
//    //    string str1 = strTime.Remove(0, 3);

//    //    //if ((Convert.ToInt32(str) <= 24) && (Convert.ToInt32(str1) > 00))
//    //    //{
//    //    //    strselectcriteria1 = "And Shift='First Shift'";
//    //    //}
//    //    //if ((Convert.ToInt32(str) >= 24) && (Convert.ToInt32(str1) > 00))
//    //    //{
//    //    //    strselectcriteria1 = "And Shift='Second Shift'";
//    //    //}
//    //    if ((CentreID == "10172") && (Convert.ToInt32(str) <= 24) && (Convert.ToInt32(str1) > 00))
//    //    {
//    //        strselectcriteria1 = "And Shift='First Shift'";
//    //    }


//    //    if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0")
//    //    {
//    //        strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "'";

//    //    }
//    //    if (SubCentreID == "0" && CentreID != "0" && ClusterID != "0")
//    //    {
//    //        strselectcriteria = " and EM.centre_id='" + CentreID + "'  and cm.cluster_id='" + ClusterID + "'";
//    //    }
//    //    if (SubCentreID == "0" && CentreID == "0" && ClusterID != "0")
//    //    {
//    //        strselectcriteria = "  and cm.cluster_id='" + ClusterID + "'";
//    //    }
//    //    if (SubCentreID != "0" && CentreID == "0" && ClusterID != "0")
//    //    {
//    //        strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
//    //    }
//    //    if (SubCentreID != "0" && CentreID != "0" && ClusterID == "0")
//    //    {
//    //        strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
//    //    }
//    //    if (EMPCODE != null)
//    //    {
//    //        strselectcriteria += " and em.emp_code='" + EMPCODE + "'";
//    //    }
//    //    if (EMPNAME != null)
//    //    {
//    //        strselectcriteria += " and ( ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '') like '%" + EMPNAME + "%') ";
//    //    }
//    //    if (DateTime.Now.Day <= 24)
//    //    {
//    //        sqlStr = " DECLARE @current_month CHAR(6) " +
//    //                " DECLARE @previous_month CHAR(6) " +
//    //                " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//    //                " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
//    //                " select  distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(FIRSTNAME +' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) AS Pamecian, " +
//    //                " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM  " +
//    //                " left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//    //                " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//    //                //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
//    //                //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//    //                " Inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//    //                " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
//    //                " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//    //                " where department_id=" + strDepartment1 + "  and  1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
//    //                " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)";
//    //    }
//    //    else
//    //    {
//    //        sqlStr = " DECLARE @current_month CHAR(6) " +
//    //               " DECLARE @previous_month CHAR(6) " +
//    //               " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//    //               " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
//    //               " select  distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(FIRSTNAME +' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) AS Pamecian, " +
//    //               " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM  " +
//    //               " left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//    //               " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//    //                //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
//    //                //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//    //                " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//    //               " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
//    //               " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//    //               " where department_id=" + strDepartment1 + "  and  1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and cm.cluster_id='" + ClusterID + "' and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
//    //               " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)";
//    //    }
//    //    ds = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
//    //    if (ds.Tables[0].Rows.Count == 0)
//    //    {
//    //        if (DateTime.Now.Day <= 24)
//    //        {
//    //            sqlStr = " DECLARE @current_month CHAR(6) " +
//    //                      " DECLARE @previous_month CHAR(6) " +
//    //                      " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//    //                      " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
//    //                      " select distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) " +
//    //                      " AS Pamecian,DE.ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master  EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id) inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)" +
//    //                       " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//    //                                    //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
//    //                                      //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//    //                      " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//    //                      " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//    //                      " where department_id=" + strDepartment1 + "  and  1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
//    //                     " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and  DOJ<=CAST(@previous_month + '21' AS datetime)";
//    //        }
//    //        else
//    //        {
//    //            sqlStr = " DECLARE @current_month CHAR(6) " +
//    //                     " DECLARE @previous_month CHAR(6) " +
//    //                     " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//    //                     " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
//    //                     " select distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) " +
//    //                     " AS Pamecian,DE.ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id) inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)" +
//    //                      " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//    //                      //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
//    //                        //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//    //                     " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//    //                     " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//    //                     " where department_id=" + strDepartment1 + "  and  1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
//    //                    " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and  DOJ<=CAST(@current_month + '21' AS datetime)";
//    //        }
//    //        ds1 = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
//    //    }
//    //    if (ds.Tables[0].Rows.Count != 0)
//    //    { 
//    //    return ds;
//    //    }
//    //    else
//    //    return ds1;
//    //}

//    //add by rani
//    //21-03-2016
//    //public DataSet Fill_Grid()
//    //{
//    //    DataSet ds1 = new DataSet();
//    //    string sqlStr = "";

//    //    string strselectcriteria = "";


//    //    string strselectcriteria1 = "";

//    //    string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
//    //    string str = strTime.Remove(2);
//    //    string str1 = strTime.Remove(0, 3);

//    //    //if ((Convert.ToInt32(str) <= 24) && (Convert.ToInt32(str1) > 00))
//    //    //{
//    //    //    strselectcriteria1 = "And Shift='First Shift'";
//    //    //}
//    //    //if ((Convert.ToInt32(str) >= 24) && (Convert.ToInt32(str1) > 00))
//    //    //{
//    //    //    strselectcriteria1 = "And Shift='Second Shift'";
//    //    //}
//    //    if ((CentreID == "10172") && (Convert.ToInt32(str) <= 24) && (Convert.ToInt32(str1) > 00))
//    //    {
//    //        strselectcriteria1 = "And Shift='First Shift'";
//    //    }


//    //    if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0" &&  Emp_ID=="" )
//    //    {
//    //        strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "'";

//    //    }
//    //    else if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0" && Emp_ID == "0")
//    //    {
//    //        strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "'";

//    //    }
//    //    else if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0" && Emp_ID != "" && Emp_ID != null && Emp_ID != "0")
//    //    {
//    //        strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "' and  em.Rm_empcode='" + Emp_ID + "'";

//    //    }

//    //    else if (SubCentreID == "0" && CentreID != "0" && ClusterID != "0" && Emp_ID != "" && Emp_ID != null && Emp_ID != "0")
//    //    {
//    //        strselectcriteria = " and EM.centre_id='" + CentreID + "' and cm.cluster_id='" + ClusterID + "' and  em.Rm_empcode='" + Emp_ID + "'";

//    //    }
//    //    else if (SubCentreID == "0" && CentreID == "0" && ClusterID != "0" && Emp_ID != "" && Emp_ID != null && Emp_ID!="0")
//    //    {
//    //        strselectcriteria = "  and cm.cluster_id='" + ClusterID + "' and  em.Rm_empcode='" + Emp_ID + "'";

//    //    }
//    //    else if ( RM!=null && SubCentreID == "0" && CentreID == "0" && ClusterID != "0" && RM.Count != 0 && Emp_ID == "0" && RSM.Count== 0)
//    //    {
//    //        strselectcriteria = " and cm.cluster_id='" + ClusterID + "' and ( em.Rm_empcode in ( ";
//    //        for (int a = 0; a < RM.Count; a++)
//    //        {
//    //            strselectcriteria += " '" + RM[a].Substring(0, 7).ToString() + "'";
//    //            if (a != RM.Count - 1) 
//    //            strselectcriteria += ",";
//    //            if (a == RM.Count - 1)
//    //            {

//    //                strselectcriteria += "  )  ) ";
//    //            }
//    //        }
//    //    }
//    //    else if (RM != null && SubCentreID == "0" && CentreID == "0" && ClusterID != "0" && RM.Count != 0 && Emp_ID == "0" && RSM.Count != 0)
//    //    {
//    //        if (RSM_EMPCode == "0")
//    //        {
//    //            strselectcriteria = " and cm.cluster_id='" + ClusterID + "' and ( em.Rm_empcode in ( ";
//    //            for (int a = 0; a < RM.Count; a++)
//    //            {
//    //                strselectcriteria += " '" + RM[a].Substring(0, 7).ToString() + "'";
//    //                if (a != RM.Count - 1)
//    //                    strselectcriteria += ",";
//    //                if (a == RM.Count - 1)
//    //                {

//    //                    strselectcriteria += "  )  ) ";
//    //                }
//    //            }

//    //        }
//    //        else
//    //        {
//    //            strselectcriteria = "and em.RSM_empcode='" + RSM_EMPCode + "'  and cm.cluster_id='" + ClusterID + "' and ( em.Rm_empcode in ( ";
//    //            for (int a = 0; a < RM.Count; a++)
//    //            {
//    //                strselectcriteria += " '" + RM[a].Substring(0, 7).ToString() + "'";
//    //                if (a != RM.Count - 1)
//    //                    strselectcriteria += ",";
//    //                if (a == RM.Count - 1)
//    //                {

//    //                    strselectcriteria += "  )  ) ";
//    //                }
//    //            }

//    //        }


//    //    }

//    //    else
//    //    {
//    //        strselectcriteria = "  and cm.cluster_id='" + ClusterID + "' ";
//    //    }

//    //    //if (SubCentreID == "0" && CentreID == "0" && ClusterID != "0" && RM.Count != 0 && Emp_ID == "0")
//    //    //{
//    //    //    strselectcriteria = " and cm.cluster_id='" + ClusterID + "' and ( em.Rm_empcode in ( ";
//    //    //    for (int a = 0; a < RM.Count; a++)
//    //    //    {
//    //    //        strselectcriteria += " '" + RM[a].Substring(0, 7).ToString() + "'";
//    //    //        if (a != RM.Count - 1) 
//    //    //        strselectcriteria += ",";
//    //    //        if (a == RM.Count - 1)
//    //    //        {

//    //    //            strselectcriteria += "  )  ) ";
//    //    //        }
//    //    //    }
//    //    //}



//    //    //if (SubCentreID == "0" && CentreID != "0" && ClusterID != "0")
//    //    //{
//    //    //    strselectcriteria = " and EM.centre_id='" + CentreID + "'  and cm.cluster_id='" + ClusterID + "'";
//    //    //}
//    //    //if (SubCentreID == "0" && CentreID == "0" && ClusterID != "0")
//    //    //{
//    //    //    strselectcriteria = "  and cm.cluster_id='" + ClusterID + "'";
//    //    //}
//    //    if (SubCentreID != "0" && CentreID == "0" && ClusterID != "0")
//    //    {
//    //        strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
//    //    }
//    //    if (SubCentreID != "0" && CentreID != "0" && ClusterID == "0")
//    //    {
//    //        strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
//    //    }
//    //    if (EMPCODE != null)
//    //    {
//    //        strselectcriteria += " and em.emp_code='" + EMPCODE + "'";
//    //    }
//    //    if (EMPNAME != null)
//    //    {
//    //        strselectcriteria += " and ( ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '') like '%" + EMPNAME + "%') ";
//    //    }
//    //    if (DateTime.Now.Day <= 24)
//    //    {
//    //        sqlStr = " DECLARE @current_month CHAR(6) " +
//    //                " DECLARE @previous_month CHAR(6) " +
//    //                " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//    //                " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
//    //                " select  distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(Fullname +' ', '')) AS Pamecian, " + //(ISNULL(FIRSTNAME +' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) AS Pamecian, " +
//    //                " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,Centre_name,SubcentreName from employee_master EM  " +
//    //               // " left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE] ='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//    //               " left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "')  " +
//    //                " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//    //            //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
//    //            //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//    //                " Inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//    //                " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
//    //                " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//    //            //" where department_id=" + strDepartment1 +and
//    //                " where   1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
//    //                " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)";
//    //    }
//    //    else
//    //    {
//    //        sqlStr = " DECLARE @current_month CHAR(6) " +
//    //               " DECLARE @previous_month CHAR(6) " +
//    //               " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//    //               " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
//    //               " select  distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(Fullname +' ', '')) AS Pamecian, " +// +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) AS Pamecian, " +
//    //               " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,Centre_name,SubcentreName from employee_master EM  " +
//    //               " left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//    //               " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//    //            //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
//    //            //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//    //                " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//    //               " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
//    //               " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//    //            // " where department_id=" + strDepartment1 + "  and 
//    //                 " where 1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and cm.cluster_id='" + ClusterID + "' and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
//    //               " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)";
//    //    }
//    //    ds = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
//    //    if (ds.Tables[0].Rows.Count == 0)
//    //    {
//    //        if (DateTime.Now.Day <= 24)
//    //        {
//    //            sqlStr = " DECLARE @current_month CHAR(6) " +
//    //                      " DECLARE @previous_month CHAR(6) " +
//    //                      " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//    //                      " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
//    //                      " select distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(Fullname +' ', '')) AS Pamecian, " +//(ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) " +
//    //                      "DE.ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName from employee_master  EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id) inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)" +
//    //                       " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//    //                //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
//    //                //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//    //                      " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//    //                      " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//    //                //" where department_id=" + strDepartment1 + "  and 
//    //                     " where   1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
//    //                     " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and  DOJ<=CAST(@previous_month + '21' AS datetime)";
//    //        }
//    //        else
//    //        {
//    //            sqlStr = " DECLARE @current_month CHAR(6) " +
//    //                     " DECLARE @previous_month CHAR(6) " +
//    //                     " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//    //                     " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
//    //                     " select distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(Fullname +' ', '')) AS Pamecian, " +//(ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) " +
//    //                     " DE.ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id) inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)" +
//    //                      " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//    //                //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
//    //                //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//    //                     " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//    //                     " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//    //                //" where department_id=" + strDepartment1 + "  and  
//    //                     " where 1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
//    //                    " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and  DOJ<=CAST(@current_month + '21' AS datetime)";
//    //        }
//    //        ds1 = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
//    //    }
//    //    if (ds.Tables[0].Rows.Count != 0)
//    //    {
//    //        return ds;
//    //    }
//    //    else
//    //        return ds1;
//    //}
//    public DataSet Fill_Grid1()
//    {
//        DataSet ds1 = new DataSet();
//        string sqlStr = "";

//        string strselectcriteria = "";


//        string strselectcriteria1 = "";

//        string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
//        string str = strTime.Remove(2);
//        string str1 = strTime.Remove(0, 3);

//        //if ((Convert.ToInt32(str) <= 24) && (Convert.ToInt32(str1) > 00))
//        //{
//        //    strselectcriteria1 = "And Shift='First Shift'";
//        //}
//        //if ((Convert.ToInt32(str) >= 24) && (Convert.ToInt32(str1) > 00))
//        //{
//        //    strselectcriteria1 = "And Shift='Second Shift'";
//        //}
//        if ((CentreID == "10172") && (Convert.ToInt32(str) <= 24) && (Convert.ToInt32(str1) > 00))
//        {
//            strselectcriteria1 = "And Shift='First Shift'";
//        }
//        if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0" && Emp_ID == "")
//        {
//            strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "'";

//        }
//        else if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0" && Emp_ID == "0")
//        {
//            strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "'";

//        }
//        else if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0" && Emp_ID != "" && Emp_ID != null && Emp_ID != "0")
//        {
//            strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "' and  em.Rm_empcode='" + Emp_ID + "'";

//        }

//        else if (SubCentreID == "0" && CentreID != "0" && ClusterID != "0" && Emp_ID != "" && Emp_ID != null && Emp_ID != "0")
//        {
//            strselectcriteria = " and EM.centre_id='" + CentreID + "' and cm.cluster_id='" + ClusterID + "' and  em.Rm_empcode='" + Emp_ID + "'";

//        }
//        else if (SubCentreID == "0" && CentreID == "0" && ClusterID != "0" && Emp_ID != "" && Emp_ID != null && Emp_ID != "0")
//        {
//            strselectcriteria = "  and cm.cluster_id='" + ClusterID + "' and  em.Rm_empcode='" + Emp_ID + "'";

//        }
//        else if (RM != null && SubCentreID == "0" && CentreID == "0" && ClusterID != "0" && RM.Count != 0 && Emp_ID == "0" && RSM.Count == 0)
//        {
//            strselectcriteria = " and cm.cluster_id='" + ClusterID + "' and ( em.Rm_empcode in ( ";
//            for (int a = 0; a < RM.Count; a++)
//            {
//                strselectcriteria += " '" + RM[a].Substring(0, 7).ToString() + "'";
//                if (a != RM.Count - 1)
//                    strselectcriteria += ",";
//                if (a == RM.Count - 1)
//                {

//                    strselectcriteria += "  )  ) ";
//                }
//            }
//        }
//        else if (RM != null && SubCentreID == "0" && CentreID == "0" && ClusterID != "0" && RM.Count != 0 && Emp_ID == "0" && RSM.Count != 0)
//        {
//            if (RSM_EMPCode == "0")
//            {
//                strselectcriteria = " and cm.cluster_id='" + ClusterID + "' and ( em.Rm_empcode in ( ";
//                for (int a = 0; a < RM.Count; a++)
//                {
//                    strselectcriteria += " '" + RM[a].Substring(0, 7).ToString() + "'";
//                    if (a != RM.Count - 1)
//                        strselectcriteria += ",";
//                    if (a == RM.Count - 1)
//                    {

//                        strselectcriteria += "  )  ) ";
//                    }
//                }

//            }
//            else
//            {
//                strselectcriteria = "and em.RSM_empcode='" + RSM_EMPCode + "'  and cm.cluster_id='" + ClusterID + "' and ( em.Rm_empcode in ( ";
//                for (int a = 0; a < RM.Count; a++)
//                {
//                    strselectcriteria += " '" + RM[a].Substring(0, 7).ToString() + "'";
//                    if (a != RM.Count - 1)
//                        strselectcriteria += ",";
//                    if (a == RM.Count - 1)
//                    {

//                        strselectcriteria += "  )  ) ";
//                    }
//                }

//            }


//        }


//        else
//        {
//            strselectcriteria = "  and cm.cluster_id='" + ClusterID + "' ";
//        }

//        //if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0")
//        //{
//        //    strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "'";

//        //}
//        //if (SubCentreID == "0" && CentreID != "0" && ClusterID != "0")
//        //{
//        //    strselectcriteria = " and EM.centre_id='" + CentreID + "'  and cm.cluster_id='" + ClusterID + "'";
//        //}
//        //if (SubCentreID == "0" && CentreID == "0" && ClusterID != "0")
//        //{
//        //    strselectcriteria = "  and cm.cluster_id='" + ClusterID + "'";
//        //}
//        if (SubCentreID != "0" && CentreID == "0" && ClusterID != "0")
//        {
//            strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
//        }
//        if (SubCentreID != "0" && CentreID != "0" && ClusterID == "0")
//        {
//            strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
//        }
//        if (EMPCODE != null)
//        {
//            strselectcriteria += " and em.emp_code='" + EMPCODE + "'";
//        }
//        if (EMPNAME != null)
//        {
//            strselectcriteria += " and ( ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '') like '%" + EMPNAME + "%') ";
//        }
//        if (DateTime.Now.Day <= 24)
//        {
//            if (Date == "")
//                sqlStr = " DECLARE @current_month CHAR(6) " +
//                        " DECLARE @previous_month CHAR(6) " +
//                        " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                        " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
//                        " select  distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(FULLNAME +' ', ''))AS Pamecian, " +//(ISNULL(FIRSTNAME +' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) AS Pamecian, " +
//                        " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM  " +
//                        " left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//                        " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//                    //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
//                    //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//                        " Inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                        " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
//                        " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                    //" where department_id=" + strDepartment1 +and
//                        " where   1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
//                        " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)";
//            else
//            {
//                sqlStr = " DECLARE @current_month CHAR(6) " +
//                       " DECLARE @previous_month CHAR(6) " +
//                       " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                       " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
//                       " select  distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(FULLNAME +' ', ''))AS Pamecian, " +//(ISNULL(FIRSTNAME +' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) AS Pamecian, " +
//                       " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM  " +
//                       " left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + Convert.ToDateTime(Date).ToString("dd-MMM-yyyy") + "') " +
//                       " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//                    //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
//                    //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//                       " Inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                       " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
//                       " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                    //" where department_id=" + strDepartment1 +and
//                       " where   1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
//                       " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)";
//            }
//        }
//        else
//        {
//            if (Date == "")
//                sqlStr = " DECLARE @current_month CHAR(6) " +
//                       " DECLARE @previous_month CHAR(6) " +
//                       " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                       " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
//                       " select  distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(FULLNAME +' ', ''))AS Pamecian, " +//(ISNULL(FIRSTNAME +' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) AS Pamecian, " +
//                       " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM  " +
//                       " left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//                       " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//                    //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
//                    //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//                        " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                       " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
//                       " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                    // " where department_id=" + strDepartment1 + "  and 
//                         " where 1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and cm.cluster_id='" + ClusterID + "' and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
//                       " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)";
//            else
//            {
//                sqlStr = " DECLARE @current_month CHAR(6) " +
//                      " DECLARE @previous_month CHAR(6) " +
//                      " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                      " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
//                      " select  distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(FULLNAME +' ', ''))AS Pamecian, " +//(ISNULL(FIRSTNAME +' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) AS Pamecian, " +
//                      " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM  " +
//                      " left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + Convert.ToDateTime(Date).ToString("dd-MMM-yyyy") + "') " +
//                      " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//                    //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
//                    //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//                       " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                      " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
//                      " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                    // " where department_id=" + strDepartment1 + "  and 
//                        " where 1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and cm.cluster_id='" + ClusterID + "' and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
//                      " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)";
//            }
//        }
//        ds = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
//        if (ds.Tables[0].Rows.Count == 0)
//        {
//            if (DateTime.Now.Day <= 24)
//            {
//                sqlStr = " DECLARE @current_month CHAR(6) " +
//                          " DECLARE @previous_month CHAR(6) " +
//                          " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                          " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
//                          " select distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(FULLNAME +' ', ''))AS Pamecian, " +//(ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) " +
//                          " AS Pamecian,DE.ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master  EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id) inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)" +
//                           " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                    //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
//                    //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//                          " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//                          " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                    //" where department_id=" + strDepartment1 + "  and 
//                         " where   1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
//                         " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and  DOJ<=CAST(@previous_month + '21' AS datetime)";
//            }
//            else
//            {
//                sqlStr = " DECLARE @current_month CHAR(6) " +
//                         " DECLARE @previous_month CHAR(6) " +
//                         " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                         " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
//                         " select distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(FULLNAME +' ', ''))AS Pamecian, " +//(ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) " +
//                         " AS Pamecian,DE.ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id) inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)" +
//                          " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                    //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
//                    //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//                         " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//                         " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                    //" where department_id=" + strDepartment1 + "  and  
//                         " where 1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
//                        " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and  DOJ<=CAST(@current_month + '21' AS datetime)";
//            }
//            ds1 = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
//        }
//        if (ds.Tables[0].Rows.Count != 0)
//        {
//            return ds;
//        }
//        else
//            return ds1;
//    }

//    public DataSet Fill_Grid()
//    {
//        DataSet ds1 = new DataSet();
//        string sqlStr = "";

//        string strselectcriteria = "";


//        string strselectcriteria1 = "";

//        string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
//        string str = strTime.Remove(2);
//        string str1 = strTime.Remove(0, 3);

//        //if ((Convert.ToInt32(str) <= 24) && (Convert.ToInt32(str1) > 00))
//        //{
//        //    strselectcriteria1 = "And Shift='First Shift'";
//        //}
//        //if ((Convert.ToInt32(str) >= 24) && (Convert.ToInt32(str1) > 00))
//        //{
//        //    strselectcriteria1 = "And Shift='Second Shift'";
//        //}
//        if ((CentreID == "10172") && (Convert.ToInt32(str) <= 24) && (Convert.ToInt32(str1) > 00))
//        {
//            strselectcriteria1 = "And Shift='First Shift'";
//        }


//        if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0" && Emp_ID == "")
//        {
//            strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "'";

//        }
//        else if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0" && Emp_ID == "0")
//        {
//            strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "'";

//        }
//        else if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0" && Emp_ID != "" && Emp_ID != null && Emp_ID != "0")
//        {
//            strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "' and  em.Rm_empcode='" + Emp_ID + "'";

//        }

//        else if (SubCentreID == "0" && CentreID != "0" && ClusterID != "0" && Emp_ID != "" && Emp_ID != null && Emp_ID != "0")
//        {
//            strselectcriteria = " and EM.centre_id='" + CentreID + "' and cm.cluster_id='" + ClusterID + "' and  em.Rm_empcode='" + Emp_ID + "'";

//        }
//        else if (SubCentreID == "0" && CentreID == "0" && ClusterID != "0" && Emp_ID != "" && Emp_ID != null && Emp_ID != "0")
//        {
//            strselectcriteria = "  and cm.cluster_id='" + ClusterID + "' and  em.Rm_empcode='" + Emp_ID + "'";

//        }
//        else if (RM != null && SubCentreID == "0" && CentreID == "0" && ClusterID != "0" && RM.Count != 0 && Emp_ID == "0" && RSM.Count == 0)
//        {
//            strselectcriteria = " and cm.cluster_id='" + ClusterID + "' and ( em.Rm_empcode in ( ";
//            for (int a = 0; a < RM.Count; a++)
//            {
//                strselectcriteria += " '" + RM[a].Substring(0, 7).ToString() + "'";
//                if (a != RM.Count - 1)
//                    strselectcriteria += ",";
//                if (a == RM.Count - 1)
//                {

//                    strselectcriteria += "  )  ) ";
//                }
//            }
//        }
//        else if (RM != null && SubCentreID == "0" && CentreID == "0" && ClusterID != "0" && RM.Count != 0 && Emp_ID == "0" && RSM.Count != 0)
//        {
//            if (RSM_EMPCode == "0")
//            {
//                strselectcriteria = " and cm.cluster_id='" + ClusterID + "' and ( em.Rm_empcode in ( ";
//                for (int a = 0; a < RM.Count; a++)
//                {
//                    strselectcriteria += " '" + RM[a].Substring(0, 7).ToString() + "'";
//                    if (a != RM.Count - 1)
//                        strselectcriteria += ",";
//                    if (a == RM.Count - 1)
//                    {

//                        strselectcriteria += "  )  ) ";
//                    }
//                }

//            }
//            else
//            {
//                strselectcriteria = "and em.RSM_empcode='" + RSM_EMPCode + "'  and cm.cluster_id='" + ClusterID + "' and ( em.Rm_empcode in ( ";
//                for (int a = 0; a < RM.Count; a++)
//                {
//                    strselectcriteria += " '" + RM[a].Substring(0, 7).ToString() + "'";
//                    if (a != RM.Count - 1)
//                        strselectcriteria += ",";
//                    if (a == RM.Count - 1)
//                    {

//                        strselectcriteria += "  )  ) ";
//                    }
//                }

//            }


//        }

//        else
//        {
//            strselectcriteria = "  and cm.cluster_id='" + ClusterID + "' ";
//        }

//        //if (SubCentreID == "0" && CentreID == "0" && ClusterID != "0" && RM.Count != 0 && Emp_ID == "0")
//        //{
//        //    strselectcriteria = " and cm.cluster_id='" + ClusterID + "' and ( em.Rm_empcode in ( ";
//        //    for (int a = 0; a < RM.Count; a++)
//        //    {
//        //        strselectcriteria += " '" + RM[a].Substring(0, 7).ToString() + "'";
//        //        if (a != RM.Count - 1) 
//        //        strselectcriteria += ",";
//        //        if (a == RM.Count - 1)
//        //        {

//        //            strselectcriteria += "  )  ) ";
//        //        }
//        //    }
//        //}



//        //if (SubCentreID == "0" && CentreID != "0" && ClusterID != "0")
//        //{
//        //    strselectcriteria = " and EM.centre_id='" + CentreID + "'  and cm.cluster_id='" + ClusterID + "'";
//        //}
//        //if (SubCentreID == "0" && CentreID == "0" && ClusterID != "0")
//        //{
//        //    strselectcriteria = "  and cm.cluster_id='" + ClusterID + "'";
//        //}
//        if (SubCentreID != "0" && CentreID == "0" && ClusterID != "0")
//        {
//            strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
//        }
//        if (SubCentreID != "0" && CentreID != "0" && ClusterID == "0")
//        {
//            strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
//        }
//        if (EMPCODE != null)
//        {
//            strselectcriteria += " and em.emp_code='" + EMPCODE + "'";
//        }
//        if (EMPNAME != null)
//        {
//            strselectcriteria += " and ( ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '') like '%" + EMPNAME + "%') ";
//        }
//        if (DateTime.Now.Day <= 24)
//        {
//            if ((ToDate == null || ToDate == "") && (FromDate == null || FromDate == ""))
//            //if ((ToDate != null || ToDate != "") && (FromDate != null || FromDate !=""))
//            {
//                sqlStr = " DECLARE @current_month CHAR(6) " +
//                " DECLARE @previous_month CHAR(6) " +
//                " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
//                "select  * from(" +
//                " select  distinct em.emp_id,em.emp_code as[Emp Code],Fullname as Pamecian, " +
//                " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,Centre_name,SubcentreName,date from employee_master EM  " +
//                " left outer join DATILY_ATTENDANCE DE on de.emp_id=em.emp_id  " +
//                " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//                    //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
//                    //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//                " Inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
//                " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                    //" where department_id=" + strDepartment1 +and
//                " where   1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
//                " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)" +
//                " and  ( date <= cast( (Convert(varchar,  '" + System.DateTime.Now + "',103)) as datetime)   and  date >= cast ((convert(varchar,'" + System.DateTime.Now.AddDays(-15) + "' ,103)) as datetime) or date is null)" +
//                " ) abc pivot ( max(ATTENDANCE) " +
//                " for  date in ( ";
//                for (int a = 14; a >= 0; a--)
//                {
//                    sqlStr += "[";
//                    if (System.DateTime.Now.AddDays(-a).ToString().Length == 20)
//                        sqlStr += System.DateTime.Now.AddDays(-a).ToString().Substring(0, 9) + " 00:00:00:000";
//                    else if (System.DateTime.Now.AddDays(-a).ToString().Length == 19)
//                        sqlStr += System.DateTime.Now.AddDays(-a).ToString().Substring(0, 9) + " 00:00:00:000";
//                    else
//                        sqlStr += System.DateTime.Now.AddDays(-a).ToString().Substring(0, 10) + " 00:00:00:000";
//                    if (a == 0)
//                        sqlStr += "]";
//                    else
//                        sqlStr += "],";
//                }
//                sqlStr += ")) as pvt";
//                //sqlStr = " DECLARE @current_month CHAR(6) " +
//                //       " DECLARE @previous_month CHAR(6) " +
//                //       " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                //       " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +

//                //      " select  emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date  from (" +

//                //       "select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date " +
//                //      "from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id )" +
//                //       "inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)  " +
//                //       "inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                //       "left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//                //       "left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                //       " where 1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL)" +
//                //       "and (DOL >=  '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)" +
//                //       ") ABC " +
//                //       "where  date <= cast( (Convert(varchar,  '" + System.DateTime.Now + "',103)) as datetime)   and  date >= cast ((convert(varchar,'" + System.DateTime.Now.AddDays(-14) + "' ,103)) as datetime) " +

//                //       "group by emp_id ,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName, date";
//            }
//            else
//            {
//                TimeSpan d = TimeSpan.Zero;

//                if (ToDate != "" && FromDate != "")
//                    d = Convert.ToDateTime(ToDate) - Convert.ToDateTime(FromDate);
//                int Diff = Convert.ToInt32(d.TotalDays);
//                sqlStr = " DECLARE @current_month CHAR(6) " +
//                " DECLARE @previous_month CHAR(6) " +
//                " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
//                "select  * from(" +
//                " select  distinct em.emp_id,em.emp_code as[Emp Code],Fullname as Pamecian, " +
//                " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,Centre_name,SubcentreName,date from employee_master EM  " +
//                " left outer join DATILY_ATTENDANCE DE on de.emp_id=em.emp_id  " +
//                " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//                    //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
//                    //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//                " Inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
//                " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                    //" where department_id=" + strDepartment1 +and
//                " where   1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
//                " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)" +
//                " and  ( date <= cast( (Convert(varchar,  '" + Convert.ToDateTime(ToDate) + "',103)) as datetime)   and  date >= cast ((convert(varchar,'" + Convert.ToDateTime(FromDate) + "' ,103)) as datetime)  or date is null)" +
//                " ) abc pivot ( max(ATTENDANCE) " +
//                " for  date in ( ";
//                for (int a = Diff; a >= 0; a--)
//                {
//                    sqlStr += "[";
//                    if (Convert.ToDateTime(ToDate).AddDays(-a).ToString().Length == 20)
//                        sqlStr += Convert.ToDateTime(ToDate).AddDays(-a).ToString().Substring(0, 9) + "00:00:00:000";
//                    else if (Convert.ToDateTime(ToDate).AddDays(-a).ToString().Length == 19)
//                        sqlStr += Convert.ToDateTime(ToDate).AddDays(-a).ToString().Substring(0, 9) + " 00:00:00:000";
//                    else
//                        sqlStr += Convert.ToDateTime(ToDate).AddDays(-a).ToString().Substring(0, 10) + "00:00:00:000";
//                    if (a == 0)
//                        sqlStr += "]";
//                    else
//                        sqlStr += "],";
//                }
//                sqlStr += ")) as pvt";
//            }
//            //sqlStr = " DECLARE @current_month CHAR(6) " +
//            //        " DECLARE @previous_month CHAR(6) " +
//            //        " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//            //        " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
//            //        " select  distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(Fullname +' ', '')) AS Pamecian, " + //(ISNULL(FIRSTNAME +' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) AS Pamecian, " +
//            //        " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,Centre_name,SubcentreName from employee_master EM  " +
//            //    // " left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE] ='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//            //       " left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "')  " +
//            //        " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//            //    //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
//            //    //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//            //        " Inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//            //        " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
//            //        " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//            //    //" where department_id=" + strDepartment1 +and
//            //        " where   1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
//            //        " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)";
//        }
//        else
//        {
//            if ((ToDate == null || ToDate == "") && (FromDate == null || FromDate == ""))
//            //if ((ToDate != null || ToDate != "") && (FromDate != null || FromDate !=""))
//            {
//                sqlStr = " DECLARE @current_month CHAR(6) " +
//                       " DECLARE @previous_month CHAR(6) " +
//                       " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                       " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +

//                       "select  * from(" +
//                    " select  distinct em.emp_id,em.emp_code as[Emp Code],Fullname as Pamecian, " +
//                    " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,Centre_name,SubcentreName,date from employee_master EM  " +
//                    " left outer join DATILY_ATTENDANCE DE on de.emp_id=em.emp_id  " +
//                    " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//                    //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
//                    //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//                    " Inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                    " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
//                    " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                    //" where department_id=" + strDepartment1 +and
//                    " where   1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
//                    " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)" +
//                    " and  ( date <= cast( (Convert(varchar,  '" + System.DateTime.Now + "',103)) as datetime)   and  date >= cast ((convert(varchar,'" + System.DateTime.Now.AddDays(-15) + "' ,103)) as datetime)  or date is null)" +
//                    " ) abc pivot ( max(ATTENDANCE) " +
//                    " for  date in ( ";
//                for (int a = 14; a >= 0; a--)
//                {
//                    sqlStr += "[";
//                    if (System.DateTime.Now.AddDays(-a).ToString().Length == 20)
//                        sqlStr += System.DateTime.Now.AddDays(-a).ToString().Substring(0, 9) + " 00:00:00:000";
//                    else if (System.DateTime.Now.AddDays(-a).ToString().Length == 19)
//                        sqlStr += System.DateTime.Now.AddDays(-a).ToString().Substring(0, 9) + " 00:00:00:000";
//                    else
//                        sqlStr += System.DateTime.Now.AddDays(-a).ToString().Substring(0, 10) + " 00:00:00:000";
//                    if (a == 0)
//                        sqlStr += "]";
//                    else
//                        sqlStr += "],";
//                }
//                sqlStr += ")) as pvt";
//            }

//            else
//            {
//                TimeSpan d = TimeSpan.Zero;

//                if (ToDate != "" && FromDate != "")
//                    d = Convert.ToDateTime(ToDate) - Convert.ToDateTime(FromDate);
//                int Diff = Convert.ToInt32(d.TotalDays);
//                sqlStr = " DECLARE @current_month CHAR(6) " +
//                       " DECLARE @previous_month CHAR(6) " +
//                       " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                       " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
//                "select  * from(" +
//                " select  distinct em.emp_id,em.emp_code as[Emp Code],Fullname as Pamecian, " +
//                " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,Centre_name,SubcentreName,date from employee_master EM  " +
//                " left outer join DATILY_ATTENDANCE DE on de.emp_id=em.emp_id  " +
//                " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//                    //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
//                    //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//                " Inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
//                " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                    //" where department_id=" + strDepartment1 +and
//                " where   1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
//                " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)" +
//                " and  ( date <= cast( (Convert(varchar,  '" + Convert.ToDateTime(ToDate) + "',103)) as datetime)   and  date >= cast ((convert(varchar,'" + Convert.ToDateTime(FromDate) + "' ,103)) as datetime)  or date is null)" +
//                " ) abc pivot ( max(ATTENDANCE) " +
//                " for  date in ( ";
//                for (int a = Diff; a >= 0; a--)
//                {
//                    sqlStr += "[";
//                    if (Convert.ToDateTime(ToDate).AddDays(-a).ToString().Length == 20)
//                        sqlStr += Convert.ToDateTime(ToDate).AddDays(-a).ToString().Substring(0, 9) + "00:00:00:000";
//                    else if (Convert.ToDateTime(ToDate).AddDays(-a).ToString().Length == 19)
//                        sqlStr += Convert.ToDateTime(ToDate).AddDays(-a).ToString().Substring(0, 9) + " 00:00:00:000";
//                    else
//                        sqlStr += Convert.ToDateTime(ToDate).AddDays(-a).ToString().Substring(0, 10) + "00:00:00:000";
//                    if (a == 0)
//                        sqlStr += "]";
//                    else
//                        sqlStr += "],";
//                }
//                sqlStr += ")) as pvt";

//            }
//            //   " select  distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(Fullname +' ', '')) AS Pamecian, " +// +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) AS Pamecian, " +
//            //   " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,Centre_name,SubcentreName from employee_master EM  " +
//            //   " left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//            //   " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//            ////" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
//            ////" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//            //    " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//            //   " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
//            //   " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//            //// " where department_id=" + strDepartment1 + "  and 
//            //     " where 1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and cm.cluster_id='" + ClusterID + "' and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
//            //   " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)";
//        }
//        ds = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
//        if (ds.Tables[0].Rows.Count == 0)
//        {
//            if (DateTime.Now.Day <= 24)
//            {
//                if ((ToDate == null || ToDate == "") && (FromDate == null || FromDate == ""))
//                //if ((ToDate != null || ToDate != "") && (FromDate != null || FromDate !=""))
//                {
//                    sqlStr = " DECLARE @current_month CHAR(6) " +
//                              " DECLARE @previous_month CHAR(6) " +
//                              " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                              " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +

//                                "select  * from(" +
//                    " select  distinct em.emp_id,em.emp_code as[Emp Code],Fullname as Pamecian, " +
//                    " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,Centre_name,SubcentreName,date from employee_master EM  " +
//                    " left outer join DATILY_ATTENDANCE DE on de.emp_id=em.emp_id and date is null " +
//                    " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//                        //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
//                        //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//                    " Inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                    " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
//                    " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                        //" where department_id=" + strDepartment1 +and
//                    " where   1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
//                    " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)" +
//                    " and  ( date <= cast( (Convert(varchar,  '" + System.DateTime.Now + "',103)) as datetime)   and  date >= cast ((convert(varchar,'" + System.DateTime.Now.AddDays(-15) + "' ,103)) as datetime) or date is null)" +
//                    " ) abc pivot ( max(ATTENDANCE) " +
//                    " for  date in ( ";
//                    for (int a = 14; a >= 0; a--)
//                    {
//                        sqlStr += "[";
//                        if (System.DateTime.Now.AddDays(-a).ToString().Length == 20)
//                            sqlStr += System.DateTime.Now.AddDays(-a).ToString().Substring(0, 9) + " 00:00:00:000";
//                        else if (System.DateTime.Now.AddDays(-a).ToString().Length == 19)
//                            sqlStr += System.DateTime.Now.AddDays(-a).ToString().Substring(0, 9) + " 00:00:00:000";
//                        else
//                            sqlStr += System.DateTime.Now.AddDays(-a).ToString().Substring(0, 10) + " 00:00:00:000";
//                        if (a == 0)
//                            sqlStr += "]";
//                        else
//                            sqlStr += "],";
//                    }
//                    sqlStr += ")) as pvt";
//                }

//                else
//                {
//                    TimeSpan d = TimeSpan.Zero;

//                    if (ToDate != "" && FromDate != "")
//                        d = Convert.ToDateTime(ToDate) - Convert.ToDateTime(FromDate);
//                    int Diff = Convert.ToInt32(d.TotalDays);
//                    sqlStr = " DECLARE @current_month CHAR(6) " +
//                              " DECLARE @previous_month CHAR(6) " +
//                              " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                              " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +

//                                "select  * from(" +
//                    " select  distinct em.emp_id,em.emp_code as[Emp Code],Fullname as Pamecian, " +
//                    " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,Centre_name,SubcentreName,date from employee_master EM  " +
//                    " left outer join DATILY_ATTENDANCE DE on de.emp_id=em.emp_id and date is null " +
//                    " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//                        //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
//                        //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//                    " Inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                    " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
//                    " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                      " where   1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
//                " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)" +
//                " and  ( date <= cast( (Convert(varchar,  '" + Convert.ToDateTime(ToDate) + "',103)) as datetime)   and  date >= cast ((convert(varchar,'" + Convert.ToDateTime(FromDate) + "' ,103)) as datetime)  or date is null)" +
//                " ) abc pivot ( max(ATTENDANCE) " +
//                " for  date in ( ";
//                    for (int a = Diff; a >= 0; a--)
//                    {
//                        sqlStr += "[";
//                        if (Convert.ToDateTime(ToDate).AddDays(-a).ToString().Length == 20)
//                            sqlStr += Convert.ToDateTime(ToDate).AddDays(-a).ToString().Substring(0, 9) + "00:00:00:000";
//                        else if (Convert.ToDateTime(ToDate).AddDays(-a).ToString().Length == 19)
//                            sqlStr += Convert.ToDateTime(ToDate).AddDays(-a).ToString().Substring(0, 9) + " 00:00:00:000";
//                        else
//                            sqlStr += Convert.ToDateTime(ToDate).AddDays(-a).ToString().Substring(0, 10) + "00:00:00:000";
//                        if (a == 0)
//                            sqlStr += "]";
//                        else
//                            sqlStr += "],";
//                    }
//                    sqlStr += ")) as pvt";

//                }
//                     // " select distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(Fullname +' ', '')) AS Pamecian, " +//(ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) " +
//                     // "DE.ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName from employee_master  EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id) inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)" +
//                     //  " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                     //   //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
//                     //   //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//                     // " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//                     // " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                     //   //" where department_id=" + strDepartment1 + "  and 
//                     //" where   1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
//                     //" (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and  DOJ<=CAST(@previous_month + '21' AS datetime)";
//            }
//            else
//            {
//                if ((ToDate == null || ToDate == "") && (FromDate == null || FromDate == ""))
//                //i
//                {
//                    sqlStr = " DECLARE @current_month CHAR(6) " +
//                             " DECLARE @previous_month CHAR(6) " +
//                             " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                             " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
//                        //     " select distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(Fullname +' ', '')) AS Pamecian, " +//(ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) " +
//                        //     " DE.ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id) inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)" +
//                        //      " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                        ////" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
//                        ////" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//                        //     " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//                        //     " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                        ////" where department_id=" + strDepartment1 + "  and  
//                        //     " where 1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
//                        //    " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and  DOJ<=CAST(@current_month + '21' AS datetime)";
//                            "select  * from(" +
//                        " select  distinct em.emp_id,em.emp_code as[Emp Code],Fullname as Pamecian, " +
//                        " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,Centre_name,SubcentreName,date from employee_master EM  " +
//                        " left outer join DATILY_ATTENDANCE DE on de.emp_id=em.emp_id  and date is null " +
//                        " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//                        //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
//                        //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//                        " Inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                        " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
//                        " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                        //" where department_id=" + strDepartment1 +and
//                        " where   1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
//                        " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)" +
//                        " and  ( date <= cast( (Convert(varchar,  '" + System.DateTime.Now + "',103)) as datetime)   and  date >= cast ((convert(varchar,'" + System.DateTime.Now.AddDays(-15) + "' ,103)) as datetime) or date is null)" +
//                        " ) abc pivot ( max(ATTENDANCE) " +
//                        " for  date in ( ";
//                    for (int a = 14; a >= 0; a--)
//                    {
//                        sqlStr += "[";
//                        if (System.DateTime.Now.AddDays(-a).ToString().Length == 20)
//                            sqlStr += System.DateTime.Now.AddDays(-a).ToString().Substring(0, 9) + " 00:00:00:000";
//                        else if (System.DateTime.Now.AddDays(-a).ToString().Length == 19)
//                            sqlStr += System.DateTime.Now.AddDays(-a).ToString().Substring(0, 9) + " 00:00:00:000";
//                        else
//                            sqlStr += System.DateTime.Now.AddDays(-a).ToString().Substring(0, 10) + " 00:00:00:000";
//                        if (a == 0)
//                            sqlStr += "]";
//                        else
//                            sqlStr += "],";
//                    }
//                    sqlStr += ")) as pvt";
//                }
//                else
//                {

//                    TimeSpan d = TimeSpan.Zero;

//                    if (ToDate != "" && FromDate != "")
//                        d = Convert.ToDateTime(ToDate) - Convert.ToDateTime(FromDate);
//                    int Diff = Convert.ToInt32(d.TotalDays);
//                    sqlStr = " DECLARE @current_month CHAR(6) " +
//                               " DECLARE @previous_month CHAR(6) " +
//                               " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                               " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +

//                                 "select  * from(" +
//                      " select  distinct em.emp_id,em.emp_code as[Emp Code],Fullname as Pamecian, " +
//                      " DE.ATTENDANCE,DEPARTMENT,DESIGNATION,Centre_name,SubcentreName,date from employee_master EM  " +
//                      " left outer join DATILY_ATTENDANCE DE on de.emp_id=em.emp_id and date is null " +
//                      " inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//                        //" Inner join MAC_Master MAC on(em.Emp_id=MAC.Emp_id) " +
//                        //" Inner join DAT DT on(dt.MACADDRESS=MAC.MAC_info and DT.DATE>='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "') " +
//                      " Inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                      " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID) " +
//                      " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                        " where   1=1 " + strselectcriteria + " and 1=1 " + strselectcriteria1 + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and " +
//                  " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)" +
//                  " and  ( date <= cast( (Convert(varchar,  '" + Convert.ToDateTime(ToDate) + "',103)) as datetime)   and  date >= cast ((convert(varchar,'" + Convert.ToDateTime(FromDate) + "' ,103)) as datetime)  or date is null)" +
//                  " ) abc pivot ( max(ATTENDANCE) " +
//                  " for  date in ( ";
//                    for (int a = Diff; a >= 0; a--)
//                    {
//                        sqlStr += "[";
//                        if (Convert.ToDateTime(ToDate).AddDays(-a).ToString().Length == 20)
//                            sqlStr += Convert.ToDateTime(ToDate).AddDays(-a).ToString().Substring(0, 9) + "00:00:00:000";
//                        else if (Convert.ToDateTime(ToDate).AddDays(-a).ToString().Length == 19)
//                            sqlStr += Convert.ToDateTime(ToDate).AddDays(-a).ToString().Substring(0, 9) + " 00:00:00:000";
//                        else
//                            sqlStr += Convert.ToDateTime(ToDate).AddDays(-a).ToString().Substring(0, 10) + "00:00:00:000";
//                        if (a == 0)
//                            sqlStr += "]";
//                        else
//                            sqlStr += "],";
//                    }
//                    sqlStr += ")) as pvt";
//                }
//            }
//            ds1 = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
//        }
//        if (ds.Tables[0].Rows.Count != 0)
//        {
//            return ds;
//        }
//        else
//            return ds1;
//    }

//    public DataSet EditGrid(string sdate)
//    {
//        DataSet ds1 = new DataSet();
//        string sqlStr = "";
//        string strselectcriteria = "";
//        if (EMPCODE != null)
//        {
//            strselectcriteria += " and em.emp_code='" + EMPCODE + "'";
//        }
//        if (EMPNAME != null)
//        {
//            strselectcriteria += " and ( ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '') like '%" + EMPNAME + "%') ";
//        }



//        sqlStr = " DECLARE @current_month CHAR(6) " +
//                      " DECLARE @previous_month CHAR(6) " +
//                      " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                      " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
//                      " select distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(Fullname +' ', '')) AS Pamecian, " +//(ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) " +
//                      " ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id  and [DATE]='" + sdate + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)" +
//                       " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                      " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//                      " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                      " where department_id=" + strDepartment1 + "  and   EM.centre_id=Case Isnull('" + CentreID + "',0) When 0 Then Em.centre_id Else '" + CentreID + "'  End   and SUBCENTRE_ID=Case Isnull('" + SubCentreID + "',0) When 0 Then subcentre_id Else '" + SubCentreID + "'  End  and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
//                     " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) ";


//        ds = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
//        if (ds.Tables[0].Rows.Count == 0)
//        {

//            sqlStr = " DECLARE @current_month CHAR(6) " +
//                     " DECLARE @previous_month CHAR(6) " +
//                     " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                     " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
//                    " select distinct em.emp_id,em.emp_code as[Emp Code],(ISNULL(Fullname +' ', '')) AS Pamecian, " +//(ISNULL(FIRSTNAME + ' ', '') +ISNULL(MIDDLENAME + ' ', '') + ISNULL(LASTNAME + ' ', '')) " +
//                    " ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id  and [DATE]='" + sdate + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)" +
//                     " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                    " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//                    " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                    " where department_id=" + strDepartment1 + "  and   EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "'   and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
//                   " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) ";


//            ds1 = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);

//        }
//        if (ds.Tables[0].Rows.Count != 0)
//        {
//            return ds;
//        }
//        else
//            return ds1;
//    }

//    //public DataSet GetToDayAttenance()
//    //{
//    //    DataSet ds1 = new DataSet();
//    //    string sqlStr = "";
//    //    string strselectcriteria = "";
//    //    if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0")
//    //    {
//    //        strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "'";

//    //    }
//    //    if (SubCentreID == "0" && CentreID != "0" && ClusterID != "0")
//    //    {
//    //        strselectcriteria = " and EM.centre_id='" + CentreID + "'  and cm.cluster_id='" + ClusterID + "'";
//    //    }
//    //    if (SubCentreID == "0" && CentreID == "0" && ClusterID != "0")
//    //    {
//    //        strselectcriteria = "  and cm.cluster_id='" + ClusterID + "'";
//    //    }
//    //    if (SubCentreID != "0" && CentreID == "0" && ClusterID != "0")
//    //    {
//    //        strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
//    //    }
//    //    if (SubCentreID != "0" && CentreID != "0" && ClusterID == "0")
//    //    {
//    //        strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
//    //    }
//    //    if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() != "Sunday")
//    //    {
//    //        if (DateTime.Now.Day <= 20)
//    //        {
//    //            sqlStr = " DECLARE @current_month CHAR(6) " +
//    //                     " DECLARE @previous_month CHAR(6) " +
//    //                     " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//    //                     " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
//    //                     " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//    //                      " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//    //                     " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//    //                     " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//    //                     " where department_id=" + strDepartment1 + "  and  1=1 " + strselectcriteria + "  and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
//    //                    " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)";
//    //        }
//    //        else
//    //        {
//    //            sqlStr = " DECLARE @current_month CHAR(6) " +
//    //                     " DECLARE @previous_month CHAR(6) " +
//    //                     " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//    //                     " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
//    //                     " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//    //                      " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//    //                     " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//    //                     " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//    //                     " where department_id=" + strDepartment1 + "  and  1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
//    //                    " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)";
//    //        }
//    //    }
//    //    else
//    //    {
//    //        if (DateTime.Now.Day <= 20)
//    //        {
//    //            sqlStr = " DECLARE @current_month CHAR(6) " +
//    //                     " DECLARE @previous_month CHAR(6) " +
//    //                     " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//    //                     " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
//    //                     " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-2).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//    //                      " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//    //                     " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//    //                     " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//    //                     " where department_id=" + strDepartment1 + "  and  1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
//    //                    " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)";
//    //        }
//    //        else
//    //        {
//    //            sqlStr = " DECLARE @current_month CHAR(6) " +
//    //                    " DECLARE @previous_month CHAR(6) " +
//    //                    " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//    //                    " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
//    //                    " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-2).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//    //                     " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//    //                    " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//    //                    " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//    //                    " where department_id=" + strDepartment1 + "  and  1=1 " + strselectcriteria + "  and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
//    //                   " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)";
//    //        }
//    //    }
//    //    ds1 = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
//    //    return ds1;
//    //}

//    //add by Rani
//    public DataSet GetToDayAttenance1()
//    {
//        DataSet ds1 = new DataSet();
//        string sqlStr = "";
//        string strselectcriteria = "";
//        //if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0" && Emp_ID == "0")
//        //{
//        //    strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "'";

//        //}
//        //if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0" && Emp_ID != "0")
//        //{
//        //    strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "' and  em.user_id_activityManager='" + Emp_ID + "'";

//        //}
//        if (SubCentreID == "0" && CentreID != "0" && ClusterID != "0")
//        {
//            strselectcriteria = " and EM.centre_id='" + CentreID + "'  and cm.cluster_id='" + ClusterID + "'";
//        }
//        if (SubCentreID == "0" && CentreID == "0" && ClusterID != "0")
//        {
//            strselectcriteria = "  and cm.cluster_id='" + ClusterID + "'";
//        }
//        if (SubCentreID != "0" && CentreID == "0" && ClusterID != "0")
//        {
//            strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
//        }
//        if (SubCentreID != "0" && CentreID != "0" && ClusterID == "0")
//        {
//            strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
//        }
//        if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() != "Sunday")
//        {
//            if (DateTime.Now.Day <= 20)
//            {
//                //if ((ToDate != null && FromDate != null))
//                //{
//                //    sqlStr = " DECLARE @current_month CHAR(6) " +
//                //             " DECLARE @previous_month CHAR(6) " +
//                //             " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                //             " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +

//                //            " select  emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date  from (" +

//                //             "select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date " +
//                //            "from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id )" +
//                //             "inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)  " +
//                //             "inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                //             "left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//                //             "left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                //             " where 1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL)" +
//                //             "and (DOL >=  '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)" +
//                //             ") ABC " +
//                //             "where  date <= cast( (Convert(varchar(10),  '" + Convert.ToDateTime(ToDate).Date.ToString("yyyy-MM-dd HH:mm:SS") + "' ,103)) as datetime) and date >= cast ((convert(varchar(10), '" + Convert.ToDateTime(FromDate).Date.ToString("yyyy-MM-dd HH:mm:SS") + "'  ,103)) as datetime) " +

//                //             "group by emp_id ,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName, date";
//                //}
//                //else
//                //{
//                sqlStr = " DECLARE @current_month CHAR(6) " +
//                        " DECLARE @previous_month CHAR(6) " +
//                        " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                        " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +

//                       " select  emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date  from (" +

//                        "select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date " +
//                       "from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id )" +
//                        "inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)  " +
//                        "inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                        "left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//                        "left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                        " where 1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL)" +
//                        "and (DOL >=  '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)" +
//                        ") ABC " +
//                        "where  date <= cast( (Convert(varchar(10),  '" + System.DateTime.Now + "',103)) as datetime)   and  date >= cast ((convert(varchar(10),'" + System.DateTime.Now.AddDays(-14) + "' ,103)) as datetime) " +

//                        "group by emp_id ,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName, date";
//                //}

//                //     " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(0).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//                //      " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                //     " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//                //     " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                ////" where department_id=" + strDepartment1 + "  and 
//                //     " where 1=1 " + strselectcriteria + "  and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
//                //    " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)";
//            }

//            else
//            {
//                sqlStr = " DECLARE @current_month CHAR(6) " +
//                         " DECLARE @previous_month CHAR(6) " +
//                         " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                         " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
//                         " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//                          " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                         " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//                         " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                    // " where department_id=" + strDepartment1 + "  and  
//                         " where 1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
//                        " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)";
//            }
//        }
//        else
//        {
//            if (DateTime.Now.Day <= 20)
//            {
//                sqlStr = " DECLARE @current_month CHAR(6) " +
//                         " DECLARE @previous_month CHAR(6) " +
//                         " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                         " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
//                         " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-2).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//                          " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                         " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//                         " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                    // " where department_id=" + strDepartment1 + "  and 
//                         " where  1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
//                        " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)";
//            }
//            else
//            {
//                sqlStr = " DECLARE @current_month CHAR(6) " +
//                        " DECLARE @previous_month CHAR(6) " +
//                        " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                        " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
//                        " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-2).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//                         " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                        " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//                        " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                    //   " where department_id=" + strDepartment1 + "  and  
//                       "where  1=1 " + strselectcriteria + "  and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
//                       " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)";
//            }
//        }
//        ds1 = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
//        return ds1;
//    }
//    public DataSet GetToDayAttenance2()
//    {
//        DataSet ds1 = new DataSet();
//        string sqlStr = "";
//        string strselectcriteria = "";
//        if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0")
//        {
//            strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "'";

//        }
//        if (SubCentreID == "0" && CentreID != "0" && ClusterID != "0")
//        {
//            strselectcriteria = " and EM.centre_id='" + CentreID + "'  and cm.cluster_id='" + ClusterID + "'";
//        }
//        if (SubCentreID == "0" && CentreID == "0" && ClusterID != "0")
//        {
//            strselectcriteria = "  and cm.cluster_id='" + ClusterID + "'";
//        }
//        if (SubCentreID != "0" && CentreID == "0" && ClusterID != "0")
//        {
//            strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
//        }
//        if (SubCentreID != "0" && CentreID != "0" && ClusterID == "0")
//        {
//            strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
//        }
//        if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() != "Sunday")
//        {
//            if (DateTime.Now.Day <= 20)
//            {
//                sqlStr = " DECLARE @current_month CHAR(6) " +
//                         " DECLARE @previous_month CHAR(6) " +
//                         " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                         " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
//                         " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//                          " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                         " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//                         " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                    //" where department_id=" + strDepartment1 + "  and 
//                         " where 1=1 " + strselectcriteria + "  and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
//                        " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)";
//            }
//            else
//            {
//                sqlStr = " DECLARE @current_month CHAR(6) " +
//                         " DECLARE @previous_month CHAR(6) " +
//                         " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                         " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
//                         " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//                          " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                         " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//                         " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                    // " where department_id=" + strDepartment1 + "  and  
//                         " where 1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
//                        " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)";
//            }
//        }
//        else
//        {
//            if (DateTime.Now.Day <= 20)
//            {
//                sqlStr = " DECLARE @current_month CHAR(6) " +
//                         " DECLARE @previous_month CHAR(6) " +
//                         " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                         " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
//                         " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-2).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//                          " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                         " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//                         " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                    // " where department_id=" + strDepartment1 + "  and 
//                         " where  1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
//                        " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)";
//            }
//            else
//            {
//                sqlStr = " DECLARE @current_month CHAR(6) " +
//                        " DECLARE @previous_month CHAR(6) " +
//                        " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                        " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
//                        " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,UNIT,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-2).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//                         " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                        " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//                        " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                    //   " where department_id=" + strDepartment1 + "  and  
//                       "where  1=1 " + strselectcriteria + "  and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
//                       " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)";
//            }
//        }
//        ds1 = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
//        return ds1;
//    }
//    public DataSet GetToDayAttenance()
//    {
//        DataSet ds1 = new DataSet();
//        string sqlStr = "";
//        string strselectcriteria = "";
//        //if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0" && Emp_ID == "0")
//        //{
//        //    strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "'";

//        //}
//        //if (SubCentreID != "0" && CentreID != "0" && ClusterID != "0" && Emp_ID != "0")
//        //{
//        //    strselectcriteria = " and EM.centre_id='" + CentreID + "' and SUBCENTRE_ID='" + SubCentreID + "' and cm.cluster_id='" + ClusterID + "' and  em.user_id_activityManager='" + Emp_ID + "'";

//        //}
//        if (SubCentreID == "0" && CentreID != "0" && ClusterID != "0")
//        {
//            strselectcriteria = " and EM.centre_id='" + CentreID + "'  and cm.cluster_id='" + ClusterID + "'";
//        }
//        if (SubCentreID == "0" && CentreID == "0" && ClusterID != "0")
//        {
//            strselectcriteria = "  and cm.cluster_id='" + ClusterID + "'";
//        }
//        if (SubCentreID != "0" && CentreID == "0" && ClusterID != "0")
//        {
//            strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
//        }
//        if (SubCentreID != "0" && CentreID != "0" && ClusterID == "0")
//        {
//            strselectcriteria = "and SUBCENTRE_ID='" + SubCentreID + "'  and cm.cluster_id='" + ClusterID + "'";
//        }
//        if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() != "Sunday")
//        {
//            if (DateTime.Now.Day <= 20)
//            {
//                if ((ToDate == null || ToDate == "") && (FromDate == null || FromDate == ""))
//                //if ((ToDate != null || ToDate != "") && (FromDate != null || FromDate !=""))
//                {
//                    sqlStr = " DECLARE @current_month CHAR(6) " +
//                           " DECLARE @previous_month CHAR(6) " +
//                           " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                           " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +

//                          " select  emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date  from (" +

//                           "select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date " +
//                          "from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id )" +
//                           "inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)  " +
//                           "inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                           "left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//                           "left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                           " where 1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL)" +
//                           "and (DOL >=  '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)" +
//                           ") ABC " +
//                           "where  date <= cast( (Convert(varchar,  '" + System.DateTime.Now + "',103)) as datetime)   and  date >= cast ((convert(varchar,'" + System.DateTime.Now.AddDays(-14) + "' ,103)) as datetime) " +

//                           "group by emp_id ,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName, date";
//                }
//                else
//                {
//                    sqlStr = " DECLARE @current_month CHAR(6) " +
//                            " DECLARE @previous_month CHAR(6) " +
//                            " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                            " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +

//                           " select  emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date  from (" +

//                            "select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date " +
//                           "from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id )" +
//                            "inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)  " +
//                            "inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                            "left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//                            "left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                            " where 1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL)" +
//                            "and (DOL >=  '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)" +
//                            ") ABC " +
//                            "where  date <= cast( (Convert(varchar,  '" + Convert.ToDateTime(ToDate).Date.ToString("yyyy-MM-dd HH:mm") + "' ,103)) as datetime) and date >= cast ((convert(varchar, '" + Convert.ToDateTime(FromDate).Date.ToString("yyyy-MM-dd HH:mm") + "'  ,103)) as datetime) " +

//                            "group by emp_id ,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName, date";

//                }

//                //     " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(0).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//                //      " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                //     " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//                //     " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                ////" where department_id=" + strDepartment1 + "  and 
//                //     " where 1=1 " + strselectcriteria + "  and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
//                //    " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)";
//            }

//            else
//            {
//                if ((ToDate == null || ToDate == "") && (FromDate == null || FromDate == ""))
//                //if ((ToDate != null || ToDate != "") && (FromDate != null || FromDate !=""))
//                {
//                    sqlStr = " DECLARE @current_month CHAR(6) " +
//                           " DECLARE @previous_month CHAR(6) " +
//                           " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                           " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +

//                          " select  emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date  from (" +

//                           "select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date " +
//                          "from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id )" +
//                           "inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)  " +
//                           "inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                           "left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//                           "left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                           " where 1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL)" +
//                           "and (DOL >=  '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)" +
//                           ") ABC " +
//                           "where  date <= cast( (Convert(varchar,  '" + System.DateTime.Now + "',103)) as datetime)   and  date >= cast ((convert(varchar,'" + System.DateTime.Now.AddDays(-14) + "' ,103)) as datetime) " +

//                           "group by emp_id ,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName, date";
//                }
//                else
//                {
//                    sqlStr = " DECLARE @current_month CHAR(6) " +
//                            " DECLARE @previous_month CHAR(6) " +
//                            " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                            " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
//                           " select  emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date  from (" +

//                            "select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date " +
//                           "from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id )" +
//                            "inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)  " +
//                            "inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                            "left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//                            "left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                            " where 1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL)" +
//                            "and (DOL >=  '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)" +
//                            ") ABC " +
//                            "where  date <= cast( (Convert(varchar,  '" + Convert.ToDateTime(ToDate).Date.ToString("yyyy-MM-dd HH:mm") + "' ,103)) as datetime) and date >= cast ((convert(varchar, '" + Convert.ToDateTime(FromDate).Date.ToString("yyyy-MM-dd HH:mm") + "'  ,103)) as datetime) " +

//                            "group by emp_id ,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName, date";

//                }

//                //sqlStr = " DECLARE @current_month CHAR(6) " +
//                //         " DECLARE @previous_month CHAR(6) " +
//                //         " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                //         " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
//                //         " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//                //          " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                //         " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//                //         " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                //    // " where department_id=" + strDepartment1 + "  and  
//                //         " where 1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
//                //        " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)";
//            }
//        }
//        else
//        {
//            if (DateTime.Now.Day <= 20)
//            {
//                if ((ToDate == null || ToDate == "") && (FromDate == null || FromDate == ""))
//                //if ((ToDate != null || ToDate != "") && (FromDate != null || FromDate !=""))
//                {
//                    sqlStr = " DECLARE @current_month CHAR(6) " +
//                           " DECLARE @previous_month CHAR(6) " +
//                           " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                           " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +

//                          " select  emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date  from (" +

//                           "select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date " +
//                          "from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id )" +
//                           "inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)  " +
//                           "inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                           "left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//                           "left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                           " where 1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL)" +
//                           "and (DOL >=  '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)" +
//                           ") ABC " +
//                           "where  date <= cast( (Convert(varchar,  '" + System.DateTime.Now + "',103)) as datetime)   and  date >= cast ((convert(varchar,'" + System.DateTime.Now.AddDays(-14) + "' ,103)) as datetime) " +

//                           "group by emp_id ,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName, date";
//                }
//                else
//                {
//                    sqlStr = " DECLARE @current_month CHAR(6) " +
//                            " DECLARE @previous_month CHAR(6) " +
//                            " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                            " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +

//                           " select  emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date  from (" +

//                            "select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date " +
//                           "from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id )" +
//                            "inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)  " +
//                            "inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                            "left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//                            "left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                            " where 1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL)" +
//                            "and (DOL >=  '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)" +
//                            ") ABC " +
//                            "where  date <= cast( (Convert(varchar,  '" + Convert.ToDateTime(ToDate).Date.ToString("yyyy-MM-dd HH:mm") + "' ,103)) as datetime) and date >= cast ((convert(varchar, '" + Convert.ToDateTime(FromDate).Date.ToString("yyyy-MM-dd HH:mm") + "'  ,103)) as datetime) " +

//                            "group by emp_id ,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName, date";

//                }
//                //sqlStr = " DECLARE @current_month CHAR(6) " +
//                //         " DECLARE @previous_month CHAR(6) " +
//                //         " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                //         " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, -1, GETDATE()), 112) " +
//                //         " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-2).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//                //          " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                //         " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//                //         " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                //    // " where department_id=" + strDepartment1 + "  and 
//                //         " where  1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
//                //        " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@previous_month + '21' AS datetime)";
//            }
//            else
//            {
//                if ((ToDate == null || ToDate == "") && (FromDate == null || FromDate == ""))
//                //if ((ToDate != null || ToDate != "") && (FromDate != null || FromDate !=""))
//                {
//                    sqlStr = " DECLARE @current_month CHAR(6) " +
//                           " DECLARE @previous_month CHAR(6) " +
//                           " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                           " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +

//                          " select  emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date  from (" +

//                           "select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date " +
//                          "from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id )" +
//                           "inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)  " +
//                           "inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                           "left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//                           "left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                           " where 1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL)" +
//                           "and (DOL >=  '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)" +
//                           ") ABC " +
//                           "where  date <= cast( (Convert(varchar,  '" + System.DateTime.Now + "',103)) as datetime)   and  date >= cast ((convert(varchar,'" + System.DateTime.Now.AddDays(-14) + "' ,103)) as datetime) " +

//                           "group by emp_id ,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName, date";
//                }
//                else
//                {
//                    sqlStr = " DECLARE @current_month CHAR(6) " +
//                            " DECLARE @previous_month CHAR(6) " +
//                            " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                            " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
//                           " select  emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date  from (" +

//                            "select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName,date " +
//                           "from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id )" +
//                            "inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id)  " +
//                            "inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                            "left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//                            "left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                            " where 1=1 " + strselectcriteria + " and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL)" +
//                            "and (DOL >=  '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)" +
//                            ") ABC " +
//                            "where  date <= cast( (Convert(varchar,  '" + Convert.ToDateTime(ToDate).Date.ToString("yyyy-MM-dd HH:mm") + "' ,103)) as datetime) and date >= cast ((convert(varchar, '" + Convert.ToDateTime(FromDate).Date.ToString("yyyy-MM-dd HH:mm") + "'  ,103)) as datetime) " +

//                            "group by emp_id ,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName, date";

//                }
//                //sqlStr = " DECLARE @current_month CHAR(6) " +
//                //        " DECLARE @previous_month CHAR(6) " +
//                //        " SET @current_month = CONVERT(CHAR(6), GETDATE(), 112) " +
//                //        " SET @previous_month = CONVERT(CHAR(6), DATEADD(MONTH, 1, GETDATE()), 112) " +
//                //        " select em.emp_id,ATTENDANCE,DEPARTMENT ,DESIGNATION,Centre_name,SubcentreName from employee_master EM left outer join DATILY_ATTENDANCE DE on(de.emp_id=em.emp_id and [DATE]='" + System.DateTime.Now.AddDays(-2).ToString("dd-MMM-yyyy") + "') inner join CENTRE_MASTER cm on(em.centre_id=cm.centre_id) " +
//                //         " inner join Subcentremaster scm on(em.SUBCENTRE_ID=scm.subcentreid) " +
//                //        " left outer join DEPARTMENT_MASTER DM on(EM.DEPARTMENT_ID=DM.DEPT_ID)" +
//                //        " left outer join DESIGNATION_MASTER DES on(DES.DESIGNATION_ID=EM.DESIGNATION_ID) " +
//                //    //   " where department_id=" + strDepartment1 + "  and  
//                //       "where  1=1 " + strselectcriteria + "  and (APPROVED_BY_HOHR='Y' OR APPROVED_BY_HOHR IS NULL) and" +
//                //       " (DOL >= '" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' or DOl is null) and DOJ<=CAST(@current_month + '21' AS datetime)";
//            }
//        }
//        ds1 = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlStr);
//        return ds1;
//    }
//    public void InsertAttendence2(ArrayList ArrListEmp, ArrayList ArrListAtten, ArrayList ArrPreAtten, string AlistCreBy, DateTime AlistCreDate)
//    {
//        if (Date != "" && Date != null)
//        {
//             OleDbParameter[] paramGrid = new OleDbParameter[5];

//            OleDbParameter[] paramGrid1 = new OleDbParameter[5];

//            for (int i = 0; i <= ArrListEmp.Count - 1; i++)
//            {

//                string strSql = "";
//                OleDbConnection conn = new OleDbConnection(con.ConnectionString);
//                conn.Open();
//                OleDbTransaction oledbTrans = conn.BeginTransaction();
//                int k = 0;
//                try
//                {


//                    strSql = " select count(emp_id) from DATILY_ATTENDANCE where [Date]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' and emp_id=" + ArrListEmp[i].ToString() + "";
//                    k = Convert.ToInt32(OleDbHelper.ExecuteScalar(oledbTrans, CommandType.Text, strSql));

//                    if (k == 0)
//                    {
//                        strSql = "insert into DATILY_ATTENDANCE (EMP_ID,[DATE],ATTENDANCE,CreateBy,CreateDate) values(?,?,?,?,?)";
//                        paramGrid[0] = new OleDbParameter("@EMP_ID", OleDbType.VarChar);
//                        paramGrid[0].Value = ArrListEmp[i].ToString();
//                        paramGrid[1] = new OleDbParameter("@[DATE]", OleDbType.Date);
//                        paramGrid[1].Value = System.DateTime.Now.ToShortDateString();
//                        paramGrid[2] = new OleDbParameter("@ATTENDANCE", OleDbType.VarChar);
//                        paramGrid[2].Value = ArrListAtten[i].ToString();
//                        paramGrid[3] = new OleDbParameter("@CreateBy", OleDbType.VarChar);
//                        paramGrid[3].Value = AlistCreBy.ToString();
//                        paramGrid[4] = new OleDbParameter("@CreateDate", OleDbType.Date);
//                        paramGrid[4].Value = System.DateTime.Now.ToShortDateString();
//                        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, strSql, paramGrid);
//                        Message = "Saved successfully !!!";
//                    }
//                    else
//                    {
//                        strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrListAtten[i].ToString() + "',CreateBy='" + AlistCreBy.ToString() + "',CreateDate='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' where    [Date]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' and emp_id=" + ArrListEmp[i].ToString() + " ";

//                        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, strSql);
//                        Message = "Updated successfully !!!";
//                    }
//                    oledbTrans.Commit();
//                    conn.Close();
//                }
//                catch (Exception ex)
//                {
//                    oledbTrans.Rollback();
//                    conn.Close();
//                    Message = ex.Message;
//                }
//                if (ColumnFlag == true)
//                {
//                    OleDbConnection conn1 = new OleDbConnection(con.ConnectionString);
//                    conn.Open();
//                    OleDbTransaction oledbTrans1 = conn.BeginTransaction();
//                    try
//                    {


//                        if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() != "Sunday")
//                        {
//                            strSql = " select count(emp_id) from DATILY_ATTENDANCE where   [DATE]='" + System.DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy") + "'  and emp_id=" + ArrListEmp[i].ToString() + " ";
//                        }
//                        else
//                            strSql = " select count(emp_id) from DATILY_ATTENDANCE where   [DATE]='" + System.DateTime.Now.AddDays(-2).ToString("dd-MMM-yyyy") + "'  and emp_id=" + ArrListEmp[i].ToString() + " ";
//                        k = Convert.ToInt32(OleDbHelper.ExecuteScalar(oledbTrans1, CommandType.Text, strSql));

//                        if (k == 0)
//                        {
//                            strSql = "insert into DATILY_ATTENDANCE (EMP_ID,[DATE],ATTENDANCE,CreateBy,CreateDate) values(?,?,?,?,?)";
//                            paramGrid1[0] = new OleDbParameter("@EMP_ID", OleDbType.VarChar);
//                            paramGrid1[0].Value = ArrListEmp[i].ToString();
//                            paramGrid1[1] = new OleDbParameter("@[DATE]", OleDbType.Date);
//                            paramGrid1[1].Value = System.DateTime.Now.ToShortDateString();
//                            paramGrid1[3] = new OleDbParameter("@CreateBy", OleDbType.VarChar);
//                            paramGrid1[3].Value = AlistCreBy.ToString();
//                            paramGrid1[4] = new OleDbParameter("@CreateDate", OleDbType.Date);
//                            paramGrid1[4].Value = System.DateTime.Now.ToShortDateString();
//                            if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() != "Sunday")
//                            {
//                                paramGrid1[1].Value = System.DateTime.Now.AddDays(-1).ToShortDateString();
//                            }
//                            else
//                                paramGrid1[1].Value = System.DateTime.Now.AddDays(-2).ToShortDateString();
//                            paramGrid1[2] = new OleDbParameter("@ATTENDANCE", OleDbType.VarChar);
//                            paramGrid1[2].Value = ArrPreAtten[i].ToString();
//                            OleDbHelper.ExecuteNonQuery(oledbTrans1, CommandType.Text, strSql, paramGrid1);
//                            Message = "Saved successfully !!!";
//                        }
//                        else
//                        {
//                            if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() != "Sunday")
//                            {
//                                strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrPreAtten[i].ToString() + "',CreateBy='" + AlistCreBy.ToString() + "',CreateDate='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' where   [DATE]>='" + System.DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy") + "' and [DATE]<'" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' AND EMP_ID=" + ArrListEmp[i].ToString() + " ";
//                            }
//                            else
//                                strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrPreAtten[i].ToString() + "',CreateBy='" + AlistCreBy.ToString() + "',CreateDate='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' where   [DATE]>='" + System.DateTime.Now.AddDays(-2).ToString("dd-MMM-yyyy") + "' and [DATE]<'" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' AND EMP_ID=" + ArrListEmp[i].ToString() + " ";

//                            OleDbHelper.ExecuteNonQuery(oledbTrans1, CommandType.Text, strSql);
//                            Message = "Updated successfully !!!";
//                        }
//                        oledbTrans1.Commit();
//                        conn1.Close();
//                    }
//                    catch (Exception ex)
//                    {
//                        oledbTrans1.Rollback();
//                        conn1.Close();
//                        Message = ex.Message;
//                    }
//                }
//            }
       
//        }
//        else
//        {

//            OleDbParameter[] paramGrid = new OleDbParameter[5];

//            OleDbParameter[] paramGrid1 = new OleDbParameter[5];

//            for (int i = 0; i <= ArrListEmp.Count - 1; i++)
//            {

//                string strSql = "";
//                OleDbConnection conn = new OleDbConnection(con.ConnectionString);
//                conn.Open();
//                OleDbTransaction oledbTrans = conn.BeginTransaction();
//                int k = 0;
//                try
//                {


//                    strSql = " select count(emp_id) from DATILY_ATTENDANCE where [Date]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' and emp_id=" + ArrListEmp[i].ToString() + "";
//                    k = Convert.ToInt32(OleDbHelper.ExecuteScalar(oledbTrans, CommandType.Text, strSql));

//                    if (k == 0)
//                    {
//                        strSql = "insert into DATILY_ATTENDANCE (EMP_ID,[DATE],ATTENDANCE,CreateBy,CreateDate) values(?,?,?,?,?)";
//                        paramGrid[0] = new OleDbParameter("@EMP_ID", OleDbType.VarChar);
//                        paramGrid[0].Value = ArrListEmp[i].ToString();
//                        paramGrid[1] = new OleDbParameter("@[DATE]", OleDbType.Date);
//                        paramGrid[1].Value = System.DateTime.Now.ToShortDateString();
//                        paramGrid[2] = new OleDbParameter("@ATTENDANCE", OleDbType.VarChar);
//                        paramGrid[2].Value = ArrListAtten[i].ToString();
//                        paramGrid[3] = new OleDbParameter("@CreateBy", OleDbType.VarChar);
//                        paramGrid[3].Value = AlistCreBy.ToString();
//                        paramGrid[4] = new OleDbParameter("@CreateDate", OleDbType.Date);
//                        paramGrid[4].Value = System.DateTime.Now.ToShortDateString();
//                        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, strSql, paramGrid);
//                        Message = "Saved successfully !!!";
//                    }
//                    else
//                    {
//                        strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrListAtten[i].ToString() + "',CreateBy='" + AlistCreBy.ToString() + "',CreateDate='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' where    [Date]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' and emp_id=" + ArrListEmp[i].ToString() + " ";

//                        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, strSql);
//                        Message = "Updated successfully !!!";
//                    }
//                    oledbTrans.Commit();
//                    conn.Close();
//                }
//                catch (Exception ex)
//                {
//                    oledbTrans.Rollback();
//                    conn.Close();
//                    Message = ex.Message;
//                }
//                if (ColumnFlag == true)
//                {
//                    OleDbConnection conn1 = new OleDbConnection(con.ConnectionString);
//                    conn.Open();
//                    OleDbTransaction oledbTrans1 = conn.BeginTransaction();
//                    try
//                    {


//                        if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() != "Sunday")
//                        {
//                            strSql = " select count(emp_id) from DATILY_ATTENDANCE where   [DATE]='" + System.DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy") + "'  and emp_id=" + ArrListEmp[i].ToString() + " ";
//                        }
//                        else
//                            strSql = " select count(emp_id) from DATILY_ATTENDANCE where   [DATE]='" + System.DateTime.Now.AddDays(-2).ToString("dd-MMM-yyyy") + "'  and emp_id=" + ArrListEmp[i].ToString() + " ";
//                        k = Convert.ToInt32(OleDbHelper.ExecuteScalar(oledbTrans1, CommandType.Text, strSql));

//                        if (k == 0)
//                        {
//                            strSql = "insert into DATILY_ATTENDANCE (EMP_ID,[DATE],ATTENDANCE,CreateBy,CreateDate) values(?,?,?,?,?)";
//                            paramGrid1[0] = new OleDbParameter("@EMP_ID", OleDbType.VarChar);
//                            paramGrid1[0].Value = ArrListEmp[i].ToString();
//                            paramGrid1[1] = new OleDbParameter("@[DATE]", OleDbType.Date);
//                            paramGrid1[1].Value = System.DateTime.Now.ToShortDateString();
//                            paramGrid1[3] = new OleDbParameter("@CreateBy", OleDbType.VarChar);
//                            paramGrid1[3].Value = AlistCreBy.ToString();
//                            paramGrid1[4] = new OleDbParameter("@CreateDate", OleDbType.Date);
//                            paramGrid1[4].Value = System.DateTime.Now.ToShortDateString();
//                            if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() != "Sunday")
//                            {
//                                paramGrid1[1].Value = System.DateTime.Now.AddDays(-1).ToShortDateString();
//                            }
//                            else
//                                paramGrid1[1].Value = System.DateTime.Now.AddDays(-2).ToShortDateString();
//                            paramGrid1[2] = new OleDbParameter("@ATTENDANCE", OleDbType.VarChar);
//                            paramGrid1[2].Value = ArrPreAtten[i].ToString();
//                            OleDbHelper.ExecuteNonQuery(oledbTrans1, CommandType.Text, strSql, paramGrid1);
//                            Message = "Saved successfully !!!";
//                        }
//                        else
//                        {
//                            if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() != "Sunday")
//                            {
//                                strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrPreAtten[i].ToString() + "',CreateBy='" + AlistCreBy.ToString() + "',CreateDate='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' where   [DATE]>='" + System.DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy") + "' and [DATE]<'" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' AND EMP_ID=" + ArrListEmp[i].ToString() + " ";
//                            }
//                            else
//                                strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrPreAtten[i].ToString() + "',CreateBy='" + AlistCreBy.ToString() + "',CreateDate='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' where   [DATE]>='" + System.DateTime.Now.AddDays(-2).ToString("dd-MMM-yyyy") + "' and [DATE]<'" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' AND EMP_ID=" + ArrListEmp[i].ToString() + " ";

//                            OleDbHelper.ExecuteNonQuery(oledbTrans1, CommandType.Text, strSql);
//                            Message = "Updated successfully !!!";
//                        }
//                        oledbTrans1.Commit();
//                        conn1.Close();
//                    }
//                    catch (Exception ex)
//                    {
//                        oledbTrans1.Rollback();
//                        conn1.Close();
//                        Message = ex.Message;
//                    }
//                }
//            }
//        }
//    }

//    public void InsertAttendence(ArrayList ArrListEmp, ArrayList ArrListAtten, ArrayList ArrPreAtten, string AlistCreBy, DateTime AlistCreDate, int p)
//    {

//        OleDbParameter[] paramGrid = new OleDbParameter[5];

//        OleDbParameter[] paramGrid1 = new OleDbParameter[5];
//        if ((ToDate == null || ToDate == "") && (FromDate == null || FromDate == ""))
//        {
//            for (int i = 0; i <= ArrListEmp.Count - 1; i++)
//            {

//                string strSql = "";
//                //OleDbConnection conn = new OleDbConnection(con.ConnectionString);
//                //conn.Open();
//                //OleDbTransaction oledbTrans = conn.BeginTransaction();
//                int k = 0;
//                //try
//                //{
//                //    strSql = " select count(emp_id) from DATILY_ATTENDANCE where [Date]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' and emp_id=" + ArrListEmp[i].ToString() + "";
//                //    k = Convert.ToInt32(OleDbHelper.ExecuteScalar(oledbTrans, CommandType.Text, strSql));

//                //    if (k == 0)
//                //    {
//                //        strSql = "insert into DATILY_ATTENDANCE (EMP_ID,[DATE],ATTENDANCE,CreateBy,CreateDate) values(?,?,?,?,?)";
//                //        paramGrid[0] = new OleDbParameter("@EMP_ID", OleDbType.VarChar);
//                //        paramGrid[0].Value = ArrListEmp[i].ToString();
//                //        paramGrid[1] = new OleDbParameter("@[DATE]", OleDbType.Date);
//                //        paramGrid[1].Value = System.DateTime.Now.ToShortDateString();
//                //        paramGrid[2] = new OleDbParameter("@ATTENDANCE", OleDbType.VarChar);
//                //        paramGrid[2].Value = ArrListAtten[i].ToString();
//                //        paramGrid[3] = new OleDbParameter("@CreateBy", OleDbType.VarChar);
//                //        paramGrid[3].Value = AlistCreBy.ToString();
//                //        paramGrid[4] = new OleDbParameter("@CreateDate", OleDbType.Date);
//                //        paramGrid[4].Value = System.DateTime.Now.ToShortDateString();
//                //        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, strSql, paramGrid);
//                //        Message = "Saved successfully !!!";
//                //    }
//                //    else
//                //    {
//                //        strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrListAtten[i].ToString() + "',CreateBy='" + AlistCreBy.ToString() + "',CreateDate='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' where    [Date]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' and emp_id=" + ArrListEmp[i].ToString() + " ";

//                //        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, strSql);
//                //        Message = "Updated successfully !!!";
//                //    }
//                //    oledbTrans.Commit();
//                //conn.Close();
//                //}
//                //catch (Exception ex)
//                //{
//                //    oledbTrans.Rollback();
//                //    conn.Close();
//                //    Message = ex.Message;
//                //}
//                if (ColumnFlag == true)
//                {
//                    OleDbConnection conn1 = new OleDbConnection(con.ConnectionString);
//                    conn1.Open();
//                    OleDbTransaction oledbTrans1 = conn1.BeginTransaction();
//                    try
//                    {
//                        int s = p + 1;

//                        //if (System.DateTime.Now.AddDays(-p).DayOfWeek.ToString() != "Sunday")
//                        //{
//                        strSql = " select count(emp_id) from DATILY_ATTENDANCE where   [DATE]='" + System.DateTime.Now.AddDays(-p).ToString("dd-MMM-yyyy") + "'  and emp_id=" + ArrListEmp[i].ToString() + " ";
//                        //}
//                        //else
//                        //    strSql = " select count(emp_id) from DATILY_ATTENDANCE where   [DATE]='" + System.DateTime.Now.AddDays(-s).ToString("dd-MMM-yyyy") + "'  and emp_id=" + ArrListEmp[i].ToString() + " ";
//                        k = Convert.ToInt32(OleDbHelper.ExecuteScalar(oledbTrans1, CommandType.Text, strSql));

//                        if (k == 0)
//                        {
//                            strSql = "insert into DATILY_ATTENDANCE (EMP_ID,[DATE],ATTENDANCE,CreateBy,CreateDate) values(?,?,?,?,?)";
//                            paramGrid1[0] = new OleDbParameter("@EMP_ID", OleDbType.VarChar);
//                            paramGrid1[0].Value = ArrListEmp[i].ToString();
//                            paramGrid1[1] = new OleDbParameter("@[DATE]", OleDbType.Date);
//                            paramGrid1[1].Value = System.DateTime.Now.ToShortDateString();
//                            paramGrid1[3] = new OleDbParameter("@CreateBy", OleDbType.VarChar);
//                            paramGrid1[3].Value = AlistCreBy.ToString();
//                            paramGrid1[4] = new OleDbParameter("@CreateDate", OleDbType.Date);
//                            paramGrid1[4].Value = System.DateTime.Now.ToShortDateString();
//                            //if (System.DateTime.Now.AddDays(-p).DayOfWeek.ToString() != "Sunday")
//                            //{
//                            paramGrid1[1].Value = System.DateTime.Now.AddDays(-p).ToShortDateString();
//                            //}
//                            //else
//                            //    paramGrid1[1].Value = System.DateTime.Now.AddDays(-s).ToShortDateString();

//                            paramGrid1[2] = new OleDbParameter("@ATTENDANCE", OleDbType.VarChar);
//                            paramGrid1[2].Value = ArrListAtten[i].ToString();
//                            OleDbHelper.ExecuteNonQuery(oledbTrans1, CommandType.Text, strSql, paramGrid1);
//                            Message = "Saved successfully !!!";
//                        }
//                        else
//                        {
//                            //if (System.DateTime.Now.AddDays(-p).DayOfWeek.ToString() != "Sunday")
//                            //{
//                            strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrListAtten[i].ToString() + "',CreateBy='" + AlistCreBy.ToString() + "',CreateDate='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' where   [DATE]='" + System.DateTime.Now.AddDays(-p).ToString("dd-MMM-yyyy") + "' AND EMP_ID=" + ArrListEmp[i].ToString() + " ";
//                            //}
//                            //else
//                            //    strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrPreAtten[i].ToString() + "',CreateBy='" + AlistCreBy.ToString() + "',CreateDate='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' where   [DATE]='" + System.DateTime.Now.AddDays(-s).ToString("dd-MMM-yyyy") + "' AND EMP_ID=" + ArrListEmp[i].ToString() + " ";

//                            OleDbHelper.ExecuteNonQuery(oledbTrans1, CommandType.Text, strSql);
//                            Message = "Updated successfully !!!";
//                        }
//                        oledbTrans1.Commit();
//                        conn1.Close();
//                    }
//                    catch (Exception ex)
//                    {
//                        oledbTrans1.Rollback();
//                        conn1.Close();
//                        Message = ex.Message;
//                    }
//                }
//            }
//        }
//        else
//        {
//            for (int i = 0; i <= ArrListEmp.Count - 1; i++)
//            {

//                string strSql = "";
//                //OleDbConnection conn = new OleDbConnection(con.ConnectionString);
//                //conn.Open();
//                //OleDbTransaction oledbTrans = conn.BeginTransaction();
//                int k = 0;
//                //try
//                //{
//                //    strSql = " select count(emp_id) from DATILY_ATTENDANCE where [Date]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' and emp_id=" + ArrListEmp[i].ToString() + "";
//                //    k = Convert.ToInt32(OleDbHelper.ExecuteScalar(oledbTrans, CommandType.Text, strSql));

//                //    if (k == 0)
//                //    {
//                //        strSql = "insert into DATILY_ATTENDANCE (EMP_ID,[DATE],ATTENDANCE,CreateBy,CreateDate) values(?,?,?,?,?)";
//                //        paramGrid[0] = new OleDbParameter("@EMP_ID", OleDbType.VarChar);
//                //        paramGrid[0].Value = ArrListEmp[i].ToString();
//                //        paramGrid[1] = new OleDbParameter("@[DATE]", OleDbType.Date);
//                //        paramGrid[1].Value = System.DateTime.Now.ToShortDateString();
//                //        paramGrid[2] = new OleDbParameter("@ATTENDANCE", OleDbType.VarChar);
//                //        paramGrid[2].Value = ArrListAtten[i].ToString();
//                //        paramGrid[3] = new OleDbParameter("@CreateBy", OleDbType.VarChar);
//                //        paramGrid[3].Value = AlistCreBy.ToString();
//                //        paramGrid[4] = new OleDbParameter("@CreateDate", OleDbType.Date);
//                //        paramGrid[4].Value = System.DateTime.Now.ToShortDateString();
//                //        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, strSql, paramGrid);
//                //        Message = "Saved successfully !!!";
//                //    }
//                //    else
//                //    {
//                //        strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrListAtten[i].ToString() + "',CreateBy='" + AlistCreBy.ToString() + "',CreateDate='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' where    [Date]='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' and emp_id=" + ArrListEmp[i].ToString() + " ";

//                //        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, strSql);
//                //        Message = "Updated successfully !!!";
//                //    }
//                //    oledbTrans.Commit();
//                //conn.Close();
//                //}
//                //catch (Exception ex)
//                //{
//                //    oledbTrans.Rollback();
//                //    conn.Close();
//                //    Message = ex.Message;
//                //}
//                if (ColumnFlag == true)
//                {
//                    OleDbConnection conn1 = new OleDbConnection(con.ConnectionString);
//                    conn1.Open();
//                    OleDbTransaction oledbTrans1 = conn1.BeginTransaction();
//                    try
//                    {
//                        int s = p + 1;
//                        //if (Convert.ToDateTime(ToDate).AddDays(-p).DayOfWeek.ToString() != "Sunday")
//                        //// if (System.DateTime.Now.AddDays(-p).DayOfWeek.ToString() != "Sunday")
//                        //{
//                        strSql = " select count(emp_id) from DATILY_ATTENDANCE where   [DATE]='" + Convert.ToDateTime(ToDate).AddDays(-p).Date.ToString("yyyy-MM-dd HH:mm") + "'  and emp_id=" + ArrListEmp[i].ToString() + " ";
//                        //}
//                        //else
//                        //    strSql = " select count(emp_id) from DATILY_ATTENDANCE where   [DATE]='" + Convert.ToDateTime(ToDate).AddDays(-s).ToString("yyyy-MM-dd HH:mm") + "'  and emp_id=" + ArrListEmp[i].ToString() + " ";
//                        k = Convert.ToInt32(OleDbHelper.ExecuteScalar(oledbTrans1, CommandType.Text, strSql));

//                        if (k == 0)
//                        {
//                            strSql = "insert into DATILY_ATTENDANCE (EMP_ID,[DATE],ATTENDANCE,CreateBy,CreateDate) values(?,?,?,?,?)";
//                            paramGrid1[0] = new OleDbParameter("@EMP_ID", OleDbType.VarChar);
//                            paramGrid1[0].Value = ArrListEmp[i].ToString();
//                            paramGrid1[1] = new OleDbParameter("@[DATE]", OleDbType.Date);
//                            paramGrid1[1].Value = Convert.ToDateTime(ToDate).AddDays(-p).Date.ToString("yyyy-MM-dd HH:mm");
//                            paramGrid1[3] = new OleDbParameter("@CreateBy", OleDbType.VarChar);
//                            paramGrid1[3].Value = AlistCreBy.ToString();
//                            paramGrid1[4] = new OleDbParameter("@CreateDate", OleDbType.Date);
//                            paramGrid1[4].Value = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
//                            //if (Convert.ToDateTime(ToDate).AddDays(-p).Date.DayOfWeek.ToString("yyyy-MM-dd HH:mm:SS") != "Sunday")
//                            //{
//                            paramGrid1[1].Value = Convert.ToDateTime(ToDate).AddDays(-p).Date.ToString("yyyy-MM-dd HH:mm");
//                            //}
//                            //else
//                            //    paramGrid1[1].Value = Convert.ToDateTime(ToDate).AddDays(-s).Date.ToString("yyyy-MM-dd HH:mm");

//                            paramGrid1[2] = new OleDbParameter("@ATTENDANCE", OleDbType.VarChar);
//                            paramGrid1[2].Value = ArrListAtten[i].ToString();
//                            OleDbHelper.ExecuteNonQuery(oledbTrans1, CommandType.Text, strSql, paramGrid1);
//                            Message = "Saved successfully !!!";
//                        }
//                        else
//                        {
//                            //if (Convert.ToDateTime(ToDate).AddDays(-p).Date.DayOfWeek.ToString() != "Sunday")
//                            //{
//                            strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrListAtten[i].ToString() + "',CreateBy='" + AlistCreBy.ToString() + "',CreateDate='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' where   [DATE]='" + Convert.ToDateTime(ToDate).AddDays(-p).Date.ToString("yyyy-MM-dd HH:mm") + "' AND EMP_ID=" + ArrListEmp[i].ToString() + " ";
//                            //}
//                            //else
//                            //    strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrPreAtten[i].ToString() + "',CreateBy='" + AlistCreBy.ToString() + "',CreateDate='" + System.DateTime.Now.ToString("dd-MMM-yyyy") + "' where   [DATE]='" + Convert.ToDateTime(ToDate).AddDays(-s).ToString("yyyy-MM-dd HH:mm") + "' AND EMP_ID=" + ArrListEmp[i].ToString() + " ";

//                            OleDbHelper.ExecuteNonQuery(oledbTrans1, CommandType.Text, strSql);
//                            Message = "Updated successfully !!!";
//                        }
//                        oledbTrans1.Commit();
//                        conn1.Close();
//                    }
//                    catch (Exception ex)
//                    {
//                        oledbTrans1.Rollback();
//                        conn1.Close();
//                        Message = ex.Message;
//                    }
//                }
//            }
//        }
//    }

//    public DataSet GetHier()
//    {
//        DataSet ds = new DataSet();
//        string strSql = "";
//        strSql = " select cm.CENTRE_NAME,clm.cluster_name,SubCentreName from  centre_master cm " +
//                        " inner join SubCentreMaster scb on(cm.CENTRE_ID=scb.CentreId) " +
//                        " inner join cluster_master clm on(clm.cluster_id=cm.cluster_id) where SubCentreId = " + SubCentreID + " ";
//        if (SubCentreID == "" || SubCentreID == null)
//        {
//            strSql = " select cm.CENTRE_NAME,clm.cluster_name from  centre_master cm " +

//                          " inner join cluster_master clm on(clm.cluster_id=cm.cluster_id) where centre_id = " + CentreID + " ";
//        }
//        ds = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, strSql);
//        return ds;
//    }

//    public void UpdateAttendaceByHO(ArrayList ArrListEmp, ArrayList ArrListAtten, string Date, string AlistCreBy, DateTime AlistCreDate, string AlistModBy, DateTime AlistModDate)
//    {
//        OleDbConnection conn = new OleDbConnection(con.ConnectionString);
//        conn.Open();
//        OleDbTransaction oledbTrans = conn.BeginTransaction();
//        OleDbParameter[] paramGrid = new OleDbParameter[7];
//        string strSql = "";

//        try
//        {
//            for (int i = 0; i <= ArrListEmp.Count - 1; i++)
//            {
//                strSql = " select count(da.emp_id) from DATILY_ATTENDANCE DA  inner join employee_master em on (em.emp_id=da.emp_id) where   [DATE]='" + Date + "' and SUBCENTRE_ID=" + SubCentreID + " and da.emp_id='" + ArrListEmp[i].ToString() + "'";
//                int k = (int)OleDbHelper.ExecuteScalar(oledbTrans, CommandType.Text, strSql);
//                if (k != 0)
//                {
//                    strSql = "update  DATILY_ATTENDANCE   SET  ATTENDANCE='" + ArrListAtten[i].ToString() + "',ModifyBy='" + AlistModBy.ToString() + "',ModifyDate='" + System.DateTime.Now.ToShortDateString() + "' where [DATE]='" + Date + "' AND EMP_ID=" + ArrListEmp[i].ToString() + "  ";
//                    OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, strSql);
//                    Message = "Updated successfully !!!";
//                }
//                else
//                {
//                    strSql = "insert into DATILY_ATTENDANCE (EMP_ID,[DATE],ATTENDANCE,CreateBy,CreateDate,ModifyBy,ModifyDate) values(?,?,?,?,?,?,?)";
//                    paramGrid[0] = new OleDbParameter("@EMP_ID", OleDbType.VarChar);
//                    paramGrid[0].Value = ArrListEmp[i].ToString();
//                    paramGrid[1] = new OleDbParameter("@[DATE]", OleDbType.VarChar);
//                    paramGrid[1].Value = Date;
//                    paramGrid[2] = new OleDbParameter("@ATTENDANCE", OleDbType.VarChar);
//                    paramGrid[2].Value = ArrListAtten[i].ToString();
//                    paramGrid[3] = new OleDbParameter("@ModifyBy", OleDbType.VarChar);
//                    paramGrid[3].Value = AlistModBy.ToString();
//                    paramGrid[4] = new OleDbParameter("@ModifyDate", OleDbType.Date);
//                    paramGrid[4].Value = System.DateTime.Now.ToShortDateString();
//                    paramGrid[5] = new OleDbParameter("@CreateBy", OleDbType.VarChar);
//                    paramGrid[5].Value = AlistCreBy.ToString();
//                    paramGrid[6] = new OleDbParameter("@CreateDate", OleDbType.Date);
//                    paramGrid[6].Value = System.DateTime.Now.ToShortDateString();
//                    OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, strSql, paramGrid);
//                    Message = "Saved successfully !!!";
//                }


//            }
//            oledbTrans.Commit();
//            conn.Close();

//        }
//        catch (Exception ex)
//        {
//            oledbTrans.Rollback();
//            conn.Close();
//            Message = ex.Message;
//        }
//    }
//}
