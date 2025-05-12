using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class HR_HR_HR_OJT_InductionTrinForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Request.QueryString["CentreID"] != "" && Request.QueryString["CentreID"] != null && Request.QueryString["SubcentreID"] != "" && Request.QueryString["SubcentreID"] != null && Request.QueryString["ClusterID"] != "" && Request.QueryString["ClusterID"] != null)
            {
                hdfCentre.Value = Request.QueryString["CentreID"].ToString();
                hdfSubcentre.Value = Request.QueryString["SubcentreID"].ToString();
                hdfCluster.Value = Request.QueryString["ClusterID"].ToString();
            }
            if (Request.QueryString["CentreID"] != "" && Request.QueryString["CentreID"] != null && Request.QueryString["SubcentreID"] != "" && Request.QueryString["SubcentreID"] != null)
            {
                hdfCentre.Value = Request.QueryString["CentreID"].ToString();
                hdfSubcentre.Value = Request.QueryString["SubcentreID"].ToString();
            }
            if (Request.QueryString["SubcentreID"] != "" && Request.QueryString["SubcentreID"] != null)
            {
                hdfSubcentre.Value = Request.QueryString["SubcentreID"].ToString();
            }
            if (Request.QueryString["EMP_ID"] != "" && Request.QueryString["EMP_ID"] != null)
            {
                hdnEmpId.Value = Request.QueryString["EMP_ID"].ToString();
            }

            //GetInductionTrainerName();
            //GetQmsTrainerName();

          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_InductionTrainData";
            sqlcmd.CommandTimeout = 0;

            SqlParameter CentreID = new SqlParameter();
            CentreID.SqlDbType = SqlDbType.VarChar;
            CentreID.Value = hdfCentre.Value;
            CentreID.ParameterName = "@CentreID";
            sqlcmd.Parameters.Add(CentreID);

            //SqlParameter ClusterID = new SqlParameter();
            //ClusterID.SqlDbType = SqlDbType.VarChar;
            //ClusterID.Value = hdfCluster.Value;
            //ClusterID.ParameterName = "@ClusterID";
            //sqlcmd.Parameters.Add(ClusterID);

            SqlParameter SubcentreID = new SqlParameter();
            SubcentreID.SqlDbType = SqlDbType.VarChar;
            SubcentreID.Value = hdfSubcentre.Value;
            SubcentreID.ParameterName = "@SubcentreID";
            sqlcmd.Parameters.Add(SubcentreID);

            SqlParameter EmpID = new SqlParameter();
            EmpID.SqlDbType = SqlDbType.VarChar;
            EmpID.Value = hdnEmpId.Value;
            EmpID.ParameterName = "@EmpID";
            sqlcmd.Parameters.Add(EmpID);

            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            if (dt.Rows.Count > 0)
            {
                txtEmpCode.Text = dt.Rows[0]["Emp_code"].ToString().Trim();
                txtName.Text = dt.Rows[0]["FullName"].ToString().Trim();
                txtDoj.Text = dt.Rows[0]["DOJ"].ToString().Trim();
                txtDesig.Text = dt.Rows[0]["DESIGNATION"].ToString().Trim();
                txtDateTrain.Text = dt.Rows[0]["Training_Date"].ToString().Trim();
                ddlInducTrain.SelectedValue = dt.Rows[0]["Indu_Train"].ToString().Trim();
                txtInductionTrainer.Text  = dt.Rows[0]["Trainer_Name"].ToString().Trim();
                txtQmsTrainer.Text = dt.Rows[0]["Qms_Trainer"].ToString().Trim();
                txtMouDate.Text = dt.Rows[0]["Mou_Issue_Date"].ToString().Trim();
                txtremark.Text = dt.Rows[0]["ojt_remark"].ToString().Trim();
            }         

        }
    }
  
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Insert_OjtAddDetails12";
            sqlcmd.CommandTimeout = 0;

            SqlParameter EMP_CODE = new SqlParameter();
            EMP_CODE.SqlDbType = SqlDbType.VarChar;
            EMP_CODE.Value = txtEmpCode.Text.Trim();
            EMP_CODE.ParameterName = "@EMP_CODE";
            sqlcmd.Parameters.Add(EMP_CODE);

            SqlParameter Training_Date = new SqlParameter();
            Training_Date.SqlDbType = SqlDbType.DateTime;
            Training_Date.Value =strDate(txtDateTrain.Text.Trim());
            Training_Date.ParameterName = "@Training_Date";
            sqlcmd.Parameters.Add(Training_Date);

            SqlParameter Indu_Train = new SqlParameter();
            Indu_Train.SqlDbType = SqlDbType.VarChar;
            Indu_Train.Value = ddlInducTrain.SelectedValue.ToString();
            Indu_Train.ParameterName = "@Indu_Train";
            sqlcmd.Parameters.Add(Indu_Train);

            SqlParameter Trainer_Name = new SqlParameter();
            Trainer_Name.SqlDbType = SqlDbType.VarChar;
            Trainer_Name.Value = txtInductionTrainer.Text.Trim();  
            Trainer_Name.ParameterName = "@Trainer_Name";
            sqlcmd.Parameters.Add(Trainer_Name);

            SqlParameter Qms_Trainer = new SqlParameter();
            Qms_Trainer.SqlDbType = SqlDbType.VarChar;
            Qms_Trainer.Value = txtQmsTrainer.Text.Trim();  
            Qms_Trainer.ParameterName = "@Qms_Trainer";
            sqlcmd.Parameters.Add(Qms_Trainer);

            SqlParameter remark = new SqlParameter();
            remark.SqlDbType = SqlDbType.VarChar;
            remark.Value = txtremark.Text.Trim();
            remark.ParameterName = "@remark";
            sqlcmd.Parameters.Add(remark);
            int i;

            
            i=sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            lblMessage.Text = "Record Update Sucessfully";
            ClearData();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;     
        }

    }

    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);

        string strMM = strInDate.Substring(3, 2);

        string strYYYY = strInDate.Substring(6, 4);

        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY;  //on Server 

        //string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;   //On local machine

        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);

        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy");

        return strOutDate;
    }

    private void ClearData()
    {
        txtDateTrain.Text = "";
        txtDesig.Text = "";
        txtDoj.Text = "";
        txtEmpCode.Text = "";
        txtName.Text = "";
        txtCaseAssign.Text = "";
        txtCaseComplete.Text = "";
        txtErrorCount.Text = "";
        txtMouDate.Text = "";
        ddlInducTrain.SelectedIndex = 0;
        ddlBehaviour.SelectedIndex = 0;
        ddlInOut.SelectedIndex = 0;
        ddlMinProduct.SelectedIndex = 0;
        ddlTraining.SelectedIndex = 0;
        txtQmsTrainer.Text = "";
        txtInductionTrainer.Text = "";
        txtremark.Text = ""; 
    }

    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");  
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Insert_OjtDailyProductTracker";
            sqlcmd.CommandTimeout = 0;

            SqlParameter UID = new SqlParameter();
            UID.SqlDbType = SqlDbType.Int;
            UID.Value = hdnUID.Value;
            UID.ParameterName = "@UID";
            sqlcmd.Parameters.Add(UID);

            SqlParameter Emp_Id = new SqlParameter();
            Emp_Id.SqlDbType = SqlDbType.Int;
            Emp_Id.Value = hdnEmpId.Value;
            Emp_Id.ParameterName = "@Emp_Id";
            sqlcmd.Parameters.Add(Emp_Id);

            SqlParameter EMP_CODE = new SqlParameter();
            EMP_CODE.SqlDbType = SqlDbType.VarChar;
            EMP_CODE.Value = txtEmpCode.Text.Trim();
            EMP_CODE.ParameterName = "@Emp_Code";
            sqlcmd.Parameters.Add(EMP_CODE);

            SqlParameter Emp_Name = new SqlParameter();
            Emp_Name.SqlDbType = SqlDbType.VarChar;
            Emp_Name.Value = txtName.Text.Trim();
            Emp_Name.ParameterName = "@Emp_Name";
            sqlcmd.Parameters.Add(Emp_Name);

            SqlParameter Cluster_Id = new SqlParameter();
            Cluster_Id.SqlDbType = SqlDbType.VarChar;
            Cluster_Id.Value = hdfCluster.Value;
            Cluster_Id.ParameterName = "@Cluster_Id";
            sqlcmd.Parameters.Add(Cluster_Id);

            SqlParameter Centre_Id = new SqlParameter();
            Centre_Id.SqlDbType = SqlDbType.VarChar;
            Centre_Id.Value = hdfCentre.Value;
            Centre_Id.ParameterName = "@Centre_Id";
            sqlcmd.Parameters.Add(Centre_Id);

            SqlParameter SubCentre_Id = new SqlParameter();
            SubCentre_Id.SqlDbType = SqlDbType.VarChar;
            SubCentre_Id.Value = hdfSubcentre.Value;
            SubCentre_Id.ParameterName = "@SubCentre_Id";
            sqlcmd.Parameters.Add(SubCentre_Id);

            SqlParameter Min_Product = new SqlParameter();
            Min_Product.SqlDbType = SqlDbType.VarChar;
            Min_Product.Value = ddlMinProduct.SelectedValue.ToString();
            Min_Product.ParameterName = "@Min_Product";
            sqlcmd.Parameters.Add(Min_Product);

            SqlParameter InOut_Time = new SqlParameter();
            InOut_Time.SqlDbType = SqlDbType.VarChar;
            InOut_Time.Value = ddlInOut.SelectedValue.ToString();
            InOut_Time.ParameterName = "@InOut_Time";
            sqlcmd.Parameters.Add(InOut_Time);

            SqlParameter Emp_Behaviour = new SqlParameter();
            Emp_Behaviour.SqlDbType = SqlDbType.VarChar;
            Emp_Behaviour.Value = ddlBehaviour.SelectedValue.ToString();
            Emp_Behaviour.ParameterName = "@Emp_Behaviour";
            sqlcmd.Parameters.Add(Emp_Behaviour);

            SqlParameter Case_Assign = new SqlParameter();
            Case_Assign.SqlDbType = SqlDbType.Int;
            Case_Assign.Value = txtCaseAssign.Text.Trim();
            Case_Assign.ParameterName = "@Case_Assign";
            sqlcmd.Parameters.Add(Case_Assign);

            SqlParameter Case_Complete = new SqlParameter();
            Case_Complete.SqlDbType = SqlDbType.Int;
            Case_Complete.Value = txtCaseComplete.Text.Trim();
            Case_Complete.ParameterName = "@Case_Complete";
            sqlcmd.Parameters.Add(Case_Complete);

            SqlParameter Error_Count = new SqlParameter();
            Error_Count.SqlDbType = SqlDbType.Int;
            Error_Count.Value = txtErrorCount.Text.Trim();
            Error_Count.ParameterName = "@Error_Count";
            sqlcmd.Parameters.Add(Error_Count);

            SqlParameter Training = new SqlParameter();
            Training.SqlDbType = SqlDbType.VarChar;
            Training.Value = ddlTraining.SelectedValue.ToString();
            Training.ParameterName = "@Training";
            sqlcmd.Parameters.Add(Training);

            SqlParameter UserId = new SqlParameter();
            UserId.SqlDbType = SqlDbType.VarChar;
            UserId.Value = Session["UserId"].ToString();
            UserId.ParameterName = "@UserId";
            sqlcmd.Parameters.Add(UserId);
                        
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            lblMessage1.Text = "Record Update Sucessfully";
            GridData();         
            
        }
        catch (Exception ex)
        {
            lblMessage1.Text = ex.Message;
        }
    }

    private void GridData()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_OjtDetailsData";
        sqlcmd.CommandTimeout = 0;
        
        SqlParameter EmpID = new SqlParameter();
        EmpID.SqlDbType = SqlDbType.VarChar;
        EmpID.Value = hdnEmpId.Value;
        EmpID.ParameterName = "@EmpID";
        sqlcmd.Parameters.Add(EmpID);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            GVProdTrack.DataSource = dt;
            GVProdTrack.DataBind();
        }
        else
        {
            GVProdTrack.DataSource = null;
            GVProdTrack.DataBind();
        }
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        GridData();
        lblMessage1.Text = "";
        btnSave.Enabled =false;  
    }

    protected void btnCan1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");  
    }

    protected void GVProdTrack_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", "javascript:Pro_SelectRow('" + e.Row.RowIndex + "','" + e.Row.Cells[0].Text + "')");            
        } 
    }
  }

