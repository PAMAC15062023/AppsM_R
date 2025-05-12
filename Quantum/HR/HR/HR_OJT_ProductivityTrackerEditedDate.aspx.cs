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

public partial class HR_HR_HR_OJT_ProductivityTrackerEditedDate : System.Web.UI.Page
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
            //ShowGrid();
            GV_EMP_VEIW.Columns[13].Visible = false;
        }
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
        GV_EMP_VEIW.PageIndex = e.NewPageIndex;
        ShowGrid();
    }

    public void ShowGrid()
    {
        //string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
        //string strhh = strTime.Remove(2);
        //string strmm = strTime.Remove(0, 3);



        //if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() != "Sunday")
        //{
        //    hdndate.Value = System.DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");

        //}
        //else
        //{
        //    hdndate.Value = System.DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy");
        //}


        //if ((Convert.ToInt32(strhh) >= 12) && ((Convert.ToInt32(strmm) >= 00)))
        //{
        //    GV_EMP_VEIW.Columns[0].Visible = false;
        //    GV_EMP_VEIW.Columns[6].Visible = false;
        //    GV_EMP_VEIW.Columns[7].Visible = false;
        //    GV_EMP_VEIW.Columns[8].Visible = false;
        //    GV_EMP_VEIW.Columns[9].Visible = false;
        //    GV_EMP_VEIW.Columns[10].Visible = false;
        //    GV_EMP_VEIW.Columns[11].Visible = false;
        //    GV_EMP_VEIW.Columns[12].Visible = false;
        //    GV_EMP_VEIW.Columns[13].Visible = false;
        //}

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

        string PrevDaydate;
        PrevDaydate = hdndate.Value;

        SqlParameter CreateDate = new SqlParameter();
        CreateDate.SqlDbType = SqlDbType.DateTime;
        CreateDate.Value =strDate(txtdate.Text.Trim());
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
            DropDownList ddlMinProduct = (DropDownList)GV_EMP_VEIW.Rows[i].FindControl("ddlMinProduct");
            DropDownList ddlInOut = (DropDownList)GV_EMP_VEIW.Rows[i].FindControl("ddlInOut");
            DropDownList ddlBehaviour = (DropDownList)GV_EMP_VEIW.Rows[i].FindControl("ddlBehaviour");
            TextBox txtCaseAssigned = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtCaseAssigned");
            TextBox txtCaseCompleted = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtCaseCompleted");
            TextBox txtErrorCount = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtErrorCount");
            DropDownList ddlTraining = (DropDownList)GV_EMP_VEIW.Rows[i].FindControl("ddlTraining");
            TextBox txtReason = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtReason");

            if (chkSelect.Checked == true)
            {

                sEmpId = GV_EMP_VEIW.Rows[i].Cells[1].Text.Trim();
                sEmpCode = GV_EMP_VEIW.Rows[i].Cells[2].Text.Trim();
                sEmpName = GV_EMP_VEIW.Rows[i].Cells[3].Text.Trim();
                ProductivityTracker(sEmpId, sEmpCode, sEmpName, ddlMinProduct.SelectedValue.ToString(), ddlInOut.SelectedValue.ToString(), ddlBehaviour.SelectedValue.ToString(), txtCaseAssigned.Text.Trim(), txtCaseCompleted.Text.Trim(), txtErrorCount.Text.Trim(), ddlTraining.SelectedValue.ToString(), txtReason.Text.Trim());

                chkSelect.Checked = false;
                chkSelect.Enabled = false;
                ddlMinProduct.Enabled = false;
                ddlInOut.Enabled = false;
                ddlBehaviour.Enabled = false;
                txtCaseAssigned.Enabled = false;
                txtCaseCompleted.Enabled = false;
                txtErrorCount.Enabled = false;
                ddlTraining.Enabled = false;
                txtReason.Enabled = false;

            }
        }
    }

    private void ProductivityTracker(string EmpId, string EmpCode, string EmpName, string MinProduct, string InOut, string Behaviour, string CaseAssigned, string CaseCompleted, string ErrorCount, string sTraining, string Reason)
    {
        try
        {
            //string strInDate = System.DateTime.Now.ToString();

            //string strDD = System.DateTime.Now.AddDays(-1).Day.ToString();  //Previous Day

            //string strMM = strInDate.Substring(3, 2);

            //string strYYYY = strInDate.Substring(6, 4);

            //string PrevDaydate = strDD + "/" + strMM + "/" + strYYYY;

          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Insert_OjtDailyProductTrackerEdit";
            sqlcmd.CommandTimeout = 0;

            SqlParameter UID = new SqlParameter();
            UID.SqlDbType = SqlDbType.Int;
            UID.Value = "0";
            UID.ParameterName = "@UID";
            sqlcmd.Parameters.Add(UID);

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

            SqlParameter Cluster_Id = new SqlParameter();
            Cluster_Id.SqlDbType = SqlDbType.VarChar;
            Cluster_Id.Value = Session["ClusterID"].ToString();
            Cluster_Id.ParameterName = "@Cluster_Id";
            sqlcmd.Parameters.Add(Cluster_Id);

            SqlParameter Centre_Id = new SqlParameter();
            Centre_Id.SqlDbType = SqlDbType.VarChar;
            Centre_Id.Value = Session["CentreID"].ToString();
            Centre_Id.ParameterName = "@Centre_Id";
            sqlcmd.Parameters.Add(Centre_Id);

            SqlParameter SubCentre_Id = new SqlParameter();
            SubCentre_Id.SqlDbType = SqlDbType.VarChar;
            SubCentre_Id.Value = Session["SubCentreID"].ToString();
            SubCentre_Id.ParameterName = "@SubCentre_Id";
            sqlcmd.Parameters.Add(SubCentre_Id);

            SqlParameter Min_Product = new SqlParameter();
            Min_Product.SqlDbType = SqlDbType.VarChar;
            Min_Product.Value = MinProduct;
            Min_Product.ParameterName = "@Min_Product";
            sqlcmd.Parameters.Add(Min_Product);

            SqlParameter InOut_Time = new SqlParameter();
            InOut_Time.SqlDbType = SqlDbType.VarChar;
            InOut_Time.Value = InOut;
            InOut_Time.ParameterName = "@InOut_Time";
            sqlcmd.Parameters.Add(InOut_Time);

            SqlParameter Emp_Behaviour = new SqlParameter();
            Emp_Behaviour.SqlDbType = SqlDbType.VarChar;
            Emp_Behaviour.Value = Behaviour;
            Emp_Behaviour.ParameterName = "@Emp_Behaviour";
            sqlcmd.Parameters.Add(Emp_Behaviour);

            string strCaseAssigned;

            if (CaseAssigned == "")
            {
                strCaseAssigned = "0";
            }
            else
            {
                strCaseAssigned = CaseAssigned;
            }
            SqlParameter Case_Assign = new SqlParameter();
            Case_Assign.SqlDbType = SqlDbType.Int;
            Case_Assign.Value = strCaseAssigned;
            Case_Assign.ParameterName = "@Case_Assign";
            sqlcmd.Parameters.Add(Case_Assign);

            string strCaseCompleted;

            if (CaseCompleted == "")
            {
                strCaseCompleted = "0";
            }
            else
            {
                strCaseCompleted = CaseCompleted;
            }

            SqlParameter Case_Complete = new SqlParameter();
            Case_Complete.SqlDbType = SqlDbType.Int;
            Case_Complete.Value = strCaseCompleted;
            Case_Complete.ParameterName = "@Case_Complete";
            sqlcmd.Parameters.Add(Case_Complete);

            string strErrorCount;

            if (ErrorCount == "")
            {
                strErrorCount = "0";
            }
            else
            {
                strErrorCount = ErrorCount;

            }


            SqlParameter Error_Count = new SqlParameter();
            Error_Count.SqlDbType = SqlDbType.Int;
            Error_Count.Value = strErrorCount;
            Error_Count.ParameterName = "@Error_Count";
            sqlcmd.Parameters.Add(Error_Count);

            SqlParameter Training = new SqlParameter();
            Training.SqlDbType = SqlDbType.VarChar;
            Training.Value = sTraining;
            Training.ParameterName = "@Training";
            sqlcmd.Parameters.Add(Training);

            SqlParameter Createdate = new SqlParameter();
            Createdate.SqlDbType = SqlDbType.DateTime;
            Createdate.Value =strDate(txtdate.Text.Trim());     //////  Previous day date
            Createdate.ParameterName = "@CreateDate";
            sqlcmd.Parameters.Add(Createdate);

            SqlParameter UserId = new SqlParameter();
            UserId.SqlDbType = SqlDbType.VarChar;
            UserId.Value = Session["UserId"].ToString();
            UserId.ParameterName = "@UserId";
            sqlcmd.Parameters.Add(UserId);

            int i = sqlcmd.ExecuteNonQuery();

            sqlcon.Close();
            if (i > 0)
            {
                lblmsg.Text = "Record Update Sucessfully";
            }
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

    protected void btnshow_Click(object sender, EventArgs e)
    {
        lbldate.Text =strDate(txtdate.Text.Trim());

        ShowGrid();
    }

    protected void txtCaseCompleted_TextChanged(object sender, EventArgs e)
    {

        for (int P = 0; P <= GV_EMP_VEIW.Rows.Count - 1; P++)
        {
            DropDownList ddlMinProduct = (DropDownList)GV_EMP_VEIW.Rows[P].FindControl("ddlMinProduct");

            TextBox txtCaseAssigned = (TextBox)GV_EMP_VEIW.Rows[P].FindControl("txtCaseAssigned");

            TextBox txtCaseCompleted = (TextBox)GV_EMP_VEIW.Rows[P].FindControl("txtCaseCompleted");

            TextBox txtReason = (TextBox)GV_EMP_VEIW.Rows[P].FindControl("txtReason");

            if (txtCaseCompleted.Text == "" || ddlMinProduct.SelectedValue.ToString() == "NA")
            {
                txtReason.Visible = false;
            }
            else
            {

                int ddlmin;

                if (ddlMinProduct.SelectedValue.ToString() == "45-50")
                {
                    ddlmin = Convert.ToInt32("45");
                }
                else if (ddlMinProduct.SelectedValue.ToString() == "15-18 Visits")
                {
                    ddlmin = Convert.ToInt32("15");
                }
                else if (ddlMinProduct.SelectedValue.ToString() == "85-100 Tele")
                {
                    ddlmin = Convert.ToInt32("85");
                }
                else if (ddlMinProduct.SelectedValue.ToString() == "85-100 Cases")
                {
                    ddlmin = Convert.ToInt32("85");
                }
                else if (ddlMinProduct.SelectedValue.ToString() == "85-100 Reports")
                {
                    ddlmin = Convert.ToInt32("85");
                }
                else if (ddlMinProduct.SelectedValue.ToString() == "400 Dual Entry")
                {
                    ddlmin = Convert.ToInt32("400");
                }              
                else if (ddlMinProduct.SelectedValue.ToString() == "5-6 Dox Collection")
                {
                    ddlmin = Convert.ToInt32("5");
                }
                else if (ddlMinProduct.SelectedValue.ToString() == "80-90 calls per day")
                {
                    ddlmin = Convert.ToInt32("80");
                }
                else if (ddlMinProduct.SelectedValue.ToString() == "Depends on the Area 10 DropBox per person")
                {
                    ddlmin = Convert.ToInt32("10");
                }
                else
                {
                    ddlmin = Convert.ToInt32(ddlMinProduct.SelectedValue.ToString());
                }


                if (Convert.ToInt32(txtCaseAssigned.Text) < ddlmin || Convert.ToInt32(txtCaseCompleted.Text) < ddlmin)
                {
                    txtReason.Visible = true;
                }
                else
                {
                    txtReason.Visible = false;
                }
            }
        }
    }
    
}
