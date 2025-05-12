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
using System.IO;

public partial class DCR_DCR_DedupDepositScanImage : System.Web.UI.Page
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);

        //lblName.Text = "Dedup search for: " + " Slip No.: " + Request.QueryString["Slip_No"].ToString();    //Request.QueryString["Name"].ToString() + 
        lblName.Text = "Dedup search for 'SLIP No. : " + Request.QueryString["Slip_No"].ToString() + "'";

        Search(Request.QueryString["Slip_No"]);
    }

    protected void Search(string strSlipNo)
    {
        try
        {
            sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DCR_Get_DedupSearch";
            cmd.CommandTimeout = 0;

            SqlParameter Slip_No = new SqlParameter();
            Slip_No.SqlDbType = SqlDbType.VarChar;
            Slip_No.ParameterName = "@SlipNo";
            Slip_No.Value = strSlipNo;
            cmd.Parameters.Add(Slip_No);

            SqlParameter Client_ID = new SqlParameter();
            Client_ID.SqlDbType = SqlDbType.VarChar;
            Client_ID.ParameterName = "@CLIENT_ID";
            Client_ID.Value = Session["ClientID"].ToString(); ;
            cmd.Parameters.Add(Client_ID);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            int r = dt.Rows.Count;

            sqlcon.Close();

            if ((r > 0) && (strSlipNo != ""))
            {
                gvDedup.DataSource = dt;
                gvDedup.DataBind();
            }
            else
            {
                gvDedup.DataSource = null;
                gvDedup.DataBind();
                lblmsg.Text = "No Record Found.";
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }


}
