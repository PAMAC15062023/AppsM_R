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

public partial class IDOC_IDOC_Reopen : System.Web.UI.Page
{


    CCommon objConn = new CCommon();
    SqlConnection sqlcon;
    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);
        if (!IsPostBack)
        {
            validate();

        }

    }
    protected void btnsearch_Click1(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlcon;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "IDOC_reopen_search";
        cmd.CommandTimeout = 0;

        SqlParameter case_id = new SqlParameter();
        case_id.SqlDbType = SqlDbType.VarChar;
        case_id.Value = txtcaseid.Text;
        case_id.ParameterName = "@CASE_ID";
        cmd.Parameters.Add(case_id);

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            txtrefno.Text = dt.Rows[0]["REF_NO"].ToString();
            txtappname.Text = dt.Rows[0]["FULL_NAME"].ToString();
         }
        else
        {
            lblMessage.Text = "";

        }

    }

    protected void validate()
    {
        btnsearch.Attributes.Add("onclick", "javascript:return validate();");
        btnReopen.Attributes.Add("onclick", "javascript:return validateall();");

    }

    protected void clear()
    {
        txtcaseid.Text = "";
        txtrefno.Text = "";
        txtappname.Text = "";
     }
    protected void btnReopen_Click1(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlcon;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_reopen_case_ststus_IDOC";
        cmd.CommandTimeout = 0;

        SqlParameter case_id = new SqlParameter();
        case_id.SqlDbType = SqlDbType.VarChar;
        case_id.Value = txtcaseid.Text;
        case_id.ParameterName = "@CASE_ID";
        cmd.Parameters.Add(case_id);

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            lblMessage.Text = "Case is Already Open ";
        }
        else
        {
            lblMessage.Text = " Case is Reopen ";

        }
       
        clear();
    }
    }

