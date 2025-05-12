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

public partial class CPA_PD_Case_Updation : System.Web.UI.Page
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;
    string strproc;
    string StrCase_id;

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);

        if (!IsPostBack)
        {
            Validate();
            Get_ClusterList();
            FillGrid();
            //Get_verificationType();

            //grdTele.Columns[20].Visible = false;
            //grdTele.Columns[21].Visible=false;
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
        //ddlverificationtype.SelectedIndex = 0;
        //txtLeadID.Text = "";
        //txtPolicyNo.Text = "";
        //txtCallCenter.Text = "";
        //txtTeamLeader.Text = "";
        //txtName.Text = "";
        //txtAddress.Text = "";
        //txtPincode.Text = "";
        //txtContactNo.Text = "";
        //txtInitiationDate.Text = "";
        //ddlLeadType.SelectedIndex = 0;
        //txtAppointmentDate.Text = "";
        //txtAppointmentTime.Text = "";
        //txtAmount.Text = "";
        //txtRemarks.Text = "";
        //txtCaseReceivedDate.Text = "";
        //txtCaseReceivedTime.Text = "";
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
            sqlcmd.CommandText = "PD_cluster_Assign12";
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

    //private void Get_verificationType()
    //{
    //    try
    //    {
    //        sqlcon.Open();

    //        SqlCommand cmd3 = new SqlCommand();
    //        cmd3.Connection = sqlcon;
    //        cmd3.CommandType = CommandType.StoredProcedure;
    //        cmd3.CommandText = "DCR_FE_ASSIGN_VERIFICATION_TYPE";
    //        cmd3.CommandTimeout = 0;

    //        SqlDataAdapter sqlda2 = new SqlDataAdapter();
    //        sqlda2.SelectCommand = cmd3;

    //        DataTable dt = new DataTable();
    //        sqlda2.Fill(dt);

    //        sqlcon.Close();

    //        if (dt.Rows.Count > 0)
    //        {
    //            ddlverificationtype.DataTextField = "Verification_Type";
    //            ddlverificationtype.DataValueField = "Verification_type_code";

    //            ddlverificationtype.DataSource = dt;
    //            ddlverificationtype.DataBind();

    //            ddlverificationtype.Items.Insert(0, new ListItem("--Select--", "A"));
    //            ddlverificationtype.SelectedIndex = 0;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMsg.Text = ex.Message;
    //    }
    //}

    protected void FillGrid()
    {
        try
        {
            sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PD_get_tele_details123";
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

                grdTele.DataSource = dt;
                grdTele.DataBind();
            }
            else
            {
                lblMsg.Text = "No Records Found...!!!";

                grdTele.DataSource = null;
                grdTele.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void grdTele_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdTele.PageIndex = e.NewEditIndex;
    }

    protected void grdTele_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblMsg.Text = "";
        HdnCaseID.Value = "";
        HdnID.Value = "";

        for (int i = 0; i <= grdTele.Rows.Count - 1; i++)
        {
            string caseID = e.CommandArgument.ToString();
            HdnCaseID.Value = grdTele.Rows[i].Cells[1].Text.ToString();

            if (e.CommandName == "Edit")
            {
                if (caseID == HdnCaseID.Value)
                {
                    //ddlcenter.SelectedItem.Text.ToString() = grdTele.Rows[i].Cells[2].Text.ToString();
                    //ddlverificationtype.Text = grdTele.Rows[i].Cells[3].Text.ToString();

                    txtfilerefno.Text = grdTele.Rows[i].Cells[2].Text.Trim();
                    txtcustname.Text = grdTele.Rows[i].Cells[3].Text.Trim();
                    txtCompname.Text = grdTele.Rows[i].Cells[4].Text.Trim();
                    txtcontactpersonname.Text = grdTele.Rows[i].Cells[5].Text.Trim();
                    txtcontactno.Text = grdTele.Rows[i].Cells[6].Text.Trim();
                    txtPamaclocation.Text = grdTele.Rows[i].Cells[7].Text.Trim();
                    txtAddress.Text = grdTele.Rows[i].Cells[8].Text.Trim();
                    txtAllocationdate.Text = grdTele.Rows[i].Cells[9].Text.Trim();
                    HdnclusterID.Value = grdTele.Rows[i].Cells[10].Text.Trim();

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
            int i = 0;
            StrCase_id = HdnCaseID.Value;

            if (HdnclusterID.Value == "1014")
            {
                strproc = "pd_INSERT_CASE_east_updation";
            }
            else if (HdnclusterID.Value == "1012")
            {
                strproc = "pd_INSERT_CASE_west_updation";
            }
            else if (HdnclusterID.Value == "1013")
            {
                strproc = "pd_INSERT_CASE_south_updation";
            }
            else if (HdnclusterID.Value == "1015")
            {
                strproc = "pd_INSERT_CASE_North_updation";
            }
            else if (HdnclusterID.Value == "1018")
            {
                strproc = "pd_INSERT_CASE_BVU_updation";
            }
            else
            {
                strproc = "pd_INSERT_CASE_west_updation";
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

            //SqlParameter ADD_BY = new SqlParameter();
            //ADD_BY.SqlDbType = SqlDbType.VarChar;
            //ADD_BY.Value = DBNull.Value;
            //ADD_BY.ParameterName = "@ADD_BY";
            //sqlcmd.Parameters.Add(ADD_BY);

            SqlParameter MODIFY_BY = new SqlParameter();
            MODIFY_BY.SqlDbType = SqlDbType.VarChar;
            MODIFY_BY.Value = Session["UserID"].ToString();
            MODIFY_BY.ParameterName = "@MODIFY_BY";
            sqlcmd.Parameters.Add(MODIFY_BY);

            SqlParameter Case_id = new SqlParameter();
            Case_id.SqlDbType = SqlDbType.VarChar;
            Case_id.Value = StrCase_id;
            Case_id.ParameterName = "@Case_id";
            sqlcmd.Parameters.Add(Case_id);

            SqlParameter flie_ref_no = new SqlParameter();
            flie_ref_no.SqlDbType = SqlDbType.NVarChar;
            flie_ref_no.Value = txtfilerefno.Text.ToString().Trim();
            flie_ref_no.ParameterName = "@File_Ref_No";
            sqlcmd.Parameters.Add(flie_ref_no);

            SqlParameter customer_name = new SqlParameter();
            customer_name.SqlDbType = SqlDbType.NVarChar;
            customer_name.Value = txtcustname.Text.ToString().Trim();
            customer_name.ParameterName = "@Customer_Name";
            sqlcmd.Parameters.Add(customer_name);

            SqlParameter Compname = new SqlParameter();
            Compname.SqlDbType = SqlDbType.NVarChar;
            Compname.Value = txtCompname.Text.ToString().Trim();
            Compname.ParameterName = "@Company_Name";
            sqlcmd.Parameters.Add(Compname);

            SqlParameter contact_person_name = new SqlParameter();
            contact_person_name.SqlDbType = SqlDbType.NVarChar;
            contact_person_name.Value = txtcontactpersonname.Text.ToString().Trim();
            contact_person_name.ParameterName = "@Contact_Person_Name";
            sqlcmd.Parameters.Add(contact_person_name);

            SqlParameter contact_no = new SqlParameter();
            contact_no.SqlDbType = SqlDbType.NVarChar;
            contact_no.Value = txtcontactno.Text.ToString().Trim();
            contact_no.ParameterName = "@Contact_Number";
            sqlcmd.Parameters.Add(contact_no);

            SqlParameter pamac_location = new SqlParameter();
            pamac_location.SqlDbType = SqlDbType.NVarChar;
            pamac_location.Value = txtPamaclocation.Text.ToString().Trim();
            pamac_location.ParameterName = "@pamac_location";
            sqlcmd.Parameters.Add(pamac_location);


            SqlParameter address = new SqlParameter();
            address.SqlDbType = SqlDbType.NVarChar;
            address.Value = txtAddress.Text.ToString().Trim();
            address.ParameterName = "@Address";
            sqlcmd.Parameters.Add(address);



            SqlParameter allocatio_date = new SqlParameter();
            allocatio_date.SqlDbType = SqlDbType.DateTime;
            allocatio_date.Value = strDate(txtAllocationdate.Text.ToString().Trim());
            allocatio_date.ParameterName = "@Allocation_date";
            sqlcmd.Parameters.Add(allocatio_date);


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

            int RowEffected = 0;
            RowEffected = sqlcmd.ExecuteNonQuery();

            sqlcon.Close();

            if (RowEffected > 0)
            {
                lblMsg.Text = "Record Updated Successfully...!!!";
            }
            ClearControl();
            FillGrid();

            grdTele.DataSource = null;
            grdTele.DataBind();


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

    protected void grdTele_Sorting(object sender, GridViewSortEventArgs e)
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

        grdTele.DataSource = dt;
        grdTele.DataBind();
    }
}
