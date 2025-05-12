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
public partial class Software_Requirement_Software_DeveloperStatus : System.Web.UI.Page
{


    CCommon objConn = new CCommon(); SqlConnection sqlcon;
    string filename_Attachment;
    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);



        if (!IsPostBack)
        {
            //ddlcentre.Items.Insert(0, new ListItem("--ALL--", "ALL"));
            //ddlsubcentre.Items.Insert(0, new ListItem("--ALL--", "ALL"));
            // ddlassignedto.Items.Insert(0, new ListItem("--ALL--", "ALL"));
            //Get_ClusterList();
            //Get_developerlist();

            //Search();

        }

        //Validation();
        //Panel1.Visible = true;
        Panel2.Visible = false;
    }


    //private void Get_ClusterList()
    //{
    //    try
    //    {

    //        sqlcon.Open();

    //        SqlCommand cmd2 = new SqlCommand();
    //        cmd2.Connection = sqlcon;
    //        cmd2.CommandType = CommandType.StoredProcedure;
    //        cmd2.CommandText = "Sp_ClusterList1";
    //        cmd2.CommandTimeout = 0;



    //        //SqlParameter ClusterId = new SqlParameter();
    //        //ClusterId.SqlDbType = SqlDbType.VarChar;
    //        //ClusterId.SqlValue = Session["ClusterId"].ToString();
    //        //ClusterId.ParameterName = "@ClusterId";
    //        //cmd2.Parameters.Add(ClusterId);


    //        SqlDataAdapter sqlda1 = new SqlDataAdapter();
    //        sqlda1.SelectCommand = cmd2;

    //        DataTable dt1 = new DataTable();
    //        sqlda1.Fill(dt1);

    //        sqlcon.Close();

    //        if (dt1.Rows.Count > 0)
    //        {
    //            ddlcluster.DataTextField = "Cluster_Name";
    //            ddlcluster.DataValueField = "Cluster_id";

    //            ddlcluster.DataSource = dt1;
    //            ddlcluster.DataBind();

    //            ddlcluster.Items.Insert(0, new ListItem("--ALL--", "ALL"));
    //            ddlcluster.SelectedIndex = 0;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblmsg.Text = ex.Message;
    //    }
    //}

    //protected void ddlcluster_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    Get_CentreList();

    //}

    //private void Get_developerlist()
    //{
    //    try
    //    {

    //        sqlcon.Open();

    //        SqlCommand cmd2 = new SqlCommand();
    //        cmd2.Connection = sqlcon;
    //        cmd2.CommandType = CommandType.StoredProcedure;
    //        cmd2.CommandText = "get_developer_list";
    //        cmd2.CommandTimeout = 0;

    //        SqlDataAdapter sqlda1 = new SqlDataAdapter();
    //        sqlda1.SelectCommand = cmd2;

    //        DataTable dt1 = new DataTable();
    //        sqlda1.Fill(dt1);

    //        sqlcon.Close();

    //        if (dt1.Rows.Count > 0)
    //        {
    //            ddldevlopername.DataTextField = "fullname";
    //            ddldevlopername.DataValueField = "emp_code";

    //            ddldevlopername.DataSource = dt1;
    //            ddldevlopername.DataBind();

    //            ddldevlopername.Items.Insert(0, new ListItem("--ALL--", "ALL"));
    //            ddldevlopername.SelectedIndex = 0;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblmsg.Text = ex.Message;
    //    }
    //}

    //protected void BtnActionSave_Click(object sender, EventArgs e)
    //{

    //    try
    //    {

    //        sqlcon.Open();

    //        SqlCommand cmd = new SqlCommand();
    //        cmd.Connection = sqlcon;
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.CommandText = "Sp_Developerstatus";
    //        cmd.CommandTimeout = 0;

    //        SqlParameter Serial_No = new SqlParameter();
    //        Serial_No.SqlDbType = SqlDbType.Int;
    //        Serial_No.Value = HDNUPDATE.Value;
    //        Serial_No.ParameterName = "@Serial_No";
    //        cmd.Parameters.Add(Serial_No);


    //        SqlParameter Rootcause = new SqlParameter();
    //        Rootcause.SqlDbType = SqlDbType.VarChar;
    //        Rootcause.Value = txtrootcause.Text.Trim();
    //        Rootcause.ParameterName = "@RootCause";
    //        cmd.Parameters.Add(Rootcause);


    //        SqlParameter Developerremark = new SqlParameter();
    //        Developerremark.SqlDbType = SqlDbType.VarChar;
    //        Developerremark.Value = txtDeveloperremark.Text.Trim();
    //        Developerremark.ParameterName = "@problemsolution";
    //        cmd.Parameters.Add(Developerremark);


    //        SqlParameter overallremark = new SqlParameter();
    //        overallremark.SqlDbType = SqlDbType.VarChar;
    //        overallremark.Value = txtDeveloperremark.Text.Trim();
    //        overallremark.ParameterName = "@overallremark";
    //        cmd.Parameters.Add(overallremark);

    //        SqlParameter FileUpload1 = new SqlParameter();
    //        FileUpload1.SqlDbType = SqlDbType.VarChar;
    //        FileUpload1.Value = UploadAttachment_OnServer1();
    //        FileUpload1.ParameterName = "@Attachment1";
    //        cmd.Parameters.Add(FileUpload1);

    //        int r = cmd.ExecuteNonQuery();

    //        sqlcon.Close();

    //        if (r > 0)
    //        {
    //            lblmsg.Text = "Data Submitted Successfully";
    //        }
    //    }
    //    catch (Exception Ex)
    //    {
    //        lblmsg.Text = Ex.Message;
    //    }

    //    //Search();
    //}

    //private void Get_SubCentreList()
    //{
    //    try
    //    {
    //        sqlcon.Open();

    //        SqlCommand cmd4 = new SqlCommand();
    //        cmd4.Connection = sqlcon;
    //        cmd4.CommandType = CommandType.StoredProcedure;
    //        cmd4.CommandText = "Sp_SubCentreList1";
    //        cmd4.CommandTimeout = 0;

    //        SqlParameter CentreId = new SqlParameter();
    //        CentreId.SqlDbType = SqlDbType.VarChar;
    //        CentreId.SqlValue = ddlcentre.SelectedValue.ToString();
    //        CentreId.ParameterName = "@CentreId";
    //        cmd4.Parameters.Add(CentreId);

    //        SqlDataAdapter sqlda1 = new SqlDataAdapter();
    //        sqlda1.SelectCommand = cmd4;

    //        DataTable dt1 = new DataTable();
    //        sqlda1.Fill(dt1);

    //        sqlcon.Close();

    //        if (dt1.Rows.Count > 0)
    //        {
    //            ddlsubcentre.DataTextField = "SubCentreName";
    //            ddlsubcentre.DataValueField = "SubCentreid";

    //            ddlsubcentre.DataSource = dt1;
    //            ddlsubcentre.DataBind();

    //            ddlsubcentre.Items.Insert(0, new ListItem("--ALL--", "ALL"));
    //            ddlsubcentre.SelectedIndex = 0;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblmsg.Text = ex.Message;

    //    }
    //}

    //private void Get_CentreList()
    //{
    //    try
    //    {

    //        sqlcon.Open();

    //        SqlCommand cmd2 = new SqlCommand();
    //        cmd2.Connection = sqlcon;
    //        cmd2.CommandType = CommandType.StoredProcedure;
    //        cmd2.CommandText = "Sp_CentreList1";
    //        cmd2.CommandTimeout = 0;

    //        SqlParameter ClusterId = new SqlParameter();
    //        ClusterId.SqlDbType = SqlDbType.VarChar;
    //        ClusterId.SqlValue = ddlcluster.SelectedValue.ToString();
    //        ClusterId.ParameterName = "@Cluster_Id";
    //        cmd2.Parameters.Add(ClusterId);

    //        SqlDataAdapter sqlda1 = new SqlDataAdapter();
    //        sqlda1.SelectCommand = cmd2;

    //        DataTable dt1 = new DataTable();
    //        sqlda1.Fill(dt1);

    //        sqlcon.Close();

    //        if (dt1.Rows.Count > 0)
    //        {
    //            ddlcentre.DataTextField = "Centre_Name";
    //            ddlcentre.DataValueField = "Centre_id";

    //            ddlcentre.DataSource = dt1;
    //            ddlcentre.DataBind();

    //            ddlcentre.Items.Insert(0, new ListItem("--ALL--", "ALL"));
    //            ddlcentre.SelectedIndex = 0;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblmsg.Text = ex.Message;
    //    }
    //}

    //protected void ddlcentre_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    Get_SubCentreList();
    //}

    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);

        string strMM = strInDate.Substring(3, 2);

        string strYYYY = strInDate.Substring(6, 4);

        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY;

        //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;

        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);

        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy");

        return strOutDate;
    }

    
    protected void GrdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;

        for (int i = 0; i <= GrdView.Rows.Count - 1; i++)
        {
            String strUID = "";
            strUID = e.CommandArgument.ToString();

            lblTikectNo.Text = "Ticket No:- " + strUID;

            HdnUID.Value = GrdView.Rows[i].Cells[1].Text.Trim();

            if (e.CommandName == "Edit1")
            {
                if (HdnUID.Value == strUID)
                {
                    HDNUPDATE.Value = GrdView.Rows[i].Cells[1].Text.Trim();
                    lblEmpCode.Text = GrdView.Rows[i].Cells[2].Text.Trim();
                    lblFrstName.Text = GrdView.Rows[i].Cells[3].Text.Trim();
                    lblLastName.Text = GrdView.Rows[i].Cells[4].Text.Trim();
                    LblCentreName.Text = GrdView.Rows[i].Cells[5].Text.Trim();
                    lblSubcentreName.Text = GrdView.Rows[i].Cells[6].Text.Trim();
                    lblreqest.Text = GrdView.Rows[i].Cells[7].Text.Trim();

                    txttechnicalproblm.Text = GrdView.Rows[i].Cells[8].Text.Trim();
                    txtlRemark.Text = GrdView.Rows[i].Cells[9].Text.Trim();

                    lblreqtype.Text = GrdView.Rows[i].Cells[11].Text.Trim();
                    Lblvertical.Text = GrdView.Rows[i].Cells[10].Text.Trim();
                    lblverticalhead.Text = GrdView.Rows[i].Cells[12].Text.Trim();
                    //lbltask1.Text = GrdView.Rows[i].Cells[13].Text.Trim();
                    //lbltask2.Text = GrdView.Rows[i].Cells[15].Text.Trim();
                    //lbltask3.Text = GrdView.Rows[i].Cells[16].Text.Trim();
                    //lbltask4.Text = GrdView.Rows[i].Cells[17].Text.Trim();
                    //lbltask5.Text = GrdView.Rows[i].Cells[14].Text.Trim();

                    lblRequestedDate.Text = GrdView.Rows[i].Cells[13].Text.Trim();
                    lblApplication.Text = GrdView.Rows[i].Cells[14].Text.Trim();
                    lblpriority.Text = GrdView.Rows[i].Cells[15].Text.Trim();
                    lblrequirement.Text = GrdView.Rows[i].Cells[16].Text.Trim();
                    lblimplementedat.Text = GrdView.Rows[i].Cells[17].Text.Trim();
                    //hdncluster.Value = GrdView.Rows[i].Cells[26].Text.Trim();
                    //ddloverallremark.SelectedValue = GrdView.Rows[i].Cells[27].Text.Trim();

                    lblEstimatedDevelopmentTime.Text = GrdView.Rows[i].Cells[20].Text.Trim();
                    lblActualSpentTime.Text = GrdView.Rows[i].Cells[21].Text.Trim();

                    txtrootcause.Text = GrdView.Rows[i].Cells[18].Text.Trim().Replace("&nbsp;", "");
                    txtDeveloperremark.Text = GrdView.Rows[i].Cells[19].Text.Trim();

                    BindAttachment(HdnUID.Value);

                    fillgridAnnexure(strUID);
                }
            }
        }
    }
    private void BindAttachment(string TicketNo)
    {
        try
        {
            sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SSU_BindAttachmentByTicketNo_SP";
            cmd.CommandTimeout = 0;

            SqlParameter Ticket_No = new SqlParameter();
            Ticket_No.SqlDbType = SqlDbType.VarChar;
            Ticket_No.Value = TicketNo;
            Ticket_No.ParameterName = "@TicketNo";
            cmd.Parameters.Add(Ticket_No);


            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                gvAttachment.DataSource = dt;
                gvAttachment.DataBind();
            }
            else
            {
                gvAttachment.DataSource = null;
                gvAttachment.DataBind();
            }
        }
        catch (Exception Ex)
        {
            lblmsg.Text = Ex.Message;
        }
    }
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        //ddlcentre.SelectedIndex = 0;
        //ddlsubcentre.SelectedIndex = 0;
        //txtFromDate.Text = "";
        //txtToDate.Text = "";
        //lblmsg.Text = "";

        GrdView.DataSource = null;
        GrdView.DataBind();

        //Response.Redirect("Default.aspx");
    }
    private void Search()
    {
        try
        {
            string overallremark = string.Empty;
            string msg = string.Empty;

            if (txtToDate.Text == "")
            {
                msg = msg + "Please enter To Date ";
            }
            if (txtFromDate.Text == "")
            {
                msg = msg + "Please enter From Date";
            }
           
            if (msg != "")
            {

                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
                return;
            }


            sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SSU_TicketHistory_SP";   //"SpSSUFeedback_devlpr";
            cmd.CommandTimeout = 0;

            //SqlParameter Userid = new SqlParameter();
            //Userid.SqlDbType = SqlDbType.VarChar;
            //Userid.Value = Convert.ToString((Session["UserId"]));
            //Userid.ParameterName = "@emp_id";
            //cmd.Parameters.Add(Userid);

            SqlParameter FromDate = new SqlParameter();
            FromDate.SqlDbType = SqlDbType.DateTime;
            FromDate.Value = strDate(txtFromDate.Text.Trim());
            FromDate.ParameterName = "@FromDate";
            cmd.Parameters.Add(FromDate);

            SqlParameter Todate = new SqlParameter();  
            Todate.SqlDbType = SqlDbType.DateTime;
            Todate.Value = strDate(txtToDate.Text.Trim());
            Todate.ParameterName = "@Todate";
            cmd.Parameters.Add(Todate);


            if (ddloverallremark.SelectedItem.Text.ToString() != "--ALL--")
            {
                overallremark = ddloverallremark.SelectedItem.Text.ToString();
            }

            SqlParameter status = new SqlParameter();
            status.SqlDbType = SqlDbType.VarChar;
            status.Value = overallremark;
            status.ParameterName = "@CaseStatus";
            cmd.Parameters.Add(status);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                lblmsg.Text = "";
                lblmsg.Text = "Total Count Is :" + dt.Rows.Count;

                GrdView.DataSource = dt;
                GrdView.DataBind();

            }
            else
            {
                lblmsg.Text = "";
                lblmsg.Text = "Total Count Is :" + dt.Rows.Count;

                GrdView.DataSource = null;
                GrdView.DataBind();
            }
        }
        catch (Exception Ex)
        {
            lblmsg.Text = Ex.Message;
        }
    }

    private string UploadAttachment_OnServer1()
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
            lblmsg.Text = ex.Message;
            return "";
        }
    }




    //protected void Btnsearch_Click(object sender, EventArgs e)
    //{
    //    Search();
    //}

    protected void BtnActionSave_Click1(object sender, EventArgs e)
    {
        try
        {


            sqlcon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_SSUFEEDBACK_ssustatus";
            cmd.CommandTimeout = 0;

            SqlParameter ticketno = new SqlParameter();
            ticketno.SqlDbType = SqlDbType.VarChar;
            ticketno.Value = HDNUPDATE.Value;
            ticketno.ParameterName = "@ticketno";
            cmd.Parameters.Add(ticketno);


            SqlParameter clusterid = new SqlParameter();
            clusterid.SqlDbType = SqlDbType.VarChar;
            clusterid.Value = hdncluster.Value;
            clusterid.ParameterName = "@clusterid";
            cmd.Parameters.Add(clusterid);


            //if (lblrequirement.Text = "Error")
            //{

            SqlParameter root_cause = new SqlParameter();
            root_cause.SqlDbType = SqlDbType.VarChar;
            root_cause.Value = txtrootcause.Text.Trim();
            root_cause.ParameterName = "@rootcause";
            cmd.Parameters.Add(root_cause);


            //}
            //else
            //{
            //    SqlParameter root_cause = new SqlParameter();
            //    root_cause.SqlDbType = SqlDbType.VarChar;
            //    root_cause.Value = DBNull.Value; 
            //    root_cause.ParameterName = "@rootcause";
            //    cmd.Parameters.Add(root_cause);


            //}


            SqlParameter problemsolution = new SqlParameter();
            problemsolution.SqlDbType = SqlDbType.VarChar;
            problemsolution.Value = txtDeveloperremark.Text.Trim();
            problemsolution.ParameterName = "@problemsolution";
            cmd.Parameters.Add(problemsolution);

            SqlParameter overallremark = new SqlParameter();
            overallremark.SqlDbType = SqlDbType.VarChar;
            overallremark.Value = ddloverallremark.SelectedValue;
            overallremark.ParameterName = "@Overallremark";
            cmd.Parameters.Add(overallremark);

            SqlParameter FileUpload1 = new SqlParameter();
            FileUpload1.SqlDbType = SqlDbType.VarChar;
            FileUpload1.Value = UploadAttachment_OnServer1();
            FileUpload1.ParameterName = "@developerattachment";
            cmd.Parameters.Add(FileUpload1);


            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            int r = cmd.ExecuteNonQuery();

            sqlcon.Close();

            if (r > 0)
            {
                lblmsg.Text = "Data Submitted Successfully";
            }
        }


        catch (Exception Ex)
        {
            lblmsg.Text = Ex.Message;
        }

        Search();
        clear();


    }


    private void clear()
    {
        txtDeveloperremark.Text = "";
        //Txtoverallremark.Text = "";
        txtrootcause.Text = "";




    }

    protected void fillgridAnnexure(string UID)
    {
        try
        {
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_grv_new_data ";
            cmd.CommandTimeout = 0;

            SqlParameter ticketno = new SqlParameter();
            ticketno.SqlDbType = SqlDbType.VarChar;
            ticketno.Value = UID;
            ticketno.ParameterName = "@ticketNo";
            cmd.Parameters.Add(ticketno);

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd;

            DataTable dt = new DataTable();
            sqlda1.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                Grddwld.DataSource = dt;
                Grddwld.DataBind();


            }
            else
            {
                Grddwld.DataSource = null;
                Grddwld.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
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
                    case ".csv":
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
                    case ".xlsx":
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
            lblmsg.Text = ex.Message;
        }
    }

    protected void lnkdownload_Click(object sender, EventArgs e)
    {
        string DownloadPath = ((System.Web.UI.WebControls.LinkButton)(sender)).CommandArgument.ToString();
        if (DownloadPath != "")
        {
            DownloadFile(DownloadPath, true);
        }
        else
        {
            lblmsg.Text = "No Attached Document Found...!!!";
        }
    }

    protected void lnkdownload2_Click(object sender, EventArgs e)
    {
        string DownloadPath = ((System.Web.UI.WebControls.LinkButton)(sender)).CommandArgument.ToString();
        if (DownloadPath != "")
        {
            DownloadFile(DownloadPath, true);
        }
        else
        {
            lblmsg.Text = "No Attached Document Found...!!!";
        }
    }


    protected void lnkdownload3_Click(object sender, EventArgs e)
    {
        string DownloadPath = ((System.Web.UI.WebControls.LinkButton)(sender)).CommandArgument.ToString();
        if (DownloadPath != "")
        {
            DownloadFile(DownloadPath, true);
        }
        else
        {
            lblmsg.Text = "No Attached Document Found...!!!";
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    { }




    protected void Grddwld_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkdownload = (LinkButton)e.Row.FindControl("lnkdownload");
            LinkButton lnkdownload2 = (LinkButton)e.Row.FindControl("lnkdownload2");
            LinkButton lnkdownload3 = (LinkButton)e.Row.FindControl("lnkdownload3");


            if (lnkdownload.CommandArgument == "")
            {
                lnkdownload.Enabled = false;
                lnkdownload.ToolTip = "No Attachment Found...!!!";
            }
            if (lnkdownload2.CommandArgument == "")
            {
                lnkdownload2.Enabled = false;
                lnkdownload2.ToolTip = "No Attachment Found...!!!";
            }
            if (lnkdownload3.CommandArgument == "")
            {
                lnkdownload3.Enabled = false;
                lnkdownload3.ToolTip = "No Attachment Found...!!!";
            }
        }
    }

    protected void BtnReset12_Click(object sender, EventArgs e)
    {
        txtDeveloperremark.Text = "";
        //Txtoverallremark.Text = "";

        txtrootcause.Text = "";
        //Panel1.Visible = false;
        Panel2.Visible = true;
    }

    protected void gvAttachment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;

        for (int i = 0; i <= gvAttachment.Rows.Count - 1; i++)
        {
            string Attachment_ID = "";
            Attachment_ID = e.CommandArgument.ToString();


            hdnAttachmentID.Value = gvAttachment.Rows[i].Cells[1].Text.Trim();

            if (e.CommandName == "Download1")
            {
                if (hdnAttachmentID.Value == Attachment_ID)
                {
                    string DownloadPath = GetAttachmentPath(Convert.ToInt32(Attachment_ID));
                    if (DownloadPath != "")
                    {
                        DownloadFile(DownloadPath, true);
                    }
                    else
                    {
                        lblmsg.Text = "No Attached Document Found...!!!";
                    }
                }
            }
        }
    }
    private string GetAttachmentPath(int AttachmentID)
    {
        try
        {

            string AttachmentPath = "";

            sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SSU_GetAttachmentPath_SP";
            cmd.CommandTimeout = 0;

            SqlParameter ID = new SqlParameter();
            ID.SqlDbType = SqlDbType.Int;
            ID.Value = AttachmentID;
            ID.ParameterName = "@ID";
            cmd.Parameters.Add(ID);


            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataSet ds = new DataSet();
            da.Fill(ds);

            sqlcon.Close();

            if (ds.Tables.Count > 0)
            {
                AttachmentPath = ds.Tables[0].Rows[0]["Attachment"].ToString(); 
            }

            return AttachmentPath;
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            return "";
        }
    }

    protected void Btnsearch_Click1(object sender, EventArgs e)
    {
       
        Search();
    }
}