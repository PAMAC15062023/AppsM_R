using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data.OleDb;

public partial class CPA_PD_Case_Reopen : System.Web.UI.Page
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;
    string strproc;

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);

        if (!IsPostBack)
        {
            validate();
        }
    }

    protected void validate()
    {
        btnsearch.Attributes.Add("onclick", "javascript:return validate();");
        btnReopen.Attributes.Add("onclick", "javascript:return validate();");
    }

    protected void clear()
    {
        txtcase_id.Text = "";
        txtappname.Text = "";
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        sqlcon.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlcon;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "DCR_Reopen_Search_Case";
        cmd.CommandTimeout = 0;

        SqlParameter case_id = new SqlParameter();
        case_id.SqlDbType = SqlDbType.VarChar;
        case_id.Value = txtcase_id.Text.ToString().Trim();
        case_id.ParameterName = "@CASE_ID";
        cmd.Parameters.Add(case_id);

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataTable dt = new DataTable();
        da.Fill(dt);

        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            txtappname.Text = dt.Rows[0]["FULLNAME"].ToString();
            HdnCluster.Value = dt.Rows[0]["Cluster_id"].ToString();
            hdncentre.Value = dt.Rows[0]["Centre_id"].ToString();
        }
        else
        {
            lblMessage.Text = "No Record Found.";
        }
    }

    protected void btnReopen_Click(object sender, EventArgs e)
    {
        if (HdnCluster.Value == "1011")
        {
            strproc = "sp_reopen_case_status_BVU";
        }
        else if (HdnCluster.Value == "1014")
        {
            strproc = "sp_reopen_case_status_East";
        }
        else if (HdnCluster.Value == "1013")
        {
            strproc = "sp_reopen_case_status_South";
        }
        else if (HdnCluster.Value == "1015")
        {
            strproc = "sp_reopen_case_status_North";
        }
        else if (HdnCluster.Value == "1018")
        {
            strproc = "sp_reopen_case_status_BVU";
        }
        else
        {
            strproc = "sp_reopen_case_status_West";
        }

        sqlcon.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlcon;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = strproc;
        cmd.CommandTimeout = 0;

        SqlParameter case_id = new SqlParameter();
        case_id.SqlDbType = SqlDbType.VarChar;
        case_id.Value = txtcase_id.Text.ToString().Trim();
        case_id.ParameterName = "@CASE_ID";
        cmd.Parameters.Add(case_id);

        //SqlParameter Cluster_id = new SqlParameter();
        //Cluster_id.SqlDbType = SqlDbType.VarChar;
        //Cluster_id.Value = HdnCluster.Value;
        //Cluster_id.ParameterName = "@Cluster_id";
        //cmd.Parameters.Add(Cluster_id);

        //SqlParameter Centre_id = new SqlParameter();
        //Centre_id.SqlDbType = SqlDbType.VarChar;
        //Centre_id.Value = hdncentre.Value;
        //Centre_id.ParameterName = "@Centre_id";
        //cmd.Parameters.Add(Centre_id);

        //SqlParameter CLIENT_ID = new SqlParameter();
        //CLIENT_ID.SqlDbType = SqlDbType.VarChar;
        //CLIENT_ID.Value = Session["ClientID"].ToString();
        //CLIENT_ID.ParameterName = "@CLIENT_ID";
        //cmd.Parameters.Add(CLIENT_ID);

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataTable dt = new DataTable();
        da.Fill(dt);

        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            lblMessage.Text = "Case Reopened Successfully.";
            //lblMessage.Text = "Case is Already Opened.";
        }
        else
        {
            lblMessage.Text = "Case is Already Opened.";
            //lblMessage.Text = "Case Reopened Successfully.";
        }

        clear();
    }
}
