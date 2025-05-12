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
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertAttendance_FromBiometrics_ToPMS";
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
                lblCount.Text = "";
                lblCount.Text = "Total Count Is :" + dt.Rows.Count;

                GridView1.DataSource = dt;
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
