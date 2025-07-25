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
/// Summary description for CCommon
/// </summary>
public class CCommon
{
  
	public CCommon()
	{
        
	}

    public string ConnectionString
    {
        get
        {
//            return (ConfigurationManager.ConnectionStrings["CMConnectionString"].ToString());
            string zone;
            //zone = HttpContext.Current.Session["Zone"].ToString();
            return (ConfigurationManager.ConnectionStrings["WestTestConnectionString"].ToString());
        }
    }

    public string AppConnectionString
    {
        get
        {
            string zone;
            //zone = HttpContext.Current.Session["Zone"].ToString();
            return (ConfigurationManager.AppSettings["WestTestconstring"].ToString());
        }
    }
        
    //public string NegMatchConnectionString
    //{
    //    get
    //    {
    //        return (ConfigurationManager.ConnectionStrings["NegMatchConnectionString"].ToString());
    //    }
    //}

    // public string BvuConnectionString
    //{
    //    get
    //    {
    //        return (ConfigurationManager.ConnectionStrings["NegMatchConnectionString"].ToString());
    //    }
    //}
  
    public string RepositoryConnectionString
    {
        get
        {
            return (ConfigurationManager.ConnectionStrings["RepositoryConnectionString"].ToString());
        }
    }

    public string GetUniqueID( string sTableNm, string sPrefix)
    {
        Int32 iUniqueId = 0;
        string sSql = "";
        sSql="Select Last_id  from Last_detail where table_name='" + sTableNm + "'" +
             " and prefix ='" + sPrefix + "'";

        OleDbDataReader sqlRead = OleDbHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sSql);
        if (sqlRead.Read())
            iUniqueId = Convert.ToInt32(sqlRead[0].ToString());
        else
        {
            sSql = "Insert Into Last_detail values ('" + sTableNm + "','" + sPrefix + "',1)";
            OleDbHelper.ExecuteNonQuery(this.ConnectionString, CommandType.Text, sSql);
            iUniqueId = 1;
        }
     
        sqlRead.Close();
        sSql = "Update Last_detail set Last_id=" + (iUniqueId + 1) +
               "where table_name='" + sTableNm + "' and prefix='" + sPrefix + "'";

        OleDbHelper.ExecuteNonQuery(this.ConnectionString, CommandType.Text, sSql);

        return sPrefix + iUniqueId;
    }
 
    public string GetUniqueID1(string sTableNm, string sPrefix)
    {
        Int32 iUniqueId = 0;
        string sSql = "";
        sSql = "Select Last_id  from Last_detail where table_name='" + sTableNm + "'" +
             " and prefix ='" + sPrefix + "'";

        OleDbDataReader sqlRead = OleDbHelper.ExecuteReader(this.ConnectionString, CommandType.Text, sSql);
        if (sqlRead.Read())
            iUniqueId = Convert.ToInt32(sqlRead[0].ToString());
        else
        {
            sSql = "Insert Into Last_detail values ('" + sTableNm + "','" + sPrefix + "',1)";
            OleDbHelper.ExecuteNonQuery(this.ConnectionString, CommandType.Text, sSql);
            iUniqueId = 1;
        }

        //sqlRead.Close();
        //sSql = "Update Last_detail set Last_id=" + (iUniqueId + 1) +
        //       "where table_name='" + sTableNm + "' and prefix='" + sPrefix + "'";

        //OleDbHelper.ExecuteNonQuery(this.ConnectionString, CommandType.Text, sSql);

        return sPrefix + iUniqueId;
    }
 
    public string FixQuotes(string strToConver)
    {
        string strData;
        strData = strToConver.Replace("'", "''");
        return strData;
    }

    public  DateTime date_mm_dd_yy(string strDate)
    {
        string[] D = strDate.Split('/');
        string dd = D[0];
        string mm = D[1];
        string yy = D[2];
        if (Convert.ToInt16(mm) > 12)
        {
            string temp = dd;
            dd = mm;
            mm = temp;
        }
        yy = mm + "/" + dd + "/" + yy;
        DateTime tDate = Convert.ToDateTime(yy);
        return tDate;
    }

    public string string_mm_dd_yy(string strDate)
    {
        string[] D = strDate.Split('/');
        string dd = D[0];
        string mm = D[1];
        string yy = D[2];
        if (Convert.ToInt16(mm) > 12)
        {
            string temp = dd;
            dd = mm;
            mm = temp;
            dd = dd + 1;
        }
        yy = mm + "/" + dd + "/" + yy;
        //DateTime tDate = Convert.ToDateTime(yy);
        return yy;
    }

    #region Date conversion dd/mm/yyyy to dd-MMM-yyyy added  by Manoj

    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);
        string strMM = strInDate.Substring(3, 2);
        string strYYYY = strInDate.Substring(6, 4);
        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY;
        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);
        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy");
        return strOutDate;
    }
    #endregion

    #region Date conversion dd/mm/yyyy to yyyy-mm-dd added  by Daljit

    public string strDate1(string strIDate)
    {
        string strDD = strIDate.Substring(0, 2);
        string strMM = strIDate.Substring(3, 2);
        string strYYYY = strIDate.Substring(6, 4);
        string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;
        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);
        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy");
        //string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy");
        return strOutDate;
    }

    #endregion
}
