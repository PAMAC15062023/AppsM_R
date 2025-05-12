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

public partial class HR_HR_HR_ProfessionalConvertionDetails : System.Web.UI.Page
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

            ds = CBE.FillBISView_ProfConv(txtFromDate.Text.Trim(), txtToDate.Text.Trim());
            GV_EMP_VEIW.DataSource = ds;
            GV_EMP_VEIW.DataBind();

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
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

        ds = CBE.FillBISView_ProfConv(txtFromDate.Text.Trim(), txtToDate.Text.Trim());
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
            string sEmpStat = "";

            CheckBox chkSelect = (CheckBox)GV_EMP_VEIW.Rows[i].FindControl("chkSelect");
            DropDownList ddlChangeStat = (DropDownList)GV_EMP_VEIW.Rows[i].FindControl("ddlChangeStat");
            TextBox txtBasic = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtBasic");
            TextBox txtHRA = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtHRA");
            TextBox txtSPAllo = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtSPAllo");
            TextBox txtConve = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtConve");
            TextBox txtMediRemb = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtMediRemb");
            TextBox txtWashAll = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtWashAll");
            TextBox txtGrossAmt = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtGrossAmt");
            TextBox txtConvDate = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtConvDate");

            if (chkSelect.Checked == true)
            {
                sEmpId = GV_EMP_VEIW.Rows[i].Cells[1].Text.Trim();
                sEmpCode = GV_EMP_VEIW.Rows[i].Cells[2].Text.Trim();
                sEmpName = GV_EMP_VEIW.Rows[i].Cells[3].Text.Trim();
                sEmpStat = GV_EMP_VEIW.Rows[i].Cells[5].Text.Trim();

                txtGrossAmt.Text = Convert.ToString((Convert.ToDouble(txtHRA.Text.Trim()) + Convert.ToDouble(txtBasic.Text.Trim()) + Convert.ToDouble(txtSPAllo.Text.Trim()) + Convert.ToDouble(txtConve.Text.Trim()) + Convert.ToDouble(txtMediRemb.Text.Trim()) + Convert.ToDouble(txtWashAll.Text.Trim())));

                ProfessionalConUpdation(sEmpId, sEmpCode, sEmpName, sEmpStat, ddlChangeStat.SelectedValue.ToString(), txtHRA.Text.Trim(), txtBasic.Text.Trim(), txtSPAllo.Text.Trim(), txtConve.Text.Trim(), txtMediRemb.Text.Trim(), txtWashAll.Text.Trim(), txtGrossAmt.Text.Trim(), txtConvDate.Text.Trim());

                chkSelect.Enabled = false;
                ddlChangeStat.Enabled = false;
                txtBasic.Enabled = false;
                txtHRA.Enabled = false;
                txtSPAllo.Enabled = false;
                txtConve.Enabled = false;
                txtMediRemb.Enabled = false;
                txtWashAll.Enabled = false;
                txtConvDate.Enabled = false; 
                
            }
            
        }
    }

    private void ProfessionalConUpdation(string EmpId, string EmpCode, string EmpName, string EmpStat, string ChangeStat,string HRA,string Basic,string SPAllo,string Conve,string MediRemb,string WashAll, string GrossAmt,string ConvDate)
    {
        try
        {
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Insert_ProfessionalConvDetail";
            sqlcmd.CommandTimeout = 0;
                        
            SqlParameter Emp_Id = new SqlParameter();
            Emp_Id.SqlDbType = SqlDbType.Int;
            Emp_Id.Value = EmpId;
            Emp_Id.ParameterName = "@Emp_Id";
            sqlcmd.Parameters.Add(Emp_Id);

            SqlParameter EMP_CODE = new SqlParameter();
            EMP_CODE.SqlDbType = SqlDbType.VarChar;
            EMP_CODE.Value = EmpCode;
            EMP_CODE.ParameterName = "@Emp_Code";
            sqlcmd.Parameters.Add(EMP_CODE);

            SqlParameter Emp_Name = new SqlParameter();
            Emp_Name.SqlDbType = SqlDbType.VarChar;
            Emp_Name.Value = EmpName;
            Emp_Name.ParameterName = "@Emp_Name";
            sqlcmd.Parameters.Add(Emp_Name);

            SqlParameter sEmpStat = new SqlParameter();
            sEmpStat.SqlDbType = SqlDbType.VarChar;
            sEmpStat.Value = EmpStat;
            sEmpStat.ParameterName = "@Emp_Status";
            sqlcmd.Parameters.Add(sEmpStat);

            SqlParameter sChangeStat = new SqlParameter();
            sChangeStat.SqlDbType = SqlDbType.VarChar;
            sChangeStat.Value = ChangeStat;
            sChangeStat.ParameterName = "@Change_Status";
            sqlcmd.Parameters.Add(sChangeStat);

            SqlParameter Approve_Status = new SqlParameter();
            Approve_Status.SqlDbType = SqlDbType.VarChar;
            Approve_Status.Value = "N";
            Approve_Status.ParameterName = "@Approve_Status";
            sqlcmd.Parameters.Add(Approve_Status);

            SqlParameter sHRA = new SqlParameter();
            sHRA.SqlDbType = SqlDbType.VarChar;
            sHRA.Value = HRA;
            sHRA.ParameterName = "@HRA";
            sqlcmd.Parameters.Add(sHRA);

            SqlParameter sBasic = new SqlParameter();
            sBasic.SqlDbType = SqlDbType.VarChar;
            sBasic.Value = Basic;
            sBasic.ParameterName = "@Basic";
            sqlcmd.Parameters.Add(sBasic);

            SqlParameter sSP_All = new SqlParameter();
            sSP_All.SqlDbType = SqlDbType.VarChar;
            sSP_All.Value = SPAllo;
            sSP_All.ParameterName = "@SP_All";
            sqlcmd.Parameters.Add(sSP_All);

            SqlParameter sConveyance = new SqlParameter();
            sConveyance.SqlDbType = SqlDbType.VarChar;
            sConveyance.Value = Conve;
            sConveyance.ParameterName = "@Conveyance";
            sqlcmd.Parameters.Add(sConveyance);

            SqlParameter sMedical_Remb = new SqlParameter();
            sMedical_Remb.SqlDbType = SqlDbType.VarChar;
            sMedical_Remb.Value = MediRemb;
            sMedical_Remb.ParameterName = "@Medical_Remb";
            sqlcmd.Parameters.Add(sMedical_Remb);

            SqlParameter sWashing_Allow = new SqlParameter();
            sWashing_Allow.SqlDbType = SqlDbType.VarChar;
            sWashing_Allow.Value = WashAll;
            sWashing_Allow.ParameterName = "@Washing_Allow";
            sqlcmd.Parameters.Add(sWashing_Allow);

            SqlParameter sGross_Amt = new SqlParameter();
            sGross_Amt.SqlDbType = SqlDbType.VarChar;
            sGross_Amt.Value = GrossAmt;
            sGross_Amt.ParameterName = "@Gross_Amt";
            sqlcmd.Parameters.Add(sGross_Amt);

            SqlParameter sChange_StatusDate = new SqlParameter();
            sChange_StatusDate.SqlDbType = SqlDbType.DateTime;
            sChange_StatusDate.Value = ConvDate;
            sChange_StatusDate.ParameterName = "@Change_StatusDate";
            sqlcmd.Parameters.Add(sChange_StatusDate);

            SqlParameter UserId = new SqlParameter();
            UserId.SqlDbType = SqlDbType.VarChar;
            UserId.Value = Session["UserId"].ToString();
            UserId.ParameterName = "@UserId";
            sqlcmd.Parameters.Add(UserId);

            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            lblmsg.Text = "Record Update Sucessfully";

        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }    

    protected void btnCan_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");  
    }
    //protected void GV_EMP_VEIW_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        Image ImgExpireDate = (Image)e.Row.FindControl("ImgExpireDate");
    //        TextBox txtConvDate = (TextBox)e.Row.FindControl("txtConvDate");

    //        ImgExpireDate.Attributes.Add("onclick", "javascript:popUpCalendar(this," + txtConvDate.ClientID + ",'dd/mm/yyyy',0,0);");
    //    }
    //}
}
