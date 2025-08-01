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
/// Summary description for CEmployeeMaster
/// /// //Name          :  CEmployeeMaster
//Description   :  To Select, Insert, Update and Delete Employee Details
//Created By    :  Asavari Sonawane
//Created On    :  14-May-2007

/// </summary>
public class CEmployeeMaster
{
    private CCommon oCmn;
    public CEmployeeMaster()
    {
        oCmn = new CCommon();
    }
    #region Propery Declarion For Employee_Master
    private String sEmpCode;        //1
    private String sFName;          //2
    private String sMName;          //3
    private String sLName;          //4
    private String sDoB;
    //5
    private String sDoL;
    private String sGender;         //6
    private String sAdd1;           //7
    private String sAdd2;           //8
    private String sAdd3;           //9
    private String sCity;           //10
    private String sPin;            //11
    private String sMobile;         //12
    private String sPhone;          //13
    private String sEmpType;        //14
    private String sDesignation;    //15
    private String sDepartment;     //16    
    private String sCentreID;       //17
    private String sCompanyID;      //18   
    private String sAddOn;            //19
    private String sAddedBy;        //20
    private String sModifyOn;         //21
    private String sModifyBy;       //22  
    private String sFullName;       //23
    private String sEmpID;          //24
    private String sDoJ;            //25

    private String strSubCentreID;
    public String SubCentreID    //1
    {
        get { return strSubCentreID; }
        set
        {
            if (value == "")
            {
                strSubCentreID = null;
            }
            else
            {
                strSubCentreID = value;
            }
        }
    }
    private String strUnit;
    public String Unit    //1
    {
        get { return strUnit; }
        set
        {
            if (value == "")
            {
                strUnit = null;
            }
            else
            {
                strUnit = value;
            }
        }
    }
    private String strSuvidhaAC;
    public String SuvidhaAC    //1
    {
        get { return strSuvidhaAC; }
        set
        {
            if (value == "")
            {
                strSuvidhaAC = null;
            }
            else
            {
                strSuvidhaAC = value;
            }
        }
    }
    private String strResignation;
    public String Resignation    //1
    {
        get { return strResignation; }
        set
        {
            if (value == "")
            {
                strResignation = null;
            }
            else
            {
                strResignation = value;
            }
        }
    }
    private String strLeftOrganisation;
    public String LeftOrganisation    //1
    {
        get { return strLeftOrganisation; }
        set
        {
            if (value == "")
            {
                strLeftOrganisation = null;
            }
            else
            {
                strLeftOrganisation = value;
            }
        }
    }

    public String EmpCode    //1
    {
        get { return sEmpCode; }
        set
        {
            if (value == "")
            {
                sEmpCode = null;
            }
            else
            {
                sEmpCode = value;
            }
        }
    }
    public String FName    //2
    {
        get { return sFName; }
        set
        {
            //if (value == "")
            //{
            //    sFName = null;
            //}
            //else
            //{
            sFName = value;
            //}
        }
    }
    public String MName    //3
    {
        get { return sMName; }
        set
        {
            if (value == "")
            {
                sMName = null;
            }
            else
            {
                sMName = value;
            }
        }
    }
    //Changed by Prashant Rewale
    public String LName    //4
    {
        get { return sLName; }
        set
        {
            //if (value == "")
            //{
            //    sLName = null;
            //}
            //else
            //{
            sLName = value;
            //}
        }
    }
    public String DoB    //5
    {
        get { return sDoB; }
        set
        {
            if (value == "")
            {
                sDoB = null;
            }
            else
            {
                sDoB = value;
            }
        }
    }
    public String DoL    //5
    {
        get { return sDoL; }
        set
        {
            if (value == "")
            {
                sDoL = null;
            }
            else
            {
                sDoL = value;
            }
        }
    }
    public String Gender    //6
    {
        get { return sGender; }
        set
        {
            if (value == "")
            {
                sGender = null;
            }
            else
            {
                sGender = value;
            }
        }
    }
    public String Add1    //7
    {
        get { return sAdd1; }
        set
        {
            if (value == "")
            {
                sAdd1 = null;
            }
            else
            {
                sAdd1 = value;
            }
        }
    }
    public String Add2    //8
    {
        get { return sAdd2; }
        set
        {
            if (value == "")
            {
                sAdd2 = null;
            }
            else
            {
                sAdd2 = value;
            }
        }
    }
    public String Add3    //9
    {
        get { return sAdd3; }
        set
        {
            if (value == "")
            {
                sAdd3 = null;
            }
            else
            {
                sAdd3 = value;
            }
        }
    }
    public String City    //10
    {
        get { return sCity; }
        set
        {
            if (value == "")
            {
                sCity = null;
            }
            else
            {
                sCity = value;
            }
        }
    }
    public String Pin    //11
    {
        get { return sPin; }
        set
        {
            if (value == "")
            {
                sPin = null;
            }
            else
            {
                sPin = value;
            }
        }
    }
    public String Mobile    //12
    {
        get { return sMobile; }
        set
        {
            if (value == "")
            {
                sMobile = null;
            }
            else
            {
                sMobile = value;
            }
        }
    }
    public String Phone    //13
    {
        get { return sPhone; }
        set
        {
            if (value == "")
            {
                sPhone = null;
            }
            else
            {
                sPhone = value;
            }
        }
    }
    public String EmpType    //14
    {
        get { return sEmpType; }
        set
        {
            if (value == "")
            {
                sEmpType = null;
            }
            else
            {
                sEmpType = value;
            }
        }
    }
    public String Designation    //15
    {
        get { return sDesignation; }
        set
        {
            if (value == "")
            {
                sDesignation = null;
            }
            else
            {
                sDesignation = value;
            }
        }
    }
    public String Department    //16
    {
        get { return sDepartment; }
        set
        {
            if (value == "")
            {
                sDepartment = null;
            }
            else
            {
                sDepartment = value;
            }
        }
    }
    public String CentreID    //17
    {
        get { return sCentreID; }
        set
        {
            if (value == "")
            {
                sCentreID = null;
            }
            else
            {
                sCentreID = value;
            }
        }
    }
    public String CompanyID    //18
    {
        get { return sCompanyID; }
        set
        {
            if (value == "")
            {
                sCompanyID = null;
            }
            else
            {
                sCompanyID = value;
            }
        }
    }

