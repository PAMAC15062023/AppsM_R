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

public partial class QMS_QMS_TicketStatus : System.Web.UI.Page
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;
    string filename_Attachment;
    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);
        if (!IsPostBack)
        {
            string ticketmno = Request.QueryString["TK"].ToString();
            Get_Ticket_Details(ticketmno);
        }

    }

    private void Get_Ticket_Details(string p)
    {

        sqlcon.Open();

        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlcon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "Get_Ticket_Details";
        sqlCom.CommandTimeout = 0;

        SqlParameter TicketNo = new SqlParameter();
        TicketNo.SqlDbType = SqlDbType.VarChar;
        TicketNo.Value = p.Trim();
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
  
        try
        {
            sqlcon.Open();

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Insert_Update_TicketStatus12_New";
            sqlCom.CommandTimeout = 0;

            //SqlParameter BranchID = new SqlParameter();
            //BranchID.SqlDbType = SqlDbType.Int;
            //BranchID.Value = (Session["CentreID"]).ToString(); //Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            //BranchID.ParameterName = "@BranchID";
            //sqlCom.Parameters.Add(BranchID);

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
            AssignedTo.Value = "P-00001";
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

            //SqlParameter ClusterID = new SqlParameter();
            //ClusterID.SqlDbType = SqlDbType.VarChar;
            //ClusterID.Value = HdnClusterId.Value;
            //ClusterID.ParameterName = "@ClusterID";
            //sqlCom.Parameters.Add(ClusterID);

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
            lblMessage.Text = "Status updated Successfully";
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/QMS/QMS/QMSAssignedTo.aspx");
    }

    private void AssignHeaderValues(DataTable dt)
    {
        lblTicketNo.Text = dt.Rows[0]["TicketNo"].ToString();
        lblTicketRaiseDate.Text = dt.Rows[0]["TicketRaiseDate"].ToString();
        //lblBranch.Text = dt.Rows[0]["CentreName"].ToString();
        //lblDepartment.Text = dt.Rows[0]["Department"].ToString();
        lblRemark.Text = dt.Rows[0]["ProblemDesc"].ToString();
        lblUserName.Text = dt.Rows[0]["TicketRaiseBy"].ToString();
        ddlTicketStatus.SelectedValue = dt.Rows[0]["TicketStatus"].ToString();
        lblTicketStatus.Text = dt.Rows[0]["TicketStatus"].ToString().Trim();
        //HdnClusterId.Value = dt.Rows[0]["Cluster_id"].ToString().Trim();

        if (lblTicketStatus.Text.Trim() == "Close")
        {
            btnSave.Visible = false;
        }
    }
}
