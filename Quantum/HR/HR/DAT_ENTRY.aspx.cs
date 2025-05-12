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

public partial class HR_HR_DAT_ENTRY : System.Web.UI.Page
{
    DAT_ENTRY DE = new DAT_ENTRY();
    DataSet ds = new DataSet();
    string strDay = "";
    string strPreDay = "";
    string str = "";

    CCommon objConn = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        bool admin = false;
        bool IsRM = false;
        bool IsRSM = false;


        sdsSubCentre.ConnectionString = objConn.ConnectionString;  //Sir
        sdsCentre.ConnectionString = objConn.ConnectionString;  //Sir
        sdsCluster.ConnectionString = objConn.ConnectionString;
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

                if (str == "11")
                {

                    if (!IsPostBack)
                    {
                        DE.SubCentreID = Session["SubCentreID"].ToString();
                        DE.CentreID = Session["CentreID"].ToString();
                        DE.ClusterID = Session["ClusterId"].ToString();
                        //  FillGrid();
                    }


                }
                //if (str == "7")
                //{
                //    btnshow.Visible =false;
                //    ddlSubCentre.Visible = true;
                //    lblSubCentre.Visible = true;
                //    lblSubcentreCo.Visible = true;


                //    if (!IsPostBack)
                //    {
                //        sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + Session["CentreID"].ToString() + " order by SubCentreName";
                //        ddlSubCentre.DataBind();
                //        //ddlSubCentre.SelectedValue = Session["SubcentreID"].ToString();

                //        DE.SubCentreID = ddlSubCentre.SelectedValue;
                //        DE.CentreID = Session["CentreID"].ToString();
                //        DE.ClusterID = Session["ClusterId"].ToString();

                //        FillGrid();
                //    }
                //}
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
                //if (str == "7")
                //{
                //    btnshow.Visible =false;
                //    ddlSubCentre.Visible = true;
                //    ddlCentreName.Visible = true;
                //    ddlCluster.Visible = true;
                //    lblSubCentre.Visible = true;
                //    lblSubcentreCo.Visible = true;
                //    lblCentre.Visible = true;
                //    lblCentreCo.Visible = true;
                //    lblCluster.Visible = true;
                //    lblClusterCo.Visible = true;

                //    if (!IsPostBack)
                //    {
                //        ddlCluster.DataBind();
                //        ddlCluster.SelectedValue = Session["ClusterId"].ToString();
                //        sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] where cluster_id=" + ddlCluster.SelectedValue + " order by CENTRE_NAME";
                //        ddlCentreName.DataBind();
                //        //ddlCentreName.SelectedValue = Session["CentreId"].ToString();
                //        sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + ddlCentreName.SelectedValue + " order by SubCentreName";
                //        ddlSubCentre.DataBind();
                //        //ddlSubCentre.SelectedValue = Session["SubcentreID"].ToString();

                //        DE.ClusterID = ddlCluster.SelectedValue;
                //        DE.CentreID = ddlCentreName.SelectedValue;
                //        DE.SubCentreID = ddlSubCentre.SelectedValue;

                //        FillGrid();
                //    }

