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

public partial class HR_HR_HR_OJT_ProductivityTrackerEdited : System.Web.UI.Page
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
            Getdata();
            Get_ClusterList();
            //ShowGrid();
            GV_EMP_VEIW.Columns[13].Visible = false;
        }
        //lbldate.Text = strDate(hdndate.Value);
    }

    protected void btnshow_Click(object sender, EventArgs e)
    {
        ShowGrid();
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


        try
        {
            if (ddlclustername.SelectedIndex == 0)
            {
                sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] order by CENTRE_NAME ";
                ddlCentre.DataBind();
            }
            else
            {
                sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] WHERE ([CLUSTER_ID] = " + ddlclustername.SelectedValue + ") order by CENTRE_NAME";
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
            if (ddlclustername.Visible == true)
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

    protected void GV_EMP_VEIW_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String strEMP_ID = "";
        strEMP_ID = e.CommandArgument.ToString();
        if (e.CommandName == "Ed")
        {
            string strRole = Session["RoleID"].ToString();
            string[] strRole1 = strRole.Split(',');


            if (ddlclustername.Visible == true && ddlCentre.Visible == true && ddlSubcentre.Visible == true)
            {
                Response.Redirect("HR_OJT_InductionTrinForm.aspx?SubCentreID=" + ddlSubcentre.SelectedValue + " &CentreID=" + ddlCentre.SelectedValue + " &ClusterID=" + ddlclustername.SelectedValue + " &EMP_ID=" + strEMP_ID);
            }
            else if (ddlCentre.Visible == true && ddlSubcentre.Visible == true && ddlclustername.Visible == false)
            {
                Response.Redirect("HR_OJT_InductionTrinForm.aspx?SubCentreID=" + ddlSubcentre.SelectedValue + " &CentreID=" + ddlCentre.SelectedValue + "&EMP_ID=" + strEMP_ID);
            }
            else if (ddlSubcentre.Visible == true && ddlclustername.Visible == false && ddlCentre.Visible == false)
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
            string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
            string strhh = strTime.Remove(2);
            string strmm = strTime.Remove(0, 3);
                    
            GetHolidayList();
        
            string centre = Convert.ToString(1011);
            CBE.CentreID = Session["CentreId"].ToString();

            if (CBE.CentreID == centre)
            {
                if ((Convert.ToInt32(strhh) >= 16) && ((Convert.ToInt32(strmm) >= 00)))
                {
                    GV_EMP_VEIW.Columns[0].Visible = false;
                    GV_EMP_VEIW.Columns[6].Visible = false;
                    GV_EMP_VEIW.Columns[7].Visible = false;
                    GV_EMP_VEIW.Columns[8].Visible = false;
                    GV_EMP_VEIW.Columns[9].Visible = false;
                    GV_EMP_VEIW.Columns[10].Visible = false;
                    GV_EMP_VEIW.Columns[11].Visible = false;
                    GV_EMP_VEIW.Columns[12].Visible = false;
                    GV_EMP_VEIW.Columns[13].Visible = false;
                }
            }
            else
            {
                if ((Convert.ToInt32(strhh) >= 14) && ((Convert.ToInt32(strmm) >= 00)))
                {
                    GV_EMP_VEIW.Columns[0].Visible = false;
                    GV_EMP_VEIW.Columns[6].Visible = false;
                    GV_EMP_VEIW.Columns[7].Visible = false;
                    GV_EMP_VEIW.Columns[8].Visible = false;
                    GV_EMP_VEIW.Columns[9].Visible = false;
                    GV_EMP_VEIW.Columns[10].Visible = false;
                    GV_EMP_VEIW.Columns[11].Visible = false;
                    GV_EMP_VEIW.Columns[12].Visible = false;
                    GV_EMP_VEIW.Columns[13].Visible = false;
                }
            }

            if (ddlclustername.Visible == true && ddlCentre.Visible == true && ddlSubcentre.Visible == true)
        {
            CBE.ClusterID = ddlclustername.SelectedValue;
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
        sqlcmd.CommandText = "Get_OjtEmpData_ProdTrack_Search_PreviousDay_Test1";
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
        CreateDate.Value = strDate(hdndate.Value);   
        CreateDate.ParameterName = "@createdate";
        sqlcmd.Parameters.Add(@CreateDate);

        SqlParameter UserID = new SqlParameter();
        UserID.SqlDbType = SqlDbType.VarChar;
        UserID.Value = hdnEmpCode.Value;
        UserID.ParameterName = "@UserID";
        sqlcmd.Parameters.Add(UserID);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;

        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        GV_EMP_VEIW.DataSource = dt;
        GV_EMP_VEIW.DataBind();

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Save();
        ShowGrid();
    }

    private void Save() 
    {
        try
        {
            for (int i = 0; i <= GV_EMP_VEIW.Rows.Count - 1; i++)
            {
                string sEmpCode = "";
                string sEmpName = "";
                string sEmpId = "";

                CheckBox chkSelect = (CheckBox)GV_EMP_VEIW.Rows[i].FindControl("chkSelect");
                //DropDownList ddlMinProduct = (DropDownList)GV_EMP_VEIW.Rows[i].FindControl("ddlMinProduct");
                TextBox txtMinProduct = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtMinProduct");

                //DropDownList ddlInOut = (DropDownList)GV_EMP_VEIW.Rows[i].FindControl("ddlInOut");
                TextBox txtintime = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtintime");
                TextBox txtouttime = (TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtouttime");
                DropDownList ddlBehaviour = (DropDownList)GV_EMP_VEIW.Rows[i].FindControl("ddlBehaviour");
                //added//

                DropDownList ddlattendance = (DropDownList)GV_EMP_VEIW.Rows[i].FindControl("ddlattendance");

                //ended//
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
                    ProductivityTracker(sEmpId, sEmpCode, sEmpName, txtMinProduct.Text.ToString(), txtintime.Text.ToString().Trim(), txtouttime.Text.ToString().Trim(), ddlBehaviour.SelectedValue.ToString(), ddlattendance.SelectedValue.ToString(), txtCaseAssigned.Text.Trim(), txtCaseCompleted.Text.Trim(), txtErrorCount.Text.Trim(), ddlTraining.SelectedValue.ToString(), txtReason.Text.Trim());

                    chkSelect.Checked = false;
                    chkSelect.Enabled = false;
                    //ddlMinProduct.Enabled = false;
                    txtMinProduct.Enabled = false;

                    ddlBehaviour.Enabled = false;
                    //added//
                    ddlattendance.Enabled = false;
                    //ended//
                    txtCaseAssigned.Enabled = false;
                    txtCaseCompleted.Enabled = false;
                    txtErrorCount.Enabled = false;
                    ddlTraining.Enabled = false;
                    txtReason.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message;
        }
    }

    private void ProductivityTracker(string EmpId, string EmpCode, string EmpName, string MinProduct, string InTime, string OutTime, string Behaviour, string Attendance, string CaseAssigned, string CaseCompleted, string ErrorCount, string sTraining, string Reason)
    {
        try
        {
            CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
            sqlcon.Open();

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "Insert_OjtDailyProductTrackerEdit_Test12";
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

            SqlParameter In_Time = new SqlParameter();
            In_Time.SqlDbType = SqlDbType.VarChar;
            In_Time.Value = InTime;
            In_Time.ParameterName = "@In_Time";
            sqlcmd.Parameters.Add(In_Time);

            SqlParameter Out_Time = new SqlParameter();
            Out_Time.SqlDbType = SqlDbType.VarChar;
            Out_Time.Value = OutTime;
            Out_Time.ParameterName = "@Out_Time";
            sqlcmd.Parameters.Add(Out_Time);

            SqlParameter Emp_Behaviour = new SqlParameter();
            Emp_Behaviour.SqlDbType = SqlDbType.VarChar;
            Emp_Behaviour.Value = Behaviour;
            Emp_Behaviour.ParameterName = "@Emp_Behaviour";
            sqlcmd.Parameters.Add(Emp_Behaviour);


            SqlParameter Emp_attendance = new SqlParameter();
            Emp_attendance.SqlDbType = SqlDbType.VarChar;
            Emp_attendance.Value = Attendance;
            Emp_attendance.ParameterName = "@Attendance";
            sqlcmd.Parameters.Add(Emp_attendance);

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

            if (Reason == "" || Reason == null)
            {
                SqlParameter ReasonM = new SqlParameter();
                ReasonM.SqlDbType = SqlDbType.VarChar;
                ReasonM.Value = "No Minimum Productivity";
                ReasonM.ParameterName = "@Reason";
                sqlcmd.Parameters.Add(ReasonM);
            }
            else
            {
                SqlParameter ReasonM = new SqlParameter();
                ReasonM.SqlDbType = SqlDbType.VarChar;
                ReasonM.Value = Reason;
                ReasonM.ParameterName = "@Reason";
                sqlcmd.Parameters.Add(ReasonM);
            }

             SqlParameter Createdate = new SqlParameter();
             Createdate.SqlDbType = SqlDbType.DateTime;
             Createdate.Value =strDate(hdndate.Value);         //////  Previous day date
             Createdate.ParameterName = "@CreateDate";
             sqlcmd.Parameters.Add(Createdate);

            SqlParameter UserId = new SqlParameter();
            UserId.SqlDbType = SqlDbType.VarChar;
            UserId.Value = Session["UserId"].ToString();
            UserId.ParameterName = "@UserId";
            sqlcmd.Parameters.Add(UserId);

            int i= sqlcmd.ExecuteNonQuery();

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

   private void GetHolidayList()
   {
      for (int i = 1; i <= 4; i++)
      {
          string sDate = System.DateTime.Now.AddDays(-i).ToString("dd-MMM-yyyy");
          
          CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
          sqlcon.Open();

          SqlCommand Cmd = new SqlCommand();
          Cmd.Connection = sqlcon;
          Cmd.CommandType = CommandType.StoredProcedure;
          Cmd.CommandText = "SpGetHolidayList";
          Cmd.CommandTimeout = 0;

          SqlParameter Centre_id = new SqlParameter();
          Centre_id.SqlDbType = SqlDbType.VarChar;
          Centre_id.Value = Session["CentreID"].ToString();
          Centre_id.ParameterName = "@Centre_id";
          Cmd.Parameters.Add(Centre_id);

          SqlParameter Date = new SqlParameter();
          Date.SqlDbType = SqlDbType.VarChar;
          Date.Value = sDate;
          Date.ParameterName = "@Date";
          Cmd.Parameters.Add(Date);

          SqlDataAdapter da = new SqlDataAdapter();
          da.SelectCommand = Cmd;

          DataTable dt = new DataTable();
          da.Fill(dt);

          string sCentreid = Session["CentreID"].ToString();

          if (dt.Rows.Count == 0)
          {
              hdndate.Value = System.DateTime.Now.AddDays(-i).ToString("dd/MM/yyyy");

              int k = i;

              k++;

              if (System.DateTime.Now.AddDays(-i).DayOfWeek.ToString() == "Sunday")
              {
                  hdndate.Value = System.DateTime.Now.AddDays(-k).ToString("dd/MM/yyyy");
              }

              i = 5;
          }
          else
          {
              string sCompareToCentre = dt.Rows[0]["Centre_id"].ToString();

              if (sCentreid != sCompareToCentre)
              {
                  hdndate.Value = System.DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");

                  if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() == "Sunday")
                  {
                      hdndate.Value = System.DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy");
                  }
              }
              else
              {
                  if (i > 1)
                  {
                      int p = 3;

                      hdndate.Value = System.DateTime.Now.AddDays(-p).ToString("dd/MM/yyyy");
                      p++;

                      if (System.DateTime.Now.AddDays(-p).DayOfWeek.ToString() == "Sunday")
                      {
                          int y = p;
                          y++;
                          hdndate.Value = System.DateTime.Now.AddDays(-y).ToString("dd/MM/yyyy");
                      }
                  }
                  else
                  {
                      hdndate.Value = System.DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy");
                      if (System.DateTime.Now.AddDays(-2).DayOfWeek.ToString() == "Sunday")
                      {
                          hdndate.Value = System.DateTime.Now.AddDays(-3).ToString("dd/MM/yyyy");
                      }
                  }
              }
          }
          sqlcon.Close();
       }
    }

    protected void txtCaseCompleted_TextChanged(object sender, EventArgs e)
    {
        for (int P = 0; P <= GV_EMP_VEIW.Rows.Count - 1; P++)
        {
            //DropDownList ddlMinProduct = (DropDownList)GV_EMP_VEIW.Rows[P].FindControl("ddlMinProduct");
            TextBox txtMinProduct = (TextBox)GV_EMP_VEIW.Rows[P].FindControl("txtMinProduct");

            CheckBox chkSelect = (CheckBox)GV_EMP_VEIW.Rows[P].FindControl("chkSelect");


            TextBox txtCaseAssigned = (TextBox)GV_EMP_VEIW.Rows[P].FindControl("txtCaseAssigned");

            TextBox txtCaseCompleted = (TextBox)GV_EMP_VEIW.Rows[P].FindControl("txtCaseCompleted");

            TextBox txtReason = (TextBox)GV_EMP_VEIW.Rows[P].FindControl("txtReason");

            if (chkSelect.Checked == true)
            {
                if (Convert.ToInt32(txtMinProduct.Text) > Convert.ToInt32(txtCaseCompleted.Text))
                {
                    txtReason.Visible = true;
                }
                else
                {
                    txtReason.Visible = false;
                }
            }
            else
            {
                txtReason.Visible = false;
            }
        }
    }

    private void Getdata()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = sqlcon;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Get_OjtEmpData_TEST";
        cmd.CommandTimeout = 0;

        SqlParameter Emp_Code = new SqlParameter();
        Emp_Code.SqlDbType = SqlDbType.VarChar;
        Emp_Code.Value = Convert.ToInt32(Session["UserId"]);
        Emp_Code.ParameterName = "@Emp_id";
        cmd.Parameters.Add(Emp_Code);

        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;

        DataTable dt = new DataTable();
        da.Fill(dt);

        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            hdnEmpCode.Value = dt.Rows[0]["Emp_code"].ToString();   //New Added
        }
    }

    //NEW
    protected void btnBackUp_Click(object sender, EventArgs e)
    {
        ShowBackUpGrid();
    }

    public void ShowBackUpGrid()
    {
        string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
        string strhh = strTime.Remove(2);
        string strmm = strTime.Remove(0, 3);

        GetHolidayList();

        string centre = Convert.ToString(1011);
        CBE.CentreID = Session["CentreId"].ToString();

        if (CBE.CentreID == centre)
        {
            if ((Convert.ToInt32(strhh) >= 20) && ((Convert.ToInt32(strmm) >= 00)))
            {
                GV_EMP_VEIW.Columns[0].Visible = false;
                GV_EMP_VEIW.Columns[6].Visible = false;
                GV_EMP_VEIW.Columns[7].Visible = false;
                GV_EMP_VEIW.Columns[8].Visible = false;
                GV_EMP_VEIW.Columns[9].Visible = false;
                GV_EMP_VEIW.Columns[10].Visible = false;
                GV_EMP_VEIW.Columns[11].Visible = false;
                GV_EMP_VEIW.Columns[12].Visible = false;
                GV_EMP_VEIW.Columns[13].Visible = false;
            }
        }
        else
        {
            if ((Convert.ToInt32(strhh) >= 12) && ((Convert.ToInt32(strmm) >= 00)))
            {
                GV_EMP_VEIW.Columns[0].Visible = false;
                GV_EMP_VEIW.Columns[6].Visible = false;
                GV_EMP_VEIW.Columns[7].Visible = false;
                GV_EMP_VEIW.Columns[8].Visible = false;
                GV_EMP_VEIW.Columns[9].Visible = false;
                GV_EMP_VEIW.Columns[10].Visible = false;
                GV_EMP_VEIW.Columns[11].Visible = false;
                GV_EMP_VEIW.Columns[12].Visible = false;
                GV_EMP_VEIW.Columns[13].Visible = false;
            }
        }

        if (ddlclustername.Visible == true && ddlCentre.Visible == true && ddlSubcentre.Visible == true)
        {
            CBE.ClusterID = ddlclustername.SelectedValue;
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
        sqlcmd.CommandText = "Get_OjtEmpData_ProdTrack_Search_PreviousDay_BackUp";
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
        CreateDate.Value = strDate(hdndate.Value);
        CreateDate.ParameterName = "@createdate";
        sqlcmd.Parameters.Add(@CreateDate);

        SqlParameter UserID = new SqlParameter();
        UserID.SqlDbType = SqlDbType.VarChar;
        UserID.Value = hdnEmpCode.Value;
        UserID.ParameterName = "@UserID";
        sqlcmd.Parameters.Add(UserID);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;

        DataTable dt = new DataTable();
        sqlda.Fill(dt);
        sqlcon.Close();

        GV_EMP_VEIW.DataSource = dt;
        GV_EMP_VEIW.DataBind();

    }
    //END NEW
    protected void ddlattendance_SelectedIndexChanged(object sender, EventArgs e)
    {

        for (int i = 0; i <= GV_EMP_VEIW.Rows.Count - 1; i++)
        {
            CheckBox chkSelect = (CheckBox)GV_EMP_VEIW.Rows[i].FindControl("chkSelect");

            if (chkSelect.Checked == true)
            {
                // string id = GV_EMP_VEIW.Rows[i].Cells[1].Text.Trim();
                DropDownList status = (DropDownList)GV_EMP_VEIW.Rows[i].FindControl("ddlattendance");

                if (status.SelectedItem.ToString() == "Absent" || status.SelectedItem.ToString() == "Leave" || status.SelectedItem.ToString() == "Attrited")
                {
                    ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtintime")).Enabled = false;
                    ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtintime")).BackColor = System.Drawing.Color.Yellow;
                    ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtouttime")).Enabled = false;
                    ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtouttime")).BackColor = System.Drawing.Color.Yellow;
                    // ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtMinProduct")).Text = "";
                    ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtMinProduct")).Enabled = false;
                    ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtMinProduct")).BackColor = System.Drawing.Color.Yellow;
                    ((DropDownList)GV_EMP_VEIW.Rows[i].FindControl("ddlBehaviour")).Enabled = false;
                    ((DropDownList)GV_EMP_VEIW.Rows[i].FindControl("ddlBehaviour")).BackColor = System.Drawing.Color.Yellow;
                    ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtCaseAssigned")).Enabled = false;
                    ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtCaseAssigned")).BackColor = System.Drawing.Color.Yellow;
                    ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtCaseCompleted")).Enabled = false;
                    ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtCaseCompleted")).BackColor = System.Drawing.Color.Yellow;
                    ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtErrorCount")).Enabled = false;
                    ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtErrorCount")).BackColor = System.Drawing.Color.Yellow;
                    ((DropDownList)GV_EMP_VEIW.Rows[i].FindControl("ddlTraining")).Enabled = false;
                    ((DropDownList)GV_EMP_VEIW.Rows[i].FindControl("ddlTraining")).BackColor = System.Drawing.Color.Yellow;
                    ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtReason")).Text = "";
                    ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtReason")).Text = status.SelectedItem.ToString();
                    ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtReason")).BackColor = System.Drawing.Color.Yellow;
                    ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtReason")).Enabled = false;



                }
                else
                {
                    ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtintime")).Enabled = true;
                    ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtintime")).BackColor = System.Drawing.Color.LightYellow;
                    ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtouttime")).Enabled = true;
                    ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtouttime")).BackColor = System.Drawing.Color.LightYellow;
                    ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtMinProduct")).Enabled = false;
                    ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtMinProduct")).BackColor = System.Drawing.Color.LightYellow;
                    ((DropDownList)GV_EMP_VEIW.Rows[i].FindControl("ddlBehaviour")).Enabled = true;
                    ((DropDownList)GV_EMP_VEIW.Rows[i].FindControl("ddlBehaviour")).BackColor = System.Drawing.Color.LightYellow;
                    ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtCaseAssigned")).Enabled = true;
                    ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtCaseAssigned")).BackColor = System.Drawing.Color.LightYellow;
                    ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtCaseCompleted")).Enabled = true;
                    ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtCaseCompleted")).BackColor = System.Drawing.Color.LightYellow;
                    ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtErrorCount")).Enabled = true;
                    ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtErrorCount")).BackColor = System.Drawing.Color.LightYellow;
                    ((DropDownList)GV_EMP_VEIW.Rows[i].FindControl("ddlTraining")).Enabled = true;
                    ((DropDownList)GV_EMP_VEIW.Rows[i].FindControl("ddlTraining")).BackColor = System.Drawing.Color.LightYellow;
                    ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtReason")).Text = "";
                    ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtReason")).Enabled = true;
                    ((TextBox)GV_EMP_VEIW.Rows[i].FindControl("txtReason")).BackColor = System.Drawing.Color.LightYellow;

                }
            }
        }

    }

}
