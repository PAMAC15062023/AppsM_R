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

public partial class Admin_QMS_TicketStatus : System.Web.UI.Page
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;
    string filename_Attachment;

    protected void Page_Init(object sender, EventArgs e)
    {
       ViewStateUserKey = Session.SessionID;

        if (Session.Count == 0)
        {
            Session.Abandon();
            Response.Redirect("~/InvalidRequest.aspx");
        }
        Session.Timeout = 240;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
        sqlcon = new SqlConnection(objConn.AppConnectionString);

        if (!IsPostBack)
        {
            if (Request.QueryString["Tk"] != null)
            {
                Get_HeaderDetails(Request.QueryString["Tk"].ToString().Trim());
                Register_Controls();
            }
        }
    }

    private void Clear_Controls()
    {
        txtUpdateRemark.Text = "";
        ddlAssignedTo.SelectedIndex = 0;
        ddlTicketStatus.SelectedIndex = 0;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/QMS/TicketAssignment.aspx", true);
    }

    private void Register_Controls()
    {
        btnSave.Attributes.Add("onclick", "javascript:return Validate_UpdateStatus();");
    }

    private void Get_HeaderDetails(string pTicketNo)
    {
        Get_SupportEngineerList();
        lblTicketNo.Text = pTicketNo;
        Get_TicketStatusInfo(lblTicketNo.Text.Trim());
    }

    private void Get_SupportEngineerList()
    {
        try
        {
            sqlcon.Open();

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_QMS_User_2";
            sqlCom.CommandTimeout = 0;

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlcon.Close();

            ddlAssignedTo.DataTextField = "Fullname";
            ddlAssignedTo.DataValueField = "Emp_Code";
            ddlAssignedTo.DataSource = dt;
            ddlAssignedTo.DataBind();

            ddlAssignedTo.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlAssignedTo.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    private void AssignHeaderValues(DataTable dt)
    {
        lblTicketRaiseDate.Text = dt.Rows[0]["RequestDate"].ToString();
        lblBranch.Text = dt.Rows[0]["CentreName"].ToString();
        lblDepartment.Text = dt.Rows[0]["Department"].ToString();
        lblRemark.Text = dt.Rows[0]["Remark"].ToString();
        lblUserName.Text = dt.Rows[0]["UserName"].ToString();
        ddlTicketStatus.SelectedValue = dt.Rows[0]["TicketStatus"].ToString();
        lblTicketStatus.Text = dt.Rows[0]["TicketStatus"].ToString().Trim();
        HdnClusterId.Value = dt.Rows[0]["Cluster_id"].ToString().Trim();

        if (lblTicketStatus.Text.Trim() == "Close")
        {
            btnSave.Visible = false;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Insert_Update_TicketStatus(lblTicketNo.Text.Trim());
        Get_HeaderDetails(Request.QueryString["Tk"].ToString().Trim());
        Clear_Controls();
    }

    private void Get_TicketStatusInfo(string pTicketNo)
    {
        try
        {
            sqlcon.Open();

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_TicketStatusInfo_NEW";
            sqlCom.CommandTimeout = 0;

            SqlParameter TicketNo = new SqlParameter();
            TicketNo.SqlDbType = SqlDbType.VarChar;
            TicketNo.Value = pTicketNo.Trim();
            TicketNo.ParameterName = "@TicketNo";
            sqlCom.Parameters.Add(TicketNo);

            //SqlParameter ClusterID = new SqlParameter();
            //ClusterID.SqlDbType = SqlDbType.VarChar;
            //ClusterID.Value = Session["ClusterID"].ToString();
            //ClusterID.ParameterName = "@ClusterID";
            //sqlCom.Parameters.Add(ClusterID);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataSet ds = new DataSet();
            sqlDA.Fill(ds);

            sqlcon.Close();

         
            AssignHeaderValues(ds.Tables[0]);

            if (ds.Tables.Count == 2)
            {
                DataList1.DataSource = ds.Tables[1];
                DataList1.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    private void Insert_Update_TicketStatus(string pTicketNo)
    {
        try
        {
            sqlcon.Open();

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Insert_Update_TicketStatus12_New";
            sqlCom.CommandTimeout = 0;

            SqlParameter BranchID = new SqlParameter();
            BranchID.SqlDbType = SqlDbType.Int;
            BranchID.Value = (Session["CentreID"]).ToString(); //Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchID.ParameterName = "@BranchID";
            sqlCom.Parameters.Add(BranchID);

            SqlParameter TicketNo = new SqlParameter();
            TicketNo.SqlDbType = SqlDbType.VarChar;
            TicketNo.Value = lblTicketNo.Text.Trim();
            TicketNo.ParameterName = "@TicketNo";
            sqlCom.Parameters.Add(TicketNo);

            SqlParameter AssignedBy = new SqlParameter();
            AssignedBy.SqlDbType = SqlDbType.VarChar;
            AssignedBy.Value = (Session["UserId"]).ToString(); //Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);
            AssignedBy.ParameterName = "@AssignedBy";
            sqlCom.Parameters.Add(AssignedBy);

            SqlParameter AssignedTo = new SqlParameter();
            AssignedTo.SqlDbType = SqlDbType.VarChar;
            AssignedTo.Value = ddlAssignedTo.SelectedValue.ToString();
            AssignedTo.ParameterName = "@AssignedTo";
            sqlCom.Parameters.Add(AssignedTo);

            SqlParameter TicketStatus = new SqlParameter();
            TicketStatus.SqlDbType = SqlDbType.VarChar;
            TicketStatus.Value = ddlTicketStatus.SelectedItem.ToString();
            TicketStatus.ParameterName = "@TicketStatus";
            sqlCom.Parameters.Add(TicketStatus);

            SqlParameter UpdateStatus = new SqlParameter();
            UpdateStatus.SqlDbType = SqlDbType.VarChar;
            UpdateStatus.Value = txtUpdateRemark.Text.Trim();
            UpdateStatus.ParameterName = "@UpdateStatus";
            sqlCom.Parameters.Add(UpdateStatus);


            SqlParameter FileUpload = new SqlParameter();
            FileUpload.SqlDbType = SqlDbType.VarChar;
            FileUpload.Value = UploadAttachment_OnServer();
            FileUpload.ParameterName = "@AttachmentPath1";
            sqlCom.Parameters.Add(FileUpload);




            SqlParameter VarResult = new SqlParameter();
            VarResult.SqlDbType = SqlDbType.VarChar;
            VarResult.Value = lblTicketNo.Text.Trim();
            VarResult.ParameterName = "@VarResult";
            VarResult.Size = 200;
            VarResult.Direction = ParameterDirection.Output;
            sqlCom.Parameters.Add(VarResult);

            SqlParameter ClusterID = new SqlParameter();
            ClusterID.SqlDbType = SqlDbType.VarChar;
            ClusterID.Value = HdnClusterId.Value;
            ClusterID.ParameterName = "@ClusterID";
            sqlCom.Parameters.Add(ClusterID);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            sqlCom.ExecuteNonQuery();
            string RowEffected = Convert.ToString(sqlCom.Parameters["@VarResult"].Value);

            sqlcon.Close();

            if (RowEffected != "")
            {
                lblMessage.Text = RowEffected;
                lblTicketNo.Text = RowEffected;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    
    private string UploadAttachment_OnServer()
    {
        try
        {
            string FileSavePath = "";
            if (FileUpload1.FileName != "")
            {
                string strPath = Server.MapPath("UploadFile/");

                strPath = strPath.Trim();
                filename_Attachment = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss")) + "-" + Convert.ToString(FileUpload1.FileName.Trim());
                filename_Attachment = filename_Attachment.Replace(" ", "_");
                FileSavePath = strPath + filename_Attachment;


                FileUpload1.SaveAs(FileSavePath);
            }
            return FileSavePath;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            return "";
        }
    }
    
}