                //}

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
                    ddlRM.Visible = true;
                    lblRM.Visible = true;
                    DropDownList1.Visible = true;
                    Label1.Visible = true;
                    Label2.Visible = true;
                    imgntnsave.Enabled = false;


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
            }
            string strEMPem = "select Emp_code from Employee_master  where EMP_ID=" +
                             Session["USERID"] + "";

            object drEmpem = OleDbHelper.ExecuteScalar(objConn.ConnectionString, CommandType.Text, strEMPem);

            DE.SubCentreID = ddlSubCentre.SelectedValue;
            DE.CentreID = Session["CentreID"].ToString();
            if (IsRM == true && IsRSM == false && admin == false)
            {
                DE.Emp_ID = (ddlRM.Visible == true && ddlRM.SelectedValue != "0") ? ddlRM.SelectedValue : drEmpem.ToString();
            }
            else if (admin == false && IsRM == false && IsRSM == true)
            {
                DE.RSM_EMPCode = (admin == false && DropDownList1.Visible == true && DropDownList1.SelectedValue != "0") ? DropDownList1.SelectedValue : drEmpem.ToString();
                DE.Emp_ID = ddlRM.SelectedValue;
            }
            else if (IsRSM == true && IsRM == true)
            {
                DE.RSM_EMPCode = DropDownList1.SelectedValue;
            }
            DE.FromDate = txtRequestFromDate.Text;
            DE.ToDate = TextBox2.Text;
            if (admin == true)
            {
                DE.Admin_EMPCODE = drEmpem.ToString();
                DE.RSM_EMPCode = DropDownList1.SelectedValue;
                DE.Emp_ID = ddlRM.SelectedValue;
            }
            if (IsRM == true)
            {
                string sql = "select top 1  da.date from employee_master em inner join Datily_attendance da on em.emp_id =da.emp_id where em.rm_empcode='" + DE.Emp_ID + "' order by date desc";
                object dr = OleDbHelper.ExecuteScalar(objConn.ConnectionString, CommandType.Text, sql);
                if (dr != null)
                {
                    string dte = dr.ToString();
                    LabelMsg.Text = "Attendance Last Updated On " + Convert.ToDateTime(dte).ToString("dd-MM-yyyy") + " ";
                }
                else
                {
                    LabelMsg.Text = "None of the Attendance is  marked By this SM";
                }


            }

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
        TimeSpan d = TimeSpan.Zero;
        string DateDiff = "0";
        int icount = 15;
        if (DE.ToDate != "" && DE.FromDate != "")
            d = Convert.ToDateTime(DateTime.ParseExact(DE.ToDate, "dd/MM/yyyy", null)) - Convert.ToDateTime(DateTime.ParseExact(DE.FromDate, "dd/MM/yyyy", null));
        DateDiff = Convert.ToInt32(d.TotalDays).ToString();
        //Convert.ToString(Convert.ToDateTime(DE.ToDate).Date.Day - Convert.ToDateTime(DE.FromDate).Date.Day);
        if (Convert.ToInt32(DateDiff) > 15)
        {
            lblMsg.Text = "Only DateRange for 15 Days are allowed";
            for (int i = icount - 1; i >= 0; i--)
            // for (int i = 0; i < icount; i++)
            {
                string strPredate = System.DateTime.Now.AddDays(-i).Day.ToString();
                strPreDay = System.DateTime.Now.AddDays(-i).DayOfWeek.ToString().Substring(0, 3);

                string strPreHeaderText = strPredate + "-" + strPreDay;
                GVDE.Columns[6 + (14 - i)].HeaderText = strPreHeaderText;
                GVDE.Columns[6 + (14 - i)].Visible = true;
            }

            for (int i = icount; i < 15; i++)
            {
                GVDE.Columns[6 + (14 - i)].Visible = false;
            }

            string strdate = System.DateTime.Now.Day.ToString();
            strDay = System.DateTime.Now.DayOfWeek.ToString();

            //string strPredate = System.DateTime.Now.AddDays(-1).Day.ToString();
            //        strPreDay = System.DateTime.Now.AddDays(-1).DayOfWeek.ToString();

            string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
            string str = strTime.Remove(2);
            string str1 = strTime.Remove(0, 3);
        }
        if (DateDiff != "0" && Convert.ToInt32(DateDiff) < 15 && Convert.ToDateTime(DateTime.ParseExact(DE.ToDate, "dd/MM/yyyy", null)).Date > System.DateTime.Now.Date)
        {
            DateDiff = Convert.ToString(System.DateTime.Now.Day - Convert.ToDateTime(DateTime.ParseExact(DE.FromDate, "dd/MM/yyyy", null)).Date.Day);
            icount = Convert.ToInt32(DateDiff) + 1;
            if (icount < 15)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Kindly select Date range properly ToDate is more Than today's date.Choose fromdate " + Convert.ToDateTime(System.DateTime.Now.AddDays(-14)).ToString("dd/MM/yyyy") + " ";
                return;
            }
            for (int i = icount - 1; i >= 0; i--)
            // for (int i = 0; i < icount; i++)
            {
                string strPredate = System.DateTime.Now.AddDays(-i).Day.ToString();
                strPreDay = System.DateTime.Now.AddDays(-i).DayOfWeek.ToString().Substring(0, 3);

                string strPreHeaderText = strPredate + "-" + strPreDay;
                GVDE.Columns[6 + (14 - i)].HeaderText = strPreHeaderText;
                GVDE.Columns[6 + (14 - i)].Visible = true;
            }

            for (int i = icount; i < 15; i++)
            {
                GVDE.Columns[6 + (14 - i)].Visible = false;
            }

            string strdate = System.DateTime.Now.Day.ToString();
            strDay = System.DateTime.Now.DayOfWeek.ToString();

            //string strPredate = System.DateTime.Now.AddDays(-1).Day.ToString();
            //        strPreDay = System.DateTime.Now.AddDays(-1).DayOfWeek.ToString();

            string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
            string str = strTime.Remove(2);
            string str1 = strTime.Remove(0, 3);

        }

        else if (DateDiff != "0" && Convert.ToInt32(DateDiff) < 15)
        {
            icount = Convert.ToInt32(DateDiff) + 1;
            for (int i = icount - 1; i >= 0; i--)
            // for (int i = 0; i < icount; i++)
            {
                string strPredate = Convert.ToDateTime(DateTime.ParseExact(DE.ToDate, "dd/MM/yyyy", null)).AddDays(-i).Day.ToString();
                strPreDay = Convert.ToString(Convert.ToDateTime(DateTime.ParseExact(DE.ToDate, "dd/MM/yyyy", null)).AddDays(-i).DayOfWeek.ToString().Substring(0, 3));

                string strPreHeaderText = strPredate + "-" + strPreDay;
                GVDE.Columns[6 + (14 - i)].HeaderText = strPreHeaderText;
                GVDE.Columns[6 + (14 - i)].Visible = true;
            }
            for (int i = icount; i < 15; i++)
            {
                GVDE.Columns[6 + (14 - i)].Visible = false;


            }

        }
        else
        {
            for (int i = icount - 1; i >= 0; i--)
            {
                string strPredate = System.DateTime.Now.AddDays(-i).Day.ToString();
                strPreDay = System.DateTime.Now.AddDays(-i).DayOfWeek.ToString().Substring(0, 3);

                string strPreHeaderText = strPredate + "-" + strPreDay;

                GVDE.Columns[6 + (14 - i)].HeaderText = strPreHeaderText;
                GVDE.Columns[6 + (14 - i)].Visible = true;
            }

            //  for (int i = 0; i < icount; i++)
            //{
            //    string strPredate = System.DateTime.Now.AddDays(-i).Day.ToString();
            //    strPreDay = System.DateTime.Now.AddDays(-i).DayOfWeek.ToString().Substring(0, 3);

            //    string strPreHeaderText = strPredate + "-" + strPreDay;
            //    GVDE.Columns[6 + i].HeaderText = strPreHeaderText;
            //    GVDE.Columns[6 + i].Visible = true;
            //}

            for (int i = icount; i < 15; i++)
            {
                GVDE.Columns[6 + (14 - i)].Visible = false;
            }

            string strdate = System.DateTime.Now.Day.ToString();
            strDay = System.DateTime.Now.DayOfWeek.ToString();

            //string strPredate = System.DateTime.Now.AddDays(-1).Day.ToString();
            //        strPreDay = System.DateTime.Now.AddDays(-1).DayOfWeek.ToString();

            string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
            string str = strTime.Remove(2);
            string str1 = strTime.Remove(0, 3);
        }

        //string strHeaderText = strdate + "-" + strDay;
        //string strPreHeaderText = strPredate + "-" + strPreDay;
        //GVDE.Columns[7].HeaderText = strPreHeaderText;
        //GVDE.Columns[7].Visible = false;

        //GVDE.Columns[8].HeaderText = strHeaderText;

        if (txtEmpCode.Text.Trim() != "")
        {
            DE.EMPCODE = txtEmpCode.Text.Trim();
        }
        if (txtEmpName.Text.Trim() != "")
        {
            DE.EMPNAME = txtEmpName.Text.Trim().Replace(' ', '%');
        }
        DataSet ds = new DataSet();
        ds = DE.Fill_Grid();
        ViewState["v1"] = ds;
        DataSet ds1 = new DataSet();
        //if (DE.Emp_ID != "" && DE.Emp_ID != null)
        //{
        //    ds1 = DE.GetToDayAttenance1();
        //}
        //else
        //{
        ds1 = DE.GetToDayAttenance();
        //}

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
    //public void FillGrid()
    //{
    //  string DateDiff ="0";
    //    int icount = 15;
    //    if(DE.ToDate !="" && DE.FromDate !="")
    //        DateDiff = Convert.ToString(Convert.ToDateTime(DE.ToDate).Date.Day - Convert.ToDateTime(DE.FromDate).Date.Day);
    //    if (Convert.ToInt32(DateDiff) > 15)
    //    {
    //        lblMsg.Text = "Only DateRange for 15 Days are allowed";
    //       for (int i = 0; i < icount; i++)
    //        {
    //            string strPredate = System.DateTime.Now.AddDays(-i).Day.ToString();
    //            strPreDay = System.DateTime.Now.AddDays(-i).DayOfWeek.ToString().Substring(0, 3);

    //            string strPreHeaderText = strPredate + "-" + strPreDay;
    //            GVDE.Columns[6 + i].HeaderText = strPreHeaderText;
    //            GVDE.Columns[6 + i].Visible = true;
    //        }

    //        for (int i = icount; i < 15; i++)
    //        {
    //            GVDE.Columns[6 + i].Visible = false;
    //        }

    //        string strdate = System.DateTime.Now.Day.ToString();
    //        strDay = System.DateTime.Now.DayOfWeek.ToString();

    //        //string strPredate = System.DateTime.Now.AddDays(-1).Day.ToString();
    //        //        strPreDay = System.DateTime.Now.AddDays(-1).DayOfWeek.ToString();

    //        string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
    //        string str = strTime.Remove(2);
    //        string str1 = strTime.Remove(0, 3);
    //    }
    //    if (DateDiff != "0" && Convert.ToInt32(DateDiff) < 15 && Convert.ToDateTime(DE.ToDate).Date > System.DateTime.Now.Date )
    //    {
    //        DateDiff = Convert.ToString(System.DateTime.Now.Day - Convert.ToDateTime(DE.FromDate).Date.Day);
    //        icount = Convert.ToInt32(DateDiff) + 1;
    //        for (int i = 0; i < icount; i++)
    //        {
    //            string strPredate = System.DateTime.Now.AddDays(-i).Day.ToString();
    //            strPreDay = System.DateTime.Now.AddDays(-i).DayOfWeek.ToString().Substring(0, 3);

    //            string strPreHeaderText = strPredate + "-" + strPreDay;
    //            GVDE.Columns[6 + i].HeaderText = strPreHeaderText;
    //            GVDE.Columns[6 + i].Visible = true;
    //        }

    //        for (int i = icount; i < 15; i++)
    //        {
    //            GVDE.Columns[6 + i].Visible = false;
    //        }

    //        string strdate = System.DateTime.Now.Day.ToString();
    //        strDay = System.DateTime.Now.DayOfWeek.ToString();

    //        //string strPredate = System.DateTime.Now.AddDays(-1).Day.ToString();
    //        //        strPreDay = System.DateTime.Now.AddDays(-1).DayOfWeek.ToString();

    //        string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
    //        string str = strTime.Remove(2);
    //        string str1 = strTime.Remove(0, 3);

    //    }

    //    else  if (DateDiff != "0" && Convert.ToInt32(DateDiff) < 15)
    //    {
    //        icount = Convert.ToInt32(DateDiff)+1;
    //        for (int i = 0; i < icount; i++)
    //        {
    //            string strPredate =Convert.ToDateTime(DE.ToDate).AddDays(-i).Day.ToString();
    //            strPreDay =Convert.ToString(Convert.ToDateTime(DE.ToDate).AddDays(-i).DayOfWeek.ToString().Substring(0, 3));

    //            string strPreHeaderText = strPredate + "-" + strPreDay;
    //            GVDE.Columns[6 + i].HeaderText = strPreHeaderText;
    //            GVDE.Columns[6 + i].Visible = true;
    //        }
    //        for (int i = icount; i < 15 ; i++)
    //        {
    //            GVDE.Columns[6 + i].Visible = false;
    //        }

    //    }
    //   else
    //    {

    //   for (int i = 0; i < icount; i++)
    //    {
    //        string strPredate = System.DateTime.Now.AddDays(-i).Day.ToString();
    //        strPreDay = System.DateTime.Now.AddDays(-i).DayOfWeek.ToString().Substring(0, 3);

    //        string strPreHeaderText = strPredate + "-" + strPreDay;
    //        GVDE.Columns[6 + i].HeaderText = strPreHeaderText;
    //        GVDE.Columns[6 + i].Visible = true;
    //    }

    //    for (int i = icount; i < 15; i++)
    //    {
    //        GVDE.Columns[6 + i].Visible = false;
    //    }

    //    string strdate = System.DateTime.Now.Day.ToString();
    //    strDay = System.DateTime.Now.DayOfWeek.ToString();

    //    //string strPredate = System.DateTime.Now.AddDays(-1).Day.ToString();
    //    //        strPreDay = System.DateTime.Now.AddDays(-1).DayOfWeek.ToString();

    //    string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
    //    string str = strTime.Remove(2);
    //    string str1 = strTime.Remove(0, 3);
    //    }

    //    //string strHeaderText = strdate + "-" + strDay;
    //    //string strPreHeaderText = strPredate + "-" + strPreDay;
    //    //GVDE.Columns[7].HeaderText = strPreHeaderText;
    //    //GVDE.Columns[7].Visible = false;

    //    //GVDE.Columns[8].HeaderText = strHeaderText;

    //    if (txtEmpCode.Text.Trim() != "")
    //    {
    //        DE.EMPCODE = txtEmpCode.Text.Trim();
    //    }
    //    if (txtEmpName.Text.Trim() != "")
    //    {
    //        DE.EMPNAME = txtEmpName.Text.Trim().Replace(' ', '%');
    //    }
    //    DataSet ds = new DataSet();
    //    ds = DE.Fill_Grid();
    //    ViewState["v1"] = ds;
    //    DataSet ds1 = new DataSet();
    //    //if (DE.Emp_ID != "" && DE.Emp_ID != null)
    //    //{
    //    //    ds1 = DE.GetToDayAttenance1();
    //    //}
    //    //else
    //    //{
    //        ds1 = DE.GetToDayAttenance();
    //    //}

    //    ViewState["v2"] = ds1;
    //    GVDE.DataSource = ds;



    //    GVDE.DataBind();
    //    if (GVDE.Rows.Count <= 0)
    //    {
    //        lblMsg.Text = "No record found.";
    //        lblMsg.Visible = true;
    //        btnSave.Visible = false;
    //        imgntnsave.Visible = false;

    //    }

    //    if (GVDE.Rows.Count > 0)
    //    {

    //        lblMsg.Visible = false;
    //        btnSave.Visible = false;
    //        imgntnsave.Visible = true;
    //    }

    //    ds.Dispose();
    //    ds1.Dispose();
    //}
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ArrayList AlistEmp = new ArrayList();
            ArrayList AlistAtten = new ArrayList();
            ArrayList AlistPreAtten = new ArrayList();


            string AlistCreBy = "";
            DateTime AlistCreDate;

            AlistCreBy = Session["UserId"].ToString();
            AlistCreDate = DateTime.Now;

            int icount = 4;
            for (int i = 1; i < icount; i++)
            {
                foreach (GridViewRow row in GVDE.Rows)
                {
                    string ddlname = "ddl" + i;
                    HiddenField hidID = (HiddenField)row.FindControl("hidEmpID");
                    DropDownList ddlID = (DropDownList)row.FindControl(ddlname);
                    // DropDownList ddlID1 = (DropDownList)row.FindControl("Preddl");
                    AlistEmp.Add(hidID.Value);
                    AlistAtten.Add(ddlID.SelectedValue);
                    // AlistPreAtten.Add(ddlID1.SelectedValue);
                }
                if (GVDE.Columns[7].Visible == true)
                {
                    DE.ColumnFlag = true;
                }
                // DE.InsertAttendence(AlistEmp, AlistAtten, AlistAtten, AlistCreBy, AlistCreDate);

            }



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
            TimeSpan d = TimeSpan.Zero;

            if (DE.ToDate != "" && DE.FromDate != "")
                d = Convert.ToDateTime(DateTime.ParseExact(DE.ToDate, "dd/MM/yyyy", null)) - Convert.ToDateTime(DateTime.ParseExact(DE.FromDate, "dd/MM/yyyy", null));
            int Diff = Convert.ToInt32(d.TotalDays);
            if (e.Row.RowIndex != -1)
            {
                DataSet ds1 = new DataSet();

                DataSet ds2 = new DataSet();
                ds1 = (DataSet)ViewState["v1"];
                ds2 = (DataSet)ViewState["v2"];

                HiddenField hidID = ((HiddenField)(e.Row.FindControl("hidEmpID")));
                if (hidID.Value == "202587")
                {
                }
                DropDownList ddlID = null;


                if ((DE.ToDate == null || DE.ToDate == "") && (DE.FromDate == null || DE.FromDate == ""))
                {
                    if (ds1.Tables[0].Columns.Count == 22)
                    {


                        DataRow[] dr1 = ds1.Tables[0].Select("emp_id='" + hidID.Value + "'");
                        if ((ds1.Tables[0].Rows.Count) > 0)
                        {

                            for (int n = 1; n <= ds1.Tables[0].Columns.Count - 7; n++)
                            {
                                ddlID = ((DropDownList)(e.Row.FindControl("ddl" + n)));
                                ddlID.SelectedValue = dr1[0][6 + n].ToString();


                                if ((ddlID.SelectedValue == "P") || (ddlID.SelectedValue == "A") || (ddlID.SelectedValue == "L"))
                                {
                                    ddlID.Items.Remove("U");
                                    ddlID.Enabled = false;

                                }
                            }
                        }
                    }
                }
                else
                {
                    if (ds1.Tables[0].Columns.Count == (7 + Diff + 1))
                    {


                        DataRow[] dr1 = ds1.Tables[0].Select("emp_id='" + hidID.Value + "'");
                        if ((ds1.Tables[0].Rows.Count) > 0)
                        {

                            for (int n = 1; n <= ds1.Tables[0].Columns.Count - 7; n++)
                            {
                                ddlID = ((DropDownList)(e.Row.FindControl("ddl" + n)));
                                ddlID.SelectedValue = dr1[0][6 + n].ToString();


                                if ((ddlID.SelectedValue == "P") || (ddlID.SelectedValue == "A") || (ddlID.SelectedValue == "L"))
                                {
                                    ddlID.Items.Remove("U");
                                    ddlID.Enabled = false;

                                }
                            }
                        }
                    }
                }


                if (e.Row.RowIndex == GVDE.Rows.Count)
                {
                    ds1.Dispose();
                    ds2.Dispose();
                }

            }

            //    if (e.Row.RowIndex != -1)
            //    {
            //        DataSet ds1 = new DataSet();

            //        DataSet ds2 = new DataSet();
            //        ds1 = (DataSet)ViewState["v1"];
            //        ds2 = (DataSet)ViewState["v2"];

            //        HiddenField hidID = ((HiddenField)(e.Row.FindControl("hidEmpID")));
            //        if (hidID.Value == "202587")
            //        {
            //        }
            //        DropDownList ddlID = null;// ((DropDownList)(e.Row.FindControl("ddl" + i)));

            //        if (ds2.Tables[0].Columns.Count == 7)
            //        {
            //            //DataRow[] dr1 = ds2.Tables[0].Select( r => new { r.emp_id,r.Date}).Distinct();
            //            DataRow[] drrr= ds2.Tables[0].Select("emp_id='" + hidID.Value + "'");
            //            List<DataRow>  drrrrr = new List<DataRow>();
            //           for (int b=0;b<drrr.Length ;b++)
            //           {
            //               string dt = "";
            //               if(b!=0)
            //               {
            //                   dt = drrr[b - 1]["date"].ToString();
            //               }
            //               if (drrr[b]["date"].ToString() != dt)
            //               {
            //                   drrrrr.Add(drrr[b]);
            //               }

            //            }

            //            DataRow[] dr1 = drrrrr.ToArray();

            //            for (int a = 0; a < dr1.Length; a++)
            //            {
            //                //ddlID = ((DropDownList)(e.Row.FindControl("ddl" + (15 - a))));
            //                if (Convert.ToDateTime(dr1[a].ItemArray[6].ToString()).DayOfWeek.ToString() == "Monday")
            //                {

            //                    ddlID = ((DropDownList)(e.Row.FindControl("ddl" + (15 - (a - 1)))));
            //                    if ((ds2.Tables[0].Rows.Count) > 0)
            //                    {
            //                        ddlID.SelectedValue = dr1[a]["ATTENDANCE"].ToString();


            //                        if ((ddlID.SelectedValue == "P") || (ddlID.SelectedValue == "A"))
            //                        {
            //                            ddlID.Items.Remove("U");
            //                            ddlID.Enabled = false;

            //                        }
            //                        string DateDiff = Convert.ToString(Convert.ToDateTime(DE.ToDate).Date.Day - Convert.ToDateTime(DE.FromDate).Date.Day);
            //                        if (dr1.Length >= 15 || dr1.Length >(Convert.ToInt32(DateDiff)+1))
            //                        {
            //                            a++;
            //                        }
            //                    }
            //                }

            //                else
            //                {
            //                    ddlID = ((DropDownList)(e.Row.FindControl("ddl" + (15 - a))));
            //                    //dr1[7]=

            //                    if ((ds2.Tables[0].Rows.Count) > 0)
            //                    {
            //                        ddlID.SelectedValue = dr1[a]["ATTENDANCE"].ToString();


            //                        if ((ddlID.SelectedValue == "P") || (ddlID.SelectedValue == "A"))
            //                        {
            //                            ddlID.Items.Remove("U");
            //                            ddlID.Enabled = false;

            //                        }
            //                    }
            //                }

            //            }



            //        }


            //        //////DropDownList PreddlID = ((DropDownList)(e.Row.FindControl("Preddl")));

            //        //////if ((ds2.Tables[0].Rows.Count) > 0)
            //        //////{
            //        //////    DataRow[] dr = ds2.Tables[0].Select("emp_id='" + hidID.Value + "'");
            //        //////    PreddlID.SelectedValue = dr[0]["ATTENDANCE"].ToString();
            //        //////    if ((PreddlID.SelectedValue == "P") || (PreddlID.SelectedValue == "A"))
            //        //////    {
            //        //////        PreddlID.Items.Remove("U");
            //        //////        PreddlID.Enabled = false;
            //        //////    }

            //        //////}


            //        //if (ds1.Tables[0].Columns.Count == 9)
            //        //{


            //        //    DataRow[] dr1 = ds1.Tables[0].Select("emp_id='" + hidID.Value + "'");
            //        //    if ((ds1.Tables[0].Rows.Count) > 0)
            //        //    {
            //        //        ddlID.SelectedValue = dr1[0]["ATTENDANCE"].ToString();


            //        //        if ((ddlID.SelectedValue == "P") || (ddlID.SelectedValue == "A"))
            //        //        {
            //        //            ddlID.Items.Remove("U");
            //        //            ddlID.Enabled = false;

            //        //        }
            //        //    }
            //        //}

            //        if (e.Row.RowIndex == GVDE.Rows.Count)
            //        {
            //            ds1.Dispose();
            //            ds2.Dispose();
            //        }

            //    }
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
        try
        {
            if (ddlCluster.Visible == true && ddlCentreName.Visible == true && ddlSubCentre.Visible == true && ddlRM.Visible == true)
            {
                DE.ClusterID = ddlCluster.SelectedValue;
                DE.CentreID = ddlCentreName.SelectedValue;
                DE.SubCentreID = ddlSubCentre.SelectedValue;
                DE.Emp_ID = ddlRM.SelectedValue;

            }
            else if (ddlCluster.Visible == true && ddlCentreName.Visible == true && ddlSubCentre.Visible == true)
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
        catch (Exception ex)
        {

        }
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            int diff = 14;
            ArrayList AlistEmp = new ArrayList();
            ArrayList AlistAtten = new ArrayList();
            ArrayList AlistPreAtten = new ArrayList();

            DropDownList ddl = null;
            string AlistCreBy = "";
            DateTime AlistCreDate;

            AlistCreBy = Session["UserId"].ToString();
            AlistCreDate = DateTime.Now;

            int icount = 15 + 1;

            TimeSpan d = TimeSpan.Zero;

            if (DE.ToDate != "" && DE.FromDate != "")
            {
                d = Convert.ToDateTime(DateTime.ParseExact(DE.ToDate, "dd/MM/yyyy", null)) - Convert.ToDateTime(DateTime.ParseExact(DE.FromDate, "dd/MM/yyyy", null));
                diff = Convert.ToInt32(d.TotalDays);
            }
            for (int i = 1; i < icount; i++)
            {

                foreach (GridViewRow row in GVDE.Rows)
                {
                    //if (diff < 16)
                    //{
                    //    ddlname = "ddl" + (icount-i);
                    //    DropDownList ddlID = (DropDownList)row.FindControl(ddlname);
                    //    ddlID.Visible = false;

                    //}
                    string ddlname = "ddl" + (i);
                    HiddenField hidID = (HiddenField)row.FindControl("hidEmpID");
                    //AlistEmp.Add(hidID.Value);
                    DropDownList ddlID = (DropDownList)row.FindControl(ddlname);
                    // DropDownList ddlID1 = (DropDownList)row.FindControl("Preddl");
                    ddl = ddlID;

                    if (ddlID.SelectedValue == "U")
                    {


                        lblMsg.Visible = true;
                        lblMsg.Text = "Please Insert attendance for all Attendance cant be U";
                        return;

                    }
                    // AlistPreAtten.Add(ddlID1.SelectedValue);
                }
            }
            for (int i = 1; i < icount; i++)
            {

                foreach (GridViewRow row in GVDE.Rows)
                {

                    string ddlname = "ddl" + (i);
                    HiddenField hidID = (HiddenField)row.FindControl("hidEmpID");
                    AlistEmp.Add(hidID.Value);
                    DropDownList ddlID = (DropDownList)row.FindControl(ddlname);
                    // DropDownList ddlID1 = (DropDownList)row.FindControl("Preddl");

                    AlistAtten.Add(ddlID.SelectedValue);
                    // AlistPreAtten.Add(ddlID1.SelectedValue);
                }
                if (GVDE.Columns[7].Visible == true)
                {
                    DE.ColumnFlag = true;

                }
                if (ddl.SelectedValue == "U")
                {
                    //if (diff < 16)
                    //{

                    //    ddlID.Visible = false;

                    //}
                    //else
                    //{
                    lblMsg.Visible = true;
                    lblMsg.Text = "Please Insert attendance for all Attendance cant be U";
                    return;
                    //}
                }


                // int p = i - 1;
                int p = (diff) - (i - 1);
                DE.InsertAttendence(AlistEmp, AlistAtten, AlistAtten, AlistCreBy, AlistCreDate, p);
                AlistEmp.Clear();
                AlistAtten.Clear();
            }

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

    protected void ddlRM_SelectedIndexChanged1(object sender, EventArgs e)
    {
        string sql = "select top 1  da.date from employee_master em inner join Datily_attendance da on em.emp_id =da.emp_id where em.rm_empcode='" + ddlRM.SelectedValue + "' order by date desc";
        DE.Emp_ID = ddlRM.SelectedValue;
        object dr = OleDbHelper.ExecuteScalar(objConn.ConnectionString, CommandType.Text, sql);
        if (dr != null)
        {
            string dte = dr.ToString();
            LabelMsg.Text = "Attendance Last Updated On " + Convert.ToDateTime(dte).ToString("dd-MM-yyyy") + " ";

        }
        else
        {
            LabelMsg.Text = "None of the Attendance is  marked By this SM";
        }
    }







    protected void txtRequestFromDate_TextChanged(object sender, EventArgs e)
    {
        if (txtRequestFromDate.Text != "")
        {
            string frmdate = Convert.ToDateTime(DateTime.ParseExact(txtRequestFromDate.Text, "dd/MM/yyyy", null)).AddDays(14).ToString();
            TextBox2.Text = Convert.ToDateTime(frmdate).ToString("dd/MM/yyyy");
        }
        // LabelMsg.Text = "done";
    }
}

