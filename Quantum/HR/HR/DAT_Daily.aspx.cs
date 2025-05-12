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
using System.Collections.Generic;

public partial class HR_HR_DAT_Daily : System.Web.UI.Page
{

    DAT_ENTRY DE = new DAT_ENTRY();
    DataSet ds = new DataSet();
    string strDay = "";
    string strPreDay = "";
    string str = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        bool admin = false;
        bool IsRM = false;
        bool IsRSM = false;

        CCommon objConn = new CCommon();
        sdsSubCentre.ConnectionString = objConn.ConnectionString;  //Sir
        sdsCentre.ConnectionString = objConn.ConnectionString;  //Sir
        sdsCluster.ConnectionString = objConn.ConnectionString;  //Sir
        sdsRM.ConnectionString = objConn.ConnectionString;//Sir
        SdsRsm.ConnectionString = objConn.ConnectionString;//Sir
        DE.Department1 = Session["department_id"].ToString();
        try
        {
            string strRole = Session["RoleID"].ToString();
            string[] strRole1 = strRole.Split(',');

            bool bflag = false;


            foreach (string str in strRole1)
            {

                if (str == "1")
                {
                    btnshow.Visible = false;
                    ddlSubCentre.Visible = true;
                    ddlCentreName.Visible = true;
                    ddlCluster.Visible = true;
                    lblSubCentre.Visible = true;
                    lblSubcentreCo.Visible = true;
                    lblCentre.Visible = true;
                    lblCentreCo.Visible = true;
                    lblCluster.Visible = true;
                    lblClusterCo.Visible = true;
                    ddlRM.Visible = true;
                    lblRM.Visible = true;
                    DropDownList1.Visible = true;
                    Label1.Visible = true;
                    Label2.Visible = true;


                    //SdsRsm.SelectCommand = "select RSM_empcode as emp_code ,RSM_empcode +' '+RSM_NAME as fullname from Rsm_master";
                    //DropDownList1.DataBind();

                    admin = true;
                    if (!IsPostBack)
                    {
                        ddlCluster.DataBind();
                        ddlCluster.SelectedValue = Session["ClusterId"].ToString();
                        sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] where cluster_id=" + ddlCluster.SelectedValue + " order by CENTRE_NAME";
                        ddlCentreName.DataBind();
                        //ddlCentreName.SelectedValue = Session["CentreId"].ToString();
                        sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + ddlCentreName.SelectedValue + " order by SubCentreName";
                        ddlSubCentre.DataBind();

                        SdsRsm.SelectCommand = "select RSM_empcode as emp_code ,RSM_empcode +' '+RSM_NAME as fullname from Rsm_master";
                        DropDownList1.DataBind();
                        List<string> RSm = new List<string>();
                        for (int a = 1; a < DropDownList1.Items.Count; a++)
                        {
                            RSm.Add(DropDownList1.Items[a].ToString());
                        }

                        //ddlSubCentre.SelectedValue = Session["SubcentreID"].ToString();
                        sdsRM.SelectCommand = "select distinct rm.RM_empcode as emp_code,rm.RM_empcode+' '+rm.RM_name as Fullname from RM_master rm join  RSM_master rsm on rsm.RSM_empcode=rm.RsM_empcode join employee_master em on rsm.RsM_empcode=em.emp_code";
                        ddlRM.DataBind();

                        List<string> arm = new List<string>();
                        for (int a = 1; a < ddlRM.Items.Count; a++)
                        {
                            arm.Add(ddlRM.Items[a].ToString());
                        }

                        string strEMpadmin = "select Emp_code from Employee_master  where EMP_ID=" +
                           Session["USERID"] + "";

                        object drEmpadmin = OleDbHelper.ExecuteScalar(objConn.ConnectionString, CommandType.Text, strEMpadmin);
                        DE.Admin_EMPCODE = drEmpadmin.ToString();

                        if (DE.Admin_EMPCODE != null || DE.Admin_EMPCODE != "")
                        {
                            admin = true;
                        }
                        DE.ClusterID = ddlCluster.SelectedValue;
                        DE.CentreID = ddlCentreName.SelectedValue;
                        DE.SubCentreID = ddlSubCentre.SelectedValue;
                        DE.Emp_ID = ddlRM.SelectedValue;
                        DE.RSM_EMPCode = DropDownList1.SelectedValue;
                        DE.RM = arm;
                        DE.RSM = RSm;


                        //  FillGrid();
                    }

                }

                if (str == "6")
                {
                    btnshow.Visible = false;
                    ddlSubCentre.Visible = true;
                    ddlCentreName.Visible = true;
                    ddlCluster.Visible = true;
                    lblSubCentre.Visible = true;
                    lblSubcentreCo.Visible = true;
                    lblCentre.Visible = true;
                    lblCentreCo.Visible = true;
                    lblCluster.Visible = true;
                    lblClusterCo.Visible = true;
                    ddlRM.Visible = true;
                    lblRM.Visible = true;
                    DropDownList1.Visible = false;
                    Label1.Visible = false;
                    Label2.Visible = false;

                    IsRSM = true;
                    if (!IsPostBack)
                    {
                        ddlCluster.DataBind();
                        ddlCluster.SelectedValue = Session["ClusterId"].ToString();
                        sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] where cluster_id=" + ddlCluster.SelectedValue + " order by CENTRE_NAME";
                        ddlCentreName.DataBind();
                        //ddlCentreName.SelectedValue = Session["CentreId"].ToString();
                        sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + ddlCentreName.SelectedValue + " order by SubCentreName";
                        ddlSubCentre.DataBind();
                        //ddlSubCentre.SelectedValue = Session["SubcentreID"].ToString();
                        sdsRM.SelectCommand = "select distinct rm.RM_empcode as emp_code,rm.RM_empcode+' '+rm.RM_name as Fullname from RM_master rm join  RSM_master rsm on rsm.RSM_empcode=rm.RsM_empcode join employee_master em on rsm.RsM_empcode=em.emp_code where em.emp_id='" + Session["UserId"].ToString() + "'";
                        ddlRM.DataBind();
                        List<string> arm = new List<string>();
                        for (int a = 1; a < ddlRM.Items.Count; a++)
                        {
                            arm.Add(ddlRM.Items[a].ToString());
                        }

                        DE.ClusterID = ddlCluster.SelectedValue;
                        DE.CentreID = ddlCentreName.SelectedValue;
                        DE.SubCentreID = ddlSubCentre.SelectedValue;
                        DE.Emp_ID = ddlRM.SelectedValue;
                        DE.RM = arm;
                        DE.RSM_EMPCode = Session["UserId"].ToString();

                        //  FillGrid();
                    }

                }

