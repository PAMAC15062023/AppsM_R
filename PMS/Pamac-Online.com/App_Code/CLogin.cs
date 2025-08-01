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
using System.Data.OleDb;
using myInfo;

/// <summary>
/// This class is for user authenticatuion.
/// </summary>

public class CLogin
{
    private string strUserName;
    private string strPassword;
    private string strCentreId;
    private string strLogId;

    private string strHierarchyId;
    private string strRoleId;
    private decimal strUserLevel;
    private string strUserId;
    private string strFLName;
    private string strPrefix;

    private CCommon objConn;

    public string UserName
    {
        get { return strUserName; }
        set { strUserName = value; }
    }

   
    public string Password
    {
        get { return strPassword; }
        set { strPassword = value; }
    }

    public string CentreId
    {
        get { return strCentreId; }
        set { strCentreId = value; }
    }

    public string HierarchyId
    {
        get { return strHierarchyId; }
        set { strHierarchyId = value; }
    }

    public string RoleId
    {
        get { return strRoleId; }
        set { strRoleId = value; }
    }

    public decimal UserLevel
    {
        get { return strUserLevel; }
        set { strUserLevel = value; }
    }

    public string UserId
    {
        get { return strUserId; }
        set { strUserId = value; }
    }

    public string LogId
    {
        get { return strLogId; }
        set { strLogId = value; }
    }

    public string FLName
    {
        get { return strFLName; }
        set { strFLName = value; }
    }

    public string Prefix
    {
        get { return strPrefix; }
    }

    public CLogin()
	{
        objConn = new CCommon();
	}

