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




    public void Quotes_image_insert(string quotes_imagename)
    {

        SqlCommand sqlcmd1 = new SqlCommand();
        sqlcmd1.Connection = sqlcon;
        sqlcmd1.CommandType = CommandType.StoredProcedure;
        sqlcmd1.CommandText = "Quotes_image_insert";

        SqlDataAdapter newda1 = new SqlDataAdapter();
        newda1.SelectCommand = sqlcmd1;

        sqlcmd1.Parameters.AddWithValue("@quotes_image_name", quotes_imagename);
        DataSet newds1 = new DataSet();
        newda1.Fill(newds1);

    }



    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);
       // Application_start();
    }



    void Application_start()
    {
        Thread thread = new Thread(CronThread);
        thread.IsBackground = true;
       // thread.Start();


    }

    private void CronThread()
    {
        while (true)
        {
            Thread.Sleep(TimeSpan.FromSeconds(30));
            // Do something every half hour

           // Email1();



        }
    }
    
 
    private void Email1()
    {

        MailMessage mail = new MailMessage();
        SmtpClient smtp = new SmtpClient("69.64.70.36", 25);

        string Emailid;

        string strimg ="";
        //string empname;


        //getdate

        SqlCommand sqlcmd2 = new SqlCommand();
        sqlcmd2.Connection = sqlcon;
        sqlcmd2.CommandType = CommandType.StoredProcedure;
        sqlcmd2.CommandText = "Quotes_GetBirthdayDate";

        sqlcon.Open();
        SqlDataAdapter da2 = new SqlDataAdapter();
        da2.SelectCommand = sqlcmd2;

        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        sqlcon.Close();
       
        //Emailid = "Rupesh.Zodage@pamac.com";

        //image  
        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Quotes_image_show";

        sqlcmd.CommandTimeout = 0;
        sqlcon.Open();
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = sqlcmd;

        DataSet ds = new DataSet();
        da.Fill(ds);
        sqlcon.Close();
        //emalid

        SqlCommand sqlcmd1 = new SqlCommand();
        sqlcmd1.Connection = sqlcon;
        sqlcmd1.CommandType = CommandType.StoredProcedure;
        sqlcmd1.CommandText = "emaiidrote";
        sqlcon.Open();
        SqlDataAdapter da1 = new SqlDataAdapter();
        da1.SelectCommand = sqlcmd1;

        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        sqlcon.Close();

        int count = ds1.Tables[0].Rows.Count;


        for (int i = 0; i < count; i++)
        {
            try
            {


                mail.From = new MailAddress("calculus@pamac.com", "PAMAC HR");

                strimg = ds.Tables[0].Rows[i]["quotes_image_name"].ToString();
                //empname = ds2.Tables[0].Rows[i]["FULLNAME"].ToString();

                Emailid = "";
                Emailid = ds1.Tables[0].Rows[i]["Email_Id"].ToString();
              

                mail.Bcc.Add(Emailid);
                mail.Subject = "Daily Quotes";


                string strBody =
                           "<html><body><font color=\"Navy\" style=\"font-style=Italic;font-weight=bold\">" +
                           "<img src='" + strimg + "' alt=''/>" +
                         
                           "<P>Regards,</P>" +
                           "<P>HR TEAM</P>" +
                           "</font></body></html>";

                mail.Attachments.Add(new Attachment(@"D:\akanksha work\New_PMS_Merage19\PublishMumbai14\Employeemanagement\images\" + strimg));

                mail.Body = strBody;
                mail.IsBodyHtml = true;

                smtp.Port = 25;
                smtp.Credentials = new System.Net.NetworkCredential("calculus@pamac.com", "qw@!34GH");
                smtp.EnableSsl = false;

               // smtp.Send(mail);
              
            }


            catch
            {
            }
            finally
            {
            }
        }

        mail.To.Add("edp@pamac.com");
        smtp.Send(mail);
        Quotes_image_insert(strimg);
    }


}
