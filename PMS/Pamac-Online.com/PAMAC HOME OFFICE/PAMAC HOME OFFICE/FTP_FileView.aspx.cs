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

public partial class FTP_FTP_Dynamic_FTP_FileView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetUserViewRights();
            Get_FTP_OtherShareFile();
            Get_FTP_Record_View_today();
            
        }
    }

    private void GetUserViewRights()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_FtpUserViewRights";
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
            GVshareData.DataSource = dt;
            GVshareData.DataBind();
        }
        else
        {
            GVshareData.DataSource = null;
            GVshareData.DataBind();
        }
    }

    private void ControlValidation()
    {
        //btnSearch.Attributes.Add("onclick", "javascript:return ValidControl();");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Get_FTP_Record_View();
        Get_FTP_OtherShareFile();
    }

    private void Get_FTP_Record_View()
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
        @IsDate.Value = "N";
        @IsDate.ParameterName = "@IsDate";
        sqlcmd.Parameters.Add(@IsDate);

        SqlParameter FromDate = new SqlParameter();
        FromDate.SqlDbType = SqlDbType.VarChar;
        FromDate.Value = txtFromDate.Text.Trim();
        FromDate.ParameterName = "@FromDate";
        sqlcmd.Parameters.Add(FromDate);

        SqlParameter ToDate = new SqlParameter();
        ToDate.SqlDbType = SqlDbType.VarChar;
        ToDate.Value = txtToDate.Text.Trim();
        ToDate.ParameterName = "@ToDate";
        sqlcmd.Parameters.Add(ToDate);

        SqlParameter FileName = new SqlParameter();
        FileName.SqlDbType = SqlDbType.VarChar;
        FileName.Value = txtFileName.Text.Trim();
        FileName.ParameterName = "@FileName";
        sqlcmd.Parameters.Add(FileName);

        SqlParameter FileExt = new SqlParameter();
        FileExt.SqlDbType = SqlDbType.VarChar;
        FileExt.Value = txtFileExt.Text.Trim();
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
            lblMessage.Text = "Record Not Found";
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtFromDate.Text = "";
        txtToDate.Text = "";
        txtFileName.Text = "";
        txtFileExt.Text = "";
        DataList1.DataSource = null;
        DataList1.DataBind();

        
    }

    protected void lnkShare_Click(object sender, EventArgs e)
    {        

    }

    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.AlternatingItem)||(e.Item.ItemType == ListItemType.Item))
        { 
        
            //OnClientClick="javascript:WindowOpen('<%# (DataBinder.Eval(Container.DataItem,"FILE_ID"))%>');"
            
            LinkButton lnkShare = (LinkButton)e.Item.FindControl("lnkShare");
            LinkButton lnkDownload = (LinkButton)e.Item.FindControl("lnkDownload");

          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = "select * from employee_master where DOL is null and Ftp_Manager=1 and emp_id='"+ Session["UserId"].ToString() +"'";
            sqlcmd.CommandTimeout = 0;

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                lnkDownload.Enabled = true;
            }
            else
            {
                lnkDownload.Enabled = false;
                
            }

            lnkShare.Attributes.Add("onclick", "javascript:return WindowOpen('" + ((System.Web.UI.WebControls.DataList)(sender)).DataKeys[e.Item.ItemIndex].ToString() + "');");
            //lnkDownload.Attributes.Add("onclick", "javascript:return WindowOpen1('" + ((System.Web.UI.WebControls.DataList)(sender)).DataKeys[e.Item.ItemIndex].ToString() + "');");
                    
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

            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            if (ext != null)
            {
                switch (ext.ToLower())
                {

                    case ".txt":
                        type = "text/plain";
                        break;
                    case ".html":
                        type = "text/plain";
                        break;
                    case ".pdf":
                        type = "Application/pdf";
                        break;
                    case ".doc":
                    case ".rtf":
                    case ".docx":
                        type = "Application/msword";
                        break;
                    case ".xls":
                    case ".xlsx":
                        type = "application/vnd.ms-excel";
                        break;
                    case ".mdb":
                    case ".mdbx":
                        type = "Application/msaccess";
                        break;
                    case ".ppt":
                    case ".pptx":
                        type = "Application/mspowerpoint";
                        break;
                    case ".zip":
                        type = "application/zip";
                        break;
                    case ".jpg":
                        type = "application/jpg";
                        break;
                }
            }
            if (forceDownload)
            {
                Response.AppendHeader("content-disposition","attachment; filename=" + name);
            }
            if (type != "")
                Response.ContentType = type;
            Response.WriteFile(path);
            Response.End();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }
    }

    protected void lnkDownload_Click(object sender, EventArgs e)
    {
        //string DownloadPath = ((System.Web.UI.WebControls.LinkButton)(sender)).CommandArgument.ToString();
        //if (DownloadPath != "")
        //{
        //    DownloadFile(DownloadPath, true);
        //}
        //else
        //{
        //    lblMessage.Text = "No Attach document found!";
        //}
        string DownloadPath = ((System.Web.UI.WebControls.LinkButton)(sender)).CommandArgument.ToString();
        if (DownloadPath != "")
        {
            DownloadFile(DownloadPath, true);
        }
        else
        {
            lblMessage.Text = "No Attach document found!";
        }
    }

    protected void IMap_Click(object sender, ImageMapEventArgs e)
    {
        
    }

    private void Get_FTP_OtherShareFile()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_FtpUploadShareFile_NEW";
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
            DataList2.DataSource = dt;
            DataList2.DataBind();
           
            }
        
        else
        {
            DataList2.DataSource = null;
            DataList2.DataBind();
        }
    }

    protected void lnkView_Click(object sender, EventArgs e)
    {
        string DownloadPath = ((System.Web.UI.WebControls.LinkButton)(sender)).CommandArgument.ToString();
        if (DownloadPath != "")
        {
            DownloadFile(DownloadPath, true);
        }
        else
        {
            lblMessage.Text = "No Attach document found!";
        }
    }

    //add by manswini

    private void Get_FTP_Record_View_today()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "sp_get_today_Records";
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
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }
        else
        {
            DataList1.DataSource = null;
            DataList1.DataBind();
            lblMessage.Text = "Record Not Found";
        }
    }
   //------------------Comp---------------------
  
}
