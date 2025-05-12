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

public partial class CPA_PD_Case_Revist : System.Web.UI.Page
{
    CCommon objConn = new CCommon();
    SqlConnection sqlcon;
    string strproc;

    protected void Page_Load(object sender, EventArgs e)
    {
        sqlcon = new SqlConnection(objConn.AppConnectionString);

        if (!IsPostBack)
        {
            validate();
            Get_FEList();
            Get_DATA();
        }
    }

    protected void validate()
    {
        btnsearch.Attributes.Add("onclick", "javascript:return validate();");
       // btnReopen.Attributes.Add("onclick", "javascript:return validate();");
    }

    protected void clear()
    {
        txtcase_id.Text = "";
        //txtappname.Text = "";
    }


    private void Get_FEList()
    {
        try
        {
            sqlcon.Open();

            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = sqlcon;
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd3.CommandText = "sp_pd_FEdata12_new";
            cmd3.CommandTimeout = 0;

            //if (Hdnmaster.Value == "2")
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
                ddlFE.DataTextField = "FULLNAME";
                ddlFE.DataValueField = "Emp_id";

                ddlFE.DataSource = dt;
                ddlFE.DataBind();

                ddlFE.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlFE.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }


    protected void Gridsearch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        lblMessage.Text = "";
        hdnCaseID.Value = "";
        hdnID.Value = "";

        for (int i = 0; i <= Gridsearch.Rows.Count - 1; i++)
        {
            string caseID = e.CommandArgument.ToString();
            hdnCaseID.Value = Gridsearch.Rows[i].Cells[1].Text.ToString();

            if (e.CommandName == "Edit")
            {
                if (caseID == hdnCaseID.Value)
                {
                    txtcase_id.Text = Gridsearch.Rows[i].Cells[1].Text.Trim();
                    //txtcusname.Text = Gridsearch.Rows[i].Cells[2].Text.Trim();

                    //HdnCluster.Value = Gridsearch.Rows[i].Cells[10].Text.Trim();
                    //hdncentre.Value = Gridsearch.Rows[i].Cells[11].Text.Trim();







                    hdnID.Value = hdnCaseID.Value;
                }
                lblMessage.Text = "";
                lblMessage.Visible = false;
                Gridsearch.Visible = false;
                //pnlData.Visible = true;
                //pnlStatus.Visible = true;
            }
        }
    }

    protected void Gridsearch_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Gridsearch.PageIndex = e.NewEditIndex;
    }







    private void Get_DATA()
    {

        try
        {


            sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PD_Get_FEASSIGN_DATA";
            cmd.CommandTimeout = 0;


            //SqlParameter case_id = new SqlParameter();
            //case_id.SqlDbType = SqlDbType.VarChar;
            //case_id.Value = txtcase_id.Text.ToString();
            //case_id.ParameterName = "@case_id";
            //cmd.Parameters.Add(case_id);


            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            da.Fill(dt);


            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                lblMessage.Text = "Total Count : " + dt.Rows.Count;
                Gridsearch.DataSource = dt;
                Gridsearch.DataBind();

                //NEW
                //txtPickUpDate.Text = dt.Rows[0]["PickUpDate"].ToString();
                // txtChequeDate.Text = dt.Rows[0]["ChequeDate"].ToString();
                // txtChequeNo.Text =   dt.Rows[0]["ChequeNo"].ToString();
                //txtChequeAmount.Text= dt.Rows[0]["ChequeAmount"].ToString();
                // txtBankName.Text =   dt.Rows[0]["BankName"].ToString();
                // txtBankBranch.Text = dt.Rows[0]["BankBranch"].ToString();
                //END NEW
            }
            else
            {
                lblMessage.Text = "No Record Found.";

                Gridsearch.DataSource = null;
                Gridsearch.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

       


    }



    protected void btnsearch_Click(object sender, EventArgs e)
    {
        Get_DATA();
       
    }


    protected void btnReAssign_Click(object sender, EventArgs e)
    {
        try
        {

            sqlcon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Insert_FE_ReAssignTo_Histroy_PD";
            cmd.CommandTimeout = 0;

            SqlParameter Case_id = new SqlParameter();
            Case_id.SqlDbType = SqlDbType.VarChar;
            Case_id.Value = txtcase_id.Text.ToString();
            Case_id.ParameterName = "@Case_id";
            cmd.Parameters.Add(Case_id);


            SqlParameter fe_id = new SqlParameter();
            fe_id.SqlDbType = SqlDbType.VarChar;
            fe_id.Value = ddlFE.SelectedValue.ToString();
            fe_id.ParameterName ="@FE_ID";
            cmd.Parameters.Add(fe_id);




            SqlParameter MODIFY_BY = new SqlParameter();
            MODIFY_BY.SqlDbType = SqlDbType.VarChar;
            MODIFY_BY.Value = Session["UserID"].ToString().Trim();
            MODIFY_BY.ParameterName = "@AssignBy";
            cmd.Parameters.Add(MODIFY_BY);




            int RowEffected = 0;
            RowEffected = cmd.ExecuteNonQuery();
            sqlcon.Close();

            if (RowEffected > 0)
            {
                lblMessage.Visible = true;
                //lblSave.Visible = true;
                lblMessage.Text = "Record Save Successfully.";

              
            }
           

        }
        catch (Exception ex)
        {
            lblMessage.Text = "Error: " + ex.Message;
        }


    }

}
