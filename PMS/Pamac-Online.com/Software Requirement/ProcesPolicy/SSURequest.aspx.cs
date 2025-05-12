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

public partial class Software_Requirement_Software_SSURequest : System.Web.UI.Page
{
    CCommon connobj = new CCommon();
    CCommon objConn = new CCommon(); SqlConnection sqlcon;
    string filename_Attachment;
    string Emailid;
    string RowEffected;
    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);

        pnlStatus.Visible = false;
        Pnlclient.Visible = true;
        Pnlmain.Visible = true;
        pnlrightasiignment.Visible = false;
        pnlStatus.Visible = false;
        Pnlclientadd.Visible = false;
        pnlStatus.Visible = false;
        Pnldomain.Visible = false;
        pnlpassword.Visible = false;
        pnlautoreply.Visible = false;
     
     
        if (!IsPostBack)
        {
            ddlsubcentre.Items.Insert(0, new ListItem("--ALL--", "0"));
            Get_CentreList();
            Get_SubCentreList();
        
            Get_vertical();
            Get_verticalhead_new();
            Get_Client();
            Get_Activity();;
            Get_ActivityclientAdd();
            Get_Activityrights();
            Get_product();
            Get_productcliendadd();
            Get_productrights();

            

            Getdata();
            FillGrid();
            Get_RequirementList();
            //Get_verticalhead();

        }


        Validation();

    }

    private void Email()
    {
        string User = ddlverticalHead.SelectedValue.ToString();
        // string ticketno = GrdView.Rows[i].Cells[1].Text.Trim();

        if (User == "101103522")
        {
            Emailid = "murugan.odiyar@pamac.com";
        }
        else if (User == "10133")
        {
            Emailid = "rajesh.patel@pamac.com";
        }
        else if (User == "103376")
        {
            Emailid = "sachin.tirlotkar@pamac.com";
        }
        else if (User == "101889")
        {
            Emailid = "sameer.kudalkar@pamac.com";
        }
        else if (User == "101103639")
        {
            Emailid = "mangesh.hande@pamac.com";
        }
        else if (User == "101103516")
        {
            Emailid = "software.support@pamac.com";
        }
        else if (User == "101993")
        {
            Emailid = "a.vinodh@pamac.com";
        }
        else if (User == "101318")
        {
            Emailid = "maulik.tikariya@pamac.com";
        }
        else if (User == "103390")
        {
            Emailid = "mahendra.jadhav@pamac.com";
        }
        else if (User == "101103390")
        {
            Emailid = "shankar.devare@pamac.com";
        }
        else if (User == "101144593")
        {
            Emailid = "santosh.morajkar@pamac.com";
        }
        else if (User == "101738")
        {
            Emailid = "sansar.chand@pamac.com";
        }
        else if (User == "101910")
        {
            Emailid = "shankar.kamat@pamac.com";
        }
        else if (User == "102118")
        {
            Emailid = "prithvi.joshi@pamac.com";
        }
        else if (User == "101920")
        {
            Emailid = "rajesh.agarwal@pamac.com";
        }

        else if (User == "102979")
        {
            Emailid = "amit.mishra@pamac.com";
        }

        else if (User == "102979")
        {
            Emailid = "niranjan.desai@pamcal.com";
        }
        string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
        string strhh = strTime.Remove(2);
        string strmm = strTime.Remove(0, 3);

        string Current = System.DateTime.Now.Date.ToString().Remove(10);

        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient("103.13.99.137", 25);

            mail.From = new MailAddress("calculus@pamac.com", "PAMAC SSU");

            string mailcc = "Rupesh.zodage@pamac.com";
            mail.To.Add(Emailid);

            mail.CC.Add(mailcc);

            mail.Subject = "Software Rquirement Related - Query ";

            string strBody =
                       "<html><body><font color=\"Navy\" style=\"font-style=Italic;font-weight=bold\">" +

                       "<P>                                                                                               </P>" +
                       "<P>Dear Sir,</P>" +
                       "<P>This is to notify you for a query raised in Software Application with the inferred Transaction ID  " + lblTicketNo.Text + ".</P>" +

                       "<P>*Kindly Login To the PMS & Process the request at the earliest*</P>" +

                       "<P>*This is an automatically generated email, Please do not reply*</P>" +


                       "<P>                                                                                         </P>" +
                       "<P>Regards,</P>" +
                       "<P>Software  TEAM</P> " +

                       " </font></html></body>";
            mail.Body = strBody;

            mail.IsBodyHtml = true;

            smtp.Port = 25;
            smtp.Credentials = new System.Net.NetworkCredential("calculus@pamac.com", "pamac@123");
            smtp.EnableSsl = false;

            smtp.Send(mail);
            Lblmsg.Text = " Email successfully sent To ";
            //lblTicketNo.Text = RowEffected;
        }
        catch (Exception ex)
        {
            Lblmsg.Text = "Email Failed." + ex.Message;
        }
    }



    private void Get_VerticalCPV()
    {
        try
        {

            sqlcon.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = sqlcon;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "vertical_CPV";
            cmd2.CommandTimeout = 0;

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd2;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlverticalHead.DataTextField = "Vertical_head";
                ddlverticalHead.DataValueField = "emp_id";

                ddlverticalHead.DataSource = dt1;
                ddlverticalHead.DataBind();

                ddlverticalHead.Items.Insert(0, new ListItem("--ALL--", "0"));
                ddlverticalHead.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Lblmsg.Text = ex.Message;
        }
        finally
        {
            sqlcon.Close();

        }
    }

    private void Get_VerticalCPA()
    {
        try
        {

            sqlcon.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = sqlcon;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "vertical_CPA";
            cmd2.CommandTimeout = 0;

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd2;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlverticalHead.DataTextField = "Vertical_head";
                ddlverticalHead.DataValueField = "emp_id";

                ddlverticalHead.DataSource = dt1;
                ddlverticalHead.DataBind();

                ddlverticalHead.Items.Insert(0, new ListItem("--ALL--", "0"));
                ddlverticalHead.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Lblmsg.Text = ex.Message;
        }
        finally
        {
            sqlcon.Close();

        }
    }

    private void Get_VerticalPTPU()
    {
        try
        {

            sqlcon.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = sqlcon;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "vertical_PTPU";
            cmd2.CommandTimeout = 0;

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd2;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlverticalHead.DataTextField = "Vertical_head";
                ddlverticalHead.DataValueField = "emp_id";

                ddlverticalHead.DataSource = dt1;
                ddlverticalHead.DataBind();

                ddlverticalHead.Items.Insert(0, new ListItem("--ALL--", "0"));
                ddlverticalHead.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Lblmsg.Text = ex.Message;
        }
        finally
        {
            sqlcon.Close();

        }
    }

    private void Get_VerticalPDCR()
    {
        try
        {

            sqlcon.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = sqlcon;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "vertical_PDCR";
            cmd2.CommandTimeout = 0;

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd2;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlverticalHead.DataTextField = "Vertical_head";
                ddlverticalHead.DataValueField = "emp_id";

                ddlverticalHead.DataSource = dt1;
                ddlverticalHead.DataBind();

                ddlverticalHead.Items.Insert(0, new ListItem("--ALL--", "0"));
                ddlverticalHead.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Lblmsg.Text = ex.Message;
        }
        finally
        {
            sqlcon.Close();

        }
    }

    private void Get_VerticalAdmin()
    {
        try
        {

            sqlcon.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = sqlcon;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "vertical_Admin";
            cmd2.CommandTimeout = 0;

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd2;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlverticalHead.DataTextField = "Vertical_head";
                ddlverticalHead.DataValueField = "emp_id";

                ddlverticalHead.DataSource = dt1;
                ddlverticalHead.DataBind();

                ddlverticalHead.Items.Insert(0, new ListItem("--ALL--", "0"));
                ddlverticalHead.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Lblmsg.Text = ex.Message;
        }
        finally
        {
            sqlcon.Close();

        }
    }

    private void Get_VerticalSSU()
    {
        try
        {

            sqlcon.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = sqlcon;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "vertical_SSU";
            cmd2.CommandTimeout = 0;

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd2;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlverticalHead.DataTextField = "Vertical_head";
                ddlverticalHead.DataValueField = "emp_id";

                ddlverticalHead.DataSource = dt1;
                ddlverticalHead.DataBind();

                ddlverticalHead.Items.Insert(0, new ListItem("--ALL--", "0"));
                ddlverticalHead.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Lblmsg.Text = ex.Message;
        }
        finally
        {
            sqlcon.Close();

        }
    }


    protected void ddlvertical_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlvertical.SelectedIndex == 1)
        {

            Get_VerticalCPV();
        }
        else if (ddlvertical.SelectedIndex == 2)
        {

            Get_VerticalCPA();
        }
        else if (ddlvertical.SelectedIndex == 3)
        {

            Get_VerticalPTPU();
        }

        else if (ddlvertical.SelectedIndex == 4)
        {

            Get_VerticalPDCR();
        }

        else if (ddlvertical.SelectedIndex == 7)
        {

            Get_VerticalAdmin();
        }
        else if (ddlvertical.SelectedIndex == 11)
        {

            Get_VerticalSSU();
        }


        else if (ddlvertical.SelectedIndex == 12)
        {

            Get_VerticalSSU();
        }

        else if (ddlvertical.SelectedIndex == 10)
        {

            Get_VerticalHSU();
        }

    }




    private void Get_VerticalHSU()
    {
        try
        {

            sqlcon.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = sqlcon;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "vertical_HSU";
            cmd2.CommandTimeout = 0;

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd2;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlverticalHead.DataTextField = "Vertical_head";
                ddlverticalHead.DataValueField = "emp_id";

                ddlverticalHead.DataSource = dt1;
                ddlverticalHead.DataBind();

                ddlverticalHead.Items.Insert(0, new ListItem("--ALL--", "0"));
                ddlverticalHead.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Lblmsg.Text = ex.Message;
        }
        finally
        {
            sqlcon.Close();

        }
    }



    protected void lnkClose_Click(object sender, EventArgs e)
    {
        for (int i = 0; i <= grdGrid.Rows.Count - 1; i++)
        {
            //CheckBox chkSelect = (CheckBox)grdGrid.Rows[i].FindControl("chkSelect");
            string Remark = null;
            //if (chkSelect.Checked == true)
            //{
            TextBox txtRemark = (TextBox)grdGrid.Rows[i].FindControl("txtNewRemark");
            Remark = txtRemark.Text.ToString();
            string TicketNo = grdGrid.Rows[i].Cells[7].Text.Trim();

            sqlcon.Open();

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Update_SSUTicketInfo";
            sqlCom.CommandTimeout = 0;

            SqlParameter TicketNo1 = new SqlParameter();
            TicketNo1.SqlDbType = SqlDbType.VarChar;
            TicketNo1.Value = TicketNo;
            TicketNo1.ParameterName = "@TicketNo";
            sqlCom.Parameters.Add(TicketNo1);

            //SqlParameter Status = new SqlParameter();
            //Status.SqlDbType = SqlDbType.VarChar;
            //Status.Value = 2;
            //Status.ParameterName = "@Status";
            //sqlCom.Parameters.Add(Status);



            //SqlParameter ID = new SqlParameter();
            //ID.SqlDbType = SqlDbType.VarChar;
            //ID.Value = id;
            //ID.ParameterName = "@ID";
            //sqlCom.Parameters.Add(ID);

            if (txtRemark.Text == null || txtRemark.Text == "" || txtRemark.Text == string.Empty)
            {
                Remark = string.Empty;
            }

            SqlParameter UAT_REMARK = new SqlParameter();
            UAT_REMARK.SqlDbType = SqlDbType.VarChar;
            UAT_REMARK.Value = Remark;
            UAT_REMARK.ParameterName = "@UAT_REMARK";
            sqlCom.Parameters.Add(UAT_REMARK);

            int RowsEffeted = sqlCom.ExecuteNonQuery();
            if (RowsEffeted > 0)
            {
                Lblmsg.Text = "Record Successfully Updated!";
                Lblmsg.CssClass = "UpdateMessage";
            }
            sqlcon.Close();

            //}
            //    else
            //    {
            //        Lblmsg.Text = "Please Select Atleast One Record...!!!";
            //    }
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
            Lblmsg.Text = ex.Message;
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
            Lblmsg.Text = "No Attached Document Found...!!!";
        }
    }

    protected void grdGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkdownload = (LinkButton)e.Row.FindControl("lnkdownload");
            //LinkButton lnkdownload2 = (LinkButton)e.Row.FindControl("lnkdownload2");
            //LinkButton lnkdownload3 = (LinkButton)e.Row.FindControl("lnkdownload3");


            if (lnkdownload.CommandArgument == "")
            {
                lnkdownload.Enabled = false;
                lnkdownload.ToolTip = "No Attachment Found...!!!";
            }
            //if (lnkdownload2.CommandArgument == "")
            //{
            //    lnkdownload2.Enabled = false;
            //    lnkdownload2.ToolTip = "No Attachment Found...!!!";
            //}
            //if (lnkdownload3.CommandArgument == "")
            //{
            //    lnkdownload3.Enabled = false;
            //    lnkdownload3.ToolTip = "No Attachment Found...!!!";
            //}
        }
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlvertical.SelectedIndex!=0)
            {
                if (ddlverticalHead.SelectedIndex!=0)
                {

                    if (txtToDate.Text != "")
                    {
                        String str1 = System.DateTime.Now.ToString("dd/MM/yyyy");
                        if (txtToDate.Text != str1)
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = sqlcon;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "Sp_SoftwareRequest1213";
                            cmd.CommandTimeout = 0;

                            SqlParameter Created_By = new SqlParameter();
                            Created_By.SqlDbType = SqlDbType.VarChar;
                            Created_By.Value = Convert.ToInt32(Session["UserId"]);
                            Created_By.ParameterName = "@Created_By";
                            cmd.Parameters.Add(Created_By);

                            SqlParameter Emp_code = new SqlParameter();
                            Emp_code.SqlDbType = SqlDbType.VarChar;
                            Emp_code.Value = txtEmpCode.Text.Trim();
                            Emp_code.ParameterName = "@Emp_code";
                            cmd.Parameters.Add(Emp_code);

                            SqlParameter First_Name = new SqlParameter();
                            First_Name.SqlDbType = SqlDbType.VarChar;
                            First_Name.Value = txtfirstname.Text.Trim();
                            First_Name.ParameterName = "@First_Name";
                            cmd.Parameters.Add(First_Name);

                            SqlParameter Last_Name = new SqlParameter();
                            Last_Name.SqlDbType = SqlDbType.VarChar;
                            Last_Name.Value = txtLastName.Text.Trim();
                            Last_Name.ParameterName = "@Last_Name";
                            cmd.Parameters.Add(Last_Name);

                            SqlParameter ClusterId = new SqlParameter();
                            ClusterId.SqlDbType = SqlDbType.VarChar;
                            ClusterId.Value = Session["ClusterId"].ToString();
                            ClusterId.ParameterName = "@ClusterId";
                            cmd.Parameters.Add(ClusterId);

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

                            SqlParameter Date = new SqlParameter();
                            Date.SqlDbType = SqlDbType.VarChar;
                            Date.Value = strDate(txtFromDate.Text.Trim());
                            Date.ParameterName = "@Date";
                            cmd.Parameters.Add(Date);


                            SqlParameter ReqrDate = new SqlParameter();
                            ReqrDate.SqlDbType = SqlDbType.VarChar;
                            ReqrDate.Value = strDate(txtToDate.Text.Trim());
                            ReqrDate.ParameterName = "@ReqrDate";
                            cmd.Parameters.Add(ReqrDate);


                            SqlParameter Vertical = new SqlParameter();
                            Vertical.SqlDbType = SqlDbType.VarChar;
                            Vertical.Value = ddlvertical.SelectedValue.ToString();
                            Vertical.ParameterName = "@Vertical";
                            cmd.Parameters.Add(Vertical);

                            SqlParameter Approveto = new SqlParameter();
                            Approveto.SqlDbType = SqlDbType.VarChar;
                            Approveto.Value = ddlverticalHead.SelectedValue.ToString();
                            Approveto.ParameterName = "@Approveto";
                            cmd.Parameters.Add(Approveto);

                            SqlParameter Problem = new SqlParameter();
                            Problem.SqlDbType = SqlDbType.VarChar;
                            Problem.Value = txtproblem.Text.Trim();
                            Problem.ParameterName = "@Problem";
                            cmd.Parameters.Add(Problem);


                            SqlParameter RequirementType = new SqlParameter();
                            RequirementType.SqlDbType = SqlDbType.VarChar;
                            RequirementType.Value = ddlreqtype.SelectedValue.ToString();
                            RequirementType.ParameterName = "@RequestType";
                            cmd.Parameters.Add(RequirementType);

                            SqlParameter Application = new SqlParameter();
                            Application.SqlDbType = SqlDbType.VarChar;
                            Application.Value = ddlapplication.SelectedValue.ToString();
                            Application.ParameterName = "@application";
                            cmd.Parameters.Add(Application);



                            SqlParameter requirement = new SqlParameter();
                            requirement.SqlDbType = SqlDbType.VarChar;
                            requirement.Value = ddlrequirement.SelectedValue.ToString();
                            requirement.ParameterName = "@requirement";
                            cmd.Parameters.Add(requirement);


                            SqlParameter priority = new SqlParameter();
                            priority.SqlDbType = SqlDbType.VarChar;
                            priority.Value = ddlpriority.SelectedValue.ToString();
                            priority.ParameterName = "@priority";
                            cmd.Parameters.Add(priority);


                            SqlParameter implementedAt = new SqlParameter();
                            implementedAt.SqlDbType = SqlDbType.VarChar;
                            implementedAt.Value = ddllocations.SelectedValue.ToString();
                            implementedAt.ParameterName = "@implementedAt";
                            cmd.Parameters.Add(implementedAt);


                            if (ddlrequirement.SelectedIndex == 2 || ddlrequirement.SelectedIndex == 3)
                            {
                                SqlParameter activity = new SqlParameter();
                                activity.SqlDbType = SqlDbType.VarChar;
                                activity.Value = ddlactivity.SelectedValue.ToString();
                                activity.ParameterName = "@Activity_id";
                                cmd.Parameters.Add(activity);

                                SqlParameter product = new SqlParameter();
                                product.SqlDbType = SqlDbType.VarChar;
                                product.Value = ddlproduct.SelectedValue.ToString();
                                product.ParameterName = "@Product_id";
                                cmd.Parameters.Add(product);

                                SqlParameter client = new SqlParameter();
                                client.SqlDbType = SqlDbType.VarChar;
                                client.Value = ddlclient.SelectedValue.ToString();
                                client.ParameterName = "@Client_id";
                                cmd.Parameters.Add(client);

                            }
                            else
                            {

                                SqlParameter activity = new SqlParameter();
                                activity.SqlDbType = SqlDbType.VarChar;
                                activity.Value = DBNull.Value; ;
                                activity.ParameterName = "@Activity_id";
                                cmd.Parameters.Add(activity);

                                SqlParameter product = new SqlParameter();
                                product.SqlDbType = SqlDbType.VarChar;
                                product.Value = DBNull.Value; ;
                                product.ParameterName = "@Product_id";
                                cmd.Parameters.Add(product);

                                SqlParameter client = new SqlParameter();
                                client.SqlDbType = SqlDbType.VarChar;
                                client.Value = DBNull.Value; ;
                                client.ParameterName = "@Client_id";
                                cmd.Parameters.Add(client);


                            }


                            if (ddlrequirement.SelectedIndex == 1)
                            {
                                SqlParameter activity = new SqlParameter();
                                activity.SqlDbType = SqlDbType.VarChar;
                                activity.Value = ddlclientactivity.SelectedValue.ToString();
                                activity.ParameterName = "@clientActivity_id";
                                cmd.Parameters.Add(activity);

                                SqlParameter product = new SqlParameter();
                                product.SqlDbType = SqlDbType.VarChar;
                                product.Value = ddlclientproduct.SelectedValue.ToString();
                                product.ParameterName = "@clientProduct_id";
                                cmd.Parameters.Add(product);

                                SqlParameter client = new SqlParameter();
                                client.SqlDbType = SqlDbType.VarChar;
                                client.Value = txtclientadd.Text.Trim();
                                client.ParameterName = "@clientClient_id";
                                cmd.Parameters.Add(client);

                            }
                            else
                            {

                                SqlParameter activity = new SqlParameter();
                                activity.SqlDbType = SqlDbType.VarChar;
                                activity.Value = DBNull.Value; 
                                activity.ParameterName = "@clientActivity_id";
                                cmd.Parameters.Add(activity);

                                SqlParameter product = new SqlParameter();
                                product.SqlDbType = SqlDbType.VarChar;

                                product.Value = DBNull.Value;
                                product.ParameterName = "@clientProduct_id";
                                cmd.Parameters.Add(product);

                                SqlParameter client = new SqlParameter();
                                client.SqlDbType = SqlDbType.VarChar;
                                client.Value = DBNull.Value;
                                client.ParameterName = "@clientClient_id";
                                cmd.Parameters.Add(client);


                            }

                            if (ddlrequirement.SelectedIndex == 7)
                            {
                                SqlParameter activity = new SqlParameter();
                                activity.SqlDbType = SqlDbType.VarChar;
                                activity.Value = ddlrightactivity.SelectedValue.ToString();
                                activity.ParameterName = "@RightsActivity_id";
                                cmd.Parameters.Add(activity);

                                SqlParameter product = new SqlParameter();
                                product.SqlDbType = SqlDbType.VarChar;
                                product.Value = ddlrightproduct.SelectedValue.ToString();
                                product.ParameterName = "@RightsProduct_id";
                                cmd.Parameters.Add(product);

                                SqlParameter employee_code = new SqlParameter();
                                employee_code.SqlDbType = SqlDbType.VarChar;
                                employee_code.Value = txtempployeecode.Text.Trim();
                                employee_code.ParameterName = "@rightsempcode";
                                cmd.Parameters.Add(employee_code);

                                SqlParameter rightsdetails = new SqlParameter();
                                rightsdetails.SqlDbType = SqlDbType.VarChar;
                                rightsdetails.Value = txtrightdetails.Text.Trim();
                                rightsdetails.ParameterName = "@rightdetails";
                                cmd.Parameters.Add(rightsdetails);


                            }
                            else
                            {

                                SqlParameter activity = new SqlParameter();
                                activity.SqlDbType = SqlDbType.VarChar;
                                activity.Value = DBNull.Value; ;
                                activity.ParameterName = "@RightsActivity_id";
                                cmd.Parameters.Add(activity);

                                SqlParameter product = new SqlParameter();
                                product.SqlDbType = SqlDbType.VarChar;
                                product.Value = DBNull.Value;
                                product.ParameterName = "@RightsProduct_id";
                                cmd.Parameters.Add(product);

                                SqlParameter employee_code = new SqlParameter();
                                employee_code.SqlDbType = SqlDbType.VarChar;
                                employee_code.Value = DBNull.Value;
                                employee_code.ParameterName = "@Rightsempcode";
                                cmd.Parameters.Add(employee_code);

                                SqlParameter rightsdetails = new SqlParameter();
                                rightsdetails.SqlDbType = SqlDbType.VarChar;
                                rightsdetails.Value = DBNull.Value;
                                rightsdetails.ParameterName = "@Rightdetails";
                                cmd.Parameters.Add(rightsdetails);


      

                            }


                            //if (ddlrequirement.SelectedIndex == 7)
                            //{
                            //    SqlParameter activity = new SqlParameter();
                            //    activity.SqlDbType = SqlDbType.VarChar;
                            //    activity.Value = ddlrightactivity.SelectedValue.ToString();
                            //    activity.ParameterName = "@RightsActivity_id";
                            //    cmd.Parameters.Add(activity);

                            //    SqlParameter product = new SqlParameter();
                            //    product.SqlDbType = SqlDbType.VarChar;
                            //    product.Value = ddlrightproduct.SelectedValue.ToString();
                            //    product.ParameterName = "@RightsProduct_id";
                            //    cmd.Parameters.Add(product);

                            //    SqlParameter employee_code = new SqlParameter();
                            //    employee_code.SqlDbType = SqlDbType.VarChar;
                            //    employee_code.Value = txtempployeecode.Text.Trim();
                            //    employee_code.ParameterName = "@rightsempcode";
                            //    cmd.Parameters.Add(employee_code);

                            //    SqlParameter rightsdetails = new SqlParameter();
                            //    rightsdetails.SqlDbType = SqlDbType.VarChar;
                            //    rightsdetails.Value = txtrightdetails.Text.Trim();
                            //    rightsdetails.ParameterName = "@rightdetails";
                            //    cmd.Parameters.Add(rightsdetails);


                            //}
                            //else
                            //{

                            //    SqlParameter activity = new SqlParameter();
                            //    activity.SqlDbType = SqlDbType.VarChar;
                            //    activity.Value = DBNull.Value; ;
                            //    activity.ParameterName = "@RightsActivity_id";
                            //    cmd.Parameters.Add(activity);

                            //    SqlParameter product = new SqlParameter();
                            //    product.SqlDbType = SqlDbType.VarChar;
                            //    product.Value = DBNull.Value;
                            //    product.ParameterName = "@RightsProduct_id";
                            //    cmd.Parameters.Add(product);

                            //    SqlParameter employee_code = new SqlParameter();
                            //    employee_code.SqlDbType = SqlDbType.VarChar;
                            //    employee_code.Value = DBNull.Value;
                            //    employee_code.ParameterName = "@rightsempcode";
                            //    cmd.Parameters.Add(employee_code);

                            //    SqlParameter rightsdetails = new SqlParameter();
                            //    rightsdetails.SqlDbType = SqlDbType.VarChar;
                            //    rightsdetails.Value = DBNull.Value;
                            //    rightsdetails.ParameterName = "@rightdetails";
                            //    cmd.Parameters.Add(rightsdetails);




                            //}

                            if (ddlrequirement.SelectedIndex == 6)
                            {
                                SqlParameter pass_empname = new SqlParameter();
                                pass_empname.SqlDbType = SqlDbType.VarChar;
                                pass_empname.Value = txtemp_name.Text.Trim();
                                pass_empname.ParameterName = "@pass_empname";
                                cmd.Parameters.Add(pass_empname);

                                SqlParameter passemp_code = new SqlParameter();
                                passemp_code.SqlDbType = SqlDbType.VarChar;
                                passemp_code.Value = txtemp_code.Text.Trim();
                                passemp_code.ParameterName = "@pass_empcode";
                                cmd.Parameters.Add(passemp_code);

                               
                                SqlParameter employee_location = new SqlParameter();
                                employee_location.SqlDbType = SqlDbType.VarChar;
                                employee_location.Value = txtemp_location.Text.Trim();
                                employee_location.ParameterName = "@emp_location";
                                cmd.Parameters.Add(employee_location);

                                

                            }
                            else
                            {

                                SqlParameter pass_empname = new SqlParameter();
                                pass_empname.SqlDbType = SqlDbType.VarChar;
                                pass_empname.Value = DBNull.Value;
                                pass_empname.ParameterName = "@pass_empname";
                                cmd.Parameters.Add(pass_empname);

                                SqlParameter passemp_code = new SqlParameter();
                                passemp_code.SqlDbType = SqlDbType.VarChar;
                                passemp_code.Value = DBNull.Value;
                                passemp_code.ParameterName = "@pass_empcode";
                                cmd.Parameters.Add(passemp_code);


                                SqlParameter employee_location = new SqlParameter();
                                employee_location.SqlDbType = SqlDbType.VarChar;
                                employee_location.Value = DBNull.Value;
                                employee_location.ParameterName = "@emp_location";
                                cmd.Parameters.Add(employee_location);

                                




                            }


                            if (ddlrequirement.SelectedIndex == 4)
                            {
                                SqlParameter domain_empcode = new SqlParameter();
                                domain_empcode.SqlDbType = SqlDbType.VarChar;
                                domain_empcode.Value = txtempdomanicode.Text.Trim();
                                domain_empcode.ParameterName = "@emp_codedomain";
                                cmd.Parameters.Add(domain_empcode);

                                SqlParameter domain_empname = new SqlParameter();
                                domain_empname.SqlDbType = SqlDbType.VarChar;
                                domain_empname.Value = txtdomainempname.Text.Trim();
                                domain_empname.ParameterName = "@emp_namedomain";
                                cmd.Parameters.Add(domain_empname);



                                SqlParameter domain_empemailid = new SqlParameter();
                                domain_empemailid.SqlDbType = SqlDbType.VarChar;
                                domain_empemailid.Value = txtdomainemail.Text.Trim();
                                domain_empemailid.ParameterName = "@emp_emaildomain";
                                cmd.Parameters.Add(domain_empemailid);

                                SqlParameter domain_name = new SqlParameter();
                                domain_name.SqlDbType = SqlDbType.VarChar;
                                domain_name.Value = txtdomainname.Text.Trim();
                                domain_name.ParameterName = "@domain_name";
                                cmd.Parameters.Add(domain_name);




                            }
                            else
                            {

                                SqlParameter domain_empcode = new SqlParameter();
                                domain_empcode.SqlDbType = SqlDbType.VarChar;
                                domain_empcode.Value =  DBNull.Value;
                                domain_empcode.ParameterName = "@emp_codedomain";
                                cmd.Parameters.Add(domain_empcode);

                                SqlParameter domain_empname = new SqlParameter();
                                domain_empname.SqlDbType = SqlDbType.VarChar;
                                domain_empname.Value = DBNull.Value;
                                domain_empname.ParameterName = "@emp_namedomain";
                                cmd.Parameters.Add(domain_empname);



                                SqlParameter domain_empemailid = new SqlParameter();
                                domain_empemailid.SqlDbType = SqlDbType.VarChar;
                                domain_empemailid.Value = DBNull.Value;
                                domain_empemailid.ParameterName = "@emp_emaildomain";
                                cmd.Parameters.Add(domain_empemailid);

                                SqlParameter domain_name = new SqlParameter();
                                domain_name.SqlDbType = SqlDbType.VarChar;
                                domain_name.Value = DBNull.Value;
                                domain_name.ParameterName = "@domain_name";
                                cmd.Parameters.Add(domain_name);




                            }


                            if (ddlrequirement.SelectedIndex == 5)
                            {
                                SqlParameter autoreply_empcode = new SqlParameter();
                                autoreply_empcode.SqlDbType = SqlDbType.VarChar;
                                autoreply_empcode.Value = txtempcodeautoreply.Text.Trim();
                                autoreply_empcode.ParameterName = "@emp_codeautoreply";
                                cmd.Parameters.Add(autoreply_empcode);

                                SqlParameter autoreply_remark = new SqlParameter();
                                autoreply_remark.SqlDbType = SqlDbType.VarChar;
                                autoreply_remark.Value = txtautoreplyremerk.Text.Trim();
                                autoreply_remark.ParameterName = "@Autoreply_remark";
                                cmd.Parameters.Add(autoreply_remark);



                                SqlParameter Auto_replystart = new SqlParameter();
                                Auto_replystart.SqlDbType = SqlDbType.VarChar;
                                Auto_replystart.Value = strDate(txtstartfrom.Text.Trim());
                                Auto_replystart.ParameterName = "@Autoreply_startfrom";
                                cmd.Parameters.Add(Auto_replystart);

                                SqlParameter Auto_replyend = new SqlParameter();
                                Auto_replyend.SqlDbType = SqlDbType.VarChar;
                                Auto_replyend.Value = strDate(txtendto.Text.Trim());
                                Auto_replyend.ParameterName = "@Autoreply_endto";
                                cmd.Parameters.Add(Auto_replyend);



                            }
                            else
                            {

                                SqlParameter autoreply_empcode = new SqlParameter();
                                autoreply_empcode.SqlDbType = SqlDbType.VarChar;
                                autoreply_empcode.Value = DBNull.Value;
                                autoreply_empcode.ParameterName = "@emp_codeautoreply";
                                cmd.Parameters.Add(autoreply_empcode);

                                SqlParameter autoreply_remark = new SqlParameter();
                                autoreply_remark.SqlDbType = SqlDbType.VarChar;
                                autoreply_remark.Value = DBNull.Value;
                                autoreply_remark.ParameterName = "@Autoreply_remark";
                                cmd.Parameters.Add(autoreply_remark);



                                SqlParameter Auto_replystart = new SqlParameter();
                                Auto_replystart.SqlDbType = SqlDbType.VarChar;
                                Auto_replystart.Value = DBNull.Value;
                                Auto_replystart.ParameterName = "@Autoreply_startfrom";
                                cmd.Parameters.Add(Auto_replystart);

                                SqlParameter Auto_replyend = new SqlParameter();
                                Auto_replyend.SqlDbType = SqlDbType.VarChar;
                                Auto_replyend.Value = DBNull.Value;
                                Auto_replyend.ParameterName = "@Autoreply_endto";
                                cmd.Parameters.Add(Auto_replyend);



                            }




                            SqlParameter FileUpload1 = new SqlParameter();
                            FileUpload1.SqlDbType = SqlDbType.VarChar;
                            FileUpload1.Value = UploadAttachment_OnServer1();
                            FileUpload1.ParameterName = "@Attachment1";
                            cmd.Parameters.Add(FileUpload1);

                            SqlParameter FileUpload2 = new SqlParameter();
                            FileUpload2.SqlDbType = SqlDbType.VarChar;
                            FileUpload2.Value = UploadAttachment_OnServer2();
                            FileUpload2.ParameterName = "@Attachment2";
                            cmd.Parameters.Add(FileUpload2);

                            SqlParameter FileUpload3 = new SqlParameter();
                            FileUpload3.SqlDbType = SqlDbType.VarChar;
                            FileUpload3.Value = UploadAttachment_OnServer3();
                            FileUpload3.ParameterName = "@Attachment3";
                            cmd.Parameters.Add(FileUpload3);

                            SqlParameter Suggestion = new SqlParameter();
                            Suggestion.SqlDbType = SqlDbType.VarChar;
                            Suggestion.Value = txtSuggestion.Text.Trim();
                            Suggestion.ParameterName = "@Suggestion";
                            cmd.Parameters.Add(Suggestion);

                            SqlParameter TicketNo = new SqlParameter();
                            TicketNo.SqlDbType = SqlDbType.VarChar;
                            TicketNo.Value = "";
                            TicketNo.ParameterName = "@TicketNo";
                            cmd.Parameters.Add(TicketNo);

                            SqlParameter VarResult = new SqlParameter();
                            VarResult.SqlDbType = SqlDbType.VarChar;
                            //VarResult.Value = lblTicketNo.Text.Trim();
                            VarResult.ParameterName = "@VarResult";
                            VarResult.Size = 200;
                            VarResult.Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(VarResult);

                            sqlcon.Open();

                            int r = cmd.ExecuteNonQuery();

                            RowEffected = Convert.ToString(cmd.Parameters["@VarResult"].Value);

                            sqlcon.Close();

                            if (RowEffected != "")
                            {
                                Lblmsg.Text = "Ticket Successfully Generated.";
                                lblTicketNo.Text = RowEffected;

                                Email();
                                FillGrid();
                                clear();

                            }


                            else
                            {
                                Lblmsg.Text = "Required till Date should not be less then Requested  Date";

                            }
                            

                        }
                       
                    }
                    else
                    {
                        Lblmsg.Text = "Please Enter Required Till Date";
                    }

                    }
                    else
                    {
                        Lblmsg.Text = "Please Select vertical Head";
                    }
              
            }
            else
            {

                Lblmsg.Text = "Please Select the vertical";

            }
        

            }
            
        
      
        




        catch (Exception Ex)
        {
            Lblmsg.Text = Ex.Message;
        }
        finally
        {
            sqlcon.Close();

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
            Lblmsg.Text = ex.Message;
            return "";
        }
    }

    private string UploadAttachment_OnServer2()
    {
        try
        {
            string FileSavePath = "";
            if (FileUpload2.FileName != "")
            {
                string strPath = Server.MapPath("UploadFile/");

                strPath = strPath.Trim();
                filename_Attachment = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss")) + "-" + Convert.ToString(FileUpload2.FileName.Trim());
                filename_Attachment = filename_Attachment.Replace(" ", "_");
                FileSavePath = strPath + filename_Attachment;


                FileUpload2.SaveAs(FileSavePath);
            }
            return FileSavePath;
        }
        catch (Exception ex)
        {
            Lblmsg.Text = ex.Message;
            return "";
        }
    }

    private string UploadAttachment_OnServer3()
    {
        try
        {
            string FileSavePath = "";
            if (FileUpload3.FileName != "")
            {
                string strPath = Server.MapPath("UploadFile/");

                strPath = strPath.Trim();
                filename_Attachment = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss")) + "-" + Convert.ToString(FileUpload3.FileName.Trim());
                filename_Attachment = filename_Attachment.Replace(" ", "_");
                FileSavePath = strPath + filename_Attachment;


                FileUpload3.SaveAs(FileSavePath);
            }
            return FileSavePath;
        }
        catch (Exception ex)
        {
            Lblmsg.Text = ex.Message;
            return "";
        }
    }

    private void Getdata()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlcon;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Sp_EmpInfo";
        cmd.CommandTimeout = 0;

        SqlParameter Emp_Code = new SqlParameter();
        Emp_Code.SqlDbType = SqlDbType.VarChar;
        Emp_Code.Value = Convert.ToInt32(Session["UserId"]);
        Emp_Code.ParameterName = "@Emp_id";
        cmd.Parameters.Add(Emp_Code);

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataTable dt = new DataTable();
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            txtEmpCode.Text = dt.Rows[0]["Emp_Code"].ToString();
            txtfirstname.Text = dt.Rows[0]["Firstname"].ToString();
            txtLastName.Text = dt.Rows[0]["lastname"].ToString();
            ddlcentre.SelectedValue = Session["CentreID"].ToString();
            ddlsubcentre.SelectedValue = Session["SubCentreID"].ToString();
            txtFromDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        }

    }

    protected void txtEmpCode_TextChanged(object sender, EventArgs e)
    {
        Getdata();
    }

    //private void Product()
    //{
    //    sqlcon.Open();

    //    SqlCommand cmd1 = new SqlCommand();
    //    cmd1.Connection = sqlcon;
    //    cmd1.CommandType = CommandType.StoredProcedure;
    //    cmd1.CommandText = "Sp_prod";
    //    cmd1.CommandTimeout = 0;

    //    SqlDataAdapter sqlda1 = new SqlDataAdapter();
    //    sqlda1.SelectCommand = cmd1;

    //    DataTable dt1 = new DataTable();
    //    sqlda1.Fill(dt1);

    //    sqlcon.Close();

    //    if (dt1.Rows.Count > 0)
    //    {
    //        DdlApplication.DataTextField = "Product_Name";
    //        DdlApplication.DataValueField = "Product_id";

    //        DdlApplication.DataSource = dt1;
    //        DdlApplication.DataBind();

    //        DdlApplication.Items.Insert(0, new ListItem("--select--", "0"));
    //        DdlApplication.SelectedIndex = 0;
    //    }

    //}

    private void Get_RequirementList()
    {
        try
        {


            sqlcon.Open();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = sqlcon;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "Get_RequirementList";
            cmd2.CommandTimeout = 0;

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd2;


         
            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlrequirement.DataTextField = "RequirementType";
                ddlrequirement.DataValueField = "RequirementID";

                ddlrequirement.DataSource = dt1;
                ddlrequirement.DataBind();

                ddlrequirement.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlrequirement.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Lblmsg.Text = ex.Message;
        }
        finally
        {
            sqlcon.Close();

        }
    }

    private void Get_vertical()
    {
        try
        {

            sqlcon.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = sqlcon;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "Sp_verticalmaster";
            cmd2.CommandTimeout = 0;

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd2;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlvertical.DataTextField = "vertical_Name";
                ddlvertical.DataValueField = "vertical_id";

                ddlvertical.DataSource = dt1;
                ddlvertical.DataBind();

                ddlvertical.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlvertical.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Lblmsg.Text = ex.Message;
        }
        finally
        {
            sqlcon.Close();

        }
    }


    private void clear()
    {
        //ddlcentre.SelectedIndex = 0;
        //ddlsubcentre.SelectedIndex = 0;
        ddlpriority.SelectedIndex = 0;
        ddlvertical.SelectedIndex = 0;
        ddlverticalHead.SelectedIndex = 0;
        //txtFromDate.Text = "";
        txtToDate.Text = "";
        txtproblem.Text = "";
        txtSuggestion.Text = "";
        ddllocations.SelectedIndex = 0;
        //Lblmsg.Text = "";
        ddlapplication.SelectedIndex = 0;
        ddlrequirement.SelectedIndex = 0;
        



        //GrdView.DataSource = null;
        //GrdView.DataBind();

        //Response.Redirect("Default.aspx");
    }


    private void Get_SubCentreList()
    {
        try
        {
            sqlcon.Open();

            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = sqlcon;
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd4.CommandText = "Sp_SubCentreList123";
            cmd4.CommandTimeout = 0;

            //SqlParameter CentreId = new SqlParameter();
            //CentreId.SqlDbType = SqlDbType.VarChar;
            //CentreId.SqlValue = ddlcentre.SelectedValue.ToString();
            //CentreId.ParameterName = "@centreid";
            //cmd4.Parameters.Add(CentreId);

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

                ddlsubcentre.Items.Insert(0, new ListItem("--ALL--", "0"));
                ddlsubcentre.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Lblmsg.Text = ex.Message;

        }
        finally
        {
            sqlcon.Close();

        }
    }

    protected void FillGrid()
    {
        try
        {
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_SSU_RequestSTATUS";
            sqlcmd.CommandTimeout = 0;

            SqlParameter Add_By = new SqlParameter();
            Add_By.SqlDbType = SqlDbType.VarChar;
            Add_By.Value = Session["UserId"].ToString();    //Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);     
            Add_By.ParameterName = "@UserID";
            sqlcmd.Parameters.Add(Add_By);

            //SqlParameter Centre_ID = new SqlParameter();
            //Centre_ID.SqlDbType = SqlDbType.VarChar;
            //Centre_ID.Value = (Session["CentreID"]).ToString();    //Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);  
            //Centre_ID.ParameterName = "@centreid";
            //sqlcmd.Parameters.Add(Centre_ID);

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = sqlcmd;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                Lblmsg.Text = "Total Records Found : " + dt1.Rows.Count;

                grdGrid.DataSource = dt1;
                grdGrid.DataBind();
            }
            else
            {
                Lblmsg.Text = "No Records Found...!!!";

                grdGrid.DataSource = null;
                grdGrid.DataBind();
            }
        }
        catch (Exception ex)
        {
            Lblmsg.Text = ex.Message;
        }
        finally
        {
            sqlcon.Close();

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
            cmd2.CommandText = "Sp_CentreList";
            cmd2.CommandTimeout = 0;


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

                ddlcentre.Items.Insert(0, new ListItem("--ALL--", "0"));
                ddlcentre.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Lblmsg.Text = ex.Message;
        }
        finally
        {
            sqlcon.Close();

        }
    }

    private void Get_verticalhead_new()
    {
        try
        {
            sqlcon.Open();

            SqlCommand cmd4 = new SqlCommand();
            cmd4.Connection = sqlcon;
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd4.CommandText = "Sp_vertical_head";
            cmd4.CommandTimeout = 0;

            //SqlParameter verticalId = new SqlParameter();
            //verticalId.SqlDbType = SqlDbType.VarChar;
            //verticalId.SqlValue = ddlvertical.SelectedValue.ToString();
            //verticalId.ParameterName = "@vertical_id";
            //cmd4.Parameters.Add(verticalId);

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd4;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlverticalHead.DataTextField = "vertical_head";
                ddlverticalHead.DataValueField = "emp_id";

                ddlverticalHead.DataSource = dt1;
                ddlverticalHead.DataBind();

                ddlverticalHead.Items.Insert(0, new ListItem("--ALL--", "0"));
                ddlverticalHead.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Lblmsg.Text = ex.Message;

        }
        finally
        {
            sqlcon.Close();

        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

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

    protected void Validation()
    {

        BtnSave.Attributes.Add("onclick", "javascript:return ClientValidate(source, arguments);");
        BtnSave.Attributes.Add("onclick", "javascript:return  funValidateFromToDate();");
      
       
    }
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        txtproblem.Text = "";
        txtSuggestion.Text = "";
        ddllocations.SelectedIndex = 0;
        ddlpriority.SelectedIndex = 0;
        ddlreqtype.SelectedIndex = 0;
        ddlrequirement.SelectedIndex = 0;
        ddlvertical.SelectedIndex = 0;
        ddlverticalHead.SelectedIndex = 0;
        ddlapplication.SelectedIndex = 0;
        Lblmsg.Text = "";

    }

    ////private void Sp_get_approvalAuthority_list()
    ////{
    ////    try
    ////    {
    ////        sqlcon.Open();

    ////        SqlCommand cmd4 = new SqlCommand();
    ////        cmd4.Connection = sqlcon;
    ////        cmd4.CommandType = CommandType.StoredProcedure;
    ////        cmd4.CommandText = "Sp_get_approvalAuthority_list";
    ////        cmd4.CommandTimeout = 0;

    ////        SqlParameter vertical = new SqlParameter();
    ////        vertical.SqlDbType = SqlDbType.VarChar;
    ////        vertical.SqlValue = ddlvertical.SelectedValue.ToString();
    ////        vertical.ParameterName = "@vertical";
    ////        cmd4.Parameters.Add(vertical);

    ////        SqlDataAdapter sqlda1 = new SqlDataAdapter();
    ////        sqlda1.SelectCommand = cmd4;

    ////        DataTable dt1 = new DataTable();
    ////        sqlda1.Fill(dt1);

    ////        sqlcon.Close();

    ////        if (dt1.Rows.Count > 0)
    ////        {
    ////            ddlverticalHead.DataTextField = "Full_name";
    ////            ddlverticalHead.DataValueField = "Emp_id";

    ////            ddlverticalHead.DataSource = dt1;
    ////            ddlverticalHead.DataBind();

    ////            //ddlverticalHead.Items.Insert(0, new ListItem("--ALL--", "A"));
    ////            //ddlverticalHead.SelectedIndex = 0;
    ////        }
    ////    }
    ////    catch (Exception ex)
    ////    {
    ////        Lblmsg.Text = ex.Message;

    ////    }
    ////}


    //protected void ddlvertical_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    Get_verticalhead_new();
    //}



    //protected void ddlcentre_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    Get_SubCentreList();
    //}

    //private void Get_SubCentreList()
    //{
    //    try
    //    {
    //        sqlcon.Open();

    //        SqlCommand cmd4 = new SqlCommand();
    //        cmd4.Connection = sqlcon;
    //        cmd4.CommandType = CommandType.StoredProcedure;
    //        cmd4.CommandText = "Sp_SubCentreList";
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

    //            ddlsubcentre.Items.Insert(0, new ListItem("--ALL--", "A"));
    //            ddlsubcentre.SelectedIndex = 0;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Lblmsg.Text = ex.Message;

    //    }
    //}

    //protected void ddlcentre_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    Get_SubCentreList();
    //}

    public bool FunctioncompareDate()
    {

        DateTime sRequestdate;
        DateTime sRequiredtillDate;
        sRequestdate = Convert.ToDateTime(connobj.strDate(txtFromDate.Text.ToString().Trim()));
        sRequiredtillDate = Convert.ToDateTime(connobj.strDate(txtToDate.Text.ToString().Trim()));
        bool bReturn = true;
        if (sRequestdate > sRequiredtillDate)
        {
            bReturn = false;
        }
        else
        {
            bReturn = true;


        }
        return bReturn;
    }
    protected void ddlreqtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlreqtype.SelectedIndex==1)
        {
            Get_softwarerequirement1();
        }
        else {

            Get_softwarerequirement2();
        
        }
        


    }


    private void Get_softwarerequirement1()
    {
        try
        {

            sqlcon.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = sqlcon;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "ssurequirement11";
            cmd2.CommandTimeout = 0;

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd2;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlrequirement.DataTextField = "Requirementtype";
                ddlrequirement.DataValueField = "Requirementid";

                ddlrequirement.DataSource = dt1;
                ddlrequirement.DataBind();

                ddlrequirement.Items.Insert(0, new ListItem("--ALL--", "0"));
                ddlrequirement.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Lblmsg.Text = ex.Message;
        }
        finally
        {
            sqlcon.Close();

        }
    }




    private void Get_softwarerequirement2()
    {
        try
        {

            sqlcon.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = sqlcon;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "ssurequirement12";
            cmd2.CommandTimeout = 0;

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd2;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlrequirement.DataTextField = "Requirementtype";
                ddlrequirement.DataValueField = "Requirementid";

                ddlrequirement.DataSource = dt1;
                ddlrequirement.DataBind();

                ddlrequirement.Items.Insert(0, new ListItem("--ALL--", "0"));
                ddlrequirement.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Lblmsg.Text = ex.Message;
        }
        finally
        {
            sqlcon.Close();

        }
    }

    private void Get_Activity()
    {
        try
        {

            sqlcon.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = sqlcon;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "SSU_Activity";
            cmd2.CommandTimeout = 0;

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd2;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlactivity.DataTextField = "Activity_name";
                ddlactivity.DataValueField = "Activity_id";

                ddlactivity.DataSource = dt1;
                ddlactivity.DataBind();

                ddlactivity.Items.Insert(0, new ListItem("--ALL--", "0"));
                ddlactivity.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Lblmsg.Text = ex.Message;
        }
        finally
        {
            sqlcon.Close();

        }
    }


    private void Get_ActivityclientAdd()
    {
        try
        {

            sqlcon.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = sqlcon;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "SSU_Activity";
            cmd2.CommandTimeout = 0;

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd2;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlclientactivity.DataTextField = "Activity_name";
                ddlclientactivity.DataValueField = "Activity_id";

                ddlclientactivity.DataSource = dt1;
                ddlclientactivity.DataBind();

                ddlclientactivity.Items.Insert(0, new ListItem("--ALL--", "0"));
                ddlclientactivity.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Lblmsg.Text = ex.Message;
        }
        finally
        {
            sqlcon.Close();

        }
    }


    private void Get_Activityrights()
    {
        try
        {

            sqlcon.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = sqlcon;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "SSU_Activity";
            cmd2.CommandTimeout = 0;

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd2;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlrightactivity.DataTextField = "Activity_name";
                ddlrightactivity.DataValueField = "Activity_id";

                ddlrightactivity.DataSource = dt1;
                ddlrightactivity.DataBind();

                ddlrightactivity.Items.Insert(0, new ListItem("--ALL--", "0"));
                ddlrightactivity.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Lblmsg.Text = ex.Message;
        }
        finally
        {
            sqlcon.Close();

        }
    }





    private void Get_product()
    {
        try
        {

            sqlcon.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = sqlcon;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "SSU_Product";
            cmd2.CommandTimeout = 0;


            SqlParameter product_id = new SqlParameter();
            product_id.SqlDbType = SqlDbType.VarChar;
            product_id.Value = ddlactivity.SelectedValue.ToString();  //Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);     
            product_id.ParameterName = "@activity_id";
            cmd2.Parameters.Add(product_id);

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd2;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlproduct.DataTextField = "product_name";
                ddlproduct.DataValueField = "product_id";

                ddlproduct.DataSource = dt1;
                ddlproduct.DataBind();

                ddlproduct.Items.Insert(0, new ListItem("--ALL--", "0"));
                ddlproduct.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Lblmsg.Text = ex.Message;
        }
        finally
        {
            sqlcon.Close();

        }
    }
    private void Get_productcliendadd()
    {
        try
        {

            sqlcon.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = sqlcon;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "SSU_Product";
            cmd2.CommandTimeout = 0;


            SqlParameter product_id = new SqlParameter();
            product_id.SqlDbType = SqlDbType.VarChar;
            product_id.Value = ddlclientactivity.SelectedValue.ToString();  //Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);     
            product_id.ParameterName = "@activity_id";
            cmd2.Parameters.Add(product_id);

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd2;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlclientproduct.DataTextField = "product_name";
                ddlclientproduct.DataValueField = "product_id";

                ddlclientproduct.DataSource = dt1;
                ddlclientproduct.DataBind();

                ddlclientproduct.Items.Insert(0, new ListItem("--ALL--", "0"));
                ddlclientproduct.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Lblmsg.Text = ex.Message;
        }
        finally
        {
            sqlcon.Close();

        }
    }
    private void Get_productrights()
    {
        try
        {

            sqlcon.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = sqlcon;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "SSU_Product";
            cmd2.CommandTimeout = 0;


            SqlParameter product_id = new SqlParameter();
            product_id.SqlDbType = SqlDbType.VarChar;
            product_id.Value = ddlrightactivity.SelectedValue.ToString();  //Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);     
            product_id.ParameterName = "@activity_id";
            cmd2.Parameters.Add(product_id);

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd2;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlrightproduct.DataTextField = "product_name";
                ddlrightproduct.DataValueField = "product_id";

                ddlrightproduct.DataSource = dt1;
                ddlrightproduct.DataBind();

                ddlrightproduct.Items.Insert(0, new ListItem("--ALL--", "0"));
                ddlrightproduct.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Lblmsg.Text = ex.Message;
        }
        finally
        {
            sqlcon.Close();

        }
    }



    private void Get_Client()
    {
        try
        {

            sqlcon.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = sqlcon;
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "SSU_client";
            cmd2.CommandTimeout = 0;



            SqlParameter product_id = new SqlParameter();
            product_id.SqlDbType = SqlDbType.VarChar;
            product_id.Value = ddlproduct.SelectedValue.ToString();  //Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);     
            product_id.ParameterName = "@product_id";
            cmd2.Parameters.Add(product_id);


            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd2;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            if (dt1.Rows.Count > 0)
            {
                ddlclient.DataTextField = "client_name";
                ddlclient.DataValueField = "client_id";

                ddlclient.DataSource = dt1;
                ddlclient.DataBind();

                ddlclient.Items.Insert(0, new ListItem("--ALL--", "0"));
                ddlclient.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Lblmsg.Text = ex.Message;
        }
        finally
        {
            sqlcon.Close();

        }
    }



    protected void ddlrequirement_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlrequirement.SelectedValue == "11" || ddlrequirement.SelectedValue == "12")
        {

            pnlStatus.Visible = true;
            Pnlclient.Visible = true;
        }
        else if (ddlrequirement.SelectedValue == "1")
        {
            Pnlclientadd.Visible = true;
             pnlStatus.Visible = false;
             pnlrightasiignment.Visible =false;
             Pnldomain.Visible = false;
             pnlpassword.Visible = false;
             pnlautoreply.Visible = false;


        }
        else if (ddlrequirement.SelectedValue == "7")

        {
            pnlrightasiignment.Visible = true;
            pnlStatus.Visible = false; 
            Pnlclientadd.Visible = false;
            pnlStatus.Visible = false;
            Pnldomain.Visible = false;
            pnlpassword.Visible = false;
            pnlautoreply.Visible = false;


        }
        else if (ddlrequirement.SelectedValue == "4")
        {
            pnlrightasiignment.Visible = false;
            pnlStatus.Visible = false;
            Pnlclientadd.Visible = false;
            pnlStatus.Visible = false;
            Pnldomain.Visible = true;
            pnlpassword.Visible = false;
            pnlautoreply.Visible = false;

        }

        else if (ddlrequirement.SelectedValue == "6")
        {
            pnlrightasiignment.Visible = false;
            pnlStatus.Visible = false;
            Pnlclientadd.Visible = false;
            pnlStatus.Visible = false;
            Pnldomain.Visible = false;
            pnlpassword.Visible = true;
            pnlautoreply.Visible = false;
           
        }
        else if (ddlrequirement.SelectedValue == "5")
        {
            pnlrightasiignment.Visible = false;
            pnlStatus.Visible = false;
            Pnlclientadd.Visible = false;
            pnlStatus.Visible = false;
            Pnldomain.Visible = false;
            pnlpassword.Visible = false;
            pnlautoreply.Visible =true ;
        }


        else if(ddlrequirement.SelectedValue == "2")
        {

            Pnlclient.Visible = true;
            pnlStatus.Visible = false;
        
        }
    }

    protected void ddlactivity_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_product();
        pnlStatus.Visible = true;
      
    }


    //protected void ddlcentre_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //Get_SubCentreList();
    //}
    protected void ddlproduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_Client();
        pnlStatus.Visible = true;
    }
    protected void ddlclientactivity_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_productcliendadd();
        pnlautoreply.Visible = false;
        Pnldomain.Visible = false;
        pnlpassword.Visible = false;
        pnlrightasiignment.Visible = false;
        Pnlclientadd.Visible = true;
       




    }


    protected void ddlrightactivity_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_productrights();
        pnlautoreply.Visible = false;
        Pnldomain.Visible = false;
        pnlpassword.Visible = false;
        Pnlclientadd.Visible = false;
        pnlrightasiignment.Visible = true;
       


    }
    
}
