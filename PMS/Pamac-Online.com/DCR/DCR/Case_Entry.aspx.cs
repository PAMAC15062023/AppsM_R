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

public partial class DCR_DCR_Case_Entry : System.Web.UI.Page
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
            Validate();
            Get_ClusterList();
            Get_verificationType();
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

    protected void Validate()
    {
        btnSave.Attributes.Add("onclick", "javascript:return Validate();");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("Default.aspx");
    }

    protected void ClearControl()
    {
        ddlcenter.SelectedIndex = 0;
        ddlverificationtype.SelectedIndex = 0;
        txtLeadID.Text = "";
        txtPolicyNo.Text = "";
        txtCallCenter.Text = "";
        txtTeamLeader.Text = "";
        txtName.Text = "";
        txtAddress.Text = "";
        txtPincode.Text = "";
        txtContactNo.Text = "";
        txtInitiationDate.Text = "";
        ddlLeadType.SelectedIndex = 0;
        txtAppointmentDate.Text = "";
        txtAppointmentTime.Text = "";
        txtAmount.Text = "";
        txtRemarks.Text = "";
        txtCaseReceivedDate.Text = "";
        txtCaseReceivedTime.Text = "";
    }

    private void Get_ClusterList()
    {
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_ClusterMaster";
        sqlcmd.CommandTimeout = 0;

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;

        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            ddlclustername.DataTextField = "CLUSTER_NAME";
            ddlclustername.DataValueField = "CLUSTER_ID";

            ddlclustername.DataSource = dt;
            ddlclustername.DataBind();

            ddlclustername.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }

    protected void ddlclustername_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        FillCentre();
    }

    public void FillCentre()
    {
        try
        {
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "DCR_cluster_Assign";
            sqlcmd.CommandTimeout = 0;

            SqlParameter Cluster_id = new SqlParameter();
            Cluster_id.SqlDbType = SqlDbType.VarChar;
            Cluster_id.Value = ddlclustername.SelectedValue.ToString();
            Cluster_id.ParameterName = "@Cluster_id";
            sqlcmd.Parameters.Add(Cluster_id);

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = sqlcmd;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            HdnclusterID.Value = dt1.Rows[0]["cluster_id"].ToString();

            if (dt1.Rows.Count > 0)
            {
                ddlcenter.DataTextField = "Centre_Name";
                ddlcenter.DataValueField = "Centre_id";

                ddlcenter.DataSource = dt1;
                ddlcenter.DataBind();

                ddlcenter.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlcenter.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    private void Get_verificationType()
    {
        try
        {
            sqlcon.Open();

            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = sqlcon;
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd3.CommandText = "DCR_FE_ASSIGN_VERIFICATION_TYPE";
            cmd3.CommandTimeout = 0;

            SqlDataAdapter sqlda2 = new SqlDataAdapter();
            sqlda2.SelectCommand = cmd3;

            DataTable dt = new DataTable();
            sqlda2.Fill(dt);

            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                ddlverificationtype.DataTextField = "Verification_Type";
                ddlverificationtype.DataValueField = "Verification_type_code";

                ddlverificationtype.DataSource = dt;
                ddlverificationtype.DataBind();

                ddlverificationtype.Items.Insert(0, new ListItem("--Select--", "A"));
                ddlverificationtype.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            sqlcon.Open();

            SqlCommand sqlcmd1 = new SqlCommand();
            sqlcmd1.Connection = sqlcon;
            sqlcmd1.CommandType = CommandType.StoredProcedure;
            sqlcmd1.CommandText = "SP_getTopID_new";
            sqlcmd1.CommandTimeout = 0;

            SqlParameter Cluster = new SqlParameter();
            Cluster.SqlDbType = SqlDbType.VarChar;
            Cluster.Value = HdnclusterID.Value;
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

            if (HdnclusterID.Value == "1011")
            {
                strproc = "DCR_INSERT_CASE_BVU";
                StrCase_id = "B" + ID;
            }
            else if (HdnclusterID.Value == "1014")
            {
                strproc = "DCR_INSERT_CASE_EAST";
                StrCase_id = "E" + ID;
            }
            else if (HdnclusterID.Value == "1013")
            {
                strproc = "DCR_INSERT_CASE_SOUTH";
                StrCase_id = "S" + ID;
            }
            else if (HdnclusterID.Value == "1015")
            {
                strproc = "DCR_INSERT_CASE_NORTH";
                StrCase_id = "N" + ID;
            }
            else if (HdnclusterID.Value == "1018")
            {
                strproc = "DCR_INSERT_CASE_BVU";
                StrCase_id = "B" + ID;
            }
            else
            {
                strproc = "DCR_INSERT_CASE_WEST";
                StrCase_id = "W" + ID;
            }


            ////////////////////////////////////////////////////////////////////////////////////////

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

            SqlParameter MODIFY_BY = new SqlParameter();
            MODIFY_BY.SqlDbType = SqlDbType.VarChar;
            MODIFY_BY.Value = DBNull.Value;
            MODIFY_BY.ParameterName = "@MODIFY_BY";
            sqlcmd.Parameters.Add(MODIFY_BY);

            SqlParameter Case_id = new SqlParameter();
            Case_id.SqlDbType = SqlDbType.VarChar;
            Case_id.Value = StrCase_id;
            Case_id.ParameterName = "@Case_id";
            sqlcmd.Parameters.Add(Case_id);

            SqlParameter Lead_id = new SqlParameter();
            Lead_id.SqlDbType = SqlDbType.NVarChar;
            Lead_id.Value = txtLeadID.Text.ToString().Trim();
            Lead_id.ParameterName = "@LEAD_ID";
            sqlcmd.Parameters.Add(Lead_id);

            SqlParameter Policy_No = new SqlParameter();
            Policy_No.SqlDbType = SqlDbType.NVarChar;
            Policy_No.Value = txtPolicyNo.Text.ToString().Trim();
            Policy_No.ParameterName = "@Policy_No";
            sqlcmd.Parameters.Add(Policy_No);

            SqlParameter Call_Center_Group = new SqlParameter();
            Call_Center_Group.SqlDbType = SqlDbType.NVarChar;
            Call_Center_Group.Value = txtCallCenter.Text.ToString().Trim();
            Call_Center_Group.ParameterName = "@Call_Center_Group";
            sqlcmd.Parameters.Add(Call_Center_Group);

            SqlParameter Team_Leader = new SqlParameter();
            Team_Leader.SqlDbType = SqlDbType.NVarChar;
            Team_Leader.Value = txtTeamLeader.Text.ToString().Trim();
            Team_Leader.ParameterName = "@Team_Leader";
            sqlcmd.Parameters.Add(Team_Leader);

            SqlParameter Customer_Name = new SqlParameter();
            Customer_Name.SqlDbType = SqlDbType.NVarChar;
            Customer_Name.Value = txtName.Text.ToString().Trim();
            Customer_Name.ParameterName = "@CUST_FULLNAME";
            sqlcmd.Parameters.Add(Customer_Name);

            SqlParameter Customer_Address = new SqlParameter();
            Customer_Address.SqlDbType = SqlDbType.NVarChar;
            Customer_Address.Value = txtAddress.Text.ToString().Trim();
            Customer_Address.ParameterName = "@CUST_ADD_LINE_1";
            sqlcmd.Parameters.Add(Customer_Address);

            string PinCode = txtPincode.Text.ToString().Trim();
            if (PinCode != "")
            {
                SqlParameter PIN_Code = new SqlParameter();
                PIN_Code.SqlDbType = SqlDbType.VarChar;
                PIN_Code.Value = PinCode;
                PIN_Code.ParameterName = "@CUST_PIN";
                sqlcmd.Parameters.Add(PIN_Code);
            }

            SqlParameter Contact_No = new SqlParameter();
            Contact_No.SqlDbType = SqlDbType.NVarChar;
            Contact_No.Value = txtContactNo.Text.ToString().Trim();
            Contact_No.ParameterName = "@CUST_CONTACT_NO";
            sqlcmd.Parameters.Add(Contact_No);

            SqlParameter Initiation_Date = new SqlParameter();
            Initiation_Date.SqlDbType = SqlDbType.DateTime;
            Initiation_Date.Value = strDate(txtInitiationDate.Text.ToString().Trim());
            Initiation_Date.ParameterName = "@INITIATION_DATE";
            sqlcmd.Parameters.Add(Initiation_Date);


            if (txtAppointmentDate.Text != "")
            {
                SqlParameter Appointment_Date = new SqlParameter();
                Appointment_Date.SqlDbType = SqlDbType.DateTime;
                Appointment_Date.Value = strDate(txtAppointmentDate.Text.ToString().Trim());
                Appointment_Date.ParameterName = "@APPOINTMENT_DATE";
                sqlcmd.Parameters.Add(Appointment_Date);
            }
            else
            {
                SqlParameter Appointment_Date = new SqlParameter();
                Appointment_Date.SqlDbType = SqlDbType.DateTime;
                Appointment_Date.Value = DBNull.Value;
                Appointment_Date.ParameterName = "@APPOINTMENT_DATE";
                sqlcmd.Parameters.Add(Appointment_Date);
            }


            if (txtAppointmentDate.Text != "")
            {
                SqlParameter Appointment_Time = new SqlParameter();
                Appointment_Time.SqlDbType = SqlDbType.VarChar;
                Appointment_Time.Value = txtAppointmentTime.Text.ToString().Trim() + " " + ddlAppointmentTime.SelectedItem.Text;
                Appointment_Time.ParameterName = "@APPOINTMENT_TIME";
                sqlcmd.Parameters.Add(Appointment_Time);
            }
            else
            {
                SqlParameter Appointment_Time = new SqlParameter();
                Appointment_Time.SqlDbType = SqlDbType.VarChar;
                Appointment_Time.Value = DBNull.Value;
                Appointment_Time.ParameterName = "@APPOINTMENT_TIME";
                sqlcmd.Parameters.Add(Appointment_Time);
            }


            SqlParameter Amount = new SqlParameter();
            Amount.SqlDbType = SqlDbType.VarChar;
            Amount.Value = txtAmount.Text.ToString().Trim();
            Amount.ParameterName = "@AMOUNT";
            sqlcmd.Parameters.Add(Amount);

            SqlParameter Remarks = new SqlParameter();
            Remarks.SqlDbType = SqlDbType.NVarChar;
            Remarks.Value = txtRemarks.Text.ToString().Trim();
            Remarks.ParameterName = "@REMARK";
            sqlcmd.Parameters.Add(Remarks);

            SqlParameter Lead_Type = new SqlParameter();
            Lead_Type.SqlDbType = SqlDbType.VarChar;
            Lead_Type.Value = ddlLeadType.SelectedItem.ToString().Trim();
            Lead_Type.ParameterName = "LEAD_TYPE";
            sqlcmd.Parameters.Add(Lead_Type);

            SqlParameter Location = new SqlParameter();
            Location.SqlDbType = SqlDbType.VarChar;
            Location.Value = ddlcenter.SelectedItem.ToString().Trim();
            Location.ParameterName = "@Centre_Name";
            sqlcmd.Parameters.Add(Location);

            SqlParameter Verification_Type = new SqlParameter();
            Verification_Type.SqlDbType = SqlDbType.VarChar;
            Verification_Type.Value = ddlverificationtype.SelectedValue.ToString().Trim();
            Verification_Type.ParameterName = "@Verification_type_id";
            sqlcmd.Parameters.Add(Verification_Type);

            SqlParameter Centre_id = new SqlParameter();
            Centre_id.SqlDbType = SqlDbType.VarChar;
            Centre_id.Value = ddlcenter.SelectedValue.ToString();
            Centre_id.ParameterName = "@Centreid";
            sqlcmd.Parameters.Add(Centre_id);

            SqlParameter Cluster_id = new SqlParameter();
            Cluster_id.SqlDbType = SqlDbType.VarChar;
            Cluster_id.Value = HdnclusterID.Value;
            Cluster_id.ParameterName = "@Clusterid";
            sqlcmd.Parameters.Add(Cluster_id);

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

            int RowEffected = 0;
            RowEffected = sqlcmd.ExecuteNonQuery();

            sqlcon.Close();

            if (RowEffected > 0)
            {
                lblMsg.Text = "Record Save Successfully...!!!";
            }
            ClearControl();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }


}
