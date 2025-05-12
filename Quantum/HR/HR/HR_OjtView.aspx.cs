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

public partial class HR_HR_HR_OjtView : System.Web.UI.Page
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

        if(!IsPostBack)
        {

            //GetData();
            
        }
    }   

    private void GetData()
    { 
      CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_OjtEmpData";
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

            ds = CBE.FillBISView_Ojt(txtFromDate.Text.Trim(), txtToDate.Text.Trim());
            GV_EMP_VEIW.DataSource = ds;
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
                Response.Redirect("HR_OJT_InductionTrinForm.aspx?SubCentreID=" + ddlSubcentre.SelectedValue + " &CentreID=" + ddlCentre.SelectedValue + " &ClusterID=" + ddlCluter.SelectedValue + " &EMP_ID=" + strEMP_ID);
            }
            else if (ddlCentre.Visible == true && ddlSubcentre.Visible == true && ddlCluter.Visible == false)
            {
                Response.Redirect("HR_OJT_InductionTrinForm.aspx?SubCentreID=" + ddlSubcentre.SelectedValue + " &CentreID=" + ddlCentre.SelectedValue + "&EMP_ID=" + strEMP_ID);
            }
            else if (ddlSubcentre.Visible == true && ddlCluter.Visible == false && ddlCentre.Visible == false)
            {
                Response.Redirect("HR_OJT_InductionTrinForm.aspx?SubCentreID=" + ddlSubcentre.SelectedValue + "&EMP_ID=" + strEMP_ID);
            }
            else
            {
                Response.Redirect("HR_OJT_InductionTrinForm.aspx?EMP_ID=" + strEMP_ID);

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
        if (txtEmpName.Text.Trim() != "")
        {
            CBE.EMPNAME = txtEmpName.Text.Trim().Replace(' ', '%');
        }

        ds = CBE.FillBISView_Ojt(txtFromDate.Text.Trim(), txtToDate.Text.Trim());
        GV_EMP_VEIW.DataSource = ds;
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
            DropDownList ddlInducTrain = (DropDownList)GV_EMP_VEIW.Rows[i].FindControl("ddlInducTrain");
            TextBox txtInductionTrainer = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtInductionTrainer");                        
            TextBox txtQmsTrainer = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtQmsTrainer");            

            if (chkSelect.Checked == true)
            {
                sEmpCode = GV_EMP_VEIW.Rows[i].Cells[1].Text.Trim();
                InsertFtpViewData(sEmpCode, txtDateTrain.Text.Trim(), txtInductionTrainer.Text.Trim(), txtQmsTrainer.Text.Trim(), ddlInducTrain.SelectedValue.ToString());

                chkSelect.Enabled = false;
                ddlInducTrain.Enabled = false;
                txtInductionTrainer.Enabled = false;
                txtQmsTrainer.Enabled = false;
                txtDateTrain.Enabled = false;
                lblmsg.Text = "";
            }            
        }
    }

    private void InsertFtpViewData(string EmpCode, string DateTrain, string InductionTrainer, string QmsTrainer, string InducTrain)
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Insert_OjtAddDetails";
            sqlcmd.CommandTimeout = 0;

            SqlParameter EMP_CODE = new SqlParameter();
            EMP_CODE.SqlDbType = SqlDbType.VarChar;
            EMP_CODE.Value = EmpCode;
            EMP_CODE.ParameterName = "@EMP_CODE";
            sqlcmd.Parameters.Add(EMP_CODE);

            SqlParameter Training_Date = new SqlParameter();
            Training_Date.SqlDbType = SqlDbType.DateTime;
            Training_Date.Value =strDate(DateTrain);
            Training_Date.ParameterName = "@Training_Date";
            sqlcmd.Parameters.Add(Training_Date);

            SqlParameter Indu_Train = new SqlParameter();
            Indu_Train.SqlDbType = SqlDbType.VarChar;
            Indu_Train.Value = InducTrain;
            Indu_Train.ParameterName = "@Indu_Train";
            sqlcmd.Parameters.Add(Indu_Train);

            SqlParameter Trainer_Name = new SqlParameter();
            Trainer_Name.SqlDbType = SqlDbType.VarChar;
            Trainer_Name.Value = InductionTrainer;
            Trainer_Name.ParameterName = "@Trainer_Name";
            sqlcmd.Parameters.Add(Trainer_Name);

            SqlParameter Qms_Trainer = new SqlParameter();
            Qms_Trainer.SqlDbType = SqlDbType.VarChar;
            Qms_Trainer.Value = QmsTrainer;
            Qms_Trainer.ParameterName = "@Qms_Trainer";
            sqlcmd.Parameters.Add(Qms_Trainer);

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
}
