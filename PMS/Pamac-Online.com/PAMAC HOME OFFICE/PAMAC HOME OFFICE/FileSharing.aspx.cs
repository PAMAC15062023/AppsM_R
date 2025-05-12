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
using System.Net.Mail;
using System.Data.SqlClient;


public partial class FTP_FTP_Dynamic_FileSharing : System.Web.UI.Page
{
    //string Emailid;
    string Emailidcc;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Context.Request.QueryString["1"] != "")
            {
                hdnFileID.Value = Context.Request.QueryString["1"];
            }

            ControlValidation();
            GetFileName();
            GetSharedFileData();
            Get_EmployeeNameList();
        }
        string StrScript = "<script language='javascript'> javascript:Page_load_validation(); </script>";
        Page.RegisterStartupScript("OnLoad_1", StrScript);
   
    }

    private void GetSharedFileData()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "";
        sqlcmd.CommandTimeout = 0;
 

    }

    private void GetFileName()
    { 
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.Text;
        sqlcmd.CommandText = "select File_Name from FTP_File_UploadInfo where File_ID= '"+ hdnFileID.Value +"'";
        sqlcmd.CommandTimeout = 0;

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            txtSharedFileName.Text = dt.Rows[0]["File_Name"].ToString();  
        }
    }   

    private void Get_EmployeeNameList()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_Employee_Data_Supervisor";    /////"Get_EmployeeNameList";
        sqlcmd.CommandTimeout = 0;

        SqlParameter CentreID = new SqlParameter();
        CentreID.SqlDbType = SqlDbType.Int;
        CentreID.Value = Session["CentreID"].ToString();
        CentreID.ParameterName = "@CentreID";
        sqlcmd.Parameters.Add(CentreID);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlEmpName.DataValueField = "EMP_ID";
            ddlEmpName.DataTextField = "FullName";



            ddlEmpName.DataSource = dt;
            ddlEmpName.DataBind();
        }
        else
        {
            ddlEmpName.DataSource = null;
            ddlEmpName.DataBind();

            lblPnlErrorMessage.Text = "Record Not Found";
        }

        ddlEmpName.Items.Insert(0, "--Select--");
        ddlEmpName.SelectedIndex = 0;

    }

    private void ControlValidation()
    {
        //btnSearch.Attributes.Add("onclick", "javascript:return ValidControl();");
        btnAdd.Attributes.Add("onclick", "javascript:return MainTab_First_AddtoGrid();");
        btnDelete.Attributes.Add("onclick", "javascript:return Delete_MainTab('MainTab_First','" + hdnMainTab_First.ClientID + "','2');");


    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Inser_FTPUserViewRights";
            sqlcmd.CommandTimeout = 0;

            SqlParameter FileId = new SqlParameter();
            FileId.SqlDbType = SqlDbType.Int;
            FileId.Value = hdnFileID.Value;
            FileId.ParameterName = "@FileId";
            sqlcmd.Parameters.Add(FileId);

            SqlParameter Details = new SqlParameter();
            Details.SqlDbType = SqlDbType.VarChar;
            Details.Value = hdnMainTab_First.Value;
            Details.ParameterName = "@Details";
            sqlcmd.Parameters.Add(Details);

            SqlParameter UserId = new SqlParameter();
            UserId.SqlDbType = SqlDbType.VarChar;
            UserId.Value = Session["UserId"].ToString();
            UserId.ParameterName = "@UserId";
            sqlcmd.Parameters.Add(UserId);

           int i= sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            if (i > 0)
            {
                lblPnlErrorMessage.Text = "Record Save Succefully";
                Email();
            }
  
        }
        catch (Exception ex)
        {
            lblPnlErrorMessage.Text = ex.Message;
        }
    }


    private void Email()
    {


        CCommon objConn = new CCommon(); 
        SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlcon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "sp_getfullname_mail";

        SqlParameter FileId = new SqlParameter();
        FileId.SqlDbType = SqlDbType.Int;
        FileId.Value = hdnFileID.Value;
        FileId.ParameterName = "@file_id";
        sqlCom.Parameters.Add(FileId);

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;

        DataSet ds = new DataSet();
        sqlDA.Fill(ds);

       
        sqlcon.Close();

       
           
        string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
        string strhh = strTime.Remove(2);
        string strmm = strTime.Remove(0, 3);

        string Current = System.DateTime.Now.Date.ToString().Remove(10);

        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient("69.64.70.36", 25);

                mail.From = new MailAddress("calculus@pamac.com", "PAMAC PMS");

                //Emailid = "Rupesh.zodage@pamac.com";
                Emailidcc = ds.Tables[1].Rows[i]["pamac_emailid"].ToString();

                mail.To.Add(Emailidcc);
                //mail.CC.Add(Emailidcc);
                mail.Subject = "PAMAC HOME OFFICE";

                string strBody =
                           "<html><body><font color=\"Navy\" style=\"font-style=Italic;font-weight=bold\">" +

                           "<P>                                                                                               </P>" +
                           "<P>Dear Sir/Madam,</P>" +
                           "<P>                                                                                         </P>" +
                           "<P>This is to notify you that file " + ds.Tables[0].Rows[0]["file_name"].ToString() + " have been uploaded by " + ds.Tables[0].Rows[0]["fullname"].ToString() + " in PAMAC HOME OFFICE.</P>" +
                           "<P>                                                                                        </P>" +
                           "<P>Note:-</P>" +
                           "<P>                                                                                         </P>" +
                           "<P> Uploaded file will be avaliable on the FTP for 3 days from the date of uploaded and same will be automatically removed from the FTP after 3 days.</P>" +
                           "<p> This is automatically generated email,Please Do not reply.</P>" +
                           "<P>                                                                                          </P>" +
                           "<P>Regards,</P>" +
                   " "+ds.Tables[0].Rows[0]["fullname"].ToString() + "" +
                           " </font></html></body>";

                mail.Body = strBody;

                mail.IsBodyHtml = true;

                smtp.Port = 25;
                smtp.Credentials = new System.Net.NetworkCredential("calculus@pamac.com", "qw@!34GH");
                smtp.EnableSsl = false;

                smtp.Send(mail);
                lblPnlErrorMessage.Text = " Email successfully sent !!!" ;
                
            }
            catch (Exception ex)
            {
                lblPnlErrorMessage.Text = "Email Failed." + ex.Message;
            }
        }
    }


    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtSharedFileName.Text = "";
        ddlEmpName.SelectedIndex = 0;
        hdnMainTab_First.Value = ""; 
    }

    public void Get_fullname()
    {
        try
        {

            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "sp_getfullname_mail";

            SqlParameter FileId = new SqlParameter();
            FileId.SqlDbType = SqlDbType.Int;
            FileId.Value = hdnFileID.Value;
            FileId.ParameterName = "@file_id";
            sqlCom.Parameters.Add(FileId);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlcon.Close();
           

            
        }
        catch (Exception ex)
        {
            
        }
    }

    protected void ddlEmpName_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