//using System;
//using System.Data;
//using System.Configuration;
//using System.Collections;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;
//using System.Collections.Generic;

//public partial class HR_HR_DAT_ENTRY : System.Web.UI.Page
//{
//    DAT_ENTRY DE = new DAT_ENTRY();
//    DataSet ds = new DataSet();
//    string strDay = "";
//    string strPreDay = "";
//    string str = "";
//    //protected void Page_Load(object sender, EventArgs e)
//    //{
        
//    //    CCommon objConn = new CCommon();
//    //    sdsSubCentre.ConnectionString = objConn.ConnectionString;  //Sir
//    //    sdsCentre.ConnectionString = objConn.ConnectionString;  //Sir
//    //    sdsCluster.ConnectionString = objConn.ConnectionString;
//    //    sdsRM.ConnectionString = objConn.ConnectionString;//Sir
//    //    SdsRsm.ConnectionString = objConn.ConnectionString;//Sir
//    //    DE.Department1 = Session["department_id"].ToString();
//    //    try
//    //    {
//    //        string strRole = Session["RoleID"].ToString();
//    //        string[] strRole1 = strRole.Split(',');

//    //        bool bflag = false;


//    //        foreach (string str in strRole1)
//    //        {

//    //            if (str == "11")
//    //            {

//    //                if (!IsPostBack)
//    //                {
//    //                    DE.SubCentreID = Session["SubCentreID"].ToString();
//    //                    DE.CentreID = Session["CentreID"].ToString();
//    //                    DE.ClusterID = Session["ClusterId"].ToString();
//    //                  //  FillGrid();
//    //                }


//    //            }
//    //            //if (str == "7")
//    //            //{
//    //            //    btnshow.Visible =false;
//    //            //    ddlSubCentre.Visible = true;
//    //            //    lblSubCentre.Visible = true;
//    //            //    lblSubcentreCo.Visible = true;


//    //            //    if (!IsPostBack)
//    //            //    {
//    //            //        sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + Session["CentreID"].ToString() + " order by SubCentreName";
//    //            //        ddlSubCentre.DataBind();
//    //            //        //ddlSubCentre.SelectedValue = Session["SubcentreID"].ToString();

//    //            //        DE.SubCentreID = ddlSubCentre.SelectedValue;
//    //            //        DE.CentreID = Session["CentreID"].ToString();
//    //            //        DE.ClusterID = Session["ClusterId"].ToString();

//    //            //        FillGrid();
//    //            //    }
//    //            //}
//    //            if (str == "7")
//    //            {
//    //                btnshow.Visible = false;
//    //                ddlSubCentre.Visible = true;
//    //                ddlCentreName.Visible = true;
//    //                lblSubCentre.Visible = true;
//    //                lblSubcentreCo.Visible = true;
//    //                lblCentre.Visible = true;
//    //                lblCentreCo.Visible = true;
//    //                ddlRM.Visible = false;
//    //                lblRM.Visible = false;
//    //                ddlCluster.Visible = true;
//    //                lblCentreCo.Visible = true;
//    //                lblClusterCo.Visible = true;
//    //                lblCluster.Visible = true;

//    //                lblcoRM.Visible = false;

//    //                DropDownList1.Visible = false;
//    //                Label1.Visible = false;
//    //                Label2.Visible = false;

//    //                if (!IsPostBack)
//    //                {

//    //                    sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] where cluster_id=" + Session["ClusterId"].ToString() + " order by CENTRE_NAME";
//    //                    ddlCentreName.DataBind();
//    //                    //ddlCentreName.SelectedValue = Session["CentreID"].ToString();

//    //                    sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + ddlCentreName.SelectedValue + " order by SubCentreName";
//    //                    ddlSubCentre.DataBind();
//    //                    //ddlSubCentre.SelectedValue = Session["SubCentreID"].ToString();
//    //                  //  sdsRM.SelectCommand = "select distinct rm.RM_empcode as emp_code,rm.RM_empcode+' '+rm.RM_name as Fullname from RM_master rm join employee_master em on rm.RM_empcode=em.emp_code where em.emp_id='" + Session["UserId"].ToString() + "'";


//    //                    string strEMP = "select distinct rm.RM_empcode as emp_code,rm.RM_empcode+' '+rm.RM_name as Fullname from RM_master rm join employee_master em on rm.RM_empcode=em.emp_code where em.emp_id='" + Session["UserId"].ToString() + "'";

//    //                    object drEmp = OleDbHelper.ExecuteScalar(objConn.ConnectionString, CommandType.Text, strEMP);

//    //                    string Empid = drEmp.ToString();
                        

//    //                    DE.SubCentreID = ddlSubCentre.SelectedValue;
//    //                    DE.CentreID = ddlCentreName.SelectedValue;
//    //                    DE.ClusterID = Session["ClusterId"].ToString();
//    //                    DE.Emp_ID = Convert.ToString(Empid);
//    //                   // DE.Emp_ID = "select emp_code from employee_master where emp_id='" + Session["Userid"].ToString() + "'";
//    //                    FillGrid();
//    //                }
//    //            }
//    //            //if (str == "7")
//    //            //{
//    //            //    btnshow.Visible =false;
//    //            //    ddlSubCentre.Visible = true;
//    //            //    ddlCentreName.Visible = true;
//    //            //    ddlCluster.Visible = true;
//    //            //    lblSubCentre.Visible = true;
//    //            //    lblSubcentreCo.Visible = true;
//    //            //    lblCentre.Visible = true;
//    //            //    lblCentreCo.Visible = true;
//    //            //    lblCluster.Visible = true;
//    //            //    lblClusterCo.Visible = true;

