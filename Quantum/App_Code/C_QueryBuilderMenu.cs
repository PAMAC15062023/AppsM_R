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
/// Summary description for C_QueryBuilderMenu
/// </summary>
public class C_QueryBuilderMenu
{
    CCommon connobj = new CCommon();
	public C_QueryBuilderMenu()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetMenu(string UserId)
    {
        OleDbConnection con = new OleDbConnection(connobj.ConnectionString);
        con.Open();
        DataTable dt = new DataTable();
        string str = "SELECT  ASSIGN_QUERY.Query_ID, QUERY_MASTER.Query_Defination, QUERY_MASTER.Page_Url " +
                     "FROM ASSIGN_QUERY INNER JOIN " +
                     "QUERY_MASTER ON ASSIGN_QUERY.Query_ID = QUERY_MASTER.Query_ID WHERE (ASSIGN_QUERY.EMP_ID = " + UserId + ")" +
                     " And Query_Type=1";
        dt = OleDbHelper.ExecuteDataset(con, CommandType.Text, str).Tables[0];
        con.Close();
        return dt;
    }

    public DataTable GetMenu1(string UserId)
    {
        OleDbConnection con = new OleDbConnection(connobj.ConnectionString);
        con.Open();
        DataTable dt1 = new DataTable();
        string str1 = "SELECT  ASSIGN_QUERY.Query_ID, QUERY_MASTER.Query_Defination, QUERY_MASTER.Page_Url " +
                     "FROM ASSIGN_QUERY INNER JOIN " +
                     "QUERY_MASTER ON ASSIGN_QUERY.Query_ID = QUERY_MASTER.Query_ID WHERE (ASSIGN_QUERY.EMP_ID = " + UserId + ")" +
                     " And Query_Type=2";
        dt1 = OleDbHelper.ExecuteDataset(con, CommandType.Text, str1).Tables[0];
        con.Close();
        return dt1;
    }
    public DataTable GetMenu2(string UserId)
    {
        OleDbConnection con = new OleDbConnection(connobj.ConnectionString);
        con.Open();
        DataTable dt2 = new DataTable();
        string str1 = "SELECT  ASSIGN_QUERY.Query_ID, QUERY_MASTER.Query_Defination, QUERY_MASTER.Page_Url " +
                     "FROM ASSIGN_QUERY INNER JOIN " +
                     "QUERY_MASTER ON ASSIGN_QUERY.Query_ID = QUERY_MASTER.Query_ID WHERE (ASSIGN_QUERY.EMP_ID = " + UserId + ")" +
                     " And Query_Type=3";
        dt2 = OleDbHelper.ExecuteDataset(con, CommandType.Text, str1).Tables[0];
        con.Close();
        return dt2;
    }
}