                if (str == "7")
                {
                    btnshow.Visible = false;
                    ddlSubCentre.Visible = true;
                    ddlCentreName.Visible = true;
                    lblSubCentre.Visible = true;
                    lblSubcentreCo.Visible = true;
                    lblCentre.Visible = true;
                    lblCentreCo.Visible = true;
                    ddlRM.Visible = false;
                    lblRM.Visible = false;
                    ddlCluster.Visible = true;
                    lblCentreCo.Visible = true;
                    lblClusterCo.Visible = true;
                    lblCluster.Visible = true;

                    lblcoRM.Visible = false;

                    DropDownList1.Visible = false;
                    Label1.Visible = false;
                    Label2.Visible = false;
                    IsRM = true;
                    if (!IsPostBack)
                    {

                        sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] where cluster_id=" + Session["ClusterId"].ToString() + " order by CENTRE_NAME";
                        ddlCentreName.DataBind();
                        //ddlCentreName.SelectedValue = Session["CentreID"].ToString();

                        sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + ddlCentreName.SelectedValue + " order by SubCentreName";
                        ddlSubCentre.DataBind();
                        //ddlSubCentre.SelectedValue = Session["SubCentreID"].ToString();
                        //  sdsRM.SelectCommand = "select distinct rm.RM_empcode as emp_code,rm.RM_empcode+' '+rm.RM_name as Fullname from RM_master rm join employee_master em on rm.RM_empcode=em.emp_code where em.emp_id='" + Session["UserId"].ToString() + "'";


                        string strEMP = "select distinct rm.RM_empcode as emp_code,rm.RM_empcode+' '+rm.RM_name as Fullname from RM_master rm join employee_master em on rm.RM_empcode=em.emp_code where em.emp_id='" + Session["UserId"].ToString() + "'";

                        object drEmp = OleDbHelper.ExecuteScalar(objConn.ConnectionString, CommandType.Text, strEMP);

                        string Empid = drEmp.ToString();


                        DE.SubCentreID = ddlSubCentre.SelectedValue;
                        DE.CentreID = ddlCentreName.SelectedValue;
                        DE.ClusterID = Session["ClusterId"].ToString();
                        DE.Emp_ID = Convert.ToString(Empid);
                        // DE.Emp_ID = "select emp_code from employee_master where emp_id='" + Session["Userid"].ToString() + "'";
                        //  FillGrid();
                    }
                }
                if (str == "22")
                {

                    if (!IsPostBack)
                    {
                        DE.SubCentreID = Session["SubCentreID"].ToString();
                        DE.CentreID = Session["CentreID"].ToString();
                        DE.ClusterID = Session["ClusterId"].ToString();
                        FillGrid();
                    }


                }
                if (str == "23")
                {
                    btnshow.Visible = false;
                    ddlSubCentre.Visible = true;
                    lblSubCentre.Visible = true;
                    lblSubcentreCo.Visible = true;


                    if (!IsPostBack)
                    {
                        sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + Session["CentreID"].ToString() + " order by SubCentreName";
                        ddlSubCentre.DataBind();
                        //ddlSubCentre.SelectedValue = Session["SubcentreID"].ToString();

                        DE.SubCentreID = ddlSubCentre.SelectedValue;
                        DE.CentreID = Session["CentreID"].ToString();
                        DE.ClusterID = Session["ClusterId"].ToString();

                        FillGrid();
                    }
                }
                if (str == "25")
                {
                    btnshow.Visible = false;
                    ddlSubCentre.Visible = true;
                    ddlCentreName.Visible = true;
                    lblSubCentre.Visible = true;
                    lblSubcentreCo.Visible = true;
                    lblCentre.Visible = true;
                    lblCentreCo.Visible = true;

                    if (!IsPostBack)
                    {

                        sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] where cluster_id=" + Session["ClusterId"].ToString() + " order by CENTRE_NAME";
                        ddlCentreName.DataBind();
                        //ddlCentreName.SelectedValue = Session["CentreID"].ToString();

                        sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + ddlCentreName.SelectedValue + " order by SubCentreName";
                        ddlSubCentre.DataBind();
                        //ddlSubCentre.SelectedValue = Session["SubCentreID"].ToString();

                        DE.SubCentreID = ddlSubCentre.SelectedValue;
                        DE.CentreID = ddlCentreName.SelectedValue;
                        DE.ClusterID = Session["ClusterId"].ToString();

                        FillGrid();
                    }
                }
                if (str == "24")
                {
                    btnshow.Visible = false;
                    ddlSubCentre.Visible = true;
                    ddlCentreName.Visible = true;
                    ddlCluster.Visible = true;
                    lblSubCentre.Visible = true;
                    lblSubcentreCo.Visible = true;
                    lblCentre.Visible = true;
                    lblCentreCo.Visible = true;
                    lblCluster.Visible = true;
                    lblClusterCo.Visible = true;

                    if (!IsPostBack)
                    {
                        ddlCluster.DataBind();
                        ddlCluster.SelectedValue = Session["ClusterId"].ToString();
                        sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] where cluster_id=" + ddlCluster.SelectedValue + " order by CENTRE_NAME";
                        ddlCentreName.DataBind();
                        //ddlCentreName.SelectedValue = Session["CentreId"].ToString();
                        sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + ddlCentreName.SelectedValue + " order by SubCentreName";
                        ddlSubCentre.DataBind();
                        //ddlSubCentre.SelectedValue = Session["SubcentreID"].ToString();

                        DE.ClusterID = ddlCluster.SelectedValue;
                        DE.CentreID = ddlCentreName.SelectedValue;
                        DE.SubCentreID = ddlSubCentre.SelectedValue;

                        FillGrid();
                    }

                }

                if (str == "2")
                {
                    btnshow.Visible = false;
                    ddlSubCentre.Visible = true;
                    ddlCentreName.Visible = true;
                    ddlCluster.Visible = true;
                    lblSubCentre.Visible = true;
                    lblSubcentreCo.Visible = true;
                    lblCentre.Visible = true;
                    lblCentreCo.Visible = true;
                    lblCluster.Visible = true;
                    lblClusterCo.Visible = true;

                    if (!IsPostBack)
                    {
                        ddlCluster.DataBind();
                        ddlCluster.SelectedValue = Session["ClusterId"].ToString();
                        sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] where cluster_id=" + ddlCluster.SelectedValue + " order by CENTRE_NAME";
                        ddlCentreName.DataBind();
                        //ddlCentreName.SelectedValue = Session["CentreId"].ToString();
                        sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + ddlCentreName.SelectedValue + " order by SubCentreName";
                        ddlSubCentre.DataBind();
                        //ddlSubCentre.SelectedValue = Session["SubcentreID"].ToString();

                        DE.ClusterID = ddlCluster.SelectedValue;
                        DE.CentreID = ddlCentreName.SelectedValue;
                        DE.SubCentreID = ddlSubCentre.SelectedValue;

                        FillGrid();
                    }

                }



            }
            //
            string strEMPem = "select Emp_code from Employee_master  where EMP_ID=" +
                           Session["USERID"] + "";

            object drEmpem = OleDbHelper.ExecuteScalar(objConn.ConnectionString, CommandType.Text, strEMPem);

            if (IsRM == true && IsRSM == false && admin == false)
            {
                DE.Emp_ID = (ddlRM.Visible == true && ddlRM.SelectedValue != "0") ? ddlRM.SelectedValue : drEmpem.ToString();
            }
            else if (admin == false && IsRM == false && IsRSM == true)
            {
                DE.RSM_EMPCode = (admin == false && DropDownList1.Visible == true && DropDownList1.SelectedValue != "0") ? DropDownList1.SelectedValue : drEmpem.ToString();
            }
            else if (IsRSM == true && IsRM == true)
            {
                DE.RSM_EMPCode = DropDownList1.SelectedValue;
            }
            //DE.FromDate = txtRequestFromDate.Text;
            //DE.ToDate = TextBox2.Text;
            if (admin == true)
            {
                DE.Admin_EMPCODE = drEmpem.ToString();
                DE.RSM_EMPCode = DropDownList1.SelectedValue;
            }


            /////
            DE.Date = txtRequestFromDate.Text;
            DE.SubCentreID = ddlSubCentre.SelectedValue;
            DE.CentreID = Session["CentreID"].ToString();
            DataSet dsHier = new DataSet();
            dsHier = DE.GetHier();
            string strHier = "";
            if (ddlSubCentre.SelectedIndex != 0)
            {
                if (dsHier.Tables[0].Columns.Count == 3)
                {
                    strHier = dsHier.Tables[0].Rows[0]["cluster_name"].ToString() + "-" + dsHier.Tables[0].Rows[0]["CENTRE_NAME"].ToString() + "-" + dsHier.Tables[0].Rows[0]["SubCentreName"].ToString();
                }
                else
                    strHier = dsHier.Tables[0].Rows[0]["cluster_name"].ToString() + "-" + dsHier.Tables[0].Rows[0]["CENTRE_NAME"].ToString();
                lblHierChichy.Text = strHier;
            }
            lblDate.Text = "Attendance Entry  For The Date - " + System.DateTime.Now.ToString("dd/MM/yyyy") + "";
            string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
            string str1 = strTime.Remove(2);
            string str2 = strTime.Remove(0, 3);
            if ((Convert.ToInt32(str1) <= 12))
            {
                if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() != "Sunday")
                {

                    lblDate.Text = "Attendance Entry  For The Date - " + System.DateTime.Now.ToString("dd/MM/yyyy") + "";
                    //lblDate.Text = "Attendance Entry  For  Date - " + System.DateTime.Now.ToString("dd/MM/yyyy") + " and " + System.DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy") + "";

                }
                else
                    //lblDate.Text = "Attendance Entry  For  Date - " + System.DateTime.Now.ToString("dd/MM/yyyy") + " and " + System.DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy") + "";
                    lblDate.Text = "Attendance Entry  For The Date - " + System.DateTime.Now.ToString("dd/MM/yyyy") + "";


            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        } 
    }
    public void FillGrid()
    {
        if (txtRequestFromDate.Text != null && txtRequestFromDate.Text !="")
        {
            string strdate = Convert.ToDateTime(txtRequestFromDate.Text).Day.ToString();
            strDay = Convert.ToDateTime(txtRequestFromDate.Text).DayOfWeek.ToString();

            string strPredate = Convert.ToDateTime(txtRequestFromDate.Text).AddDays(-1).Day.ToString();
            strPreDay = Convert.ToDateTime(txtRequestFromDate.Text).AddDays(-1).DayOfWeek.ToString();

            string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
            string str = strTime.Remove(2);
            string str1 = strTime.Remove(0, 3);

            string strHeaderText = strdate + "-" + strDay;
            string strPreHeaderText = strPredate + "-" + strPreDay;
            GVDE.Columns[6].HeaderText = strPreHeaderText;
            GVDE.Columns[6].Visible = false;

            GVDE.Columns[7].HeaderText = strHeaderText;

            if (txtEmpCode.Text.Trim() != "")
            {
                DE.EMPCODE = txtEmpCode.Text.Trim();
            }
            if (txtEmpName.Text.Trim() != "")
            {
                DE.EMPNAME = txtEmpName.Text.Trim().Replace(' ', '%');
            }
        }
        else
        {
            string strdate = System.DateTime.Now.Day.ToString();
            strDay = System.DateTime.Now.DayOfWeek.ToString();

            string strPredate = System.DateTime.Now.AddDays(-1).Day.ToString();
            strPreDay = System.DateTime.Now.AddDays(-1).DayOfWeek.ToString();

            string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
            string str = strTime.Remove(2);
            string str1 = strTime.Remove(0, 3);

            string strHeaderText = strdate + "-" + strDay;
            string strPreHeaderText = strPredate + "-" + strPreDay;
            GVDE.Columns[6].HeaderText = strPreHeaderText;
            GVDE.Columns[6].Visible = false;

            GVDE.Columns[7].HeaderText = strHeaderText;

            if (txtEmpCode.Text.Trim() != "")
            {
                DE.EMPCODE = txtEmpCode.Text.Trim();
            }
            if (txtEmpName.Text.Trim() != "")
            {
                DE.EMPNAME = txtEmpName.Text.Trim().Replace(' ', '%');
            }
        }
        DataSet ds = new DataSet();
        ds = DE.Fill_Grid1();
        ViewState["v1"] = ds;
        DataSet ds1 = new DataSet();
        ds1 = DE.GetToDayAttenance2();
        ViewState["v2"] = ds1;
        GVDE.DataSource = ds;



        GVDE.DataBind();
        if (GVDE.Rows.Count <= 0)
        {
            lblMsg.Text = "No record found.";
            lblMsg.Visible = true;
            btnSave.Visible = false;
            imgntnsave.Visible = false;

        }

        if (GVDE.Rows.Count > 0)
        {

            lblMsg.Visible = false;
            btnSave.Visible = false;
            imgntnsave.Visible = true;
        }

        ds.Dispose();
        ds1.Dispose();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ArrayList AlistEmp = new ArrayList();
            ArrayList AlistAtten = new ArrayList();
            ArrayList AlistPreAtten = new ArrayList();


            string AlistCreBy = "";
            DateTime AlistCreDate;
            //string AlistModBy = "";
            //DateTime AlistModDate;
            AlistCreBy = Session["UserId"].ToString();
            AlistCreDate = DateTime.Now;
            //AlistModBy = Session["UserId"].ToString();
            //AlistModDate = DateTime.Now;


            foreach (GridViewRow row in GVDE.Rows)
            {
                HiddenField hidID = (HiddenField)row.FindControl("hidEmpID");
                DropDownList ddlID = (DropDownList)row.FindControl("ddl");

                DropDownList ddlID1 = (DropDownList)row.FindControl("Preddl");
                AlistEmp.Add(hidID.Value);
                AlistAtten.Add(ddlID.SelectedValue);
                AlistPreAtten.Add(ddlID1.SelectedValue);
            }
            if (GVDE.Columns[7].Visible == true)
            {
                DE.ColumnFlag = true;
            }
            DE.InsertAttendence2(AlistEmp, AlistAtten, AlistPreAtten, AlistCreBy, AlistCreDate);
            if (ddlCluster.Visible == true && ddlCentreName.Visible == true && ddlSubCentre.Visible == true)
            {
                DE.ClusterID = ddlCluster.SelectedValue;
                DE.CentreID = ddlCentreName.SelectedValue;
                DE.SubCentreID = ddlSubCentre.SelectedValue;

            }
            else if (ddlCentreName.Visible == true && ddlSubCentre.Visible == true)
            {
                DE.CentreID = ddlCentreName.SelectedValue;
                DE.SubCentreID = ddlSubCentre.SelectedValue;
                DE.ClusterID = Session["ClusterId"].ToString();
            }
            else if (ddlSubCentre.Visible == true)
            {
                DE.SubCentreID = ddlSubCentre.SelectedValue;
                DE.CentreID = Session["CentreId"].ToString();
                DE.ClusterID = Session["ClusterId"].ToString();
            }
            else
            {
                DE.SubCentreID = Session["SubcentreID"].ToString();
                DE.CentreID = Session["CentreId"].ToString();
                DE.ClusterID = Session["ClusterId"].ToString();
            }
            FillGrid();
            lblMsg.Visible = true;
            lblMsg.Text = DE.Message;

        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message;
        }
    }
    protected void GVDE_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowIndex != -1)
            {
                DataSet ds1 = new DataSet();

                DataSet ds2 = new DataSet();
                ds1 = (DataSet)ViewState["v1"];
                ds2 = (DataSet)ViewState["v2"];
                DropDownList ddlID = ((DropDownList)(e.Row.FindControl("ddl")));
                DropDownList PreddlID = ((DropDownList)(e.Row.FindControl("Preddl")));
                HiddenField hidID = ((HiddenField)(e.Row.FindControl("hidEmpID")));

                if ((ds2.Tables[0].Rows.Count) > 0)
                {
                    DataRow[] dr = ds2.Tables[0].Select("emp_id='" + hidID.Value + "'");
                    PreddlID.SelectedValue = dr[0]["ATTENDANCE"].ToString();
                    if ((PreddlID.SelectedValue == "P") || (PreddlID.SelectedValue == "A"))
                    {
                        PreddlID.Items.Remove("U");
                        PreddlID.Enabled = false;
                    }

                }


                if (ds1.Tables[0].Columns.Count == 9)
                {


                    DataRow[] dr1 = ds1.Tables[0].Select("emp_id='" + hidID.Value + "'");
                    if ((ds1.Tables[0].Rows.Count) > 0)
                    {
                        ddlID.SelectedValue = dr1[0]["ATTENDANCE"].ToString();


                        if ((ddlID.SelectedValue == "P") || (ddlID.SelectedValue == "A"))
                        {
                            ddlID.Items.Remove("U");
                            ddlID.Enabled = false;

                        }
                    }
                }

                if (e.Row.RowIndex == GVDE.Rows.Count)
                {
                    ds1.Dispose();
                    ds2.Dispose();
                }

            }
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message;
        }
    }
    protected void ddlSubCentre_DataBound(object sender, EventArgs e)
    {
        ddlSubCentre.Items.Insert(0, new ListItem("--All--", "0"));

    }
    protected void ddlCluster_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCluster.SelectedIndex == 0)
            {
                sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] order by CENTRE_NAME ";
                ddlCentreName.DataBind();
            }
            else
            {
                sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] WHERE ([CLUSTER_ID] = " + ddlCluster.SelectedValue + ") order by CENTRE_NAME";
                ddlCentreName.DataBind();
            }
            if (ddlCentreName.SelectedIndex == 0)
            {
                string strRole = Session["RoleID"].ToString();
                string[] strRole1 = strRole.Split(',');


                foreach (string str in strRole1)
                {
                    if (str == "25")
                    {
                        sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where ClusterID=" + Session["ClusterId"].ToString() + " order by SubCentreName";
                    }
                    if (str == "24")
                    {
                        sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster  order by SubCentreName";

                    }
                }
                ddlSubCentre.DataBind();
            }
            else
            {
                sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + ddlCentreName.SelectedValue + " order by SubCentreName";
                ddlSubCentre.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void ddlCentreName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCluster.Visible == true)
            {
                if (ddlCentreName.SelectedIndex == 0)
                {
                    sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster order by SubCentreName  ";
                    ddlSubCentre.DataBind();
                }
                else
                {
                    sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + ddlCentreName.SelectedValue + " order by SubCentreName";
                    ddlSubCentre.DataBind();
                }
            }
            else
            {
                sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where ClusterId ='" + Session["ClusterID"] + "' order by SubCentreName   ";
                ddlSubCentre.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void ddlCentreName_DataBound(object sender, EventArgs e)
    {
        ddlCentreName.Items.Insert(0, new ListItem("--All--", "0"));
    }
    protected void ddlCluster_DataBound(object sender, EventArgs e)
    {
        ddlCluster.Items.Insert(0, new ListItem("--All--", "0"));
    }

    protected void btnshow_Click(object sender, EventArgs e)
    {

    }
    protected void GVDE_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVDE.PageIndex = e.NewPageIndex;
        if (ddlCluster.Visible == true && ddlCentreName.Visible == true && ddlSubCentre.Visible == true)
        {
            DE.ClusterID = ddlCluster.SelectedValue;
            DE.CentreID = ddlCentreName.SelectedValue;
            DE.SubCentreID = ddlSubCentre.SelectedValue;

        }
        else if (ddlCentreName.Visible == true && ddlSubCentre.Visible == true)
        {
            DE.CentreID = ddlCentreName.SelectedValue;
            DE.SubCentreID = ddlSubCentre.SelectedValue;
            DE.ClusterID = Session["ClusterId"].ToString();
        }
        else if (ddlSubCentre.Visible == true)
        {
            DE.SubCentreID = ddlSubCentre.SelectedValue;
            DE.CentreID = Session["CentreId"].ToString();
            DE.ClusterID = Session["ClusterId"].ToString();
        }
        else
        {
            DE.SubCentreID = Session["SubcentreID"].ToString();
            DE.CentreID = Session["CentreId"].ToString();
            DE.ClusterID = Session["ClusterId"].ToString();
        }
        FillGrid();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (ddlCluster.Visible == true && ddlCentreName.Visible == true && ddlSubCentre.Visible == true)
        {
            DE.ClusterID = ddlCluster.SelectedValue;
            DE.CentreID = ddlCentreName.SelectedValue;
            DE.SubCentreID = ddlSubCentre.SelectedValue;

        }
        else if (ddlCentreName.Visible == true && ddlSubCentre.Visible == true)
        {
            DE.CentreID = ddlCentreName.SelectedValue;
            DE.SubCentreID = ddlSubCentre.SelectedValue;
            DE.ClusterID = Session["ClusterId"].ToString();
        }
        else if (ddlSubCentre.Visible == true)
        {
            DE.SubCentreID = ddlSubCentre.SelectedValue;
            DE.CentreID = Session["CentreId"].ToString();
            DE.ClusterID = Session["ClusterId"].ToString();
        }
        else
        {
            DE.SubCentreID = Session["SubcentreID"].ToString();
            DE.CentreID = Session["CentreId"].ToString();
            DE.ClusterID = Session["ClusterId"].ToString();
        }
        FillGrid();
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ArrayList AlistEmp = new ArrayList();
            ArrayList AlistAtten = new ArrayList();
            ArrayList AlistPreAtten = new ArrayList();


            string AlistCreBy = "";
            DateTime AlistCreDate;
            //string AlistModBy = "";
            //DateTime AlistModDate;
            AlistCreBy = Session["UserId"].ToString();
            AlistCreDate = DateTime.Now;
            //AlistModBy = Session["UserId"].ToString();
            //AlistModDate = DateTime.Now;


            foreach (GridViewRow row in GVDE.Rows)
            {
                HiddenField hidID = (HiddenField)row.FindControl("hidEmpID");
                DropDownList ddlID = (DropDownList)row.FindControl("ddl");

                DropDownList ddlID1 = (DropDownList)row.FindControl("Preddl");
                AlistEmp.Add(hidID.Value);
                AlistAtten.Add(ddlID.SelectedValue);
                AlistPreAtten.Add(ddlID1.SelectedValue);
            }
            if (GVDE.Columns[6].Visible == true)
            {
                DE.ColumnFlag = true;
            }
            DE.InsertAttendence2(AlistEmp, AlistAtten, AlistPreAtten, AlistCreBy, AlistCreDate);
            if (ddlCluster.Visible == true && ddlCentreName.Visible == true && ddlSubCentre.Visible == true)
            {
                DE.ClusterID = ddlCluster.SelectedValue;
                DE.CentreID = ddlCentreName.SelectedValue;
                DE.SubCentreID = ddlSubCentre.SelectedValue;

            }
            else if (ddlCentreName.Visible == true && ddlSubCentre.Visible == true)
            {
                DE.CentreID = ddlCentreName.SelectedValue;
                DE.SubCentreID = ddlSubCentre.SelectedValue;
                DE.ClusterID = Session["ClusterId"].ToString();
            }
            else if (ddlSubCentre.Visible == true)
            {
                DE.SubCentreID = ddlSubCentre.SelectedValue;
                DE.CentreID = Session["CentreId"].ToString();
                DE.ClusterID = Session["ClusterId"].ToString();
            }
            else
            {
                DE.SubCentreID = Session["SubcentreID"].ToString();
                DE.CentreID = Session["CentreId"].ToString();
                DE.ClusterID = Session["ClusterId"].ToString();
            }
            FillGrid();
            lblMsg.Visible = true;
            lblMsg.Text = DE.Message;

        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message;
        }
    }

    protected void ddlRM_DataBound2(object sender, EventArgs e)
    {
        ddlRM.Items.Insert(0, new ListItem("--All--", "0"));


    }
    protected void DropDownList1_DataBound(object sender, EventArgs e)
    {
        DropDownList1.Items.Insert(0, new ListItem("--All--", "0"));
    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        sdsRM.SelectCommand = "select distinct rm.RM_empcode as emp_code,rm.RM_empcode+' '+rm.RM_name as Fullname from RM_master rm join  RSM_master rsm on rsm.RSM_empcode=rm.RsM_empcode join employee_master em on rsm.RsM_empcode=em.emp_code where em.emp_code='" + DropDownList1.SelectedValue + "'";
        ddlRM.DataBind();
    }
}
