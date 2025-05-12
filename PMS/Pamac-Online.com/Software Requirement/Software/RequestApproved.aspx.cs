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
using System.Net.Mail;
public partial class Software_Requirement_Software_RequestApproved : System.Web.UI.Page
{
    CCommon objConn = new CCommon(); SqlConnection sqlcon;
    string Emailid;
    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);



        if (!IsPostBack)
        {


            ddlcentre.Items.Insert(0, new ListItem("--ALL--", "ALL"));
            ddlsubcentre.Items.Insert(0, new ListItem("--ALL--", "ALL"));

            Get_ClusterList();

            BindSearch();
        }

        // GrdView.Columns[21].Visible = false;
        //String a;
        //a= Convert.ToString(System.DateTime.Now.AddDays(1));
        //txtExpectedDate.Text = a;
        Validation();
        Panel1.Visible = true;
        Panel2.Visible = false;
        //fillgridAnnexure(string UID);


    }


    private void Email()
    {

        String ticket = HDNUPDATE.Value;
        //string User = ddlverticalHead.SelectedValue.ToString();
        //// string ticketno = GrdView.Rows[i].Cells[1].Text.Trim();

        //if (User == "101103522")
        //{
        //    Emailid = "edp@pamac.com";
        //}
        //else if (User == "10133")
        //{
        //    Emailid = "rajesh.patel@pamac.com";
        //}
        //else if (User == "103376")
        //{
        //    Emailid = "sachin.tirlotkar@pamac.com";
        //}
        //else if (User == "101889")
        //{
        //    Emailid = "sameer.kudalkar@pamac.com";
        //}
        //else if (User == "101103639")
        //{
        //    Emailid = "mangesh.hande@pamac.com";
        //}
        //else if (User == "101103516")
        //{
        //    Emailid = "ganesh.sawant@pamac.com";
        //}
        string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
        string strhh = strTime.Remove(2);
        string strmm = strTime.Remove(0, 3);

        string Current = System.DateTime.Now.Date.ToString().Remove(10);

        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient("69.64.70.36", 25);

            mail.From = new MailAddress("calculus@pamac.com", "PAMAC SSU");

            string mailTO = "Rupesh.zodage@pamac.com";
            //mail.To.Add("Rupesh.zodage@pamac.com);

            mail.To.Add(mailTO);

            mail.Subject = "Software Rquirement Related - Query ";

            string strBody =
                       "<html><body><font color=\"Navy\" style=\"font-style=Italic;font-weight=bold\">" +

                       "<P>                                                                                               </P>" +
                       "<P>Dear Sir,</P>" +
                       "<P>This is to notify you for a query or Given Ticket  Approved By Vertical Head. Transaction ID  " + ticket + ".</P>" +

                       "<P>*Kindly Login To the PMS & Process the request at the earliest*</P>" +

                       "<P>*This is an automatically generated email, Please do not reply*</P>" +


                       "<P>                                                                                         </P>" +
                       "<P>Regards,</P>" +
                       "<P>Software  TEAM</P> " +

                       " </font></html></body>";
            mail.Body = strBody;

            mail.IsBodyHtml = true;

            smtp.Port = 25;
            smtp.Credentials = new System.Net.NetworkCredential("calculus@pamac.com", "HW76$$mm");
            smtp.EnableSsl = false;

            smtp.Send(mail);
            lblmsg.Text = " Email successfully sent To ";
            //lblTicketNo.Text = RowEffected;
        }
        catch (Exception ex)
        {
            lblmsg.Text = "Email Failed." + ex.Message;
        }
    }
    //public bool FunctioncompareDate()
    //{

    //    DateTime sRequestdate;
    //    DateTime sRequiredtillDate;
    //    sRequestdate = Convert.ToDateTime(connobj.strDate(txtrequest.Text.ToString().Trim()));
    //    sRequiredtillDate = Convert.ToDateTime(connobj.strDate(txtExpectedDate.Text.ToString().Trim()));
    //    bool bReturn = true;
    //    if (sRequestdate > sRequiredtillDate)
    //    {
    //        bReturn = false;
    //    }
    //    else
    //    {
    //        bReturn = true;


    //    }
    //    return bReturn;
    //}
    protected void BtnActionSave_Click(object sender, EventArgs e)
    {
        string msg = string.Empty;

        try
        {
            if (ddlcostbenifits.SelectedItem.Text == "YES")
            {
                if (txtcostremark.Text == "" || txtcostremark.Text == null)
                {
                    msg = msg + "Please Enter Cost Remarks ";

                    Panel1.Visible = false;
                    Panel2.Visible = true;
                }
            }
            if (txtRemark.Text == "" || txtRemark.Text == null)
            {
                msg = msg + "Please Enter Remarks ";

                Panel1.Visible = false;
                Panel2.Visible = true;
            }
            if (msg != "")
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
                return;
            }

            String str1 = System.DateTime.Now.ToString("dd/MM/yyyy");
            if (txtExpectedDate.Text != str1)
            {

                sqlcon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_Approvedstatus12";
                cmd.CommandTimeout = 0;

                SqlParameter ticketno = new SqlParameter();
                ticketno.SqlDbType = SqlDbType.VarChar;
                ticketno.Value = HDNUPDATE.Value;
                ticketno.ParameterName = "@ticketno";
                cmd.Parameters.Add(ticketno);

                SqlParameter ApprvStatus = new SqlParameter();
                ApprvStatus.SqlDbType = SqlDbType.VarChar;
                ApprvStatus.Value = "Approved";
                ApprvStatus.ParameterName = "@ApprvStatus";
                cmd.Parameters.Add(ApprvStatus);

                SqlParameter clusterid = new SqlParameter();
                clusterid.SqlDbType = SqlDbType.VarChar;
                clusterid.Value = hdnclusterid.Value;
                clusterid.ParameterName = "@clusterid";
                cmd.Parameters.Add(clusterid);

                SqlParameter costbenifits = new SqlParameter();
                costbenifits.SqlDbType = SqlDbType.VarChar;
                costbenifits.Value = ddlcostbenifits.SelectedValue.ToString();
                costbenifits.ParameterName = "@cost_benifits";
                cmd.Parameters.Add(costbenifits);

                SqlParameter cost_remark = new SqlParameter();
                cost_remark.SqlDbType = SqlDbType.VarChar;
                cost_remark.Value = txtcostremark.Text.Trim();
                cost_remark.ParameterName = "@cost_remark";
                cmd.Parameters.Add(cost_remark);

                SqlParameter ExpextedDate = new SqlParameter();
                ExpextedDate.SqlDbType = SqlDbType.VarChar;
                ExpextedDate.Value = strDate(txtExpectedDate.Text.Trim());
                ExpextedDate.ParameterName = "@ExpextedDate";
                cmd.Parameters.Add(ExpextedDate);

                SqlParameter ApprovedPriority = new SqlParameter();
                ApprovedPriority.SqlDbType = SqlDbType.VarChar;
                ApprovedPriority.Value = ddlpriority.SelectedValue.ToString();
                ApprovedPriority.ParameterName = "@priority";
                cmd.Parameters.Add(ApprovedPriority);


                SqlParameter Remark = new SqlParameter();
                Remark.SqlDbType = SqlDbType.VarChar;
                Remark.Value = txtRemark.Text.Trim();
                Remark.ParameterName = "@ApprovedRemark";
                cmd.Parameters.Add(Remark);

                SqlParameter ApprovedBy = new SqlParameter();
                ApprovedBy.SqlDbType = SqlDbType.VarChar;
                ApprovedBy.Value = Session["UserId"].ToString();
                ApprovedBy.ParameterName = "@ApprovedBy";
                cmd.Parameters.Add(ApprovedBy);


                int r = cmd.ExecuteNonQuery();

                sqlcon.Close();

                if (r > 0)
                {
                    lblmsg.Text = "Data Submitted Successfully";
                }


                Email();
                BindSearch();

                clear();
            }
            else
            {
                Label1.Text = "Expected  Date should not be less then Requested  Date";
                Panel1.Visible = false;
                Panel2.Visible = true;
            }
        }

        catch (Exception Ex)
        {
            lblmsg.Text = Ex.Message;
        }

        BindSearch();
    }



    private void Get_SubCentreList()
    {
        try
        {
            sqlcon.Open();

            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = sqlcon;
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd4.CommandText = "Sp_SubCentreList1";
            cmd4.CommandTimeout = 0;

            //SqlParameter ClusterId = new SqlParameter();
            //ClusterId.SqlDbType = SqlDbType.VarChar;
            //ClusterId.SqlValue = Session["ClusterId"].ToString();
            //ClusterId.ParameterName = "@ClusterId";
            //cmd4.Parameters.Add(ClusterId);


            SqlParameter Centreid = new SqlParameter();
            Centreid.SqlDbType = SqlDbType.VarChar;
            Centreid.SqlValue = ddlcentre.SelectedValue.ToString();
            Centreid.ParameterName = "@centreid";
            cmd4.Parameters.Add(Centreid);



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

    protected void ddlcentre_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_SubCentreList();
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

    protected void GrdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;

        for (int i = 0; i <= GrdView.Rows.Count - 1; i++)
        {
            String strUID = "";
            strUID = e.CommandArgument.ToString();

            lblTicketNo.Text = "TicketNo:- " + strUID;

            HdnUID.Value = GrdView.Rows[i].Cells[1].Text.Trim();

            if (e.CommandName == "Edit1")
            {
                if (HdnUID.Value == strUID)
                {
                    lblTicketNo2.Text = strUID;

                    HDNUPDATE.Value = GrdView.Rows[i].Cells[1].Text.Trim();
                    lblEmpCode.Text = GrdView.Rows[i].Cells[2].Text.Trim();
                    lblFrstName.Text = GrdView.Rows[i].Cells[3].Text.Trim();
                    lblLastName.Text = GrdView.Rows[i].Cells[4].Text.Trim();
                    LblCentreName.Text = GrdView.Rows[i].Cells[5].Text.Trim();
                    lblSubcentreName.Text = GrdView.Rows[i].Cells[6].Text.Trim();
                    txtrequest.Text = GrdView.Rows[i].Cells[7].Text.Trim();

                    //txttechnicalproblm.Text = GrdView.Rows[i].Cells[8].Text.Trim();
                    //txtlRemark.Text = GrdView.Rows[i].Cells[9].Text.Trim();

                    lblreqtype.Text = GrdView.Rows[i].Cells[10].Text.Trim();
                    Lblvertical.Text = GrdView.Rows[i].Cells[11].Text.Trim();
                    lblverticalhead.Text = GrdView.Rows[i].Cells[12].Text.Trim();

                    txtrequiredtill.Text = GrdView.Rows[i].Cells[13].Text.Trim();
                    txtExpectedDate.Text = GrdView.Rows[i].Cells[13].Text.Trim();
                    lblApplication.Text = GrdView.Rows[i].Cells[14].Text.Trim();
                    lblpriority.Text = GrdView.Rows[i].Cells[15].Text.Trim();
                    lblrequirement.Text = GrdView.Rows[i].Cells[16].Text.Trim();
                    lblimplementedat.Text = GrdView.Rows[i].Cells[17].Text.Trim();





                    hdnclusterid.Value = GrdView.Rows[i].Cells[21].Text.Trim();
                    //hdncentreid.Value = GrdView.Rows[i].Cells[22].Text.Trim();

                    //lblremark.Text = GrdView.Rows[i].Cells[9].Text.Trim();






                    fillgridAnnexure(strUID);

                }

            }



        }



    }


    private void clear()
    {

        txtExpectedDate.Text = "";
        txtRemark.Text = "";
        ddlpriority.SelectedIndex = 0;
        lblmsg.Text = "";
        Label1.Text = "";


    }
    //protected void BtnReset_Click(object sender, EventArgs e)
    //{

    //    //GrdView.DataSource = null;
    //    //GrdView.DataBind();

    //    //Response.Redirect("Default.aspx");
    //}


    private void Validation()
    {

        BtnActionSave.Attributes.Add("onclick", "javascript:return funValidateFromToDate1();");


    }

    private void Search()
    {

        try
        {
            sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpFeedback_View_approced1234";
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

            SqlParameter userid = new SqlParameter();
            userid.SqlDbType = SqlDbType.VarChar;
            userid.Value = Session["UserId"].ToString();
            userid.ParameterName = "@userid";
            cmd.Parameters.Add(userid);

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

    protected void Button1_Click(object sender, EventArgs e)
    {
        Search();
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


    protected void btnBack_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;

        ddlcentre.SelectedIndex = 0;
        ddlsubcentre.SelectedIndex = 0;
        txtFromDate.Text = "";
        txtToDate.Text = "";
        lblmsg.Text = "";

        GrdView.DataSource = null;
        GrdView.DataBind();
    }

    protected void btndelete_Click(object sender, EventArgs e)
    {
        try
        {

            sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Sp_status_new1234";
            cmd.CommandTimeout = 0;

            SqlParameter ticket_No = new SqlParameter();
            ticket_No.SqlDbType = SqlDbType.VarChar;
            ticket_No.Value = HDNUPDATE.Value;
            ticket_No.ParameterName = "@ticketno";
            cmd.Parameters.Add(ticket_No);


            SqlParameter clusterid = new SqlParameter();
            clusterid.SqlDbType = SqlDbType.VarChar;
            clusterid.Value = hdnclusterid.Value;
            clusterid.ParameterName = "@clusterid";
            cmd.Parameters.Add(clusterid);

            SqlParameter ApprvStatus = new SqlParameter();
            ApprvStatus.SqlDbType = SqlDbType.VarChar;
            ApprvStatus.Value = "Deleted";
            ApprvStatus.ParameterName = "@ApprvStatus";
            cmd.Parameters.Add(ApprvStatus);


            SqlParameter costbenifits = new SqlParameter();
            costbenifits.SqlDbType = SqlDbType.VarChar;
            costbenifits.Value = ddlcostbenifits.SelectedValue.ToString();
            costbenifits.ParameterName = "@cost_benifits";
            cmd.Parameters.Add(costbenifits);

            SqlParameter cost_remark = new SqlParameter();
            cost_remark.SqlDbType = SqlDbType.VarChar;
            cost_remark.Value = strDate(txtExpectedDate.Text.Trim());
            cost_remark.ParameterName = "@cost_remark";
            cmd.Parameters.Add(cost_remark);



            SqlParameter ExpextedDate = new SqlParameter();
            ExpextedDate.SqlDbType = SqlDbType.VarChar;
            ExpextedDate.Value = strDate(txtExpectedDate.Text.Trim());
            ExpextedDate.ParameterName = "@ExpextedDate";
            cmd.Parameters.Add(ExpextedDate);



            SqlParameter ApprovedPriority = new SqlParameter();
            ApprovedPriority.SqlDbType = SqlDbType.VarChar;
            ApprovedPriority.Value = ddlpriority.SelectedValue.ToString();
            ApprovedPriority.ParameterName = "@priority";
            cmd.Parameters.Add(ApprovedPriority);


            SqlParameter Remark = new SqlParameter();
            Remark.SqlDbType = SqlDbType.VarChar;
            Remark.Value = txtRemark.Text.Trim();
            Remark.ParameterName = "@ApprovedRemark";
            cmd.Parameters.Add(Remark);


            int r = cmd.ExecuteNonQuery();

            sqlcon.Close();

            lblmsg.Text = "Data Delete Successfully";

            //if (r > 0)
            //{

            //}
        }
        catch (Exception Ex)
        {
            lblmsg.Text = Ex.Message;
        }

        Search();
        clear();

    }
    protected void BtnReject_Click(object sender, EventArgs e)
    {
        try
        {

            sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Sp_Approvedstatus_new12";
            cmd.CommandTimeout = 0;

            SqlParameter ticket_No = new SqlParameter();
            ticket_No.SqlDbType = SqlDbType.VarChar;
            ticket_No.Value = HDNUPDATE.Value;
            ticket_No.ParameterName = "@ticketno";
            cmd.Parameters.Add(ticket_No);


            SqlParameter clusterid = new SqlParameter();
            clusterid.SqlDbType = SqlDbType.VarChar;
            clusterid.Value = hdnclusterid.Value;
            clusterid.ParameterName = "@clusterid";
            cmd.Parameters.Add(clusterid);

            SqlParameter ApprvStatus = new SqlParameter();
            ApprvStatus.SqlDbType = SqlDbType.VarChar;
            ApprvStatus.Value = "Rejected";
            ApprvStatus.ParameterName = "@ApprvStatus";
            cmd.Parameters.Add(ApprvStatus);


            SqlParameter costbenifits = new SqlParameter();
            costbenifits.SqlDbType = SqlDbType.VarChar;
            costbenifits.Value = ddlcostbenifits.SelectedValue.ToString();
            costbenifits.ParameterName = "@cost_benifits";
            cmd.Parameters.Add(costbenifits);

            SqlParameter cost_remark = new SqlParameter();
            cost_remark.SqlDbType = SqlDbType.VarChar;
            cost_remark.Value = strDate(txtExpectedDate.Text.Trim());
            cost_remark.ParameterName = "@cost_remark";
            cmd.Parameters.Add(cost_remark);



            SqlParameter ExpextedDate = new SqlParameter();
            ExpextedDate.SqlDbType = SqlDbType.VarChar;
            ExpextedDate.Value = strDate(txtExpectedDate.Text.Trim());
            ExpextedDate.ParameterName = "@ExpextedDate";
            cmd.Parameters.Add(ExpextedDate);



            SqlParameter ApprovedPriority = new SqlParameter();
            ApprovedPriority.SqlDbType = SqlDbType.VarChar;
            ApprovedPriority.Value = ddlpriority.SelectedValue.ToString();
            ApprovedPriority.ParameterName = "@priority";
            cmd.Parameters.Add(ApprovedPriority);


            SqlParameter Remark = new SqlParameter();
            Remark.SqlDbType = SqlDbType.VarChar;
            Remark.Value = txtRemark.Text.Trim();
            Remark.ParameterName = "@ApprovedRemark";
            cmd.Parameters.Add(Remark);


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
    protected void ddlcluster_SelectedIndexChanged(object sender, EventArgs e)
    {

        Get_CentreList();

    }

    protected void BtnReset12_Click(object sender, EventArgs e)
    {
        ddlcostbenifits.SelectedIndex = 0;
        txtcostremark.Text = "";
        txtExpectedDate.Text = "";
        txtRemark.Text = "";
        ddlpriority.SelectedIndex = 0;
        Panel2.Visible = true;
        Panel1.Visible = false;


    }
    private void BindSearch()
    {

        try
        {
            sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SpFeedback_View_approced_Bind";
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

            SqlParameter userid = new SqlParameter();
            userid.SqlDbType = SqlDbType.VarChar;
            userid.Value = Session["UserId"].ToString();
            userid.ParameterName = "@userid";
            cmd.Parameters.Add(userid);

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
}

