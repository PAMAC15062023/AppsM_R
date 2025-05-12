using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Download : System.Web.UI.Page
{
    CCommon objconn = new CCommon();
    OleDbConnection sqlconn = new OleDbConnection();

    protected void Page_Load(object sender, EventArgs e)
    {
        Search12();
        grd1.Visible = true;
    }

    private void DownloadFile(string fname, bool forceDownload)
    {
        try
        {
            string path = fname;
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

    private void Search12()
    {
        string abc;
        SqlConnection sqlCon = new SqlConnection(objconn.AppConnectionString);
        try
        {

            sqlCon.Open();

            string proc = null;
            if (Session["RoleId"].ToString() == "1")
            {
                proc = "getdata_upload123";
            }
            else
            {
                proc = "getdata_upload1234";
            }


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlCon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = proc;
            cmd.CommandTimeout = 0;

            SqlParameter emp_id = new SqlParameter();
            emp_id.SqlDbType = SqlDbType.VarChar;
            emp_id.Value = Session["UserId"].ToString();
            emp_id.ParameterName = "@emp_id";
            cmd.Parameters.Add(emp_id);

            //Label l1 = new Label();
            //SqlDataReader dr;
            //dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    l1.Text = dr.GetValue(0).ToString();
            //    //abc = dr.ToString();
            //}


            //hdnempid.Value = l1.Text;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);





            sqlCon.Close();

            if (dt.Rows.Count > 0)
            {
                lblMessage.Text = "";
                lblMessage.Text = "Total Count Is :" + dt.Rows.Count;

                grd1.DataSource = dt;
                grd1.DataBind();
            }
            else
            {
                lblMessage.Text = "";
                lblMessage.Text = "Total Count Is :" + dt.Rows.Count;

                grd1.DataSource = null;
                grd1.DataBind();
            }
        }
        catch (Exception Ex)
        {
            lblMessage.Text = Ex.Message;
        }

    }


 

    protected void Btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrganizationTree.aspx");
    }


}