//    //            //    if (!IsPostBack)
//    //            //    {
//    //            //        ddlCluster.DataBind();
//    //            //        ddlCluster.SelectedValue = Session["ClusterId"].ToString();
//    //            //        sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] where cluster_id=" + ddlCluster.SelectedValue + " order by CENTRE_NAME";
//    //            //        ddlCentreName.DataBind();
//    //            //        //ddlCentreName.SelectedValue = Session["CentreId"].ToString();
//    //            //        sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + ddlCentreName.SelectedValue + " order by SubCentreName";
//    //            //        ddlSubCentre.DataBind();
//    //            //        //ddlSubCentre.SelectedValue = Session["SubcentreID"].ToString();

//    //            //        DE.ClusterID = ddlCluster.SelectedValue;
//    //            //        DE.CentreID = ddlCentreName.SelectedValue;
//    //            //        DE.SubCentreID = ddlSubCentre.SelectedValue;

//    //            //        FillGrid();
//    //            //    }

//    //            //}

//    //            if (str == "6")
//    //            {
//    //                btnshow.Visible = false;
//    //                ddlSubCentre.Visible = true;
//    //                ddlCentreName.Visible = true;
//    //                ddlCluster.Visible = true;
//    //                lblSubCentre.Visible = true;
//    //                lblSubcentreCo.Visible = true;
//    //                lblCentre.Visible = true;
//    //                lblCentreCo.Visible = true;
//    //                lblCluster.Visible = true;
//    //                lblClusterCo.Visible = true;
//    //                ddlRM.Visible = true;
//    //                lblRM.Visible = true;
//    //                DropDownList1.Visible = false;
//    //                Label1.Visible = false;
//    //                Label2.Visible = false;


//    //                if (!IsPostBack)
//    //                {
//    //                    ddlCluster.DataBind();
//    //                    ddlCluster.SelectedValue = Session["ClusterId"].ToString();
//    //                    sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] where cluster_id=" + ddlCluster.SelectedValue + " order by CENTRE_NAME";
//    //                    ddlCentreName.DataBind();
//    //                    //ddlCentreName.SelectedValue = Session["CentreId"].ToString();
//    //                    sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + ddlCentreName.SelectedValue + " order by SubCentreName";
//    //                    ddlSubCentre.DataBind();
//    //                    //ddlSubCentre.SelectedValue = Session["SubcentreID"].ToString();
//    //                    sdsRM.SelectCommand = "select distinct rm.RM_empcode as emp_code,rm.RM_empcode+' '+rm.RM_name as Fullname from RM_master rm join  RSM_master rsm on rsm.RSM_empcode=rm.RsM_empcode join employee_master em on rsm.RsM_empcode=em.emp_code where em.emp_id='"+Session["UserId"].ToString()+"'";
//    //                    ddlRM.DataBind();
//    //                    List<string> arm = new List<string>();
//    //                    for (int a = 1; a < ddlRM.Items.Count; a++)
//    //                    {
//    //                        arm.Add(ddlRM.Items[a].ToString());
//    //                    }

//    //                    DE.ClusterID = ddlCluster.SelectedValue;
//    //                    DE.CentreID = ddlCentreName.SelectedValue;
//    //                    DE.SubCentreID = ddlSubCentre.SelectedValue;
//    //                    DE.Emp_ID = ddlRM.SelectedValue;
//    //                    DE.RM = arm;

//    //                  //  FillGrid();
//    //                }
                  
//    //            }

//    //            if (str == "1")
//    //            {
//    //                btnshow.Visible = false;
//    //                ddlSubCentre.Visible = true;
//    //                ddlCentreName.Visible = true;
//    //                ddlCluster.Visible = true;
//    //                lblSubCentre.Visible = true;
//    //                lblSubcentreCo.Visible = true;
//    //                lblCentre.Visible = true;
//    //                lblCentreCo.Visible = true;
//    //                lblCluster.Visible = true;
//    //                lblClusterCo.Visible = true;
//    //                ddlRM.Visible = true;
//    //                lblRM.Visible = true;
//    //                DropDownList1.Visible = true;
//    //                Label1.Visible = true;
//    //                Label2.Visible = true;


//    //                //SdsRsm.SelectCommand = "select RSM_empcode as emp_code ,RSM_empcode +' '+RSM_NAME as fullname from Rsm_master";
//    //                //DropDownList1.DataBind();


//    //                if (!IsPostBack)
//    //                {
//    //                    ddlCluster.DataBind();
//    //                    ddlCluster.SelectedValue = Session["ClusterId"].ToString();
//    //                    sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] where cluster_id=" + ddlCluster.SelectedValue + " order by CENTRE_NAME";
//    //                    ddlCentreName.DataBind();
//    //                    //ddlCentreName.SelectedValue = Session["CentreId"].ToString();
//    //                    sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + ddlCentreName.SelectedValue + " order by SubCentreName";
//    //                    ddlSubCentre.DataBind();

//    //                    SdsRsm.SelectCommand = "select RSM_empcode as emp_code ,RSM_empcode +' '+RSM_NAME as fullname from Rsm_master";
//    //                    DropDownList1.DataBind();
//    //                    List<string> RSm = new List<string>();
//    //                    for (int a = 1; a < DropDownList1.Items.Count; a++)
//    //                    {
//    //                        RSm.Add(DropDownList1.Items[a].ToString());
//    //                    }

//    //                    //ddlSubCentre.SelectedValue = Session["SubcentreID"].ToString();
//    //                    sdsRM.SelectCommand = "select distinct rm.RM_empcode as emp_code,rm.RM_empcode+' '+rm.RM_name as Fullname from RM_master rm join  RSM_master rsm on rsm.RSM_empcode=rm.RsM_empcode join employee_master em on rsm.RsM_empcode=em.emp_code";
//    //                    ddlRM.DataBind();

//    //                    List<string> arm = new List<string>();
//    //                    for (int a = 1; a < ddlRM.Items.Count; a++)
//    //                    {
//    //                        arm.Add(ddlRM.Items[a].ToString());
//    //                    }
                      
//    //                    DE.ClusterID = ddlCluster.SelectedValue;
//    //                    DE.CentreID = ddlCentreName.SelectedValue;
//    //                    DE.SubCentreID = ddlSubCentre.SelectedValue;
//    //                    DE.Emp_ID = ddlRM.SelectedValue;
//    //                    DE.RSM_EMPCode = DropDownList1.SelectedValue;
//    //                    DE.RM = arm;
//    //                    DE.RSM = RSm;


//    //                  //  FillGrid();
//    //                }

//    //            }
//    //        }


//    //        DE.SubCentreID = ddlSubCentre.SelectedValue;
//    //        DE.CentreID = Session["CentreID"].ToString();
//    //        DE.Emp_ID = ddlRM.SelectedValue;
//    //        DE.FromDate = txtRequestFromDate.Text;
//    //        DE.ToDate = TextBox2.Text;
//    //        DataSet dsHier = new DataSet();
//    //        dsHier = DE.GetHier();
//    //        string strHier = "";
//    //        if (ddlSubCentre.SelectedIndex != 0)
//    //        {
//    //            if (dsHier.Tables[0].Columns.Count == 3)
//    //            {
//    //                strHier = dsHier.Tables[0].Rows[0]["cluster_name"].ToString() + "-" + dsHier.Tables[0].Rows[0]["CENTRE_NAME"].ToString() + "-" + dsHier.Tables[0].Rows[0]["SubCentreName"].ToString();
//    //            }
//    //            else
//    //                strHier = dsHier.Tables[0].Rows[0]["cluster_name"].ToString() + "-" + dsHier.Tables[0].Rows[0]["CENTRE_NAME"].ToString();
//    //            lblHierChichy.Text = strHier;
//    //        }
//    //        lblDate.Text = "Attendance Entry  For The Date - " + System.DateTime.Now.ToString("dd/MM/yyyy") + "";
//    //        string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
//    //        string str1 = strTime.Remove(2);
//    //        string str2 = strTime.Remove(0, 3);
//    //        if ((Convert.ToInt32(str1) <= 12))
//    //        {
//    //            if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() != "Sunday")
//    //            {

//    //                lblDate.Text = "Attendance Entry  For The Date - " + System.DateTime.Now.ToString("dd/MM/yyyy") + "";
//    //                //lblDate.Text = "Attendance Entry  For  Date - " + System.DateTime.Now.ToString("dd/MM/yyyy") + " and " + System.DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy") + "";

//    //            }
//    //            else
//    //                //lblDate.Text = "Attendance Entry  For  Date - " + System.DateTime.Now.ToString("dd/MM/yyyy") + " and " + System.DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy") + "";
//    //                lblDate.Text = "Attendance Entry  For The Date - " + System.DateTime.Now.ToString("dd/MM/yyyy") + "";


//    //        }
//    //    }
//    //    catch (Exception ex)
//    //    {
//    //        lblMsg.Text = ex.Message;
//    //    }
//    //}
//    CCommon objConn = new CCommon();
//    protected void Page_Load(object sender, EventArgs e)
//   {
//        bool admin = false;
//        bool IsRM = false;
//        bool IsRSM = false;

       
//        sdsSubCentre.ConnectionString = objConn.ConnectionString;  //Sir
//        sdsCentre.ConnectionString = objConn.ConnectionString;  //Sir
//        sdsCluster.ConnectionString = objConn.ConnectionString;
//        sdsRM.ConnectionString = objConn.ConnectionString;//Sir
//        SdsRsm.ConnectionString = objConn.ConnectionString;//Sir
//        DE.Department1 = Session["department_id"].ToString();
//        try
//        {
//            string strRole = Session["RoleID"].ToString();
//            string[] strRole1 = strRole.Split(',');

//            bool bflag = false;


//            foreach (string str in strRole1)
//            {

//                if (str == "11")
//                {

//                    if (!IsPostBack)
//                    {
//                        DE.SubCentreID = Session["SubCentreID"].ToString();
//                        DE.CentreID = Session["CentreID"].ToString();
//                        DE.ClusterID = Session["ClusterId"].ToString();
//                        //  FillGrid();
//                    }


//                }
//                //if (str == "7")
//                //{
//                //    btnshow.Visible =false;
//                //    ddlSubCentre.Visible = true;
//                //    lblSubCentre.Visible = true;
//                //    lblSubcentreCo.Visible = true;


//                //    if (!IsPostBack)
//                //    {
//                //        sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + Session["CentreID"].ToString() + " order by SubCentreName";
//                //        ddlSubCentre.DataBind();
//                //        //ddlSubCentre.SelectedValue = Session["SubcentreID"].ToString();

//                //        DE.SubCentreID = ddlSubCentre.SelectedValue;
//                //        DE.CentreID = Session["CentreID"].ToString();
//                //        DE.ClusterID = Session["ClusterId"].ToString();

//                //        FillGrid();
//                //    }
//                //}
//                if (str == "7")
//                {
//                    btnshow.Visible = false;
//                    ddlSubCentre.Visible = true;
//                    ddlCentreName.Visible = true;
//                    lblSubCentre.Visible = true;
//                    lblSubcentreCo.Visible = true;
//                    lblCentre.Visible = true;
//                    lblCentreCo.Visible = true;
//                    ddlRM.Visible = false;
//                    lblRM.Visible = false;
//                    ddlCluster.Visible = true;
//                    lblCentreCo.Visible = true;
//                    lblClusterCo.Visible = true;
//                    lblCluster.Visible = true;

//                    lblcoRM.Visible = false;

//                    DropDownList1.Visible = false;
//                    Label1.Visible = false;
//                    Label2.Visible = false;
//                    IsRM = true;
//                    if (!IsPostBack)
//                    {

//                        sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] where cluster_id=" + Session["ClusterId"].ToString() + " order by CENTRE_NAME";
//                        ddlCentreName.DataBind();
//                        //ddlCentreName.SelectedValue = Session["CentreID"].ToString();

//                        sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + ddlCentreName.SelectedValue + " order by SubCentreName";
//                        ddlSubCentre.DataBind();
//                        //ddlSubCentre.SelectedValue = Session["SubCentreID"].ToString();
//                        //  sdsRM.SelectCommand = "select distinct rm.RM_empcode as emp_code,rm.RM_empcode+' '+rm.RM_name as Fullname from RM_master rm join employee_master em on rm.RM_empcode=em.emp_code where em.emp_id='" + Session["UserId"].ToString() + "'";


//                        string strEMP = "select distinct rm.RM_empcode as emp_code,rm.RM_empcode+' '+rm.RM_name as Fullname from RM_master rm join employee_master em on rm.RM_empcode=em.emp_code where em.emp_id='" + Session["UserId"].ToString() + "'";

