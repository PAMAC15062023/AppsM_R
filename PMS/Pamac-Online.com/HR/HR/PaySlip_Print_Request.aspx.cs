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


public partial class HR_HR_PaySlip_Print_Request : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                
            }
            Registered_Valition_On_Status();

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }

    }

    private void Registered_Valition_On_Status()
    {
        btnAccept.Attributes.Add("onclick","javascript:return Validation_On_Accept_Case(1);");
        btnReject.Attributes.Add("onclick", "javascript:return Validation_On_Accept_Case(1);");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Get_Data_Of_Salary_Slip();       
    }

    public void Get_Data_Of_Salary_Slip()
    {
        try
        {


           CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_SalaryDetails_for_Authorize";
            sqlCom.CommandTimeout = 0;

            SqlParameter Cluster = new SqlParameter();
            Cluster.SqlDbType = SqlDbType.VarChar;
            Cluster.ParameterName = "@Cluster";
            Cluster.Value = "";//ddlCluster.SelectedValue.ToString(); 
            sqlCom.Parameters.Add(Cluster);

            SqlParameter EmployeeCode = new SqlParameter();
            EmployeeCode.SqlDbType = SqlDbType.VarChar;
            EmployeeCode.ParameterName = "@EmployeeCode";
            EmployeeCode.Value = txtEmpCode.Text.Trim();
            sqlCom.Parameters.Add(EmployeeCode);

            SqlParameter Status = new SqlParameter();
            Status.SqlDbType = SqlDbType.Int;
            Status.ParameterName = "@Status";
            Status.Value = ddlStatus.SelectedValue.ToString().Trim();
            sqlCom.Parameters.Add(Status);

            SqlParameter SalaryYear = new SqlParameter();
            SalaryYear.SqlDbType = SqlDbType.VarChar;
            SalaryYear.ParameterName = "@SalaryYear";
            SalaryYear.Value = txtYear.Text.Trim() + ddlMonth.SelectedValue.ToString().Trim();
            sqlCom.Parameters.Add(SalaryYear);

            //SqlParameter UserID = new SqlParameter();
            //UserID.SqlDbType = SqlDbType.VarChar;
            //UserID.ParameterName = "@UserID";
            //UserID.Value = Session["UserID"].ToString();
            //sqlCom.Parameters.Add(UserID);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                GridSerch.DataSource = dt;
                GridSerch.DataBind();
                lblMessage.Text = "Total Records Found " + dt.Rows.Count;
                lblMessage.CssClass = "UpdateMessage";
            }
            else
            {
                GridSerch.DataSource = null;
                GridSerch.DataBind();
                lblMessage.Text = "No Records found!";
                lblMessage.CssClass = "ErrorMessage";
            }

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;

        }
    }


    protected void GridSerch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
            //chkSelect.Attributes.Add("onclick", "javascript:checkSelected('" + chkSelect.ClientID + "');");

            if (e.Row.Cells[6].Text.ToString() == "Pending")
            {
                chkSelect.Enabled = true;
            }
            else
            {
                chkSelect.Enabled = false;
            }

        }

    }

    protected void btnAccept_Click(object sender, EventArgs e)
    {
        int strstatus_Acc=1;
        Insert_into_Salary_Print_Request(strstatus_Acc);
        Get_Data_Of_Salary_Slip();

    }

    public void Insert_into_Salary_Print_Request(int strStatus)
    {
        for (int i = 0; i <= GridSerch.Rows.Count-1; i++)
        {
            CheckBox chkSelect = (CheckBox)GridSerch.Rows[i].FindControl("chkSelect");
            if (chkSelect.Checked==true)
            {

                try
                {
                    CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
                    sqlcon.Open();
                    SqlCommand sqlCom = new SqlCommand();
                    sqlCom.Connection = sqlcon;
                    sqlCom.CommandType = CommandType.StoredProcedure;
                    sqlCom.CommandText = "Insert_Employee_Salary_PrintRequest";
                    sqlCom.CommandTimeout = 0;

                    SqlParameter RequestID = new SqlParameter();
                    RequestID.SqlDbType = SqlDbType.Int;
                    RequestID.ParameterName = "@RequestID";
                    RequestID.Value = chkSelect.ToolTip.ToString();//hdnUID.Value;
                    sqlCom.Parameters.Add(RequestID);

                    SqlParameter Status = new SqlParameter();
                    Status.SqlDbType = SqlDbType.Int;
                    Status.ParameterName = "@Status";
                    Status.Value = strStatus;
                    sqlCom.Parameters.Add(Status);

                    SqlParameter UserID = new SqlParameter();
                    UserID.SqlDbType = SqlDbType.VarChar;
                    UserID.ParameterName = "@UserID";
                    UserID.Value = Session["UserID"].ToString();
                    sqlCom.Parameters.Add(UserID);

                    int intRow = sqlCom.ExecuteNonQuery();
                    sqlcon.Close();

                    if (intRow > 0)
                    {
                        lblMessage.CssClass = "UpdateMessage";
                        lblMessage.Text = "Record Successfully Updated!!!!";
                    }

                }

                catch (Exception ex)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = ex.Message;
                }
            }
        }
    }

    
    protected void btnReject_Click(object sender, EventArgs e)
    {
        int strstatus_Pending= 2;
        Insert_into_Salary_Print_Request(strstatus_Pending);
        Get_Data_Of_Salary_Slip();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("../HR/Default.aspx", true);
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlCluster.SelectedIndex=0;
        ddlMonth.SelectedIndex=0;
        ddlStatus.SelectedIndex=0;
        txtEmpCode.Text="";
        txtYear.Text ="";
     }
}
