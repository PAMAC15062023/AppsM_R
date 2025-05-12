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


public partial class QueryBuilder_FE_PayoutProcess_Monthly : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                btnSave.Visible = false; 
            }

        }
        catch(Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message;
            
         }


    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GETDataFor_FEPayout();

    }
    private void GETDataFor_FEPayout()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_FE_PayoutCount_For_MonthyAuthorize";
        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;

        SqlParameter CentreId = new SqlParameter();
        CentreId.SqlDbType = SqlDbType.VarChar;
        CentreId.ParameterName = "@CentreId";
        CentreId.Value = Session["CentreId"].ToString();
        sqlcmd.Parameters.Add(CentreId);

        string[] EmployeeInfo = ddlFeName.SelectedItem.Value.Split(':');
        int EmployeeID = 0;
        if (EmployeeInfo.Length > 1)
        {
            EmployeeID = Convert.ToInt32(EmployeeInfo[0]);
            string EmployeeCode = EmployeeInfo[1];
            hdnFEID.Value = EmployeeID.ToString();
        }

        SqlParameter FeId = new SqlParameter();
        FeId.SqlDbType = SqlDbType.VarChar;
        FeId.ParameterName = "@FeId";
        FeId.Value = EmployeeID.ToString();
        sqlcmd.Parameters.Add(FeId);


        SqlParameter FromDate = new SqlParameter();
        FromDate.SqlDbType = SqlDbType.VarChar;
        FromDate.ParameterName = "@FromDate";
        FromDate.Value = txtFromDate.Text.Trim();
        sqlcmd.Parameters.Add(FromDate);

        SqlParameter ToDate = new SqlParameter();
        ToDate.SqlDbType = SqlDbType.VarChar;
        ToDate.ParameterName = "@ToDate";
        ToDate.Value = txtToDate.Text.Trim();
        sqlcmd.Parameters.Add(ToDate);

        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            GV1.DataSource = dt;
            GV1.DataBind();
            btnSave.Visible = true;
        }
        else
        {
            GV1.DataSource = null;
            GV1.DataBind();
            lblMsg.Text = "Records Not Found!!!!!";
        }

    }

    protected void GV1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView grvDetails = (GridView)e.Row.FindControl("grvDetails");//
            CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
            chkSelect.Attributes.Add("onclick", "javascript:checkSelected('" + chkSelect.ClientID + "','" + grvDetails.ClientID + "');");


            LinkButton lnkFeName = (LinkButton)e.Row.FindControl("lnkFeName");
           
            

            string  strFEID=lnkFeName.CommandArgument.ToString().Trim();
            grvDetails.DataSource = (DataTable)SearchFePayoutData(strFEID);
            grvDetails.DataBind();


        }
    }
    private DataTable SearchFePayoutData(string FEID)
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_FEPayoutDetails_For_Authorize";
       

        SqlParameter CentreId = new SqlParameter();
        CentreId.SqlDbType = SqlDbType.VarChar;
        CentreId.ParameterName = "@CentreId";
        CentreId.Value = Session["CentreId"].ToString();
        sqlcmd.Parameters.Add(CentreId);

        SqlParameter FeId = new SqlParameter();
        FeId.SqlDbType = SqlDbType.VarChar;
        FeId.ParameterName = "@FeId";
        FeId.Value = FEID;
        sqlcmd.Parameters.Add(FeId);


        SqlParameter FromDate = new SqlParameter();
        FromDate.SqlDbType = SqlDbType.VarChar;
        FromDate.ParameterName = "@FromDate";
        FromDate.Value = txtFromDate.Text.Trim();
        sqlcmd.Parameters.Add(FromDate);

        SqlParameter ToDate = new SqlParameter();
        ToDate.SqlDbType = SqlDbType.VarChar;
        ToDate.ParameterName = "@ToDate";
        ToDate.Value = txtToDate.Text.Trim();
        sqlcmd.Parameters.Add(ToDate);

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlcon.Close();

        return dt;

    }

    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        InsertGridData();
    }

    private void InsertGridData()
    {

        for (int i = 0; i <=GV1.Rows.Count -1; i++)
        {
            GridView grvDetails = (GridView) GV1.Rows[i].FindControl("grvDetails");//

       for (int j = 0; j <= grvDetails.Rows.Count - 1; j++)
        {
            CheckBox chkSelect = (CheckBox)grvDetails.Rows[j].FindControl("chkSelect");

            if (chkSelect.Checked == true)
            {
                string[] ColDetails = new string[4];
                ColDetails[0] = grvDetails.Rows[j].Cells[2].Text.ToString().Trim();
                ColDetails[1] = grvDetails.Rows[j].Cells[1].Text.ToString().Trim();
                ColDetails[2] = grvDetails.Rows[j].Cells[5].Text.ToString().Trim();
                ColDetails[3] = grvDetails.DataKeys[j].Value.ToString();

                InsertFePayoutData(ColDetails);
            }
        }

    }


    }

    private void InsertFePayoutData(string[] strcol)
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Insert_Authorize_FE_Payout";

            SqlParameter CaseId = new SqlParameter();
            CaseId.SqlDbType = SqlDbType.VarChar;
            CaseId.Value = strcol[0].ToString();
            CaseId.ParameterName = "@Case_id";
            sqlcmd.Parameters.Add(CaseId);

            SqlParameter ProductCode = new SqlParameter();
            ProductCode.SqlDbType = SqlDbType.VarChar;
            ProductCode.Value = strcol[1].ToString();
            ProductCode.ParameterName = "@ProductCode";
            sqlcmd.Parameters.Add(ProductCode);

            SqlParameter Verification_Code = new SqlParameter();
            Verification_Code.SqlDbType = SqlDbType.VarChar;
            Verification_Code.Value = strcol[2].ToString();
            Verification_Code.ParameterName = "@Verification_Code";
            sqlcmd.Parameters.Add(Verification_Code);

            SqlParameter FE_ID = new SqlParameter();
            FE_ID.SqlDbType = SqlDbType.VarChar;
            FE_ID.Value = strcol[3].ToString();
            FE_ID.ParameterName = "@FE_ID";
            sqlcmd.Parameters.Add(FE_ID);
             
            SqlParameter UserId = new SqlParameter();
            UserId.SqlDbType = SqlDbType.VarChar;
            UserId.Value = Session["UserId"].ToString();
            UserId.ParameterName = "@UserId";
            sqlcmd.Parameters.Add(UserId);

            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            lblMsg.Text = "Data Save Successfully..........";
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }


    protected void btnShow_Click(object sender, EventArgs e)
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_EmployeeNameList";
        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;

        SqlParameter CentreId = new SqlParameter();
        CentreId.SqlDbType = SqlDbType.Int;
        CentreId.ParameterName = "@CentreID";
        CentreId.Value = Session["CentreId"].ToString();
        sqlcmd.Parameters.Add(CentreId);

        SqlParameter DesigCode = new SqlParameter();
        DesigCode.SqlDbType = SqlDbType.VarChar;
        DesigCode.ParameterName = "@Designation_Code";
        DesigCode.Value = "FE";
        sqlcmd.Parameters.Add(DesigCode);

        SqlParameter EmpName = new SqlParameter();
        EmpName.SqlDbType = SqlDbType.VarChar;
        EmpName.ParameterName = "@EmployeeName";
        EmpName.Value = txtFeName.Text.Trim();
        sqlcmd.Parameters.Add(EmpName);

        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        ddlFeName.DataTextField = "FullName";
        ddlFeName.DataValueField = "Emp_Id";
        ddlFeName.DataSource = dt;
        ddlFeName.DataBind();

        ddlFeName.Items.Insert(0, "--Select--");
        ddlFeName.SelectedIndex = 0;
    }

}
