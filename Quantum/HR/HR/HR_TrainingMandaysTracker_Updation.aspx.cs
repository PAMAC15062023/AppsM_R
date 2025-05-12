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

public partial class HR_HR_HR_TrainingMandaysTracker_Updation : System.Web.UI.Page
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
           
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_InductionTrainData_TrainMandays";
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
                txtDesig.Text = dt.Rows[0]["DESIGNATION"].ToString().Trim();
                txtDateTrain.Text = dt.Rows[0]["Training_Date"].ToString().Trim();
                txtInductionTrainer.Text = dt.Rows[0]["TrainMandays_TrainerName"].ToString().Trim();
                txtTopic.Text = dt.Rows[0]["Topic"].ToString().Trim();
                txtVenue.Text = dt.Rows[0]["Venue"].ToString().Trim();
                txtDura.Text = dt.Rows[0]["Duration"].ToString().Trim();
                txtEva.Text = dt.Rows[0]["Evaluation"].ToString().Trim();
            }
            else
            {
                lblMessage.Text = "Details Not Avilable";
                lblMessage.Visible = true; 
            }
        }
    }

    //private void GetInductionTrainerName()
    //{
    //  CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
    //    sqlcon.Open();

    //    SqlCommand sqlcmd = new SqlCommand();
    //    sqlcmd.Connection = sqlcon;
    //    sqlcmd.CommandType = CommandType.StoredProcedure;
    //    sqlcmd.CommandText = "Get_InductionTrainerName";
    //    sqlcmd.CommandTimeout = 0;

    //    SqlDataAdapter sqlda = new SqlDataAdapter();
    //    sqlda.SelectCommand = sqlcmd;
    //    DataTable dt = new DataTable();
    //    sqlda.Fill(dt);
    //    sqlcon.Close();

    //    ddlInductionTrainer.DataTextField = "FullName";
    //    ddlInductionTrainer.DataValueField = "Emp_id";
    //    ddlInductionTrainer.DataSource = dt;
    //    ddlInductionTrainer.DataBind();

    //    ddlInductionTrainer.Items.Insert(0, "-Select-");
    //    ddlInductionTrainer.SelectedIndex = 0;
    //}

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Insert_OjtAddDetails_TrainMandays";
            sqlcmd.CommandTimeout = 0;

            SqlParameter EMP_CODE = new SqlParameter();
            EMP_CODE.SqlDbType = SqlDbType.VarChar;
            EMP_CODE.Value = txtEmpCode.Text.Trim();
            EMP_CODE.ParameterName = "@EMP_CODE";
            sqlcmd.Parameters.Add(EMP_CODE);

            SqlParameter Training_Date = new SqlParameter();
            Training_Date.SqlDbType = SqlDbType.DateTime;
            Training_Date.Value =strDate(txtDateTrain.Text.Trim());
            Training_Date.ParameterName = "@TrainMandays_Date";
            sqlcmd.Parameters.Add(Training_Date);

            SqlParameter Indu_Train = new SqlParameter();
            Indu_Train.SqlDbType = SqlDbType.VarChar;
            Indu_Train.Value = txtInductionTrainer.Text.Trim();  
            Indu_Train.ParameterName = "@TrainMandays_TrainerName";
            sqlcmd.Parameters.Add(Indu_Train);

            SqlParameter Topic = new SqlParameter();
            Topic.SqlDbType = SqlDbType.VarChar;
            Topic.Value = txtTopic.Text.Trim();
            Topic.ParameterName = "@Topic";
            sqlcmd.Parameters.Add(Topic);

            SqlParameter Venue = new SqlParameter();
            Venue.SqlDbType = SqlDbType.VarChar;
            Venue.Value = txtVenue.Text.Trim();
            Venue.ParameterName = "@Venue";
            sqlcmd.Parameters.Add(Venue);

            SqlParameter Duration = new SqlParameter();
            Duration.SqlDbType = SqlDbType.VarChar;
            Duration.Value = txtDura.Text.Trim();
            Duration.ParameterName = "@Duration";
            sqlcmd.Parameters.Add(Duration);

            SqlParameter Evaluation = new SqlParameter();
            Evaluation.SqlDbType = SqlDbType.VarChar;
            Evaluation.Value = txtEva.Text.Trim();
            Evaluation.ParameterName = "@Evaluation";
            sqlcmd.Parameters.Add(Evaluation);

            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            lblMessage.Text = "Record Update Sucessfully";
            lblMessage.Visible = true;  
            ClearData();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.Visible = true;  
        }

    }

    private void ClearData()
    {
        txtDateTrain.Text = "";
        txtTopic.Text = "";
        txtVenue.Text = "";
        txtDura.Text = "";
        txtEva.Text = "";
        txtInductionTrainer.Text = "";
    }

    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");  
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

}
