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
using System.Data;
using System.Configuration;
using System.IO;
using System.Data.OleDb;



public partial class HR_HR_HR_attendance_master : System.Web.UI.Page
{

    CHR_Export hrad = new CHR_Export();
    CCommon objconn = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddltime.SelectedItem.Text = "09:30:00";
            ddt_st_out.SelectedItem.Text = "18:30:00";
            ddlDev_in_time1.SelectedItem.Text = "10:00:00";
            dlDev_in_time2.SelectedItem.Text = "10:30:00";
            ddl_Dev_out_time.SelectedItem.Text = "17:30:00";
            ddl_time.SelectedItem.Text = "10";
            ddl_penIN_2.SelectedItem.Text = "25";
            ddl_pen_out.SelectedItem.Text = "25";
            ddl_pen_out_2.SelectedItem.Text = "50";


            
        
        }
    }
   
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        GetEmployee_Details();
    }



    private void GetEmployee_Details()
    {
        try
        {
                DataSet ds = new DataSet();
                clearcontrol();
                ds = hrad.Getemp_details(txtsearch.Text.Trim());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtname.Text = ds.Tables[0].Rows[0]["Fullname"].ToString();
                    txtcode.Text = ds.Tables[0].Rows[0]["emp_code"].ToString();
                    txtcentre.Text = ds.Tables[0].Rows[0]["centre_name"].ToString();
                    txtsubcentre.Text = ds.Tables[0].Rows[0]["subcentrename"].ToString();
                    txtunit.Text = ds.Tables[0].Rows[0]["unit"].ToString();
                    txtdesign.Text = ds.Tables[0].Rows[0]["designation"].ToString();
                    lblmsg.Visible = false;

                }

                ds.Dispose();
            
        }
            
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = "Error while retreiving records" + ex.Message;
        }


    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        save_updated();
    }


    public void save_updated()
    {
        try
        {
                int RowEffected = 0;

                SqlConnection con = new SqlConnection(objconn.AppConnectionString);


                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = con;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = "sp_update_attendance";
                sqlcmd.CommandTimeout = 0;

                    SqlParameter emp_code = new SqlParameter();
                    emp_code.SqlDbType = SqlDbType.VarChar;
                    emp_code.Value = txtsearch.Text;
                    emp_code.ParameterName = "@emp_code";
                    sqlcmd.Parameters.Add(emp_code);
                
                SqlParameter st_time = new SqlParameter();
                st_time.SqlDbType = SqlDbType.VarChar;
                st_time.Value = ddltime.SelectedValue.ToString();
                st_time.ParameterName = "@st_time";
                sqlcmd.Parameters.Add(st_time);

                SqlParameter st_out_time = new SqlParameter();
                st_out_time.SqlDbType = SqlDbType.VarChar;
                st_out_time.Value =ddt_st_out.SelectedValue.ToString();
                st_out_time.ParameterName = "@st_out_time";
                sqlcmd.Parameters.Add(st_out_time);

                SqlParameter exem_time_default = new SqlParameter();
                exem_time_default.SqlDbType = SqlDbType.Int;
                exem_time_default.Value =Convert.ToInt32(exem_time1.Text.Trim());
                exem_time_default.ParameterName = "@exem_time_default";
                sqlcmd.Parameters.Add(exem_time_default);


                SqlParameter exem_time_DHC = new SqlParameter();
                exem_time_DHC.SqlDbType = SqlDbType.Int;
                exem_time_DHC.Value =Convert.ToInt32( exem_time2.Text.Trim());
                exem_time_DHC.ParameterName = "@exem_time_DHC";
                sqlcmd.Parameters.Add(exem_time_DHC);


                SqlParameter exem_out_time = new SqlParameter();
                exem_out_time.SqlDbType = SqlDbType.Int;
                exem_out_time.Value = Convert.ToInt32(exem_time3.Text.Trim());
                exem_out_time.ParameterName = "@exem_out_time";
                sqlcmd.Parameters.Add(exem_out_time);

                SqlParameter devi_INtime1 = new SqlParameter();
                devi_INtime1.SqlDbType = SqlDbType.VarChar;
                devi_INtime1.Value = ddlDev_in_time1.SelectedValue.Trim();
                devi_INtime1.ParameterName = "@devi_INtime1";
                sqlcmd.Parameters.Add(devi_INtime1);


               
              
                SqlParameter devi_INtime2 = new SqlParameter();
                devi_INtime2.SqlDbType = SqlDbType.VarChar;
                devi_INtime2.Value = dlDev_in_time2.SelectedValue.Trim();
                devi_INtime2.ParameterName = "@devi_INtime2";
                sqlcmd.Parameters.Add(devi_INtime2);

                decimal a = Convert.ToDecimal(ddl_time.SelectedValue.Trim()) / 100;

                SqlParameter pen_intime1 = new SqlParameter();
                pen_intime1.SqlDbType = SqlDbType.Decimal;
                pen_intime1.Value = a;
                pen_intime1.ParameterName = "@pen_intime1";
                sqlcmd.Parameters.Add(pen_intime1);

                SqlParameter devi_outtime1 = new SqlParameter();
                devi_outtime1.SqlDbType = SqlDbType.VarChar;
                devi_outtime1.Value = ddl_Dev_out_time.SelectedValue.Trim();
                devi_outtime1.ParameterName = "@devi_outtime1";
                sqlcmd.Parameters.Add(devi_outtime1);

                decimal b = Convert.ToDecimal(ddl_pen_out.SelectedValue.Trim()) / 100;

                SqlParameter pen_outtime1 = new SqlParameter();
                pen_outtime1.SqlDbType = SqlDbType.Decimal;
                pen_outtime1.Value =b;
                pen_outtime1.ParameterName = "@pen_outtime1";
                sqlcmd.Parameters.Add(pen_outtime1);

                decimal c = Convert.ToDecimal(ddl_penIN_2.SelectedValue.Trim()) / 100;
              
                SqlParameter pen_intime2 = new SqlParameter();
                pen_intime2.SqlDbType = SqlDbType.Decimal;
                pen_intime2.Value = c;
                pen_intime2.ParameterName = "@pen_intime2";
                sqlcmd.Parameters.Add(pen_intime2);

                decimal d = Convert.ToDecimal(ddl_pen_out_2.SelectedValue.Trim()) / 100;

                SqlParameter pen_outtime2 = new SqlParameter();
                pen_outtime2.SqlDbType = SqlDbType.Decimal;
                pen_outtime2.Value = d;
                pen_outtime2.ParameterName = "@pen_outtime2";
                sqlcmd.Parameters.Add(pen_outtime2);

                
                con.Open();
               

                RowEffected = sqlcmd.ExecuteNonQuery();
                lblmsg.Visible = true;
                lblmsg.Text = "Data Updated Successfuly !!!!!!!";
                clearcontrol();
                clear_data();

                con.Close();
               

        }


        catch
        {
        }

    }

    public void clearcontrol()
    {
        txtcentre.Text = "";
        txtcode.Text = "";
        txtsubcentre.Text = "";
        txtunit.Text = "";
        txtdesign.Text = "";
        txtname.Text = "";


    }

    public void clear_data()
    {
        ddl_time.ClearSelection();
        ddt_st_out.ClearSelection();
        ddlDev_in_time1.ClearSelection();
        dlDev_in_time2.ClearSelection();
        ddl_Dev_out_time.ClearSelection();        
        exem_time1.Text = "";
        exem_time2.Text = "";
        exem_time3.Text = "";
        ddltime.ClearSelection();
        ddl_pen_out.ClearSelection();
    }

    private void Validation()
    {
        btnsave.Attributes.Add("onclick", "javascript:WidowOpen();");
    }
    protected void btnUpload_Click(object sender, EventArgs e)
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

                            Update_Timemaster(dt.Rows[i]);

                        }
                        lblMsgXls.Visible = true;
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

    protected void Update_Timemaster(DataRow dr)
    {

        try
        {
            SqlConnection sqlCon = new SqlConnection(objconn.AppConnectionString);

            SqlCommand command = new SqlCommand("sp_update_attendance_import", sqlCon);
            command.CommandType = CommandType.StoredProcedure;


            command.Parameters.AddWithValue("@emp_code", dr["Emp Code"].ToString().Trim());
            command.Parameters.AddWithValue("@st_outtime", dr["Standard Outime"].ToString().Trim());
            command.Parameters.AddWithValue("@st_time", dr["Standard Intime"].ToString());

            command.Parameters.AddWithValue("@exem_time_default", dr["Exem Time Default"].ToString().Trim());
            command.Parameters.AddWithValue("@exem_time_DHC", dr["Exem Time DCH"].ToString().Trim());
            command.Parameters.AddWithValue("@exem_out_time", dr["Exem Out Time"].ToString().Trim());

            command.Parameters.AddWithValue("@devi_INtime1",dr["Devi IN Time1"].ToString());

            command.Parameters.AddWithValue("@devi_INtime2",dr["Devi IN Time2"].ToString().Trim());
            command.Parameters.AddWithValue("@pen_intime1",dr["Penalty In Time1"].ToString().Trim());
            command.Parameters.AddWithValue("@pen_intime2",dr["Penalty IN Time2"].ToString());

            command.Parameters.AddWithValue("@devi_outtime1",dr["Devi Out Time1"].ToString().Trim());
            command.Parameters.AddWithValue("@pen_outtime1",dr["Penalty Out Time1"].ToString().Trim());
            command.Parameters.AddWithValue("@pen_outtime2",dr["Penalty Out Time2"].ToString().Trim());

            sqlCon.Open();
            int i = command.ExecuteNonQuery();
            sqlCon.Close();
        }
        catch(Exception ex)
        {
        }
    }
  
}


