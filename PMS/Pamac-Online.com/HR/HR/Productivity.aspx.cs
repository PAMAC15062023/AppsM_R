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

public partial class HR_HR_Productivity : System.Web.UI.Page
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);

        if (!IsPostBack)
        {
            Validation();
            Get_ClusterList();
            Get_ClusterList1();
            pnlCategory.Visible = true;
            //NEW
            Get_ClusterList2();
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

    protected void btnCancel_Click1(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void btnCancel1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void btnCancel2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void Validation()
    {
        btnSearch1.Attributes.Add("onclick", "javascript:return SearchMaster();");
        btnSearch.Attributes.Add("onclick", "javascript:return SearchUpdate();");
        btnSave.Attributes.Add("onclick", "javascript:return Validate();");
        btnRemove.Attributes.Add("onclick", "javascript:return ValidateRemove();");
        //NEW
        btnSearch2.Attributes.Add("onclick", "javascript:return SearchBackUp();");
        btnSaveBackUp.Attributes.Add("onclick", "javascript:return ValidateBackUp();");
    }

    protected void Get_ClusterList()
    {
        try
        {
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

                ddlclustername.Items.Insert(0, new ListItem("--SELECT--", "0"));
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void Get_ClusterList1()
    {
        try
        {
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
                ddlclustername1.DataTextField = "CLUSTER_NAME";
                ddlclustername1.DataValueField = "CLUSTER_ID";

                ddlclustername1.DataSource = dt;
                ddlclustername1.DataBind();

                ddlclustername1.Items.Insert(0, new ListItem("--SELECT--", "0"));
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void ClearControls()
    {
        HDNEmpCode1.Value = "";
        HDNID.Value = "";

        ddlCategory.SelectedIndex = 0;
        ddlclustername.SelectedIndex = 0;
        ddlclustername1.SelectedIndex = 0;
        txtSearchEmpMaster.Text = "";
        txtSearchEmpUpdate.Text = "";

        txtEmpCode.Text = "";
        txtEmpName.Text = "";
        txtCentre.Text = "";
        txtSubCentre.Text = "";
        txtDOJ.Text = "";
        txtEmpType.Text = "";
        txtActivity.Text = "";
        txtDepartment.Text = "";
        txtDesignation.Text = "";
        txtUpdateCode.Text = "";
        txtMinProd.Text = "";
        txtRemark.Text = "";

        GridSearchMaster.DataSource = null;
        GridSearchMaster.DataBind();
        GridSearchUpdate.DataSource = null;
        GridSearchUpdate.DataBind();

        //NEW
        HdnUA.Value = "";
        HdnUA_ID.Value = "";
        ddlclustername2.SelectedIndex = 0;
        txtUpdateEmp.Text = "";
        txtUpdate_EmpCode.Text = "";
        txtBackUp_EmpCode.Text = "";
        GridBackUp.DataSource = null;
        GridBackUp.DataBind();
        //END NEW 
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblUpdate.Text = "";

        if (ddlCategory.SelectedIndex == 0)
        {
            pnlMsg.Visible = true;
            pnlCategory.Visible = true;
            pnlSearchMaster.Visible = false;
            pnlData.Visible = false;
            pnlSearchUpdate.Visible = false;
            //NEW
            pnlBackupSearch.Visible = false;
            pnlBackupSave.Visible = false;
        }

        if (ddlCategory.SelectedIndex == 1)
        {
            pnlMsg.Visible = true;
            pnlCategory.Visible = false;
            pnlSearchMaster.Visible = true;
            pnlData.Visible = false;
            pnlSearchUpdate.Visible = false;
            //NEW
            pnlBackupSearch.Visible = false;
            pnlBackupSave.Visible = false;
        }

        if (ddlCategory.SelectedIndex == 2)
        {
            pnlMsg.Visible = true;
            pnlCategory.Visible = false;
            pnlSearchMaster.Visible = false;
            pnlData.Visible = false;
            pnlSearchUpdate.Visible = true;
            //NEW
            pnlBackupSearch.Visible = false;
            pnlBackupSave.Visible = false;
        }
        //NEW
        if (ddlCategory.SelectedIndex == 3)
        {
            pnlMsg.Visible = true;
            pnlCategory.Visible = false;
            pnlSearchMaster.Visible = false;
            pnlData.Visible = false;
            pnlSearchUpdate.Visible = false;
            pnlBackupSearch.Visible = true;
            pnlBackupSave.Visible = false;
        }

    }

    protected void btnSearch1_Click(object sender, EventArgs e)
    {
        FillGridMaster();
    }

    protected void FillGridMaster()
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandText = "Get_OJT_Master";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;

            SqlParameter EmpSearch = new SqlParameter();
            EmpSearch.SqlDbType = SqlDbType.VarChar;
            EmpSearch.Value = txtSearchEmpMaster.Text.Trim();
            EmpSearch.ParameterName = "@Emp_Code";
            cmd.Parameters.Add(EmpSearch);

            SqlParameter ClusterID = new SqlParameter();
            ClusterID.SqlDbType = SqlDbType.VarChar;
            ClusterID.Value = ddlclustername.SelectedValue.ToString();
            ClusterID.ParameterName = "@Cluster_ID";
            cmd.Parameters.Add(ClusterID);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            sqlcon.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                GridSearchMaster.DataSource = dt;
                GridSearchMaster.DataBind();

                pnlSearchMaster.Visible = true;
            }
            else
            {
                lblMsg.Text = "Records Not Found in BIS...!!!";

                GridSearchMaster.DataSource = null;
                GridSearchMaster.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void GridSearchMaster_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridSearchMaster.PageIndex = e.NewEditIndex;
    }

    protected void GridSearchMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblMsg.Text = "";
        for (int i = 0; i <= GridSearchMaster.Rows.Count - 1; i++)
        {
            string EMPCode = e.CommandArgument.ToString();
            HDNEmpCode1.Value = GridSearchMaster.Rows[i].Cells[1].Text.Trim();

            if (e.CommandName == "Edit")
            {
                if (EMPCode == HDNEmpCode1.Value)
                {
                    txtEmpCode.Text = GridSearchMaster.Rows[i].Cells[1].Text.Trim();
                    txtEmpName.Text = GridSearchMaster.Rows[i].Cells[2].Text.Trim();
                    txtCentre.Text = GridSearchMaster.Rows[i].Cells[3].Text.Trim();
                    txtSubCentre.Text = GridSearchMaster.Rows[i].Cells[4].Text.Trim();
                    txtDOJ.Text = GridSearchMaster.Rows[i].Cells[5].Text.Trim();
                    txtEmpType.Text = GridSearchMaster.Rows[i].Cells[6].Text.Trim();
                    txtActivity.Text = GridSearchMaster.Rows[i].Cells[7].Text.Trim();
                    txtDepartment.Text = GridSearchMaster.Rows[i].Cells[8].Text.Trim();
                    txtDesignation.Text = GridSearchMaster.Rows[i].Cells[9].Text.Trim();

                    HDNID.Value = HDNEmpCode1.Value;
                }
            }
        }
        lblMsg.Text = "";
        pnlMsg.Visible = true;
        pnlCategory.Visible = false;
        pnlSearchUpdate.Visible = false;
        pnlSearchMaster.Visible = false;
        pnlData.Visible = true;
        //NEW
        pnlBackupSearch.Visible = false;
        pnlBackupSave.Visible = false;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Save();
        ClearControls();

        lblMsg.Visible = true;
        lblUpdate.Visible = false;

        pnlCategory.Visible = true;
        pnlSearchMaster.Visible = false;
        pnlData.Visible = false;
        pnlSearchUpdate.Visible = false;
        //NEW
        pnlBackupSearch.Visible = false;
        pnlBackupSave.Visible = false;
    }

    protected void Save()
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandText = "Insert_Productivity";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;

            if (ddlCategory.SelectedIndex == 1)
            {
                SqlParameter Cluster = new SqlParameter();
                Cluster.SqlDbType = SqlDbType.VarChar;
                Cluster.Value = ddlclustername.SelectedValue.Trim();
                Cluster.ParameterName = "@Cluster";
                cmd.Parameters.Add(Cluster);

                SqlParameter AddBy = new SqlParameter();
                AddBy.SqlDbType = SqlDbType.VarChar;
                AddBy.Value = Session["UserID"].ToString().Trim();
                AddBy.ParameterName = "@AddBy";
                cmd.Parameters.Add(AddBy);
            }
            else
            {
                SqlParameter AddBy = new SqlParameter();
                AddBy.SqlDbType = SqlDbType.VarChar;
                AddBy.Value = DBNull.Value;
                AddBy.ParameterName = "@AddBy";
                cmd.Parameters.Add(AddBy);
            }

            if (ddlCategory.SelectedIndex == 2)
            {
                SqlParameter Cluster1 = new SqlParameter();
                Cluster1.SqlDbType = SqlDbType.VarChar;
                Cluster1.Value = ddlclustername1.SelectedValue.Trim();
                Cluster1.ParameterName = "@Cluster";
                cmd.Parameters.Add(Cluster1);

                SqlParameter ModifyBy = new SqlParameter();
                ModifyBy.SqlDbType = SqlDbType.VarChar;
                ModifyBy.Value = Session["UserID"].ToString().Trim();
                ModifyBy.ParameterName = "@ModifyBy";
                cmd.Parameters.Add(ModifyBy);
            }
            else
            {
                SqlParameter ModifyBy = new SqlParameter();
                ModifyBy.SqlDbType = SqlDbType.VarChar;
                ModifyBy.Value = DBNull.Value;
                ModifyBy.ParameterName = "@ModifyBy";
                cmd.Parameters.Add(ModifyBy);
            }

            SqlParameter EmpCode = new SqlParameter();
            EmpCode.SqlDbType = SqlDbType.VarChar;
            EmpCode.Value = txtEmpCode.Text.Trim();
            EmpCode.ParameterName = "@Emp_Code";
            cmd.Parameters.Add(EmpCode);

            SqlParameter EmpName = new SqlParameter();
            EmpName.SqlDbType = SqlDbType.VarChar;
            EmpName.Value = txtEmpName.Text.Trim();
            EmpName.ParameterName = "@Emp_Name";
            cmd.Parameters.Add(EmpName);

            SqlParameter center = new SqlParameter();
            center.SqlDbType = SqlDbType.VarChar;
            center.Value = txtCentre.Text.Trim();
            center.ParameterName = "@Centre";
            cmd.Parameters.Add(center);

            SqlParameter SubCentre = new SqlParameter();
            SubCentre.SqlDbType = SqlDbType.VarChar;
            SubCentre.Value = txtSubCentre.Text.Trim();
            SubCentre.ParameterName = "@SubCentre";
            cmd.Parameters.Add(SubCentre);

            SqlParameter DOJ = new SqlParameter();
            DOJ.SqlDbType = SqlDbType.DateTime;
            DOJ.Value = strDate(txtDOJ.Text.Trim());
            DOJ.ParameterName = "@DOJ";
            cmd.Parameters.Add(DOJ);

            SqlParameter EmpType = new SqlParameter();
            EmpType.SqlDbType = SqlDbType.VarChar;
            EmpType.Value = txtEmpType.Text.Trim();
            EmpType.ParameterName = "@Category";
            cmd.Parameters.Add(EmpType);

            SqlParameter Activity = new SqlParameter();
            Activity.SqlDbType = SqlDbType.VarChar;
            Activity.Value = txtActivity.Text.Trim();
            Activity.ParameterName = "@Activity";
            cmd.Parameters.Add(Activity);

            SqlParameter Department = new SqlParameter();
            Department.SqlDbType = SqlDbType.VarChar;
            Department.Value = txtDepartment.Text.Trim();
            Department.ParameterName = "@Department";
            cmd.Parameters.Add(Department);

            SqlParameter Designation = new SqlParameter();
            Designation.SqlDbType = SqlDbType.VarChar;
            Designation.Value = txtDesignation.Text.Trim();
            Designation.ParameterName = "@Designation";
            cmd.Parameters.Add(Designation);

            SqlParameter Training = new SqlParameter();
            Training.SqlDbType = SqlDbType.VarChar;
            Training.Value = ddlTraining.SelectedItem.ToString();
            Training.ParameterName = "@Intro_Training_Required";
            cmd.Parameters.Add(Training);

            SqlParameter UpdateEmp = new SqlParameter();
            UpdateEmp.SqlDbType = SqlDbType.VarChar;
            UpdateEmp.Value = txtUpdateCode.Text.Trim();
            UpdateEmp.ParameterName = "@Update_Emp_Name";
            cmd.Parameters.Add(UpdateEmp);

            SqlParameter MinProd = new SqlParameter();
            MinProd.SqlDbType = SqlDbType.VarChar;
            MinProd.Value = txtMinProd.Text.Trim();
            MinProd.ParameterName = "@Min_Productivity";
            cmd.Parameters.Add(MinProd);

            SqlParameter Remark = new SqlParameter();
            Remark.SqlDbType = SqlDbType.NVarChar;
            Remark.Value = txtRemark.Text.Trim();
            Remark.ParameterName = "@Remark";
            cmd.Parameters.Add(Remark);

            sqlcon.Open();

            int RowEffected = 0;
            RowEffected = cmd.ExecuteNonQuery();

            sqlcon.Close();

            if (RowEffected > 0)
            {
                pnlMsg.Visible = true;
                lblMsg.Text = "Record Save Successfully.";
                lblUpdate.Text = "Record Removed Successfully.";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillGridUpdate();
    }

    protected void FillGridUpdate()
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandText = "Get_OJT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;

            SqlParameter EmpSearch = new SqlParameter();
            EmpSearch.SqlDbType = SqlDbType.VarChar;
            EmpSearch.Value = txtSearchEmpUpdate.Text.Trim();
            EmpSearch.ParameterName = "@Emp_Code";
            cmd.Parameters.Add(EmpSearch);

            SqlParameter ClusterID = new SqlParameter();
            ClusterID.SqlDbType = SqlDbType.VarChar;
            ClusterID.Value = ddlclustername1.SelectedValue.Trim();
            ClusterID.ParameterName = "@Cluster_ID";
            cmd.Parameters.Add(ClusterID);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            sqlcon.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                GridSearchUpdate.DataSource = dt;
                GridSearchUpdate.DataBind();

                pnlSearchUpdate.Visible = true;
            }
            else
            {
                lblMsg.Text = "Records Not Found...!!!";

                GridSearchUpdate.DataSource = null;
                GridSearchUpdate.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void GridSearchUpdate_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridSearchUpdate.PageIndex = e.NewEditIndex;
    }

    protected void GridSearchUpdate_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblMsg.Text = "";
        lblUpdate.Text = "";
        for (int i = 0; i <= GridSearchUpdate.Rows.Count - 1; i++)
        {
            string EMPCode = e.CommandArgument.ToString();
            HDNEmpCode1.Value = GridSearchUpdate.Rows[i].Cells[1].Text.Trim();

            if (e.CommandName == "Edit")
            {
                if (EMPCode == HDNEmpCode1.Value)
                {
                    txtEmpCode.Text = GridSearchUpdate.Rows[i].Cells[1].Text.Trim();
                    txtEmpName.Text = GridSearchUpdate.Rows[i].Cells[2].Text.Trim();
                    txtCentre.Text = GridSearchUpdate.Rows[i].Cells[3].Text.Trim();
                    txtSubCentre.Text = GridSearchUpdate.Rows[i].Cells[4].Text.Trim();
                    txtDOJ.Text = GridSearchUpdate.Rows[i].Cells[5].Text.Trim();
                    txtEmpType.Text = GridSearchUpdate.Rows[i].Cells[6].Text.Trim();
                    txtActivity.Text = GridSearchUpdate.Rows[i].Cells[7].Text.Trim();
                    txtDepartment.Text = GridSearchUpdate.Rows[i].Cells[8].Text.Trim();
                    txtDesignation.Text = GridSearchUpdate.Rows[i].Cells[9].Text.Trim();
                    txtUpdateCode.Text = GridSearchUpdate.Rows[i].Cells[11].Text.Trim();
                    txtMinProd.Text = GridSearchUpdate.Rows[i].Cells[12].Text.Trim();

                    HDNID.Value = HDNEmpCode1.Value;
                }
                lblMsg.Text = "";
                pnlMsg.Visible = true;
                pnlCategory.Visible = false;
                pnlSearchUpdate.Visible = false;
                pnlSearchMaster.Visible = false;
                pnlData.Visible = true;
                //NEW
                pnlBackupSearch.Visible = false;
                pnlBackupSave.Visible = false;
            }
        }
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        Save();
        lblMsg.Visible = false;
        lblUpdate.Visible = true;

        ClearControls();

        pnlCategory.Visible = true;
        pnlSearchMaster.Visible = false;
        pnlData.Visible = false;
        pnlSearchUpdate.Visible = false;
        //NEW
        pnlBackupSearch.Visible = false;
        pnlBackupSave.Visible = false;
    }

    //NEW
    protected void btnCancel3_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void btnCancel4_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void Get_ClusterList2()
    {
        try
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_ClusterMaster";
            sqlcmd.CommandTimeout = 0;

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;

            sqlcon.Open();

            DataTable dt = new DataTable();
            sqlda.Fill(dt);

            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                ddlclustername2.DataTextField = "CLUSTER_NAME";
                ddlclustername2.DataValueField = "CLUSTER_ID";

                ddlclustername2.DataSource = dt;
                ddlclustername2.DataBind();

                ddlclustername2.Items.Insert(0, new ListItem("--SELECT--", "0"));
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void btnSearch2_Click(object sender, EventArgs e)
    {
        FillGridBackUp();
    }

    protected void FillGridBackUp()
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandText = "Get_BackUp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;

            SqlParameter EmpSearch = new SqlParameter();
            EmpSearch.SqlDbType = SqlDbType.VarChar;
            EmpSearch.Value = txtUpdateEmp.Text.Trim();
            EmpSearch.ParameterName = "@Emp_Code";
            cmd.Parameters.Add(EmpSearch);

            SqlParameter ClusterID = new SqlParameter();
            ClusterID.SqlDbType = SqlDbType.VarChar;
            ClusterID.Value = ddlclustername2.SelectedValue.Trim();
            ClusterID.ParameterName = "@Cluster_ID";
            cmd.Parameters.Add(ClusterID);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            sqlcon.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                GridBackUp.DataSource = dt;
                GridBackUp.DataBind();

                pnlBackupSearch.Visible = true;
            }
            else
            {
                lblMsg.Text = "Records Not Found...!!!";

                GridBackUp.DataSource = null;
                GridBackUp.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void GridBackUp_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridBackUp.PageIndex = e.NewEditIndex;
    }

    protected void GridBackUp_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblMsg.Text = "";
        lblUpdate.Text = "";

        for (int i = 0; i <= GridBackUp.Rows.Count - 1; i++)
        {
            string EMPCode = e.CommandArgument.ToString();
            HdnUA.Value = GridBackUp.Rows[i].Cells[1].Text.Trim();

            if (e.CommandName == "Edit")
            {
                if (EMPCode == HdnUA.Value)
                {
                    txtUpdate_EmpCode.Text = GridBackUp.Rows[i].Cells[1].Text.Trim();
                    txtBackUp_EmpCode.Text = GridBackUp.Rows[i].Cells[3].Text.Trim();

                    HdnUA_ID.Value = HdnUA.Value;
                }
                lblMsg.Text = "";
                lblUpdate.Text = "";
                pnlMsg.Visible = true;
                pnlCategory.Visible = false;
                pnlSearchUpdate.Visible = false;
                pnlSearchMaster.Visible = false;
                pnlData.Visible = false;
                pnlBackupSearch.Visible = false;
                pnlBackupSave.Visible = true;
            }
        }
    }

    protected void btnSaveBackUp_Click(object sender, EventArgs e)
    {
        SaveBackUp();

        lblMsg.Visible = true;
        lblUpdate.Visible = false;

        ClearControls();

        pnlMsg.Visible = true;
        pnlCategory.Visible = true;
        pnlSearchMaster.Visible = false;
        pnlData.Visible = false;
        pnlSearchUpdate.Visible = false;
        pnlBackupSearch.Visible = false;
        pnlBackupSave.Visible = false;
    }

    protected void SaveBackUp()
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandText = "Insert_BackUp";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;

            SqlParameter Cluster = new SqlParameter();
            Cluster.SqlDbType = SqlDbType.VarChar;
            Cluster.Value = ddlclustername2.SelectedValue.Trim();
            Cluster.ParameterName = "@Cluster";
            cmd.Parameters.Add(Cluster);

            SqlParameter Update_EmpCode = new SqlParameter();
            Update_EmpCode.SqlDbType = SqlDbType.VarChar;
            Update_EmpCode.Value = txtUpdate_EmpCode.Text.Trim();
            Update_EmpCode.ParameterName = "@Update_EmpCode";
            cmd.Parameters.Add(Update_EmpCode);

            SqlParameter BackUp_EmpCode = new SqlParameter();
            BackUp_EmpCode.SqlDbType = SqlDbType.VarChar;
            BackUp_EmpCode.Value = txtBackUp_EmpCode.Text.Trim();
            BackUp_EmpCode.ParameterName = "@BackUp_EmpCode";
            cmd.Parameters.Add(BackUp_EmpCode);

            SqlParameter AddBy = new SqlParameter();
            AddBy.SqlDbType = SqlDbType.VarChar;
            AddBy.Value = Session["UserID"].ToString().Trim();
            AddBy.ParameterName = "@AddBy";
            cmd.Parameters.Add(AddBy);

            sqlcon.Open();

            int RowEffected = 0;
            RowEffected = cmd.ExecuteNonQuery();

            sqlcon.Close();

            if (RowEffected > 0)
            {
                lblMsg.Text = "Record Save Successfully.";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }


}
