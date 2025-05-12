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

public partial class DCR_DCR_CASESTATUSVIEW : System.Web.UI.Page
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;
    string strproc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Search();
    }

    private void Search()
    {
        try
        {
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "DCR_Get_CaseStatusView12";
            sqlcmd.CommandTimeout = 0;

            string CaseID = txtCaseID.Text.ToString().Trim();
            if (CaseID != "")
            {
                SqlParameter Case_ID = new SqlParameter();
                Case_ID.SqlDbType = SqlDbType.VarChar;
                Case_ID.Value = CaseID;
                Case_ID.ParameterName = "@Case_ID";
                sqlcmd.Parameters.Add(Case_ID);
            }
            else
            {
                SqlParameter Case_ID = new SqlParameter();
                Case_ID.SqlDbType = SqlDbType.VarChar;
                Case_ID.Value = DBNull.Value;
                Case_ID.ParameterName = "@Case_ID";
                sqlcmd.Parameters.Add(Case_ID);
            }

            //string LeadID = txtLeadID.Text.ToString().Trim();
            //if (LeadID != "")
            //{
            //    SqlParameter Lead_ID = new SqlParameter();
            //    Lead_ID.SqlDbType = SqlDbType.VarChar;
            //    Lead_ID.Value = LeadID;
            //    Lead_ID.ParameterName = "@Lead_ID";
            //    sqlcmd.Parameters.Add(Lead_ID);
            //}
            //else
            //{
            //    SqlParameter Lead_ID = new SqlParameter();
            //    Lead_ID.SqlDbType = SqlDbType.VarChar;
            //    Lead_ID.Value = DBNull.Value;
            //    Lead_ID.ParameterName = "@Lead_ID";
            //    sqlcmd.Parameters.Add(Lead_ID);
            //}

            //string ChequeNo = txtChequeNo.Text.ToString().Trim();
            //if (ChequeNo != "")
            //{
            //    SqlParameter Cheque_No = new SqlParameter();
            //    Cheque_No.SqlDbType = SqlDbType.VarChar;
            //    Cheque_No.Value = ChequeNo;
            //    Cheque_No.ParameterName = "@ChequeNo";
            //    sqlcmd.Parameters.Add(Cheque_No);
            //}
            //else
            //{
            //    SqlParameter Cheque_No = new SqlParameter();
            //    Cheque_No.SqlDbType = SqlDbType.VarChar;
            //    Cheque_No.Value = DBNull.Value;
            //    Cheque_No.ParameterName = "@ChequeNo";
            //    sqlcmd.Parameters.Add(Cheque_No);
            //}

            //string PolicyNo = txtPolicyNo.Text.ToString().Trim();
            //if (PolicyNo != "")
            //{
            //    SqlParameter Policy_No = new SqlParameter();
            //    Policy_No.SqlDbType = SqlDbType.VarChar;
            //    Policy_No.Value = PolicyNo;
            //    Policy_No.ParameterName = "@Policy_no";
            //    sqlcmd.Parameters.Add(Policy_No);
            //}
            //else
            //{
            //    SqlParameter Policy_No = new SqlParameter();
            //    Policy_No.SqlDbType = SqlDbType.VarChar;
            //    Policy_No.Value = DBNull.Value;
            //    Policy_No.ParameterName = "@Policy_no";
            //    sqlcmd.Parameters.Add(Policy_No);
            //}

            //string MobileNo = txtMobile.Text.ToString().Trim();
            //if (MobileNo != "")
            //{
            //    SqlParameter Mobile = new SqlParameter();
            //    Mobile.SqlDbType = SqlDbType.VarChar;
            //    Mobile.Value = MobileNo;
            //    Mobile.ParameterName = "@CUST_CONTACT_NO";
            //    sqlcmd.Parameters.Add(Mobile);
            //}
            //else
            //{
            //    SqlParameter Mobile = new SqlParameter();
            //    Mobile.SqlDbType = SqlDbType.VarChar;
            //    Mobile.Value = DBNull.Value;
            //    Mobile.ParameterName = "@CUST_CONTACT_NO";
            //    sqlcmd.Parameters.Add(Mobile);
            //}

            //SqlParameter ClientID = new SqlParameter();
            //ClientID.SqlDbType = SqlDbType.VarChar;
            //ClientID.Value = Session["ClientID"].ToString().Trim();
            //ClientID.ParameterName = "@Client_ID";
            //sqlcmd.Parameters.Add(ClientID);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                gvCaseStatusView.DataSource = dt;
                gvCaseStatusView.DataBind();
                lblmsg.Text = "Total Records Founds: " + dt.Rows.Count;
            }
            else
            {
                gvCaseStatusView.DataSource = null;
                gvCaseStatusView.DataBind();
                lblmsg.Text = "No Records Found...!!!";
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }

    private void DownloadFile(string fname, bool forceDownload)
    {
        try
        {
            string path = fname;
            string name = Path.GetFileName(path);
            string ext = Path.GetExtension(path);
            string type = "";
            // set known types based on file extension  
            if (ext != null)
            {
                switch (ext.ToLower())
                {
                    case ".txt":
                        type = "text/plain";
                        break;
                    case ".doc":
                    case ".rtf":
                        type = "Application/msword";
                        break;
                    case ".zip":
                        type = "application/zip";
                        break;
                    case ".xls":
                        type = "application/vnd.ms-excel";
                        break;
                    case ".pdf":
                        type = "application/PDF";
                        break;
                    case ".jpg":
                    case ".jpeg":
                    case ".gif":
                        type = "image/JPEG";
                        break;
                }
            }
            if (forceDownload)

                Response.ClearHeaders();
            Response.ClearContent();
            Response.Clear();

            {
                Response.AppendHeader("content-disposition", "attachment; filename=" + name);
            }
            if (type != "")

                Response.ContentType = type;
            Response.WriteFile(path);
            Response.End();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }

    protected void lnkDownloadFile_Click(object sender, EventArgs e)
    {
        string DownloadPath = ((System.Web.UI.WebControls.LinkButton)(sender)).CommandArgument.ToString();
        if (DownloadPath != "")
        {
            DownloadFile(DownloadPath, true);
        }
        else
        {
            lblmsg.Text = "No Attached Document Found...!!!";
        }
    }

    private void DownloadFile_1(string fname, bool forceDownload)
    {
        try
        {
            string path = fname;
            string name = Path.GetFileName(path);
            string ext = Path.GetExtension(path);
            string type = "";
            // set known types based on file extension  
            if (ext != null)
            {
                switch (ext.ToLower())
                {
                    case ".txt":
                        type = "text/plain";
                        break;
                    case ".doc":
                    case ".rtf":
                        type = "Application/msword";
                        break;
                    case ".zip":
                        type = "application/zip";
                        break;
                    case ".xls":
                        type = "application/vnd.ms-excel";
                        break;
                    case ".pdf":
                        type = "application/PDF";
                        break;
                    case ".jpg":
                    case ".jpeg":
                    case ".gif":
                        type = "image/JPEG";
                        break;
                }
            }
            if (forceDownload)

                Response.ClearHeaders();
            Response.ClearContent();
            Response.Clear();

            {
                Response.AppendHeader("content-disposition", "attachment; filename=" + name);
            }
            if (type != "")

                Response.ContentType = type;
            Response.WriteFile(path);
            Response.End();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }

    protected void lnkDownloadFile_1_Click(object sender, EventArgs e)
    {
        string DownloadPath = ((System.Web.UI.WebControls.LinkButton)(sender)).CommandArgument.ToString();
        if (DownloadPath != "")
        {
            DownloadFile_1(DownloadPath, true);
        }
        else
        {
            lblmsg.Text = "No Attached Document Found...!!!";
        }
    }

    protected void gvCaseStatusView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkDownloadFile = (LinkButton)e.Row.FindControl("lnkDownloadFile");
            if (lnkDownloadFile.CommandArgument == "")
            {
                lnkDownloadFile.Enabled = false;
                lnkDownloadFile.ToolTip = "No Attachment Found...!!!";
            }
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkDownloadFile = (LinkButton)e.Row.FindControl("lnkDownloadFile_1");
            if (lnkDownloadFile.CommandArgument == "")
            {
                lnkDownloadFile.Enabled = false;
                lnkDownloadFile.ToolTip = "No Attachment Found...!!!";
            }
        }
    }

    public SortDirection SortDirection
    {
        get
        {
            if (ViewState["SortDirection"] == null)
            {
                ViewState["SortDirection"] = SortDirection.Ascending;
            }
            return (SortDirection)ViewState["SortDirection"];
        }
        set
        {
            ViewState["SortDirection"] = value;
        }
    }

    protected void gvCaseStatusView_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression;
        string direction = string.Empty;

        if (SortDirection == SortDirection.Ascending)
        {
            SortDirection = SortDirection.Descending;
            direction = "DESC";
        }
        else
        {
            SortDirection = SortDirection.Ascending;
            direction = "ASC";
        }


        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "DCR_Get_CaseStatusView";
        sqlcmd.CommandTimeout = 0;

        SqlParameter Case_ID = new SqlParameter();
        Case_ID.SqlDbType = SqlDbType.VarChar;
        Case_ID.Value = txtCaseID.Text.ToString().Trim();
        Case_ID.ParameterName = "@Case_ID";
        sqlcmd.Parameters.Add(Case_ID);

        SqlParameter Lead_ID = new SqlParameter();
        Lead_ID.SqlDbType = SqlDbType.VarChar;
        Lead_ID.Value = txtLeadID.Text.ToString().Trim();
        Lead_ID.ParameterName = "@Lead_ID";
        sqlcmd.Parameters.Add(Lead_ID);

        SqlParameter Cheque_No = new SqlParameter();
        Cheque_No.SqlDbType = SqlDbType.VarChar;
        Cheque_No.Value = txtChequeNo.Text.ToString().Trim();
        Cheque_No.ParameterName = "@ChequeNo";
        sqlcmd.Parameters.Add(Cheque_No);

        SqlParameter Policy_No = new SqlParameter();
        Policy_No.SqlDbType = SqlDbType.VarChar;
        Policy_No.Value = txtPolicyNo.Text.ToString().Trim();
        Policy_No.ParameterName = "@Policy_no";
        sqlcmd.Parameters.Add(Policy_No);

        SqlParameter Mobile = new SqlParameter();
        Mobile.SqlDbType = SqlDbType.VarChar;
        Mobile.Value = txtMobile.Text.ToString().Trim();
        Mobile.ParameterName = "@CUST_CONTACT_NO";
        sqlcmd.Parameters.Add(Mobile);

        SqlParameter ClientID = new SqlParameter();
        ClientID.SqlDbType = SqlDbType.VarChar;
        ClientID.Value = Session["ClientID"].ToString().Trim();
        ClientID.ParameterName = "@Client_ID";
        sqlcmd.Parameters.Add(ClientID);

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = sqlcmd;

        DataTable dt = new DataTable();
        da.Fill(dt);

        sqlcon.Close();

        dt.DefaultView.Sort = sortExpression + " " + direction;

        gvCaseStatusView.DataSource = dt;
        gvCaseStatusView.DataBind();
    }



}
