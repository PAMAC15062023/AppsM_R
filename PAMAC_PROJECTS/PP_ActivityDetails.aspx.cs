using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Pamac_Projects
{
    public partial class PP_ActivityDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["PHeader"] != null && Session["actnumber"] != null)
                {

                    string acthead = Session["PHeader"].ToString();
                    string actnumber = Session["actnumber"].ToString();

                    // lblMessage.Text = "Under construction";
                    //  string acthead = Request.QueryString["actheader"];
                    String actheadfull = acthead + " Details";
                    lblHeader.Text = actheadfull;
                    // string msg ="";
                    string msg = Request.QueryString["msg"];
                    lblMessage.Text = msg;

                    GetActivityDetails(actnumber, acthead);
                }
                else
                {
                    Response.Redirect("PP_Login.aspx", false);
                }


            }
        }
        public void GetActivityDetails(string actnumber, string acthead)
        {
            try
            {

                if (Session["PHeader"] != null && Session["actnumber"] != null)
                {

                    SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                    sqlCon.Open();
                    SqlCommand sqlcmd = new SqlCommand();
                    sqlcmd.Connection = sqlCon;
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.CommandText = "SP_getactnumberdetails";

                    sqlcmd.Parameters.AddWithValue("@actnumber", actnumber);
                    // sqlcmd.Parameters.AddWithValue("@acthead", acthead);
                    //  sqlcmd.Parameters.AddWithValue("@field_show_in", field_show_in);
                    SqlDataAdapter sqlDA = new SqlDataAdapter();

                    sqlDA.SelectCommand = sqlcmd;
                    DataTable dt = new DataTable();
                    sqlDA.Fill(dt);
                    sqlCon.Close();

                    int cnt = dt.Rows.Count - 1;
                    if (dt.Rows.Count > 0)
                    {
                        grv1.DataSource = dt;
                        grv1.DataBind();

                        string subject = grv1.Rows[0].Cells[3].Text;
                        Session["Subject"] = subject;


                        for (int y = 7; y <= 9; y++)
                        {
                            for (int i = 0; i <= cnt; i++)
                            {
                                // if  grv1.Rows[i].Cells[y].Text contains more than one file we need to loop

                                String str = grv1.Rows[i].Cells[y].Text;

                                char[] spearator = { ',' };

                                // using the method 
                                String[] strlist = str.Split(spearator);

                                foreach (String s in strlist)
                                {
                                    HyperLink myLink = new HyperLink();
                                    myLink.Text = s + "<br>"; // grv1.Rows[i].Cells[y].Text;
                                    grv1.Rows[i].Cells[y].Controls.Add(myLink);

                                    string file = s;// grv1.Rows[i].Cells[y].Text;
                                    file = file.Trim();
                                    myLink.NavigateUrl = "PP_download.aspx?file=" + file;
                                    //grv1.Rows[i].Cells[y].Text = myLink.NavigateUrl + " ; ";

                                    // Console.WriteLine(s);
                                }
                                //   Console.ReadKey();

                                //////////////////////////////
                                // HyperLink myLink = new HyperLink();
                                //  myLink.Text = grv1.Rows[i].Cells[y].Text;
                                // grv1.Rows[i].Cells[y].Controls.Add(myLink);
                                //    string file = grv1.Rows[i].Cells[y].Text;
                                //  myLink.NavigateUrl = "PP_download.aspx?file=" + file;

                                //Server.MapPath("~/UploadedFiles/") + myLink.Text;
                            }
                        }
                    }
                }
                else
                {
                    Response.Redirect("PP_Login.aspx", false);
                }
            }
            catch (Exception ex)
            {

                lblMessage.Text = ex.ToString();
            }

        }


        protected void grv1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnReply_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["PHeader"] != null && Session["actnumber"] != null)
                {
                    string acthead = Session["PHeader"].ToString();
                    string actnumber = Session["actnumber"].ToString();
                    string subject =
                    lblMessage.Text = acthead + "Under construction" + actnumber;
                    Response.Redirect("PP_Reply.aspx", false);
                }
                else
                {
                    Response.Redirect("PP_Login.aspx", false);
                }
            }
            catch (Exception ex)
            {

                lblMessage.Text = ex.ToString();
            }

        }

        protected void btnHold_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["PHeader"] != null && Session["actnumber"] != null && Session["UserName"] != null)
                {
                    string actnumber = Session["actnumber"].ToString();
                    string acthead = Session["PHeader"].ToString();
                    string postedby = Session["UserName"].ToString();

                    SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                    SqlCommand cmd = new SqlCommand("SP_insertintoPP_Activities", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@act_no", actnumber);
                    cmd.Parameters.AddWithValue("@TypeOfActivity", acthead);
                    cmd.Parameters.AddWithValue("@AssignedTo", postedby);
                    cmd.Parameters.AddWithValue("@Summary", "");
                    cmd.Parameters.AddWithValue("@Attachment_1", "");
                    cmd.Parameters.AddWithValue("@Attachment_2", "");
                    cmd.Parameters.AddWithValue("@Attachment_3", "");
                    cmd.Parameters.AddWithValue("@Attachinfo_1", "");
                    cmd.Parameters.AddWithValue("@Attachinfo_2", "");
                    cmd.Parameters.AddWithValue("@Attachinfo_3", "");
                    cmd.Parameters.AddWithValue("@PostedBy", postedby);
                    cmd.Parameters.AddWithValue("@Proc", "HOLD");

                    sqlCon.Open();
                    int result = cmd.ExecuteNonQuery();
                    sqlCon.Close();

                    if (result > 0)
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "Data Successfully made HOLD ";
                        SendMail(actnumber);
                    }
                }
                else
                {
                    Response.Redirect("PP_Login.aspx", false);
                }
            }
            catch (Exception ex)
            {

                lblMessage.Text = ex.ToString();
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["PHeader"] != null && Session["actnumber"] != null && Session["UserName"] != null)
                {
                    // insert a new record with statusn = "CLOSED"
                    string actnumber = Session["actnumber"].ToString();
                    string acthead = Session["PHeader"].ToString();
                    string postedby = Session["UserName"].ToString();

                    SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                    SqlCommand cmd = new SqlCommand("SP_insertintoPP_Activities", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@act_no", actnumber);
                    cmd.Parameters.AddWithValue("@TypeOfActivity", acthead);
                    cmd.Parameters.AddWithValue("@AssignedTo", postedby);
                    cmd.Parameters.AddWithValue("@Summary", "");
                    cmd.Parameters.AddWithValue("@Attachment_1", "");
                    cmd.Parameters.AddWithValue("@Attachment_2", "");
                    cmd.Parameters.AddWithValue("@Attachment_3", "");
                    cmd.Parameters.AddWithValue("@Attachinfo_1", "");
                    cmd.Parameters.AddWithValue("@Attachinfo_2", "");
                    cmd.Parameters.AddWithValue("@Attachinfo_3", "");
                    cmd.Parameters.AddWithValue("@PostedBy", postedby);
                    cmd.Parameters.AddWithValue("@Proc", "CLOSED");

                    sqlCon.Open();
                    int result = cmd.ExecuteNonQuery();
                    sqlCon.Close();

                    if (result > 0)
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "RECORD Successfully CLOSED ";

                        SendMail(actnumber);

                    }
                }
                else
                {
                    Response.Redirect("PP_Login.aspx", false);
                }
            }
            catch (Exception ex)
            {

                lblMessage.Text = ex.ToString();
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["PHeader"] != null)
                {
                    string acthead = Session["PHeader"].ToString();
                    Response.Redirect("PP_Activities.aspx", false);
                }
                else
                {
                    Response.Redirect("PP_Login.aspx", false);
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.ToString();
            }

        }

        protected void grv1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string newval = e.Row.Cells[6].Text;
                e.Row.Cells[6].Attributes.Add("style", "word-break:break-all;width:300px");
            }

        }
        protected void grv2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        public static void SendMail(string actno)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

                string MailTo = "";
                string MailCC = "";

                string PostedDate = "";
                string PostedBy = "";
                string Subject = "";
                string ActStatus = "";
                string AssignTo = "";
                string TypeOfActivity = "";
                string Summary = "";

                SqlCommand cmd = new SqlCommand("SP_BindEmail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    MailTo = ds.Tables[0].Rows[0]["ToEmail"].ToString();
                }

                SqlCommand cmd2 = new SqlCommand("SP_BinddetailsForEmail", con);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@ACTNo", actno);
                SqlDataAdapter adp2 = new SqlDataAdapter(cmd2);
                DataSet ds2 = new DataSet();
                adp2.Fill(ds2);
                if (ds2 != null && ds.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
                {
                    PostedDate = ds2.Tables[0].Rows[0]["PostedDate"].ToString();
                    PostedBy = ds2.Tables[0].Rows[0]["PostedBy"].ToString();
                    Subject = ds2.Tables[0].Rows[0]["Subject"].ToString();
                    ActStatus = ds2.Tables[0].Rows[0]["Act_Status"].ToString();
                    AssignTo = ds2.Tables[0].Rows[0]["AssignTo"].ToString();
                    TypeOfActivity = ds2.Tables[0].Rows[0]["TypeOfActivity"].ToString();
                    Summary = ds2.Tables[0].Rows[0]["Summary"].ToString();
                }




                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient("mail.pamac.com", 587);
                mail.From = new MailAddress("software.support@pamac.com", "PAMAC Project"); //you have to provide your gmail address as from addres
                mail.To.Add(MailTo.TrimEnd(','));


                mail.Subject = TypeOfActivity + " " + actno + " " + Subject + " Replied";
                string strBody =
                        "<html><body><font color=\"Navy\"><P>=====================================================================================================================</P>" +
                        "<P>                                                                                               </P>" +
                        " <P>Hi</P>" +
                        "<P>                                                                                         </P>" +
                        "<P>Welcome to Pamac Project!</P>" +
                        "<P>A great way to manage and track your project efficiently.</P>" +
                        "<P>You have a reply for " + actno + "</P>" +
                        "<P>Reply :-" + Summary + "</P>" +
                        "<table border='1'><tr>" +
                        "<td> Assign To </td>" +
                       "<td> " + AssignTo + " </td>" +
                       "</tr><tr>" +
                       "<td> Type Of Activity </td>" +
                       "<td> " + TypeOfActivity + " </td>" +
                       "</tr><tr>" +
                       "<td> Activity No </td>" +
                       "<td> " + actno + " </td>" +
                       "</tr><tr>" +
                       "<td> Posted Date </td>" +
                       "<td> " + PostedDate + " </td>" +
                       "</tr><tr>" +
                       "<td> Posted By </td>" +
                       "<td> " + PostedBy + " </td>" +
                       "</tr><tr>" +
                       "<td> Subject </td>" +
                       "<td> " + Subject + " </td>" +
                       "</tr><tr>" +
                       "<td> Status </td>" +
                       "<td> " + ActStatus + " </td>" +
                       "</tr></table>" +
                        "<P>“This Is An Automatically Generated Email, Please Do Not Reply:”  </P>" +
                        "<P>                                                                                         </P>" +
                        "<P>Regards,</P>" +
                        "<P>PAMAC Project</P> " +

                   "<P>=====================================================================================================================</P></font></html></body>";

                mail.Body = strBody;
                mail.IsBodyHtml = true;
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("software.support@pamac.com", "_ug7rogzH");  //you have to provide you gamil username and password
                smtp.EnableSsl = false;/// Main line :SSL should be false
                smtp.Send(mail);
            }
            catch (Exception ex)
            {

            }
        }
    }
}