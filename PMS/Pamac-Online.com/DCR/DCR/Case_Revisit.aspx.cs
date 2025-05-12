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

public partial class DCR_DCR_Case_Revisit : System.Web.UI.Page
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
        btnRevisit.Attributes.Add("onclick", "javascript:return validate();");
    }

    protected void clear()
    {
        txtcase_id.Text = "";
        txtappname.Text = "";
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";

        sqlcon.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlcon;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "DCR_ReVisit_Search_Case";
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
            lblMsg.Text = "No Record Found.";
            clear();
        }
    }

    protected void btnRevisit_Click(object sender, EventArgs e)
    {
        try
        {
            if (HdnCluster.Value == "1011")
            {
                strproc = "DCR_Insert_Revisit_BVU";
            }
            else if (HdnCluster.Value == "1014")
            {
                strproc = "DCR_Insert_Revisit_EAST";
            }
            else if (HdnCluster.Value == "1013")
            {
                strproc = "DCR_Insert_Revisit_SOUTH";
            }
            else if (HdnCluster.Value == "1015")
            {
                strproc = "DCR_Insert_Revisit_NORTH";
            }
            else if (HdnCluster.Value == "1018")
            {
                strproc = "DCR_Insert_Revisit_BVU";
            }
            else
            {
                strproc = "DCR_Insert_Revisit_WEST";
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

            SqlParameter CLUSTER_ID = new SqlParameter();
            CLUSTER_ID.SqlDbType = SqlDbType.VarChar;
            CLUSTER_ID.Value = HdnCluster.Value;
            CLUSTER_ID.ParameterName = "@CLUSTER_ID";
            cmd.Parameters.Add(CLUSTER_ID);

            SqlParameter CENTRE_ID = new SqlParameter();
            CENTRE_ID.SqlDbType = SqlDbType.VarChar;
            CENTRE_ID.Value = hdncentre.Value;
            CENTRE_ID.ParameterName = "@CENTRE_ID";
            cmd.Parameters.Add(CENTRE_ID);

            SqlParameter ADD_BY = new SqlParameter();
            ADD_BY.SqlDbType = SqlDbType.VarChar;
            ADD_BY.Value = Session["UserID"].ToString().Trim();
            ADD_BY.ParameterName = "@ADD_BY";
            cmd.Parameters.Add(ADD_BY);

            int RowEffected = 0;
            RowEffected = cmd.ExecuteNonQuery();
            sqlcon.Close();

            if (RowEffected > 0)
            {
                lblMsg.Text = "Case Is Now Open For Revisit...!!!";
            }
            clear();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }


}
