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
using System.Data.OleDb;

public partial class Default6 : System.Web.UI.Page
{
    CCommon ObjComm = new CCommon();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
        lblMsgXls.Visible = false;
    }




    protected void BtnImport_Click1(object sender, EventArgs e)
    {


        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        try
        {
            if (FileUpload1.HasFile)
            {

                String strPath = "";

                //to get the file extention
                String strFileName = FileUpload1.FileName.ToString();

                FileInfo fi = new FileInfo(strFileName);
                String strExt = fi.Extension;
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                if (strExt.ToLower() == ".xls")
                {
                    //Uploading file start.
                    strPath = Server.MapPath("HR/HR/EmployeeDocument/");

                    //strPath = strPath + strDateTime + FileUpload1.FileName;
                    strPath = strPath + strDateTime + ".xls";
                    FileUpload1.PostedFile.SaveAs(strPath);


                }
                string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strPath + @";Extended Properties=""Excel 8.0;IMEX=1""";

                OleDbConnection oleCon = new OleDbConnection(strConn);
                oleCon.Open();

                OleDbCommand oleCom = new OleDbCommand("SELECT * FROM [sheet1$]");
                oleCom.Connection = oleCon;

                OleDbDataAdapter oleDA = new OleDbDataAdapter();
                oleDA.SelectCommand = oleCom;

                DataTable dt = new DataTable();
                oleDA.Fill(dt);
                //GrdSalary.DataSource = dt;
                //GrdSalary.DataBind();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        Upload_BIS_Data(dt.Rows[i]);

                    }
                    lblMsgXls.Visible = true;
                    lblMsgXls.Text = "Data Imported Successfully!!";
                    lblMsgXls.CssClass = "UpdateMessage";



                    oleCon.Close();

                }
            }
            //String strPath = "";
            //String MyFile = "";
            //string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                //strPath = Server.MapPath("~/HR/ImportFiles/");
            //MyFile = strDateTime + ".xls";
            //strPath = (strPath + MyFile);
            //FileUpload1.PostedFile.SaveAs(strPath);

                //string strFileName = FileUpload1.FileName.ToString();

                //FileInfo fi = new FileInfo(strFileName);
            //string strExt = fi.Extension;

                //if (strExt.ToLower() == ".xls")
            //{
            //    string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strPath + @";Extended Properties=""Excel 8.0;IMEX=1""";


                //    sqlcon.Open();

                //    SqlCommand sqlCom = new SqlCommand("SELECT * FROM [sheet1$]");
            //    sqlCom.Connection = sqlcon;

                //    SqlDataAdapter sqlda = new SqlDataAdapter();
            //    sqlda.SelectCommand = sqlCom;

                //    DataTable dt = new DataTable();
            //    sqlda.Fill(dt);
            //    sqlcon.Close();

                //    if (dt.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < dt.Rows.Count; i++)
            //        {

                //            Upload_BIS_Data(dt.Rows[i]);

                //        }
            //        lblMsgXls.Text = "Data Imported Successfully!!";

                //    }


                //    //string strFile = Server.MapPath("~/HR/HRImport/") + MyFile;
            //    //if (File.Exists(strFile))
            //    //{
            //    //    File.Delete(strFile);
            //    //}
            //}

            //    else
            //    {
            //        lblMsgXls.Visible = true;
            //        lblMsgXls.Text = "It's Not An Excel File...!!!";
            //    }

            else
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Please Select Excel File To Import...!!!";
            }
        }
        catch (Exception ex)
        {
            lblMsgXls.Visible = true;
            lblMsgXls.Text = "Error :" + ex.Message;
        }
    }


    public void Upload_BIS_Data(DataRow dr)
    {
        try
        {

            CCommon objConn = new CCommon();
            SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);


            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Upload_emaildata";
            sqlcmd.CommandTimeout = 0;

            SqlParameter bridge_code = new SqlParameter();
            bridge_code.SqlDbType = SqlDbType.VarChar;
            bridge_code.Value = dr["bridge_code"].ToString();
            bridge_code.ParameterName = "@bridge_code";
            sqlcmd.Parameters.Add(bridge_code);

            SqlParameter Emp_Name = new SqlParameter();
            Emp_Name.SqlDbType = SqlDbType.VarChar;
            Emp_Name.Value = dr["Emp_Name"].ToString();
            Emp_Name.ParameterName = "@Emp_Name";
            sqlcmd.Parameters.Add(Emp_Name);



            SqlParameter Amount = new SqlParameter();
            Amount.SqlDbType = SqlDbType.VarChar;
            Amount.Value = dr["Amount"].ToString();
            Amount.ParameterName = "@Amount";
            sqlcmd.Parameters.Add(Amount);


            SqlParameter MonthYr = new SqlParameter();
            MonthYr.SqlDbType = SqlDbType.VarChar;
            MonthYr.Value = dr["MonthYr"].ToString();
            MonthYr.ParameterName = "@MonthYr";
            sqlcmd.Parameters.Add(MonthYr);


            SqlParameter Email_id = new SqlParameter();
            Email_id.SqlDbType = SqlDbType.VarChar;
            Email_id.Value = dr["Email_id"].ToString();
            Email_id.ParameterName = "@Email_id";
            sqlcmd.Parameters.Add(Email_id);


            sqlcon.Open();
            int RowEffected = 0;

            RowEffected = sqlcmd.ExecuteNonQuery();
            lblMsgXls.Visible = true;
            lblMsgXls.Text = "Data Updated Successfuly !!!!!!!";
            //  clearcontrol();

            sqlcon.Close();



        }
        catch
        {



        }



    }


   
}
