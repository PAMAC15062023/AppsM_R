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

public partial class HDFC_HDFC_Default : System.Web.UI.Page
{
  
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            CCommon objConn = new CCommon();
            SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = sqlcon;
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd3.CommandText = "Sp_Login_Details_2";
            cmd3.CommandTimeout = 0;

            SqlParameter LoginName = new SqlParameter();
            LoginName.SqlDbType = SqlDbType.VarChar;
            LoginName.Value = Session["userid"].ToString().Trim();
            LoginName.ParameterName = "@LoginName";
            cmd3.Parameters.Add(LoginName);

            SqlDataAdapter sqlda2 = new SqlDataAdapter();
            sqlda2.SelectCommand = cmd3;

            DataTable dt = new DataTable();
            sqlda2.Fill(dt);

            sqlcon.Close();



            if (dt.Rows.Count > 0)
            {
                Session["Old"] = dt.Rows[0]["log_det_id"].ToString();

            }
            if (Session["LogId"].ToString() != Session["Old"].ToString())
            {
                Response.Redirect("~/OldSession.aspx");
            }
        }
        catch (Exception ex)
        {

        }

    }
}
