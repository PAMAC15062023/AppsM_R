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
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data.OleDb;

public partial class HR_HR_PhotoNotification : System.Web.UI.Page
{

    CCommon objconn = new CCommon();
    //OleDbConnection sqlconn = new OleDbConnection();

    string filename_Attachment;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
        }
    }

    private void Fillgrid()
    {


        SqlConnection sqlCon = new SqlConnection(objconn.AppConnectionString);


        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlCon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_photoPath_allcluster";//"Get_photoPath";
        sqlcmd.CommandTimeout = 0;

        SqlParameter emp_id = new SqlParameter();
        emp_id.SqlDbType = SqlDbType.VarChar;
        emp_id.Value = Session["Userid"].ToString();
        emp_id.ParameterName = "@Emp_Id";
        sqlcmd.Parameters.Add(emp_id);


        SqlParameter FromDate = new SqlParameter();
        FromDate.SqlDbType = SqlDbType.VarChar;
        FromDate.Value = objconn.strDate(txtFromdate.Text.ToString());
        FromDate.ParameterName = "@FromDate";
        sqlcmd.Parameters.Add(FromDate);

        SqlParameter Todate = new SqlParameter();
        Todate.SqlDbType = SqlDbType.VarChar;
        Todate.Value = objconn.strDate(txtTodate.Text.ToString());
        Todate.ParameterName = "@Todate";
        sqlcmd.Parameters.Add(Todate);

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = sqlcmd;

        DataTable dt = new DataTable();
        da.Fill(dt);


        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }

        //RowEffected = sqlcmd.ExecuteNonQuery();
        //lblMessage.Visible = true;
        //lblMessage.Text = "Data Updated Successfuly !!!!!!!";
        ////  clearcontrol();

        //sqlCon.Close();

    }
    protected void Btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrganizationTree.aspx");
    }
    protected void lnkdownload_Click(object sender, EventArgs e)
    {
        string DownloadPath = ((System.Web.UI.WebControls.LinkButton)(sender)).CommandArgument.ToString();
        if (DownloadPath != "")
        {
            DownloadFile(DownloadPath, true);
        }
        else
        {
            lblMessage.Text = "No Attached Document Found...!!!";
        }
    }

    private void DownloadFile(string fname, bool forceDownload)
    {
        try
        {
            string path = "EmployeePhoto\\"+fname;
            string name = Path.GetFileName(path);
            string ext = Path.GetExtension(path);
            string type = "";
            // set known types based on file extension  
            if (ext != null)
            {
                switch (ext.ToLower())
                {
                    case ".txt":
                        type = "text/plain";
                        break;
                    case ".doc":
                    case ".rtf":
                        type = "Application/msword";
                        break;
                    case ".zip":
                        type = "application/zip";
                        break;
                    case ".xls":
                        type = "application/vnd.ms-excel";
                        break;
                }
            }
            if (forceDownload)

                Response.ClearHeaders();
            Response.ClearContent();
            Response.Clear();

            {
                Response.AppendHeader("content-disposition", "attachment; filename=" + name);
            }
            if (type != "")

                Response.ContentType = type;
            Response.WriteFile(path);
            Response.End();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[4].Visible = false;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Fillgrid();
    }
}


