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


public partial class HR_HR_HR_DOLupdate : System.Web.UI.Page
{
    CHR_Export hrad = new CHR_Export();
    CCommon objconn = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox1.Text = System.DateTime.Now.AddDays(-4).ToString("dd/MM/yyyy");
        lblMessage.Visible = false;

    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        GetEmployee_Details_dol();
    }


    private void GetEmployee_Details_dol()
    {
        try
        {
            DataSet ds = new DataSet();
            //clearcontrol();
            ds = hrad.Getemp_details(txtsearch.Text.Trim());
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtname.Text = ds.Tables[0].Rows[0]["Fullname"].ToString();
                txtcode.Text = ds.Tables[0].Rows[0]["emp_code"].ToString();
                txtcentre.Text = ds.Tables[0].Rows[0]["centre_name"].ToString();
                txtsubcentre.Text = ds.Tables[0].Rows[0]["subcentrename"].ToString();
                txtunit.Text = ds.Tables[0].Rows[0]["unit"].ToString();
                txtdesign.Text = ds.Tables[0].Rows[0]["designation"].ToString();
                HiddenField1.Value = ds.Tables[0].Rows[0]["doj"].ToString();
                lblmsg.Visible = false;
            }
            else
            {
                lblmsg.Visible = true;
                lblmsg.Text = "Record Not Found!!";
            }

            ds.Dispose();

        }

        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error while retreiving records" + ex.Message;
        }


    }


    public void clearcontrol()
    {
        txtsearch.Text = "";
        txtcentre.Text = "";
        txtcode.Text = "";
        txtsubcentre.Text = "";
        txtunit.Text = "";
        txtdesign.Text = "";
        txtname.Text = "";
        txtdate.Text = "";
        ddldolreason.ClearSelection();
        ddlNoticeServed.ClearSelection();
        txtresgndate.Text = "";

    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        save_updated_DOL();
    }

    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);

        string strMM = strInDate.Substring(3, 2);

        string strYYYY = strInDate.Substring(6, 4);

        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY;  //on Server 

        //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;   //On local machine

        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);

        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy");

        return strOutDate;
    }


    //public void save_updated_DOL()
    //{
    //    try
    //    {
    //        if (txtsearch.Text != "")
    //        {
    //            SqlConnection con = new SqlConnection(objconn.AppConnectionString);
    //            SqlCommand sqlcmd = new SqlCommand();
    //            sqlcmd.Connection = con;
    //            sqlcmd.CommandType = CommandType.StoredProcedure;
    //            sqlcmd.CommandText = "sp_updateDOL_HR";
    //            sqlcmd.CommandTimeout = 0;

    //            SqlParameter emp_code = new SqlParameter();
    //            emp_code.SqlDbType = SqlDbType.VarChar;
    //            emp_code.Value = txtsearch.Text.ToString();
    //            emp_code.ParameterName = "@emp_code";
    //            sqlcmd.Parameters.Add(emp_code);

    //            SqlParameter hr_dol = new SqlParameter();
    //            hr_dol.SqlDbType = SqlDbType.VarChar;
    //            hr_dol.Value =strDate(txtdate.Text.ToString()); 
    //            hr_dol.ParameterName = "@dol";
    //            sqlcmd.Parameters.Add(hr_dol);

    //            SqlParameter resgndate = new SqlParameter();
    //            resgndate.SqlDbType = SqlDbType.VarChar;
    //            resgndate.Value = strDate(txtresgndate.Text.ToString());
    //            resgndate.ParameterName = "@resgndate";
    //            sqlcmd.Parameters.Add(resgndate);

    //            SqlParameter dol_update_by = new SqlParameter();
    //            dol_update_by.SqlDbType = SqlDbType.VarChar;
    //            dol_update_by.Value = Session["UserId"].ToString();
    //            dol_update_by.ParameterName = "@dol_updated_by";
    //            sqlcmd.Parameters.Add(dol_update_by);

    //            SqlParameter dol_reason = new SqlParameter();
    //            dol_reason.SqlDbType = SqlDbType.VarChar;
    //            dol_reason.Value = ddldolreason.SelectedValue.ToString();
    //            dol_reason.ParameterName = "@dol_reason";
    //            sqlcmd.Parameters.Add(dol_reason);

    //            SqlParameter NoticeServed = new SqlParameter();
    //            NoticeServed.SqlDbType = SqlDbType.VarChar;
    //            NoticeServed.Value = ddlNoticeServed.SelectedValue.ToString();
    //            NoticeServed.ParameterName = "@Notice_Served";
    //            sqlcmd.Parameters.Add(NoticeServed);

    //            con.Open();
    //            int RowEffected = 0;

    //            RowEffected = sqlcmd.ExecuteNonQuery();
    //            lblmsg.Visible = true;
    //            lblmsg.Text = "Data Updated Successfuly !!!!!!!";
    //            clearcontrol(); 

    //            con.Close();
    //        }
    //        else
    //        {
    //            lblmsg.Visible = true;
    //            lblmsg.Text = "Please Enter the Employee Code started from P- ";
    //        }

    //    }
    //    catch
    //    {
    //    }

    //}


    public void save_updated_DOL()
    {
        try
        {
            if (txtsearch.Text != "")
            {
                //DateTime dol = DateTime.ParseExact(txtdate.Text, "dd/MM/yyyy", null); 
                //DateTime doj = Convert.ToDateTime(HiddenField1.Value); 

                //string abc = strDate(txtdate.Text.ToString());
                //string xyz = HiddenField1.Value;

                //DateTime dol = Convert.ToDateTime(abc);
                //DateTime doj = Convert.ToDateTime(xyz);



                //if (doj < dol)
                //{
                    String str1 = strDate(System.DateTime.Now.ToString("dd/MM/yyyy"));
                    String str2 = strDate(txtdate.Text.ToString());
                    DateTime aa = Convert.ToDateTime(str1);

                    DateTime bb = Convert.ToDateTime(str2);

                    TimeSpan diff = aa.Subtract(bb);
                    string u1 = Session["Userid"].ToString();
                    if (ddldolreason.SelectedValue.ToString() == "Absconding")
                    {

                        if (diff.Days <= 10)
                        {

                            SqlConnection con = new SqlConnection(objconn.AppConnectionString);
                            SqlCommand sqlcmd = new SqlCommand();
                            sqlcmd.Connection = con;
                            sqlcmd.CommandType = CommandType.StoredProcedure;
                            sqlcmd.CommandText = "sp_updateDOL_HR";
                            sqlcmd.CommandTimeout = 0;

                            SqlParameter emp_code = new SqlParameter();
                            emp_code.SqlDbType = SqlDbType.VarChar;
                            emp_code.Value = txtsearch.Text.ToString();
                            emp_code.ParameterName = "@emp_code";
                            sqlcmd.Parameters.Add(emp_code);

                            SqlParameter hr_dol = new SqlParameter();
                            hr_dol.SqlDbType = SqlDbType.VarChar;
                            hr_dol.Value = strDate(txtdate.Text.ToString());
                            hr_dol.ParameterName = "@dol";
                            sqlcmd.Parameters.Add(hr_dol);

                            SqlParameter resgndate = new SqlParameter();
                            resgndate.SqlDbType = SqlDbType.VarChar;
                            resgndate.Value = strDate(txtresgndate.Text.ToString());
                            resgndate.ParameterName = "@resgndate";
                            sqlcmd.Parameters.Add(resgndate);

                            SqlParameter dol_update_by = new SqlParameter();
                            dol_update_by.SqlDbType = SqlDbType.VarChar;
                            dol_update_by.Value = Session["UserId"].ToString();
                            dol_update_by.ParameterName = "@dol_updated_by";
                            sqlcmd.Parameters.Add(dol_update_by);

                            SqlParameter dol_reason = new SqlParameter();
                            dol_reason.SqlDbType = SqlDbType.VarChar;
                            dol_reason.Value = ddldolreason.SelectedValue.ToString();
                            dol_reason.ParameterName = "@dol_reason";
                            sqlcmd.Parameters.Add(dol_reason);

                            SqlParameter NoticeServed = new SqlParameter();
                            NoticeServed.SqlDbType = SqlDbType.VarChar;
                            NoticeServed.Value = ddlNoticeServed.SelectedValue.ToString();
                            NoticeServed.ParameterName = "@Notice_Served";
                            sqlcmd.Parameters.Add(NoticeServed);

                            con.Open();
                            int RowEffected = 0;

                            RowEffected = sqlcmd.ExecuteNonQuery();
                            lblmsg.Visible = true;
                            lblmsg.Text = "Data Updated Successfuly !!!!!!!";
                            clearcontrol();

                            con.Close();
                        }
                        else
                        {


                            lblmsg.Visible = true;
                            lblmsg.Text = "for absconding cases DOL shopuld not less than 12 days";


                        }


                    }
                    else
                    {

                        if (diff.Days <= 3)
                        {

                            SqlConnection con = new SqlConnection(objconn.AppConnectionString);
                            SqlCommand sqlcmd = new SqlCommand();
                            sqlcmd.Connection = con;
                            sqlcmd.CommandType = CommandType.StoredProcedure;
                            sqlcmd.CommandText = "sp_updateDOL_HR";
                            sqlcmd.CommandTimeout = 0;

                            SqlParameter emp_code = new SqlParameter();
                            emp_code.SqlDbType = SqlDbType.VarChar;
                            emp_code.Value = txtsearch.Text.ToString();
                            emp_code.ParameterName = "@emp_code";
                            sqlcmd.Parameters.Add(emp_code);

                            SqlParameter hr_dol = new SqlParameter();
                            hr_dol.SqlDbType = SqlDbType.VarChar;
                            hr_dol.Value = strDate(txtdate.Text.ToString());
                            hr_dol.ParameterName = "@dol";
                            sqlcmd.Parameters.Add(hr_dol);

                            SqlParameter resgndate = new SqlParameter();
                            resgndate.SqlDbType = SqlDbType.VarChar;
                            resgndate.Value = strDate(txtresgndate.Text.ToString());
                            resgndate.ParameterName = "@resgndate";
                            sqlcmd.Parameters.Add(resgndate);

                            SqlParameter dol_update_by = new SqlParameter();
                            dol_update_by.SqlDbType = SqlDbType.VarChar;
                            dol_update_by.Value = Session["UserId"].ToString();
                            dol_update_by.ParameterName = "@dol_updated_by";
                            sqlcmd.Parameters.Add(dol_update_by);

                            SqlParameter dol_reason = new SqlParameter();
                            dol_reason.SqlDbType = SqlDbType.VarChar;
                            dol_reason.Value = ddldolreason.SelectedValue.ToString();
                            dol_reason.ParameterName = "@dol_reason";
                            sqlcmd.Parameters.Add(dol_reason);

                            SqlParameter NoticeServed = new SqlParameter();
                            NoticeServed.SqlDbType = SqlDbType.VarChar;
                            NoticeServed.Value = ddlNoticeServed.SelectedValue.ToString();
                            NoticeServed.ParameterName = "@Notice_Served";
                            sqlcmd.Parameters.Add(NoticeServed);

                            con.Open();
                            int RowEffected = 0;

                            RowEffected = sqlcmd.ExecuteNonQuery();
                            lblmsg.Visible = true;
                            lblmsg.Text = "Data Updated Successfuly !!!!!!!";
                            clearcontrol();

                            con.Close();
                        }
                        else
                        {
                            lblmsg.Visible = true;
                            lblmsg.Text = "DOL shopuld not less than 3 days";
                        }
                    }
                //}
                //else
                //{
                //    lblmsg.Visible = true;
                //    lblmsg.Text = "Invalid Date";
                //}

            }
            else
            {
                lblmsg.Visible = true;
                lblmsg.Text = "Please Enter the Employee Code";
            }


        }
        catch
        {
        }
    }
    protected void btnupload_Click(object sender, EventArgs e)
    {
        try
        {
            if (xslFileUpload.HasFile)
            {
                String strPath = "";
                String MyFile = "";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                strPath = Server.MapPath("~/HR/ImportFiles/");
                MyFile = strDateTime + ".xls";
                strPath = (strPath + MyFile);
                xslFileUpload.PostedFile.SaveAs(strPath);

                string strFileName = xslFileUpload.FileName.ToString();

                FileInfo fi = new FileInfo(strFileName);
                string strExt = fi.Extension;

                if (strExt.ToLower() == ".xls")
                {
                    string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strPath + @";Extended Properties=""Excel 8.0;IMEX=1""";

                    OleDbConnection oleCon = new OleDbConnection(strConn);
                    oleCon.Open();

                    OleDbCommand oleCom = new OleDbCommand("SELECT * FROM [sheet1$]");
                    oleCom.Connection = oleCon;

                    OleDbDataAdapter oleDA = new OleDbDataAdapter();
                    oleDA.SelectCommand = oleCom;

                    DataTable dt = new DataTable();
                    oleDA.Fill(dt);
                    oleCon.Close();

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            Update_DOL(dt.Rows[i]);

                        }
                        lblMsgXls.Text = "Data Import Successfully!!";

                    }


                    string strFile = Server.MapPath("~/HR/ImportFiles/") + MyFile;
                    if (File.Exists(strFile))
                    {
                        File.Delete(strFile);
                    }
                }
                else
                {
                    lblMsgXls.Visible = true;
                    lblMsgXls.Text = "It's Not An Excel File...!!!";
                }
            }
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



    protected void Update_DOL(DataRow dr)
    {



        //SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        SqlConnection sqlCon = new SqlConnection(objconn.AppConnectionString);

        SqlCommand command = new SqlCommand("sp_UploadProcDOL", sqlCon);
        command.CommandType = CommandType.StoredProcedure;


        command.Parameters.AddWithValue("@emp_code", dr["Emp_code"].ToString().Trim());
        command.Parameters.AddWithValue("@Resigndate", dr["Date Of Resignation"].ToString().Trim());
        command.Parameters.AddWithValue("@DOL", dr["Date Of Leaving"].ToString());

        command.Parameters.AddWithValue("@dol_reason", dr["DOL Reason"].ToString().Trim());
        command.Parameters.AddWithValue("@Notice_Served", dr["Notice Served"].ToString().Trim());
        command.Parameters.AddWithValue("@Zone", ddlZone.SelectedValue.ToString().Trim());
        command.Parameters.AddWithValue("@modify_user_id", Session["UserId"].ToString());


        sqlCon.Open();
        int i = command.ExecuteNonQuery();
        sqlCon.Close();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUpload1.HasFile)
            {
                String strPath = "";
                String MyFile = "";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                strPath = Server.MapPath("~/HR/ImportFiles/");
                MyFile = strDateTime + ".xls";
                strPath = (strPath + MyFile);
                FileUpload1.PostedFile.SaveAs(strPath);

                string strFileName = FileUpload1.FileName.ToString();

                FileInfo fi = new FileInfo(strFileName);
                string strExt = fi.Extension;

                if (strExt.ToLower() == ".xls")
                {
                    string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strPath + @";Extended Properties=""Excel 8.0;IMEX=1""";

                    OleDbConnection oleCon = new OleDbConnection(strConn);
                    oleCon.Open();

                    OleDbCommand oleCom = new OleDbCommand("SELECT * FROM [sheet1$]");
                    oleCom.Connection = oleCon;

                    OleDbDataAdapter oleDA = new OleDbDataAdapter();
                    oleDA.SelectCommand = oleCom;

                    DataTable dt = new DataTable();
                    oleDA.Fill(dt);
                    oleCon.Close();

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            Upload_OD(dt.Rows[i]);

                        }
                        lblMsgXls.Text = "Data Imported Successfully!!";

                    }


                    string strFile = Server.MapPath("~/HR/ImportFiles/") + MyFile;
                    if (File.Exists(strFile))
                    {
                        File.Delete(strFile);
                    }
                }
                else
                {
                    lblMsgXls.Visible = true;
                    lblMsgXls.Text = "It's Not An Excel File...!!!";
                }
            }
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




    protected void BtnSal_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUpload2.HasFile)
            {
                String strPath = "";
                String MyFile = "";
                string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                strPath = Server.MapPath("~/HR/ImportFiles/");
                MyFile = strDateTime + ".xls";
                strPath = (strPath + MyFile);
                FileUpload2.PostedFile.SaveAs(strPath);

                string strFileName = FileUpload2.FileName.ToString();

                FileInfo fi = new FileInfo(strFileName);
                string strExt = fi.Extension;

                if (strExt.ToLower() == ".xls")
                {
                    string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strPath + @";Extended Properties=""Excel 8.0;IMEX=1""";

                    OleDbConnection oleCon = new OleDbConnection(strConn);
                    oleCon.Open();

                    OleDbCommand oleCom = new OleDbCommand("SELECT * FROM [sheet1$]");
                    oleCom.Connection = oleCon;

                    OleDbDataAdapter oleDA = new OleDbDataAdapter();
                    oleDA.SelectCommand = oleCom;

                    DataTable dt = new DataTable();
                    oleDA.Fill(dt);
                    oleCon.Close();

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            Upload_sal(dt.Rows[i]);

                        }
                        lblMsgXls.Text = "Data Imported Successfully!!";

                    }


                    string strFile = Server.MapPath("~/HR/ImportFiles/") + MyFile;
                    if (File.Exists(strFile))
                    {
                        File.Delete(strFile);
                    }
                }
                else
                {
                    lblMsgXls.Visible = true;
                    lblMsgXls.Text = "It's Not An Excel File...!!!";
                }
            }
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

    protected void Upload_OD(DataRow dr)
    {
        //SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        SqlConnection sqlCon = new SqlConnection(objconn.AppConnectionString);

        SqlCommand command = new SqlCommand("sp_UploadProcOD", sqlCon);
        command.CommandType = CommandType.StoredProcedure;


        command.Parameters.AddWithValue("@emp_code", dr["Emp_code"].ToString().Trim());
        command.Parameters.AddWithValue("@DATE", Convert.ToDateTime(dr["Date"].ToString().Trim()));
        command.Parameters.AddWithValue("@Outdoor_Remark", dr["Outdoor_Remark"].ToString().Trim());
        command.Parameters.AddWithValue("@CreateBy", Session["UserId"].ToString());
        command.Parameters.AddWithValue("@Zone", dr["Zone"].ToString().Trim());


        sqlCon.Open();
        int i = command.ExecuteNonQuery();
        sqlCon.Close();


    }



    protected void Upload_sal(DataRow dr)
    {
        //SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        SqlConnection sqlCon = new SqlConnection(objconn.AppConnectionString);

        SqlCommand command = new SqlCommand("sp_UploadProcSAL", sqlCon);
        command.CommandType = CommandType.StoredProcedure;


        command.Parameters.AddWithValue("@emp_code", dr["emp_code"].ToString().Trim());
        command.Parameters.AddWithValue("@Basic", dr["Basic"].ToString().Trim());
        command.Parameters.AddWithValue("@HRA", dr["HRA"].ToString().Trim());
        command.Parameters.AddWithValue("@DERIVED_INC", dr["DERIVED INCENTIVES"].ToString().Trim());
        command.Parameters.AddWithValue("@conveyance", dr["conveyance"].ToString().Trim());
        command.Parameters.AddWithValue("@Washing_Allow", dr["WASHNG ALL"].ToString().Trim());
        command.Parameters.AddWithValue("@MEDICAL_ALL", dr["MEDICAL ALL"].ToString().Trim());
        command.Parameters.AddWithValue("@LTA", dr["LTA"].ToString().Trim());
        command.Parameters.AddWithValue("@Gross_Amt", dr["Gross"].ToString().Trim());
       // command.Parameters.AddWithValue("@emp_id", Session["UserId"].ToString());

        sqlCon.Open();
        int i = command.ExecuteNonQuery();
        sqlCon.Close();


    }



}
