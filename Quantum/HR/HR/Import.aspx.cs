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

public partial class HR_HR_Import : System.Web.UI.Page
{
    CCommon ObjComm = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRole = Session["RoleID"].ToString();
        string[] strRole1 = strRole.Split(',');

        if (strRole == "1")
        {
            BtnImport.Enabled = true;
        }
        else
        {
            BtnImport.Enabled = false;
        }
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
                    strPath = Server.MapPath("../../HRImport");

                    //strPath = strPath + strDateTime + FileUpload1.FileName;
                    strPath = strPath + strDateTime + ".xls";
                    FileUpload1.PostedFile.SaveAs(strPath);


                }

                //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strPath + @";Extended Properties=""Excel 8.0;IMEX=1""";

                string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strPath + @";Extended Properties=""Excel 8.0;IMEX=1""";

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
            string[] Name = null;
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Upload_BIS1_new";
            sqlcmd.CommandTimeout = 0;

            SqlParameter Emp_Code = new SqlParameter();
            Emp_Code.SqlDbType = SqlDbType.NVarChar;
            Emp_Code.ParameterName = "@Emp_Code";
            Emp_Code.Value = dr["Employee Code"].ToString();
            sqlcmd.Parameters.Add(Emp_Code);

            SqlParameter EmpFullName = new SqlParameter();
            EmpFullName.SqlDbType = SqlDbType.VarChar;
            EmpFullName.ParameterName = "@FULLNAME";
            EmpFullName.Value = dr["Employee Name"].ToString();
            sqlcmd.Parameters.Add(EmpFullName);

            if (dr["Employee Name"].ToString() != null)
                Name = Convert.ToString(dr["Employee Name"]).Split(' ');
            if (Name.Length > 0)
            {
                if (Name.Length > 0 && Name[0].ToString() != "")
                {
                    SqlParameter FirstName = new SqlParameter();
                    FirstName.SqlDbType = SqlDbType.VarChar;
                    FirstName.ParameterName = "@FIRSTNAME";
                    FirstName.Value = Name[0].ToString();
                    sqlcmd.Parameters.Add(FirstName);
                }
                else
                {
                    SqlParameter FirstName = new SqlParameter();
                    FirstName.SqlDbType = SqlDbType.VarChar;
                    FirstName.ParameterName = "@FIRSTNAME";
                    FirstName.Value = DBNull.Value;
                    sqlcmd.Parameters.Add(FirstName);
                }

                if (Name.Length > 2 && Name[2].ToString() != "")
                {

                    SqlParameter LastName = new SqlParameter();
                    LastName.SqlDbType = SqlDbType.VarChar;
                    LastName.ParameterName = "@LASTNAME";
                    LastName.Value = Name[2].ToString();
                    sqlcmd.Parameters.Add(LastName);
                }
                else if (Name.Length == 2 && Name[1].ToString() != "")
                {
                    SqlParameter LastName = new SqlParameter();
                    LastName.SqlDbType = SqlDbType.VarChar;
                    LastName.ParameterName = "@LASTNAME";
                    LastName.Value = Name[1].ToString();
                    sqlcmd.Parameters.Add(LastName);
                }

                else
                {
                    SqlParameter LastName = new SqlParameter();
                    LastName.SqlDbType = SqlDbType.VarChar;
                    LastName.ParameterName = "@LASTNAME";
                    LastName.Value = "";
                    sqlcmd.Parameters.Add(LastName);
                }
                if ((Name.Length > 2) && Name[1].ToString() != null)
                {

                    SqlParameter MiddleName = new SqlParameter();
                    MiddleName.SqlDbType = SqlDbType.VarChar;
                    MiddleName.ParameterName = "@MIDDLENAME";
                    MiddleName.Value = Name[1].ToString();
                    sqlcmd.Parameters.Add(MiddleName);
                }
                else
                {
                    SqlParameter MiddleName = new SqlParameter();
                    MiddleName.SqlDbType = SqlDbType.VarChar;
                    MiddleName.ParameterName = "@MIDDLENAME";
                    MiddleName.Value = "";
                    sqlcmd.Parameters.Add(MiddleName);
                }

            }

            SqlParameter DOB = new SqlParameter();
            DOB.SqlDbType = SqlDbType.VarChar;
            DOB.ParameterName = "@DOB";
            DOB.Value = dr["Date of Birth"].ToString();
            sqlcmd.Parameters.Add(DOB);

            SqlParameter DOJ = new SqlParameter();
            DOJ.SqlDbType = SqlDbType.VarChar;
            DOJ.ParameterName = "@DOJ";
            DOJ.Value = dr["Date of Joining"].ToString();
            sqlcmd.Parameters.Add(DOJ);

            SqlParameter Add1 = new SqlParameter();
            Add1.SqlDbType = SqlDbType.VarChar;
            Add1.ParameterName = "@ADD1";
            Add1.Value = dr["Add1"].ToString();
            sqlcmd.Parameters.Add(Add1);

            SqlParameter Add2 = new SqlParameter();
            Add2.SqlDbType = SqlDbType.VarChar;
            Add2.ParameterName = "@ADD2";
            Add2.Value = dr["Add2"].ToString();
            sqlcmd.Parameters.Add(Add2);

            SqlParameter Add3 = new SqlParameter();
            Add3.SqlDbType = SqlDbType.VarChar;
            Add3.ParameterName = "@ADD3";
            Add3.Value = dr["Add3"].ToString();
            sqlcmd.Parameters.Add(Add3);


            SqlParameter city = new SqlParameter();
            city.SqlDbType = SqlDbType.VarChar;
            city.ParameterName = "@CITY";
            city.Value = dr["City"].ToString();
            sqlcmd.Parameters.Add(city);

            SqlParameter Pin = new SqlParameter();
            Pin.SqlDbType = SqlDbType.VarChar;
            Pin.ParameterName = "@PIN";
            Pin.Value = dr["Pin"].ToString();
            sqlcmd.Parameters.Add(Pin);

            SqlParameter Tele = new SqlParameter();
            Tele.SqlDbType = SqlDbType.VarChar;
            Tele.ParameterName = "@PHONE_R";
            Tele.Value = dr["Tele"].ToString();
            sqlcmd.Parameters.Add(Tele);

            SqlParameter Mob = new SqlParameter();
            Mob.SqlDbType = SqlDbType.VarChar;
            Mob.ParameterName = "@MOBILE";
            Mob.Value = dr["Mob"].ToString();
            sqlcmd.Parameters.Add(Mob);

            SqlParameter Mangername = new SqlParameter();
            Mangername.SqlDbType = SqlDbType.VarChar;
            Mangername.ParameterName = "@Manager";
            Mangername.Value = dr["Managers Name"].ToString();
            sqlcmd.Parameters.Add(Mangername);

            SqlParameter Hub = new SqlParameter();
            Hub.SqlDbType = SqlDbType.VarChar;
            Hub.ParameterName = "@Hub";
            Hub.Value = dr["Hub"].ToString();
            sqlcmd.Parameters.Add(Hub);

            SqlParameter Region = new SqlParameter();
            Region.SqlDbType = SqlDbType.VarChar;
            Region.ParameterName = "@Region";
            Region.Value = dr["Region"].ToString();
            sqlcmd.Parameters.Add(Region);

            SqlParameter Designation = new SqlParameter();
            Designation.SqlDbType = SqlDbType.VarChar;
            Designation.ParameterName = "@Designation";
            Designation.Value = dr["Designation"].ToString();
            sqlcmd.Parameters.Add(Designation);


            SqlParameter DDPay = new SqlParameter();
            DDPay.SqlDbType = SqlDbType.VarChar;
            DDPay.ParameterName = "@DDPay";
            DDPay.Value = dr["DDPay"].ToString();
            sqlcmd.Parameters.Add(DDPay);

            SqlParameter ResignDate = new SqlParameter();
            ResignDate.SqlDbType = SqlDbType.VarChar;
            ResignDate.ParameterName = "@ResignDate";
            ResignDate.Value = dr["Resignation Date"].ToString();
            sqlcmd.Parameters.Add(ResignDate);

            SqlParameter PanNo = new SqlParameter();
            PanNo.SqlDbType = SqlDbType.VarChar;
            PanNo.ParameterName = "@PAN#";
            PanNo.Value = dr["Pan No"].ToString();
            sqlcmd.Parameters.Add(PanNo);

            SqlParameter PanAck = new SqlParameter();
            PanAck.SqlDbType = SqlDbType.VarChar;
            PanAck.ParameterName = "@PanAck";
            PanAck.Value = dr["PanAck"].ToString();
            sqlcmd.Parameters.Add(PanAck);

            SqlParameter AcctNo = new SqlParameter();
            AcctNo.SqlDbType = SqlDbType.VarChar;
            AcctNo.ParameterName = "@SUVIDHA_AC";
            AcctNo.Value = dr["AcctNo"].ToString();
            sqlcmd.Parameters.Add(AcctNo);


            SqlParameter AddDate = new SqlParameter();
            AddDate.SqlDbType = SqlDbType.VarChar;
            AddDate.ParameterName = "@ADD_DATE";
            AddDate.Value = txtdate.Text;
            sqlcmd.Parameters.Add(AddDate);

            SqlParameter RM = new SqlParameter();
            RM.SqlDbType = SqlDbType.VarChar;
            RM.ParameterName = "@RM_empcode";
            RM.Value = dr["RM"].ToString();
            sqlcmd.Parameters.Add(RM);

            SqlParameter RSM = new SqlParameter();
            RSM.SqlDbType = SqlDbType.VarChar;
            RSM.ParameterName = "@RSM_empcode";
            RSM.Value = dr["RSM"].ToString();
            sqlcmd.Parameters.Add(RSM);

            int i = sqlcmd.ExecuteNonQuery();
            sqlcon.Close();

            if (i > 0)
            {
                lblMsgXls.Visible = true;
                lblMsgXls.Text = "Data Imported Successfully!!";
                lblMsgXls.CssClass = "UpdateMessage";
            }
            else
            {
                //lblMsgXls.Visible = true;
                //lblMsgXls.Text = "Data Not Imported Successfully!!";
                //lblMsgXls.CssClass = "UpdateMessage";
            }
            
        }

        catch (Exception ex)
        {

        }
    }


}