//                        object drEmp = OleDbHelper.ExecuteScalar(objConn.ConnectionString, CommandType.Text, strEMP);

//                        string Empid = drEmp.ToString();


//                        DE.SubCentreID = ddlSubCentre.SelectedValue;
//                        DE.CentreID = ddlCentreName.SelectedValue;
//                        DE.ClusterID = Session["ClusterId"].ToString();
//                        DE.Emp_ID = Convert.ToString(Empid);
//                        // DE.Emp_ID = "select emp_code from employee_master where emp_id='" + Session["Userid"].ToString() + "'";
//                      //  FillGrid();
//                    }
//                }
//                //if (str == "7")
//                //{
//                //    btnshow.Visible =false;
//                //    ddlSubCentre.Visible = true;
//                //    ddlCentreName.Visible = true;
//                //    ddlCluster.Visible = true;
//                //    lblSubCentre.Visible = true;
//                //    lblSubcentreCo.Visible = true;
//                //    lblCentre.Visible = true;
//                //    lblCentreCo.Visible = true;
//                //    lblCluster.Visible = true;
//                //    lblClusterCo.Visible = true;

//                //    if (!IsPostBack)
//                //    {
//                //        ddlCluster.DataBind();
//                //        ddlCluster.SelectedValue = Session["ClusterId"].ToString();
//                //        sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] where cluster_id=" + ddlCluster.SelectedValue + " order by CENTRE_NAME";
//                //        ddlCentreName.DataBind();
//                //        //ddlCentreName.SelectedValue = Session["CentreId"].ToString();
//                //        sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + ddlCentreName.SelectedValue + " order by SubCentreName";
//                //        ddlSubCentre.DataBind();
//                //        //ddlSubCentre.SelectedValue = Session["SubcentreID"].ToString();

//                //        DE.ClusterID = ddlCluster.SelectedValue;
//                //        DE.CentreID = ddlCentreName.SelectedValue;
//                //        DE.SubCentreID = ddlSubCentre.SelectedValue;

//                //        FillGrid();
//                //    }

//                //}

//                if (str == "6")
//                {
//                    btnshow.Visible = false;
//                    ddlSubCentre.Visible = true;
//                    ddlCentreName.Visible = true;
//                    ddlCluster.Visible = true;
//                    lblSubCentre.Visible = true;
//                    lblSubcentreCo.Visible = true;
//                    lblCentre.Visible = true;
//                    lblCentreCo.Visible = true;
//                    lblCluster.Visible = true;
//                    lblClusterCo.Visible = true;
//                    ddlRM.Visible = true;
//                    lblRM.Visible = true;
//                    DropDownList1.Visible = false;
//                    Label1.Visible = false;
//                    Label2.Visible = false;

//                    IsRSM = true;
//                    if (!IsPostBack)
//                    {
//                        ddlCluster.DataBind();
//                        ddlCluster.SelectedValue = Session["ClusterId"].ToString();
//                        sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] where cluster_id=" + ddlCluster.SelectedValue + " order by CENTRE_NAME";
//                        ddlCentreName.DataBind();
//                        //ddlCentreName.SelectedValue = Session["CentreId"].ToString();
//                        sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + ddlCentreName.SelectedValue + " order by SubCentreName";
//                        ddlSubCentre.DataBind();
//                        //ddlSubCentre.SelectedValue = Session["SubcentreID"].ToString();
//                        sdsRM.SelectCommand = "select distinct rm.RM_empcode as emp_code,rm.RM_empcode+' '+rm.RM_name as Fullname from RM_master rm join  RSM_master rsm on rsm.RSM_empcode=rm.RsM_empcode join employee_master em on rsm.RsM_empcode=em.emp_code where em.emp_id='" + Session["UserId"].ToString() + "'";
//                        ddlRM.DataBind();
//                        List<string> arm = new List<string>();
//                        for (int a = 1; a < ddlRM.Items.Count; a++)
//                        {
//                            arm.Add(ddlRM.Items[a].ToString());
//                        }

//                        DE.ClusterID = ddlCluster.SelectedValue;
//                        DE.CentreID = ddlCentreName.SelectedValue;
//                        DE.SubCentreID = ddlSubCentre.SelectedValue;
//                        DE.Emp_ID = ddlRM.SelectedValue;
//                        DE.RM = arm;
//                        DE.RSM_EMPCode = Session["UserId"].ToString();

//                        //  FillGrid();
//                    }

//                }

//                if (str == "1")
//                {
//                    btnshow.Visible = false;
//                    ddlSubCentre.Visible = true;
//                    ddlCentreName.Visible = true;
//                    ddlCluster.Visible = true;
//                    lblSubCentre.Visible = true;
//                    lblSubcentreCo.Visible = true;
//                    lblCentre.Visible = true;
//                    lblCentreCo.Visible = true;
//                    lblCluster.Visible = true;
//                    lblClusterCo.Visible = true;
//                    ddlRM.Visible = true;
//                    lblRM.Visible = true;
//                    DropDownList1.Visible = true;
//                    Label1.Visible = true;
//                    Label2.Visible = true;


//                    //SdsRsm.SelectCommand = "select RSM_empcode as emp_code ,RSM_empcode +' '+RSM_NAME as fullname from Rsm_master";
//                    //DropDownList1.DataBind();

//                    admin = true;
//                    if (!IsPostBack)
//                    {
//                        ddlCluster.DataBind();
//                        ddlCluster.SelectedValue = Session["ClusterId"].ToString();
//                        sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] where cluster_id=" + ddlCluster.SelectedValue + " order by CENTRE_NAME";
//                        ddlCentreName.DataBind();
//                        //ddlCentreName.SelectedValue = Session["CentreId"].ToString();
//                        sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + ddlCentreName.SelectedValue + " order by SubCentreName";
//                        ddlSubCentre.DataBind();

//                        SdsRsm.SelectCommand = "select RSM_empcode as emp_code ,RSM_empcode +' '+RSM_NAME as fullname from Rsm_master";
//                        DropDownList1.DataBind();
//                        List<string> RSm = new List<string>();
//                        for (int a = 1; a < DropDownList1.Items.Count; a++)
//                        {
//                            RSm.Add(DropDownList1.Items[a].ToString());
//                        }

//                        //ddlSubCentre.SelectedValue = Session["SubcentreID"].ToString();
//                        sdsRM.SelectCommand = "select distinct rm.RM_empcode as emp_code,rm.RM_empcode+' '+rm.RM_name as Fullname from RM_master rm join  RSM_master rsm on rsm.RSM_empcode=rm.RsM_empcode join employee_master em on rsm.RsM_empcode=em.emp_code";
//                        ddlRM.DataBind();

//                        List<string> arm = new List<string>();
//                        for (int a = 1; a < ddlRM.Items.Count; a++)
//                        {
//                            arm.Add(ddlRM.Items[a].ToString());
//                        }

//                        string strEMpadmin = "select Emp_code from Employee_master  where EMP_ID=" +
//                           Session["USERID"] + "";

//                        object drEmpadmin = OleDbHelper.ExecuteScalar(objConn.ConnectionString, CommandType.Text, strEMpadmin);
//                        DE.Admin_EMPCODE = drEmpadmin.ToString();

//                        if (DE.Admin_EMPCODE != null || DE.Admin_EMPCODE != "")
//                        {
//                            admin = true;
//                        }
//                        DE.ClusterID = ddlCluster.SelectedValue;
//                        DE.CentreID = ddlCentreName.SelectedValue;
//                        DE.SubCentreID = ddlSubCentre.SelectedValue;
//                        DE.Emp_ID = ddlRM.SelectedValue;
//                        DE.RSM_EMPCode = DropDownList1.SelectedValue;
//                        DE.RM = arm;
//                        DE.RSM = RSm;


//                        //  FillGrid();
//                    }

//                }

//            }
//            string strEMPem = "select Emp_code from Employee_master  where EMP_ID=" +
//                             Session["USERID"] + "";

//            object drEmpem = OleDbHelper.ExecuteScalar(objConn.ConnectionString, CommandType.Text, strEMPem);

//            DE.SubCentreID = ddlSubCentre.SelectedValue;
//            DE.CentreID = Session["CentreID"].ToString();
//            if (IsRM == true && IsRSM == false && admin == false)
//            {
//                DE.Emp_ID = (ddlRM.Visible == true && ddlRM.SelectedValue != "0") ? ddlRM.SelectedValue : drEmpem.ToString();
//            }
//            else if (admin == false && IsRM == false && IsRSM == true)
//            {
//                DE.RSM_EMPCode = (admin == false && DropDownList1.Visible == true && DropDownList1.SelectedValue != "0") ? DropDownList1.SelectedValue : drEmpem.ToString();
//                DE.Emp_ID = ddlRM.SelectedValue;
//            }
//            else if (IsRSM == true && IsRM == true)
//            {
//                DE.RSM_EMPCode = DropDownList1.SelectedValue;
//            }
//            DE.FromDate = txtRequestFromDate.Text;
//            DE.ToDate = TextBox2.Text;
//            if (admin == true)
//            {
//                DE.Admin_EMPCODE = drEmpem.ToString();
//                DE.RSM_EMPCode = DropDownList1.SelectedValue;
//                DE.Emp_ID = ddlRM.SelectedValue;
//            }
//            if (IsRM == true)
//            {
//                string sql = "select top 1  da.date from employee_master em inner join Datily_attendance da on em.emp_id =da.emp_id where em.rm_empcode='" + DE.Emp_ID + "' order by date desc";
//                object dr = OleDbHelper.ExecuteScalar(objConn.ConnectionString, CommandType.Text, sql);
//                if (dr != null)
//                {
//                    string dte = dr.ToString();
//                    LabelMsg.Text = "Attendance Last Updated On " + Convert.ToDateTime(dte).ToString("dd-MM-yyyy") + " ";
//                }
//                else
//                {
//                    LabelMsg.Text = "None of the Attendance is  marked By this SM";
//                }


//            }

//            DataSet dsHier = new DataSet();
//            dsHier = DE.GetHier();
//            string strHier = "";
//            if (ddlSubCentre.SelectedIndex != 0)
//            {
//                if (dsHier.Tables[0].Columns.Count == 3)
//                {
//                    strHier = dsHier.Tables[0].Rows[0]["cluster_name"].ToString() + "-" + dsHier.Tables[0].Rows[0]["CENTRE_NAME"].ToString() + "-" + dsHier.Tables[0].Rows[0]["SubCentreName"].ToString();
//                }
//                else
//                    strHier = dsHier.Tables[0].Rows[0]["cluster_name"].ToString() + "-" + dsHier.Tables[0].Rows[0]["CENTRE_NAME"].ToString();
//                lblHierChichy.Text = strHier;
//            }
//            lblDate.Text = "Attendance Entry  For The Date - " + System.DateTime.Now.ToString("dd/MM/yyyy") + "";
//            string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
//            string str1 = strTime.Remove(2);
//            string str2 = strTime.Remove(0, 3);
//            if ((Convert.ToInt32(str1) <= 12))
//            {
//                if (System.DateTime.Now.AddDays(-1).DayOfWeek.ToString() != "Sunday")
//                {

//                    lblDate.Text = "Attendance Entry  For The Date - " + System.DateTime.Now.ToString("dd/MM/yyyy") + "";
//                    //lblDate.Text = "Attendance Entry  For  Date - " + System.DateTime.Now.ToString("dd/MM/yyyy") + " and " + System.DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy") + "";

//                }
//                else
//                    //lblDate.Text = "Attendance Entry  For  Date - " + System.DateTime.Now.ToString("dd/MM/yyyy") + " and " + System.DateTime.Now.AddDays(-2).ToString("dd/MM/yyyy") + "";
//                    lblDate.Text = "Attendance Entry  For The Date - " + System.DateTime.Now.ToString("dd/MM/yyyy") + "";


//            }
//        }
//        catch (Exception ex)
//        {
//            lblMsg.Text = ex.Message;
//        }
//    }
//    public void FillGrid()
//    {
//        TimeSpan d = TimeSpan.Zero;
//        string DateDiff = "0";
//        int icount = 15;
//        if (DE.ToDate != "" && DE.FromDate != "")
//            d = Convert.ToDateTime(DateTime.ParseExact(DE.ToDate, "dd/MM/yyyy", null)) - Convert.ToDateTime(DateTime.ParseExact(DE.FromDate, "dd/MM/yyyy", null));
//        DateDiff = Convert.ToInt32(d.TotalDays).ToString();
//        //Convert.ToString(Convert.ToDateTime(DE.ToDate).Date.Day - Convert.ToDateTime(DE.FromDate).Date.Day);
//        if (Convert.ToInt32(DateDiff) > 15)
//        {
//            lblMsg.Text = "Only DateRange for 15 Days are allowed";
//            for (int i = icount - 1; i >= 0; i--)
//            // for (int i = 0; i < icount; i++)
//            {
//                string strPredate = System.DateTime.Now.AddDays(-i).Day.ToString();
//                strPreDay = System.DateTime.Now.AddDays(-i).DayOfWeek.ToString().Substring(0, 3);

