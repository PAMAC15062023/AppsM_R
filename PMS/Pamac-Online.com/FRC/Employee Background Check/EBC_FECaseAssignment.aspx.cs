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
using System.Data;
using System.Data.SqlClient;

public partial class EBC_New_EBC_New_EBC_FECaseAssignment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Get_FENameList();
            Get_VerificationCode_List();
            Register_Javascript();
        }

    }
    private void Register_Javascript()
    {
        btnSearch.Attributes.Add("onclick", "javascript:return Validate_Search();");
        btnAssign.Attributes.Add("onclick", "javascript:return Validate_Assignment();");

    }
    private void Get_SubVerification_Type_ID_For_Search()
    {
        try
        {

            int pVerifcationID = 0;

            if (ddlType.SelectedIndex != 0)
            {
                pVerifcationID=Convert.ToInt32(ddlType.SelectedItem.Value);
            }

            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_SubVerification_Type_ID_For_Search";

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            SqlParameter Verification_Type_ID = new SqlParameter();
            Verification_Type_ID.SqlDbType = SqlDbType.Int;
            Verification_Type_ID.Value = pVerifcationID;
            Verification_Type_ID.ParameterName = "@Verification_Type_ID";
            sqlCom.Parameters.Add(Verification_Type_ID);

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlcon.Close();

            ddlSubVeriType.Items.Clear();

            ddlSubVeriType.DataTextField = "Verification_Code";
            ddlSubVeriType.DataValueField = "Sub_Verification_Type_ID";
            
            ddlSubVeriType.DataSource = dt;
            ddlSubVeriType.DataBind();

            ddlSubVeriType.Items.Insert(0, "--All--");
            ddlSubVeriType.SelectedIndex = 0;



        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    private void Get_VerificationCode_List()
    {
        try
        {


            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_VerificationTypeID_ForEBC";

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlcon.Close();

            ddlType.DataTextField = "Verification_Type";
            ddlType.DataValueField = "Verification_Type_ID";

            ddlType.DataSource = dt;
            ddlType.DataBind();

            ddlType.Items.Insert(0, "--All--");
            ddlType.SelectedIndex = 0;



        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    private void Get_FENameList()
    {
        try
        {


            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_EmployeeNameList";

            SqlParameter CentreID = new SqlParameter();
            CentreID.SqlDbType = SqlDbType.Int ;
            CentreID.Value = Convert.ToInt32(Session["CentreID"]);
            CentreID.ParameterName = "@CentreID";
            sqlCom.Parameters.Add(CentreID);

            SqlParameter Designation_Code = new SqlParameter();
            Designation_Code.SqlDbType = SqlDbType.VarChar  ;
            Designation_Code.Value = "FE";
            Designation_Code.ParameterName = "@Designation_Code";
            sqlCom.Parameters.Add(Designation_Code);

            SqlParameter EmployeeName = new SqlParameter();
            EmployeeName.SqlDbType = SqlDbType.VarChar  ;
            EmployeeName.Value = "";
            EmployeeName.ParameterName = "@EmployeeName";
            sqlCom.Parameters.Add(EmployeeName);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlcon.Close();

            ddlFENameList.DataTextField = "FullName";
            ddlFENameList.DataValueField = "EMP_ID";

            ddlFENameList.DataSource = dt;
            ddlFENameList.DataBind();

            ddlFENameList.Items.Insert(0, "--Select--");
            ddlFENameList.SelectedIndex = 0;

            ddlFE.DataTextField = "FullName";
            ddlFE.DataValueField = "EMP_ID";

            ddlFE.DataSource = dt;
            ddlFE.DataBind();

            ddlFE.Items.Insert(0, "--Select--");
            ddlFE.SelectedIndex = 0;



        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }
    private void Get_EBC_Case_For_FEAssignment()
    {
        try
        {

            int pFEID = 0;

            if (ddlFENameList.SelectedIndex != 0)
            {
                string strFEName = ddlFENameList.SelectedItem.Value.Trim();

                string[] arrFEName = strFEName.Split(':');
                if (arrFEName.Length > 0)
                {
                    pFEID =Convert.ToInt32(arrFEName[0]);
                }
            }
            int pVerificationID = 0;

            if (ddlType.SelectedIndex != 0)
            {
                pVerificationID = Convert.ToInt32(ddlType.SelectedItem.Value); 

            }

            int pSubVerificationID = 0;

            if (ddlSubVeriType.SelectedIndex != 0)
            {
                pSubVerificationID = Convert.ToInt32(ddlSubVeriType.SelectedItem.Value);

            }

            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_EBC_Case_For_FEAssignment";

            SqlParameter CentreID = new SqlParameter();
            CentreID.SqlDbType = SqlDbType.Int;
            CentreID.Value = Convert.ToInt32(Session["CentreID"]);
            CentreID.ParameterName = "@CentreID";
            sqlCom.Parameters.Add(CentreID);

            SqlParameter FEID = new SqlParameter();
            FEID.SqlDbType = SqlDbType.Int;
            FEID.Value = pFEID;
            FEID.ParameterName = "@FEID";
            sqlCom.Parameters.Add(FEID);

            SqlParameter ApplicantName = new SqlParameter();
            ApplicantName.SqlDbType = SqlDbType.VarChar;
            ApplicantName.Value = txtCustName.Text.Trim();
            ApplicantName.ParameterName = "@ApplicantName";
            sqlCom.Parameters.Add(ApplicantName);

            SqlParameter FromDate = new SqlParameter();
            FromDate.SqlDbType = SqlDbType.VarChar;
            FromDate.Value = txtFromDate.Text.Trim();
            FromDate.ParameterName = "@FromDate";
            sqlCom.Parameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.SqlDbType = SqlDbType.VarChar;
            ToDate.Value = txtToDate.Text.Trim();
            ToDate.ParameterName = "@ToDate";
            sqlCom.Parameters.Add(ToDate);

            SqlParameter VerificationID = new SqlParameter();
            VerificationID.SqlDbType = SqlDbType.Int;
            VerificationID.Value = pVerificationID;
            VerificationID.ParameterName = "@VerificationID";
            sqlCom.Parameters.Add(VerificationID);

            SqlParameter SubVerificationID = new SqlParameter();
            SubVerificationID.SqlDbType = SqlDbType.Int;
            SubVerificationID.Value = pSubVerificationID;
            SubVerificationID.ParameterName = "@SubVerificationID";
            sqlCom.Parameters.Add(SubVerificationID);

            SqlParameter ClientID = new SqlParameter();
            ClientID.SqlDbType = SqlDbType.Int;
            ClientID.Value = Convert.ToInt32(Session["ClientID"]);
            ClientID.ParameterName = "@ClientID";
            sqlCom.Parameters.Add(ClientID);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlcon.Close();


            if (dt.Rows.Count > 0)
            {
                gvFEAssignmentCases.DataSource = dt;
                gvFEAssignmentCases.DataBind();

            }
            else
            {
                gvFEAssignmentCases.DataSource =null;
                gvFEAssignmentCases.DataBind();
            }
            lblMessage.Text = "No of Records found! "+ dt.Rows.Count.ToString(); 

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Get_EBC_Case_For_FEAssignment();
    }
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        
            Get_SubVerification_Type_ID_For_Search();
        
    }
    protected void btnAssign_Click(object sender, EventArgs e)
    {
        Insert_EBC_FE_CaseAssigment();
    }
    private void Insert_EBC_FE_CaseAssigment()
    {
        try
        {
            int pFEID = 0;
            if (ddlFE.SelectedIndex != 0)
            {
                string strFEName = ddlFE.SelectedItem.Value.Trim();

                string[] arrFEName = strFEName.Split(':');
                if (arrFEName.Length > 0)
                {
                    pFEID =Convert.ToInt32(arrFEName[0]);
                }
            }
            if (pFEID !=0)
            {
                CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

                sqlcon.Open();
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlcon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "Insert_EBC_FE_CaseAssigment";

                SqlParameter Case_Details = new SqlParameter();
                Case_Details.SqlDbType = SqlDbType.VarChar;
                Case_Details.Value = Get_CaseDetails_For_Assignment();
                Case_Details.ParameterName = "@Case_Details";
                sqlCom.Parameters.Add(Case_Details);

                SqlParameter FEID = new SqlParameter();
                FEID.SqlDbType = SqlDbType.VarChar;
                FEID.Value = pFEID;
                FEID.ParameterName = "@FEID";
                sqlCom.Parameters.Add(FEID);

                SqlParameter UserID = new SqlParameter();
                UserID.SqlDbType = SqlDbType.VarChar;
                UserID.Value = Session["UserID"].ToString();
                UserID.ParameterName = "@UserID";
                sqlCom.Parameters.Add(UserID);

                int RowFCheckBoxEffetced = Convert.ToInt32(sqlCom.ExecuteNonQuery());

                if (RowFCheckBoxEffetced > 0)
                {

                    lblMessage.Text = "Record Updated Successfully!";
                    
                }
                else
                {
                    lblMessage.Text = "Error Occured!";
                }


            }

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    
    }

    private string Get_CaseDetails_For_Assignment()
    {
        string strCaseDetails = "";
        for (int i = 0; i <= gvFEAssignmentCases.Rows.Count - 1; i++)
        {
            CheckBox chkCaseId = (CheckBox)gvFEAssignmentCases.Rows[i].Cells[0].FindControl("chkCaseId");
            

            if (chkCaseId.Checked == true)
            {
                strCaseDetails = strCaseDetails + gvFEAssignmentCases.Rows[i].Cells[1].Text.Trim() + "|" + gvFEAssignmentCases.Rows[i].Cells[5].Text.Trim() + "|" + gvFEAssignmentCases.Rows[i].Cells[6].Text.Trim()+"^";
            
            }
        }

        return strCaseDetails;
    }


}
