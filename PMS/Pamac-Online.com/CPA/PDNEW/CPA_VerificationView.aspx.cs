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

public partial class CPA_PD_CPA_VerificationView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            VerificationTypeMaster();
        }
        
    }
    private void VerificationTypeMaster()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_VerificationTypeActivity";
        sqlcmd.CommandTimeout = 0;

        SqlParameter ActivityName = new SqlParameter();
        ActivityName.SqlDbType = SqlDbType.VarChar;
        ActivityName.Value = "CPA";
        ActivityName.ParameterName = "@ActivtyName";
        sqlcmd.Parameters.Add(ActivityName);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        ddlVerificationTypeID.DataTextField = "Verification_Type_code";
        ddlVerificationTypeID.DataValueField = "Verification_Type_Id";
        ddlVerificationTypeID.DataSource = dt;
        ddlVerificationTypeID.DataBind();

        ddlVerificationTypeID.Items.Insert(0,"--Select--");
        ddlVerificationTypeID.SelectedIndex = 0; 
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}