//                string strPreHeaderText = strPredate + "-" + strPreDay;
//                GVDE.Columns[6 + (14 - i)].HeaderText = strPreHeaderText;
//                GVDE.Columns[6 + (14 - i)].Visible = true;
//            }

//            for (int i = icount; i < 15; i++)
//            {
//                GVDE.Columns[6 + (14 - i)].Visible = false;
//            }

//            string strdate = System.DateTime.Now.Day.ToString();
//            strDay = System.DateTime.Now.DayOfWeek.ToString();

//            //string strPredate = System.DateTime.Now.AddDays(-1).Day.ToString();
//            //        strPreDay = System.DateTime.Now.AddDays(-1).DayOfWeek.ToString();

//            string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
//            string str = strTime.Remove(2);
//            string str1 = strTime.Remove(0, 3);
//        }
//        if (DateDiff != "0" && Convert.ToInt32(DateDiff) < 15 && Convert.ToDateTime(DateTime.ParseExact(DE.ToDate, "dd/MM/yyyy", null)).Date > System.DateTime.Now.Date)
//        {
//            DateDiff = Convert.ToString(System.DateTime.Now.Day - Convert.ToDateTime(DateTime.ParseExact(DE.FromDate, "dd/MM/yyyy", null)).Date.Day);
//            icount = Convert.ToInt32(DateDiff) + 1;
//            if (icount < 15)
//            {
//                lblMsg.Visible = true;
//                lblMsg.Text = "Kindly select Date range properly ToDate is more Than today's date.Choose fromdate " + Convert.ToDateTime(System.DateTime.Now.AddDays(-14)).ToString("dd/MM/yyyy") + " ";
//                return;
//            }
//            for (int i = icount - 1; i >= 0; i--)
//            // for (int i = 0; i < icount; i++)
//            {
//                string strPredate = System.DateTime.Now.AddDays(-i).Day.ToString();
//                strPreDay = System.DateTime.Now.AddDays(-i).DayOfWeek.ToString().Substring(0, 3);

//                string strPreHeaderText = strPredate + "-" + strPreDay;
//                GVDE.Columns[6 + (14 - i)].HeaderText = strPreHeaderText;
//                GVDE.Columns[6 + (14 - i)].Visible = true;
//            }

//            for (int i = icount; i < 15; i++)
//            {
//                GVDE.Columns[6 + (14 - i)].Visible = false;
//            }

//            string strdate = System.DateTime.Now.Day.ToString();
//            strDay = System.DateTime.Now.DayOfWeek.ToString();

//            //string strPredate = System.DateTime.Now.AddDays(-1).Day.ToString();
//            //        strPreDay = System.DateTime.Now.AddDays(-1).DayOfWeek.ToString();

//            string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
//            string str = strTime.Remove(2);
//            string str1 = strTime.Remove(0, 3);

//        }

//        else if (DateDiff != "0" && Convert.ToInt32(DateDiff) < 15)
//        {
//            icount = Convert.ToInt32(DateDiff) + 1;
//            for (int i = icount - 1; i >= 0; i--)
//            // for (int i = 0; i < icount; i++)
//            {
//                string strPredate = Convert.ToDateTime(DateTime.ParseExact(DE.ToDate, "dd/MM/yyyy", null)).AddDays(-i).Day.ToString();
//                strPreDay = Convert.ToString(Convert.ToDateTime(DateTime.ParseExact(DE.ToDate, "dd/MM/yyyy", null)).AddDays(-i).DayOfWeek.ToString().Substring(0, 3));

//                string strPreHeaderText = strPredate + "-" + strPreDay;
//                GVDE.Columns[6 + (14 - i)].HeaderText = strPreHeaderText;
//                GVDE.Columns[6 + (14 - i)].Visible = true;
//            }
//            for (int i = icount; i < 15; i++)
//            {
//                GVDE.Columns[6 + (14 - i)].Visible = false;


//            }

//        }
//        else
//        {
//            for (int i = icount - 1; i >= 0; i--)
//            {
//                string strPredate = System.DateTime.Now.AddDays(-i).Day.ToString();
//                strPreDay = System.DateTime.Now.AddDays(-i).DayOfWeek.ToString().Substring(0, 3);

//                string strPreHeaderText = strPredate + "-" + strPreDay;

//                GVDE.Columns[6 + (14 - i)].HeaderText = strPreHeaderText;
//                GVDE.Columns[6 + (14 - i)].Visible = true;
//            }

//            //  for (int i = 0; i < icount; i++)
//            //{
//            //    string strPredate = System.DateTime.Now.AddDays(-i).Day.ToString();
//            //    strPreDay = System.DateTime.Now.AddDays(-i).DayOfWeek.ToString().Substring(0, 3);

//            //    string strPreHeaderText = strPredate + "-" + strPreDay;
//            //    GVDE.Columns[6 + i].HeaderText = strPreHeaderText;
//            //    GVDE.Columns[6 + i].Visible = true;
//            //}

//            for (int i = icount; i < 15; i++)
//            {
//                GVDE.Columns[6 + (14 - i)].Visible = false;
//            }

//            string strdate = System.DateTime.Now.Day.ToString();
//            strDay = System.DateTime.Now.DayOfWeek.ToString();

//            //string strPredate = System.DateTime.Now.AddDays(-1).Day.ToString();
//            //        strPreDay = System.DateTime.Now.AddDays(-1).DayOfWeek.ToString();

//            string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
//            string str = strTime.Remove(2);
//            string str1 = strTime.Remove(0, 3);
//        }

//        //string strHeaderText = strdate + "-" + strDay;
//        //string strPreHeaderText = strPredate + "-" + strPreDay;
//        //GVDE.Columns[7].HeaderText = strPreHeaderText;
//        //GVDE.Columns[7].Visible = false;

//        //GVDE.Columns[8].HeaderText = strHeaderText;

//        if (txtEmpCode.Text.Trim() != "")
//        {
//            DE.EMPCODE = txtEmpCode.Text.Trim();
//        }
//        if (txtEmpName.Text.Trim() != "")
//        {
//            DE.EMPNAME = txtEmpName.Text.Trim().Replace(' ', '%');
//        }
//        DataSet ds = new DataSet();
//        ds = DE.Fill_Grid();
//        ViewState["v1"] = ds;
//        DataSet ds1 = new DataSet();
//        //if (DE.Emp_ID != "" && DE.Emp_ID != null)
//        //{
//        //    ds1 = DE.GetToDayAttenance1();
//        //}
//        //else
//        //{
//        ds1 = DE.GetToDayAttenance();
//        //}

//        ViewState["v2"] = ds1;
//        GVDE.DataSource = ds;



//        GVDE.DataBind();
//        if (GVDE.Rows.Count <= 0)
//        {
//            lblMsg.Text = "No record found.";
//            lblMsg.Visible = true;
//            btnSave.Visible = false;
//            imgntnsave.Visible = false;

//        }

//        if (GVDE.Rows.Count > 0)
//        {

//            lblMsg.Visible = false;
//            btnSave.Visible = false;
//            imgntnsave.Visible = true;
//        }

//        ds.Dispose();
//        ds1.Dispose();
//    }
//    //public void FillGrid()
//    //{
//    //  string DateDiff ="0";
//    //    int icount = 15;
//    //    if(DE.ToDate !="" && DE.FromDate !="")
//    //        DateDiff = Convert.ToString(Convert.ToDateTime(DE.ToDate).Date.Day - Convert.ToDateTime(DE.FromDate).Date.Day);
//    //    if (Convert.ToInt32(DateDiff) > 15)
//    //    {
//    //        lblMsg.Text = "Only DateRange for 15 Days are allowed";
//    //       for (int i = 0; i < icount; i++)
//    //        {
//    //            string strPredate = System.DateTime.Now.AddDays(-i).Day.ToString();
//    //            strPreDay = System.DateTime.Now.AddDays(-i).DayOfWeek.ToString().Substring(0, 3);

//    //            string strPreHeaderText = strPredate + "-" + strPreDay;
//    //            GVDE.Columns[6 + i].HeaderText = strPreHeaderText;
//    //            GVDE.Columns[6 + i].Visible = true;
//    //        }

//    //        for (int i = icount; i < 15; i++)
//    //        {
//    //            GVDE.Columns[6 + i].Visible = false;
//    //        }

//    //        string strdate = System.DateTime.Now.Day.ToString();
//    //        strDay = System.DateTime.Now.DayOfWeek.ToString();

//    //        //string strPredate = System.DateTime.Now.AddDays(-1).Day.ToString();
//    //        //        strPreDay = System.DateTime.Now.AddDays(-1).DayOfWeek.ToString();

//    //        string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
//    //        string str = strTime.Remove(2);
//    //        string str1 = strTime.Remove(0, 3);
//    //    }
//    //    if (DateDiff != "0" && Convert.ToInt32(DateDiff) < 15 && Convert.ToDateTime(DE.ToDate).Date > System.DateTime.Now.Date )
//    //    {
//    //        DateDiff = Convert.ToString(System.DateTime.Now.Day - Convert.ToDateTime(DE.FromDate).Date.Day);
//    //        icount = Convert.ToInt32(DateDiff) + 1;
//    //        for (int i = 0; i < icount; i++)
//    //        {
//    //            string strPredate = System.DateTime.Now.AddDays(-i).Day.ToString();
//    //            strPreDay = System.DateTime.Now.AddDays(-i).DayOfWeek.ToString().Substring(0, 3);

//    //            string strPreHeaderText = strPredate + "-" + strPreDay;
//    //            GVDE.Columns[6 + i].HeaderText = strPreHeaderText;
//    //            GVDE.Columns[6 + i].Visible = true;
//    //        }

//    //        for (int i = icount; i < 15; i++)
//    //        {
//    //            GVDE.Columns[6 + i].Visible = false;
//    //        }

//    //        string strdate = System.DateTime.Now.Day.ToString();
//    //        strDay = System.DateTime.Now.DayOfWeek.ToString();

//    //        //string strPredate = System.DateTime.Now.AddDays(-1).Day.ToString();
//    //        //        strPreDay = System.DateTime.Now.AddDays(-1).DayOfWeek.ToString();

//    //        string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
//    //        string str = strTime.Remove(2);
//    //        string str1 = strTime.Remove(0, 3);

//    //    }

//    //    else  if (DateDiff != "0" && Convert.ToInt32(DateDiff) < 15)
//    //    {
//    //        icount = Convert.ToInt32(DateDiff)+1;
//    //        for (int i = 0; i < icount; i++)
//    //        {
//    //            string strPredate =Convert.ToDateTime(DE.ToDate).AddDays(-i).Day.ToString();
//    //            strPreDay =Convert.ToString(Convert.ToDateTime(DE.ToDate).AddDays(-i).DayOfWeek.ToString().Substring(0, 3));

//    //            string strPreHeaderText = strPredate + "-" + strPreDay;
//    //            GVDE.Columns[6 + i].HeaderText = strPreHeaderText;
//    //            GVDE.Columns[6 + i].Visible = true;
//    //        }
//    //        for (int i = icount; i < 15 ; i++)
//    //        {
//    //            GVDE.Columns[6 + i].Visible = false;
//    //        }

//    //    }
//    //   else
//    //    {
       
//    //   for (int i = 0; i < icount; i++)
//    //    {
//    //        string strPredate = System.DateTime.Now.AddDays(-i).Day.ToString();
//    //        strPreDay = System.DateTime.Now.AddDays(-i).DayOfWeek.ToString().Substring(0, 3);

//    //        string strPreHeaderText = strPredate + "-" + strPreDay;
//    //        GVDE.Columns[6 + i].HeaderText = strPreHeaderText;
//    //        GVDE.Columns[6 + i].Visible = true;
//    //    }

//    //    for (int i = icount; i < 15; i++)
//    //    {
//    //        GVDE.Columns[6 + i].Visible = false;
//    //    }

//    //    string strdate = System.DateTime.Now.Day.ToString();
//    //    strDay = System.DateTime.Now.DayOfWeek.ToString();

//    //    //string strPredate = System.DateTime.Now.AddDays(-1).Day.ToString();
//    //    //        strPreDay = System.DateTime.Now.AddDays(-1).DayOfWeek.ToString();