    public String AddOn    //19
    {
        get { return sAddOn; }
        set
        {
            if (value == "")
            {
                sAddOn = null;
            }
            else
            {
                sAddOn = value;
            }
        }
    }
    public String AddedBy    //20
    {
        get { return sAddedBy; }
        set
        {
            if (value == "")
            {
                sAddedBy = null;
            }
            else
            {
                sAddedBy = value;
            }
        }
    }
    public String ModifyOn    //21
    {
        get { return sModifyOn; }
        set
        {
            if (value == "")
            {
                sModifyOn = null;
            }
            else
            {
                sModifyOn = value;
            }
        }
    }
    public String ModifyBy    //22
    {
        get { return sModifyBy; }
        set
        {
            if (value == "")
            {
                sModifyBy = null;
            }
            else
            {
                sModifyBy = value;
            }
        }
    }
    public String FullName    //23
    {
        get { return sFullName; }
        set
        {
            if (value == "")
            {
                sFullName = null;
            }
            else
            {
                sFullName = value;
            }
        }
    }
    public String EmpID    //24
    {
        get { return sEmpID; }
        set
        {
            if (value == "")
            {
                sEmpID = null;
            }
            else
            {
                sEmpID = value;
            }
        }
    }
    public String DoJ    //25
    {
        get { return sDoJ; }
        set
        {
            if (value == "")
            {
                sDoJ = null;
            }
            else
            {
                sDoJ = value;
            }
        }
    }

    #endregion

    #region Propery Declarion For User_Master
    private String sUserID;     //1
    private String sUserName;   //2
    private String sLoginName;  //3
    private String sPassword;   //4
    private String sUserLevel;  //5

    public String UserID    //1
    {
        get { return sUserID; }
        set
        {
            if (value == "")
            {
                sUserID = null;
            }
            else
            {
                sUserID = value;
            }
        }
    }
    public String UserName    //2
    {
        get { return sUserName; }
        set
        {
            if (value == "")
            {
                sUserName = null;
            }
            else
            {
                sUserName = value;
            }
        }
    }
    public String LoginName    //3
    {
        get { return sLoginName; }
        set
        {
            if (value == "")
            {
                sLoginName = null;
            }
            else
            {
                sLoginName = value;
            }
        }
    }
    public String Password    //4
    {
        get { return sPassword; }
        set
        {
            if (value == "")
            {
                sPassword = null;
            }
            else
            {
                sPassword = value;
            }
        }
    }
    public String UserLevel    //5
    {
        get { return sUserLevel; }
        set
        {
            if (value == "")
            {
                sUserLevel = null;
            }
            else
            {
                sUserLevel = value;
            }
        }
    }
    #endregion
    //To Check Login Name Exist or Not
    public Boolean chkLoginName()
    {
        if (LoginName != "")
        {
            //Create and open Connection
            OleDbConnection sqlconn = new OleDbConnection(oCmn.ConnectionString);

            sqlconn.Open();
            //Create and open Transaction
            OleDbTransaction sqlTrans = sqlconn.BeginTransaction();
            String sSql = "";
            Int32 retVal = 0;
            try
            {
                sSql = "SELECT LOGINNAME FROM USER_MASTER WHERE LOGINNAME = '" + LoginName + "' AND 1=1 ";
                if (EmpID != null)
                {
                    sSql = sSql + " AND USERID <> '" + EmpID + "'";
                }
                OleDbDataReader oDr = OleDbHelper.ExecuteReader(sqlTrans, CommandType.Text, sSql);
                if (oDr.HasRows)
                {
                    retVal = 0;
                }
                else
                {
                    retVal = 1;
                }
                oDr.Close();
                sqlTrans.Commit();
                sqlconn.Close();

                if (retVal == 0)
                    return true;
                else
                    return false;
            }
            catch (Exception exp)
            {
                sqlTrans.Rollback();
                sqlconn.Close();
                throw new Exception("An Error Occurred ", exp);
            }
        }
        else
            return true;
    }

    public Boolean chkEmpCode()
    {
        if (LoginName != "")
        {
            //Create and open Connection
            OleDbConnection sqlconn = new OleDbConnection(oCmn.ConnectionString);

            sqlconn.Open();
            //Create and open Transaction
            OleDbTransaction sqlTrans = sqlconn.BeginTransaction();
            String sSql = "";
            Int32 retVal = 0;
            try
            {
                sSql = "SELECT EMP_CODE FROM EMPLOYEE_MASTER WHERE EMP_CODE = '" + EmpCode + "' AND 1=1 ";
                if (EmpID != null)
                {
                    sSql = sSql + " AND EMP_ID <> '" + EmpID + "'";
                }
                OleDbDataReader oDr = OleDbHelper.ExecuteReader(sqlTrans, CommandType.Text, sSql);
                if (oDr.HasRows)
                {
                    retVal = 0;
                }
                else
                {
                    retVal = 1;
                }
                oDr.Close();
                sqlTrans.Commit();
                sqlconn.Close();

                if (retVal == 0)
                    return true;
                else
                    return false;
            }
            catch (Exception exp)
            {
                sqlTrans.Rollback();
                sqlconn.Close();
                throw new Exception("An Error Occurred ", exp);
            }
        }
        else
            return true;
    }

