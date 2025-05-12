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

public partial class FTP_FTP_Dynamic_FTP_RenderPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string FileId = "";

        if (Context.Request.QueryString["1"] != "" || Context.Request.QueryString["1"] != null)
        {
            FileId = Context.Request.QueryString["1"].ToString();
            GenrateFile(FileId);
        }
    }
    private void GenrateFile(string strFileId)
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.Text;
        sqlcmd.CommandText = "select File_Binary,File_Extension from FTP_File_UploadInfo where File_Id='" + strFileId + "'";
        sqlcmd.CommandTimeout = 0;

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlcmd;

        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            byte[] Arr = (byte[])dt.Rows[0][0];
            
            

            //string format = dt.Rows[0]["File_Extension"].ToString().ToUpper();  

            //if (format == ".PDF")
            //{

            //    Response.ContentType = "application/pdf";
            //    Response.AddHeader("Content-disposition", "filename=output.pdf");

            //}
            //else if (format == ".XLS")
            //{

            //    Response.ContentType = "application/excel";
            //    Response.AddHeader("Content-disposition", "filename=output.xls");


            //}
            //else if (format == ".GIF")
            //{

            //    Response.ContentType = "image/gif";
            //    Response.AddHeader("Content-disposition", "filename=output.gif");

            //}
            //else if (format == ".JPG")
            //{

            //    Response.ContentType = "image/jpg";
            //    Response.AddHeader("Content-disposition", "filename=output.jpg");

            //}
            //else if (format == ".TXT")
            //{

            //    Response.ContentType = "application/txt";
            //    Response.AddHeader("Content-disposition", "filename=output.txt");

            //}
            //else if (format == ".DOC")
            //{

            //    Response.ContentType = "application/MS-WORD";
            //    Response.AddHeader("Content-disposition", "filename=output.doc");

            //}

            Response.Clear();
          
            Response.OutputStream.Write(Arr, 0, Arr.Length);
            Response.OutputStream.Flush();
           
            Response.End();
            Response.OutputStream.Close();            
            Response.Close();


        }        
    }
}
