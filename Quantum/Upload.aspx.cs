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
using System.Web.Mail;
using System.Net.NetworkInformation;
using System.Data.SqlClient;


public partial class Upload : System.Web.UI.Page
{

    CCommon objconn = new CCommon();
    //OleDbConnection sqlconn = new OleDbConnection();

    string filename_Attachment;
    protected void Page_Load(object sender, EventArgs e)
    {

        

    }


    protected void Button1_Click1(object sender, EventArgs e)
    {
        try
        {

            SqlConnection sqlCon = new SqlConnection(objconn.AppConnectionString);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "UploadData";
            sqlcmd.CommandTimeout = 0;

            SqlParameter emp_id = new SqlParameter();
            emp_id.SqlDbType = SqlDbType.VarChar;
            emp_id.Value = Session["Userid"].ToString();
            emp_id.ParameterName = "@Emp_Id";
            sqlcmd.Parameters.Add(emp_id);

            SqlParameter filepath = new SqlParameter();
            filepath.SqlDbType = SqlDbType.VarChar;
            filepath.Value = UploadAttachment_OnServer1();
            filepath.ParameterName = "@FilePath";
            sqlcmd.Parameters.Add(filepath);


            SqlParameter CENTRE_ID = new SqlParameter();
            CENTRE_ID.SqlDbType = SqlDbType.VarChar;
            CENTRE_ID.Value = Session["CentreId"].ToString();
            CENTRE_ID.ParameterName = "@CENTRE_ID";
            sqlcmd.Parameters.Add(CENTRE_ID);

            sqlCon.Open();
            int RowEffected = 0;

            RowEffected = sqlcmd.ExecuteNonQuery();
            lblMessage.Visible = true;
            lblMessage.Text = "Data Updated Successfuly !!!!!!!";
            //  clearcontrol();

            sqlCon.Close();
           


        }
        catch
        {



        }


        //CheckSelectedEmp();
        ////Search();
        //lblMessage.Text = "";
        //FillUploadGrid();


        //Search12();
        //grdGrid.Visible = true;
        
        //try
        //{

        //    SqlConnection sqlCon = new SqlConnection(objconn.AppConnectionString);


        //    SqlCommand sqlcmd = new SqlCommand();
        //    sqlcmd.Connection = sqlCon;
        //    sqlcmd.CommandType = CommandType.StoredProcedure;
        //    sqlcmd.CommandText = "HR_SaveUploadData";
        //    sqlcmd.CommandTimeout = 0;

        //    SqlParameter emp_id = new SqlParameter();
        //    emp_id.SqlDbType = SqlDbType.VarChar;
        //    emp_id.Value =Session["UserID"].ToString();
        //    emp_id.ParameterName = "@Emp_Id";
        //    sqlcmd.Parameters.Add(emp_id);

        //    SqlParameter filepath = new SqlParameter();
        //    filepath.SqlDbType = SqlDbType.VarChar;
        //    filepath.Value = UploadAttachment_OnServer1();
        //    filepath.ParameterName = "@File_Path";
        //    sqlcmd.Parameters.Add(filepath);


        //    sqlCon.Open();
        //    int RowEffected = 0;

        //    RowEffected = sqlcmd.ExecuteNonQuery();
        //    lblMessage.Visible = true;
        //    lblMessage.Text = "Data Updated Successfuly !!!!!!!";
        //    //  clearcontrol();

        //    sqlCon.Close();



        //}
        //catch
        //{



        //}


        ////CheckSelectedEmp();
        //////Search();
        ////lblMessage.Text = "";
        ////FillUploadGrid();


        ////Search12();
        ////grdGrid.Visible = true;
    }


    private string UploadAttachment_OnServer1()
    {
        try
        {
            string FileSavePath = "";
            if (FileUpload1.FileName != "")
            {
                string strPath = Server.MapPath("HR/HR/EmployeeDocument/");

                strPath = strPath.Trim();
                filename_Attachment = (FileUpload1.FileName.Trim());
                filename_Attachment = filename_Attachment.Replace(" ", "_");
                FileSavePath = strPath + filename_Attachment;



                FileUpload1.SaveAs(FileSavePath);
            }
            return FileSavePath;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            return "";
        }
    }
    //protected void Button2_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("OrganizationTree.aspx");
    //}
    protected void Btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrganizationTree.aspx");
    }
}
