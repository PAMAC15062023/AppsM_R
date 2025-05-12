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
public partial class FRC_Employee_Background_Check_EBC_GlobalDatabaseSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Context.Request.QueryString["CaseID"] != null && Context.Request.QueryString["CaseID"] != "" && Context.Request.QueryString["VerificationTypeID"] != null && Context.Request.QueryString["VerificationTypeID"] != "" && Context.Request.QueryString["SubVerificationTypeId"] != null && Context.Request.QueryString["SubVerificationTypeId"] != "")
            {
           
                hdnCaseID.Value = Context.Request.QueryString["CaseID"];
                hdnMainVerifyID.Value = Context.Request.QueryString["VerificationTypeID"];
                hdnSubVerifyTypeID.Value = Context.Request.QueryString["SubVerificationTypeId"];

                if (Context.Request.QueryString["Mode"] == "View")
                {

                    btnSave.Enabled = false;
                }

            }
            Get_GlobalDatabaseSerach();

        }
        
    }
    private void Get_GlobalDatabaseSerach()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_GlobalDatabaseSearchDetails";
        sqlcmd.CommandTimeout = 0;

        SqlParameter CaseID = new SqlParameter();
        CaseID.SqlDbType = SqlDbType.Int;
        CaseID.ParameterName = "@CaseID";
        CaseID.Value = hdnCaseID.Value;  
        sqlcmd.Parameters.Add(CaseID);

        SqlParameter Verification_Type_ID = new SqlParameter();
        Verification_Type_ID.SqlDbType = SqlDbType.Int;
        Verification_Type_ID.ParameterName = "@Verification_Type_ID";
        Verification_Type_ID.Value = hdnMainVerifyID.Value;  
        sqlcmd.Parameters.Add(Verification_Type_ID);

        SqlParameter SubVerificationTypeID = new SqlParameter();
        SubVerificationTypeID.SqlDbType = SqlDbType.Int;
        SubVerificationTypeID.ParameterName = "@SubVerificationTypeID";
        SubVerificationTypeID.Value =hdnSubVerifyTypeID.Value;
        sqlcmd.Parameters.Add(SubVerificationTypeID);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            txtEmpFname.Text = dt.Rows[0]["E_Name"].ToString().Trim();
            txtCompName.Text = dt.Rows[0]["Company_Name"].ToString().Trim();
            txtPersonContacted.Text = dt.Rows[0]["Contanted_Name"].ToString().Trim();
            txtPersonDesgn.Text = dt.Rows[0]["Desigantion_Contacted_Person"].ToString().Trim();
            txtContact.Text = dt.Rows[0]["Contact_Detalis"].ToString().Trim();
            ddlRecordFound.SelectedValue = dt.Rows[0]["Record_Found"].ToString().Trim();
            txtRemark.Text = dt.Rows[0]["Remark"].ToString().Trim();
            txtStatus.Text = dt.Rows[0]["status"].ToString().Trim();
            txtSupName.Text = dt.Rows[0]["SupervisorName"].ToString().Trim();
            txtDateTime.Text = dt.Rows[0]["Date_Of_Visit"].ToString().Trim();

        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_InsertGlobalDatabaseSearchData ";
            sqlcmd.CommandTimeout = 0;

            SqlParameter CaseID = new SqlParameter();
            CaseID.SqlDbType = SqlDbType.Int;
            CaseID.ParameterName = "@CaseID";
            CaseID.Value = hdnCaseID.Value;
            sqlcmd.Parameters.Add(CaseID);


            SqlParameter Verification_Type_ID = new SqlParameter();
            Verification_Type_ID.SqlDbType = SqlDbType.Int;
            Verification_Type_ID.ParameterName = "@Verification_Type_ID";
            Verification_Type_ID.Value = hdnMainVerifyID.Value;
            sqlcmd.Parameters.Add(Verification_Type_ID);

            SqlParameter SubVerificationTypeID = new SqlParameter();
            SubVerificationTypeID.SqlDbType = SqlDbType.Int;
            SubVerificationTypeID.ParameterName = "@SubVerificationTypeID";
            SubVerificationTypeID.Value = hdnSubVerifyTypeID.Value;
            sqlcmd.Parameters.Add(SubVerificationTypeID);

            SqlParameter Employee_Name = new SqlParameter();
            Employee_Name.SqlDbType = SqlDbType.VarChar;
            Employee_Name.ParameterName = "@E_name";
            Employee_Name.Value = txtEmpFname.Text.Trim(); //+ " " + txtEmpMname.Text.Trim() + " " + txtEmpLname.Text.Trim();
            sqlcmd.Parameters.Add(Employee_Name);

            SqlParameter Company_Name = new SqlParameter();
            Company_Name.SqlDbType = SqlDbType.VarChar;
            Company_Name.ParameterName = "@Company_Name";
            Company_Name.Value = txtCompName.Text.Trim();
            sqlcmd.Parameters.Add(Company_Name);


            SqlParameter Contanted_Name = new SqlParameter();
            Contanted_Name.SqlDbType = SqlDbType.VarChar;
            Contanted_Name.ParameterName = "@Contanted_Name";
            Contanted_Name.Value = txtPersonContacted.Text.Trim();
            sqlcmd.Parameters.Add(Contanted_Name);


            SqlParameter Desigantion_Contacted_Person = new SqlParameter();
            Desigantion_Contacted_Person.SqlDbType = SqlDbType.VarChar;
            Desigantion_Contacted_Person.ParameterName = "@Desigantion_Contacted_Person";
            Desigantion_Contacted_Person.Value = txtPersonDesgn.Text.Trim();
            sqlcmd.Parameters.Add(Desigantion_Contacted_Person);


            SqlParameter Contact_Detalis = new SqlParameter();
            Contact_Detalis.SqlDbType = SqlDbType.VarChar;
            Contact_Detalis.ParameterName = "@Contact_Detalis";
            Contact_Detalis.Value = txtContact.Text.Trim();
            sqlcmd.Parameters.Add(Contact_Detalis);

            SqlParameter Record_Found = new SqlParameter();
            Record_Found.SqlDbType = SqlDbType.VarChar;
            Record_Found.ParameterName = "@Record_Found";
            Record_Found.Value = ddlRecordFound.SelectedValue.Trim();
            sqlcmd.Parameters.Add(Record_Found);

            SqlParameter Remark = new SqlParameter();
            Remark.SqlDbType = SqlDbType.VarChar;
            Remark.ParameterName = "@Remark";
            Remark.Value = txtRemark.Text.Trim();
            sqlcmd.Parameters.Add(Remark);

            SqlParameter status = new SqlParameter();
            status.SqlDbType = SqlDbType.VarChar;
            status.ParameterName = "@status";
            status.Value = txtRemark.Text.Trim();
            sqlcmd.Parameters.Add(status);

            SqlParameter SupervisorName = new SqlParameter();
            SupervisorName.SqlDbType = SqlDbType.VarChar;
            SupervisorName.ParameterName = "@SupervisorName";
            SupervisorName.Value = txtSupName.Text.Trim();
            sqlcmd.Parameters.Add(SupervisorName);

            SqlParameter Date_Of_Visit = new SqlParameter();
            Date_Of_Visit.SqlDbType = SqlDbType.VarChar;
            Date_Of_Visit.ParameterName = "@Date_Of_Visit";
            Date_Of_Visit.Value = txtDateTime.Text.Trim();
            sqlcmd.Parameters.Add(Date_Of_Visit);


            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            lblmsg.Text = "Record Save Successfuly";

            IsCaseComplete();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }

    private void IsCaseComplete()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "spIsEbcVerificationComplete";
        sqlcmd.CommandTimeout = 0;

        SqlParameter CASE_ID = new SqlParameter();
        CASE_ID.SqlDbType = SqlDbType.VarChar;
        CASE_ID.Value = hdnCaseID.Value;
        CASE_ID.ParameterName = "@CASE_ID";
        sqlcmd.Parameters.Add(CASE_ID);

        SqlParameter VarResult = new SqlParameter();
        VarResult.SqlDbType = SqlDbType.VarChar;
        VarResult.Value = "";
        VarResult.ParameterName = "@MessageNO";
        VarResult.Size = 200;
        VarResult.Direction = ParameterDirection.Output;
        sqlcmd.Parameters.Add(VarResult);

        sqlcmd.ExecuteNonQuery();
        string RowEffected = Convert.ToString(sqlcmd.Parameters["@MessageNO"].Value);

        if (RowEffected != "")
        {
            lblmsg.Text = RowEffected;
            lblmsg.CssClass = "SuccessMessage";
            lblmsg.Text = RowEffected;
            lblmsg.Visible = true;
        }

        sqlcon.Close();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("EBC_New_VerificationView.aspx", false);
    }
    
}
