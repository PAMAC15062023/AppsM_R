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

public partial class HR_HR_HR_TrainingMandaysTracker : System.Web.UI.Page
{
    CBISENTRY CBE = new CBISENTRY();
    DataSet ds = new DataSet();
    CCommon con = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        CCommon objConn = new CCommon();
        sdsSubcetre.ConnectionString = objConn.ConnectionString;  //Sir
        sdsCentre.ConnectionString = objConn.ConnectionString;  //Sir
        sdsCluster.ConnectionString = objConn.ConnectionString;  //Sir

        if (!IsPostBack)
        {
            GetData();
        }

    }
    private void GetData()
    {
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_OjtEmpData_TrainMandays";
        sqlcmd.CommandTimeout = 0;

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            GV_EMP_VEIW.DataSource = dt;
            GV_EMP_VEIW.DataBind();
        }
        else
        {
            GV_EMP_VEIW.DataSource = null;
            GV_EMP_VEIW.DataBind();
            lblmsg.Text = "Record Not Found";
            lblmsg.Visible = true;
        }
    }

    protected void btnshow_Click(object sender, EventArgs e)
    {
        ShowGrid();
    }

    protected void ddlCluter_DataBound(object sender, EventArgs e)
    {
        ddlCluter.Items.Insert(0, new ListItem("--All--", "0"));
    }

    protected void ddlCluter_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCluter.SelectedIndex == 0)
            {
                sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] order by CENTRE_NAME ";
                ddlCentre.DataBind();
            }
            else
            {
                sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] WHERE ([CLUSTER_ID] = " + ddlCluter.SelectedValue + ") order by CENTRE_NAME";
                ddlCentre.DataBind();
            }
            if (ddlCentre.SelectedIndex == 0)
            {
                string strRole = Session["RoleID"].ToString();
                string[] strRole1 = strRole.Split(',');


                foreach (string str in strRole1)
                {
                    if (str == "25")
                    {
                        sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where ClusterID=" + Session["ClusterId"].ToString() + " order by SubCentreName";
                    }
                    if (str == "24")
                    {
                        sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster  order by SubCentreName";

                    }
                }
                ddlSubcentre.DataBind();
            }
            else
            {
                sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + ddlCentre.SelectedValue + " order by SubCentreName";
                ddlSubcentre.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.Visible = true;
        }
    }

    protected void ddlCentre_DataBound(object sender, EventArgs e)
    {
        ddlCentre.Items.Insert(0, new ListItem("--All--", "0"));
    }

    protected void ddlCentre_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCluter.Visible == true)
            {
                if (ddlCentre.SelectedIndex == 0)
                {
                    sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster order by SubCentreName";
                    ddlSubcentre.DataBind();
                }
                else
                {
                    sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + ddlCentre.SelectedValue + " order by SubCentreName";
                    ddlSubcentre.DataBind();
                }
            }
            else
            {
                if (ddlCentre.SelectedIndex == 0)
                {
                    sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where  ClusterId ='" + Session["ClusterID"] + "'   order by SubCentreName";
                    ddlSubcentre.DataBind();
                }
                else
                {
                    sdsSubcetre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where  ClusterId ='" + Session["ClusterID"] + "' and CentreID='" + ddlCentre.SelectedValue + "'  order by SubCentreName";
                    ddlSubcentre.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.Visible = true;

        }
    }

    protected void ddlSubcentre_DataBound(object sender, EventArgs e)
    {
        ddlSubcentre.Items.Insert(0, new ListItem("--All--", "0"));
    }

    protected void GV_EMP_VEIW_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GV_EMP_VEIW.PageIndex = e.NewPageIndex;
            if (ddlCluter.Visible == true && ddlCentre.Visible == true && ddlSubcentre.Visible == true)
            {
                CBE.ClusterID = ddlCluter.SelectedValue;
                CBE.CentreID = ddlCentre.SelectedValue;
                CBE.SubCentreID = ddlSubcentre.SelectedValue;

            }
            else if (ddlCentre.Visible == true && ddlSubcentre.Visible == true)
            {
                CBE.CentreID = ddlCentre.SelectedValue;
                CBE.SubCentreID = ddlSubcentre.SelectedValue;
                CBE.ClusterID = Session["ClusterId"].ToString();
            }
            else if (ddlSubcentre.Visible == true)
            {
                CBE.SubCentreID = ddlSubcentre.SelectedValue;
                CBE.CentreID = Session["CentreId"].ToString();
                CBE.ClusterID = Session["ClusterId"].ToString();
            }
            else
            {
                CBE.SubCentreID = Session["SubcentreID"].ToString();
                CBE.CentreID = Session["CentreId"].ToString();
                CBE.ClusterID = Session["ClusterId"].ToString();
            }


            //added by SANKET
            if (txtEmpCode.Text.Trim() != "")
            {
                CBE.EMPCODE = txtEmpCode.Text.Trim();
            }
            else
            {
                CBE.EMPCODE = "";
            }
            if (txtEmpName.Text.Trim() != "")
            {
                CBE.EMPNAME = txtEmpName.Text.Trim();
            }
            else
            {
                CBE.EMPNAME = "";
            }
            //END


          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Get_OjtEmpData_ProdTrack_Search";
            sqlcmd.CommandTimeout = 0;

            SqlParameter CentreID = new SqlParameter();
            CentreID.SqlDbType = SqlDbType.VarChar;
            CentreID.Value = ddlCentre.SelectedValue.ToString();
            CentreID.ParameterName = "@CentreID";
            sqlcmd.Parameters.Add(CentreID);

            SqlParameter SubcentreID = new SqlParameter();
            SubcentreID.SqlDbType = SqlDbType.VarChar;
            SubcentreID.Value = ddlSubcentre.SelectedValue.ToString();
            SubcentreID.ParameterName = "@SubcentreID";
            sqlcmd.Parameters.Add(SubcentreID);

            //added by SANKET
            SqlParameter EmpCode = new SqlParameter();
            EmpCode.SqlDbType = SqlDbType.VarChar;
            EmpCode.Value = CBE.EMPCODE;
            EmpCode.ParameterName = "@Emp_code";
            sqlcmd.Parameters.Add(EmpCode);

            SqlParameter EmpName = new SqlParameter();
            EmpName.SqlDbType = SqlDbType.VarChar;
            EmpName.Value = CBE.EMPNAME;
            EmpName.ParameterName = "@FirstName";
            sqlcmd.Parameters.Add(EmpName);

            String strdate;
            strdate = DateTime.Now.Date.ToString();

            SqlParameter CreateDate = new SqlParameter();
            CreateDate.SqlDbType = SqlDbType.DateTime;
            CreateDate.Value = strdate;
            CreateDate.ParameterName = "@createdate";
            sqlcmd.Parameters.Add(@CreateDate);
            //END


            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            sqlcon.Close();

            //ds = CBE.FillBISView_Ojt_Daily(txtFromDate.Text.Trim(), txtToDate.Text.Trim());
            //GV_EMP_VEIW.DataSource = ds;
            GV_EMP_VEIW.DataSource = dt;
            GV_EMP_VEIW.DataBind();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.Visible = true;
        }
    }

    protected void GV_EMP_VEIW_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String strEMP_ID = "";
        strEMP_ID = e.CommandArgument.ToString();
        if (e.CommandName == "Ed")
        {
            string strRole = Session["RoleID"].ToString();
            string[] strRole1 = strRole.Split(',');


            if (ddlCluter.Visible == true && ddlCentre.Visible == true && ddlSubcentre.Visible == true)
            {
                Response.Redirect("HR_TrainingMandaysTracker_Updation.aspx?SubCentreID=" + ddlSubcentre.SelectedValue + " &CentreID=" + ddlCentre.SelectedValue + " &ClusterID=" + ddlCluter.SelectedValue + " &EMP_ID=" + strEMP_ID);
            }
            else if (ddlCentre.Visible == true && ddlSubcentre.Visible == true && ddlCluter.Visible == false)
            {
                Response.Redirect("HR_TrainingMandaysTracker_Updation.aspx?SubCentreID=" + ddlSubcentre.SelectedValue + " &CentreID=" + ddlCentre.SelectedValue + "&EMP_ID=" + strEMP_ID);
            }
            else if (ddlSubcentre.Visible == true && ddlCluter.Visible == false && ddlCentre.Visible == false)
            {
                Response.Redirect("HR_TrainingMandaysTracker_Updation.aspx?SubCentreID=" + ddlSubcentre.SelectedValue + "&EMP_ID=" + strEMP_ID);
            }
            else
            {
                Response.Redirect("HR_TrainingMandaysTracker_Updation.aspx?EMP_ID=" + strEMP_ID);

            }
        }
    }

    public void ShowGrid()
    {
        if (ddlCluter.Visible == true && ddlCentre.Visible == true && ddlSubcentre.Visible == true)
        {
            CBE.ClusterID = ddlCluter.SelectedValue;
            CBE.CentreID = ddlCentre.SelectedValue;
            CBE.SubCentreID = ddlSubcentre.SelectedValue;

        }
        else if (ddlCentre.Visible == true && ddlSubcentre.Visible == true)
        {
            CBE.CentreID = ddlCentre.SelectedValue;
            CBE.SubCentreID = ddlSubcentre.SelectedValue;
            CBE.ClusterID = Session["ClusterId"].ToString();
        }
        else if (ddlSubcentre.Visible == true)
        {
            CBE.SubCentreID = ddlSubcentre.SelectedValue;
            CBE.CentreID = Session["CentreId"].ToString();
            CBE.ClusterID = Session["ClusterId"].ToString();
        }
        else
        {
            CBE.SubCentreID = Session["SubcentreID"].ToString();
            CBE.CentreID = Session["CentreId"].ToString();
            CBE.ClusterID = Session["ClusterId"].ToString();
        }

        if (txtEmpCode.Text.Trim() != "")
        {
            CBE.EMPCODE = txtEmpCode.Text.Trim();
        }
        else
        {
            CBE.EMPCODE = "";
        }
        if (txtEmpName.Text.Trim() != "")
        {
            CBE.EMPNAME = txtEmpName.Text.Trim();

        }
        else
        {
            CBE.EMPNAME = "";
        }

      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_OjtEmpData_ProdTrack_Search";
        sqlcmd.CommandTimeout = 0;

        SqlParameter CentreID = new SqlParameter();
        CentreID.SqlDbType = SqlDbType.VarChar;
        CentreID.Value = ddlCentre.SelectedValue.ToString();
        CentreID.ParameterName = "@CentreID";
        sqlcmd.Parameters.Add(CentreID);

        SqlParameter SubcentreID = new SqlParameter();
        SubcentreID.SqlDbType = SqlDbType.VarChar;
        SubcentreID.Value = ddlSubcentre.SelectedValue.ToString();
        SubcentreID.ParameterName = "@SubcentreID";
        sqlcmd.Parameters.Add(SubcentreID);

        SqlParameter EmpCode = new SqlParameter();
        EmpCode.SqlDbType = SqlDbType.VarChar;
        EmpCode.Value = CBE.EMPCODE;
        EmpCode.ParameterName = "@Emp_code";
        sqlcmd.Parameters.Add(EmpCode);

        SqlParameter EmpName = new SqlParameter();
        EmpName.SqlDbType = SqlDbType.VarChar;
        EmpName.Value = CBE.EMPNAME;
        EmpName.ParameterName = "@FirstName";
        sqlcmd.Parameters.Add(EmpName);

        String strdate;
        strdate = DateTime.Now.Date.ToString();

        SqlParameter CreateDate = new SqlParameter();
        CreateDate.SqlDbType = SqlDbType.DateTime;
        CreateDate.Value = strdate;
        CreateDate.ParameterName = "@createdate";
        sqlcmd.Parameters.Add(@CreateDate);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;
        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        //ds = CBE.FillBISView_Ojt_Daily(txtFromDate.Text.Trim(), txtToDate.Text.Trim());
        //GV_EMP_VEIW.DataSource = ds;
        GV_EMP_VEIW.DataSource = dt;
        GV_EMP_VEIW.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        for (int i = 0; i <= GV_EMP_VEIW.Rows.Count - 1; i++)
        {
            string sEmpCode = "";
            string sEmpName = "";
            string sEmpId = "";

            CheckBox chkSelect = (CheckBox)GV_EMP_VEIW.Rows[i].FindControl("chkSelect");
            TextBox txtDateTrain = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtDateTrain");
            TextBox txtTopic = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtTopic");            
            TextBox txtInductionTrainer = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtInductionTrainer");
            TextBox txtVenue = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtVenue");
            TextBox txtDura = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtDura");
            TextBox txtEva = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtEva");

            if (chkSelect.Checked == true)
            {
                sEmpCode = GV_EMP_VEIW.Rows[i].Cells[1].Text.Trim();
                InsertFtpViewData(sEmpCode, txtDateTrain.Text.Trim(), txtTopic.Text.Trim(), txtInductionTrainer.Text.Trim(), txtVenue.Text.Trim(), txtDura.Text.Trim(), txtEva.Text.Trim());

                chkSelect.Enabled = false;
                txtDateTrain.Enabled = false;
                txtInductionTrainer.Enabled = false;
                txtTopic.Enabled = false;
                txtVenue.Enabled = false;
                txtDura.Enabled = false;
                txtEva.Enabled = false;

            }           
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

    private void InsertFtpViewData(string EmpCode, string DateTrain, string Topic, string InductionTrainer, string Venue, string Dura, string Eva)
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
            EMP_CODE.Value = EmpCode;
            EMP_CODE.ParameterName = "@EMP_CODE";
            sqlcmd.Parameters.Add(EMP_CODE);

            SqlParameter Training_Date = new SqlParameter();
            Training_Date.SqlDbType = SqlDbType.DateTime;
            Training_Date.Value =strDate(DateTrain);
            Training_Date.ParameterName = "@TrainMandays_Date";
            sqlcmd.Parameters.Add(Training_Date);

            SqlParameter Indu_Train = new SqlParameter();
            Indu_Train.SqlDbType = SqlDbType.VarChar;
            Indu_Train.Value = InductionTrainer;
            Indu_Train.ParameterName = "@TrainMandays_TrainerName";
            sqlcmd.Parameters.Add(Indu_Train);

            SqlParameter sTopic = new SqlParameter();
            sTopic.SqlDbType = SqlDbType.VarChar;
            sTopic.Value = Topic;
            sTopic.ParameterName = "@Topic";
            sqlcmd.Parameters.Add(sTopic);

            SqlParameter sVenue = new SqlParameter();
            sVenue.SqlDbType = SqlDbType.VarChar;
            sVenue.Value = Venue;
            sVenue.ParameterName = "@Venue";
            sqlcmd.Parameters.Add(sVenue);

            SqlParameter Duration = new SqlParameter();
            Duration.SqlDbType = SqlDbType.VarChar;
            Duration.Value = Dura;
            Duration.ParameterName = "@Duration";
            sqlcmd.Parameters.Add(Duration);

            SqlParameter Evaluation = new SqlParameter();
            Evaluation.SqlDbType = SqlDbType.VarChar;
            Evaluation.Value = Eva;
            Evaluation.ParameterName = "@Evaluation";
            sqlcmd.Parameters.Add(Evaluation);

            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            lblmsg.Text = "Record Update Sucessfully";
            lblmsg.Visible = true;
            
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
            lblmsg.Visible = true;
        }
    }

    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx"); 
    }
}
