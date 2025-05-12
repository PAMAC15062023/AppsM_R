using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data.OleDb;

public partial class HR_HR_HRImport : System.Web.UI.Page
{
    CCommon objConn = new CCommon();

    SqlConnection sqlcon;


    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);
        if (!IsPostBack)
        {

            validate();
        }
    }

    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);

        string strMM = strInDate.Substring(3, 2);

        string strYYYY = strInDate.Substring(6, 4);

        string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;

        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);

        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy");

        return strOutDate;
    }

    protected void validate()
    {
        btnUplaod.Attributes.Add("onclick", "javascript:return validate();");
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        {
            try
            {
                if (xslFileUpload.HasFile)
                {
                    String strPath = "";
                    String MyFile = "";
                    string strDateTime = DateTime.Now.ToString("ddMMyyyyhhmmss");

                    strPath = Server.MapPath("../../ImportFiles/");
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



                                Insert_Into_MainCaseDetails(dt.Rows[i]);


                            }
                            lblMsgXls.Text = "Record Save Successfully...!!! Total Count: " + dt.Rows.Count;
                        }

                        string strFile = Server.MapPath("../../ImportFiles/") + MyFile;
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
    }

    protected void Insert_Into_MainCaseDetails(DataRow dr)
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        Object SaveUSERInfo = (Object)Session["UserInfo"];
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "ojt_import_data";
        sqlcmd.CommandTimeout = 0;





        SqlParameter clusterid = new SqlParameter();
        clusterid.SqlDbType = SqlDbType.VarChar;
        clusterid.Value = Session["CLUSTERID"].ToString();
        clusterid.ParameterName = "@Cluster_id";
        sqlcmd.Parameters.Add(clusterid);

        SqlParameter centreid = new SqlParameter();
        centreid.SqlDbType = SqlDbType.VarChar;
        centreid.Value = Session["CENTREID"].ToString();
        centreid.ParameterName = "@Centre_id";
        sqlcmd.Parameters.Add(centreid);

        SqlParameter subcentre_id = new SqlParameter();
        subcentre_id.SqlDbType = SqlDbType.VarChar;
        subcentre_id.Value = Session["SubCentreid"].ToString();
        subcentre_id.ParameterName = "@subcentre_id";
        sqlcmd.Parameters.Add(subcentre_id);





        SqlParameter empid = new SqlParameter();
        empid.SqlDbType = SqlDbType.VarChar;
        empid.Value = dr["EMP code"].ToString().Trim();
        empid.ParameterName = "@Emp_code";
        sqlcmd.Parameters.Add(empid);

        SqlParameter intime = new SqlParameter();
        intime.SqlDbType = SqlDbType.VarChar;
        intime.Value = dr["InTime"].ToString().Trim();
        intime.ParameterName = "@In_Time";
        sqlcmd.Parameters.Add(intime);


        SqlParameter outtime = new SqlParameter();
        outtime.SqlDbType = SqlDbType.VarChar;
        outtime.Value = dr["OutTime"].ToString().Trim();
        outtime.ParameterName = "@@Out_Time";
        sqlcmd.Parameters.Add(outtime);


        SqlParameter min_prod = new SqlParameter();
        min_prod.SqlDbType = SqlDbType.VarChar;
        min_prod.Value = dr["Minimum Productivity"].ToString().Trim();
        min_prod.ParameterName = "@Min_Product";
        sqlcmd.Parameters.Add(min_prod);

        SqlParameter emp_behv = new SqlParameter();
        emp_behv.SqlDbType = SqlDbType.VarChar;
        emp_behv.Value = dr["Behaviour For Day"].ToString().Trim();
        emp_behv.ParameterName = "@Emp_Behaviour";
        sqlcmd.Parameters.Add(emp_behv);

        SqlParameter Caseassign = new SqlParameter();
        Caseassign.SqlDbType = SqlDbType.VarChar;
        Caseassign.Value = dr["Cases Assigned"].ToString().Trim();
        Caseassign.ParameterName = "@Case_Assign";
        sqlcmd.Parameters.Add(Caseassign);

        SqlParameter casecompleted = new SqlParameter();
        casecompleted.SqlDbType = SqlDbType.Decimal;
        casecompleted.Value = dr["Cases Completed"].ToString().Trim();
        casecompleted.ParameterName = "@Case_Complete";
        sqlcmd.Parameters.Add(casecompleted);

        SqlParameter errorcount = new SqlParameter();
        errorcount.SqlDbType = SqlDbType.VarChar;
        errorcount.Value = dr["Error Count"].ToString().Trim();
        errorcount.ParameterName = "@Error_Count";
        sqlcmd.Parameters.Add(errorcount);

        SqlParameter training = new SqlParameter();
        training.SqlDbType = SqlDbType.VarChar;
        training.Value = dr["Training"].ToString().Trim();
        training.ParameterName = "@Training";
        sqlcmd.Parameters.Add(training);

        SqlParameter reasonminpro = new SqlParameter();
        reasonminpro.SqlDbType = SqlDbType.VarChar;
        reasonminpro.Value = dr["Reason For Minimum Productivity"].ToString().Trim();
        reasonminpro.ParameterName = "@Reason";
        sqlcmd.Parameters.Add(reasonminpro);

        SqlParameter ADD_BY = new SqlParameter();
        ADD_BY.SqlDbType = SqlDbType.VarChar;
        ADD_BY.Value = Session["UserID"].ToString();
        ADD_BY.ParameterName = "@createby";
        sqlcmd.Parameters.Add(ADD_BY);

        SqlParameter Createdate = new SqlParameter();
        Createdate.SqlDbType = SqlDbType.DateTime;
        Createdate.Value = txtuploaddate.Text.Trim();        //////  Previous day date
        Createdate.ParameterName = "@CreateDate";
        sqlcmd.Parameters.Add(Createdate);

        int RowEffected = 0;
        RowEffected = sqlcmd.ExecuteNonQuery();
        sqlcon.Close();

        if (RowEffected > 0)
        {
            lblMsgXls.Visible = true;
        }
    }
}
