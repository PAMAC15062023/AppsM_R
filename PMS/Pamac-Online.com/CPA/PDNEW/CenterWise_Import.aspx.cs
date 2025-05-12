using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.IO;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class CPA_PD_CenterWise_Import : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
          
        {
            string ClusterId,ClientId;
            ClusterId = Session["ClusterID"].ToString();
            ClientId=Session["ClientID"].ToString();
            Get_ClusterID_Details();
           //--For Assignment..
            Get_AllClusterForAllotment();
            Register_Javascript();

        }
    }

    private void Register_Javascript()
    {
         
        btnSearch.Attributes.Add("onclick", "javascript:return Validate_Search();");
        btnAssignment.Attributes.Add("onclick", "javascript:return Validate_Assignment();");
        
      

    }

    private void Get_ClusterID_Details()
    {
        try
        {
            CCommon objConn = new CCommon();
            SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "ClusterName";

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlcon.Close();

            ddlCluster.DataTextField = "CLUSTER_NAME";
            ddlCluster.DataValueField = "CLUSTER_ID";

            ddlCluster.DataSource = dt;
            ddlCluster.DataBind();

            ddlCluster.Items.Insert(0, "--All--");
            ddlCluster.SelectedIndex = 0;
            ddlCluster.SelectedValue = "0";

        }
        catch(Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;

        }
    }
    
    private void Get_AllClusterForAllotment()
    {
        try
        {
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "ClusterName";

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlcon.Close();

            ddlAllocatedCluster.DataTextField = "CLUSTER_NAME";
            ddlAllocatedCluster.DataValueField = "CLUSTER_ID";

            ddlAllocatedCluster.DataSource = dt;
            ddlAllocatedCluster.DataBind();

            ddlAllocatedCluster.Items.Insert(0, "--All--");
            ddlAllocatedCluster.SelectedIndex = 0;
         
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;

        }
    }

    private void Get_AllCentreForAllotment()
    {
        try
        {
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_CentreName";

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            int intClusterID = 0;
            if (ddlAllocatedCluster.SelectedIndex != 0)
            {
                intClusterID = Convert.ToInt32(ddlAllocatedCluster.SelectedItem.Value);

            }

            SqlParameter ClusterID = new SqlParameter();
            ClusterID.SqlDbType = SqlDbType.Int;
            ClusterID.Value =intClusterID;
            ClusterID.ParameterName = "@ClusterID";
            sqlCom.Parameters.Add(ClusterID);

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlcon.Close();

            ddlAllocatedCentre.DataTextField = "CENTRE_NAME";
            ddlAllocatedCentre.DataValueField = "CENTRE_ID";

            ddlAllocatedCentre.DataSource = dt;
            ddlAllocatedCentre.DataBind();

            ddlAllocatedCentre.Items.Insert(0, "--Select--");
            ddlAllocatedCentre.SelectedIndex = 0;

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;

        }

    }
    
    protected void btnAssignment_Click(object sender, EventArgs e)
    {
        try
        {
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Insert_CPA_Case_Details_Ceterwise";

            SqlParameter CaseIDList = new SqlParameter();
            CaseIDList.SqlDbType = SqlDbType.VarChar;
            CaseIDList.Value = Get_For_CaseIDlist();
            CaseIDList.ParameterName = "@CaseIDList";
            sqlCom.Parameters.Add(CaseIDList);

            SqlParameter ClientID = new SqlParameter();
            ClientID.SqlDbType = SqlDbType.VarChar;
            ClientID.Value = Session["ClientID"].ToString();
            ClientID.ParameterName = "@Client_ID";
            sqlCom.Parameters.Add(ClientID);


            int pClusterID = 0;

            if (ddlAllocatedCluster.SelectedIndex != 0)
            {
                pClusterID = Convert.ToInt32(ddlAllocatedCluster.SelectedItem.Value);

            }

            SqlParameter ClusterID = new SqlParameter();
            ClusterID.SqlDbType = SqlDbType.Int;
            ClusterID.Value = pClusterID;
            ClusterID.ParameterName = "@ClusterID";
            sqlCom.Parameters.Add(ClusterID);


            int pCentreID = 0;
            if (ddlAllocatedCentre.SelectedIndex != 0)
            {
                pCentreID = Convert.ToInt32(ddlAllocatedCentre.SelectedItem.Value);

            }

            SqlParameter CentreID = new SqlParameter();
            CentreID.SqlDbType = SqlDbType.Int;
            CentreID.Value = pCentreID;//Session["ClientID"].ToString();
            CentreID.ParameterName = "@CentreID";
            sqlCom.Parameters.Add(CentreID);
               
            SqlParameter AddBy = new SqlParameter();
            AddBy.SqlDbType = SqlDbType.VarChar;
            AddBy.Value = Session["UserID"].ToString();
            AddBy.ParameterName = "@AddBy";
            sqlCom.Parameters.Add(AddBy);

            int RowFCheckBoxEffetced = sqlCom.ExecuteNonQuery();

            if (RowFCheckBoxEffetced > 0)
            {

                lblMessage.Text = "Record Updated Successfully!";

            }
            else
            {
                lblMessage.Text = "Error Occured!";
            }


           

        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }


    }
    
    private string Get_For_CaseIDlist()
    {
        string returnValue = "";

        for (int i = 0; i < gvImportedData.Rows.Count; i++)
        {
            CheckBox chkCaseId = (CheckBox)gvImportedData.Rows[i].Cells[0].FindControl("chkCaseId");
            if (chkCaseId.Checked == true)
            {
                returnValue = returnValue + gvImportedData.Rows[i].Cells[1].Text+ "^";

                

            }
            
        }
        return returnValue;
    }

    protected void ddlCluster_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_CentreName";

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            int intClusterID = 0;
            if (ddlCluster.SelectedIndex!=0)
            {
                intClusterID = Convert.ToInt32(ddlCluster.SelectedItem.Value);
               
            }

            SqlParameter ClusterID = new SqlParameter();
            ClusterID.SqlDbType = SqlDbType.Int;
            ClusterID.Value = intClusterID;
            ClusterID.ParameterName = "@ClusterID";
            sqlCom.Parameters.Add(ClusterID);

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlcon.Close();

            ddlCentre.DataTextField = "CENTRE_NAME";
            ddlCentre.DataValueField = "CENTRE_ID";

            ddlCentre.DataSource = dt;
            ddlCentre.DataBind();

            ddlCentre.Items.Insert(0, "--Select--");
            ddlCentre.SelectedIndex = 0;

           }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;

        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

            sqlcon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlcon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_CPV_ImportDataFromHO";
                    
            SqlParameter FromDate = new SqlParameter();
            FromDate.SqlDbType = SqlDbType.VarChar;
            FromDate.Value = txtFromDate.Text.Trim();
            FromDate.ParameterName = "@FromDate";
            sqlCom.Parameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.SqlDbType = SqlDbType.VarChar;
            ToDate.Value = txtToDate.Text.Trim();
            ToDate.ParameterName = "@ToDate";
            sqlCom.Parameters.Add(ToDate);
            
            SqlParameter ClientID = new SqlParameter();
            ClientID.SqlDbType = SqlDbType.VarChar;
            ClientID.Value = Session["ClientID"].ToString();
            ClientID.ParameterName = "@ClientID";
            sqlCom.Parameters.Add(ClientID);


            int pClusterID = 0;

            if (ddlCluster.SelectedIndex != 0)
            {
                pClusterID = Convert.ToInt32(ddlCluster.SelectedItem.Value);

            }

            SqlParameter ClusterID = new SqlParameter();
            ClusterID.SqlDbType = SqlDbType.Int;
            ClusterID.Value = pClusterID;
            ClusterID.ParameterName = "@ClusterID";
            sqlCom.Parameters.Add(ClusterID);


            int pCentreID = 0;
            if (ddlCentre.SelectedIndex != 0)
            {
                pCentreID = Convert.ToInt32(ddlCentre.SelectedItem.Value);
                
            }

            SqlParameter CentreID = new SqlParameter();
            CentreID.SqlDbType = SqlDbType.Int;
            CentreID.Value = pCentreID;//Session["ClientID"].ToString();
            CentreID.ParameterName = "@CentreID";
            sqlCom.Parameters.Add(CentreID);
            

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlcon.Close();


            gvImportedData.DataSource = dt;
            gvImportedData.DataBind();

            if (dt.Rows.Count > 0)
            {
                lblMessage.Text = "Record Found-" + dt.Rows.Count;
            }
            else
            {
                lblMessage.Text = "No Record Found";
            }
            
        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)

    {
        txtToDate.Text="";
        txtFromDate.Text="";
        ddlCluster.SelectedIndex = 0;
        ddlCentre.SelectedIndex = 0;
        ddlAllocatedCluster.SelectedIndex = 0;
        ddlAllocatedCentre.SelectedIndex = 0;
        
    }

    protected void ddlAllocatedCluster_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_AllCentreForAllotment();

    }
}