//    //    string strTime = System.DateTime.Now.TimeOfDay.ToString().Remove(5);
//    //    string str = strTime.Remove(2);
//    //    string str1 = strTime.Remove(0, 3);
//    //    }

//    //    //string strHeaderText = strdate + "-" + strDay;
//    //    //string strPreHeaderText = strPredate + "-" + strPreDay;
//    //    //GVDE.Columns[7].HeaderText = strPreHeaderText;
//    //    //GVDE.Columns[7].Visible = false;

//    //    //GVDE.Columns[8].HeaderText = strHeaderText;

//    //    if (txtEmpCode.Text.Trim() != "")
//    //    {
//    //        DE.EMPCODE = txtEmpCode.Text.Trim();
//    //    }
//    //    if (txtEmpName.Text.Trim() != "")
//    //    {
//    //        DE.EMPNAME = txtEmpName.Text.Trim().Replace(' ', '%');
//    //    }
//    //    DataSet ds = new DataSet();
//    //    ds = DE.Fill_Grid();
//    //    ViewState["v1"] = ds;
//    //    DataSet ds1 = new DataSet();
//    //    //if (DE.Emp_ID != "" && DE.Emp_ID != null)
//    //    //{
//    //    //    ds1 = DE.GetToDayAttenance1();
//    //    //}
//    //    //else
//    //    //{
//    //        ds1 = DE.GetToDayAttenance();
//    //    //}

//    //    ViewState["v2"] = ds1;
//    //    GVDE.DataSource = ds;



//    //    GVDE.DataBind();
//    //    if (GVDE.Rows.Count <= 0)
//    //    {
//    //        lblMsg.Text = "No record found.";
//    //        lblMsg.Visible = true;
//    //        btnSave.Visible = false;
//    //        imgntnsave.Visible = false;

//    //    }

//    //    if (GVDE.Rows.Count > 0)
//    //    {

//    //        lblMsg.Visible = false;
//    //        btnSave.Visible = false;
//    //        imgntnsave.Visible = true;
//    //    }

//    //    ds.Dispose();
//    //    ds1.Dispose();
//    //}
//    protected void btnSave_Click(object sender, EventArgs e)
//    {
//        try
//        {
//            ArrayList AlistEmp = new ArrayList();
//            ArrayList AlistAtten = new ArrayList();
//            ArrayList AlistPreAtten = new ArrayList();


//            string AlistCreBy = "";
//            DateTime AlistCreDate;

//            AlistCreBy = Session["UserId"].ToString();
//            AlistCreDate = DateTime.Now;

//            int icount = 4;
//            for (int i = 1; i < icount; i++)
//            {
//                foreach (GridViewRow row in GVDE.Rows)
//                {
//                    string ddlname = "ddl" + i;
//                    HiddenField hidID = (HiddenField)row.FindControl("hidEmpID");
//                    DropDownList ddlID = (DropDownList)row.FindControl(ddlname);
//                    // DropDownList ddlID1 = (DropDownList)row.FindControl("Preddl");
//                    AlistEmp.Add(hidID.Value);
//                    AlistAtten.Add(ddlID.SelectedValue);
//                    // AlistPreAtten.Add(ddlID1.SelectedValue);
//                }
//                if (GVDE.Columns[7].Visible == true)
//                {
//                    DE.ColumnFlag = true;
//                }
//                // DE.InsertAttendence(AlistEmp, AlistAtten, AlistAtten, AlistCreBy, AlistCreDate);

//            }



//            if (ddlCluster.Visible == true && ddlCentreName.Visible == true && ddlSubCentre.Visible == true)
//            {
//                DE.ClusterID = ddlCluster.SelectedValue;
//                DE.CentreID = ddlCentreName.SelectedValue;
//                DE.SubCentreID = ddlSubCentre.SelectedValue;

//            }
//            else if (ddlCentreName.Visible == true && ddlSubCentre.Visible == true)
//            {
//                DE.CentreID = ddlCentreName.SelectedValue;
//                DE.SubCentreID = ddlSubCentre.SelectedValue;
//                DE.ClusterID = Session["ClusterId"].ToString();
//            }
//            else if (ddlSubCentre.Visible == true)
//            {
//                DE.SubCentreID = ddlSubCentre.SelectedValue;
//                DE.CentreID = Session["CentreId"].ToString();
//                DE.ClusterID = Session["ClusterId"].ToString();
//            }
//            else
//            {
//                DE.SubCentreID = Session["SubcentreID"].ToString();
//                DE.CentreID = Session["CentreId"].ToString();
//                DE.ClusterID = Session["ClusterId"].ToString();
//            }
//            FillGrid();
//            lblMsg.Visible = true;
//            lblMsg.Text = DE.Message;

//        }
//        catch (Exception ex)
//        {
//            lblMsg.Visible = true;
//            lblMsg.Text = ex.Message;
//        }
//    }
//    protected void GVDE_RowDataBound(object sender, GridViewRowEventArgs e)
//    {


//        try
//        {
//            TimeSpan d = TimeSpan.Zero;

//            if (DE.ToDate != "" && DE.FromDate != "")
//                d = Convert.ToDateTime(DateTime.ParseExact(DE.ToDate, "dd/MM/yyyy", null)) - Convert.ToDateTime(DateTime.ParseExact(DE.FromDate, "dd/MM/yyyy", null));
//            int Diff = Convert.ToInt32(d.TotalDays);
//            if (e.Row.RowIndex != -1)
//            {
//                DataSet ds1 = new DataSet();

//                DataSet ds2 = new DataSet();
//                ds1 = (DataSet)ViewState["v1"];
//                ds2 = (DataSet)ViewState["v2"];

//                HiddenField hidID = ((HiddenField)(e.Row.FindControl("hidEmpID")));
//                if (hidID.Value == "202587")
//                {
//                }
//                DropDownList ddlID = null;


//                if ((DE.ToDate == null || DE.ToDate == "") && (DE.FromDate == null || DE.FromDate == ""))
//                {
//                    if (ds1.Tables[0].Columns.Count == 22)
//                    {


//                        DataRow[] dr1 = ds1.Tables[0].Select("emp_id='" + hidID.Value + "'");
//                        if ((ds1.Tables[0].Rows.Count) > 0)
//                        {

//                            for (int n = 1; n <= ds1.Tables[0].Columns.Count - 7; n++)
//                            {
//                                ddlID = ((DropDownList)(e.Row.FindControl("ddl" + n)));
//                                ddlID.SelectedValue = dr1[0][6 + n].ToString();


//                                if ((ddlID.SelectedValue == "P") || (ddlID.SelectedValue == "A") || (ddlID.SelectedValue == "L")  )
//                                {
//                                    ddlID.Items.Remove("U");
//                                    ddlID.Enabled = false;

//                                }
//                            }
//                        }
//                    }
//                }
//                else
//                {
//                    if (ds1.Tables[0].Columns.Count == (7 + Diff + 1))
//                    {


//                        DataRow[] dr1 = ds1.Tables[0].Select("emp_id='" + hidID.Value + "'");
//                        if ((ds1.Tables[0].Rows.Count) > 0)
//                        {

//                            for (int n = 1; n <= ds1.Tables[0].Columns.Count - 7; n++)
//                            {
//                                ddlID = ((DropDownList)(e.Row.FindControl("ddl" + n)));
//                                ddlID.SelectedValue = dr1[0][6 + n].ToString();


//                                if ((ddlID.SelectedValue == "P") || (ddlID.SelectedValue == "A") || (ddlID.SelectedValue == "L"))
//                                {
//                                    ddlID.Items.Remove("U");
//                                    ddlID.Enabled = false;

//                                }
//                            }
//                        }
//                    }
//                }


//                if (e.Row.RowIndex == GVDE.Rows.Count)
//                {
//                    ds1.Dispose();
//                    ds2.Dispose();
//                }

//            }

//        //    if (e.Row.RowIndex != -1)
//        //    {
//        //        DataSet ds1 = new DataSet();

//        //        DataSet ds2 = new DataSet();
//        //        ds1 = (DataSet)ViewState["v1"];
//        //        ds2 = (DataSet)ViewState["v2"];

//        //        HiddenField hidID = ((HiddenField)(e.Row.FindControl("hidEmpID")));
//        //        if (hidID.Value == "202587")
//        //        {
//        //        }
//        //        DropDownList ddlID = null;// ((DropDownList)(e.Row.FindControl("ddl" + i)));

//        //        if (ds2.Tables[0].Columns.Count == 7)
//        //        {
//        //            //DataRow[] dr1 = ds2.Tables[0].Select( r => new { r.emp_id,r.Date}).Distinct();
//        //            DataRow[] drrr= ds2.Tables[0].Select("emp_id='" + hidID.Value + "'");
//        //            List<DataRow>  drrrrr = new List<DataRow>();
//        //           for (int b=0;b<drrr.Length ;b++)
//        //           {
//        //               string dt = "";
//        //               if(b!=0)
//        //               {
//        //                   dt = drrr[b - 1]["date"].ToString();
//        //               }
//        //               if (drrr[b]["date"].ToString() != dt)
//        //               {
//        //                   drrrrr.Add(drrr[b]);
//        //               }

//        //            }

//        //            DataRow[] dr1 = drrrrr.ToArray();

//        //            for (int a = 0; a < dr1.Length; a++)
//        //            {
//        //                //ddlID = ((DropDownList)(e.Row.FindControl("ddl" + (15 - a))));
//        //                if (Convert.ToDateTime(dr1[a].ItemArray[6].ToString()).DayOfWeek.ToString() == "Monday")
//        //                {

//        //                    ddlID = ((DropDownList)(e.Row.FindControl("ddl" + (15 - (a - 1)))));
//        //                    if ((ds2.Tables[0].Rows.Count) > 0)
//        //                    {
//        //                        ddlID.SelectedValue = dr1[a]["ATTENDANCE"].ToString();


//        //                        if ((ddlID.SelectedValue == "P") || (ddlID.SelectedValue == "A"))
//        //                        {
//        //                            ddlID.Items.Remove("U");
//        //                            ddlID.Enabled = false;

//        //                        }
//        //                        string DateDiff = Convert.ToString(Convert.ToDateTime(DE.ToDate).Date.Day - Convert.ToDateTime(DE.FromDate).Date.Day);
//        //                        if (dr1.Length >= 15 || dr1.Length >(Convert.ToInt32(DateDiff)+1))
//        //                        {
//        //                            a++;
//        //                        }
//        //                    }
//        //                }

//        //                else
//        //                {
//        //                    ddlID = ((DropDownList)(e.Row.FindControl("ddl" + (15 - a))));
//        //                    //dr1[7]=

//        //                    if ((ds2.Tables[0].Rows.Count) > 0)
//        //                    {
//        //                        ddlID.SelectedValue = dr1[a]["ATTENDANCE"].ToString();


//        //                        if ((ddlID.SelectedValue == "P") || (ddlID.SelectedValue == "A"))
//        //                        {
//        //                            ddlID.Items.Remove("U");
//        //                            ddlID.Enabled = false;

//        //                        }
//        //                    }
//        //                }

//        //            }



//        //        }


//        //        //////DropDownList PreddlID = ((DropDownList)(e.Row.FindControl("Preddl")));

//        //        //////if ((ds2.Tables[0].Rows.Count) > 0)
//        //        //////{
//        //        //////    DataRow[] dr = ds2.Tables[0].Select("emp_id='" + hidID.Value + "'");
//        //        //////    PreddlID.SelectedValue = dr[0]["ATTENDANCE"].ToString();
//        //        //////    if ((PreddlID.SelectedValue == "P") || (PreddlID.SelectedValue == "A"))
//        //        //////    {
//        //        //////        PreddlID.Items.Remove("U");
//        //        //////        PreddlID.Enabled = false;
//        //        //////    }

//        //        //////}


//        //        //if (ds1.Tables[0].Columns.Count == 9)
//        //        //{


//        //        //    DataRow[] dr1 = ds1.Tables[0].Select("emp_id='" + hidID.Value + "'");
//        //        //    if ((ds1.Tables[0].Rows.Count) > 0)
//        //        //    {
//        //        //        ddlID.SelectedValue = dr1[0]["ATTENDANCE"].ToString();


//        //        //        if ((ddlID.SelectedValue == "P") || (ddlID.SelectedValue == "A"))
//        //        //        {
//        //        //            ddlID.Items.Remove("U");
//        //        //            ddlID.Enabled = false;

//        //        //        }
//        //        //    }
//        //        //}

//        //        if (e.Row.RowIndex == GVDE.Rows.Count)
//        //        {
//        //            ds1.Dispose();
//        //            ds2.Dispose();
//        //        }

//        //    }
//        }
//        catch (Exception ex)
//        {
//            lblMsg.Visible = true;
//            lblMsg.Text = ex.Message;
//        }
//    }
//    protected void ddlSubCentre_DataBound(object sender, EventArgs e)
//    {
//        ddlSubCentre.Items.Insert(0, new ListItem("--All--", "0"));

