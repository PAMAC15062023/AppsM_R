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

public partial class CPA_PD_CaseImport : System.Web.UI.Page
{
       CCommon objConn = new CCommon();
    SqlConnection sqlcon;

    string strproc;
    string StrCase_id;
    string case_ID;

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

        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY;

        //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;

        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);

        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy");

        return strOutDate;
    }

    protected void validate()
    {
        btnUpload.Attributes.Add("onclick", "javascript:return validate();");
    }

    protected void ClearControl()
    {
        ddlCaseType.SelectedIndex = 0;
        xslFileUpload.Controls.Clear();
        txtCaseReceivedDate.Text = "";
        txtCaseReceivedTime.Text = "";
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
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
                            sqlcon.Open();
                            string cluster =Session["ClusterId"].ToString();
                            string centre = Session["CentreId"].ToString();

                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = sqlcon;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "PD_cluster";
                            cmd.CommandTimeout = 0;

                            SqlParameter centre_name = new SqlParameter();
                            centre_name.SqlDbType = SqlDbType.VarChar;
                            centre_name.Value = centre;
                            centre_name.ParameterName = "@centre_id";
                            cmd.Parameters.Add(@centre_name);


                            SqlParameter cluster_id = new SqlParameter();
                            cluster_id.SqlDbType = SqlDbType.VarChar;
                            cluster_id.Value = cluster;
                            cluster_id.ParameterName = "@cluster_id";
                            cmd.Parameters.Add(cluster_id);


                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = cmd;

                            DataTable sqlDT = new DataTable();
                            da.Fill(sqlDT);

                            sqlcon.Close();

                            string clusterID = sqlDT.Rows[0]["cluster_id"].ToString();
                            string Centreid = sqlDT.Rows[0]["Centre_id"].ToString();

                            if (ddlCaseType.SelectedValue == "1")
                            {
                                Insert_Into_MainCaseDetails(dt.Rows[i], clusterID, Centreid);
                            }
                            //else
                            //{
                            //    Insert_Into_MainCaseDetails(dt.Rows[i], clusterID, Centreid);
                            //}
                        }

                        ClearControl();
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

    protected void Insert_Into_MainCaseDetails(DataRow dr, string clusterID, string Centreid)
    {
        Object SaveUSERInfo = (Object)Session["UserInfo"];

        sqlcon.Open();

        SqlCommand sqlcmd1 = new SqlCommand();
        sqlcmd1.Connection = sqlcon;
        sqlcmd1.CommandType = CommandType.StoredProcedure;
        //sqlcmd1.CommandText = "SP_getTopID";
        sqlcmd1.CommandText = "SP_getTopID_NEwPD";
        sqlcmd1.CommandTimeout = 0;

        SqlParameter Cluster = new SqlParameter();
        Cluster.SqlDbType = SqlDbType.VarChar;
        Cluster.Value = clusterID;
        Cluster.ParameterName = "@Cluster_id";
        sqlcmd1.Parameters.Add(Cluster);

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = sqlcmd1;

        DataTable dt = new DataTable();
        da.Fill(dt);

        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ID = dt.Rows[0]["ID"].ToString();
        }

        if (clusterID == "1012")
        {
            strproc = "PD_Insert_Import_Details_west12";
            StrCase_id = "W" + ID;
        }
        
        else if (clusterID == "1014")
        {
            strproc = "PD_Insert_Import_Details_east12";
            StrCase_id = "E" + ID;
        }
        else if (clusterID == "1013")
        {
            strproc = "PD_Insert_Import_Details_South12";
            StrCase_id = "S" + ID;
        }
        else if (clusterID == "1015")
        {
            strproc = "PD_Insert_Import_Details_North12";
            StrCase_id = "N" + ID;
        }
        else if (clusterID == "1018")
        {
            strproc = "PD_Insert_Import_Details_west12";
            StrCase_id = "W" + ID;
        }

        else if (clusterID == "1011")
        {
            strproc = "PD_Insert_Import_Details_BVU";
            StrCase_id = "W" + ID;
        }
        else
        {
            strproc = "PD_Insert_Import_Details_west12";
            StrCase_id = "W" + ID;
        }

        sqlcon.Open();
        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = strproc;
        sqlcmd.CommandTimeout = 0;

        SqlParameter Client_ID = new SqlParameter();
        Client_ID.SqlDbType = SqlDbType.VarChar;
        Client_ID.Value = Session["ClientID"].ToString();
        Client_ID.ParameterName = "@CLIENT_ID";
        sqlcmd.Parameters.Add(Client_ID);

        SqlParameter ADD_BY = new SqlParameter();
        ADD_BY.SqlDbType = SqlDbType.VarChar;
        ADD_BY.Value = Session["UserID"].ToString();
        ADD_BY.ParameterName = "@ADD_BY";
        sqlcmd.Parameters.Add(ADD_BY);


        SqlParameter cluster_id = new SqlParameter();
        cluster_id.SqlDbType = SqlDbType.VarChar;
        cluster_id.Value = Session["ClusterId"].ToString();
        cluster_id.ParameterName = "@Cluster_id";
        sqlcmd.Parameters.Add(cluster_id);

        SqlParameter centre_id = new SqlParameter();
        centre_id.SqlDbType = SqlDbType.VarChar;
        centre_id.Value = Session["CentreId"].ToString();
        centre_id.ParameterName = "@centre_id";
        sqlcmd.Parameters.Add(centre_id);


        SqlParameter File_ref_No = new SqlParameter();
        File_ref_No.SqlDbType = SqlDbType.NVarChar;
        File_ref_No.Value = dr["File_Ref_No"].ToString().Trim();
        File_ref_No.ParameterName = "@File_Ref_No";
        sqlcmd.Parameters.Add(File_ref_No);



        SqlParameter Customer_Name = new SqlParameter();
        Customer_Name.SqlDbType = SqlDbType.NVarChar;
        Customer_Name.Value = dr["Customer_Name"].ToString().Trim();
        Customer_Name.ParameterName = "@Customer_Name";
        sqlcmd.Parameters.Add(Customer_Name);


        SqlParameter Company_Name = new SqlParameter();
        Company_Name.SqlDbType = SqlDbType.NVarChar;
        Company_Name.Value = dr["Company_Name"].ToString().Trim();
        Company_Name.ParameterName = "@Company_Name";
        sqlcmd.Parameters.Add(Company_Name);


        SqlParameter Contact_Person_Name = new SqlParameter();
        Contact_Person_Name.SqlDbType = SqlDbType.NVarChar;
        Contact_Person_Name.Value = dr["Contact_Person_Name"].ToString().Trim();
        Contact_Person_Name.ParameterName = "@Contact_Person_Name";
        sqlcmd.Parameters.Add(Contact_Person_Name);


        SqlParameter Contact_Number = new SqlParameter();
        Contact_Number.SqlDbType = SqlDbType.NVarChar;
        Contact_Number.Value = dr["Contact_Number"].ToString().Trim();
        Contact_Number.ParameterName = "@Contact_Number";
        sqlcmd.Parameters.Add(Contact_Number);


        SqlParameter PAMAC_Location = new SqlParameter();
        PAMAC_Location.SqlDbType = SqlDbType.NVarChar;
        PAMAC_Location.Value = dr["PAMAC_Location"].ToString().Trim();
        PAMAC_Location.ParameterName = "@pamac_location";
        sqlcmd.Parameters.Add(PAMAC_Location);


        SqlParameter Address = new SqlParameter();
        Address.SqlDbType = SqlDbType.NVarChar;
        Address.Value = dr["Address"].ToString().Trim();
        Address.ParameterName = "@Address";
        sqlcmd.Parameters.Add(Address);


        //DateTime a = Convert.ToDateTime(dr["Allocation Date"].ToString().Trim());

        //SqlParameter Allocation_Date = new SqlParameter();
        //Allocation_Date.SqlDbType = SqlDbType.DateTime;
        //Allocation_Date.Value = a;
        //Allocation_Date.ParameterName = "@Allocation_Date";
        //sqlcmd.Parameters.Add(Allocation_Date);



        SqlParameter Case_id = new SqlParameter();
        Case_id.SqlDbType = SqlDbType.VarChar;
        Case_id.Value = StrCase_id;
        Case_id.ParameterName = "@Case_id";
        sqlcmd.Parameters.Add(Case_id);





        int RowEffected = 0;
        RowEffected = sqlcmd.ExecuteNonQuery();
        sqlcon.Close();

        if (RowEffected > 0)
        {
            lblMsgXls.Visible = true;
        }
    }
}