    public void GetEmployee()
    {
        //Create and open Connection
        OleDbConnection sqlconn = new OleDbConnection(oCmn.ConnectionString);
        sqlconn.Open();
        //Create and open Transaction
        OleDbTransaction sqlTrans = sqlconn.BeginTransaction();
        String sSql1 = "";

        OleDbDataReader oSDR1;


        try
        {
            sSql1 = "SELECT * FROM EMPLOYEE_MASTER INNER JOIN USER_MASTER ON EMP_ID=USERID AND EMP_ID = '" + EmpID + "'";

            //Select From EMPLOYEE_MASTER
            oSDR1 = OleDbHelper.ExecuteReader(sqlTrans, CommandType.Text, sSql1);
            if (oSDR1.HasRows)
            {
                if (oSDR1.Read())
                {
                    Add1 = oSDR1["ADD1"].ToString();
                    Add2 = oSDR1["ADD2"].ToString();
                    Add3 = oSDR1["ADD3"].ToString();
                    City = oSDR1["CITY"].ToString();
                    Department = oSDR1["DEPARTMENT_ID"].ToString();
                    Designation = oSDR1["DESIGNATION_ID"].ToString();
                    EmpCode = oSDR1["EMP_CODE"].ToString();
                    FName = oSDR1["FIRSTNAME"].ToString();
                    MName = oSDR1["MIDDLENAME"].ToString();
                    LName = oSDR1["LASTNAME"].ToString();
                    Gender = oSDR1["GENDER"].ToString();

                    DoB = oSDR1["DOB"].ToString();
                    if (DoB != null)
                        DoB = Convert.ToDateTime(DoB).ToString("dd/MM/yyyy");
                    //TxtDate.Text = Convert.ToDateTime(oledbDR["ATTEMPT_DATETIME"].ToString()).ToString("dd/MM/yyyy");



                    DoL = oSDR1["DOL"].ToString();
                    if (DoL != null)
                        DoL = Convert.ToDateTime(DoL).ToString("dd/MM/yyyy");



                    DoJ = oSDR1["DOJ"].ToString();
                    if (DoJ != null)
                        DoJ = Convert.ToDateTime(DoJ).ToString("dd/MM/yyyy");
                    Mobile = oSDR1["MOBILE"].ToString();
                    Phone = oSDR1["PHONE_R"].ToString();
                    Pin = oSDR1["PIN"].ToString();
                    EmpType = oSDR1["EMP_TYPE"].ToString();
                    LoginName = oSDR1["LOGINNAME"].ToString();
                    SubCentreID = oSDR1["SUBCENTRE_ID"].ToString();
                    Unit = oSDR1["UNIT"].ToString();
                    SuvidhaAC = oSDR1["SUVIDHA_AC"].ToString();
                    Resignation = oSDR1["RESIGNATION"].ToString();
                    LeftOrganisation = oSDR1["LEFT_ORGANIZATION"].ToString();
                }
            }
            oSDR1.Close();

            sqlTrans.Commit();
            sqlconn.Close();
        }
        catch (System.Exception ex)
        {
            sqlTrans.Rollback();
            sqlconn.Close();
            throw new Exception("An error occurred while executing the GetAllCases()", ex);
        }
        finally
        {
            //Some action 
        }
    }

