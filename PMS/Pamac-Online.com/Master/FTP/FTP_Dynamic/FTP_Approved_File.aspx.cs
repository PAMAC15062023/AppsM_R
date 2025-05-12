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

public partial class FTP_FTP_Dynamic_FTP_Approved_File : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //GetRequest_By_List();
                //GetAuthorize_By_List();
                RegisterControls_WithJavascript();
            }
            
        }
        catch(Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
        
       
    }

    private void RegisterControls_WithJavascript()
    {
        btnSearch.Attributes.Add("onclick", "javascript:return Get_Validation_On_Search();");
        btnAccept.Attributes.Add("onclick", "javascript:return Get_SelectedTransactionID(1);");
        btnReject.Attributes.Add("onclick", "javascript:return Get_SelectedTransactionID(2);");
    }

    //private void GetRequest_By_List()
    //{

    //  CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
    //    sqlcon.Open();

    //    SqlCommand sqlcmd = new SqlCommand();
    //    sqlcmd.Connection = sqlcon;
    //    sqlcmd.CommandType = CommandType.StoredProcedure;
    //    sqlcmd.CommandText = "Get_Employee_Data";
    //    SqlDataAdapter sqlda = new SqlDataAdapter();

    //    sqlda.SelectCommand = sqlcmd;
    //    DataTable dt = new DataTable();
    //    sqlda.Fill(dt);
    //    sqlcon.Close();

    //    ddlRequestBy.DataTextField = "Employee_Name";
    //    ddlRequestBy.DataValueField = "Emp_id";
    //    ddlRequestBy.DataSource = dt;
    //    ddlRequestBy.DataBind();

    //    ddlRequestBy.Items.Insert(0, "-Select-");
    //    ddlRequestBy.SelectedIndex = 0;

    //}

    private void Get_UserList()
    {
        try
        {

            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_Employee_Data";

            SqlParameter UserName = new SqlParameter();
            UserName.SqlDbType = SqlDbType.VarChar;
            UserName.Value = txtUserName.Text.Trim();
            UserName.ParameterName = "@UserName";
            sqlCom.Parameters.Add(UserName);


            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlcon.Close();

            ddlRequestBy.DataTextField = "Employee_Name";
            ddlRequestBy.DataValueField = "Emp_id";

            ddlRequestBy.DataSource = dt;
            ddlRequestBy.DataBind();

            ddlRequestBy.Items.Insert(0, "--Select--");
            ddlRequestBy.SelectedIndex = 0;

            ddlRequestBy.Focus();
            
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }

    //private void GetAuthorize_By_List()
    //{

    //  CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
    //    sqlcon.Open();

    //    SqlCommand sqlcmd = new SqlCommand();
    //    sqlcmd.Connection = sqlcon;
    //    sqlcmd.CommandType = CommandType.StoredProcedure;
    //    sqlcmd.CommandText = "Get_Employee_Data";
    //    SqlDataAdapter sqlda = new SqlDataAdapter();

    //    sqlda.SelectCommand = sqlcmd;
    //    DataTable dt = new DataTable();
    //    sqlda.Fill(dt);
    //    sqlcon.Close();

    //    ddlAuthorizeBy.DataTextField = "Employee_Name";
    //    ddlAuthorizeBy.DataValueField = "Emp_id";
    //    ddlAuthorizeBy.DataSource = dt;
    //    ddlAuthorizeBy.DataBind();

    //    ddlAuthorizeBy.Items.Insert(0, "-Select-");
    //    ddlAuthorizeBy.SelectedIndex = 0;

    //}

    protected void btnSearch_Click(object sender, EventArgs e)
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_All_Data_For_Authorization";
        sqlcmd.CommandTimeout = 0;

        SqlParameter Request_FromDate = new SqlParameter();
        Request_FromDate.SqlDbType = SqlDbType.VarChar;
        Request_FromDate.Value = txtRequestFrom.Text.Trim();
        Request_FromDate.ParameterName = "@Request_FromDate";
        sqlcmd.Parameters.Add(Request_FromDate);

        SqlParameter Request_ToDate = new SqlParameter();
        Request_ToDate.SqlDbType = SqlDbType.VarChar;
        Request_ToDate.Value = txtRequestTo.Text.Trim();
        Request_ToDate.ParameterName = "@Request_ToDate";
        sqlcmd.Parameters.Add(Request_ToDate);

        string strRequestBy = "";

        if (ddlRequestBy.SelectedIndex != 0)
        {
            strRequestBy=ddlRequestBy.SelectedValue.ToString();
        }

        SqlParameter Request_By = new SqlParameter();
        Request_By.SqlDbType = SqlDbType.VarChar;
        Request_By.Value = strRequestBy.Trim();
        Request_By.ParameterName = "@Request_By";
        sqlcmd.Parameters.Add(Request_By);

        //string strAuthorize = "";

        //if (ddlRequestBy.SelectedIndex != 0)
        //{
        //    strAuthorize = ddlAuthorizeBy.SelectedValue.ToString();
        //}
        
        //SqlParameter Authorize_By = new SqlParameter();
        //Authorize_By.SqlDbType = SqlDbType.VarChar;
        //Authorize_By.Value = strAuthorize.Trim();
        //Authorize_By.ParameterName = "@Authorize_By";
        //sqlcmd.Parameters.Add(Authorize_By);

        SqlParameter intStatus = new SqlParameter();
        intStatus.SqlDbType = SqlDbType.Int;
        intStatus.Value = ddlStatus.SelectedItem.Value;
        intStatus.ParameterName = "@intStatus";
        sqlcmd.Parameters.Add(intStatus);


        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            grvFTP_RequestedData.DataSource = dt;
            grvFTP_RequestedData.DataBind();
        }
        else
        {
            grvFTP_RequestedData.DataSource = null;
            grvFTP_RequestedData.DataBind();
            lblMessage.Text = "Record Not Found"; 
        }
 

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtRequestFrom.Text="";
        txtRequestTo.Text="";
        ddlRequestBy.SelectedIndex=0;
        //ddlAuthorizeBy.SelectedIndex=0;
        ddlStatus.SelectedIndex = 0;
    }
    protected void btnAccept_Click(object sender, EventArgs e)
    {
        for (int i = 0; i <= grvFTP_RequestedData.Rows.Count - 1; i++)
        {

            string sRequestID = "";

            CheckBox chkSelect = (CheckBox)grvFTP_RequestedData.Rows[i].FindControl("chkSelect");
            TextBox txtUploadNos = (TextBox)grvFTP_RequestedData.Rows[i].FindControl("txtUploadNos");
            TextBox txtExpireDate = (TextBox)grvFTP_RequestedData.Rows[i].FindControl("txtExpireDate");


            if (chkSelect.Checked == true)
            {
                if (txtUploadNos.Text != "" || txtExpireDate.Text != "")
                {
                    sRequestID = grvFTP_RequestedData.Rows[i].Cells[1].Text.Trim();
                    Update_File_Approved_RequestData(sRequestID, txtUploadNos.Text.Trim(), txtExpireDate.Text.Trim(), 1);
                }
                else
                {
                    lblMessage.Text = "Please Enter UploadNos OR Expire Date";
                    //lblMessage.CssClass = "ErrorMessage";
                }

            }
            
           
        }

    }

    private void Update_File_Approved_RequestData(string ReqID,string UploadFile,string ExpireDate,int status)
    {
        try
        {

      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Insert_FTP_FileRequest_Auth";
        sqlcmd.CommandTimeout = 0;

        SqlParameter RequestID = new SqlParameter();
        RequestID.SqlDbType = SqlDbType.VarChar;
        RequestID.Value = ReqID;
        RequestID.ParameterName = "@RequestID";
        sqlcmd.Parameters.Add(RequestID);

        SqlParameter Status = new SqlParameter();
        Status.SqlDbType = SqlDbType.VarChar;
        Status.Value = status;
        Status.ParameterName = "@Status";
        sqlcmd.Parameters.Add(Status);

        SqlParameter Authorize_UploadNos = new SqlParameter();
        Authorize_UploadNos.SqlDbType = SqlDbType.VarChar;
        Authorize_UploadNos.Value = UploadFile;
        Authorize_UploadNos.ParameterName = "@Authorize_UploadNos";
        sqlcmd.Parameters.Add(Authorize_UploadNos);

        SqlParameter Expire_Date = new SqlParameter();
        Expire_Date.SqlDbType = SqlDbType.VarChar;
        Expire_Date.Value = ExpireDate;
        Expire_Date.ParameterName = "@Expire_Date";
        sqlcmd.Parameters.Add(Expire_Date);

        SqlParameter UserID = new SqlParameter();
        UserID.SqlDbType = SqlDbType.VarChar;
        UserID.Value = Session["UserID"].ToString();
        UserID.ParameterName = "@UserID";
        sqlcmd.Parameters.Add(UserID);


        int RowsEffeted = sqlcmd.ExecuteNonQuery();

            if (RowsEffeted > 0)
            {
                lblMessage.Text = "Record Successfully Updated!";
                //lblMessage.CssClass = "UpdateMessage";
                               
            }
             
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";

        }

    }
    
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx",true);  
    }
    protected void btnReject_Click(object sender, EventArgs e)
    {
        for (int i = 0; i <= grvFTP_RequestedData.Rows.Count - 1; i++)
        {

            string sRequestID = "";

            CheckBox chkSelect = (CheckBox)grvFTP_RequestedData.Rows[i].FindControl("chkSelect");
            TextBox txtUploadNos = (TextBox)grvFTP_RequestedData.Rows[i].FindControl("txtUploadNos");
            TextBox txtExpireDate = (TextBox)grvFTP_RequestedData.Rows[i].FindControl("txtExpireDate");


            if (chkSelect.Checked == true)
            {
                if (txtUploadNos.Text != "" || txtExpireDate.Text != "")
                {
                    sRequestID = grvFTP_RequestedData.Rows[i].Cells[1].Text.Trim();
                    Update_File_Approved_RequestData(sRequestID, txtUploadNos.Text.Trim(), txtExpireDate.Text.Trim(), 2);
                }
                else
                {
                    lblMessage.Text = "Please Enter UploadNos OR Expire Date";
                    //lblMessage.CssClass = "ErrorMessage";
                }

            }


        }
    }
    protected void grvFTP_RequestedData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if(e.Row.RowType==DataControlRowType.DataRow)
        {
            Image ImgExpireDate = (Image)e.Row.FindControl("ImgExpireDate");
            TextBox txtExpireDate = (TextBox)e.Row.FindControl("txtExpireDate");
            CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");

            ImgExpireDate.Attributes.Add("onclick", "javascript:popUpCalendar(this,"+txtExpireDate.ClientID+",'dd/mm/yyyy',0,0);");
            chkSelect.Attributes.Add("onclick", "javascript:checkSelected('" + chkSelect.ClientID + "');");
         
        }

    }
    protected void txtUserName_TextChanged(object sender, EventArgs e)
    {
        Get_UserList();
    }
}



