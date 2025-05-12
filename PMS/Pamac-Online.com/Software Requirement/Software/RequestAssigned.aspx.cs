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
using System.Net.Mail;
using System.IO;

public partial class Software_Requirement_Software_RequestAssigned : System.Web.UI.Page
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;
    //string Emailid;
    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);

        if (!IsPostBack)
        {
            ddlcentre.Items.Insert(0, new ListItem("--ALL--", "ALL"));
            ddlsubcentre.Items.Insert(0, new ListItem("--ALL--", "ALL"));
            //Get_CentreList();
            Get_developerlist();
            Get_ClusterList();
            SearchAssignedToload();
        }
        Panel2.Visible = false;
        //Validation();
        Panel1.Visible = true;

    }


    protected void ddlcluster_SelectedIndexChanged(object sender, EventArgs e)
    {

        Get_CentreList();

    }



    private void Get_ClusterList()
    {
        try
        {

            sqlcon.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = sqlcon;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "Sp_ClusterList1";
            cmd2.CommandTimeout = 0;



            //SqlParameter ClusterId = new SqlParameter();
            //ClusterId.SqlDbType = SqlDbType.VarChar;
            //ClusterId.SqlValue = Session["ClusterId"].ToString();
            //ClusterId.ParameterName = "@ClusterId";
            //cmd2.Parameters.Add(ClusterId);


            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd2;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlcluster.DataTextField = "Cluster_Name";
                ddlcluster.DataValueField = "Cluster_id";

                ddlcluster.DataSource = dt1;
                ddlcluster.DataBind();

                ddlcluster.Items.Insert(0, new ListItem("--ALL--", "ALL"));
                ddlcluster.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }

    protected void GrdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;

        for (int i = 0; i <= GrdView.Rows.Count - 1; i++)
        {
            String strUID = "";
            strUID = e.CommandArgument.ToString();

            HdnUID.Value = GrdView.Rows[i].Cells[1].Text.Trim();

            lbltickNo.Text = "Ticket No :-  " + strUID;

            if (e.CommandName == "Edit1")
            {
                if (HdnUID.Value == strUID)
                {
                    HDNUPDATE.Value = GrdView.Rows[i].Cells[1].Text.Trim();
                    lblTicketNo2.Text = strUID;
                    lblEmpCode.Text = GrdView.Rows[i].Cells[2].Text.Trim();
                    lblFrstName.Text = GrdView.Rows[i].Cells[3].Text.Trim();
                    lblLastName.Text = GrdView.Rows[i].Cells[4].Text.Trim();
                    LblCentreName.Text = GrdView.Rows[i].Cells[5].Text.Trim();
                    lblSubcentreName.Text = GrdView.Rows[i].Cells[6].Text.Trim();
                    lblreqest.Text = GrdView.Rows[i].Cells[7].Text.Trim();

                    txttechnicalproblm.Text = GrdView.Rows[i].Cells[8].Text.Trim();
                    txtlRemark.Text = GrdView.Rows[i].Cells[9].Text.Trim();

                    lblreqtype.Text = GrdView.Rows[i].Cells[10].Text.Trim();
                    Lblvertical.Text = GrdView.Rows[i].Cells[11].Text.Trim();
                    lblverticalhead.Text = GrdView.Rows[i].Cells[12].Text.Trim();

                    lblRequestedDate.Text = GrdView.Rows[i].Cells[13].Text.Trim();
                    txtduedate.Text = GrdView.Rows[i].Cells[13].Text.Trim();
                    lblApplication.Text = GrdView.Rows[i].Cells[14].Text.Trim();
                    lblpriority.Text = GrdView.Rows[i].Cells[15].Text.Trim();
                    lblrequirement.Text = GrdView.Rows[i].Cells[16].Text.Trim();
                    lblimplementedat.Text = GrdView.Rows[i].Cells[17].Text.Trim();
                    hdncluster.Value = GrdView.Rows[i].Cells[21].Text.Trim();

                    fillgridAnnexure(strUID);

                }

            }

        }



    }

    //private void Email()
    //{
    //    string User = ddlassignedto.SelectedValue.ToString();
    //    // string ticketno = GrdView.Rows[i].Cells[1].Text.Trim();

    //    if (User == "P-52338")
    //    {
    //        Emailid = "ssu2@pamac.com";
    //    }
    //    else if (User == "P-52339")
    //    {
    //        Emailid = "ssu4@pamac.com";
    //    }

    //    string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
    //    string strhh = strTime.Remove(2);
    //    string strmm = strTime.Remove(0, 3);

    //    string Current = System.DateTime.Now.Date.ToString().Remove(10);

    //    try
    //    {
    //        MailMessage mail = new MailMessage();
    //        SmtpClient smtp = new SmtpClient("69.64.70.36", 25);

    //        mail.From = new MailAddress("calculus@pamac.com", "PAMAC SSU");

    //        mail.To.Add(Emailid);

    //        mail.Subject = "Software Rquirement Related - Query ";

    //        string strBody =
    //                   "<html><body><font color=\"Navy\" style=\"font-style=Italic;font-weight=bold\">" +

    //                   "<P>                                                                                               </P>" +
    //                   "<P>Dear PAMACian,</P>" +
    //            //"<P>                                                                                         </P>" +
    //            //"<P>This is to notify you for a query raised in QMS with the inferred Transaction ID  " + TransactionId + ".</P>" +
    //            //"<P>                                                                                         </P>" +
    //            //"<P>Request you to provide immediate attention to the same & resolve it at the earliest as per the defined TAT .</P>" +
    //            //"<P>                                                                                        </P>" +
    //                   "<P>*This is an automatically generated email, Please do not reply*</P>" +
    //                   "<P>                                                                                         </P>" +
    //                   "<P>Regards,</P>" +
    //                   "<P>Software  TEAM</P> " +

    //                   " </font></html></body>";
    //        mail.Body = strBody;

    //        mail.IsBodyHtml = true;

    //        smtp.Port = 25;
    //        smtp.Credentials = new System.Net.NetworkCredential("calculus@pamac.com", "HW76$$mm");
    //        smtp.EnableSsl = false;

    //        smtp.Send(mail);
    //        lblmsg.Text = " Email successfully sent To ";
    //        //lblTicketNo.Text = RowEffected;
    //    }
    //    catch (Exception ex)
    //    {
    //        lblmsg.Text = "Email Failed." + ex.Message;
    //    }
    //}



    private void SearchAssignedTo()
    {

        try
        {
            sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpSSUFeedback_Assignedto";
            cmd.CommandTimeout = 0;



            SqlParameter Clusterid = new SqlParameter();
            Clusterid.SqlDbType = SqlDbType.VarChar;
            Clusterid.Value = ddlcluster.SelectedValue.ToString();
            Clusterid.ParameterName = "@clusterid";
            cmd.Parameters.Add(Clusterid);


            SqlParameter CentreID = new SqlParameter();
            CentreID.SqlDbType = SqlDbType.VarChar;
            CentreID.Value = ddlcentre.SelectedValue.ToString();
            CentreID.ParameterName = "@CentreID";
            cmd.Parameters.Add(CentreID);

            SqlParameter SubCentreId = new SqlParameter();
            SubCentreId.SqlDbType = SqlDbType.VarChar;
            SubCentreId.Value = ddlsubcentre.SelectedValue.ToString();
            SubCentreId.ParameterName = "@SubCentreId";
            cmd.Parameters.Add(SubCentreId);

            SqlParameter FromDate = new SqlParameter();  /// IMP
            FromDate.SqlDbType = SqlDbType.DateTime;
            FromDate.Value = strDate(txtFromDate.Text.Trim());//txtclosingdate.Text.ToString();
            FromDate.ParameterName = "@FromDate";
            cmd.Parameters.Add(FromDate);

            SqlParameter Todate = new SqlParameter();  /// IMP
            Todate.SqlDbType = SqlDbType.DateTime;
            Todate.Value = strDate(txtToDate.Text.Trim());//txtclosingdate.Text.ToString();
            Todate.ParameterName = "@Todate";
            cmd.Parameters.Add(Todate);

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

    private void SearchAssignedToload()
    {

        try
        {
            sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpSSUFeedback_Assignedtoload";
            cmd.CommandTimeout = 0;

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
    protected void BtnActionSave_Click(object sender, EventArgs e)
    {
        string msg = string.Empty;

        try
        {
            if (txttechnicalproblm.Text == "" || txttechnicalproblm.Text == null)
            {
                msg = msg + "Please Enter Technical Problem Remarks ";
            }
            if (txtlRemark.Text == "" || txtlRemark.Text == null)
            {
                msg = msg + "Please Enter Requirement Remarks ";
            }
            if (ddlassignedto.SelectedItem.Text == "--ALL--")
            {
                msg = msg + "Please Select  Assigned To ";
            }
            if (txtduedate.Text == "" || txtduedate.Text == null)
            {
                msg = msg + "Please Enter Due Date first";
            }
            if (txtEstimatedDevelopmentTime.Text == "000:00")
            {
                msg = msg + "Please Enter  Estimated Development Time";
            }
            if (msg != "")
            {
                Panel2.Visible = true;
                Panel1.Visible = false;

                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
                return;

            }



                sqlcon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_SSUFEEDBACK_AssignTo";
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

                SqlParameter Assignedto = new SqlParameter();
                Assignedto.SqlDbType = SqlDbType.VarChar;
                Assignedto.Value = ddlassignedto.SelectedValue.ToString();
                Assignedto.ParameterName = "@AssignedTo";
                cmd.Parameters.Add(Assignedto);

                SqlParameter DueDate = new SqlParameter();
                DueDate.SqlDbType = SqlDbType.VarChar;
                DueDate.Value = strDate(txtduedate.Text.Trim());
                DueDate.ParameterName = "@DueDate";
                cmd.Parameters.Add(DueDate);

                SqlParameter technical_problem = new SqlParameter();
                technical_problem.SqlDbType = SqlDbType.VarChar;
                technical_problem.Value = txttechnicalproblm.Text.Trim();
                technical_problem.ParameterName = "@Problem";
                cmd.Parameters.Add(technical_problem);

            SqlParameter EstimatedDevelopmentTime = new SqlParameter();
            EstimatedDevelopmentTime.SqlDbType = SqlDbType.Int; 
            EstimatedDevelopmentTime.Value = (txtEstimatedDevelopmentTime.Text);
            EstimatedDevelopmentTime.ParameterName = "@EstimatedDevelopmentTime";
            cmd.Parameters.Add(EstimatedDevelopmentTime);

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

                SearchAssignedToload();
                //Email();
                clear();
            
        }
        catch (Exception Ex)
        {
            lblmsg.Text = Ex.Message;
        }
    }
    //private void Validation()
    //{
    //    //Btnsearch.Attributes.Add("onclick", "javascript:return Validate();");
    //}
    protected void ddlcentre_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_SubCentreList();
    }

    private void Get_SubCentreList()
    {
        try
        {
            sqlcon.Open();

            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = sqlcon;
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd4.CommandText = "Sp_SubCentreList";
            cmd4.CommandTimeout = 0;

            SqlParameter CentreId = new SqlParameter();
            CentreId.SqlDbType = SqlDbType.VarChar;
            CentreId.SqlValue = ddlcentre.SelectedValue.ToString();
            CentreId.ParameterName = "@CentreId";
            cmd4.Parameters.Add(CentreId);

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd4;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlsubcentre.DataTextField = "SubCentreName";
                ddlsubcentre.DataValueField = "SubCentreid";

                ddlsubcentre.DataSource = dt1;
                ddlsubcentre.DataBind();

                ddlsubcentre.Items.Insert(0, new ListItem("--ALL--", "ALL"));
                ddlsubcentre.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;

        }
    }



    private void Get_CentreList()
    {
        try
        {

            sqlcon.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = sqlcon;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "Sp_CentreList1";
            cmd2.CommandTimeout = 0;


            SqlParameter ClusterId = new SqlParameter();
            ClusterId.SqlDbType = SqlDbType.VarChar;
            ClusterId.SqlValue = ddlcluster.SelectedValue.ToString();
            ClusterId.ParameterName = "@Cluster_Id";
            cmd2.Parameters.Add(ClusterId);

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd2;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlcentre.DataTextField = "Centre_Name";
                ddlcentre.DataValueField = "Centre_id";

                ddlcentre.DataSource = dt1;
                ddlcentre.DataBind();

                ddlcentre.Items.Insert(0, new ListItem("--ALL--", "ALL"));
                ddlcentre.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }


    private void Get_developerlist()
    {
        try
        {

            sqlcon.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = sqlcon;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "get_developer_list";
            cmd2.CommandTimeout = 0;

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd2;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlassignedto.DataTextField = "fullname";
                ddlassignedto.DataValueField = "emp_code";

                ddlassignedto.DataSource = dt1;
                ddlassignedto.DataBind();

                ddlassignedto.Items.Insert(0, new ListItem("--ALL--", "ALL"));
                ddlassignedto.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }

    protected void Btnsearch_Click(object sender, EventArgs e)
    {
        SearchAssignedTo();
    }
    protected void BtnReset12_Click(object sender, EventArgs e)
    {
        txtduedate.Text = "";
        ddlassignedto.SelectedIndex = 0;
        Panel2.Visible = true;
        Panel1.Visible = false;

    }
    private void clear()
    {

        txtduedate.Text = "";
        txtEstimatedDevelopmentTime.Text = "000:00";
        ddlassignedto.SelectedIndex = 0;



    }
    protected void Grddwld_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
