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
using System.IO;


public partial class QMS_QMS_QMSAssignedTo : System.Web.UI.Page
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;

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
            txtTicketNo.Text = Request.QueryString["TK"];

            Get_BranchId();
            Get_ProblemType();
            Get_AssignedBy();
        }
    }

    private void Get_BranchId()
    {
        try
        {
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_AllBranchList";
            sqlcmd.CommandTimeout = 0;

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                ddlBranchList.DataTextField = "centre_name";
                ddlBranchList.DataValueField = "centre_id";
                ddlBranchList.DataSource = dt;
                ddlBranchList.DataBind();

                ddlBranchList.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void Get_ProblemType()
    {
        sqlcon.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlcon;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Get_QMS_Problem_Details_1";
        cmd.CommandTimeout = 0;

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataTable dt = new DataTable();
        da.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlProblemTypeList.DataSource = dt;
            ddlProblemTypeList.DataTextField = "QueryName";
            ddlProblemTypeList.DataValueField = "Qms_id";
            ddlProblemTypeList.DataBind();

            ddlProblemTypeList.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }

    protected void Get_AssignedBy()
    {
        sqlcon.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlcon;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Get_QMS_User_1";
        cmd.CommandTimeout = 0;

        SqlParameter UserID = new SqlParameter();
        UserID.SqlDbType = SqlDbType.VarChar;
        UserID.Value = (Session["UserId"]).ToString();    //Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);     
        UserID.ParameterName = "@UserID";
        cmd.Parameters.Add(UserID);


        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataTable dt = new DataTable();
        da.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlAssignedBy.DataSource = dt;
            ddlAssignedBy.DataTextField = "Fullname";
            ddlAssignedBy.DataValueField = "Emp_Code";
            ddlAssignedBy.DataBind();




            ddlAssignedTo.DataSource = dt;
            ddlAssignedTo.DataTextField = "Fullname";
            ddlAssignedTo.DataValueField = "Emp_Code";
            ddlAssignedTo.DataBind();


        }
        else
        {
            ddlAssignedBy.Items.Insert(0, new ListItem("--All--", "0"));
            ddlAssignedTo.Items.Insert(0, new ListItem("--All--", "0"));
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtRequestFromDate.Text.Trim() == "" || txtRequestToDate.Text.Trim() == "")
        {
            lblMessage.Text = "Please Enter From Date & To Date!!!";
        }
        else
        {
            grv_TicketList.Visible = true;
            Get_ReqeustedTicket_For_Assignment(false);
        }
    }

    private void Get_ReqeustedTicket_For_Assignment(Boolean isExport)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        sqlcon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlcon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "Get_QMS_ReqeustedTicket_For_Assignment_NEW1234";
        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;

        int intBranchID = 0;
        if (ddlBranchList.SelectedIndex != 0)
        {
            intBranchID = Convert.ToInt32(ddlBranchList.SelectedItem.Value);
        }

        SqlParameter BranchID = new SqlParameter();
        BranchID.SqlDbType = SqlDbType.Int;
        BranchID.Value = intBranchID; //Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
        BranchID.ParameterName = "@BranchID";
        sqlCom.Parameters.Add(BranchID);

        SqlParameter TicketNo = new SqlParameter();
        TicketNo.SqlDbType = SqlDbType.VarChar;
        TicketNo.Value = txtTicketNo.Text.Trim();
        TicketNo.ParameterName = "@TicketNo";
        sqlCom.Parameters.Add(TicketNo);

        //SqlParameter Department = new SqlParameter();
        //Department.SqlDbType = SqlDbType.VarChar;
        //Department.Value = txtDepartment.Text.Trim();
        //Department.ParameterName = "@Department";
        //sqlCom.Parameters.Add(Department);

        int intPromblemTypeID = 0;
        if (ddlProblemTypeList.SelectedIndex != 0)
        {
            intPromblemTypeID = Convert.ToInt32(ddlProblemTypeList.SelectedItem.Value);
        }

        SqlParameter PromblemTypeID = new SqlParameter();
        PromblemTypeID.SqlDbType = SqlDbType.Int;
        PromblemTypeID.Value = intPromblemTypeID;
        PromblemTypeID.ParameterName = "@Problem_Type_ID";
        sqlCom.Parameters.Add(PromblemTypeID);

        SqlParameter FromDate = new SqlParameter();
        FromDate.SqlDbType = SqlDbType.VarChar;
        FromDate.Value = txtRequestFromDate.Text.Trim();
        FromDate.ParameterName = "@FromDate";
        sqlCom.Parameters.Add(FromDate);

        SqlParameter ToDate = new SqlParameter();
        ToDate.SqlDbType = SqlDbType.VarChar;
        ToDate.Value = txtRequestToDate.Text.Trim();
        ToDate.ParameterName = "@ToDate";
        sqlCom.Parameters.Add(ToDate);

        SqlParameter TicketStatus = new SqlParameter();
        TicketStatus.SqlDbType = SqlDbType.VarChar;
        TicketStatus.Value = ddlTicketStatus.SelectedItem.Value.ToString();
        TicketStatus.ParameterName = "@TicketStatus";
        sqlCom.Parameters.Add(TicketStatus);

        //SqlParameter RequestBy = new SqlParameter();
        //RequestBy.SqlDbType = SqlDbType.VarChar;
        //RequestBy.Value = txtRequestBy.Text.Trim();
        //RequestBy.ParameterName = "@RequestBy";
        //sqlCom.Parameters.Add(RequestBy);

        string strAssignedBy;

        strAssignedBy = ddlAssignedBy.SelectedValue.ToString();


        SqlParameter AssignedBY = new SqlParameter();
        AssignedBY.SqlDbType = SqlDbType.VarChar;
        AssignedBY.Value = strAssignedBy;
        AssignedBY.ParameterName = "@AssignedBY";
        sqlCom.Parameters.Add(AssignedBY);

        string strAssignedTo;

        strAssignedTo = ddlAssignedTo.SelectedValue.ToString();



        SqlParameter AssignedTo = new SqlParameter();
        AssignedTo.SqlDbType = SqlDbType.VarChar;
        AssignedTo.Value = strAssignedTo;
        AssignedTo.ParameterName = "@AssignedTo";
        sqlCom.Parameters.Add(AssignedTo);

        DataTable dt = new DataTable();
        sqlDA.Fill(dt);

        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            if (isExport == true)
            {
                btnExport.Visible = true;
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                btnExport.Visible = true;
                grv_TicketList.DataSource = dt;
                grv_TicketList.DataBind();
            }
            lblMessage.Text = "Total Records Founds: " + dt.Rows.Count;
        }
        else
        {
            if (isExport == true)
            {
                btnExport.Visible = false;
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                btnExport.Visible = false;
                grv_TicketList.DataSource = null;
                grv_TicketList.DataBind();
            }
            lblMessage.Text = "No Records Found...!!!";
        }
    }

    protected void lnkTicketNo_Click(object sender, EventArgs e)
    {
        string TicketNo = ((System.Web.UI.WebControls.LinkButton)(sender)).Text.ToString();
        if (TicketNo != "")
        {
            Response.Redirect("TicketStatus.aspx?TK=" + TicketNo, true);
         }
    }

    private void DownloadFile(string fname, bool forceDownload)
    {
        try
        {
            string path = fname;
            string name = Path.GetFileName(path);
            string ext = Path.GetExtension(path);
            string type = "";
            // set known types based on file extension  
            if (ext != null)
            {
                switch (ext.ToLower())
                {
                    case ".txt":
                        type = "text/plain";
                        break;
                    case ".doc":
                    case ".rtf":
                        type = "Application/msword";
                        break;
                    case ".zip":
                        type = "application/zip";
                        break;
                    case ".xls":
                        type = "application/vnd.ms-excel";
                        break;
                }
            }
            if (forceDownload)

                Response.ClearHeaders();
            Response.ClearContent();
            Response.Clear();

            {
                Response.AppendHeader("content-disposition", "attachment; filename=" + name);
            }
            if (type != "")

                Response.ContentType = type;
            Response.WriteFile(path);
            Response.End();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void lnkDownloadFile_Click(object sender, EventArgs e)
    {
        string DownloadPath = ((System.Web.UI.WebControls.LinkButton)(sender)).CommandArgument.ToString();
        if (DownloadPath != "")
        {
            DownloadFile(DownloadPath, true);
        }
        else
        {
            lblMessage.Text = "No Attached Document Found...!!!";
        }
    }

    protected void grv_TicketList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkDownloadFile = (LinkButton)e.Row.FindControl("lnkDownloadFile");
            if (lnkDownloadFile.CommandArgument == "")
            {
                lnkDownloadFile.Enabled = false;
                lnkDownloadFile.ToolTip = "No Attachment Found...!!!";
            }
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    { }

    private void Generate_ExcelFile()
    {
        String attachment = "attachment; filename=TicketAssignmentReport.xls";

        Response.ClearHeaders();
        Response.ClearContent();
        Response.Clear();

        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new System.IO.StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Table tblSpace = new Table();
        TableRow tblRow = new TableRow();
        TableCell tblCell = new TableCell();
        tblCell.Text = " ";

        TableRow tblRow1 = new TableRow();
        TableCell tblCell1 = new TableCell();
        tblCell1.ColumnSpan = 20;// 10;
        tblCell1.Text = "<b> <span style='background-color:Gray'> <font size='4'>PAMAC FINSERVE PVT. LTD.</font></span></b> <br/>" +
                        "<b><font size='2' color='blue'>Ticket Assignment Report.</font></b> <br/>";
        tblCell1.CssClass = "SuccessMessage";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(htw);

        Table tbl = new Table();
        grv_TicketList.EnableViewState = false;
        grv_TicketList.GridLines = GridLines.Both;
        //tbExport.RenderControl(htw);
        //grv_TicketList.RenderControl(htw);
        GridView1.RenderControl(htw);
        Response.Write(sw.ToString());

        Response.End();
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        Get_ReqeustedTicket_For_Assignment(true);
        Generate_ExcelFile();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/QMS/QMS/QMSRequest.aspx");
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        txtTicketNo.Text = "";
        //txtDepartment.Text = "";
        //txtRequestBy.Text = "";
        ddlBranchList.SelectedIndex = 0;
        ddlProblemTypeList.SelectedIndex = 0;
        ddlAssignedBy.SelectedIndex = 0;
        ddlAssignedTo.SelectedIndex = 0;
        ddlTicketStatus.SelectedIndex = 0;
        txtRequestFromDate.Text = "";
        txtRequestToDate.Text = "";
        grv_TicketList.Visible = false;
    }

    protected void grv_TicketList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
