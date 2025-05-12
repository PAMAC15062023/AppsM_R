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


public partial class DCR_DCR_PickUp_Reconciliation : System.Web.UI.Page
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;
    string strproc;
    string filename_Attachment;

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);

        if (!IsPostBack)
        {
            Validation();
            Get_ClusterList();

            pnlMsg.Visible = true;
            pnlCluster.Visible = true;
            pnlGrid.Visible = false;
            pnlData.Visible = false;
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

    protected void Validation()
    {
        btnSave.Attributes.Add("onclick", "javascript:return Validate();");
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

    protected void ddlclustername_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        FillCentre();
        FillGrid();
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
            lblMsg.Text = ex.Message;
        }
    }

    protected void ddlcenter_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        pnlMsg.Visible = true;
        pnlCluster.Visible = true;
        pnlGrid.Visible = true;
        pnlData.Visible = false;

        hdnCaseID.Value = "";
        hdnID.Value = "";

        FillGrid();
        Response.Redirect("PickUp_Reconciliation.aspx");

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void FillGrid()
    {
        try
        {
            sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DCR_Get_Cheque_Reconciliation";
            cmd.CommandTimeout = 0;

            SqlParameter ClusterID = new SqlParameter();
            ClusterID.SqlDbType = SqlDbType.VarChar;
            ClusterID.Value = ddlclustername.SelectedValue.Trim();
            ClusterID.ParameterName = "@Cluster_ID";
            cmd.Parameters.Add(ClusterID);

            SqlParameter CentreID = new SqlParameter();
            CentreID.SqlDbType = SqlDbType.VarChar;
            CentreID.Value = ddlcenter.SelectedValue.Trim();
            CentreID.ParameterName = "@Centre_ID";
            cmd.Parameters.Add(CentreID);

            SqlParameter ClientID = new SqlParameter();
            ClientID.SqlDbType = SqlDbType.VarChar;
            ClientID.Value = Session["ClientID"].ToString().Trim();
            ClientID.ParameterName = "@Client_ID";
            cmd.Parameters.Add(ClientID);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);

            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                lblMsg.Text = "Total Count : " + dt.Rows.Count;
                grdGrid.DataSource = dt;
                grdGrid.DataBind();

                //HdnCluster.Value = dt.Rows[0]["Cluster_ID"].ToString();
                //hdncentre.Value = dt.Rows[0]["Centre_ID"].ToString();
                //HdnIMAGE.Value = dt.Rows[0]["Cheque_ScanImage"].ToString();

                pnlCluster.Visible = true;
                pnlGrid.Visible = true; ;
                pnlData.Visible = false;

                grdGrid.Columns[16].Visible = false;
                grdGrid.Columns[17].Visible = false;
                grdGrid.Columns[18].Visible = false;
            }
            else
            {
                lblMsg.Text = "No Record Found.";
                grdGrid.DataSource = null;
                grdGrid.DataBind();
                pnlData.Visible = false;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void grdGrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdGrid.PageIndex = e.NewEditIndex;
    }

    protected void grdGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblMsg.Text = "";
        hdnCaseID.Value = "";
        hdnID.Value = "";

        for (int i = 0; i <= grdGrid.Rows.Count - 1; i++)
        {
            string caseID = e.CommandArgument.ToString();
            hdnCaseID.Value = grdGrid.Rows[i].Cells[1].Text.ToString();

            if (e.CommandName == "Edit")
            {
                if (caseID == hdnCaseID.Value)
                {
                    grdGrid.Columns[16].Visible = true;
                    grdGrid.Columns[17].Visible = true;
                    grdGrid.Columns[18].Visible = true;

                    txtCaseID.Text = grdGrid.Rows[i].Cells[1].Text.ToString();
                    txtVerificationType.Text = grdGrid.Rows[i].Cells[2].Text.ToString();
                    txtCentre.Text = grdGrid.Rows[i].Cells[3].Text.ToString();
                    txtName.Text = grdGrid.Rows[i].Cells[4].Text.ToString();
                    txtAddress.Text = grdGrid.Rows[i].Cells[5].Text.ToString();
                    txtContactNo.Text = grdGrid.Rows[i].Cells[6].Text.ToString();

                    txtPickUpDate.Text = grdGrid.Rows[i].Cells[9].Text.ToString();
                    txtChequeDate.Text = grdGrid.Rows[i].Cells[10].Text.ToString();
                    txtChequeNo.Text = grdGrid.Rows[i].Cells[11].Text.ToString();
                    txtChequeAmount.Text = grdGrid.Rows[i].Cells[12].Text.ToString();
                    txtBankName.Text = grdGrid.Rows[i].Cells[13].Text.ToString();
                    txtBankBranch.Text = grdGrid.Rows[i].Cells[14].Text.ToString();

                    hdnvery.Value = grdGrid.Rows[i].Cells[2].Text.ToString();
                    HdnCluster.Value = grdGrid.Rows[i].Cells[16].Text.Trim();
                    hdncentre.Value = grdGrid.Rows[i].Cells[17].Text.Trim();

                    string IMAGE = grdGrid.Rows[i].Cells[18].Text.ToString();
                    ImgCheque.ImageUrl = "https://www.pamaconline.com/DCR/DCR/UploadFile/" + IMAGE.ToString();

                    hdnID.Value = hdnCaseID.Value;
                }

                grdGrid.Columns[16].Visible = false;
                grdGrid.Columns[17].Visible = false;
                grdGrid.Columns[18].Visible = false;

                lblMsg.Text = "";
                pnlMsg.Visible = true;
                pnlCluster.Visible = false;
                pnlGrid.Visible = false;
                pnlData.Visible = true;
            }
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

    protected void grdGrid_Sorting(object sender, GridViewSortEventArgs e)
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
        cmd.CommandText = "DCR_Get_Cheque_Reconciliation";
        cmd.CommandTimeout = 0;

        SqlParameter ClusterID = new SqlParameter();
        ClusterID.SqlDbType = SqlDbType.VarChar;
        ClusterID.Value = ddlclustername.SelectedValue.Trim();
        ClusterID.ParameterName = "@Cluster_ID";
        cmd.Parameters.Add(ClusterID);

        SqlParameter CentreID = new SqlParameter();
        CentreID.SqlDbType = SqlDbType.VarChar;
        CentreID.Value = ddlcenter.SelectedValue.Trim();
        CentreID.ParameterName = "@Centre_ID";
        cmd.Parameters.Add(CentreID);

        SqlParameter ClientID = new SqlParameter();
        ClientID.SqlDbType = SqlDbType.VarChar;
        ClientID.Value = Session["ClientID"].ToString().Trim();
        ClientID.ParameterName = "@Client_ID";
        cmd.Parameters.Add(ClientID);

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataTable dt = new DataTable();
        da.Fill(dt);

        sqlcon.Close();

        dt.DefaultView.Sort = sortExpression + " " + direction;

        grdGrid.DataSource = dt;
        grdGrid.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (HdnCluster.Value == "1011")
            {
                strproc = "DCR_PickUp_ReConciliation_BVU";
            }
            else if (HdnCluster.Value == "1014")
            {
                strproc = "DCR_PickUp_ReConciliation_EAST";
            }
            else if (HdnCluster.Value == "1013")
            {
                strproc = "DCR_PickUp_ReConciliation_SOUTH";
            }
            else if (HdnCluster.Value == "1015")
            {
                strproc = "DCR_PickUp_ReConciliation_NORTH";
            }
            else if (HdnCluster.Value == "1018")
            {
                strproc = "DCR_PickUp_ReConciliation_BVU";
            }
            else
            {
                strproc = "DCR_PickUp_ReConciliation_WEST";
            }


            sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = strproc;
            cmd.CommandTimeout = 0;

            SqlParameter Cluster_id = new SqlParameter();
            Cluster_id.SqlDbType = SqlDbType.VarChar;
            Cluster_id.Value = HdnCluster.Value;
            Cluster_id.ParameterName = "@Cluster_id";
            cmd.Parameters.Add(Cluster_id);

            SqlParameter Centre_id = new SqlParameter();
            Centre_id.SqlDbType = SqlDbType.VarChar;
            Centre_id.Value = hdncentre.Value;
            Centre_id.ParameterName = "@Centre_id";
            cmd.Parameters.Add(Centre_id);

            SqlParameter CASEID = new SqlParameter();
            CASEID.SqlDbType = SqlDbType.VarChar;
            CASEID.Value = hdnID.Value;
            CASEID.ParameterName = "@Case_id";
            cmd.Parameters.Add(CASEID);

            SqlParameter Verification_Type = new SqlParameter();
            Verification_Type.SqlDbType = SqlDbType.VarChar;
            Verification_Type.Value = hdnvery.Value;
            Verification_Type.ParameterName = "@verification_type_id";
            cmd.Parameters.Add(Verification_Type);

            SqlParameter CLIENT_ID = new SqlParameter();
            CLIENT_ID.SqlDbType = SqlDbType.VarChar;
            CLIENT_ID.Value = Session["ClientID"].ToString();
            CLIENT_ID.ParameterName = "@CLIENT_ID";
            cmd.Parameters.Add(CLIENT_ID);

            SqlParameter MODIFY_BY = new SqlParameter();
            MODIFY_BY.SqlDbType = SqlDbType.VarChar;
            MODIFY_BY.Value = Session["UserID"].ToString().Trim();
            MODIFY_BY.ParameterName = "@MODIFY_BY";
            cmd.Parameters.Add(MODIFY_BY);

            SqlParameter CENTRE = new SqlParameter();
            CENTRE.SqlDbType = SqlDbType.VarChar;
            CENTRE.Value = txtCentre.Text.ToString().Trim();
            CENTRE.ParameterName = "@CENTRE_Name";
            cmd.Parameters.Add(CENTRE);

            SqlParameter NAME = new SqlParameter();
            NAME.SqlDbType = SqlDbType.NVarChar;
            NAME.Value = txtName.Text.ToString().Trim();
            NAME.ParameterName = "@CUST_FULLNAME";
            cmd.Parameters.Add(NAME);

            SqlParameter Address = new SqlParameter();
            Address.SqlDbType = SqlDbType.NVarChar;
            Address.Value = txtAddress.Text.ToString().Trim();
            Address.ParameterName = "@CUST_ADD_LINE_1";
            cmd.Parameters.Add(Address);

            SqlParameter ContactNo = new SqlParameter();
            ContactNo.SqlDbType = SqlDbType.NVarChar;
            ContactNo.Value = txtContactNo.Text.ToString().Trim();
            ContactNo.ParameterName = "@CUST_CONTACT_NO";
            cmd.Parameters.Add(ContactNo);

            SqlParameter PickUpDate = new SqlParameter();
            PickUpDate.SqlDbType = SqlDbType.DateTime;
            PickUpDate.Value = strDate(txtPickUpDate.Text.Trim());
            PickUpDate.ParameterName = "@PickUpDate";
            cmd.Parameters.Add(PickUpDate);

            SqlParameter ChequeDate = new SqlParameter();
            ChequeDate.SqlDbType = SqlDbType.DateTime;
            ChequeDate.Value = strDate(txtChequeDate.Text.Trim());
            ChequeDate.ParameterName = "@ChequeDate";
            cmd.Parameters.Add(ChequeDate);

            SqlParameter ChequeNo = new SqlParameter();
            ChequeNo.SqlDbType = SqlDbType.VarChar;
            ChequeNo.Value = txtChequeNo.Text.ToString().Trim();
            ChequeNo.ParameterName = "@ChequeNo";
            cmd.Parameters.Add(ChequeNo);

            SqlParameter ChequeAmount = new SqlParameter();
            ChequeAmount.SqlDbType = SqlDbType.NVarChar;
            ChequeAmount.Value = txtChequeAmount.Text.ToString().Trim();
            ChequeAmount.ParameterName = "@ChequeAmount";
            cmd.Parameters.Add(ChequeAmount);

            SqlParameter BankName = new SqlParameter();
            BankName.SqlDbType = SqlDbType.NVarChar;
            BankName.Value = txtBankName.Text.ToString().Trim();
            BankName.ParameterName = "@BankName";
            cmd.Parameters.Add(BankName);

            SqlParameter BankBranch = new SqlParameter();
            BankBranch.SqlDbType = SqlDbType.NVarChar;
            BankBranch.Value = txtBankBranch.Text.ToString().Trim();
            BankBranch.ParameterName = "@BankBranch";
            cmd.Parameters.Add(BankBranch);

            if (Cheque_ScanImage.FileName != "")
            {
                SqlParameter ScanImage = new SqlParameter();
                ScanImage.SqlDbType = SqlDbType.NVarChar;
                ScanImage.Value = UploadAttachment_OnServer();
                ScanImage.ParameterName = "@Cheque_ScanImage";
                cmd.Parameters.Add(ScanImage); 
                
                SqlParameter ChequeImageDate = new SqlParameter();
                ChequeImageDate.SqlDbType = SqlDbType.DateTime;
                ChequeImageDate.Value = System.DateTime.Now.ToString();
                ChequeImageDate.ParameterName = "@ChequeImageDate";
                cmd.Parameters.Add(ChequeImageDate);
            }
            else
            {
                SqlParameter ScanImage = new SqlParameter();
                ScanImage.SqlDbType = SqlDbType.NVarChar;
                ScanImage.Value = DBNull.Value;
                ScanImage.ParameterName = "@Cheque_ScanImage";
                cmd.Parameters.Add(ScanImage); 
                
                SqlParameter ChequeImageDate = new SqlParameter();
                ChequeImageDate.SqlDbType = SqlDbType.VarChar;
                ChequeImageDate.Value = DBNull.Value;
                ChequeImageDate.ParameterName = "@ChequeImageDate";
                cmd.Parameters.Add(ChequeImageDate);
            }


            int RowEffected = 0;
            RowEffected = cmd.ExecuteNonQuery();
            sqlcon.Close();

            if (RowEffected > 0)
            {
                lblMsg.Text = "Record Updated Successfully.";

                pnlMsg.Visible = true;
                pnlCluster.Visible = true;
                pnlGrid.Visible = true;
                pnlData.Visible = false;

                FillGrid();
                Response.Redirect("PickUp_Reconciliation.aspx");
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    private string UploadAttachment_OnServer()
    {
        try
        {
            string FileSavePath = "";
            if (Cheque_ScanImage.FileName != "")
            {
                string strPath = Server.MapPath("UploadFile/");

                strPath = strPath.Trim();
                filename_Attachment = Convert.ToString(DateTime.Now.ToString("yyyyMMddHHmmss")) + "-" + Convert.ToString(Cheque_ScanImage.FileName.Trim());
                filename_Attachment = Convert.ToString(Cheque_ScanImage.FileName.Trim());
                filename_Attachment = filename_Attachment.Replace(" ", "_");

                FileSavePath = strPath + Cheque_ScanImage.FileName;

                Cheque_ScanImage.SaveAs(FileSavePath);
            }
            return FileSavePath;
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            return "";
        }
    }




}
