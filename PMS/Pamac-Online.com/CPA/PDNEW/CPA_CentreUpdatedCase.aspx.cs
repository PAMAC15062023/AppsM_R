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

public partial class CPA_PD_CPA_CentreUpdatedCase : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CentreNameList();
            ValidationControl();
        }
    }

    private void ValidationControl()
    {
        btnSearch.Attributes.Add("onclick", "javascript:return ValidControl();"); 
  
    }

    private void CentreNameList()
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "CPA_CentreNameList";
            sqlcmd.CommandTimeout = 0;

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                ddlCentreName.DataTextField = "Centre_name";
                ddlCentreName.DataValueField = "centre_id";
                ddlCentreName.DataSource = dt;
                ddlCentreName.DataBind();

                ddlCentreName.Items.Insert(0,"--Select--");
                ddlCentreName.SelectedIndex = 0;  
            }
        }
        catch (Exception ex)
        {
             lblMessage.Text=ex.Message;   
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();
              
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "CPA_CentreUpdatedCases";
            sqlcmd.CommandTimeout = 0;

            SqlParameter CentreId = new SqlParameter();
            CentreId.SqlDbType = SqlDbType.VarChar;
            CentreId.Value = ddlCentreName.SelectedValue.ToString();
            CentreId.ParameterName = "@CentreId";
            sqlcmd.Parameters.Add(CentreId);

            SqlParameter FromDate = new SqlParameter();
            FromDate.SqlDbType = SqlDbType.VarChar;
            FromDate.Value = txtFromDate.Text.Trim();
            FromDate.ParameterName = "@FromDate";
            sqlcmd.Parameters.Add(FromDate);

            SqlParameter Todate = new SqlParameter();
            Todate.SqlDbType = SqlDbType.VarChar;
            Todate.Value = txtToDate.Text.Trim();
            Todate.ParameterName = "@ToDate";
            sqlcmd.Parameters.Add(Todate);

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text=ex.Message;  
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");  
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {

    }

    protected void LBUpdateDoc_Click(object sender, EventArgs e)
    {
        string Case_id = ((System.Web.UI.WebControls.LinkButton)(sender)).CommandArgument.ToString();
        string strJScript = "";
        strJScript = "<script language='javascript'>    ";
        strJScript = strJScript + "  window.open('CPA_CentreUpdatedCase_View.aspx?Id=" + Case_id + "', '_blank', 'height=600,width=700,status=yes,resizable=no');";
        strJScript = strJScript + "</script>";
        Page.RegisterClientScriptBlock("OpenPage", strJScript);
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
         if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
            LinkButton LBUpdateDoc = (LinkButton)e.Row.FindControl("LBUpdateDoc");
            if (LBUpdateDoc.CommandArgument != "")
            {
                LBUpdateDoc.Attributes.Add("onclick", "javascript:return UpdateCaseDetails('" + LBUpdateDoc.CommandArgument + "');");

            }   
        }
    }

}