    public void LogInfo()
    {
        string strPrefix = "101";

        OleDbConnection sqlconn = new OleDbConnection(objConn.ConnectionString);
        sqlconn.Open();

        OleDbTransaction sqlTrans = sqlconn.BeginTransaction();
        try
        {
            LogId = objConn.GetUniqueID("FE_LOGIN_DETAIL", strPrefix);
            string sqlLoginLog;
            sqlLoginLog = "Insert into FE_Login_Detail (LOG_DET_ID, FE_ID, LOGIN_DATE) values( ?, ?, ?)";
            OleDbParameter[] paramLoginLog = new OleDbParameter[3];
            paramLoginLog[0] = new OleDbParameter("LOG_DET_ID", OleDbType.VarChar);
            paramLoginLog[0].Value = LogId;
            paramLoginLog[1] = new OleDbParameter("FE_ID", OleDbType.VarChar);
            paramLoginLog[1].Value = UserId;
            paramLoginLog[2] = new OleDbParameter("LOGIN_DATE", OleDbType.VarChar);
            paramLoginLog[2].Value = DateTime.Now;

            int intQueryResult = OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sqlLoginLog, paramLoginLog);
            sqlTrans.Commit();
            sqlconn.Close();
        }
        catch (Exception exp)
        {
            sqlTrans.Rollback();
            sqlconn.Close();
        }
    }

    public String UserAuthenticate()
    {
        string sqlUser = "Select a.userid from user_master a, employee_master b where a.userid = b.emp_id and (DOL is null or DOL = '') and a.loginname=? and a.password=?";
        OleDbParameter[] paramUser = new OleDbParameter[2];
        object o;
        paramUser[0] = new OleDbParameter("loginname", OleDbType.VarChar);
        paramUser[0].Value = UserName;
        paramUser[1] = new OleDbParameter("password", OleDbType.VarChar);
        paramUser[1].Value = Password;
        o = OleDbHelper.ExecuteScalar(objConn.ConnectionString, CommandType.Text, sqlUser, paramUser);
        if (o != null)
        {
            sqlUser = "SELECT UR.ROLE_ID, EM.FIRSTNAME + ' ' + EM.LASTNAME AS FLNAME " +
                      " FROM USER_MASTER UM INNER JOIN " +
                      " USER_ROLE UR ON UM.USERID = UR.USER_ID INNER JOIN  " +
                      " EMPLOYEE_MASTER EM ON UM.USERID = EM.EMP_ID " +
                      " WHERE (UM.USERID = ?)";

            OleDbParameter paramHierarchy = new OleDbParameter("UserId", OleDbType.VarChar);
            strUserId = o.ToString();
            paramHierarchy.Value = o.ToString();
            OleDbDataReader drHierarchy = OleDbHelper.ExecuteReader(objConn.ConnectionString, CommandType.Text, sqlUser, paramHierarchy);
            int count = 0;
            while (drHierarchy.Read())
            {
                if (count == 0)
                {
                    strRoleId = (string)drHierarchy["ROLE_ID"];
                    //strHierarchyId = (string)drHierarchy["HIER_ID"];
                    //strUserLevel = (decimal)drHierarchy["HIER_LEVEL"];
                    strFLName = (string)drHierarchy["FLNAME"];
                }
                else
                {
                    strRoleId = strRoleId + "," + (string)drHierarchy["ROLE_ID"];
                }

                count += 1;
            }
            drHierarchy.Close();

            sqlUser = "SELECT UH.USER_ID, CHM.HIER_LEVEL,UH.HIER_ID " +
                      " FROM USER_HIERARCHY UH INNER JOIN " +
                      " COMPANY_HIERARCHY_MASTER CHM ON UH.HIER_ID = CHM.HIER_ID " +
                      " where (UH.User_id = ?) order by  CHM.HIER_LEVEL";

            OleDbParameter paramHierarchy1 = new OleDbParameter("UserId1", OleDbType.VarChar);
            paramHierarchy1.Value = strUserId;

            drHierarchy = OleDbHelper.ExecuteReader(objConn.ConnectionString, CommandType.Text, sqlUser, paramHierarchy1);

            strHierarchyId = "";
            //strUserLevel = "";
            bool isAuthorised = false;
            while (drHierarchy.Read() && !isAuthorised)
            {
                strHierarchyId = (string)drHierarchy["HIER_ID"];
                strUserLevel = (decimal)drHierarchy["HIER_LEVEL"];

                int caseSwitch = (int)strUserLevel;
                if (caseSwitch < 3)
                {
                    isAuthorised = true;
                    //drHierarchy.Close();
                    //return "0";
                }
                else
                {
                    OleDbParameter paramCentre;
                    switch (caseSwitch)
                    {
                        case 6:
                            sqlUser = "select ref_id from company_hierarchy_master where hier_id=(select parent_id from company_hierarchy_master where hier_id=(select parent_id from company_hierarchy_master where hier_id=(select parent_id from company_hierarchy_master where hier_id = ?)))";
                            paramCentre = new OleDbParameter("hier_id", OleDbType.VarChar);
                            paramCentre.Value = strHierarchyId;
                            o = OleDbHelper.ExecuteScalar(objConn.ConnectionString, CommandType.Text, sqlUser, paramCentre);
                            //if (o.ToString() == CentreId)
                                isAuthorised = true;
                            break;
                        case 5:
                            sqlUser = "select ref_id from company_hierarchy_master where hier_id=(select parent_id from company_hierarchy_master where hier_id=(select parent_id from company_hierarchy_master where hier_id=?))";
                            paramCentre = new OleDbParameter("hier_id", OleDbType.VarChar);
                            paramCentre.Value = strHierarchyId;
                            o = OleDbHelper.ExecuteScalar(objConn.ConnectionString, CommandType.Text, sqlUser, paramCentre);
                            if (o.ToString() == CentreId)
                                isAuthorised = true;
                            break;
                        case 4:
                            sqlUser = "select ref_id from company_hierarchy_master where hier_id=(select parent_id from company_hierarchy_master where hier_id=?)";
                            paramCentre = new OleDbParameter("hier_id", OleDbType.VarChar);
                            paramCentre.Value = strHierarchyId;
                            o = OleDbHelper.ExecuteScalar(objConn.ConnectionString, CommandType.Text, sqlUser, paramCentre);
                            if (o.ToString() == CentreId)
                                isAuthorised = true;
                            break;
                        case 3:
                            sqlUser = "select ref_id from company_hierarchy_master where hier_id= ?";
                            paramCentre = new OleDbParameter("hier_id", OleDbType.VarChar);
                            paramCentre.Value = strHierarchyId;
                            o = OleDbHelper.ExecuteScalar(objConn.ConnectionString, CommandType.Text, sqlUser, paramCentre);
                            if (o.ToString() == CentreId || o.ToString() == "99999" ) 
                                isAuthorised = true;
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;
                    }
                }
            }
            drHierarchy.Close();
            if (isAuthorised)
            {
                object obj = OleDbHelper.ExecuteScalar(objConn.ConnectionString, CommandType.Text, " Select Prefix from Company_Centre_Prefix ccp inner join centre_master cm on(cm.centre_id=ccp.centre_id)");
                strPrefix = obj.ToString();
                return "0";
            }
            else
                return "2";
        }
        else
            return "1";
    }

    public string GetCluster()
    {
        string strSqlCluster = "SELECT DISTINCT REF_ID FROM COMPANY_HIERARCHY_MASTER " +
                               " WHERE (HIER_ID IN (SELECT Parent_id FROM COMPANY_HIERARCHY_MASTER " +
                               " WHERE (REF_ID ='" + CentreId + "') AND (HIER_LEVEL = 3)))";
        object obj = OleDbHelper.ExecuteScalar(objConn.ConnectionString, CommandType.Text, strSqlCluster);
        if (obj != null)
        {
            return obj.ToString();
        }
        else
        {
            return "";
        }
    }

   public string GetSubCenter()
    {
        //Session["UserId"] = objLogin.UserId;
        string strSqlSubCenter = "SELECT subcentre_id FROM employee_master where emp_id='" + UserId + "'";

        object obj = OleDbHelper.ExecuteScalar(objConn.ConnectionString, CommandType.Text, strSqlSubCenter);
        if (obj != null)
        {
            return obj.ToString();
        }
        else
        {
            return "";
        }
    }




    public void InsertLoginDetail()
    {
        try
        {
            string LogId1 = objConn.GetUniqueID("LOGIN_DETAIL", strPrefix);
            LogId = LogId1;
            string RolID = HttpContext.Current.Session["RoleId"].ToString();
          
                
                string strLoginDetail = "insert into LOGIN_DETAIL (LOGIN_ID,ROL_ID,LOG_DET_ID,CENTRE_ID,LOGIN_DATETIME,CLUSTER_ID) "+
                                        " values('" + UserId + "','" + RolID + "','" + LogId1 + "','" + CentreId + "','" + System.DateTime.Now + "', " +
                                        " '" + HttpContext.Current.Session["ClusterId"].ToString() + "')";


                OleDbHelper.ExecuteNonQuery(objConn.ConnectionString, CommandType.Text, strLoginDetail);
                
            
        }
        catch
        {
 
        }
    }

    public void InsertLoginDetail_ChangePass()
    {
        try
        {
            string LogId1 = objConn.GetUniqueID("LOGIN_DETAIL", "101");
            LogId = LogId1;
            string RolID = HttpContext.Current.Session["RoleId"].ToString();


            string strLoginDetail = "insert into LOGIN_DETAIL (LOGIN_ID,ROL_ID,LOG_DET_ID,CENTRE_ID,LOGIN_DATETIME,CLUSTER_ID) " +
                                    " values('" + UserId + "','" + RolID + "','" + LogId1 + "','" + CentreId + "','" + System.DateTime.Now + "', " +
                                    " '" + HttpContext.Current.Session["ClusterId"].ToString() + "')";


            OleDbHelper.ExecuteNonQuery(objConn.ConnectionString, CommandType.Text, strLoginDetail);


        }
        catch
        {

        }
    }
  
    public void UpdateLogoutTime()
    {
        try
        {
            string strClientID = HttpContext.Current.Session["ClientId"].ToString();
            string strLoginDetail = "";
            if (strClientID != "")
            {
                strLoginDetail = " update LOGIN_DETAIL set LOGOUT_DATETIME='" + System.DateTime.Now + "',CLIENT_ID='" + HttpContext.Current.Session["ClientId"].ToString() + "' where LOG_DET_ID='" + HttpContext.Current.Session["LogID"].ToString() + "' ";

            }
            else
            {
                strLoginDetail = " update LOGIN_DETAIL set LOGOUT_DATETIME='" + System.DateTime.Now + "' where LOG_DET_ID='" + HttpContext.Current.Session["LogID"].ToString() + "' ";
            }
            OleDbHelper.ExecuteNonQuery(objConn.ConnectionString, CommandType.Text, strLoginDetail);
        }
        catch
        {

        }
        finally
        {
        }
    }

    public void UpdateLogoutTime2()
    {
        try
        {
            //string strClientID = HttpContext.Current.Session["ClientId"].ToString();

            string LOG_DET_ID = HttpContext.Current.Session["userid"].ToString();
            OleDbParameter[] paramUser_info1 = new OleDbParameter[1];

            paramUser_info1[0] = new OleDbParameter("@LOG_DET_ID", OleDbType.VarChar);
            paramUser_info1[0].Value = LOG_DET_ID;

            OleDbHelper.ExecuteNonQuery(objConn.ConnectionString, CommandType.StoredProcedure, "sp_UpdateLogoutTime2", paramUser_info1);

        }
        catch
        {

        }
    }

    //Rupesh
    public string GetToken()
    {
        string strGetToken = "select Token from TokenMaster where userid='" + UserId + "'";

        object obj = OleDbHelper.ExecuteScalar(objConn.ConnectionString, CommandType.Text, strGetToken);
        if (obj != null)
        {
            return obj.ToString();
        }
        else
        {
            return "";
        }
    }

}
