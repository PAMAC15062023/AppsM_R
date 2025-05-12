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

public partial class EBC_New_EBC_New_EBC_New_CaseStatusView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void grv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
            //LinkButton lnkDownloadFile = (LinkButton)e.Row.FindControl("lnkDownloadFile");
            //if (lnkDownloadFile.CommandArgument == "")
            //{
            //    lnkDownloadFile.Enabled = false;
            //    lnkDownloadFile.ToolTip = "No Attachment found!";
            //}

            GridView grvDetails = (GridView)e.Row.FindControl("grvDetails");
            grvDetails.DataSource = Get_TransactionDetails(e.Row.Cells[1].Text);
            grvDetails.DataBind();
        }

    }
    protected void grvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            LinkButton LinkButton1 = (LinkButton)e.Row.FindControl("LinkButton1");
            LinkButton LinkButton2 = (LinkButton)e.Row.FindControl("LinkButton2");
            LinkButton LinkButton3 = (LinkButton)e.Row.FindControl("LinkButton3");
            LinkButton LinkButton4 = (LinkButton)e.Row.FindControl("LinkButton4");
            LinkButton LinkButton5 = (LinkButton)e.Row.FindControl("LinkButton5");
            LinkButton1.Visible = false;
            LinkButton2.Visible = false;
            LinkButton3.Visible = false;
            LinkButton4.Visible = false;
            LinkButton5.Visible = false; 

            if (e.Row.Cells[1].Text == "RAV")
            {
                if (e.Row.Cells[1].Text == "EAV")
                {
                    LinkButton1.Text = "EAV";
                    LinkButton1.PostBackUrl = "";
                    LinkButton1.Visible = true; 

                }
                if (e.Row.Cells[1].Text == "PAV")
                {
                    LinkButton2.Text = "PAV";
                    LinkButton2.PostBackUrl = "";
                    LinkButton2.Visible = true; 

                }
                if (e.Row.Cells[1].Text == "CAV")
                {
                    LinkButton3.Text = "CAV";
                    LinkButton3.PostBackUrl = "";
                    LinkButton3.Visible = true; 

                }
            
            }

            
        }

    }
    

    private DataTable  Get_TransactionDetails(string  strTransactionID)
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

        sqlcon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlcon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "Get_EBC_CaseStatus_Details";

        SqlParameter TransactionID = new SqlParameter();
        TransactionID.SqlDbType = SqlDbType.VarChar;
        TransactionID.Value = strTransactionID;
        TransactionID.ParameterName = "@Case_id";
        sqlCom.Parameters.Add(TransactionID);

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlcon.Close();

        return dt;

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SearchData();
    }

    private void SearchData()
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_EBC_CaseStatusView_Search";
            sqlcmd.CommandTimeout = 0;

            SqlParameter CaseId = new SqlParameter();
            CaseId.SqlDbType = SqlDbType.VarChar;
            CaseId.ParameterName = "@Case_ID";
            CaseId.Value = txtCaseID.Text.Trim();
            sqlcmd.Parameters.Add(CaseId);

            SqlParameter Ref_No = new SqlParameter();
            Ref_No.SqlDbType = SqlDbType.VarChar;
            Ref_No.ParameterName = "@Ref_No";
            Ref_No.Value = txtRefNo.Text.Trim();
            sqlcmd.Parameters.Add(Ref_No);

            SqlParameter Applicant_Name = new SqlParameter();
            Applicant_Name.SqlDbType = SqlDbType.VarChar;
            Applicant_Name.ParameterName = "@Applicant_Name";
            Applicant_Name.Value = txtApplicantName.Text.Trim();
            sqlcmd.Parameters.Add(Applicant_Name);

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                grvTransactionInfo.DataSource = dt;
                grvTransactionInfo.DataBind();
            }
            else
            {
                lblMessage.Text = "Record Not Found..............";
            }

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
}
