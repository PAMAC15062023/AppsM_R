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

public partial class FTP_FTP_Dynamic_FTP_UploadFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MainData();
            //Get_UserList();
            //Get_EmployeeNameList();
 
          
        }
      UploadValidation();        
    }

    //private void Get_EmployeeNameList()
    //{
    //  CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
    //    sqlcon.Open();

    //    SqlCommand sqlcmd = new SqlCommand();
    //    sqlcmd.Connection = sqlcon;
    //    sqlcmd.CommandType = CommandType.StoredProcedure;
    //    sqlcmd.CommandText = "Get_Employee_Data_Supervisor_Ftp";    /////"Get_EmployeeNameList";
    //    sqlcmd.CommandTimeout = 0;

    //    SqlParameter CentreID = new SqlParameter();
    //    CentreID.SqlDbType = SqlDbType.Int;
    //    CentreID.Value = Session["CentreID"].ToString();
    //    CentreID.ParameterName = "@CentreID";
    //    sqlcmd.Parameters.Add(CentreID);

    //    SqlDataAdapter sqlda = new SqlDataAdapter();
    //    sqlda.SelectCommand = sqlcmd;
    //    DataTable dt = new DataTable();
    //    sqlda.Fill(dt);
    //    sqlcon.Close();

    //    if (dt.Rows.Count > 0)
    //    {
    //        ddlEmpName.DataValueField = "EMP_ID";
    //        ddlEmpName.DataTextField = "FullName";



    //        ddlEmpName.DataSource = dt;
    //        ddlEmpName.DataBind();
    //    }
    //    else
    //    {
    //        ddlEmpName.DataSource = null;
    //        ddlEmpName.DataBind();

    //        //lblPnlErrorMessage.Text = "Record Not Found";
    //    }

    //    ddlEmpName.Items.Insert(0, "--Select--");
    //    ddlEmpName.SelectedIndex = 0;

    //}

    


    private void UploadValidation()
    {
        btnSave.Attributes.Add("onclick", "javascript:return ValidationControl();");
    }

    //private void Get_UserList()
    //{
    //    try
    //    {

    //        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
    //        sqlcon.Open();

    //        SqlCommand sqlCom = new SqlCommand();
    //        sqlCom.Connection = sqlcon;
    //        sqlCom.CommandType = CommandType.StoredProcedure;
    //        sqlCom.CommandText = "Get_Employee_Data_Mgr";

    //        SqlParameter UserName = new SqlParameter();
    //        UserName.SqlDbType = SqlDbType.VarChar;
    //        UserName.Value = " ";
    //        UserName.ParameterName = "@UserName";
    //        sqlCom.Parameters.Add(UserName);


    //        SqlDataAdapter sqlDA = new SqlDataAdapter();
    //        sqlDA.SelectCommand = sqlCom;
    //        DataTable dt = new DataTable();
    //        sqlDA.Fill(dt);
    //        sqlcon.Close();

    //        ddlRequestBy.DataTextField = "Employee_Name";
    //        ddlRequestBy.DataValueField = "Emp_id";

    //        ddlRequestBy.DataSource = dt;
    //        ddlRequestBy.DataBind();

    //        ddlRequestBy.Items.Insert(0, "--Select--");
    //        ddlRequestBy.SelectedIndex = 0;

    //        ddlRequestBy.Focus();

    //    }
    //    catch (Exception ex)
    //    {
    //        lblMessage.Visible = true;
    //        lblMessage.Text = ex.Message;
    //        lblMessage.CssClass = "ErrorMessage";
    //    }
    //}

    private void MainData()
    { 
            GridData();
            ValidationControl();       
            FtpUploadRecentFile();
    }

    private void FtpUploadRecentFile()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_FtpUploadRecentFile";
        sqlcmd.CommandTimeout = 0;

        SqlParameter UserId = new SqlParameter();
        UserId.SqlDbType = SqlDbType.VarChar;
        UserId.Value = Session["UserId"].ToString();
        UserId.ParameterName = "@UserId";
        sqlcmd.Parameters.Add(UserId);

        SqlParameter @IsDate = new SqlParameter();
        @IsDate.SqlDbType = SqlDbType.Char;
        @IsDate.Value = "Y";
        @IsDate.ParameterName = "@IsDate";
        sqlcmd.Parameters.Add(@IsDate);

        SqlParameter FromDate = new SqlParameter();
        FromDate.SqlDbType = SqlDbType.VarChar;
        FromDate.Value = "";
        FromDate.ParameterName = "@FromDate";
        sqlcmd.Parameters.Add(FromDate);

        SqlParameter ToDate = new SqlParameter();
        ToDate.SqlDbType = SqlDbType.VarChar;
        ToDate.Value = "";
        ToDate.ParameterName = "@ToDate";
        sqlcmd.Parameters.Add(ToDate);

        SqlParameter FileName = new SqlParameter();
        FileName.SqlDbType = SqlDbType.VarChar;
        FileName.Value = "";
        FileName.ParameterName = "@FileName";
        sqlcmd.Parameters.Add(FileName);

        SqlParameter FileExt = new SqlParameter();
        FileExt.SqlDbType = SqlDbType.VarChar;
        FileExt.Value = "";
        FileExt.ParameterName = "@FileExt";
        sqlcmd.Parameters.Add(FileExt);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }
        else
        {
            DataList1.DataSource = null;
            DataList1.DataBind();
            lblMessage2.Text = "Recently No Any File Uploaded";
        }
    }

    private void GetCaptureFile()
    {

        try
        {
            for (int i = 0; i <= rptFileUpload.Items.Count - 1; i++)
            {

                FileUpload upload = (FileUpload)rptFileUpload.Items[i].FindControl("FileUpload");

                HiddenField hdnFileID = (HiddenField)rptFileUpload.Items[i].FindControl("hdnFileID");
                HiddenField hdnRequestId = (HiddenField)rptFileUpload.Items[i].FindControl("hdnRequestId");

                TextBox txtContentExpireDate = (TextBox)rptFileUpload.Items[i].FindControl("txtContentExpireDate");

                if (upload.PostedFile.ContentLength == 0)
                    continue;

                {

                    if (Path.GetExtension(upload.FileName).ToUpper() != ".EXE")
                    {

                      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
                       

                        SqlCommand sqlcmd = new SqlCommand();
                        sqlcmd.Connection = sqlcon;
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.CommandText = "Insert_FtpUploadFileInfo";
                        sqlcmd.CommandTimeout = 0;

                        SqlParameter FileUpload_Path = new SqlParameter();
                        FileUpload_Path.SqlDbType = SqlDbType.VarChar;
                        FileUpload_Path.Value = Path.GetFullPath(upload.FileName);
                        FileUpload_Path.ParameterName = "@FileUpload_Path";
                        sqlcmd.Parameters.Add(FileUpload_Path);

                        SqlParameter File_Name = new SqlParameter();
                        File_Name.SqlDbType = SqlDbType.VarChar;
                        File_Name.Value = Path.GetFileName(upload.FileName);
                        File_Name.ParameterName = "@File_Name";
                        sqlcmd.Parameters.Add(File_Name);

                        SqlParameter File_Extension = new SqlParameter();
                        File_Extension.SqlDbType = SqlDbType.VarChar;
                        File_Extension.Value = Path.GetExtension(upload.FileName);
                        File_Extension.ParameterName = "@File_Extension";
                        sqlcmd.Parameters.Add(File_Extension);

                        SqlParameter File_Size = new SqlParameter();
                        File_Size.SqlDbType = SqlDbType.VarChar;
                        File_Size.Value = upload.PostedFile.ContentLength.ToString();
                        File_Size.ParameterName = "@File_Size";
                        sqlcmd.Parameters.Add(File_Size);

                        SqlParameter File_WorkStation = new SqlParameter();
                        File_WorkStation.SqlDbType = SqlDbType.VarChar;
                        File_WorkStation.Value = Page.User.Identity.Name.ToString();
                        File_WorkStation.ParameterName = "@File_WorkStation";
                        sqlcmd.Parameters.Add(File_WorkStation);

                        SqlParameter File_Binary = new SqlParameter();
                        File_Binary.SqlDbType = SqlDbType.VarChar;
                        File_Binary.Value = FtpUploadFilePath(upload, Path.GetExtension(upload.FileName));
                        File_Binary.ParameterName = "@File_Binary";
                        sqlcmd.Parameters.Add(File_Binary);

                        SqlParameter File_Expire_Date = new SqlParameter();
                        File_Expire_Date.SqlDbType = SqlDbType.VarChar;
                        File_Expire_Date.Value = txtContentExpireDate.Text.Trim();
                        File_Expire_Date.ParameterName = "@File_Expire_Date";
                        sqlcmd.Parameters.Add(File_Expire_Date);

                        SqlParameter RequestID = new SqlParameter();
                        RequestID.SqlDbType = SqlDbType.Int;
                        RequestID.Value = hdnRequestId.Value;
                        RequestID.ParameterName = "@RequestID";
                        sqlcmd.Parameters.Add(RequestID);

                        SqlParameter FileID = new SqlParameter();
                        FileID.SqlDbType = SqlDbType.Int;
                        FileID.Value = hdnFileID.Value;
                        FileID.ParameterName = "@FileID";
                        sqlcmd.Parameters.Add(FileID);

                        SqlParameter UserId = new SqlParameter();
                        UserId.SqlDbType = SqlDbType.VarChar;
                        UserId.Value = Session["UserId"].ToString();
                        UserId.ParameterName = "@UserId";
                        sqlcmd.Parameters.Add(UserId);

                        sqlcon.Open();
                         int k= sqlcmd.ExecuteNonQuery();
                        sqlcon.Close();

                        if (k > 0)
                        {
                            lblMessage.Text = "Record Update Succesfully";
                        }


                    }

                    else
                    {
                        lblMessage.Text = "EXE File Are Not Allow";
                        break;
                    }
                }

                
            }
                MainData();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }    
    }
    private string FtpUploadFilePath(FileUpload FileUpload, string FileFormat)
    {
        string fullSitePath = Convert.ToString(ConfigurationSettings.AppSettings["FtpUploadFilePath"]);
        fullSitePath = fullSitePath.Trim();
        string FileSavePath = "";

        string fileName = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss")) + FileFormat.Trim();
        FileSavePath = fullSitePath + "\\" + fileName;

        FileUpload.SaveAs(FileSavePath);
        return FileSavePath;
    }

    private void SumOfRequestFile(int req_id)
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_FtpFileSumDetails";
        sqlcmd.CommandTimeout = 0;

        SqlParameter UserId = new SqlParameter();
        UserId.SqlDbType = SqlDbType.VarChar;
        UserId.Value = Session["UserId"].ToString();
        UserId.ParameterName = "@UserId";
        sqlcmd.Parameters.Add(UserId);


        SqlParameter reqid = new SqlParameter();
        reqid.SqlDbType = SqlDbType.VarChar;
        reqid.Value = req_id;
        reqid.ParameterName = "@req_id";
        sqlcmd.Parameters.Add(reqid);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            rptFileUpload.DataSource = dt;
            rptFileUpload.DataBind();
            lblFileUpload.Text = "Total no of files to be uplaod:" + dt.Rows.Count.ToString();

        }
        else
        {
            rptFileUpload.DataSource = null;
            rptFileUpload.DataBind();
            lblFileUpload.Text = "Record Not Found for upload"; 
        }
        sqlcon.Close();
        
    }

    private void ValidationControl()
    {
        btnSave.Attributes.Add("onclick", "javascript:return ValidationControl();");   
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");  
    }

    private void GridData()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_FtpFileDetails";
        sqlcmd.CommandTimeout = 0;

        SqlParameter UserId = new SqlParameter();
        UserId.SqlDbType = SqlDbType.VarChar;
        UserId.Value = Session["UserId"].ToString();
        UserId.ParameterName = "@UserId";
        sqlcmd.Parameters.Add(UserId);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            GvUploadReq.DataSource = dt;
            GvUploadReq.DataBind();
            
        }
        else
        {
            GvUploadReq.DataSource = null;
            GvUploadReq.DataBind();
           
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
           
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Insert_FTP_FileRequest_Auth";
            sqlcmd.CommandTimeout = 0;

            SqlParameter File_UploadNos = new SqlParameter();
            File_UploadNos.SqlDbType = SqlDbType.VarChar;
            File_UploadNos.Value = txtFileNo.Text.Trim();
            File_UploadNos.ParameterName = "@File_UploadNos";
            sqlcmd.Parameters.Add(File_UploadNos);

            SqlParameter Remark = new SqlParameter();
            Remark.SqlDbType = SqlDbType.VarChar;
            Remark.Value = txtRemark.Text.Trim();
            Remark.ParameterName = "@Remark";
            sqlcmd.Parameters.Add(Remark);

            SqlParameter UserId = new SqlParameter();
            UserId.SqlDbType = SqlDbType.VarChar;
            UserId.Value = Session["userid"].ToString();   
            UserId.ParameterName = "@UserId";
            sqlcmd.Parameters.Add(UserId);


            SqlParameter request_id = new SqlParameter();
            request_id.SqlDbType = SqlDbType.Int;
            request_id.Direction = ParameterDirection.Output;
            request_id.ParameterName = "@request_id";
            sqlcmd.Parameters.Add(request_id);


            sqlcon.Open();
            int i=    sqlcmd.ExecuteNonQuery();
            int req_id = Convert.ToInt32(sqlcmd.Parameters["@request_id"].Value);         //IMP

            sqlcon.Close();

            if (i > 0)
            {
                lblMessage.Text = "Record Update Succesfully";

                SumOfRequestFile(req_id);
                

            }
            GridData();
            txtFileNo.Text = "";
            txtRemark.Text = ""; 

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;  
        }
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");  
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (RegisterValidation_On_Control() == true)
        {
            GetCaptureFile();
            FtpUploadRecentFile();
            Response.Redirect("FTP_FileView.aspx");
        }

    }

    private bool RegisterValidation_On_Control()
    {
        bool ErrorMsg = true;
        int count = 0;
        for (int i = 0; i <= rptFileUpload.Items.Count - 1; i++)
        {

            FileUpload upload = (FileUpload)rptFileUpload.Items[i].FindControl("FileUpload");
            TextBox txtContentExpireDate = (TextBox)rptFileUpload.Items[i].FindControl("txtContentExpireDate");

            if (upload.FileName != "")
            {
                if (upload.PostedFile.ContentLength > 15360000)/////////For 15MB//////////////
                //if (upload.PostedFile.ContentLength > 5120000)////////For 5MB///////////////
                {
                    lblMessage.Text = "File size should not more than 15MB";
                    ErrorMsg = false;
                    break;
                }
                if (txtContentExpireDate.Text == "")
                {
                    lblMessage.Text = "Please Enter Content Expire Date";
                    ErrorMsg = false;
                    txtContentExpireDate.Focus();
                    break;
                }
                else
                {
                    int iday = Convert.ToInt32(txtContentExpireDate.Text.Substring(0, 2));
                    int imonth = Convert.ToInt32(txtContentExpireDate.Text.Substring(3, 2));
                    int iyear = Convert.ToInt32(txtContentExpireDate.Text.Substring(6, 4));


                    DateTime d1 = new DateTime(iyear, imonth, iday);


                    TimeSpan ts = d1 - DateTime.Today;

                    int days = ts.Days;

                    if (days >= 30)
                    {
                        lblMessage.Text = "Content Expire Date should not be more than 30 days";
                        ErrorMsg = false;
                        txtContentExpireDate.Focus();
                        break;
                    }

                }

                count = count + 1;
            }          

         }

         if (count == 0 )
         {
             lblMessage.Text = "No File Found for Upload, Please select file! ";
             ErrorMsg = false;

         }

        return ErrorMsg;
    }



    protected void rptFileUpload_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item)||(e.Item.ItemType == ListItemType.AlternatingItem))
        {
              
            Image ImgExpireDate = (Image)e.Item.FindControl("ImgExpireDate");
            TextBox txtContentExpireDate = (TextBox)e.Item.FindControl("txtContentExpireDate");

            ImgExpireDate.Attributes.Add("onclick", "javascript:popUpCalendar(this," + txtContentExpireDate.ClientID + ",'dd/mm/yyyy',0,0);");


           // TextBox txtContentExpireDate = (TextBox)e.Item.FindControl("txtContentExpireDate");

            txtContentExpireDate.Text = System.DateTime.Now.AddDays(7).ToString("dd/MM/yyyy");
            txtContentExpireDate.ReadOnly = true;
        }

    }

    private void Update_File_Approved_RequestData(string ReqID,string UploadFile)
    {
        try
        {

            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Insert_FTP_FileRequest_Auth";
            sqlcmd.CommandTimeout = 0;

            SqlParameter RequestID = new SqlParameter();
            RequestID.SqlDbType = SqlDbType.VarChar;
            RequestID.Value = ReqID;
            RequestID.ParameterName = "@RequestID";
            sqlcmd.Parameters.Add(RequestID);

            //SqlParameter Status = new SqlParameter();
            //Status.SqlDbType = SqlDbType.VarChar;
            //Status.Value = status;
            //Status.ParameterName = "@Status";
            //sqlcmd.Parameters.Add(Status);

            SqlParameter Authorize_UploadNos = new SqlParameter();
            Authorize_UploadNos.SqlDbType = SqlDbType.VarChar;
            Authorize_UploadNos.Value = UploadFile;
            Authorize_UploadNos.ParameterName = "@File_UploadNos";
            sqlcmd.Parameters.Add(Authorize_UploadNos);

            //SqlParameter Expire_Date = new SqlParameter();
            //Expire_Date.SqlDbType = SqlDbType.VarChar;
            //Expire_Date.Value = ExpireDate;
            //Expire_Date.ParameterName = "@Expire_Date";
            //sqlcmd.Parameters.Add(Expire_Date);

            SqlParameter UserID = new SqlParameter();
            UserID.SqlDbType = SqlDbType.VarChar;
            UserID.Value = Session["UserID"].ToString();
            UserID.ParameterName = "@UserID";
            sqlcmd.Parameters.Add(UserID);

            SqlParameter File_UploadNos = new SqlParameter();
            File_UploadNos.SqlDbType = SqlDbType.VarChar;
            File_UploadNos.Value = txtFileNo.Text.Trim();
            File_UploadNos.ParameterName = "@File_UploadNos";
            sqlcmd.Parameters.Add(File_UploadNos);

            SqlParameter Remark = new SqlParameter();
            Remark.SqlDbType = SqlDbType.VarChar;
            Remark.Value = txtRemark.Text.Trim();
            Remark.ParameterName = "@Remark";
            sqlcmd.Parameters.Add(Remark);

         



            SqlParameter VarResult = new SqlParameter();
            VarResult.SqlDbType = SqlDbType.VarChar;
            //VarResult.Value = sTransrefno;
            VarResult.ParameterName = "@request_id";
            VarResult.Size = 200;
            VarResult.Direction = ParameterDirection.Output;
            sqlcmd.Parameters.Add(VarResult);

            int RowsEffeted = sqlcmd.ExecuteNonQuery();

            if (RowsEffeted > 0)
            {
                lblMessage.Text = "Record Successfully Updated!";
                //lblMessage.CssClass = "UpdateMessage";

            }

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";

        }

    }
   
}
