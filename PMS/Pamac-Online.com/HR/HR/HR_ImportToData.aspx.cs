using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.OleDb;

public partial class HR_HR_HR_ImportToData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        lblCount.Text = "";
        SearchRecord();
    }
    
    private void SearchRecord()
    {

        try
        {
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertAttendance_FromBiometrics_ToPMSNEW123";
            //cmd.CommandText = "InsertAttendance_FromBiometrics_ToPMSSearch";
            cmd.CommandTimeout = 0;

            DateTime sFromDate;
            DateTime sToDate;

            sFromDate = Convert.ToDateTime(strDate(txtfromdate.Text.ToString().Trim()));
            sToDate = Convert.ToDateTime(strDate(txtTodate.Text.ToString().Trim()));


            SqlParameter FromDate = new SqlParameter();  /// IMP
            FromDate.SqlDbType = SqlDbType.DateTime;
            FromDate.Value = sFromDate;//strDate(txtfromdate.Text.Trim());//txtclosingdate.Text.ToString();
            FromDate.ParameterName = "@FromDate";
            cmd.Parameters.Add(FromDate);

            SqlParameter Todate = new SqlParameter();  /// IMP
            Todate.SqlDbType = SqlDbType.DateTime;
            Todate.Value = sToDate;//strDate(txtTodate.Text.Trim ());//txtclosingdate.Text.ToString();
            Todate.ParameterName = "@Todate";
            cmd.Parameters.Add(Todate);

            //SqlParameter UserId = new SqlParameter();  /// IMP
            //UserId.SqlDbType = SqlDbType.VarChar;
            //UserId.Value = Session["UserId"].ToString();
            //UserId.ParameterName = "@UserId";
            //cmd.Parameters.Add(UserId);


            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt1 = new DataTable();
            da.Fill(dt1);
            sqlcon.Close();


            if (dt1.Rows.Count > 0)
            {

                lblCount.Text = "";
                lblCount.Text = "Total Count Is :" + dt1.Rows.Count;

                GridView1.DataSource = dt1;
                GridView1.DataBind();

            }
            else
            {
                lblCount.Text = "Data Already Exist for" + sFromDate;

                GridView1.DataSource = null;
                GridView1.DataBind();
            }

        }
        catch (Exception Ex)
        {
            lblCount.Text = Ex.Message;
        }
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {

        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlcon;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "InsertAttendance_FromBiometrics_ToPMSNEW";
        cmd.CommandTimeout = 0;

        //DateTime sFromDate;
        //DateTime sToDate;

        //sFromDate = Convert.ToDateTime(strDate(txtfromdate.Text.ToString().Trim()));
        //sToDate = Convert.ToDateTime(strDate(txtTodate.Text.ToString().Trim()));

        SqlParameter FromDate = new SqlParameter();  /// IMP
        FromDate.SqlDbType = SqlDbType.DateTime;
        FromDate.Value = strDate(txtfromdate.Text.ToString().Trim());
        FromDate.ParameterName = "@FromDate";
        cmd.Parameters.Add(FromDate);

        SqlParameter Todate = new SqlParameter();  /// IMP
        Todate.SqlDbType = SqlDbType.DateTime;
        Todate.Value = strDate(txtTodate.Text.ToString().Trim());
        Todate.ParameterName = "@Todate";
        cmd.Parameters.Add(Todate);

        SqlParameter UserId = new SqlParameter();  /// IMP
        UserId.SqlDbType = SqlDbType.VarChar;
        UserId.Value = Session["UserId"].ToString();
        UserId.ParameterName = "@UserId";
        cmd.Parameters.Add(UserId);

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataTable dt = new DataTable();
        da.Fill(dt);

        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
               Insert_Main_Attendance(dt.Rows[i]);
              
            }
        }
    }

    private void Insert_Main_Attendance(DataRow dr)
    {

        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Sp_UpdateAttendance_FromBiometrics";
        sqlcmd.CommandTimeout = 0;

        SqlParameter EMP_ID = new SqlParameter();
        EMP_ID.SqlDbType = SqlDbType.VarChar;
        EMP_ID.Value = dr["EMP_ID"].ToString().Trim();
        EMP_ID.ParameterName = "@EMP_ID";
        sqlcmd.Parameters.Add(EMP_ID);

        SqlParameter DATE = new SqlParameter();
        DATE.SqlDbType = SqlDbType.VarChar;
        DATE.Value = dr["DATE"].ToString().Trim();
        DATE.ParameterName = "@DATE";
        sqlcmd.Parameters.Add(DATE);


        SqlParameter AttendanceDate = new SqlParameter();
        AttendanceDate.SqlDbType = SqlDbType.VarChar;
        AttendanceDate.Value = dr["AttendanceDate"].ToString().Trim();
        AttendanceDate.ParameterName = "@AttendanceDate";
        sqlcmd.Parameters.Add(AttendanceDate);

        SqlParameter ATTENDANCE = new SqlParameter();
        ATTENDANCE.SqlDbType = SqlDbType.VarChar;
        ATTENDANCE.Value = dr["ATTENDANCE"].ToString().Trim();
        ATTENDANCE.ParameterName = "@ATTENDANCE";
        sqlcmd.Parameters.Add(ATTENDANCE);

        SqlParameter InTime = new SqlParameter();
        InTime.SqlDbType = SqlDbType.VarChar;
        InTime.Value = dr["InTime"].ToString().Trim();
        InTime.ParameterName = "@InTime";
        sqlcmd.Parameters.Add(InTime);

        SqlParameter OutTime = new SqlParameter();
        OutTime.SqlDbType = SqlDbType.VarChar;
        OutTime.Value = dr["OutTime"].ToString().Trim();
        OutTime.ParameterName = "@OutTime";
        sqlcmd.Parameters.Add(OutTime);

        SqlParameter CreateBy = new SqlParameter();
        CreateBy.SqlDbType = SqlDbType.VarChar;
        CreateBy.Value = Session["Userid"].ToString();
        CreateBy.ParameterName = "@CreateBy";
        sqlcmd.Parameters.Add(CreateBy);

        SqlParameter CreateDate = new SqlParameter();
        CreateDate.SqlDbType = SqlDbType.VarChar;
        CreateDate.Value = dr["CreateDate"].ToString().Trim();
        CreateDate.ParameterName = "@CreateDate";
        sqlcmd.Parameters.Add(CreateDate);

        int RowEffected = 0;
        RowEffected = sqlcmd.ExecuteNonQuery();
        sqlcon.Close();

        if (RowEffected > 0)
        {
            lblmsg.Visible = true;
            lblmsg.Text = "Record Saved Successfully";

            //SearchRecord();
        }
    }

    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);

        string strMM = strInDate.Substring(3, 2);

        string strYYYY = strInDate.Substring(6, 4);

        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY;

        //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;

        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);

        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy");

        return strOutDate;
    }

}
