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

public partial class EBC_New_EBC_New_EBC_Summary_MIS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ValidationControl();
        }
    }

    private void ValidationControl()
    {
        btnSearch.Attributes.Add("onclick", "javascript:return SummaryValidation();");
        btnSave.Attributes.Add("onclick", "javascript:return SummaryOthValidation();");  
    }
     
    protected void btnSearch_Click(object sender, EventArgs e)
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        lblMessage.Text = ""; 

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_EBC_Case_Status";

        SqlParameter CaseId = new SqlParameter();
        CaseId.SqlDbType = SqlDbType.VarChar;
        CaseId.Value = txtRefNo.Text.Trim();
        CaseId.ParameterName = "@Ref_No";
        sqlcmd.Parameters.Add(CaseId);

        SqlParameter ClientID = new SqlParameter();
        ClientID.SqlDbType = SqlDbType.Int;
        ClientID.Value = Convert.ToInt32(Session["ClientID"]);
        ClientID.ParameterName = "@ClientID";
        sqlcmd.Parameters.Add(ClientID);


        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataSet ds = new DataSet();
        sqlda.Fill(ds);
        sqlcon.Close();

        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtAppName.Text = ds.Tables[0].Rows[0]["Applicant"].ToString();
                txtCaseId.Text = ds.Tables[0].Rows[0]["Case_ID"].ToString();
                txtDOB.Text = ds.Tables[0].Rows[0]["Date of Birth"].ToString();
                txtPAN.Text = ds.Tables[0].Rows[0]["PanNo"].ToString();
                txtRcvdDate.Text = ds.Tables[0].Rows[0]["Case Received"].ToString();
                txtFatherName.Text = ds.Tables[0].Rows[0]["Father"].ToString();
                ddlFinalStatus.SelectedValue = ds.Tables[0].Rows[0]["FinalStatus"].ToString();

                string CaseComplete = "";
                string SendDate = "";

            CaseComplete = ds.Tables[0].Rows[0]["IS_CASE_COMPLETE"].ToString();
            SendDate = ds.Tables[0].Rows[0]["SEND_DATETIME"].ToString();

            if (CaseComplete != "" && SendDate == "")
            {
                btnSave.Enabled = true;
            }
            else

                btnSave.Enabled = false;
        }
        else
        {
            lblMessage.Text = "Record No Found.........."; 
        }
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                GVSummaryStatus.DataSource = ds.Tables[1];
                GVSummaryStatus.DataBind();
            }

            
            
        }
    
   
    protected void btnSave_Click1(object sender, EventArgs e)
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_UpdateFinalStatus";

            SqlParameter CaseId = new SqlParameter();
            CaseId.SqlDbType = SqlDbType.VarChar;
            CaseId.Value = txtCaseId.Text.Trim();
            CaseId.ParameterName = "@CaseId";
            sqlcmd.Parameters.Add(CaseId);

            SqlParameter FinalStatus = new SqlParameter();
            FinalStatus.SqlDbType = SqlDbType.VarChar;
            FinalStatus.Value = ddlFinalStatus.SelectedValue.ToString();
            FinalStatus.ParameterName = "@FinalStatus";
            sqlcmd.Parameters.Add(FinalStatus);

            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            lblMessage.Text = "Final Status Update Successfully.......!!!!!!";

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
}
