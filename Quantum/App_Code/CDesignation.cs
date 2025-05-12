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
/// Summary description for CDesignation
/// </summary>
public class CDesignation
{
    CCommon oCmn = new CCommon();
    private string DesignationName;

    public string _DesignationName
    {
        get { return DesignationName; }
        set { DesignationName = value; }
    }
    private string DesignationCode;

    public string _DesignationCode
    {   
        get { return DesignationCode; }
        set { DesignationCode = value; }
    }
    private int DesignationID;

    public int _DesignationID
    {
        get { return DesignationID; }       
        set { DesignationID = value; }
    }

   
	
	public CDesignation()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void InsertUpdateDesignation()
     {
        string strSql = "";
         OleDbConnection sqlconn = new OleDbConnection(oCmn.ConnectionString);
        sqlconn.Open();
        OleDbTransaction sqlTrans = sqlconn.BeginTransaction();
        int i = 0;
        try
        {
            OleDbParameter[] param;
            strSql = "select count(DESIGNATION_ID) from Designation_Master WHERE DESIGNATION_ID=" + _DesignationID;
            i = (int)OleDbHelper.ExecuteScalar(sqlTrans, CommandType.Text, strSql);
            if (i == 0)
            {
                strSql = "Insert into Designation_Master (Designation,DESIG_CODE) values(?,?)";
                 param = new OleDbParameter[2];
                param[0] = new OleDbParameter("Designation_Name", OleDbType.VarChar, 200);
                param[0].Value = _DesignationName;
                param[1] = new OleDbParameter("Designation_Code", OleDbType.VarChar, 10);
                param[1].Value = _DesignationCode;
            }
            else
            {
                strSql = "update Designation_Master set Designation=?, DESIG_CODE=? where DESIGNATION_ID=?";
                 param = new OleDbParameter[3];
                param[0] = new OleDbParameter("Designation_Name", OleDbType.VarChar, 200);
                param[0].Value = _DesignationName;
                param[1] = new OleDbParameter("Designation_Code", OleDbType.VarChar, 10);
                param[1].Value = _DesignationCode;
                param[2] = new OleDbParameter("Designation_Id", OleDbType.Integer);
                param[2].Value = _DesignationID;
            }
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strSql, param);

            sqlTrans.Commit();
            sqlconn.Close();
        }


        catch (System.Exception exp)
        {
            sqlTrans.Rollback();
            sqlconn.Close();
            throw new Exception("An error occurred while executing the InsertUpdate", exp);
        }

    }

    public DataSet  GetDesignatio(int i)
    {
        DataSet ds = new DataSet();
        string strSql = "";
        OleDbConnection sqlconn = new OleDbConnection(oCmn.ConnectionString);
        sqlconn.Open();
        strSql = "select DESIGNATION,DESIG_CODE from DESIGNATION_MASTER WHERE DESIGNATION_ID=" + i;
        ds=OleDbHelper.ExecuteDataset(sqlconn,CommandType.Text,strSql);
        return ds;
    }

    public void DeleteDesig(int i)
    {
        string strSql = "";
        OleDbConnection sqlconn = new OleDbConnection(oCmn.ConnectionString);
        sqlconn.Open();
        strSql = "delete from DESIGNATION_MASTER where DESIGNATION_ID=" + i;
        OleDbHelper.ExecuteNonQuery(sqlconn, CommandType.Text, strSql);
    }
    public int Getname(string str)
    {
        string strSql = "";
        OleDbConnection sqlconn = new OleDbConnection(oCmn.ConnectionString);
        sqlconn.Open();
        strSql = "select count(*) from DESIGNATION_MASTER where DESIGNATION='"+str+"' ";
        int i = (int)OleDbHelper.ExecuteScalar(sqlconn, CommandType.Text, strSql);
        return i;
    }
}
