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

public partial class DCR_DCR_Case_Updation : System.Web.UI.Page
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;
    string strproc;

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);

        if (!IsPostBack)
        {
            Validate();
            Get_ClusterList();
            Get_verificationType();

            grvCaseEntry.Columns[20].Visible = false;
            grvCaseEntry.Columns[21].Visible=false;
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
        HdnCaseID.Value = "0";
        HdnID.Value = "0";

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
        FillGrid();
        ClearControl();
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

    protected void FillGrid()
    {
        try
        {
            sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DCR_Get_CaseEntry";
            cmd.CommandTimeout = 0;

            SqlParameter ClusterID = new SqlParameter();
            ClusterID.SqlDbType = SqlDbType.VarChar;
            ClusterID.Value = ddlclustername.SelectedValue.ToString();
            ClusterID.ParameterName = "@Cluster_id";
            cmd.Parameters.Add(ClusterID);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                lblMsg.Text = "Total Records : " + dt.Rows.Count;

                grvCaseEntry.DataSource = dt;
                grvCaseEntry.DataBind();
            }
            else
            {
                lblMsg.Text = "No Records Found...!!!";

                grvCaseEntry.DataSource = null;
                grvCaseEntry.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void grvCaseEntry_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grvCaseEntry.PageIndex = e.NewEditIndex;
    }

    protected void grvCaseEntry_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblMsg.Text = "";
        HdnCaseID.Value = "";
        HdnID.Value = "";

        for (int i = 0; i <= grvCaseEntry.Rows.Count - 1; i++)
        {
            string caseID = e.CommandArgument.ToString();
            HdnCaseID.Value = grvCaseEntry.Rows[i].Cells[1].Text.ToString();

            if (e.CommandName == "Edit")
            {
                if (caseID == HdnCaseID.Value)
                {
                    //ddlcenter.SelectedItem.Text.ToString() = grvCaseEntry.Rows[i].Cells[2].Text.ToString();
                    //ddlverificationtype.Text = grvCaseEntry.Rows[i].Cells[3].Text.ToString();
                    txtLeadID.Text = grvCaseEntry.Rows[i].Cells[4].Text.ToString();
                    txtPolicyNo.Text = grvCaseEntry.Rows[i].Cells[5].Text.ToString();
                    txtCallCenter.Text = grvCaseEntry.Rows[i].Cells[6].Text.ToString();
                    txtTeamLeader.Text = grvCaseEntry.Rows[i].Cells[7].Text.ToString();
                    txtName.Text = grvCaseEntry.Rows[i].Cells[8].Text.ToString();
                    txtAddress.Text = grvCaseEntry.Rows[i].Cells[9].Text.ToString();
                    txtPincode.Text = grvCaseEntry.Rows[i].Cells[10].Text.ToString();
                    txtContactNo.Text = grvCaseEntry.Rows[i].Cells[11].Text.ToString();
                    txtInitiationDate.Text = grvCaseEntry.Rows[i].Cells[12].Text.ToString();
                    ddlLeadType.Text = grvCaseEntry.Rows[i].Cells[13].Text.ToString();
                    txtAppointmentDate.Text = grvCaseEntry.Rows[i].Cells[14].Text.ToString();
                    txtAppointmentTime.Text = grvCaseEntry.Rows[i].Cells[15].Text.ToString();
                    txtAmount.Text = grvCaseEntry.Rows[i].Cells[16].Text.ToString();
                    txtRemarks.Text = grvCaseEntry.Rows[i].Cells[17].Text.ToString();
                    txtCaseReceivedDate.Text = grvCaseEntry.Rows[i].Cells[18].Text.ToString();
                    txtCaseReceivedTime.Text = grvCaseEntry.Rows[i].Cells[19].Text.ToString();

                    HdnclusterID.Value = grvCaseEntry.Rows[i].Cells[20].Text.ToString();
                    HdnCentreID.Value = grvCaseEntry.Rows[i].Cells[21].Text.ToString();

                    HdnID.Value = HdnCaseID.Value;
                }
            }
        }

        lblMsg.Text = "";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (HdnclusterID.Value == "1011")
            {
                strproc = "DCR_INSERT_CASE_BVU";
            }
            else if (HdnclusterID.Value == "1014")
            {
                strproc = "DCR_INSERT_CASE_EAST";
            }
            else if (HdnclusterID.Value == "1013")
            {
                strproc = "DCR_INSERT_CASE_SOUTH";
            }
            else if (HdnclusterID.Value == "1015")
            {
                strproc = "DCR_INSERT_CASE_NORTH";
            }
            else if (HdnclusterID.Value == "1018")
            {
                strproc = "DCR_INSERT_CASE_BVU";
            }
            else
            {
                strproc = "DCR_INSERT_CASE_WEST";
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
            ADD_BY.Value = DBNull.Value;
            ADD_BY.ParameterName = "@ADD_BY";
            sqlcmd.Parameters.Add(ADD_BY);

            SqlParameter MODIFY_BY = new SqlParameter();
            MODIFY_BY.SqlDbType = SqlDbType.VarChar;
            MODIFY_BY.Value = Session["UserID"].ToString().Trim();
            MODIFY_BY.ParameterName = "@MODIFY_BY";
            sqlcmd.Parameters.Add(MODIFY_BY);

            SqlParameter Case_id = new SqlParameter();
            Case_id.SqlDbType = SqlDbType.VarChar;
            Case_id.Value = HdnID.Value;
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
            ReceivedTime.Value = txtCaseReceivedTime.Text.ToString().Trim() + " " + ddlCaseReceivedTime.SelectedItem.Text.ToString();
            ReceivedTime.ParameterName = "@ReceivedTime";
            sqlcmd.Parameters.Add(ReceivedTime);

            int RowEffected = 0;
            RowEffected = sqlcmd.ExecuteNonQuery();

            sqlcon.Close();

            if (RowEffected > 0)
            {
                lblMsg.Text = "Record Updated Successfully...!!!";
            }
            ClearControl();

            grvCaseEntry.DataSource = null;
            grvCaseEntry.DataBind();


            Response.Redirect("Case_Updation.aspx");
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    public SortDirection SortDirection
    {
        get
        {
            if (ViewState["SortDirection"] == null)
            {
                ViewState["SortDirection"] = SortDirection.Ascending;
            }
            return (SortDirection)ViewState["SortDirection"];
        }
        set
        {
            ViewState["SortDirection"] = value;
        }
    }

    protected void grvCaseEntry_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression;
        string direction = string.Empty;

        if (SortDirection == SortDirection.Ascending)
        {
            SortDirection = SortDirection.Descending;
            direction = "DESC";
        }
        else
        {
            SortDirection = SortDirection.Ascending;
            direction = "ASC";
        }


        sqlcon.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlcon;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "DCR_Get_CaseEntry";
        cmd.CommandTimeout = 0;

        SqlParameter ClusterID = new SqlParameter();
        ClusterID.SqlDbType = SqlDbType.VarChar;
        ClusterID.Value = ddlclustername.SelectedValue.ToString();
        ClusterID.ParameterName = "@Cluster_id";
        cmd.Parameters.Add(ClusterID);

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataTable dt = new DataTable();
        da.Fill(dt);

        sqlcon.Close();

        dt.DefaultView.Sort = sortExpression + " " + direction;

        grvCaseEntry.DataSource = dt;
        grvCaseEntry.DataBind();
    }


}
