using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Software_Requirement_Software_Daily_Tracker : System.Web.UI.Page
{
    CCommon connobj = new CCommon();
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;
    DataTable DataTable = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);

        if (!IsPostBack)
        {
            if (Request.QueryString["msg"] != null)
            {
                lblReassignedAlter.Text = "Record Inserted";
            }

            InitializeComponent();
            //Panel1.Visible = true;
            Panel2.Visible = true;

            BindTicketNo();

        }
    }
    private void BindTicketNo()
    {
        try
        {

            SqlCommand cmd = new SqlCommand("SSU_BindTicketNo_DailyTracker_SP", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", Convert.ToString((Session["UserId"])));
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlTicketNo.DataTextField = "TicketNo";
                ddlTicketNo.DataValueField = "TicketNo";

                ddlTicketNo.DataSource = ds;
                ddlTicketNo.DataBind();

                ddlTicketNo.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlTicketNo.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            //lblmsg.Text = ex.Message;
        }
    }
    private void Search()
    {

        try
        {
            sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SSU_GetDetailsByTicketNo_DailyTracker_SP";
            cmd.CommandTimeout = 0;

            SqlParameter Userid = new SqlParameter();
            Userid.SqlDbType = SqlDbType.VarChar;
            Userid.Value = ddlTicketNo.SelectedValue;
            Userid.ParameterName = "@TicketNo";
            cmd.Parameters.Add(Userid);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataSet ds = new DataSet();

            da.Fill(ds);
            sqlcon.Close();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                //Panel1.Visible = false;
                //Panel2.Visible = true;

                HFTicketNo.Value = ds.Tables[0].Rows[0]["TicketNo"].ToString();
                //lblTicketNumber.Text = ds.Tables[0].Rows[0]["TicketNo"].ToString();
                lblDateofOriginalEntry.Text = ds.Tables[0].Rows[0]["Date of Original Entry"].ToString();
                lblApplication.Text = ds.Tables[0].Rows[0]["Application"].ToString();
                lblPriority.Text = ds.Tables[0].Rows[0]["Priority"].ToString();
                lblRaisedBy.Text = ds.Tables[0].Rows[0]["Raised By"].ToString();
                lblProblem.Text = ds.Tables[0].Rows[0]["Problem"].ToString();
                lblSuggestion.Text = ds.Tables[0].Rows[0]["Suggestion"].ToString();
                lblDueDate.Text = ds.Tables[0].Rows[0]["DueDate"].ToString();
                lblCurrentStatus.Text = ds.Tables[0].Rows[0]["overallremark"].ToString();
                lblEstimatedDevelopmentTime.Text = ds.Tables[0].Rows[0]["Estimated_Development_Time"].ToString();
                lblActualSpentTime.Text = ds.Tables[0].Rows[0]["Actual_TimeSpent"].ToString();


            }
            else
            {
                string Message = "Invalid Ticket Number Or  Ticket Closed ";
                ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + Message + "');", true);
            }
        }
        catch (Exception Ex)
        {
            //lblmsg.Text = Ex.Message;
        }
    }

    //protected void btnSearch_Click(object sender, EventArgs e)
    //{
    //    Search();
    //}

    protected void ddlTicketNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        Search();
    }
    protected void InitializeComponent()
    {
        if (ViewState["DataTable"] == null)
        {
            DataTable.Columns.Add("TicketNo");
            DataTable.Columns.Add("TrackDate");
            DataTable.Columns.Add("TaskToday");
            DataTable.Columns.Add("DeveloperRemark");
            DataTable.Columns.Add("TimeSpent");
            DataTable.Columns.Add("TicketCurrentStatus");
            DataTable.Columns.Add("ResionForDelay");

            ViewState["DataTable"] = DataTable;
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        lblReassignedAlter.Text = "";

        string msg = string.Empty;

        if (txtDate.Text == "")
        {
            msg = msg + "Please Select Date";
        }

        if (ddlTicketNo.SelectedIndex == 0)
        {
            msg = msg + "Please Select Ticket No ";
        }

        if (txtTask.Text == "" || txtTask.Text == null)
        {
            msg = msg + "Please Enter Task or Activity Done Today";
        }

        if (txtDeveloperRemark.Text == "" || txtDeveloperRemark.Text == null)
        {
            msg = msg + "Please Enter DeveloperRemark";
        }

        if (txtTimeSpent.Text == "00:00")
        {
            msg = msg + "Please Enter TimeSpent /n";
        }

        if (msg != "")
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
            return;
        }



        //Check If duplicate TicketNo Exists for Same Date and Same User 

        bool IsNotExists = CheckTicketNoExists(ddlTicketNo.SelectedItem.Text, strDate(txtDate.Text));


        if (CheckForDelay(strDate(txtDate.Text), txtResionForDelay.Text))
        {

        }
        else
        {
            msg = msg + "Please enter delay Reason";

            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "alert('" + msg + "');", true);
            return;
        }



        if (IsNotExists)
        {
            DataTable = (DataTable)ViewState["DataTable"];

            DataTable.Rows.Add(ddlTicketNo.SelectedItem.Text, strDate(txtDate.Text), txtTask.Text, txtDeveloperRemark.Text,
                               txtTimeSpent.Text, ddlTicketCurrentStatus.SelectedItem.Text, txtResionForDelay.Text);

            gvdis.DataSource = DataTable;
            gvdis.DataBind();

            ddlTicketNo.SelectedIndex = 0;
            txtTask.Text = "";
            txtDeveloperRemark.Text = "";
            ddlTicketCurrentStatus.SelectedIndex = 0;
            txtTimeSpent.Text = "00:00";
        }
        else
        {
            lblReassignedAlter.Text = "Record exists duplicate not allowed";
        }
    }
    protected bool CheckTicketNoExists(string TicketNo, string Date)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlcon;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SSU_CheckDailyTicket_SP";
        cmd.CommandTimeout = 0;

        cmd.Parameters.AddWithValue("@Emp_Code", Convert.ToString(Session["UserName"]));
        cmd.Parameters.AddWithValue("@TicketNo", TicketNo);
        cmd.Parameters.AddWithValue("@Date", Date);

        sqlcon.Open();
        string result = cmd.ExecuteScalar().ToString();
        sqlcon.Close();

        if (result == "TRUE")
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    protected DataSet GetHoliList()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlcon;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SSU_GetHoliDay_Calender";
        cmd.CommandTimeout = 0;
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);

        return ds;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        lblReassignedAlter.Text = "";



        try
        {
            DataTable dt = new DataTable();
            dt = new DataTable();
            dt = (DataTable)ViewState["DataTable"];

            //check tracking date 
            //if (CheckForDelay(strDate(txtDate.Text), txtResionForDelay.Text))
            //{

            dt.Columns.Remove("ResionForDelay");
            dt.AcceptChanges();

            sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SSU_InsertDailyTracker_SP";
            cmd.CommandTimeout = 0;

            cmd.Parameters.AddWithValue("@UserID", Convert.ToString(Session["UserId"]));
            cmd.Parameters.AddWithValue("@DailyTracker_DT", dt);
            SqlParameter outputIdParam = new SqlParameter("@message", SqlDbType.VarChar, 500)
            {
                Direction = ParameterDirection.Output
            };
            cmd.Parameters.Add(outputIdParam);
            int result = cmd.ExecuteNonQuery();
            string message = Convert.ToString(cmd.Parameters[2].Value);
            sqlcon.Close();


            if (message == "SUCCESS")
            {

                //send mail for delay
                if (ViewState["dtDelayReason"] != null)
                {
                    DataTable dtDelayReason = (DataTable)ViewState["dtDelayReason"];
                    foreach (DataRow dr in dtDelayReason.Rows)
                    {
                        string TrackDate = dr["TrackDate"].ToString();
                        string Reason = dr["Reason"].ToString();
                        string EmployeeName = Convert.ToString(Session["FLName"]);
                        SendMail(EmployeeName, TrackDate, Reason);
                        break;
                    }
                }


                lblReassignedAlter.Text = "Record Inserted";
                ClearData();
                BindTicketNo();

                Response.Redirect("Daily_Tracker.aspx?msg=true");

            }
            else
            {
                lblReassignedAlter.Text = "Someting went wrong! please try again.";
            }
            //}
            //else
            //{
            //    lblReassignedAlter.Text = "Please enter delay Reason";
            //}



        }
        catch (Exception exp)
        {
            lblmsg.Text = exp.Message;

        }

    }

    public bool CheckForDelay(string trackingDate, string DelayReason)
    {
        ViewState["dtDelayReason"] = null;
        DataTable dtDelayReason = new DataTable();
        dtDelayReason.Columns.Add("TrackDate");
        dtDelayReason.Columns.Add("Reason");

        bool isValid = true;

        DataSet dsholidaylist = new DataSet();
        dsholidaylist = GetHoliList();


        DateTime trackDate = Convert.ToDateTime(trackingDate);
        trackDate = trackDate.AddDays(1);

        //Check for Sunday
        if (trackDate.ToString("dddd") == "Sunday")
        {
            trackDate = trackDate.AddDays(1);
        }
        //Check for holiday
        foreach (DataRow drHlist in dsholidaylist.Tables[0].Rows)
        {
            if (drHlist["HolidayDate"].ToString() == trackDate.ToString() && Convert.ToDateTime(drHlist["HolidayDate"]).ToString("dddd") != "Sunday")
                trackDate = trackDate.AddDays(1);
        }
        //Check for Sunday
        if (trackDate.ToString("dddd") == "Sunday")
        {
            trackDate = trackDate.AddDays(1);
        }

        bool Valid = false;

        if (DateTime.Now < trackDate)
        {
            Valid = true;
        }
        else if (DateTime.Now == trackDate && DateTime.Now.Hour < 10)
        {
            Valid = true;
        }

        if (Valid == false)
        {
            string reason = DelayReason;
            dtDelayReason.Rows.Add(trackingDate, DelayReason);
            if (reason == "")
                isValid = false;

            ViewState["dtDelayReason"] = dtDelayReason;
        }



        return isValid;
    }
    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);

        string strMM = strInDate.Substring(3, 2);

        string strYYYY = strInDate.Substring(6, 4);

        string strYYYYMMDD = strYYYY + "-" + strMM + "-" + strDD;

        //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;

        DateTime dtConvertDate = Convert.ToDateTime(strYYYYMMDD);

        string strOutDate = dtConvertDate.ToString("yyyy-MM-dd");

        return strOutDate;
    }
    protected void SendMail(string EmployeeName, string TrackDate, string DelayReason)
    {
        try
        {
            //SqlCommand cmd = new SqlCommand("USP_GetEMPMailIdForSSUReport", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandType = CommandType.StoredProcedure;
            //SqlDataAdapter adp = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //adp.Fill(ds);
            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    MailTo = ds.Tables[0].Rows[0]["ToEmail"].ToString();           
            //}


            string MailTo = "ajit.kedare@pamac.com";

            string MailCC = "ramakrishnan.v@pamac.com";



            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.Subject = "Delayed Submission Of Daily Tracker By " + EmployeeName;
            mail.From = new MailAddress("software.support@pamac.com");

            mail.To.Add(MailTo.TrimEnd(','));
            mail.CC.Add(MailCC.TrimEnd(','));

            mail.Body = "<p>Sir ,</p><br /><p>Please note that " + EmployeeName + " has submitted a Daily tracker Of " + TrackDate
                             + "  with delay for the following reason </p>" +
                         "<p> " + DelayReason + "</p><br/>" +
                         "Please follow up with the concerned" +
                          "<br />  <br />  <br />  PAMAC Finserve Pvt.Ltd <br />  Management Team <br />  Mumbai – Head Office";
            mail.IsBodyHtml = true;

            //    mail.Attachments.Add(new Attachment(@"C:\Users\dell\Desktop\CFS\NANO-PRO-App_Csharp_Calculus(08May2016)\Pages\CFS\UploadFile\" + "\\" + filename));
            SmtpClient smtp = new SmtpClient("103.13.99.139", 25);
            smtp.Credentials = new System.Net.NetworkCredential("test.pamac@pamac.com", "hsu@z@123");
            smtp.EnableSsl = false;
            smtp.Send(mail);
        }
        catch (Exception ex)
        {
            string logsDirectory = Path.Combine(Environment.CurrentDirectory, "ErrorLog\\ErrorLog.txt");

            using (StreamWriter writer = new StreamWriter(logsDirectory, true))
            {
                writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                   "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            }
        }
    }

    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        lblReassignedAlter.Text = "";

        Regex regex = new Regex(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$");

        //Verify whether date entered in dd/MM/yyyy format.
        bool isValid = regex.IsMatch(txtDate.Text.Trim());

        //Verify whether entered date is Valid date.
        DateTime dt;
        isValid = DateTime.TryParseExact(txtDate.Text, "dd/MM/yyyy", new CultureInfo("en-GB"), DateTimeStyles.None, out dt);
        if (!isValid)
        {
            lblReassignedAlter.Text = "Invalid Date. date format Like [dd/MM/yyyy]";
            txtDate.Text = "";
            return;
        }


        //Daily Tracker Date can not  Be Greater then Current date
        string TodaysDate = System.DateTime.Now.ToString("dd/MM/yyyy");

        DateTime DailyTrackerDate;
        DateTime CurrentDate;

        DailyTrackerDate = Convert.ToDateTime(connobj.strDate(txtDate.Text.ToString().Trim()));
        CurrentDate = Convert.ToDateTime(connobj.strDate(TodaysDate));

        if (DailyTrackerDate > CurrentDate)
        {
            lblReassignedAlter.Text = "Invalid Date. Date Can not Be Greater then Current date";
            txtDate.Text = "";
            return;
        }

        //check User Already Submit  same date Record in  daily Tracker
        bool IsNotExists = CheckSameDateExists(strDate(txtDate.Text));

        if (IsNotExists)
        {
            txtDate.Enabled = false;
        }
        else
        {
            txtDate.Text = "";
            lblReassignedAlter.Text = "Already Submited Daily Tracker For The Day";
        }
    }
    protected bool CheckSameDateExists(string Date)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlcon;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SSU_CheckSameDate_SP";
        cmd.CommandTimeout = 0;

        cmd.Parameters.AddWithValue("@Emp_Code", Convert.ToString(Session["UserName"]));
        cmd.Parameters.AddWithValue("@Date", Date);

        sqlcon.Open();
        string result = cmd.ExecuteScalar().ToString();
        sqlcon.Close();

        if (result == "TRUE")
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    protected void ClearData()
    {
        txtDate.Text = "";
        txtDate.Enabled = true;
        txtResionForDelay.Text = "";
        ddlTicketNo.SelectedIndex = 0;
        txtTask.Text = "";
        txtDeveloperRemark.Text = "";
        txtTimeSpent.Text = "00:00";
        ddlTicketCurrentStatus.SelectedIndex = 0;

        gvdis.DataSource = null;
        gvdis.DataBind();
    }
}