using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pamac_Projects
{
    public partial class PP_ADDNEW : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Session["PHeader"] != null)
                    {
                        string acthead = Session["PHeader"].ToString();
                        //string actnumber = Session["actnumber"].ToString();
                        //   lblMsgXls.Text = "in reply";
                        lblHeader.Text = acthead + " ADD NEW ";
                        //     txtSubject.Text = Session["Subject"].ToString();
                        //  txtSubject.Enabled = false;
                        BindUsers();
                        BindPriority();
                    }
                    else
                    {
                        Response.Redirect("PP_Login.aspx", false);
                    }
                }
                catch (Exception ex)
                {

                    lblMsgXls.Text = ex.ToString();
                }


            }
        }
        protected void ddlAssignedTo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void BindUsers()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "SP_BindUsers";
                sqlCom.CommandTimeout = 0;


                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlAssignedTo.DataTextField = "UserName";
                    ddlAssignedTo.DataValueField = "Userid";
                    ddlAssignedTo.DataSource = ds.Tables[0];
                    ddlAssignedTo.DataBind();

                    ddlAssignedTo.Items.Insert(0, "--Select--");
                    ddlAssignedTo.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                lblMsgXls.Text = ex.ToString();
            }
        }
        protected void BindPriority()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "SP_BindPriority";
                sqlCom.CommandTimeout = 0;


                SqlDataAdapter da = new SqlDataAdapter(sqlCom);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    ddlPriority.DataTextField = "Priority_descr";
                    ddlPriority.DataValueField = "Priority_descr";
                    ddlPriority.DataSource = ds.Tables[0];
                    ddlPriority.DataBind();

                    ddlPriority.Items.Insert(0, "--Select--");
                    ddlPriority.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                lblMsgXls.Text = ex.ToString();
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["PHeader"] != null && Session["UserName"] != null)
                {
                    string acthead = Session["PHeader"].ToString();
                    acthead = Session["PHeader"].ToString();
                    string postedby = Session["UserName"].ToString();

                    string excelPath1 = "";
                    string excelPath2 = "";
                    string excelPath3 = "";

                    string newpath1 = Path.GetFileName(FileUpload_1.PostedFile.FileName);
                    string newpath2 = Path.GetFileName(FileUpload_2.PostedFile.FileName);
                    string newpath3 = Path.GetFileName(FileUpload_3.PostedFile.FileName);
                    if (newpath1 != "")
                    {
                        excelPath1 = Server.MapPath("~/UploadedFiles/") + Path.GetFileName(FileUpload_1.PostedFile.FileName);
                        FileUpload_1.SaveAs(excelPath1);
                    }
                    if (newpath2 != "")
                    {
                        excelPath2 = Server.MapPath("~/UploadedFiles/") + Path.GetFileName(FileUpload_2.PostedFile.FileName);
                        FileUpload_2.SaveAs(excelPath1);
                    }
                    if (newpath3 != "")
                    {
                        excelPath3 = Server.MapPath("~/UploadedFiles/") + Path.GetFileName(FileUpload_3.PostedFile.FileName);
                        FileUpload_3.SaveAs(excelPath1);
                    }


                    SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                    SqlCommand cmd = new SqlCommand("SP_insertintoPP_Activities_ADD", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TypeOfActivity", acthead);
                    cmd.Parameters.AddWithValue("@AssignedTo", ddlAssignedTo.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@Priority", ddlPriority.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@Subject", txtSubject.Text);
                    cmd.Parameters.AddWithValue("@Summary", TxtSummary.Text);
                    cmd.Parameters.AddWithValue("@Attachment_1", excelPath1);
                    cmd.Parameters.AddWithValue("@Attachment_2", excelPath2);
                    cmd.Parameters.AddWithValue("@Attachment_3", excelPath3);
                    cmd.Parameters.AddWithValue("@Attachinfo_1", txtAttachinfo1.Text);
                    cmd.Parameters.AddWithValue("@Attachinfo_2", txtAttachinfo2.Text);
                    cmd.Parameters.AddWithValue("@Attachinfo_3", txtAttachinfo3.Text);
                    cmd.Parameters.AddWithValue("@PostedBy", postedby);
                    cmd.Parameters.AddWithValue("@Proc", "OPEN");

                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        lblMsgXls.Visible = true;
                        lblMsgXls.Text = "Data Successfully Submitted ";

                        string actno = ds.Tables[0].Rows[0]["actno"].ToString();

                        SendMail(actno);

                        ClearData();

                    }
                }
                else
                {
                    Response.Redirect("PP_Login.aspx", false);
                }


            }
            catch (Exception ex)
            {
                lblMsgXls.Text = ex.ToString();
            }


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PP_Activities.aspx", false);
        }

        protected void ddlAssignedTo_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void ddlPriority_SelectedIndexChanged(object sender, EventArgs e)
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
                //string logsDirectory = Path.Combine(Environment.CurrentDirectory, "ErrorLog\\ErrorLog.txt");

                //using (StreamWriter writer = new StreamWriter(logsDirectory, true))
                //{
                //    writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                //       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                //    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                //}
            }
        }
        protected void ClearData()
        {
            ddlAssignedTo.SelectedIndex = 0;
            ddlPriority.SelectedIndex = 0;
            txtSubject.Text = "";
            TxtSummary.Text = "";
            txtAttachinfo1.Text = "";
            txtAttachinfo2.Text = "";
            txtAttachinfo3.Text = "";
        }
    }
}