//    }
//    protected void ddlCluster_SelectedIndexChanged(object sender, EventArgs e)
//    {
//        try
//        {
//            if (ddlCluster.SelectedIndex == 0)
//            {
//                sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] order by CENTRE_NAME ";
//                ddlCentreName.DataBind();
//            }
//            else
//            {
//                sdsCentre.SelectCommand = "SELECT [CENTRE_ID], [CENTRE_NAME] FROM [CENTRE_MASTER] WHERE ([CLUSTER_ID] = " + ddlCluster.SelectedValue + ") order by CENTRE_NAME";
//                ddlCentreName.DataBind();
//            }
//            if (ddlCentreName.SelectedIndex == 0)
//            {
//                string strRole = Session["RoleID"].ToString();
//                string[] strRole1 = strRole.Split(',');


//                foreach (string str in strRole1)
//                {
//                    if (str == "25")
//                    {
//                        sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where ClusterID=" + Session["ClusterId"].ToString() + " order by SubCentreName";
//                    }
//                    if (str == "24")
//                    {
//                        sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster  order by SubCentreName";

//                    }
//                }
//                ddlSubCentre.DataBind();
//            }
//            else
//            {
//                sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + ddlCentreName.SelectedValue + " order by SubCentreName";
//                ddlSubCentre.DataBind();
//            }
//        }
//        catch (Exception ex)
//        {
//            lblMsg.Text = ex.Message;
//        }
//    }
//    protected void ddlCentreName_SelectedIndexChanged(object sender, EventArgs e)
//    {
//        try
//        {
//            if (ddlCluster.Visible == true)
//            {
//                if (ddlCentreName.SelectedIndex == 0)
//                {
//                    sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster order by SubCentreName  ";
//                    ddlSubCentre.DataBind();
//                }
//                else
//                {
//                    sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where CentreId=" + ddlCentreName.SelectedValue + " order by SubCentreName";
//                    ddlSubCentre.DataBind();
//                }
//            }
//            else
//            {
//                sdsSubCentre.SelectCommand = "Select SubCentreName,SubCentreId from SubCentreMaster where ClusterId ='" + Session["ClusterID"] + "' order by SubCentreName   ";
//                ddlSubCentre.DataBind();
//            }
//        }
//        catch (Exception ex)
//        {
//            lblMsg.Text = ex.Message;
//        }
//    }
//    protected void ddlCentreName_DataBound(object sender, EventArgs e)
//    {
//        ddlCentreName.Items.Insert(0, new ListItem("--All--", "0"));
//    }
//    protected void ddlCluster_DataBound(object sender, EventArgs e)
//    {
//        ddlCluster.Items.Insert(0, new ListItem("--All--", "0"));
//    }

//    protected void btnshow_Click(object sender, EventArgs e)
//    {

//    }
//    protected void GVDE_PageIndexChanging(object sender, GridViewPageEventArgs e)
//    {
//        GVDE.PageIndex = e.NewPageIndex;
//        if (ddlCluster.Visible == true && ddlCentreName.Visible == true && ddlSubCentre.Visible == true)
//        {
//            DE.ClusterID = ddlCluster.SelectedValue;
//            DE.CentreID = ddlCentreName.SelectedValue;
//            DE.SubCentreID = ddlSubCentre.SelectedValue;

//        }
//        else if (ddlCentreName.Visible == true && ddlSubCentre.Visible == true)
//        {
//            DE.CentreID = ddlCentreName.SelectedValue;
//            DE.SubCentreID = ddlSubCentre.SelectedValue;
//            DE.ClusterID = Session["ClusterId"].ToString();
//        }
//        else if (ddlSubCentre.Visible == true)
//        {
//            DE.SubCentreID = ddlSubCentre.SelectedValue;
//            DE.CentreID = Session["CentreId"].ToString();
//            DE.ClusterID = Session["ClusterId"].ToString();
//        }
//        else
//        {
//            DE.SubCentreID = Session["SubcentreID"].ToString();
//            DE.CentreID = Session["CentreId"].ToString();
//            DE.ClusterID = Session["ClusterId"].ToString();
//        }
//        FillGrid();
//    }
//    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
//    {
//        try
//        {
//            if (ddlCluster.Visible == true && ddlCentreName.Visible == true && ddlSubCentre.Visible == true && ddlRM.Visible == true)
//            {
//                DE.ClusterID = ddlCluster.SelectedValue;
//                DE.CentreID = ddlCentreName.SelectedValue;
//                DE.SubCentreID = ddlSubCentre.SelectedValue;
//                DE.Emp_ID = ddlRM.SelectedValue;

//            }
//            else if (ddlCluster.Visible == true && ddlCentreName.Visible == true && ddlSubCentre.Visible == true)
//            {
//                DE.ClusterID = ddlCluster.SelectedValue;
//                DE.CentreID = ddlCentreName.SelectedValue;
//                DE.SubCentreID = ddlSubCentre.SelectedValue;


//            }
//            else if (ddlCentreName.Visible == true && ddlSubCentre.Visible == true)
//            {
//                DE.CentreID = ddlCentreName.SelectedValue;
//                DE.SubCentreID = ddlSubCentre.SelectedValue;
//                DE.ClusterID = Session["ClusterId"].ToString();
//            }
//            else if (ddlSubCentre.Visible == true)
//            {
//                DE.SubCentreID = ddlSubCentre.SelectedValue;
//                DE.CentreID = Session["CentreId"].ToString();
//                DE.ClusterID = Session["ClusterId"].ToString();
//            }
//            else
//            {
//                DE.SubCentreID = Session["SubcentreID"].ToString();
//                DE.CentreID = Session["CentreId"].ToString();
//                DE.ClusterID = Session["ClusterId"].ToString();
//            }
//            FillGrid();
//        }
//        catch(Exception ex )
//        {
            
//        }
//    }
//    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
//    {
//        try
//        {
//            int diff = 14;
//            ArrayList AlistEmp = new ArrayList();
//            ArrayList AlistAtten = new ArrayList();
//            ArrayList AlistPreAtten = new ArrayList();

//            DropDownList ddl = null;
//            string AlistCreBy = "";
//            DateTime AlistCreDate;

//            AlistCreBy = Session["UserId"].ToString();
//            AlistCreDate = DateTime.Now;

//            int icount = 15 + 1;

//            TimeSpan d = TimeSpan.Zero;

//            if (DE.ToDate != "" && DE.FromDate != "")
//            {
//                d = Convert.ToDateTime(DateTime.ParseExact(DE.ToDate, "dd/MM/yyyy", null)) - Convert.ToDateTime(DateTime.ParseExact(DE.FromDate, "dd/MM/yyyy", null));
//                diff = Convert.ToInt32(d.TotalDays);
//            }
//            for (int i = 1; i < icount; i++)
//            {

//                foreach (GridViewRow row in GVDE.Rows)
//                {
//                    //if (diff < 16)
//                    //{
//                    //    ddlname = "ddl" + (icount-i);
//                    //    DropDownList ddlID = (DropDownList)row.FindControl(ddlname);
//                    //    ddlID.Visible = false;
                       
//                    //}
//                    string ddlname = "ddl" + (i);
//                    HiddenField hidID = (HiddenField)row.FindControl("hidEmpID");
//                    //AlistEmp.Add(hidID.Value);
//                    DropDownList ddlID = (DropDownList)row.FindControl(ddlname);
//                    // DropDownList ddlID1 = (DropDownList)row.FindControl("Preddl");
//                    ddl = ddlID;

//                    if (ddlID.SelectedValue == "U")
//                    {


//                        lblMsg.Visible = true;
//                        lblMsg.Text = "Please Insert attendance for all Attendance cant be U";
//                        return;

//                    }
//                    // AlistPreAtten.Add(ddlID1.SelectedValue);
//                }
//            }
//            for (int i = 1; i < icount; i++)
//            {

//                foreach (GridViewRow row in GVDE.Rows)
//                {

//                    string ddlname = "ddl" + (i);
//                    HiddenField hidID = (HiddenField)row.FindControl("hidEmpID");
//                    AlistEmp.Add(hidID.Value);
//                    DropDownList ddlID = (DropDownList)row.FindControl(ddlname);
//                    // DropDownList ddlID1 = (DropDownList)row.FindControl("Preddl");

//                    AlistAtten.Add(ddlID.SelectedValue);
//                    // AlistPreAtten.Add(ddlID1.SelectedValue);
//                }
//                if (GVDE.Columns[7].Visible == true)
//                {
//                    DE.ColumnFlag = true;

//                }
//                if (ddl.SelectedValue == "U")
//                {
//                    //if (diff < 16)
//                    //{

//                    //    ddlID.Visible = false;

//                    //}
//                    //else
//                    //{
//                    lblMsg.Visible = true;
//                    lblMsg.Text = "Please Insert attendance for all Attendance cant be U";
//                    return;
//                    //}
//                }


//               // int p = i - 1;
//                int p = (diff) - (i - 1);
//                DE.InsertAttendence(AlistEmp, AlistAtten, AlistAtten, AlistCreBy, AlistCreDate, p);
//                AlistEmp.Clear();
//                AlistAtten.Clear();
//            }

//            if (ddlCluster.Visible == true && ddlCentreName.Visible == true && ddlSubCentre.Visible == true)
//            {
//                DE.ClusterID = ddlCluster.SelectedValue;
//                DE.CentreID = ddlCentreName.SelectedValue;
//                DE.SubCentreID = ddlSubCentre.SelectedValue;

//            }
//            else if (ddlCentreName.Visible == true && ddlSubCentre.Visible == true)
//            {
//                DE.CentreID = ddlCentreName.SelectedValue;
//                DE.SubCentreID = ddlSubCentre.SelectedValue;
//                DE.ClusterID = Session["ClusterId"].ToString();
//            }
//            else if (ddlSubCentre.Visible == true)
//            {
//                DE.SubCentreID = ddlSubCentre.SelectedValue;
//                DE.CentreID = Session["CentreId"].ToString();
//                DE.ClusterID = Session["ClusterId"].ToString();
//            }
//            else
//            {
//                DE.SubCentreID = Session["SubcentreID"].ToString();
//                DE.CentreID = Session["CentreId"].ToString();
//                DE.ClusterID = Session["ClusterId"].ToString();
//            }
//            FillGrid();
//            lblMsg.Visible = true;
//            lblMsg.Text = DE.Message;

//        }
//        catch (Exception ex)
//        {
//            lblMsg.Visible = true;
//            lblMsg.Text = ex.Message;
//        }
//    }

//    protected void ddlRM_DataBound2(object sender, EventArgs e)
//    {
//        ddlRM.Items.Insert(0, new ListItem("--All--", "0"));


//    }
//    protected void DropDownList1_DataBound(object sender, EventArgs e)
//    {
//        DropDownList1.Items.Insert(0, new ListItem("--All--", "0"));
//    }


//    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
//    {
//        sdsRM.SelectCommand = "select distinct rm.RM_empcode as emp_code,rm.RM_empcode+' '+rm.RM_name as Fullname from RM_master rm join  RSM_master rsm on rsm.RSM_empcode=rm.RsM_empcode join employee_master em on rsm.RsM_empcode=em.emp_code where em.emp_code='" + DropDownList1.SelectedValue + "'";
//        ddlRM.DataBind();
//    }
  
//    protected void ddlRM_SelectedIndexChanged1(object sender, EventArgs e)
//    {
//        string sql = "select top 1  da.date from employee_master em inner join Datily_attendance da on em.emp_id =da.emp_id where em.rm_empcode='" + ddlRM.SelectedValue + "' order by date desc";
//        DE.Emp_ID = ddlRM.SelectedValue;
//        object dr = OleDbHelper.ExecuteScalar(objConn.ConnectionString, CommandType.Text, sql);
//        if (dr != null)
//        {
//            string dte = dr.ToString();
//            LabelMsg.Text = "Attendance Last Updated On " + Convert.ToDateTime(dte).ToString("dd-MM-yyyy") + " ";

//        }
//        else
//        {
//            LabelMsg.Text = "None of the Attendance is  marked By this SM";
//        }
//    }







//    protected void txtRequestFromDate_TextChanged(object sender, EventArgs e)
//    {
//        if (txtRequestFromDate.Text != "")
//        {
//            string frmdate = Convert.ToDateTime(DateTime.ParseExact(txtRequestFromDate.Text, "dd/MM/yyyy", null)).AddDays(14).ToString();
//            TextBox2.Text = Convert.ToDateTime(frmdate).ToString("dd/MM/yyyy");
//        }
//       // LabelMsg.Text = "done";
//    }
//}
