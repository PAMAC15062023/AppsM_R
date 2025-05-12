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

public partial class FTP_FTP_Dynamic_FTP_ReviewReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UpdateDeleteTag();
            btnExportExcel.Visible = false;   
        }
    }

    private void UpdateDeleteTag()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Execute_PMS_FILE_Delete_Log";
        sqlcmd.CommandTimeout = 0;

        SqlParameter UserID = new SqlParameter();
        UserID.SqlDbType = SqlDbType.VarChar;
        UserID.Value = Session["UserId"].ToString();
        UserID.ParameterName = "@UserID";
        sqlcmd.Parameters.Add(UserID);

        SqlParameter IsExecute = new SqlParameter();
        IsExecute.SqlDbType = SqlDbType.VarChar;
        IsExecute.Value = "Y";
        IsExecute.ParameterName = "@IsExecute";
        sqlcmd.Parameters.Add(IsExecute);

        sqlcmd.ExecuteNonQuery();
        sqlcon.Close();  

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "FTP_ReviewReport";
        sqlcmd.CommandTimeout = 0;

        SqlParameter FromDate = new SqlParameter();
        FromDate.SqlDbType = SqlDbType.VarChar;
        FromDate.Value = txtFromDate.Text.Trim();
        FromDate.ParameterName = "@FromDate";
        sqlcmd.Parameters.Add(FromDate);

        SqlParameter ToDate = new SqlParameter();
        ToDate.SqlDbType = SqlDbType.VarChar;
        ToDate.Value = txtToDate.Text.Trim();
        ToDate.ParameterName = "@ToDate";
        sqlcmd.Parameters.Add(ToDate);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
            btnExportExcel.Visible = true;
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            lblMsg.Visible = true;  
            lblMsg.Text = "Record Not Found";
            btnExportExcel.Visible = false;
        }
    }

    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        string attachment = "attachment; filename=FTP Review Report.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();

        HtmlTextWriter htw = new HtmlTextWriter(sw);

        GridView1.RenderControl(htw);
        GridView1.GridLines = GridLines.Both;
        //tblExport.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End(); 
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }
}
