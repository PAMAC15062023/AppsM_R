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
using myInfo;
using System.IO;
using System.Net.Mail;
using System.Threading;
using System.Data.SqlClient;
public partial class Employeemanagement_Default : System.Web.UI.Page
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;

    Info a = new Info();
    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);
        //Application_start();
    }

    //void Application_start()
    //{
    //    Thread thread = new Thread(CronThread);
    //    thread.IsBackground = true;
    //    thread.Start();


    //}

    //private void CronThread()
    //{
    //    while (true)
    //    {
    //        Thread.Sleep(TimeSpan.FromMinutes(20));
    //        Email2333333();
    //    }
    //}

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    private void Email1111()
    {
        try
        {

            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient("103.13.99.137", 25);

            string Emailid;


            string str = string.Empty;


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
           // sqlcmd.CommandText = "sp_MondayBday";
            sqlcmd.CommandText = "image_show1";
            sqlcmd.CommandTimeout = 0;

            sqlcon.Open();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcmd;

            DataSet ds = new DataSet();
            da.Fill(ds);

            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();


                int count1 = ds.Tables[1].Rows.Count;

                mail.Attachments.Add(new Attachment(@"E:\Live PMS Site Consolidated\PublishMumbai\Employeemanagement\mailimage\img1.gif"));
                mail.Attachments.Add(new Attachment(@"E:\Live PMS Site Consolidated\PublishMumbai\Employeemanagement\mailimage\cumple.gif"));
               // mail.Attachments.Add(new Attachment(@"E:\Live PMS Site Consolidated\PublishMumbai\Employeemanagement\mailimage\Untitled.jpg"));
                for (int i = 0; i < count1; i++)
                {
                    using (StringWriter sw = new StringWriter())
                    {
                        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                        {
                            StringReader sr = new StringReader(sw.ToString());
                            GridView1.RenderControl(hw);

                            mail.From = new MailAddress("calculus@pamac.com", "Birthday Wishes!!!");

                            Emailid = "";
                            Emailid = ds.Tables[1].Rows[i]["Email_Id"].ToString();


                            mail.Bcc.Add(Emailid);

                            mail.Subject = "The Birthday Times!!!";

                            string strBody =


                                             "<html xmlns='http://www.w3.org/1999/xhtml'>" +
                                            "<head>" +
                                            "</head>" +
                                            "<body>" +
                                            "<table border='1px'>" +
                                            "<tr>" +
                                            "<td align='left' colspan='3' rowspan='2' style='width: 909px; height: 428px' valign='top'>" +
                                            "<table style='font-weight: bold; font-size: 13pt; text-transform: capitalize; color: #000000; font-family: 'Monotype Corsiva', Cursive'>" +
                                            "<tr>" +
                                            "<td style='WIDTH: 300px' align='left' valign='top'>" +
                                            "<img src='cumple.gif' alt='' /></td>" +
                                            "<td colspan='3' style='width: 609px' align='left' valign='top'>" +
                                            "<table style='width: 605px'>" +
                                            "<tr>" +
                                            "<td align='left' colspan='3' style='width: 541px' valign='top'>" +
                                            "<img src='img1.gif' style='width: 601px; height: 170px'  alt=''/></td>" +
                                            "</tr>" +
                                            "<tr>" +
                                            "<td colspan='3' style='width: 541px; height: 331px' valign='top'>" + sw.ToString() + "</td>" +
                                            "</tr>" +
                                            "<tr>" +
                                            "<td align='right' colspan='3' >Regards,</td>" +
                                            "</tr>" +
                                            "<tr>" +
                                            "<td align='right' colspan='3' style='width: 541px; height: 9px' valign='top'>HR Team</td>" +
                                            "</tr>" +
                                            "</table>" +
                                            "</td>" +
                                            "</tr>" +
                                            "</table>" +
                                            "</td>" +
                                            "</tr>" +
                                            "<tr>" +
                                            "</tr>" +
                                            "</table>" +

                                            "</body>" +
                                            "</html>";



                            mail.Body = strBody;
                            mail.IsBodyHtml = true;

                            smtp.Port = 25;
                            smtp.Credentials = new System.Net.NetworkCredential("calculus@pamac.com", "pamac@123");
                            smtp.EnableSsl = false;

                        }

                    }

                }
                mail.To.Add("edp@pamac.com");
                smtp.Send(mail);

                SqlCommand sqlcmd1 = new SqlCommand();
                sqlcmd1.Connection = sqlcon;
                sqlcmd1.CommandType = CommandType.StoredProcedure;
                sqlcmd1.CommandText = "SetBirthdayflag";
                sqlcmd1.CommandTimeout = 0;

                sqlcon.Open();
                int RowEffected = sqlcmd1.ExecuteNonQuery();
                sqlcon.Close();
            }
        }

        catch (Exception e)
        {
            Label1.Text = e.Message;
        }

        finally
        {

        }

    }

    private void Email1222222()
    {
        try
        {

            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient("103.13.99.137", 25);

            string Emailid;


            string str = string.Empty;


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
           // sqlcmd.CommandText = "sp_MondayBday";
            sqlcmd.CommandText = "image_show1";
            sqlcmd.CommandTimeout = 0;

            sqlcon.Open();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcmd;

            DataSet ds = new DataSet();
            da.Fill(ds);

            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();


                int count1 = ds.Tables[1].Rows.Count;

                mail.Attachments.Add(new Attachment(@"E:\Live PMS Site Consolidated\PublishMumbai\Employeemanagement\mailimage\imagquto.jpg"));
                //mail.Attachments.Add(new Attachment(@"E:\Live PMS Site Consolidated\PublishMumbai\Employeemanagement\mailimage\Untitled.jpg"));

                for (int i = 0; i < count1; i++)
                {


                    using (StringWriter sw = new StringWriter())
                    {
                        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                        {
                            StringReader sr = new StringReader(sw.ToString());
                            GridView1.RenderControl(hw);

                            mail.From = new MailAddress("calculus@pamac.com", "Birthday Wishes!!!");

                            Emailid = "";
                            Emailid = ds.Tables[1].Rows[i]["Email_Id"].ToString();


                            mail.Bcc.Add(Emailid);

                            mail.Subject = "The Birthday Times!!!";





                            string strBody =


                            "<html xmlns='http://www.w3.org/1999/xhtml'>" +
                            "<head>" +
                            "</head>" +
                            "<body>" +
                            "<table style='width: 766px' border='1px'>" +
                            "<tr>" +
                            "<td align='left' colspan='3' rowspan='1' style='width: 762px; height: 454px' valign='top'>" +
                            "<table>" +
                            "<tr>" +
                            "<td colspan='4' style='font-weight: bold; font-size: 35pt; text-transform: capitalize; color: #663399; font-family: Cursive' align='center'>" +
                            "Happy BirthDay</td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td align='center' colspan='4' style='font-weight: bold; font-size: 35pt; text-transform: capitalize;" +
                            "color: #663399; font-family: Cursive; height: 1px'>" +
                            "</td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td colspan='2' style='width: 346px'>" +
                            "<img src='imagquto.jpg' style='width: 304px; height: 417px' alt='' /></td>" +
                            "<td style='width: 25383px' valign='middle' align='center'>" +
                            "&nbsp;&nbsp;&nbsp;</td>" +
                            "<td style='width: 712px' valign='top'>" +
                            "<table style='width: 444px; height: 124px'>" +
                            "<tr>" +
                            "<td colspan='3'>" +
                            "</td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td colspan='3' style='font-size: 12pt; color: #663399; font-family: Cambria' align='left' valign='top'>" +
                            "</td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td colspan='3' style='font-size: 13pt; color: #663399; font-family: Cambria; text-transform: capitalize;' align='left' valign='middle'>" + sw.ToString() + "</td>" +
                            "</tr>" +
                            "</table>" +
                            "</td>" +
                             "</tr>" +
                            "<tr>" +
                            "<td colspan='4'  style='font-size: 13pt; color: #663399; font-family: Cambria; text-transform: capitalize;' align='right' valign='top'>" +
                            "HR Team</td>" +
                             "</tr>" +
                            "</table>" +
                            "</td>" +
                            "</tr>" +
                              "<tr>" +
                            "<td align='left' colspan='3' rowspan='3' style='width: 762px; background-color:#595699' valign='top'>" +
                            "</td>" +
                            "</tr>" +
                            "<tr>" +
                             "</tr>" +
                            "<tr>" +
                             "</tr>" +
                            "</table>" +

                            "</body>" +
                            "</html>";



                            mail.Body = strBody;
                            mail.IsBodyHtml = true;

                            smtp.Port = 25;
                            smtp.Credentials = new System.Net.NetworkCredential("calculus@pamac.com", "pamac@123");
                            smtp.EnableSsl = false;

                        }

                    }

                }
                mail.To.Add("edp@pamac.com");
                smtp.Send(mail);

                SqlCommand sqlcmd1 = new SqlCommand();
                sqlcmd1.Connection = sqlcon;
                sqlcmd1.CommandType = CommandType.StoredProcedure;
                sqlcmd1.CommandText = "SetBirthdayflag";
                sqlcmd1.CommandTimeout = 0;

                sqlcon.Open();
                int RowEffected = sqlcmd1.ExecuteNonQuery();
                sqlcon.Close();
            }
        }

        catch
        {

        }

        finally
        {

        }

    }

    private void Email2333333()
    {
        try
        {

            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient("103.13.99.137", 25);

            string Emailid;


            string str = string.Empty;


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
           // sqlcmd.CommandText = "sp_MondayBday";
            sqlcmd.CommandText = "image_show1";
            sqlcmd.CommandTimeout = 0;

            sqlcon.Open();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcmd;

            DataSet ds = new DataSet();
            da.Fill(ds);

            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();


                int count1 = ds.Tables[1].Rows.Count; 
                mail.Attachments.Add(new Attachment(@"E:\Live PMS Site Consolidated\PublishMumbai\Employeemanagement\mailimage\birthday-19.gif"));
               // mail.Attachments.Add(new Attachment(@"E:\Live PMS Site Consolidated\PublishMumbai\Employeemanagement\mailimage\Untitled.jpg"));

                for (int i = 0; i < count1; i++)
                {
                    using (StringWriter sw = new StringWriter())
                    {
                        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                        {
                            StringReader sr = new StringReader(sw.ToString());
                            GridView1.RenderControl(hw);

                            mail.From = new MailAddress("calculus@pamac.com", "Birthday Wishes!!!");

                            Emailid = "";
                            Emailid = ds.Tables[1].Rows[i]["Email_Id"].ToString();


                            mail.Bcc.Add(Emailid);

                            mail.Subject = "The Birthday Times!!!";





                            string strBody =


                            "<html xmlns='http://www.w3.org/1999/xhtml'>" +
                            "<head>" +
                            "</head>" +
                            "<body>" +
                            "<table style='width: 741px; height: 314px;' border='1px'>" +
                            "<tr>" +
                            "<td colspan='3' rowspan='3' style='height: 269px; width: 768px; ' align='left' valign='top' >" +
                            "<table>" +
                            "<tr>" +
                            "<td colspan='3' style='height: 21px'>" +
                            "<img src='birthday-19.gif' style='width: 756px; height: 254px' alt='' /></td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td colspan='3' style='font-size: 13pt; text-transform: capitalize; font-family: Cambria' align='left' valign='top'>" + sw.ToString() + "</td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td colspan='3' style='font-size: 13pt; text-transform: capitalize; font-family: Cambria' align='right' valign='top' >" +
                            "HR Team</td>" +
                            "</tr>" +
                            "</table>" +
                            "</td>" +
                            "</tr>" +
                            "<tr>" +
                            "</tr>" +
                            "<tr>" +
                            "</tr>" +
                            "</table>" +

                            "</body>" +
                            "</html>";



                            mail.Body = strBody;
                            mail.IsBodyHtml = true;

                            smtp.Port = 25;
                            smtp.Credentials = new System.Net.NetworkCredential("calculus@pamac.com", "pamac@123");
                            smtp.EnableSsl = false;

                        }

                    }

                }
                mail.To.Add("edp@pamac.com");
                smtp.Send(mail);


                SqlCommand sqlcmd1 = new SqlCommand();
                sqlcmd1.Connection = sqlcon;
                sqlcmd1.CommandType = CommandType.StoredProcedure;
                sqlcmd1.CommandText = "SetBirthdayflag";
                sqlcmd1.CommandTimeout = 0;

                sqlcon.Open();
                int RowEffected = sqlcmd1.ExecuteNonQuery();
                sqlcon.Close();
            }
        }

        catch
        {

        }

        finally
        {

        }

    }


    protected void Email_Click(object sender, EventArgs e)
    {       
      Email2333333();
    }
    protected void Email1_Click(object sender, EventArgs e)
    {
       Email1222222();       
    }
    protected void Email2_Click(object sender, EventArgs e)
    {
       Email1111();      
    }
}
