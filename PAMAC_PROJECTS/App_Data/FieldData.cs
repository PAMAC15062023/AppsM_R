using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CommonMaster
/// </summary>
public class FieldData
{
    public FieldData()
    {
        //
        // TODO: Add constructor logic here
        //

    }
    public DataTable GetFieldData(int menuid, int field_show_in)
    {
       
        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        sqlCon.Open();
        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlCon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "sp_select_fields";

        sqlcmd.Parameters.AddWithValue("@menuid", menuid);
       // sqlcmd.Parameters.AddWithValue("@activityID", activityid);
        sqlcmd.Parameters.AddWithValue("@field_show_in", field_show_in);
        SqlDataAdapter sqlDA = new SqlDataAdapter();

        sqlDA.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlCon.Close();
        return dt;


    }

}
