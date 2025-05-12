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
        Application_start();

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
            Thread.Sleep(TimeSpan.FromSeconds(30));
            // Do something every half hour
            
            
                //Email();



        }
    }


   
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }


    private void Email()
    {
         try
             {
            
        MailMessage mail = new MailMessage();
        SmtpClient smtp = new SmtpClient("69.64.70.36", 25);

        string Emailid;

     
        string str = string.Empty;

     
        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
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


            for (int i = 0; i < count1; i++)
            {
              

                    using (StringWriter sw = new StringWriter())
                    {
                        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                        
                        {

                          

                            StringReader sr = new StringReader(sw.ToString());
                            GridView1.RenderControl(hw);

                            mail.From = new MailAddress("calculus@pamac.com", "Birthday Wishes!!!");


                           

                            Emailid = ds.Tables[1].Rows[i]["Email_Id"].ToString();
                            mail.To.Add(Emailid);

                            mail.Subject = "The Birthday Times !!!";



                            mail.Attachments.Add(new Attachment(@"E:\Live PMS Site Consolidated\PublishMumbai\Employeemanagement\mailimage\bday18[1].gif"));
                            mail.Attachments.Add(new Attachment(@"E:\Live PMS Site Consolidated\PublishMumbai\Employeemanagement\mailimage\cumple11[1].gif"));
                     
                            string strBody =
                                            

                                            "<html xmlns='http://www.w3.org/1999/xhtml'>" +
                                            "<head>" +
                                            "</head>" +
                                            "<body>" +
                                            "<table border='1px'>" +
                                            "<tr>" +
                                            "<td align='left' colspan='3' rowspan='2' style='width: 909px; height: 428px' valign='top'>" +
                                            "<table>" +
                                            "<tr>" +
                                            "<td style='WIDTH: 300px' align='left' valign='top'>" +
                                            "<img src='cumple11[1].gif' /></td>" +
                                            "<td colspan='3' style='width: 609px' align='left' valign='top'>" +
                                            "<table style='width: 605px'>" +
                                            "<tr>" +
                                            "<td align='left' colspan='3' style='width: 541px' valign='top'>" +
                                            "<img src='bday18[1].gif' style='width: 601px; height: 170px' /></td>" +
                                            "</tr>" +
                                            "<tr>" +
                                            "<td colspan='3' style='width: 541px; height: 331px' valign='top'>" + sw.ToString() + "</td>" +
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
                            smtp.Credentials = new System.Net.NetworkCredential("calculus@pamac.com", "qw@!34GH");
                            smtp.EnableSsl = false;

                            smtp.Send(mail);

                        }
              

            }
            
        }
    }
}

        catch
        {
           
        }
        finally
        {
        }

    }
     
    }
    



