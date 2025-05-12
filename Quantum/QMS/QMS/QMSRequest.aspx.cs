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
using System.Threading;

public partial class QMS_QMS_QMSRequest : System.Web.UI.Page
{


    CCommon objConn = new CCommon();
    SqlConnection sqlcon;

    string filename_Attachment;
    string Emailid;
    string RowEffected;
    public string[] arr;
    int Length = 0;

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
        Application_start();

        if (!IsPostBack)
        {
            grdExportTicket.Visible = false;

            Validate();
            Getdata();
            GetProblemType();
            //Get_QMS_Department();
            Fill_Grid();
        }
    }

    private void GetProblemType()
    {
        sqlcon.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlcon;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetProblemType";
        cmd.CommandTimeout = 0;

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataTable dt = new DataTable();
        da.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlProblemType.DataSource = dt;
            ddlProblemType.DataTextField = "QueryName";
            ddlProblemType.DataValueField = "QMS_ID";
            ddlProblemType.DataBind();

            ddlProblemType.Items.Insert(0, new ListItem("--Select--", "0"));
            //    ddlQMSDepartment.DataSource = dt;
            //    ddlQMSDepartment.DataTextField = "QMS_Dept_Name";
            //    ddlQMSDepartment.DataValueField = "QMS_Dept_ID";
            //    ddlQMSDepartment.DataBind();

            //    ddlQMSDepartment.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }

    void Application_start()
    {
        Thread thread = new Thread(CronThread);
        thread.IsBackground = true;
        thread.Start();


    }

    private void CronThread()
    {
        while (true)
        {
            Thread.Sleep(TimeSpan.FromMinutes(1));
            // Do something every half hour

            // DelayEmail();


        }
    }

    protected void Validate()
    {
        btnSave.Attributes.Add("onclick", "javascript:return Validate();");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/OrganizationTree.aspx");
    }

    private void Getdata()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlcon;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Get_QMS_EmpInfo";
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
            hdnEmpCode.Value = dt.Rows[0]["Emp_code"].ToString();   //New Added
            txtUserName.Text = dt.Rows[0]["Fullname"].ToString();
        }
    }

    protected void Get_QMS_Department()
    {
        sqlcon.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlcon;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Get_QMS_Dept_details";
        cmd.CommandTimeout = 0;

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataTable dt = new DataTable();
        da.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            //    ddlQMSDepartment.DataSource = dt;
            //    ddlQMSDepartment.DataTextField = "QMS_Dept_Name";
            //    ddlQMSDepartment.DataValueField = "QMS_Dept_ID";
            //    ddlQMSDepartment.DataBind();

            //    ddlQMSDepartment.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }

    protected void Get_ProblemType()
    {
        sqlcon.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlcon;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Get_QMS_Problem_Details";
        cmd.CommandTimeout = 0;

        SqlParameter Dept_ID = new SqlParameter();
        Dept_ID.SqlDbType = SqlDbType.Int;
        Dept_ID.Value = Int32.Parse("");//ddlQMSDepartment.SelectedValue);
        Dept_ID.ParameterName = "@QMS_Dept_ID";
        cmd.Parameters.Add(Dept_ID);

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataTable dt = new DataTable();
        da.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlProblemType.DataSource = dt;
            ddlProblemType.DataTextField = "Problem_detail";
            ddlProblemType.DataValueField = "Problem_Type_ID";
            ddlProblemType.DataBind();

            ddlProblemType.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }

    protected void Get_QMS_User()
    {
        sqlcon.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlcon;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Get_QMS_User";
        cmd.CommandTimeout = 0;

        SqlParameter QMS_Dept_ID = new SqlParameter();
        QMS_Dept_ID.SqlDbType = SqlDbType.Int;
        QMS_Dept_ID.Value = "";// ddlQMSDepartment.SelectedValue;
        QMS_Dept_ID.ParameterName = "@QMS_Dept_ID";
        cmd.Parameters.Add(QMS_Dept_ID);

        //New Added
        SqlParameter Problem_Type_ID = new SqlParameter();
        Problem_Type_ID.SqlDbType = SqlDbType.Int;
        Problem_Type_ID.Value = ddlProblemType.SelectedValue;
        Problem_Type_ID.ParameterName = "@Problem_Type_ID";
        cmd.Parameters.Add(Problem_Type_ID);
        //END

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataTable dt = new DataTable();
        da.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlQMSUser.DataSource = dt;
            ddlQMSUser.DataTextField = "Fullname";
            ddlQMSUser.DataValueField = "Emp_Code";
            ddlQMSUser.DataBind();

            // ddlQMSUser.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }

    protected void ddlQMSDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Get_ProblemType();
            ddlQMSUser.Items.Clear();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void ddlProblemType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            // Get_QMS_User();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
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
            lblMsg.Text = ex.Message;
            return "";
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        InsertData();
        Email();
        ClearControl();

    }

    private void Email()
    {
        //Emailid = ".Hande@pamac.com";

        Emailid = "Software.support@pamac.com";



        //END

        string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
        string strhh = strTime.Remove(2);
        string strmm = strTime.Remove(0, 3);

        string Current = System.DateTime.Now.Date.ToString().Remove(10);

        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient("69.64.70.36", 25);

            mail.From = new MailAddress("calculus@pamac.com", "PAMAC QMS");

            mail.To.Add(Emailid);


            //mail.Bcc.Add(new MailAddress("nitin.pednekar@pamac.com", "Nitin Pednekar"));
                      mail.CC.Add(new MailAddress("software.support@pamac.com","Software Team"));
          


            mail.Subject = "Quantam QMS : QMS Query ";

            string strBody =
                    "<html><body><font color=\"Navy\" style=\"font-style=Italic;font-weight=bold\">" +

                    "<P>                                                                                               </P>" +
                    " <P>Dear PAMACian,</P>" +
                    "<P>                                                                                         </P>" +
                    "<P>This is in response to the Transaction " + RowEffected + " request raised in the PAMAC QMS to which your response has been delayed.</P>" +
                    "<P>                                                                                         </P>" +
                    " <P>This calls for your immediate attention & resolution at the earliest as per the defined TAT.</P>" +
                    "<P>                                                                                        </P>" +
                    "<P>“This is computer generated mail and hence do not reply to this mail”  </P>" +
                    "<P>                                                                                         </P>" +
                    "<P>Regards,</P>" +
                    "<P>PAMAC QMS</P> " +

                    " </font></html></body>";
            mail.Body = strBody;

            mail.IsBodyHtml = true;

            smtp.Port = 25;
            smtp.Credentials = new System.Net.NetworkCredential("calculus@pamac.com", "qw@!34GH");
            smtp.EnableSsl = false;

            smtp.Send(mail);
            //lblMsg.Text = Emailid + " Email successfully sent. " + User;
            //lblTicketNo.Text = RowEffected;

            //StatusLapsed(TransactionId);
        }

        catch (Exception ex)
        {
            lblMsg.Text = "Email Failed." + ex.Message;
        }

    }



    private void Email12()
    {
        //Emailid = ".Hande@pamac.com";




        Emailid = hdnemail.Value;



        //END

        string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
        string strhh = strTime.Remove(2);
        string strmm = strTime.Remove(0, 3);

        string Current = System.DateTime.Now.Date.ToString().Remove(10);

        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient("69.64.70.36", 25);

            mail.From = new MailAddress("calculus@pamac.com", "PAMAC QMS");

            mail.To.Add(Emailid);


            //mail.Bcc.Add(new MailAddress("nitin.pednekar@pamac.com", "Nitin Pednekar"));
            mail.CC.Add(new MailAddress("edp@pamac.com", "Software Team"));



            mail.Subject = "Quantam  : Salary related Query ";

            string strBody =
                    "<html><body><font color=\"Navy\" style=\"font-style=Italic;font-weight=bold\">" +

                    "<P>                                                                                               </P>" +
                    " <P>Dear PAMACian,</P>" +
                    "<P>                                                                                         </P>" +
                    "<P>Emp_code :" + hdnemp_code.Value + " </P>" +
                    "<P>                                                                                         </P>" +
                    " <P>Fullname : " + hdnfullname.Value + " </P>" +
                                                                                                       
                    "<P>Amount :" + hdnamount.Value + "   </P>" +
                   "<P>MonthYear: " + hdnyrmonth.Value + "   </P>" +
                    "<P>If U have any Query cal reply Mangesh Rane (mangesh.rane@pamac.com) </P>" +
                    "<P>                                                                                         </P>" +
                    "<P>Regards,</P>" +
                    "<P>PAMAC</P> " +

                    " </font></html></body>";
            mail.Body = strBody;

            mail.IsBodyHtml = true;

            smtp.Port = 25;
            smtp.Credentials = new System.Net.NetworkCredential("calculus@pamac.com", "qw@!34GH");
            smtp.EnableSsl = false;

            smtp.Send(mail);
            //lblMsg.Text = Emailid + " Email successfully sent. " + User;
            //lblTicketNo.Text = RowEffected;

            //StatusLapsed(TransactionId);
        }

        catch (Exception ex)
        {
            lblMsg.Text = "Email Failed." + ex.Message;
        }

    }
   
   


    protected void InsertData()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Insert_QMS_Ticket_InfoNew";
            cmd.CommandTimeout = 0;

            if (lblTicketNo.Text == "")
            {
                SqlParameter TicketNo = new SqlParameter();
                TicketNo.SqlDbType = SqlDbType.VarChar;
                TicketNo.Value = "";
                TicketNo.ParameterName = "@TicketNo";
                cmd.Parameters.Add(TicketNo);
            }

            else
            {
                SqlParameter TicketNo = new SqlParameter();
                TicketNo.SqlDbType = SqlDbType.VarChar;
                TicketNo.Value = lblTicketNo.Text;
                TicketNo.ParameterName = "@TicketNo";
                cmd.Parameters.Add(TicketNo);
            }

            SqlParameter UserName = new SqlParameter();
            UserName.SqlDbType = SqlDbType.VarChar;
            UserName.Value = txtUserName.Text.ToString().Trim();
            UserName.ParameterName = "@UserName";
            cmd.Parameters.Add(UserName);

            //SqlParameter Department = new SqlParameter();
            //Department.SqlDbType = SqlDbType.VarChar;
            //Department.Value = "";//ddlDepartment.SelectedItem.ToString().Trim();
            //Department.ParameterName = "@Department";
            //cmd.Parameters.Add(Department);

            //SqlParameter QMS_Department = new SqlParameter();
            //QMS_Department.SqlDbType = SqlDbType.VarChar;
            //QMS_Department.Value = "";//ddlQMSDepartment.SelectedValue.ToString().Trim();
            //QMS_Department.ParameterName = "@QMS_Dept_ID";
            //cmd.Parameters.Add(QMS_Department);

            SqlParameter QMS_User = new SqlParameter();
            QMS_User.SqlDbType = SqlDbType.VarChar;
            QMS_User.Value = "P-00001";
            QMS_User.ParameterName = "@QMS_User";
            cmd.Parameters.Add(QMS_User);

            SqlParameter ProblemType = new SqlParameter();
            ProblemType.SqlDbType = SqlDbType.VarChar;
            ProblemType.Value = lblTicketNo.Text == "" ? ddlProblemType.SelectedValue.ToString().Trim() : ddlProblemType.SelectedItem.ToString().Trim();
            ProblemType.ParameterName = "@Problem_Type_ID";
            cmd.Parameters.Add(ProblemType);

            SqlParameter Remark = new SqlParameter();
            Remark.SqlDbType = SqlDbType.VarChar;
            Remark.Value = txtRemark.Text.ToString().Trim();
            Remark.ParameterName = "@Remark";
            cmd.Parameters.Add(Remark);

            SqlParameter FileUpload = new SqlParameter();
            FileUpload.SqlDbType = SqlDbType.VarChar;
            FileUpload.Value = UploadAttachment_OnServer();
            FileUpload.ParameterName = "@AttachmentPath";
            cmd.Parameters.Add(FileUpload);

            SqlParameter Add_By = new SqlParameter();
            Add_By.SqlDbType = SqlDbType.VarChar;
            Add_By.Value = Session["UserId"].ToString(); //Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId); 
            Add_By.ParameterName = "@UserID";
            cmd.Parameters.Add(Add_By);

            SqlParameter Centre_ID = new SqlParameter();
            Centre_ID.SqlDbType = SqlDbType.VarChar;
            Centre_ID.Value = (Session["CentreID"]).ToString(); //Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId); 
            Centre_ID.ParameterName = "@BranchID";
            cmd.Parameters.Add(Centre_ID);

            SqlParameter VarResult = new SqlParameter();
            VarResult.SqlDbType = SqlDbType.VarChar;
            //VarResult.Value = lblTicketNo.Text.Trim();
            VarResult.ParameterName = "@VarResult";
            VarResult.Size = 200;
            VarResult.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(VarResult);

            //New Added
            SqlParameter Emp_Code = new SqlParameter();
            Emp_Code.SqlDbType = SqlDbType.VarChar;
            Emp_Code.Value = hdnEmpCode.Value;
            Emp_Code.ParameterName = "@Emp_Code";
            cmd.Parameters.Add(Emp_Code);
            //End 

            sqlcon.Open();
            cmd.ExecuteNonQuery();

            RowEffected = Convert.ToString(cmd.Parameters["@VarResult"].Value);

            sqlcon.Close();

            if (RowEffected != "")
            {
                lblMsg.Text = "Ticket Successfully Generated.";
                lblTicketNo.Text = RowEffected;

                Fill_Grid();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void Fill_Grid()
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        sqlcon.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlcon;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Get_QMS_Ticket_Info12New1";
        cmd.CommandTimeout = 0;

        SqlParameter Add_By = new SqlParameter();
        Add_By.SqlDbType = SqlDbType.VarChar;
        Add_By.Value = (Session["UserId"]).ToString();    //Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).UserId);     
        Add_By.ParameterName = "@UserID";
        cmd.Parameters.Add(Add_By);

        SqlParameter Centre_ID = new SqlParameter();
        Centre_ID.SqlDbType = SqlDbType.VarChar;
        Centre_ID.Value = (Session["CentreID"]).ToString();    //Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);  
        Centre_ID.ParameterName = "@BranchID";
        cmd.Parameters.Add(Centre_ID);

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataTable dt = new DataTable();
        da.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            grdTicketFill.DataSource = dt;
            grdTicketFill.DataBind();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LinkButton lnkfollowup = (LinkButton)grdTicketFill.Rows[i].FindControl("lnkfollowup");
                LinkButton lnkClose = (LinkButton)grdTicketFill.Rows[i].FindControl("lnkClose");
               // lnkClose.Text = dt.Rows[i][0].ToString();

                if ("Close" == dt.Rows[i]["TicketStatus"].ToString())
                {
                    lnkClose.Enabled = false;
                    lnkClose.ForeColor = System.Drawing.Color.BlanchedAlmond;

                }
                else
                {
                    lnkClose.Enabled = true;

                }

            }
            grdExportTicket.DataSource = dt;
            grdExportTicket.DataBind();

            btnExport.Visible = true;
        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        Generate_ExcelFile();
    }

    public override void VerifyRenderingInServerForm(Control control)
    { }

    private void Generate_ExcelFile()
    {
        grdExportTicket.Visible = true;

        String attachment = "attachment; filename=TicketDetailsReport.xls";

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
                        "<b><font size='2' color='blue'>Ticket Details Report.</font></b> <br/>";
        tblCell1.CssClass = "SuccessMessage";
        tblRow.Cells.Add(tblCell);
        tblRow1.Cells.Add(tblCell1);
        tblRow.Height = 20;
        tblSpace.Rows.Add(tblRow);
        tblSpace.Rows.Add(tblRow1);
        tblSpace.RenderControl(htw);

        Table tbl = new Table();
        grdExportTicket.EnableViewState = false;
        grdExportTicket.GridLines = GridLines.Both;
        grdExportTicket.RenderControl(htw);
        Response.Write(sw.ToString());

        Response.End();
    }

    protected void ClearControl()
    {
        //ddlDepartment.SelectedIndex = 0;
        //ddlQMSDepartment.SelectedIndex = 0;
        ddlQMSUser.SelectedIndex = 0;
        ddlProblemType.SelectedIndex = 0;
       
        txtRemark.Text = "";
        FileUpload1.Attributes.Clear();
        //ddlDepartment.SelectedValue = "";

    }

    

    //private void Email()
    //{
    //    string User = ddlQMSUser.SelectedValue.ToString();
    //    string TransactionId = lblTicketNo.Text.Trim();

    //    if (User == "P-00114")
    //    {
    //        Emailid = "Mangesh.Hande@pamac.com";
    //    }
    //    else if (User == "P-00004")
    //    {
    //        Emailid = "shankar.devare@pamac.com";
    //    }
    //    else if (User == "P-02191" || User == "P-51410")
    //    {
    //        Emailid = "hr.support@pamac.com";
    //    }
    //    else if (User == "P-01632")
    //    {
    //        Emailid = "yogesh.mohite@pamac.com";
    //    }
    //    else if (User == "P-52733")
    //    {
    //        Emailid = "praveen.rathod@pamac.com";
    //    }
    //    //New Added
    //    else if (User == "P-00046" || User == "P-51629")
    //    {
    //        Emailid = "admin.support@pamac.com";
    //    }
    //    else if (User == "P-01746")
    //    {
    //        Emailid = "amol.jadhav@pamac.com";
    //    }
    //    else if (User == "P-00033")
    //    {
    //        Emailid = "ashpak.pinjari@pamac.com";
    //    }
    //    else if (User == "P-50936")
    //    {
    //        Emailid = "accounts@pamac.com";
    //    }
    //    else if (User == "P-49506")
    //    {
    //        Emailid = "Rupesh.Zodage@pamac.com";
    //    }
    //    //END

    //    //Emailid = "ritika.vishwakarma@pamac.com";

    //    string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
    //    string strhh = strTime.Remove(2);
    //    string strmm = strTime.Remove(0, 3);

    //    string Current = System.DateTime.Now.Date.ToString().Remove(10);

    //    try
    //    {
    //        MailMessage mail = new MailMessage();
    //        SmtpClient smtp = new SmtpClient("69.64.70.36", 25);

    //        mail.From = new MailAddress("calculus@pamac.com", "PAMAC QMS");

    //        mail.To.Add(Emailid);

    //        if ("1015" == Session["Clusterid"].ToString())
    //        {
    //            if (ddlQMSDepartment.SelectedValue.ToString() == "1")
    //            {
    //                // mail.CC.Add(new MailAddress("north.hrsupport@pamac.com", "Sashi Kumar"));
    //                mail.Bcc.Add(new MailAddress("Sarita.Minj@pamac.com", "Sarita Minj"));
    //                //  mail.CC.Add(new MailAddress("Rupesh.Zodage@pamac.com","Rupesh Zodage"));
    //            }
    //            else if (ddlQMSDepartment.SelectedValue.ToString() == "2")
    //            {
    //                mail.CC.Add("Sunil.Kumar@pamac.com");
    //            }

    //        }
    //        else if ("1014" == Session["Clusterid"].ToString())
    //        {
    //            if (ddlQMSDepartment.SelectedValue.ToString() == "1")
    //            {
    //                mail.CC.Add("Gopal.Dhar@pamac.com");

    //            }
    //            //else if (ddlQMSDepartment.SelectedValue.ToString() == "2")
    //            //{
    //            //    mail.CC.Add("Nandan.Chaterjee@pamac.com");
    //            //}

    //        }
    //        else if ("1013" == Session["Clusterid"].ToString())
    //        {
    //            //if (ddlQMSDepartment.SelectedValue.ToString() == "1")
    //            //{
    //            //    // mail.CC.Add("Elumalai.K@pamac.com");

    //            //}

    //        }
    //        //if (ddlQMSDepartment.SelectedValue.ToString() == "1")
    //        //{
    //        //    mail.CC.Add(new MailAddress("ritika.vishwakarma@pamac.com", "Ritika Vishwakarma"));
    //        //}
    //        mail.Subject = "QMS - Query ";

    //        string strBody =
    //                   "<html><body><font color=\"Navy\" style=\"font-style=Italic;font-weight=bold\">" +

    //                   "<P>                                                                                               </P>" +
    //                   "<P>Dear PAMACian,</P>" +
    //                   "<P>                                                                                         </P>" +
    //                   "<P>This is to notify you for a query raised in QMS with the inferred Transaction ID  " + TransactionId + ".</P>" +
    //                   "<P>                                                                                         </P>" +
    //                   "<P>Request you to provide immediate attention to the same & resolve it at the earliest as per the defined TAT .</P>" +
    //                   "<P>                                                                                        </P>" +
    //                   "<P>*This is an automatically generated email, Please do not reply*</P>" +
    //                   "<P>                                                                                         </P>" +
    //                   "<P>Regards,</P>" +
    //                   "<P>QMS TEAM</P> " +

    //                   " </font></html></body>";
    //        mail.Body = strBody;

    //        mail.IsBodyHtml = true;

    //        smtp.Port = 25;
    //        smtp.Credentials = new System.Net.NetworkCredential("calculus@pamac.com", "HW76$$mm");
    //        smtp.EnableSsl = false;

    //        smtp.Send(mail);
    //        lblMsg.Text = txtUserName.Text.Trim() + " Email successfully sent To " + Emailid + "You will receive a revert within the next 48 hours(exclude Sundays & holidays)";
    //        lblTicketNo.Text = RowEffected;
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMsg.Text = "Email Failed." + ex.Message;
    //    }
    //}

    private void StatusLapsed(string TransactionId)
    {
        sqlcon.Open();

        SqlCommand sqlcmdk = new SqlCommand();
        sqlcmdk.Connection = sqlcon;
        sqlcmdk.CommandType = CommandType.StoredProcedure;
        sqlcmdk.CommandText = "Sp_Status_Lapsed";
        sqlcmdk.CommandTimeout = 0;

        SqlParameter Transaction = new SqlParameter();
        Transaction.SqlDbType = SqlDbType.VarChar;
        Transaction.Value = TransactionId;
        Transaction.ParameterName = "@TransactionId";
        sqlcmdk.Parameters.Add(Transaction);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmdk;

        DataTable sqldt = new DataTable();
        sqlda.Fill(sqldt);

        sqlcon.Close();
    }

    private void DelayEmail()
    {


        sqlcon.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlcon;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Get_QMS_TAT_Email1";
        cmd.CommandTimeout = 0;

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataTable dt = new DataTable();
        da.Fill(dt);

        sqlcon.Close();


        for (int i = 0; i < dt.Rows.Count; i++)
        {
            //string User = ddlQMSUser.SelectedValue.ToString();
            string User = dt.Rows[i]["AssignedTo"].ToString();
            string TransactionId = dt.Rows[i]["Ticketno"].ToString();

            string depart = dt.Rows[i]["Query Type"].ToString();

            if (User == "P-00114")
            {
                Emailid = "Mangesh.Hande@pamac.com";
            }
            else if (User == "P-00004")
            {
                Emailid = "shankar.devare@pamac.com";
            }
            else if (User == "P-02191" || User == "P-51410")
            {
                Emailid = "hr.support@pamac.com";
            }
            else if (User == "P-01632")
            {
                Emailid = "yogesh.mohite@pamac.com";
            }
            else if (User == "P-52733")
            {
                Emailid = "praveen.rathod@pamac.com";
            }

         //New Added
            else if (User == "P-00046" || User == "P-51629")
            {
                Emailid = "admin.support@pamac.com";
            }
            else if (User == "P-01746")
            {
                Emailid = "amol.jadhav@pamac.com";
            }
            else if (User == "P-00033")
            {
                Emailid = "ashpak.pinjari@pamac.com";
            }
            else if (User == "P-50936")
            {
                Emailid = "accounts@pamac.com";
            }

            //END

            string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
            string strhh = strTime.Remove(2);
            string strmm = strTime.Remove(0, 3);

            string Current = System.DateTime.Now.Date.ToString().Remove(10);

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient("69.64.70.36", 25);

                mail.From = new MailAddress("calculus@pamac.com", "PAMAC QMS");

                mail.To.Add(Emailid);

                if ("1015" == Session["Clusterid"].ToString())
                {
                    if (depart == "HR")
                    {
                        // mail.CC.Add(new MailAddress("north.hrsupport@pamac.com", "Sashi Kumar"));
                        mail.Bcc.Add(new MailAddress("Sarita.Minj@pamac.com", "Sarita Minj"));
                        //  mail.CC.Add(new MailAddress("Rupesh.Zodage@pamac.com","Rupesh Zodage"));
                    }
                    else if (depart == "Admin")
                    {
                        mail.CC.Add("Sunil.Kumar@pamac.com");
                    }

                }
                else if ("1014" == Session["Clusterid"].ToString())
                {
                    if (depart == "HR")
                    {
                        mail.CC.Add("Gopal.Dhar@pamac.com");

                    }
                    else if (depart == "Admin")
                    {
                        mail.CC.Add("Nandan.Chaterjee@pamac.com");
                    }

                }
                else if ("1013" == Session["Clusterid"].ToString())
                {
                    if (depart == "HR")
                    {
                        // mail.CC.Add("Elumalai.K@pamac.com");

                    }

                }


                if (depart == "Accounts")
                {
                    mail.CC.Add("sachin.sawant@pamac.com");

                }
                else if (depart == "5")
                {

                    if (User == "P-49506")
                    {
                        Emailid = "Rupesh.Zodage@pamac.com";
                        mail.CC.Add("ganesh.sawant@pamac.com");
                    }

                }
                else if (depart == "HR" || depart == "Admin" || depart == "Recruitment")
                {
                    mail.CC.Add("babar.mian@pamac.com");
                }


                mail.Subject = "PAMAC QMS : QMS Query ";

                string strBody =
                        "<html><body><font color=\"Navy\" style=\"font-style=Italic;font-weight=bold\">" +

                        "<P>                                                                                               </P>" +
                        " <P>Dear PAMACian,</P>" +
                        "<P>                                                                                         </P>" +
                        "<P>This is in response to the Transaction  " + TransactionId + " request raised in the PAMAC QMS to which your response has been delayed.</P>" +
                        "<P>  <table> </table>                                                                                       </P>" +
                        " <P>This calls for your immediate attention & resolution at the earliest as per the defined TAT.</P>" +
                        "<P>                                                                                        </P>" +
                        "<P>“This is computer generated mail and hence do not reply to this mail”  </P>" +
                        "<P>                                                                                         </P>" +
                        "<P>Regards,</P>" +
                        "<P>PAMAC QMS</P> " +

                        " </font></html></body>";
                mail.Body = strBody;

                mail.IsBodyHtml = true;

                smtp.Port = 25;
                smtp.Credentials = new System.Net.NetworkCredential("calculus@pamac.com", "qw@!34GH");
                smtp.EnableSsl = false;

                smtp.Send(mail);
                //lblMsg.Text = Emailid + " Email successfully sent. " + User;
                //lblTicketNo.Text = RowEffected;

                StatusLapsed(TransactionId);
            }

            catch (Exception ex)
            {
                lblMsg.Text = "Email Failed." + ex.Message;
            }

        }
    }

    #region New requirement Of Follow Up Code by Amrita on 09-05-2014
    //protected void lnkFollowUp_Click(object sender, EventArgs e)
    //{
    //    for (int i = 0; i <= grdTicketFill.Rows.Count - 1; i++)
    //    {
    //        CheckBox chkSelect = (CheckBox)grdTicketFill.Rows[i].FindControl("chkSelect");
    //        string Remark = null;

    //        if (chkSelect.Checked == true)
    //        {
    //            TextBox txtRemark = (TextBox)grdTicketFill.Rows[i].FindControl("txtNewRemark");
    //            if (txtRemark.Text == null || txtRemark.Text == "" || txtRemark.Text == string.Empty)
    //            {
    //                lblMsg.Text = "Please Enter the Remark";
    //                return;
    //            }
    //            Remark = txtRemark.Text.ToString();
    //            string tranID = grdTicketFill.Rows[i].Cells[5].Text.Trim();

    //            sqlcon.Open();

    //            SqlCommand sqlCom = new SqlCommand();
    //            sqlCom.Connection = sqlcon;
    //            sqlCom.CommandType = CommandType.StoredProcedure;
    //            sqlCom.CommandText = "Update_TicketInfo";
    //            sqlCom.CommandTimeout = 0;

    //            SqlParameter FollowUpRemark = new SqlParameter();
    //            FollowUpRemark.SqlDbType = SqlDbType.VarChar;
    //            FollowUpRemark.Value = Remark;
    //            FollowUpRemark.ParameterName = "@FollowUpRemark";
    //            sqlCom.Parameters.Add(FollowUpRemark);

    //            SqlParameter TicketNo = new SqlParameter();
    //            TicketNo.SqlDbType = SqlDbType.VarChar;
    //            TicketNo.Value = tranID;
    //            TicketNo.ParameterName = "@TicketNo";
    //            sqlCom.Parameters.Add(TicketNo);

    //            SqlParameter Status = new SqlParameter();
    //            Status.SqlDbType = SqlDbType.VarChar;
    //            Status.Value = 1;
    //            Status.ParameterName = "@Status";
    //            sqlCom.Parameters.Add(Status);

    //            int id = Convert.ToInt32(grdTicketFill.Rows[i].Cells[6].Text.Trim());

    //            SqlParameter ID = new SqlParameter();
    //            ID.SqlDbType = SqlDbType.Int;
    //            ID.Value = id;
    //            ID.ParameterName = "@ID";
    //            sqlCom.Parameters.Add(ID);

    //            int RowsEffeted = sqlCom.ExecuteNonQuery();
    //            if (RowsEffeted > 0)
    //            {
    //                lblMsg.Text = "Record Successfully Updated!";
    //                lblMsg.CssClass = "UpdateMessage";
    //            }
    //            else
    //            {
    //                lblMsg.Text = "Already Completed!";
    //            }

    //            sqlcon.Close();
    //            Fill_Grid();
    //        }
    //        else
    //        {
    //            lblMsg.Text = "Please Select Atleast One Record...!!!";
    //        }
    //    }
    //}

    //protected void lnkClose_Click(object sender, EventArgs e)
    //{
    //    string TicketNo = ((System.Web.UI.WebControls.LinkButton)(sender)).Text.ToString();
    //    if (TicketNo != "")
    //    {
    //        Response.Redirect("~/QMS/QMS/QMSAssignedTo.aspx?Tk=" + TicketNo.Trim(), true);
    //    }

    //    //for (int i = 0; i <= grdTicketFill.Rows.Count - 1; i++)
    //    //{
    //    //    CheckBox chkSelect = (CheckBox)grdTicketFill.Rows[i].FindControl("chkSelect");
    //    //    string Remark = null;
    //    //    if (chkSelect.Checked == true)
    //    //    {
       
    //    //        TextBox txtRemark = (TextBox)grdTicketFill.Rows[i].FindControl("txtNewRemark");
    //    //        Remark = txtRemark.Text.ToString();
    //    //        string tranID = grdTicketFill.Rows[i].Cells[5].Text.Trim();

    //    //        sqlcon.Open();

    //    //        SqlCommand sqlCom = new SqlCommand();
    //    //        sqlCom.Connection = sqlcon;
    //    //        sqlCom.CommandType = CommandType.StoredProcedure;
    //    //        sqlCom.CommandText = "[Update_TicketInfo]";
    //    //        sqlCom.CommandTimeout = 0;

    //    //        SqlParameter TicketNo = new SqlParameter();
    //    //        TicketNo.SqlDbType = SqlDbType.VarChar;
    //    //        TicketNo.Value = tranID;
    //    //        TicketNo.ParameterName = "@TicketNo";
    //    //        sqlCom.Parameters.Add(TicketNo);

    //    //        SqlParameter Status = new SqlParameter();
    //    //        Status.SqlDbType = SqlDbType.VarChar;
    //    //        Status.Value = 2;
    //    //        Status.ParameterName = "@Status";
    //    //        sqlCom.Parameters.Add(Status);

    //    //        //int id = Convert.ToInt32(grdTicketFill.Rows[i].Cells[6].Text.Trim());

    //    //        //SqlParameter ID = new SqlParameter();
    //    //        //ID.SqlDbType = SqlDbType.VarChar;
    //    //        //ID.Value = id;
    //    //        //ID.ParameterName = "@ID";
    //    //        //sqlCom.Parameters.Add(ID);

    //    //        if (txtRemark.Text == null || txtRemark.Text == "" || txtRemark.Text == string.Empty)
    //    //        {
    //    //            Remark = string.Empty;
    //    //        }

    //    //        SqlParameter FollowUpRemark = new SqlParameter();
    //    //        FollowUpRemark.SqlDbType = SqlDbType.VarChar;
    //    //        FollowUpRemark.Value = Remark;
    //    //        FollowUpRemark.ParameterName = "@FollowUpRemark";
    //    //        sqlCom.Parameters.Add(FollowUpRemark);

    //    //        int RowsEffeted = sqlCom.ExecuteNonQuery();
    //    //        if (RowsEffeted > 0)
    //    //        {
    //    //            lblMsg.Text = "Record Successfully Updated!";
    //    //            lblMsg.CssClass = "UpdateMessage";
    //    //        }
    //    //        sqlcon.Close();
    //    //        Fill_Grid();

    //    //    }
    //    //    else
    //    //    {
    //    //        lblMsg.Text = "Please Select Atleast One Record...!!!";
    //    //    }
    //    //}
    //}
    #endregion




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
            lblMsg.Text = ex.Message;
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
            lblMsg.Text = "No Attached Document Found...!!!";
        }
    }

    protected void grdTicketFill_RowDataBound(object sender, GridViewRowEventArgs e)
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

    //public override void VerifyRenderingInServerForm(Control control)
    //{ }








    
    protected void grdTicketFill_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        for (int i = 0; i <= grdTicketFill.Rows.Count - 1; i++)
        {
            CheckBox chkSelect = (CheckBox)grdTicketFill.Rows[i].FindControl("chkSelect");
            string Remark = null;

            String strUID = "";
            strUID = e.CommandArgument.ToString();

            hdnyrmonth.Value = grdTicketFill.Rows[i].Cells[4].Text.Trim(); ;
            if (chkSelect.Checked == true)
            {

                if (e.CommandName == "Edit1")
                {
                    if (hdnyrmonth.Value == strUID)
                    {

                        txtUserName.Text = grdTicketFill.Rows[i].Cells[6].Text.Trim();


                        lblTicketNo.Text = grdTicketFill.Rows[i].Cells[4].Text.Trim();


                        ddlProblemType.SelectedItem.Text = grdTicketFill.Rows[i].Cells[8].Text.Trim().Replace("&amp;","&");// AssignProduct(HdnProduct.Value);


                        ddlQMSUser.SelectedItem.Text= "Nitin Pednekar";//SelectedItem.Text = grdTicketFill.Rows[i].Cells[7].Text.Trim();
                        txtRemark.Text = grdTicketFill.Rows[i].Cells[9].Text.Trim();



                    }

                }
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Getdata12();
        //Email12();
    }



    private void Getdata12()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlcon;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "get_email_import";
        cmd.CommandTimeout = 0;

        //SqlParameter Emp_Code = new SqlParameter();
        //Emp_Code.SqlDbType = SqlDbType.VarChar;
        //Emp_Code.Value = Convert.ToInt32(Session["UserId"]);
        //Emp_Code.ParameterName = "@Emp_id";
        //cmd.Parameters.Add(Emp_Code);

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataTable dt = new DataTable();
        da.Fill(dt);


        DataRow Rows = dt.Rows[0];

        //if (dt.Columns.Count > 0)
        //{
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                hdnemp_code.Value = dt.Rows[i]["bridge_code"].ToString();   //New Added
                hdnfullname.Value = dt.Rows[i]["Emp_Name"].ToString();
                hdnamount.Value = dt.Rows[i]["Amount"].ToString();
                hdnyrmonth.Value = dt.Rows[i]["MonthYr"].ToString();
                hdnemail.Value = dt.Rows[i]["email_id"].ToString();
                  Email12();
              
                
            }
          
        //}


    }
}