    public void InsertEmployee()
    {
        String sSql1 = "";
        String sSql2 = "";
        //Create and open Connection
        OleDbConnection sqlconn = new OleDbConnection(oCmn.ConnectionString);
        sqlconn.Open();
        //Create and open Transaction
        OleDbTransaction sqlTrans = sqlconn.BeginTransaction();
        try
        {
            //To Get Unique CaseID
            EmpID = oCmn.GetUniqueID("EMPLOYEE_MASTER", "201").ToString();
            if (FName != null)
                FullName = FName + " ";
            if (LName != null)
                FullName = FullName + MName + " ";
            if (LName != null)
                FullName = FullName + LName;

            FullName = FullName.Trim();

            //Case Master Insert Query
            sSql1 = "INSERT INTO EMPLOYEE_MASTER(EMP_ID, EMP_CODE, FIRSTNAME, MIDDLENAME,  LASTNAME, FULLNAME, " +
                   "GENDER, DOB, DOJ, ADD1, ADD2, ADD3, CITY, PIN, MOBILE, PHONE_R, EMP_TYPE, DESIGNATION_ID, DEPARTMENT_ID, " +
                   "CENTRE_ID,  ADD_DATE, ADD_USER_ID,DOL,SUBCENTRE_ID,UNIT,SUVIDHA_AC,RESIGNATION,LEFT_ORGANIZATION) " +
                   "VALUES (?, ?, ?, ?, ?, ?, " +
                   "?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, " +
                   "?, ?, ?, ?,?,?,?,?,?)";

            OleDbParameter[] param_Employee_Master = new OleDbParameter[28];
            param_Employee_Master[0] = new OleDbParameter("EMP_ID", OleDbType.VarChar);
            param_Employee_Master[0].Value = EmpID;
            param_Employee_Master[1] = new OleDbParameter("EMP_CODE", OleDbType.VarChar);
            param_Employee_Master[1].Value = EmpCode;
            param_Employee_Master[2] = new OleDbParameter("FIRSTNAME", OleDbType.VarChar);
            param_Employee_Master[2].Value = FName;
            param_Employee_Master[3] = new OleDbParameter("MIDDLENAME", OleDbType.VarChar);
            param_Employee_Master[3].Value = MName;
            param_Employee_Master[4] = new OleDbParameter("LASTNAME", OleDbType.VarChar);
            param_Employee_Master[4].Value = LName;
            param_Employee_Master[5] = new OleDbParameter("FULLNAME", OleDbType.VarChar);
            param_Employee_Master[5].Value = FullName;
            param_Employee_Master[6] = new OleDbParameter("GENDER", OleDbType.VarChar);
            param_Employee_Master[6].Value = Gender;
            param_Employee_Master[7] = new OleDbParameter("DOB", OleDbType.Date);
            if (DoB != null)
                param_Employee_Master[7].Value = Convert.ToDateTime(oCmn.strDate(DoB));
                //param_Employee_Master[7].Value = Convert.ToDateTime(DoB).ToString("dd/MMM/yyyy");
            else
                param_Employee_Master[7].Value = DoB;

            param_Employee_Master[8] = new OleDbParameter("DOJ", OleDbType.Date);
            if (DoJ != null)
                param_Employee_Master[8].Value = Convert.ToDateTime(oCmn.strDate(DoJ));
               // param_Employee_Master[8].Value = Convert.ToDateTime(DoJ).ToString("dd/MMM/yyyy");
            else
                param_Employee_Master[8].Value = DoJ;

            param_Employee_Master[9] = new OleDbParameter("ADD1", OleDbType.VarChar);
            param_Employee_Master[9].Value = Add1;
            param_Employee_Master[10] = new OleDbParameter("ADD2", OleDbType.VarChar);
            param_Employee_Master[10].Value = Add2;
            param_Employee_Master[11] = new OleDbParameter("ADD3", OleDbType.VarChar);
            param_Employee_Master[11].Value = Add3;
            param_Employee_Master[12] = new OleDbParameter("CITY", OleDbType.VarChar);
            param_Employee_Master[12].Value = City;
            param_Employee_Master[13] = new OleDbParameter("PIN", OleDbType.VarChar);
            param_Employee_Master[13].Value = Pin;
            param_Employee_Master[14] = new OleDbParameter("MOBILE", OleDbType.VarChar);
            param_Employee_Master[14].Value = Mobile;
            param_Employee_Master[15] = new OleDbParameter("PHONE_R", OleDbType.VarChar);
            param_Employee_Master[15].Value = Phone;
            param_Employee_Master[16] = new OleDbParameter("EMP_TYPE", OleDbType.VarChar);
            param_Employee_Master[16].Value = EmpType;
            param_Employee_Master[17] = new OleDbParameter("DESIGNATION_ID", OleDbType.VarChar);
            param_Employee_Master[17].Value = Designation;
            param_Employee_Master[18] = new OleDbParameter("DEPARTMENT_ID", OleDbType.VarChar);
            param_Employee_Master[18].Value = Department;
            param_Employee_Master[19] = new OleDbParameter("CENTRE_ID", OleDbType.VarChar);
            param_Employee_Master[19].Value = CentreID;
       
            param_Employee_Master[20] = new OleDbParameter("ADD_DATE", OleDbType.VarChar);
            param_Employee_Master[20].Value = DateTime.Now;
            //param_Employee_Master[20].Value = DateTime.Now.ToString("dd/MMM/yyyy hh:mm:ss");
            
            param_Employee_Master[21] = new OleDbParameter("ADD_USER_ID", OleDbType.VarChar);
            param_Employee_Master[21].Value = AddedBy;

            param_Employee_Master[22] = new OleDbParameter("DOL", OleDbType.Date);
            if (DoL != null)
                param_Employee_Master[22].Value = Convert.ToDateTime(oCmn.strDate(DoL));
            else
                param_Employee_Master[22].Value = DoL;

            param_Employee_Master[23] = new OleDbParameter("SUBCENTRE_ID", OleDbType.VarChar, 50);
            param_Employee_Master[23].Value = SubCentreID;
            param_Employee_Master[24] = new OleDbParameter("UNIT", OleDbType.VarChar, 100);
            param_Employee_Master[24].Value = Unit;
            param_Employee_Master[25] = new OleDbParameter("SUVIDHA_AC", OleDbType.VarChar, 50);
            param_Employee_Master[25].Value = SuvidhaAC;
            param_Employee_Master[26] = new OleDbParameter("RESIGNATION", OleDbType.Char, 1);
            param_Employee_Master[26].Value = Resignation;
            param_Employee_Master[27] = new OleDbParameter("LEFT_ORGANIZATION", OleDbType.Char, 1);
            param_Employee_Master[27].Value = LeftOrganisation;


            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql1, param_Employee_Master);

            UserID = EmpID;
            UserName = FullName;

            //--Below Line is Commented By Avinash Wankhede Dated[02 May 2009] //--Password By Default Set as UserLogin Name 
            //Password = LoginName;
            //--End Here Commented By Avinash Wankhede Dated[02 May 2009]

            //Line Added By Avinash Wankhede Dated[02 May 2009] //--Password By Default Set as UserLogin Name 
            Password = Password ;
            //End Here

            //--Below Line is Commented By Avinash Wankhede Dated[02 May 2009] //--Password By Default Set as UserLogin Name 
            //sSql2 = "INSERT INTO USER_MASTER (USERID, USERNAME, LOGINNAME, PASSWORD) " +
            //       "VALUES(?, ?, ?, ?,)";
            // //--End Here Commented By Avinash Wankhede Dated[02 May 2009]


            //Line Added By Avinash Wankhede Dated[02 May 2009] //--Password By Default Set as UserLogin Name 
            //NEW Column by IS_SYSTEM, LAST_RESET_DATE for LOGIN SECURITY            
            sSql2 = "INSERT INTO USER_MASTER (USERID, USERNAME, LOGINNAME, PASSWORD,IS_SYSTEM,LAST_RESET_DATE) " +
                    "VALUES(?, ?, ?, ?,?,?)";
            // //--End Here Add -- By Avinash Wankhede Dated[02 May 2009]


            OleDbParameter[] param_User_Master = new OleDbParameter[6];
            param_User_Master[0] = new OleDbParameter("USERID", OleDbType.VarChar);
            param_User_Master[0].Value = UserID;
            param_User_Master[1] = new OleDbParameter("USERNAME", OleDbType.VarChar);
            param_User_Master[1].Value = UserName;
            param_User_Master[2] = new OleDbParameter("LOGINNAME", OleDbType.VarChar);
            param_User_Master[2].Value = LoginName;
            param_User_Master[3] = new OleDbParameter("PASSWORD", OleDbType.VarChar);
            param_User_Master[3].Value = CEncDec.Encrypt(Password, Password);

            //Line Added By Avinash Wankhede Dated[02 May 2009] //--Password By Default Set as UserLogin Name 
            param_User_Master[4] = new OleDbParameter("IS_SYSTEM", OleDbType.Boolean);
            param_User_Master[4].Value = true ;

            param_User_Master[5] = new OleDbParameter("LAST_RESET_DATE", OleDbType.Date);
            param_User_Master[5].Value = Convert.ToDateTime(DateTime.Now);

            //End Here

            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql2, param_User_Master);
            sqlTrans.Commit();
            sqlconn.Close();
        }
        catch (System.Exception exp)
        {
            sqlTrans.Rollback();
            sqlconn.Close();
            throw new Exception("An error occurred while executing the Insert", exp);
        }

    }
    public void UpdateEmployee()
    {
        String sSql1 = "";
        String sSql2 = "";
        //Create and open Connection
        OleDbConnection sqlconn = new OleDbConnection(oCmn.ConnectionString);
        sqlconn.Open();
        //Create and open Transaction
        OleDbTransaction sqlTrans = sqlconn.BeginTransaction();
        try
        {
            if (FName != null)
                FullName = FName + " ";
            if (LName != null)
                FullName = FullName + MName + " ";
            if (LName != null)
                FullName = FullName + LName;

            FullName = FullName.Trim();
            //Employee Master Insert Query
            sSql1 = "UPDATE EMPLOYEE_MASTER SET EMP_CODE = ?, FIRSTNAME = ?, MIDDLENAME = ?, " +
                    "LASTNAME = ?, FULLNAME = ?, GENDER = ?, DOB = ?, DOJ = ?, " +
                    "ADD1 =?, ADD2 = ?, ADD3 = ?, CITY = ?, PIN = ?, MOBILE = ?, " +
                    "PHONE_R = ?, EMP_TYPE = ?, DESIGNATION_ID = ?, " +
                    "DEPARTMENT_ID = ?, CENTRE_ID = ?,  " +
                    "MODIFY_DATE = ?, MODIFY_USER_ID = ?,DOL=?,SUBCENTRE_ID=?,UNIT=?,SUVIDHA_AC=?,RESIGNATION=?,LEFT_ORGANIZATION=?  WHERE EMP_ID = ?";

            OleDbParameter[] param_Employee_Master = new OleDbParameter[28];
            param_Employee_Master[0] = new OleDbParameter("EMP_CODE", OleDbType.VarChar);
            param_Employee_Master[0].Value = EmpCode;
            param_Employee_Master[1] = new OleDbParameter("FIRSTNAME", OleDbType.VarChar);
            param_Employee_Master[1].Value = FName;
            param_Employee_Master[2] = new OleDbParameter("MIDDLENAME", OleDbType.VarChar);
            param_Employee_Master[2].Value = MName;
            param_Employee_Master[3] = new OleDbParameter("LASTNAME", OleDbType.VarChar);
            param_Employee_Master[3].Value = LName;
            param_Employee_Master[4] = new OleDbParameter("FULLNAME", OleDbType.VarChar);
            param_Employee_Master[4].Value = FullName;
            param_Employee_Master[5] = new OleDbParameter("GENDER", OleDbType.VarChar);
            param_Employee_Master[5].Value = Gender;
            param_Employee_Master[6] = new OleDbParameter("DOB", OleDbType.Date);
            if (DoB != null)
                //comment by komal
                param_Employee_Master[6].Value = Convert.ToDateTime(oCmn.strDate(DoB));
                //param_Employee_Master[6].Value = Convert.ToDateTime(DoB).ToString("dd/MMM/yyyy"); //Convert.ToDateTime(oCmn.strDate(DoB));
            else
                param_Employee_Master[6].Value = DoB;

            param_Employee_Master[7] = new OleDbParameter("DOJ", OleDbType.Date);
            if (DoJ != null)
                //comment by komal
                param_Employee_Master[7].Value = Convert.ToDateTime(oCmn.strDate(DoJ));
                //param_Employee_Master[7].Value = Convert.ToDateTime(DoJ).ToString("dd/MMM/yyyy");
            else
                param_Employee_Master[7].Value = DoJ;

            param_Employee_Master[8] = new OleDbParameter("ADD1", OleDbType.VarChar);
            param_Employee_Master[8].Value = Add1;
            param_Employee_Master[9] = new OleDbParameter("ADD2", OleDbType.VarChar);
            param_Employee_Master[9].Value = Add2;
            param_Employee_Master[10] = new OleDbParameter("ADD3", OleDbType.VarChar);
            param_Employee_Master[10].Value = Add3;
            param_Employee_Master[11] = new OleDbParameter("CITY", OleDbType.VarChar);
            param_Employee_Master[11].Value = City;
            param_Employee_Master[12] = new OleDbParameter("PIN", OleDbType.VarChar);
            param_Employee_Master[12].Value = Pin;
            param_Employee_Master[13] = new OleDbParameter("MOBILE", OleDbType.VarChar);
            param_Employee_Master[13].Value = Mobile;
            param_Employee_Master[14] = new OleDbParameter("PHONE_R", OleDbType.VarChar);
            param_Employee_Master[14].Value = Phone;
            param_Employee_Master[15] = new OleDbParameter("EMP_TYPE", OleDbType.VarChar);
            param_Employee_Master[15].Value = EmpType;
            param_Employee_Master[16] = new OleDbParameter("DESIGNATION_ID", OleDbType.VarChar);
            param_Employee_Master[16].Value = Designation;
            param_Employee_Master[17] = new OleDbParameter("DEPARTMENT_ID", OleDbType.VarChar);
            param_Employee_Master[17].Value = Department;
            param_Employee_Master[18] = new OleDbParameter("CENTRE_ID", OleDbType.VarChar);
            param_Employee_Master[18].Value = CentreID;
         
            param_Employee_Master[19] = new OleDbParameter("MODIFY_DATE", OleDbType.VarChar);
            param_Employee_Master[19].Value = DateTime.Now;
            //param_Employee_Master[19].Value = DateTime.Now.ToString("dd/MMM/yyyy hh:mm:ss");

            param_Employee_Master[20] = new OleDbParameter("MODIFY_USER_ID", OleDbType.VarChar);
            param_Employee_Master[20].Value = ModifyBy;

            param_Employee_Master[21] = new OleDbParameter("DOL", OleDbType.Date);
            if (DoL != null)
                param_Employee_Master[21].Value = Convert.ToDateTime(oCmn.strDate(DoL));

            else
                param_Employee_Master[21].Value = DoL;

            param_Employee_Master[22] = new OleDbParameter("SUBCENTRE_ID", OleDbType.VarChar, 50);
            param_Employee_Master[22].Value = SubCentreID;
            param_Employee_Master[23] = new OleDbParameter("UNIT", OleDbType.VarChar, 100);
            param_Employee_Master[23].Value = Unit;
            param_Employee_Master[24] = new OleDbParameter("SUVIDHA_AC", OleDbType.VarChar, 50);
            param_Employee_Master[24].Value = SuvidhaAC;
            param_Employee_Master[25] = new OleDbParameter("RESIGNATION", OleDbType.Char, 1);
            param_Employee_Master[25].Value = Resignation;
            param_Employee_Master[26] = new OleDbParameter("LEFT_ORGANIZATION", OleDbType.Char, 1);
            param_Employee_Master[26].Value = LeftOrganisation;



            param_Employee_Master[27] = new OleDbParameter("EMP_ID", OleDbType.VarChar);
            param_Employee_Master[27].Value = EmpID;
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql1, param_Employee_Master);

            //Update User_Master
            UserID = EmpID;
            UserName = FullName;
            //--Below Line is Commented By Avinash Wankhede Dated[02 May 2009] //--Password By Default Set as UserLogin Name 
            //Password = LoginName;
            //--End Here Commented By Avinash Wankhede Dated[02 May 2009]

            //Line Added By Avinash Wankhede Dated[02 May 2009] //--Password By Default Set as UserLogin Name 
            Password = Password;
            //End Here

            //--Below Line is Commented By Avinash Wankhede Dated[02 May 2009] //--Password By Default Set as UserLogin Name 
            //sSql2 = "INSERT INTO USER_MASTER (USERID, USERNAME, LOGINNAME, PASSWORD) " +
            //        "VALUES(?, ?, ?, ?,?,?)";
            // //--End Here Commented By Avinash Wankhede Dated[02 May 2009]


            //Line Added By Avinash Wankhede Dated[02 May 2009] //--Password By Default Set as UserLogin Name 
            //NEW Column by IS_SYSTEM, LAST_RESET_DATE for LOGIN SECURITY            

            sSql2 = "UPDATE USER_MASTER SET USERNAME = ?, LOGINNAME = ? ," +
                    "PASSWORD= ?,IS_SYSTEM=?,LAST_RESET_DATE=?  WHERE USERID = ?";
              // //--End Here Add -- By Avinash Wankhede Dated[02 May 2009]

            OleDbParameter[] param_User_Master = new OleDbParameter[6];
            param_User_Master[0] = new OleDbParameter("USERNAME", OleDbType.VarChar);
            param_User_Master[0].Value = UserName;
            param_User_Master[1] = new OleDbParameter("LOGINNAME", OleDbType.VarChar);
            param_User_Master[1].Value = LoginName;
            param_User_Master[2] = new OleDbParameter("PASSWORD", OleDbType.VarChar);
            param_User_Master[2].Value = CEncDec.Encrypt(Password, Password);

            param_User_Master[5] = new OleDbParameter("USERID", OleDbType.VarChar);
            param_User_Master[5].Value = UserID;


            //Line Added By Avinash Wankhede Dated[02 May 2009] //--Password By Default Set as UserLogin Name 
            param_User_Master[3] = new OleDbParameter("IS_SYSTEM", OleDbType.Boolean);
            param_User_Master[3].Value = true;

            param_User_Master[4] = new OleDbParameter("LAST_RESET_DATE", OleDbType.Date);
            param_User_Master[4].Value = Convert.ToDateTime(DateTime.Now);

            //End Here

            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql2, param_User_Master);
            sqlTrans.Commit();
            sqlconn.Close();
        }
        catch (System.Exception exp)
        {
            sqlTrans.Rollback();
            sqlconn.Close();
            throw new Exception("An error occurred while executing the Update", exp);
        }
    }
    public void DeleteEmployee()
    {
        String sSql1 = "";
        String sSql2 = "";

        //Create and open Connection
        OleDbConnection sqlconn = new OleDbConnection(oCmn.ConnectionString);
        sqlconn.Open();
        //Create and open Transaction
        OleDbTransaction sqlTrans = sqlconn.BeginTransaction();
        try
        {
            UserID = EmpID;
            sSql1 = "DELETE EMPLOYEE_MASTER WHERE EMP_ID='" + EmpID + "'";
            sSql2 = "DELETE USER_MASTER WHERE USER_ID='" + UserID + "'";


            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql2);
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql1);

            sqlTrans.Commit();
            sqlconn.Close();
        }
        catch (System.Exception exp)
        {
            sqlTrans.Rollback();
            sqlconn.Close();
            throw new Exception("An error occurred while executing the Delete Employee", exp);
        }
        finally
        {
            //Some action
        }
    }

    //Propery Declarion For Role_Master
    private String strUserID;        //1
    private String strRoleID;       //2

    public String RUserID    //1
    {
        get { return strUserID; }
        set
        {
            if (value == "")
            {
                strUserID = null;
            }
            else
            {
                strUserID = value;
            }
        }
    }
    public String RoleID    //2
    {
        get { return strRoleID; }
        set
        {
            if (value == "")
            {
                strRoleID = null;
            }
            else
            {
                strRoleID = value;
            }
        }
    }
    public OleDbDataReader GetRole()
    {
        String sSql = "";
        //Create and open Connection
        OleDbConnection sqlconn = new OleDbConnection(oCmn.ConnectionString);
        sqlconn.Open();
        //Create and open Transaction
        OleDbTransaction sqlTrans = sqlconn.BeginTransaction();
        try
        {
            sSql = "SELECT * FROM USER_ROLE WHERE 1=1 ";
            if (RUserID != null)
            {
                sSql = sSql + " AND USER_ID = '" + RUserID + "'";
            }
            return OleDbHelper.ExecuteReader(sqlTrans, CommandType.Text, sSql);

            sqlTrans.Commit();
            sqlconn.Close();
        }
        catch (System.Exception exp)
        {
            sqlTrans.Rollback();
            sqlconn.Close();
            throw new Exception("An error occurred while executing the Delete Employee", exp);
        }
        finally
        {
            //Some action
        }

    }
    public OleDbDataReader GetEmpCode()
    {
        String sSql = "";
        //Create and open Connection
        OleDbConnection sqlconn = new OleDbConnection(oCmn.ConnectionString);
        sqlconn.Open();
        //Create and open Transaction
        OleDbTransaction sqlTrans = sqlconn.BeginTransaction();
        try
        {
            sSql = "SELECT EMP_CODE FROM EMPLOYEE_MASTER WHERE 1=1 ";
            if (RUserID != null)
            {
                sSql = sSql + " AND EMP_ID = '" + RUserID + "'";
            }
            return OleDbHelper.ExecuteReader(sqlTrans, CommandType.Text, sSql);

            sqlTrans.Commit();
            sqlconn.Close();
        }
        catch (System.Exception exp)
        {
            sqlTrans.Rollback();
            sqlconn.Close();
            throw new Exception("An error occurred while executing the Delete Employee", exp);
        }
        finally
        {
            //Some action
        }

    }
    //Assign Role
    public void AssignRole()
    {
        String sSql1 = "";

        //Create and open Connection
        OleDbConnection sqlconn = new OleDbConnection(oCmn.ConnectionString);
        sqlconn.Open();
        //Create and open Transaction
        OleDbTransaction sqlTrans = sqlconn.BeginTransaction();
        try
        {
            //Case Master Insert Query
            sSql1 = "INSERT INTO USER_ROLE (USER_ID, ROLE_ID) " +
                   "VALUES ('" + RUserID + "', '" + RoleID + "')";

            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql1);

            sqlTrans.Commit();
            sqlconn.Close();
        }
        catch (System.Exception exp)
        {
            sqlTrans.Rollback();
            sqlconn.Close();
            throw new Exception("An error occurred while executing the Insert User Roles", exp);
        }
        finally
        {
            //Some action
        }
    }
    //Delete Role
    public void DeleteRole()
    {
        String sSql1 = "";

        //Create and open Connection
        OleDbConnection sqlconn = new OleDbConnection(oCmn.ConnectionString);
        sqlconn.Open();
        //Create and open Transaction
        OleDbTransaction sqlTrans = sqlconn.BeginTransaction();
        try
        {
            sSql1 = "DELETE FROM USER_ROLE WHERE USER_ID = '" + RUserID + "'";
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql1);

            sqlTrans.Commit();
            sqlconn.Close();
        }
        catch (System.Exception exp)
        {
            sqlTrans.Rollback();
            sqlconn.Close();
            throw new Exception("An error occurred while executing the Delete User Roles", exp);
        }
        finally
        {
            //Some action
        }
    }
    public void AssignHierarchy(string strUserId, string strHierarchyId)
    {
        String sSql1 = "";

        //Create and open Connection
        OleDbConnection sqlconn = new OleDbConnection(oCmn.ConnectionString);
        sqlconn.Open();
        //Create and open Transaction
        OleDbTransaction sqlTrans = sqlconn.BeginTransaction();
        try
        {
            sSql1 = "DELETE FROM USER_Hierarchy WHERE USER_ID = ? ";
            OleDbParameter paramHeir = new OleDbParameter("UserId", OleDbType.VarChar);
            paramHeir.Value = strUserID;
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql1, paramHeir);

            sSql1 = "INSERT INTO USER_HIERARCHY (USER_ID, HIER_ID) " +
                    "VALUES (?, ?)";

            string sqlHier = "SELECT CHM.HIER_ID,CHM.Hier_level, CHM.Parent_ID AS ParentId " +
                             " , isNull((select Parent_Id from COMPANY_HIERARCHY_MASTER CHM1 where CHM1.Hier_id=CHM.Parent_Id),'0') AS ParentId1 " +
                             " , isNull((select Parent_Id from COMPANY_HIERARCHY_MASTER CHM1 where CHM1.Hier_id=(select Parent_Id from COMPANY_HIERARCHY_MASTER CHM2 where CHM2.Hier_id=CHM.Parent_Id)),'0') AS ParentId2 " +
                             " , isNull((select Parent_Id from COMPANY_HIERARCHY_MASTER CHM1 where CHM1.Hier_id=(select Parent_Id from COMPANY_HIERARCHY_MASTER CHM2 where CHM2.Hier_id=(select Parent_Id from COMPANY_HIERARCHY_MASTER CHM3 where CHM3.Hier_id=CHM.Parent_Id))),'0')AS ParentId3 " +
                             " , isNull((select Parent_Id from COMPANY_HIERARCHY_MASTER CHM1 where CHM1.Hier_id=(select Parent_Id from COMPANY_HIERARCHY_MASTER CHM2 where CHM2.Hier_id=(select Parent_Id from COMPANY_HIERARCHY_MASTER CHM3 where CHM3.Hier_id=(select Parent_Id from COMPANY_HIERARCHY_MASTER CHM4 where CHM4.Hier_id=CHM.Parent_Id)))),'0')AS ParentId4 " +
                             " , isNull((select Parent_Id from COMPANY_HIERARCHY_MASTER CHM1 where CHM1.Hier_id=(select Parent_Id from COMPANY_HIERARCHY_MASTER CHM2 where CHM2.Hier_id=(select Parent_Id from COMPANY_HIERARCHY_MASTER CHM3 where CHM3.Hier_id=(select Parent_Id from COMPANY_HIERARCHY_MASTER CHM4 where CHM4.Hier_id=(select Parent_Id from COMPANY_HIERARCHY_MASTER CHM5 where CHM5.Hier_id=CHM.Parent_Id))))),'0')AS ParentId5 " +
                             " FROM COMPANY_HIERARCHY_MASTER CHM " +
                             " where CHM.hier_id=?";

            OleDbParameter[] paramHeirInsert;
            string[] HeirId = strHierarchyId.Split(',');

            string strAll = "";
            OleDbParameter parmHier;
            foreach (string str in HeirId)
            {
                OleDbDataReader dr;
                parmHier = new OleDbParameter("HierId", OleDbType.VarChar);
                parmHier.Value = str;
                string strAllHierarchy = "";
                if (strAll.IndexOf(str + ",") == -1)
                {
                    dr = OleDbHelper.ExecuteReader(sqlTrans, CommandType.Text, sqlHier, parmHier);
                    while (dr.Read())
                    {
                        //strAllHierarchy = dr["HIER_ID"].ToString() + ",";
                        strAllHierarchy = strAllHierarchy + dr["ParentId"].ToString() + ",";
                        strAllHierarchy = strAllHierarchy + dr["ParentId1"].ToString() + ",";
                        strAllHierarchy = strAllHierarchy + dr["ParentId2"].ToString() + ",";
                        strAllHierarchy = strAllHierarchy + dr["ParentId3"].ToString() + ",";
                        strAllHierarchy = strAllHierarchy + dr["ParentId4"].ToString() + ",";
                        strAllHierarchy = strAllHierarchy + dr["ParentId5"].ToString();
                    }
                    dr.Close();
                    dr.Dispose();
                    strAll = strAll + strAllHierarchy + ",";
                    string sqlHier1 = "DELETE FROM USER_Hierarchy WHERE USER_ID = '" + strUserID + "' and Hier_Id in (" + strAllHierarchy + ")";
                    OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sqlHier1);

                    paramHeirInsert = new OleDbParameter[2];
                    paramHeirInsert[0] = new OleDbParameter("UserId", OleDbType.VarChar);
                    paramHeirInsert[1] = new OleDbParameter("HeirarchyId", OleDbType.VarChar);
                    paramHeirInsert[0].Value = strUserID;
                    paramHeirInsert[1].Value = str;
                    OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sSql1, paramHeirInsert);
                }
            }
            sqlTrans.Commit();
            sqlconn.Close();
        }
        catch (System.Exception exp)
        {
            sqlTrans.Rollback();
            sqlconn.Close();
            string st = exp.Message;
            //throw new Exception("An error occurred while executing the Delete User Roles", exp);
        }
        finally
        {
            //Some action
        }
    }

    
}
