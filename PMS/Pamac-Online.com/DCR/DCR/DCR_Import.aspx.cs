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

public partial class DCR_DCR_DCR_Import : System.Web.UI.Page
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;

    string strproc;
    string StrCase_id;
    string ID;

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
                            string centre = dt.Rows[i]["Location"].ToString();

                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = sqlcon;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "DCR_cluster";
                            cmd.CommandTimeout = 0;

                            SqlParameter centre_name = new SqlParameter();
                            centre_name.SqlDbType = SqlDbType.VarChar;
                            centre_name.Value = centre;
                            centre_name.ParameterName = "@centre_name";
                            cmd.Parameters.Add(@centre_name);

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
                            else
                            {
                                Insert_Into_MainCaseDetails(dt.Rows[i], clusterID, Centreid);
                            }
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
        sqlcmd1.CommandText = "SP_getTopID_new";
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

        if (clusterID == "1011")
        {
            strproc = "DCR_Insert_Import_Details";
            StrCase_id = "B" + ID;
        }
        else if (clusterID == "1014")
        {
            strproc = "DCR_Insert_Import_Details_East";
            StrCase_id = "E" + ID;
        }
        else if (clusterID == "1013")
        {
            strproc = "DCR_Insert_Import_Details_South";
            StrCase_id = "S" + ID;
        }
        else if (clusterID == "1015")
        {
            strproc = "DCR_Insert_Import_Details_North";
            StrCase_id = "N" + ID;
        }
        else if (clusterID == "1018")
        {
            strproc = "DCR_Insert_Import_Details";
            StrCase_id = "B" + ID;
        }
        else
        {
            strproc = "DCR_Insert_Import_Details_west";
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

        SqlParameter Lead_id = new SqlParameter();
        Lead_id.SqlDbType = SqlDbType.NVarChar;
        Lead_id.Value = dr["Lead id"].ToString().Trim();
        Lead_id.ParameterName = "@LEAD_ID";
        sqlcmd.Parameters.Add(Lead_id);

        SqlParameter Call_Center_Group = new SqlParameter();
        Call_Center_Group.SqlDbType = SqlDbType.NVarChar;
        Call_Center_Group.Value = dr["Call Center Group"].ToString().Trim();
        Call_Center_Group.ParameterName = "@Call_Center_Group";
        sqlcmd.Parameters.Add(Call_Center_Group);

        SqlParameter Team_Leader = new SqlParameter();
        Team_Leader.SqlDbType = SqlDbType.NVarChar;
        Team_Leader.Value = dr["Team Leader"].ToString().Trim();
        Team_Leader.ParameterName = "@Team_Leader";
        sqlcmd.Parameters.Add(Team_Leader);

        SqlParameter Customer_Name = new SqlParameter();
        Customer_Name.SqlDbType = SqlDbType.NVarChar;
        Customer_Name.Value = dr["Customer Name"].ToString().Trim();
        Customer_Name.ParameterName = "@CUST_FULLNAME";
        sqlcmd.Parameters.Add(Customer_Name);

        SqlParameter Customer_Address = new SqlParameter();
        Customer_Address.SqlDbType = SqlDbType.NVarChar;
        Customer_Address.Value = dr["Customer Address"].ToString().Trim();
        Customer_Address.ParameterName = "@CUST_ADD_LINE_1";
        sqlcmd.Parameters.Add(Customer_Address);

        SqlParameter Contact_No = new SqlParameter();
        Contact_No.SqlDbType = SqlDbType.NVarChar;
        Contact_No.Value = dr["Contact No"].ToString().Trim();
        Contact_No.ParameterName = "@CUST_CONTACT_NO";
        sqlcmd.Parameters.Add(Contact_No);

        SqlParameter Initiation_Date = new SqlParameter();
        Initiation_Date.SqlDbType = SqlDbType.DateTime;
        Initiation_Date.Value = dr["Initiation Date"].ToString().Trim();
        Initiation_Date.ParameterName = "@INITIATION_DATE";
        sqlcmd.Parameters.Add(Initiation_Date);

        string AppointmentDate = dr["Appointment Date"].ToString().Trim();
        if (AppointmentDate != "")
        {
            SqlParameter Appointment_Date = new SqlParameter();
            Appointment_Date.SqlDbType = SqlDbType.DateTime;
            Appointment_Date.Value = AppointmentDate;
            Appointment_Date.ParameterName = "@APPOINTMENT_DATE";
            sqlcmd.Parameters.Add(Appointment_Date);
        }
        else
        {
            SqlParameter Appointment_Date = new SqlParameter();
            Appointment_Date.SqlDbType = SqlDbType.DateTime;
            Appointment_Date.Value = DBNull.Value; ;
            Appointment_Date.ParameterName = "@APPOINTMENT_DATE";
            sqlcmd.Parameters.Add(Appointment_Date);
        }

        SqlParameter Appointment_Time = new SqlParameter();
        Appointment_Time.SqlDbType = SqlDbType.VarChar;
        Appointment_Time.Value = dr["Appointment Time"].ToString().Trim();
        Appointment_Time.ParameterName = "@APPOINTMENT_TIME";
        sqlcmd.Parameters.Add(Appointment_Time);

        SqlParameter Amount = new SqlParameter();
        Amount.SqlDbType = SqlDbType.VarChar;
        Amount.Value = dr["Amount"].ToString().Trim();
        Amount.ParameterName = "@AMOUNT";
        sqlcmd.Parameters.Add(Amount);

        SqlParameter Remarks = new SqlParameter();
        Remarks.SqlDbType = SqlDbType.NVarChar;
        Remarks.Value = dr["Remarks"].ToString().Trim();
        Remarks.ParameterName = "@REMARK";
        sqlcmd.Parameters.Add(Remarks);

        SqlParameter Lead_Type = new SqlParameter();
        Lead_Type.SqlDbType = SqlDbType.VarChar;
        Lead_Type.Value = dr["Lead Type"].ToString().Trim();
        Lead_Type.ParameterName = "LEAD_TYPE";
        sqlcmd.Parameters.Add(Lead_Type);

        SqlParameter Location = new SqlParameter();
        Location.SqlDbType = SqlDbType.VarChar;
        Location.Value = dr["Location"].ToString().Trim();
        Location.ParameterName = "@Centre_Name";
        sqlcmd.Parameters.Add(Location);

        SqlParameter Verification_Type = new SqlParameter();
        Verification_Type.SqlDbType = SqlDbType.VarChar;
        Verification_Type.Value = dr["Verification Type"].ToString().Trim();
        Verification_Type.ParameterName = "@Verification_type_id";
        sqlcmd.Parameters.Add(Verification_Type);

        SqlParameter Case_Type = new SqlParameter();
        Case_Type.SqlDbType = SqlDbType.VarChar;
        Case_Type.Value = ddlCaseType.SelectedItem.ToString().Trim();
        Case_Type.ParameterName = "@Case_Type";
        sqlcmd.Parameters.Add(Case_Type);

        SqlParameter Centre_id = new SqlParameter();
        Centre_id.SqlDbType = SqlDbType.VarChar;
        Centre_id.Value = Centreid;
        Centre_id.ParameterName = "@Centreid";
        sqlcmd.Parameters.Add(Centre_id);

        SqlParameter Cluster_id = new SqlParameter();
        Cluster_id.SqlDbType = SqlDbType.VarChar;
        Cluster_id.Value = clusterID;
        Cluster_id.ParameterName = "@Clusterid";
        sqlcmd.Parameters.Add(Cluster_id);

        SqlParameter Case_id = new SqlParameter();
        Case_id.SqlDbType = SqlDbType.VarChar;
        Case_id.Value = StrCase_id;
        Case_id.ParameterName = "@Case_id";
        sqlcmd.Parameters.Add(Case_id);

        SqlParameter ReceivedDate = new SqlParameter();
        ReceivedDate.SqlDbType = SqlDbType.VarChar;
        ReceivedDate.Value = strDate(txtCaseReceivedDate.Text.Trim());
        ReceivedDate.ParameterName = "@ReceivedDate";
        sqlcmd.Parameters.Add(ReceivedDate);

        SqlParameter ReceivedTime = new SqlParameter();
        ReceivedTime.SqlDbType = SqlDbType.VarChar;
        ReceivedTime.Value = txtCaseReceivedTime.Text.ToString().Trim() + " " + ddlCaseReceivedTime.SelectedItem.ToString();
        ReceivedTime.ParameterName = "@ReceivedTime";
        sqlcmd.Parameters.Add(ReceivedTime);

        SqlParameter Policy_No = new SqlParameter();
        Policy_No.SqlDbType = SqlDbType.VarChar;
        Policy_No.Value = dr["Policy No"].ToString().Trim(); ;
        Policy_No.ParameterName = "@Policy_No";
        sqlcmd.Parameters.Add(Policy_No);

        string PinCode = dr["PIN Code"].ToString().Trim();
        if (PinCode != "")
        {
            SqlParameter PIN_Code = new SqlParameter();
            PIN_Code.SqlDbType = SqlDbType.VarChar;
            PIN_Code.Value = PinCode;
            PIN_Code.ParameterName = "@CUST_PIN";
            sqlcmd.Parameters.Add(PIN_Code);
        }

        int RowEffected = 0;
        RowEffected = sqlcmd.ExecuteNonQuery();
        sqlcon.Close();

        if (RowEffected > 0)
        {
            lblMsgXls.Visible = true;
        }
    }


}
