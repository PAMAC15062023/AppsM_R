using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Net;

public partial class Pages_SBM_ShowProcessAndPolicies : System.Web.UI.Page
{
    CCommon connobj = new CCommon();
    CCommon objConn = new CCommon(); 
    SqlConnection sqlcon;
    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);
        if (!IsPostBack)
        {
            BindDetails();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Software Requirement/Policy/default.aspx", true);
    }

    public void BindDetails()
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);

        SqlCommand cmd = new SqlCommand("USP_ViewProcessAndPoliciesFiles", sqlcon);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        if (ds != null && ds.Tables[0].Rows.Count > 0 && ds.Tables.Count > 0)
        {
            gvFile.DataSource = ds;
            gvFile.DataBind();
        }
        else
        {

        }
    }

    protected void lkbtnViewFile_Click(object sender, EventArgs e)
    {
        int rowIndex = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;

        string FileLocation = gvFile.Rows[rowIndex].Cells[3].Text + gvFile.Rows[rowIndex].Cells[2].Text;

        string FilePath = FileLocation;

        WebClient User = new WebClient();

        Byte[] FileBuffer = User.DownloadData(FilePath);

        if (FileBuffer != null)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-length", FileBuffer.Length.ToString());
            Response.BinaryWrite(FileBuffer);
        }
    }

    protected void gvFile_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[3].Style.Add(HtmlTextWriterStyle.Display, "none");
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[3].Style.Add(HtmlTextWriterStyle.Display, "none");
        }
    }
}