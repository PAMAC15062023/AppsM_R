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

public partial class DCR_DCR_CaseAssign : System.Web.UI.Page
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;
    string clusterID;

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);

        if (!IsPostBack)
        {
            Get_verificationType();
            Get_ClusterList();
            validate();
        }

        string strRole = Session["RoleID"].ToString();
        string[] strRole1 = strRole.Split(',');

        foreach (string str in strRole1)
        {
            if (str == "2")
            {
                Hdnmaster.Value = "2";
            }
        }
    }

    protected void fillgrid()
    {
        try
        {
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = ddlCase.SelectedValue.ToString();
            cmd.CommandTimeout = 0;

            if (Hdnmaster.Value == "2")
            {
                SqlParameter center_name = new SqlParameter();
                center_name.SqlDbType = SqlDbType.VarChar;
                center_name.Value = ddlcenter.SelectedValue.ToString();
                center_name.ParameterName = "@Centre_Name";
                cmd.Parameters.Add(center_name);

                SqlParameter Cluster_id = new SqlParameter();
                Cluster_id.SqlDbType = SqlDbType.VarChar;
                Cluster_id.Value = ddlclustername.SelectedValue.ToString();
                Cluster_id.ParameterName = "@Cluster_id";
                cmd.Parameters.Add(Cluster_id);


                SqlParameter Client_id = new SqlParameter();
                Client_id.SqlDbType = SqlDbType.VarChar;
                Client_id.Value = Session["ClientID"].ToString();
                Client_id.ParameterName = "@client_id";
                cmd.Parameters.Add(Client_id);
            }
            else
            {
                SqlParameter Cluster_id = new SqlParameter();
                Cluster_id.SqlDbType = SqlDbType.VarChar;
                Cluster_id.Value = Session["Clusterid"].ToString();
                Cluster_id.ParameterName = "@Cluster_id";
                cmd.Parameters.Add(Cluster_id);

                SqlParameter center_name = new SqlParameter();
                center_name.SqlDbType = SqlDbType.VarChar;
                center_name.Value = Session["Centreid"].ToString();
                center_name.ParameterName = "@Centre_Name";
                cmd.Parameters.Add(center_name);


                SqlParameter Client_id = new SqlParameter();
                Client_id.SqlDbType = SqlDbType.VarChar;
                Client_id.Value = Session["ClientID"].ToString();
                Client_id.ParameterName = "@client_id";
                cmd.Parameters.Add(Client_id);
            }

            SqlParameter verificationtype = new SqlParameter();
            verificationtype.SqlDbType = SqlDbType.VarChar;
            verificationtype.Value = ddlverificationtype.SelectedValue.ToString();
            verificationtype.ParameterName = "@Verification_type_code";
            cmd.Parameters.Add(verificationtype);



            SqlParameter FromDate = new SqlParameter();
            FromDate.SqlDbType = SqlDbType.VarChar;
            FromDate.Value = strDate(txtFromDate.Text.Trim());
            FromDate.ParameterName = "@FromDate";
            cmd.Parameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.SqlDbType = SqlDbType.VarChar;
            ToDate.Value = strDate(txtToDate.Text.Trim());
            ToDate.ParameterName = "@ToDate";
            cmd.Parameters.Add(ToDate);







            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = cmd;

            DataTable dt = new DataTable();
            sqlda1.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                lblMsgXls.Text = "Total Count : " + dt.Rows.Count;

                Grvcasedata.DataSource = dt;
                Grvcasedata.DataBind();
            }
            else
            {
                lblMsgXls.Text = "No Records Found...!!!";

                Grvcasedata.DataSource = null;
                Grvcasedata.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMsgXls.Text = ex.Message;
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
        btnshowdata.Attributes.Add("onclick", "javascript:return validate1();");
        btnAssign.Attributes.Add("onclick", "javascript:return validateall();");
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
            lblMsgXls.Text = ex.Message;
        }
    }

    private void Get_ClusterList()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
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

    public void FillCentre()
    {
        try
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "DCR_cluster_Assign";
            sqlcmd.CommandTimeout = 0;

            if (Hdnmaster.Value == "2")
            {
                SqlParameter Cluster_id = new SqlParameter();
                Cluster_id.SqlDbType = SqlDbType.VarChar;
                Cluster_id.Value = ddlclustername.SelectedValue.ToString();
                Cluster_id.ParameterName = "@Cluster_id";
                sqlcmd.Parameters.Add(Cluster_id);
            }
            else
            {
                SqlParameter Cluster_id = new SqlParameter();
                Cluster_id.SqlDbType = SqlDbType.VarChar;
                Cluster_id.Value = Session["Clusterid"].ToString();
                Cluster_id.ParameterName = "@Cluster_id";
                sqlcmd.Parameters.Add(Cluster_id);
            }

            SqlDataAdapter sqlda1 = new SqlDataAdapter();
            sqlda1.SelectCommand = sqlcmd;

            DataTable dt1 = new DataTable();
            sqlda1.Fill(dt1);

            sqlcon.Close();

            string clusterID = dt1.Rows[0]["cluster_id"].ToString();

            if (dt1.Rows.Count > 0)
            {
                ddlcenter.DataTextField = "Centre_Name";
                ddlcenter.DataValueField = "Centre_id";

                ddlcenter.DataSource = dt1;
                ddlcenter.DataBind();

                ddlcenter.Items.Insert(0, new ListItem("--ALL--", "A"));
                ddlcenter.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblMsgXls.Text = ex.Message;
        }
    }

    private void Get_FEList()
    {
        try
        {
            sqlcon.Open();

            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = sqlcon;
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd3.CommandText = "DCR_FE_NAME_DATA";
            cmd3.CommandTimeout = 0;

            if (Hdnmaster.Value == "2")
            {
                SqlParameter center_name = new SqlParameter();
                center_name.SqlDbType = SqlDbType.VarChar;
                center_name.Value = ddlcenter.SelectedValue.ToString();
                center_name.ParameterName = "@centre_id";
                cmd3.Parameters.Add(center_name);

                SqlParameter cluster_name = new SqlParameter();
                cluster_name.SqlDbType = SqlDbType.VarChar;
                cluster_name.Value = ddlclustername.SelectedValue.ToString();
                cluster_name.ParameterName = "@cluster_id";
                cmd3.Parameters.Add(cluster_name);
            }
            else
            {
                SqlParameter center_name = new SqlParameter();
                center_name.SqlDbType = SqlDbType.VarChar;
                center_name.Value = Session["Centreid"].ToString();
                center_name.ParameterName = "@centre_id";
                cmd3.Parameters.Add(center_name);

                SqlParameter cluster_name = new SqlParameter();
                cluster_name.SqlDbType = SqlDbType.VarChar;
                cluster_name.Value = Session["ClusterID"].ToString();
                cluster_name.ParameterName = "@cluster_id";
                cmd3.Parameters.Add(cluster_name);
            }

            SqlDataAdapter sqlda2 = new SqlDataAdapter();
            sqlda2.SelectCommand = cmd3;

            DataTable dt = new DataTable();
            sqlda2.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                ddlFENAME.DataTextField = "FULLNAME";
                ddlFENAME.DataValueField = "Emp_id";

                ddlFENAME.DataSource = dt;
                ddlFENAME.DataBind();

                ddlFENAME.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlFENAME.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblMsgXls.Text = ex.Message;
        }
    }

    private void Get_talecaller()
    {
        try
        {
            sqlcon.Open();
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = sqlcon;
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd3.CommandText = "TELECALLER_DCR_DATA_ASSIGN";
            cmd3.CommandTimeout = 0;

            //if (Hdnmaster.Value == "1")
            //{
            //    SqlParameter center_name = new SqlParameter();
            //    center_name.SqlDbType = SqlDbType.VarChar;
            //    center_name.Value = ddlcenter.SelectedValue.ToString();
            //    center_name.ParameterName = "@centre_id";
            //    cmd3.Parameters.Add(center_name);

            //    SqlParameter cluster_name = new SqlParameter();
            //    cluster_name.SqlDbType = SqlDbType.VarChar;
            //    cluster_name.Value = ddlclustername.SelectedValue.ToString();
            //    cluster_name.ParameterName = "@cluster_id";
            //    cmd3.Parameters.Add(cluster_name);
            //}
            //else
            //{
            //    SqlParameter center_name = new SqlParameter();
            //    center_name.SqlDbType = SqlDbType.VarChar;
            //    center_name.Value = Session["Centreid"].ToString();
            //    center_name.ParameterName = "@centre_id";
            //    cmd3.Parameters.Add(center_name);

            //    SqlParameter cluster_name = new SqlParameter();
            //    cluster_name.SqlDbType = SqlDbType.VarChar;
            //    cluster_name.Value = Session["ClusterID"].ToString();
            //    cluster_name.ParameterName = "@cluster_id";
            //    cmd3.Parameters.Add(cluster_name);
            //}

            SqlDataAdapter sqlda2 = new SqlDataAdapter();
            sqlda2.SelectCommand = cmd3;

            DataTable dt = new DataTable();
            sqlda2.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                ddlFENAME.DataTextField = "fullname";
                ddlFENAME.DataValueField = "emp_id";

                ddlFENAME.DataSource = dt;
                ddlFENAME.DataBind();

                ddlFENAME.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlFENAME.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblMsgXls.Text = ex.Message;
        }
    }

    protected void btnshowdata_Click(object sender, EventArgs e)
    {
        Search();
    }

    private void Search()
    {
        if (ddlCase.SelectedIndex == 1)
        {
            Get_FEList();
        }
        else
        {
            Get_talecaller();
        }

        fillgrid();
    }

    protected void btnAssign_Click(object sender, EventArgs e)
    {
        if (ddlCase.SelectedIndex == 1)
        {
            Get_feassigndata();
        }
        else
        {
            Get_teleassigndata();
        }
        fillgrid();
    }

    private void Get_teleassigndata()
    {
        try
        {
            HiddenField hdnCaseID;
            CheckBox chkCaseID;
            String strSelectedCaseID = "";
            foreach (GridViewRow row in Grvcasedata.Rows)
            {
                hdnCaseID = (HiddenField)row.FindControl("hidCaseId");
                chkCaseID = (CheckBox)row.FindControl("chkCaseId");
                if (chkCaseID.Checked)
                    strSelectedCaseID += "'" + hdnCaseID.Value + "'" + ",";
            }
            if (strSelectedCaseID != "")
            {
                CFEAssignment oFE = new CFEAssignment();
                oFE.arrCaseID = (strSelectedCaseID.TrimEnd(',')).Split(',');
                oFE.AssignedTo = ddlFENAME.SelectedValue.ToString();
                oFE.AssignedBy = Session["Userid"].ToString();
                oFE.VerificationType = ddlverificationtype.SelectedValue.ToString();

                //string clusterID = ddlclustername.SelectedValue.ToString();

                if (Hdnmaster.Value == "2")
                {
                    clusterID = ddlclustername.SelectedValue.ToString();
                }
                else
                {
                    clusterID = Session["clusterID"].ToString();
                }

                oFE.InsertTcCaseMapping_DCR(clusterID);

                lblMsgXls.Text = "Telecaller Assigned Successfully";
            }
            else
                lblMsgXls.Text = "Please Select Case to Assign.";
        }
        catch (Exception exp)
        {
            lblMsgXls.Text = "Error: Telecaller Assignment Failed." + exp.Message;
        }
    }

    private void Get_feassigndata()
    {
        try
        {
            HiddenField hdnCaseID;
            CheckBox chkCaseID;
            String strSelectedCaseID = "";
            foreach (GridViewRow row in Grvcasedata.Rows)
            {
                hdnCaseID = (HiddenField)row.FindControl("hidCaseId");
                chkCaseID = (CheckBox)row.FindControl("chkCaseId");
                if (chkCaseID.Checked)
                    strSelectedCaseID += "'" + hdnCaseID.Value + "'" + ",";
            }
            if (strSelectedCaseID != "")
            {
                CFEAssignment oFE = new CFEAssignment();
                oFE.arrCaseID = (strSelectedCaseID.TrimEnd(',')).Split(',');
                oFE.AssignedTo = ddlFENAME.SelectedValue.ToString();
                oFE.AssignedBy = Session["Userid"].ToString();
                oFE.VerificationType = ddlverificationtype.SelectedValue.ToString();

                if (Hdnmaster.Value == "2")
                {
                    clusterID = ddlclustername.SelectedValue.ToString();
                }
                else
                {
                    clusterID = Session["clusterID"].ToString();
                }

                oFE.InsertFeCaseMapping_DCR(clusterID);
                lblMsgXls.Text = "FE Assigned Successfully.";
            }
            else
                lblMsgXls.Text = "Please Select Case to Assign.";
        }
        catch (Exception exp)
        {
            lblMsgXls.Text = "Error: FE Assignment Failed." + exp.Message;
        }
    }

    protected void ddlclustername_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMsgXls.Text = "";
        FillCentre();
        Grvcasedata.DataSource = null;
        Grvcasedata.DataBind();
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

    protected void Grvcasedata_Sorting(object sender, GridViewSortEventArgs e)
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
        cmd.CommandText = ddlCase.SelectedValue.ToString();
        cmd.CommandTimeout = 0;

        if (Hdnmaster.Value == "2")
        {
            SqlParameter center_name = new SqlParameter();
            center_name.SqlDbType = SqlDbType.VarChar;
            center_name.Value = ddlcenter.SelectedValue.ToString();
            center_name.ParameterName = "@Centre_Name";
            cmd.Parameters.Add(center_name);

            SqlParameter Cluster_id = new SqlParameter();
            Cluster_id.SqlDbType = SqlDbType.VarChar;
            Cluster_id.Value = ddlclustername.SelectedValue.ToString();
            Cluster_id.ParameterName = "@Cluster_id";
            cmd.Parameters.Add(Cluster_id);
        }
        else
        {
            SqlParameter Cluster_id = new SqlParameter();
            Cluster_id.SqlDbType = SqlDbType.VarChar;
            Cluster_id.Value = Session["Clusterid"].ToString();
            Cluster_id.ParameterName = "@Cluster_id";
            cmd.Parameters.Add(Cluster_id);

            SqlParameter center_name = new SqlParameter();
            center_name.SqlDbType = SqlDbType.VarChar;
            center_name.Value = Session["Centreid"].ToString();
            center_name.ParameterName = "@Centre_Name";
            cmd.Parameters.Add(center_name);
        }

        SqlParameter verificationtype = new SqlParameter();
        verificationtype.SqlDbType = SqlDbType.VarChar;
        verificationtype.Value = ddlverificationtype.SelectedValue.ToString();
        verificationtype.ParameterName = "@Verification_type_code";
        cmd.Parameters.Add(verificationtype);

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataTable dt = new DataTable();
        da.Fill(dt);

        sqlcon.Close();

        dt.DefaultView.Sort = sortExpression + " " + direction;

        Grvcasedata.DataSource = dt;
        Grvcasedata.DataBind();
    }

   
}
