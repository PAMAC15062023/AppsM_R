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
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Drawing;
public partial class HR_HR_RolewiseReport : System.Web.UI.Page
{

    DATREPORT dr = new DATREPORT();
    CCommon con = new CCommon();
    public string lblMessage = "";
    public String[] SCentreName;
    public string ColumnSundayHeader = "";
    ArrayList Arrlist = new ArrayList();
    protected void Page_Load(object sender, EventArgs e)
    {

        lblReportTitle.Text = "";
        lblMsg.Text = "";
        if (!IsPostBack)
        {
            bool result;

            result = Session["RoleId"].ToString().Contains("24");      // result is true
            if (result == true)
            {
                Fill_RolewiseDropDown("24");
            }
            else
            {
                result = Session["RoleId"].ToString().Contains("25");
                if (result == true)
                {
                    Fill_RolewiseDropDown("25");
                }
                else
                {
                    result = Session["RoleId"].ToString().Contains("23");
                    if (result == true)
                    {
                        Fill_RolewiseDropDown("23");
                    }
                    else
                    {
                        result = Session["RoleId"].ToString().Contains("22");
                        if (result == true)
                        {
                            lblChooseSubCenter.Visible = false;
                        }
                    }
                }
            }
            if (Session["RoleId"].ToString().Contains("1"))
            {

                ddlReportType.Visible = true;
                ddlReportType.Enabled = true;
            }
            else if ((Session["RoleId"].ToString().Contains("6")) || (Session["RoleId"].ToString().Contains("7")))
            {

                ddlReportType.Items.Remove("Login Tracker");
                ddlReportType.Items.Remove("Password Updation Report");


            }
            else
            {
            }

        }


    }

    private void Fill_RolewiseDropDown(string RoleId)
    {

        try
        {
            if (RoleId == "24")
            {
                lblChooseCentre.Visible = true;
                lblChooseCluster.Visible = true;
                lblChooseSubCenter.Visible = true;
                ddlCluster.Enabled = true;
                ddlCluster.Visible = true;
                ddlCentre.Enabled = true;
                ddlCentre.Visible = true;
                ddlSubCentre.Enabled = true;
                ddlSubCentre.Visible = true;
                ddlCluster.DataSource = dr.Fill_RoleDropDown("select cluster_id,cluster_name from cluster_master order by cluster_name");
                ddlCluster.DataTextField = "cluster_name";
                ddlCluster.DataValueField = "cluster_id";
                ddlCluster.DataBind();

                ListItem item = new ListItem("--Select All Cluster--", "");
                ddlCluster.Items.Insert(0, item);
            }
            if (RoleId == "25")
            {
                ddlCluster.Enabled = false;
                lblChooseCluster.Visible = false;
                ddlCluster.Visible = false;
                ddlCentre.Enabled = true;
                lblChooseCentre.Visible = true;
                ddlCentre.Visible = true;
                ddlSubCentre.Enabled = true;
                lblChooseSubCenter.Visible = true;
                ddlSubCentre.Visible = true;
                ddlCentre.DataSource = dr.Fill_RoleDropDown("select  centre_id,centre_name from centre_master where cluster_id=" + Session["ClusterId"].ToString() + "   order by centre_name");
                ddlCentre.DataTextField = "centre_name";
                ddlCentre.DataValueField = "centre_id";
                ddlCentre.DataBind();

                ListItem item = new ListItem("--Select All Centres--", "");
                ddlCentre.Items.Insert(0, item);

            }
            if (RoleId == "23")
            {

                ddlCluster.Enabled = false;
                lblChooseCluster.Visible = false;
                ddlCluster.Visible = false;
                ddlCentre.Enabled = false;
                lblChooseCentre.Visible = false;
                ddlCentre.Visible = false;
                ddlSubCentre.Enabled = true;
                ddlSubCentre.Visible = true;
                ddlSubCentre.DataSource = dr.Fill_Sub_Centre(Session["CentreId"].ToString());
                ddlSubCentre.DataTextField = "subcentrename";
                ddlSubCentre.DataValueField = "subcentreid";
                ddlSubCentre.DataBind();

                ListItem item = new ListItem("--Select All SubCentres--", "");
                ddlSubCentre.Items.Insert(0, item);
            }
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message;
        }
    }

    private void FillGrid()
    {
        dr.FromDt = con.strDate(txtFromDate.Text.ToString());
        dr.ToDt = con.strDate(txtToDate.Text.ToString());


        GVDE.DataSource = dr.ShowRolewiseEmplSalaryStatus(ddlCentre.SelectedValue, ddlSubCentre.SelectedValue, "With Data", ddlCluster.SelectedValue);
        GVDE.DataBind();

        if ((ddlCluster.SelectedIndex == 0 || ddlCluster.SelectedIndex == -1) && ddlCluster.Visible != false)
        {
            lblMessage = "List of Employee Details From " + dr.FromDt + "  to " + dr.ToDt + "";
        }
        else
        {
            lblMessage += "List of Employee Details From " + dr.FromDt + "  to " + dr.ToDt + " For Cluster : " + ddlCluster.SelectedItem.Text + " ";
        }

        if ((ddlCentre.SelectedIndex == -1 || ddlCentre.SelectedIndex == 0) && ddlCentre.Visible != false)
        {
            lblMessage += " ";
        }
        else
        {
            lblMessage += " and  Center: " + ddlCentre.SelectedItem.Text + " ";
        }

        if (ddlSubCentre.SelectedValue != "")
        {
            lblMessage += " and Sub Center: " + ddlSubCentre.SelectedItem.Text + " ";
        }

        lblReportTitle.Text = lblMessage;

        int j = 1;
        for (int i = 0; i < GVDE.Rows.Count; i++)
        {
            GVDE.Rows[i].Cells[0].Text = j.ToString();
            j++;
        }

    }

    protected void btnShow_Click(object sender, EventArgs e)
    {

    }

    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        string result = Session["RoleId"].ToString();     // result is true
        if (result == "1")
        {
            BindDateWise_Gridview();
        }
        else if (result == "2")
        {
            BindDateWise_Gridview();
        }
        else
        {
            BindDateWise_Gridview_Client();
        }


        string strCentre;

        if (GVDE.Rows.Count > 0)
        {
            String attachment = "attachment; filename=DAT Daily Report.xls";
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Table tblSpace = new Table();
            TableRow tblRow = new TableRow();
            TableCell tblCell = new TableCell();
            tblCell.Text = " ";

            TableRow tblRow1 = new TableRow();
            TableCell tblCell1 = new TableCell();
            tblCell1.ColumnSpan = 20;// 10;
            tblCell1.Text = "<b><font size='2'>DAT Daily Report FROM : " + dr.FromDt + "  TO : " + dr.ToDt + "  " + lblMessage + "  </font></b> <br/>";
            tblCell1.CssClass = "FormHeading";
            tblRow.Cells.Add(tblCell);
            tblRow1.Cells.Add(tblCell1);
            tblRow.Height = 20;
            tblSpace.Rows.Add(tblRow);
            tblSpace.Rows.Add(tblRow1);
            tblSpace.RenderControl(htw);
            Table tbl = new Table();
            GVDE.GridLines = GridLines.Both;
            GVDE.EnableViewState = false;
            GVDE.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
        else
        {
        }

    }

    protected void FillSubCentre(object sender, EventArgs e)
    {
        if (ddlCentre.SelectedIndex != 0)
        {
            ddlSubCentre.DataSource = dr.Fill_Sub_Centre(ddlCentre.SelectedValue);
            ddlSubCentre.DataTextField = "subcentrename";
            ddlSubCentre.DataValueField = "subcentreid";
            ddlSubCentre.DataBind();
        }
        if (ddlCentre.SelectedIndex == 0)
        {
            ddlSubCentre.Items.Clear();
            ddlSubCentre.DataSource = null;
            ddlSubCentre.DataBind();
        }
        GVDE.DataSource = null;
        GVDE.DataBind();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void FillCentre(object sender, EventArgs e)
    {
        try
        {

            if (ddlCluster.SelectedIndex != 0)
            {
                ddlCentre.DataSource = dr.Fill_CentrewithClusterID("select centre_id,centre_name from centre_master where cluster_id=" + ddlCluster.SelectedValue + " order by centre_name");
                ddlCentre.DataTextField = "centre_name";
                ddlCentre.DataValueField = "centre_id";
                ddlCentre.DataBind();

                ListItem item = new ListItem("--Select All Centre--", "");
                ddlCentre.Items.Insert(0, item);

                ddlSubCentre.Items.Clear();
                ddlSubCentre.DataSource = null;
                ddlSubCentre.DataBind();

            }
            if (ddlCluster.SelectedIndex == 0)
            {
                ddlCentre.Items.Clear();
                ddlCentre.DataSource = null;
                ddlCentre.DataBind();
            }
            GVDE.DataSource = null;
            GVDE.DataBind();
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message;
        }

    }

    private void AssignLableMessage()
    {
        try
        {
            bool result = Session["RoleId"].ToString().Contains("24");
            bool ansCluster = Session["RoleId"].ToString().Contains("25");
            bool ansCenter = Session["RoleId"].ToString().Contains("23");

            if (result == true)
            {
                if ((ddlCluster.SelectedIndex == 0 || ddlCluster.SelectedIndex == -1) && ddlCluster.Visible != false)
                {
                    lblMessage = "List of Employee Details From " + dr.FromDt + "  to " + dr.ToDt + " ";
                }
                else
                {
                    lblMessage += "List of Employee Details From " + dr.FromDt + "  to " + dr.ToDt + " For Cluster : " + ddlCluster.SelectedItem.Text + " ";
                }
            }
            if (ddlCluster.Visible == true)
            {
                if ((ddlCentre.SelectedIndex == -1 || ddlCentre.SelectedIndex == 0) && ddlCentre.Visible != false)
                {
                    lblMessage += " ";
                }
                else if (ddlCentre.SelectedValue != "")
                {
                    lblMessage += " and  Location : " + ddlCentre.SelectedItem.Text + " ";
                }

                if (ddlSubCentre.SelectedValue != "")
                {
                    lblMessage += " and Sub Location : " + ddlSubCentre.SelectedItem.Text + " ";
                }

                lblReportTitle.Text = lblMessage;
                if (SCentreName != null)
                {
                    if (SCentreName.Length > 0)
                    {
                        lblReportTitle.Text = " List of Employee Details From " + dr.FromDt + "  to " + dr.ToDt + " For Sub Center " + SCentreName[1] + " ";
                    }
                }
            }
            if (ddlCluster.Visible == false && ddlCentre.Visible == false)
            {
                if ((ddlCentre.SelectedIndex == -1 || ddlCentre.SelectedIndex == 0) && ddlCentre.Visible != false)
                {
                    lblMessage += "  List of Employee Details From " + dr.FromDt + "  to " + dr.ToDt + "  For All Locations";
                }
                else if (ddlCentre.SelectedValue != "")
                {
                    lblMessage += "  List of Employee Details From " + dr.FromDt + "  to " + dr.ToDt + "  " + ddlCentre.SelectedItem.Text + " ";
                }

                if (ddlSubCentre.SelectedValue != "")
                {
                    lblMessage += " List of Employee Details From " + dr.FromDt + "  to " + dr.ToDt + "  For Sub Location : " + ddlSubCentre.SelectedItem.Text + " ";
                }

                if (SCentreName != null)
                {
                    if (SCentreName.Length > 0)
                    {
                        lblMessage = " List of Employee Details From " + dr.FromDt + "  to " + dr.ToDt + " For Sub Center " + SCentreName[1] + " ";
                    }
                }
                lblReportTitle.Text = lblMessage;
            }

            lblReportTitle.Text = lblMessage;

            if (ddlCluster.Visible == false && ddlCentre.Visible == true)
            {
                if ((ddlCentre.SelectedIndex == -1 || ddlCentre.SelectedIndex == 0) && ddlCentre.Visible != false)
                {
                    lblMessage += "  List of Employee Details From " + dr.FromDt + "  to " + dr.ToDt + "  For All Locations";
                }
                else if (ddlCentre.SelectedValue != "")
                {
                    lblMessage += "  List of Employee Details From " + dr.FromDt + "  to " + dr.ToDt + "  For Location : " + ddlCentre.SelectedItem.Text + " ";
                }

                if (ddlSubCentre.SelectedValue != "")
                {
                    lblMessage += " And Sub Location : " + ddlSubCentre.SelectedItem.Text + " ";
                }

                if (SCentreName != null)
                {
                    if (SCentreName.Length > 0)
                    {
                        lblReportTitle.Text = " List of Employee Details From " + dr.FromDt + "  to " + dr.ToDt + " For Sub Center " + SCentreName[1] + " ";
                    }
                }
                lblReportTitle.Text = lblMessage;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message;
        }
    }

    //private void BindDateWise_Gridview()
    //{
    //    try
    //    {
    //        dr.FromDt = con.strDate(txtFromDate.Text.ToString());
    //        dr.ToDt = con.strDate(txtToDate.Text.ToString());
    //    }

    //    catch
    //    {
    //        lblHierChichy.Text = "Please Enter Valid Date Format DD/MM/YYYY ";
    //        return;
    //    }

    //    OleDbDataReader BindDataReader;


    //    string DateDiff = Convert.ToString(Convert.ToDateTime(dr.ToDt).Date - Convert.ToDateTime(dr.FromDt).Date);
    //    int FindSubstring;
    //    FindSubstring = Convert.ToInt32(DateDiff.ToString().IndexOf(".", 1));

    //    int Datediff;
    //    if (FindSubstring == -1)
    //    {
    //        FindSubstring = 0;
    //        Datediff = 0;
    //    }
    //    else
    //    {
    //        Datediff = Convert.ToInt32(DateDiff.ToString().Substring(0, FindSubstring));
    //    }

    //    string strSubCenter = "";
    //    string strCntre = "";
    //    string strCluster = "";

    //    bool result = Session["RoleId"].ToString().Contains("24");
    //    bool ansCluster = Session["RoleId"].ToString().Contains("25");
    //    bool ansCenter = Session["RoleId"].ToString().Contains("23");

    //    if (ddlCentre.SelectedValue == "" && ddlSubCentre.SelectedValue == "" && ddlCluster.SelectedValue == "" && result == false && ansCluster == false && ansCenter == false)
    //    {
    //        strSubCenter = dr.ShowSubCenterData(Session["UserId"].ToString());
    //        SCentreName = strSubCenter.Split(',');
    //        strSubCenter = SCentreName[0];
    //        strCntre = Session["CentreId"].ToString();
    //        strCluster = dr.ShowClusterData(Session["UserId"].ToString());

    //    }
    //    else
    //    {
    //        strSubCenter = ddlSubCentre.SelectedValue;
    //    }
    //    BindDataReader = dr.ShowRolewiseEmplSalaryStatus(strCntre, strSubCenter, ddlReportType.SelectedValue, strCluster);
    //    DataTable DT = new DataTable();
    //    DataColumn DC = new DataColumn();

    //    if (ddlReportType.SelectedValue == "Login Tracker")
    //    {
    //        DC = new DataColumn("Sr.No", typeof(System.String));
    //        DT.Columns.Add(DC);
    //        DC = new DataColumn("Emp Code", typeof(System.String));
    //        DT.Columns.Add(DC);
    //        DC = new DataColumn("Emp Name", typeof(System.String));
    //        DT.Columns.Add(DC);
    //        DC = new DataColumn("Location", typeof(System.String));
    //        DT.Columns.Add(DC);
    //        DC = new DataColumn("Sub Location", typeof(System.String));
    //        DT.Columns.Add(DC);
    //        DC = new DataColumn("Department Name", typeof(System.String));
    //        DT.Columns.Add(DC);
    //        DC = new DataColumn("Login Date & Time", typeof(System.String));
    //        DT.Columns.Add(DC);


    //    }
    //    else if (ddlReportType.SelectedValue == "Password Updation Report")
    //    {
    //        DC = new DataColumn("Sr.No", typeof(System.String));
    //        DT.Columns.Add(DC);
    //        DC = new DataColumn("Emp Code", typeof(System.String));
    //        DT.Columns.Add(DC);
    //        DC = new DataColumn("Emp Name", typeof(System.String));
    //        DT.Columns.Add(DC);
    //        DC = new DataColumn("Location", typeof(System.String));
    //        DT.Columns.Add(DC);
    //        DC = new DataColumn("Sub Location", typeof(System.String));
    //        DT.Columns.Add(DC);
    //        DC = new DataColumn("Department Name", typeof(System.String));
    //        DT.Columns.Add(DC);
    //        DC = new DataColumn("Password Change Date", typeof(System.String));
    //        DT.Columns.Add(DC);
    //    }
    //    else
    //    {

    //        DC = new DataColumn("Sr.No", typeof(System.String));
    //        DT.Columns.Add(DC);
    //        DC = new DataColumn("Centre", typeof(System.String));
    //        DT.Columns.Add(DC);
    //        DC = new DataColumn("SubCentre", typeof(System.String));
    //        DT.Columns.Add(DC);
    //        DC = new DataColumn("Emp Code", typeof(System.String));
    //        DT.Columns.Add(DC);
    //        DC = new DataColumn("Full Name", typeof(System.String));
    //        DT.Columns.Add(DC);
    //        DC = new DataColumn("CTC Per Resource", typeof(System.String));
    //        DT.Columns.Add(DC);
    //        DC = new DataColumn("Actual Salary for Billing");
    //        DT.Columns.Add(DC);
    //        DC = new DataColumn("Absent");
    //        DT.Columns.Add(DC);
    //        DC = new DataColumn("Present");
    //        DT.Columns.Add(DC);
    //    }

    //    int i = 0;
    //    if (ddlReportType.SelectedValue != "Login Tracker" && ddlReportType.SelectedValue != "Password Updation Report")
    //    {
    //        for (i = 0; i <= Datediff; i++)
    //        {
    //            DC = new DataColumn(" " + Convert.ToDateTime(dr.FromDt).AddDays(i).ToString("ddd") + ' ' + Convert.ToInt32(Convert.ToDateTime(dr.FromDt).AddDays(i).ToString("dd")) + " ", typeof(System.String));
    //            DT.Columns.Add(DC);
    //            Arrlist.Add(Convert.ToDateTime(dr.FromDt).AddDays(i).ToString());
    //        }
    //    }
    //    i = 0;
    //    int j = 0;
    //    int sno = 1;
    //    int countA = 0;
    //    int countP = 0;
    //    int countR = 0;
    //    string EmpCode = "";
    //    DataRow DR;
    //    DR = DT.NewRow();
    //    string ColumnValue;
    //    Boolean ans = false;
    //    if (ddlReportType.SelectedValue == "Login Tracker" && Datediff >= 0)
    //    {
    //        while (BindDataReader.Read())
    //        {
    //            DR = DT.NewRow();
    //            DR["Sr.No"] = sno++;
    //            DR["Emp Code"] = BindDataReader["emp_code"].ToString();
    //            DR["Emp Name"] = BindDataReader["Emp Name"].ToString();
    //            DR["Location"] = BindDataReader["Location"].ToString();
    //            DR["Sub Location"] = BindDataReader["Sub Location"].ToString();
    //            DR["Department Name"] = BindDataReader["Department Name"].ToString();
    //            DR["Login Date & Time"] = BindDataReader["Login Date & Time"].ToString();
    //            DT.Rows.Add(DR);



    //        }
    //    }
    //    else if (ddlReportType.SelectedValue == "Password Updation Report" && Datediff >= 0)
    //    {
    //        while (BindDataReader.Read())
    //        {
    //            DR = DT.NewRow();
    //            DR["Sr.No"] = sno++;
    //            DR["Emp Code"] = BindDataReader["emp_code"].ToString();
    //            DR["Emp Name"] = BindDataReader["Emp Name"].ToString();
    //            DR["Location"] = BindDataReader["Location"].ToString();
    //            DR["Sub Location"] = BindDataReader["Sub Location"].ToString();
    //            DR["Department Name"] = BindDataReader["Department Name"].ToString();
    //            DR["Password Change Date"] = BindDataReader["Password Change Date"].ToString();
    //            DT.Rows.Add(DR);



    //        }
    //    }
    //    else if (ddlReportType.SelectedValue != "Without Data" && Datediff >= 0)
    //    {
    //        /* Ends Here */

    //        while (BindDataReader.Read())
    //        {

    //            if (i == 0)
    //            {
    //                EmpCode = BindDataReader["emp_code"].ToString();
    //                i++;
    //            }
    //            if (j == 0 && i == 1)
    //            {

    //                DR["Sr.No"] = sno++;
    //                DR["Centre"] = BindDataReader["Centre_Name"];
    //                DR["SubCentre"] = BindDataReader["SubCentreName"];
    //                DR["Emp Code"] = BindDataReader["emp_code"].ToString();
    //                DR["Full Name"] = BindDataReader["fullname"].ToString();
    //                DR["CTC per Resource"] = BindDataReader["Department"].ToString();
    //                DR["Actual Salary for Billing"] = countR;
    //                DR["Absent"] = countA;
    //                DR["Present"] = countP;
    //                j++;
    //                i++;
    //            }

    //            if (EmpCode != BindDataReader["Emp_Code"].ToString())
    //            {
    //                DT.Rows.Add(DR);

    //                DT.Rows.Add();
    //                DR = DT.NewRow();
    //                EmpCode = BindDataReader["Emp_Code"].ToString();
    //                DR["Sr.No"] = sno++;
    //                DR["Centre"] = BindDataReader["Centre_Name"];
    //                DR["SubCentre"] = BindDataReader["SubCentreName"];
    //                DR["Emp Code"] = BindDataReader["emp_code"].ToString();
    //                DR["Full Name"] = BindDataReader["fullname"];
    //                DR["CTC per Resource"] = BindDataReader["Department"];
    //                DR["Actual Salary for Billing"] = countR;
    //                DR["Absent"] = countA;
    //                DR["Present"] = countP;
    //                j = 0;

    //            }
    //            if (EmpCode == BindDataReader["emp_code"].ToString())
    //            {
    //                int cnt = 0;
    //                foreach (DataColumn ColumnSunday in DT.Columns)
    //                {
    //                    if (ColumnSunday.ToString().Substring(1, 3) == "Sun")
    //                    {
    //                        if (ans == false)
    //                        {
    //                            if (ColumnSundayHeader == "")
    //                            {
    //                                ColumnSundayHeader = Convert.ToString(cnt);
    //                            }
    //                            else
    //                            {
    //                                ColumnSundayHeader = ColumnSundayHeader + ',' + Convert.ToString(cnt);
    //                            }
    //                        }
    //                        ColumnSundayHeader = ColumnSundayHeader + ',' + Convert.ToString(cnt);
    //                        ColumnValue = ColumnSunday.ToString();
    //                        if (ddlReportType.SelectedValue != "Without Data")
    //                        {
    //                            DR["" + ColumnValue + ""] = "P";
    //                        }
    //                    }
    //                    cnt++;

    //                }

    //                ans = true;
    //                if (BindDataReader["Att_Date"].ToString().Substring(0, 3) != "Sun")
    //                {
    //                    DR[" " + BindDataReader["Att_Date"] + " "] = BindDataReader["status"];
    //                }
    //                for (int k = 4; k < DT.Columns.Count; k++)
    //                {
    //                    if ((k + i) <= DT.Columns.Count - 1)
    //                    {
    //                        if (DR[i + k].ToString() == "")
    //                        {
    //                            DR[i + k] = "A";
    //                        }

    //                        if (DT.Columns[i + k].ColumnName.Substring(0, 4).Trim() == "Sat")
    //                        {
    //                            if (i + k + 2 < DT.Columns.Count)
    //                            {

    //                                if ((DR[i + k].ToString() == "A" || DR[i + k].ToString() == "") && (DR[i + k + 2].ToString() == "A" || DR[i + k + 2].ToString() == ""))
    //                                {
    //                                    DR[i + k + 1] = "A";
    //                                }
    //                            }

    //                        }


    //                        if (BindDataReader["DOL"].ToString() != null && BindDataReader["DOL"].ToString() != "")
    //                        {
    //                            if (k <= DT.Columns.Count - 6)
    //                            {
    //                                if (Convert.ToDateTime(BindDataReader["DOL"]) <= Convert.ToDateTime(Arrlist[k - 4]))
    //                                {

    //                                    DR[i + k + 3] = "Left";
    //                                }
    //                            }
    //                        }
    //                    }
    //                }
    //            }

    //        }
    //    }

    //    if (sno > 1 && ddlReportType.SelectedValue== "Client Report")
    //    {

    //        DT.Rows.Add(DR);

    //        if (ddlReportType.SelectedValue == "Without Data")
    //        {
    //            for (int Newrows = 0; Newrows < 5; Newrows++)
    //            {
    //                DT.Rows.Add();
    //                DR = DT.NewRow();
    //                DT.Rows.Add(DR);
    //            }

    //            DT.Rows.Add();
    //            DR = DT.NewRow();
    //            DR["Full Name"] = "Attendance Incharge Signature";
    //            DT.Rows.Add(DR);

    //            DT.Rows.Add();
    //            DR = DT.NewRow();
    //            DR["Full Name"] = "Attendance Incharge Name";
    //            DT.Rows.Add(DR);

    //        }
    //        GVDE.DataSource = DT;
    //        GVDE.DataBind();
    //        AssignLableMessage();
    //    }
    //    else
    //    {
    //        GVDE.DataSource = DT;
    //        GVDE.DataBind();
    //    }
    //}

    private void BindDateWise_Gridview()
    {
        try
        {
            dr.FromDt = con.strDate(txtFromDate.Text.ToString());
            dr.ToDt = con.strDate(txtToDate.Text.ToString());
        }

        catch
        {
            lblHierChichy.Text = "Please Enter Valid Date Format DD/MM/YYYY ";
            return;
        }

        OleDbDataReader BindDataReader;


        string DateDiff = Convert.ToString(Convert.ToDateTime(dr.ToDt).Date - Convert.ToDateTime(dr.FromDt).Date);
        int FindSubstring;
        FindSubstring = Convert.ToInt32(DateDiff.ToString().IndexOf(".", 1));

        int Datediff;
        if (FindSubstring == -1)
        {
            FindSubstring = 0;
            Datediff = 0;
        }
        else
        {
            Datediff = Convert.ToInt32(DateDiff.ToString().Substring(0, FindSubstring));
        }

        string strSubCenter = "";


        string strCntre = "";
        string strCluster = "";


        //bool result = Session["RoleId"].ToString().Contains("24");
        //bool ansCluster = Session["RoleId"].ToString().Contains("25");
        //bool ansCenter = Session["RoleId"].ToString().Contains("23");

        if (ddlCentre.SelectedValue == "" && ddlSubCentre.SelectedValue == "" && ddlCluster.SelectedValue == "")
        {
            strSubCenter = dr.ShowSubCenterData(Session["UserId"].ToString());
            SCentreName = strSubCenter.Split(',');
            strSubCenter = SCentreName[0];
            strCntre = Session["CentreId"].ToString();
            strCluster = dr.ShowClusterData(Session["UserId"].ToString());
        }
        else
        {
            strSubCenter = ddlSubCentre.SelectedValue;
        }

        BindDataReader = dr.ShowRolewiseEmplSalaryStatus(strCntre, strSubCenter, ddlReportType.SelectedValue, strCluster);//(ddlCentre.SelectedValue, strSubCenter, ddlReportType.SelectedValue, ddlCluster.SelectedValue);
        DataTable DT = new DataTable();
        DataColumn DC = new DataColumn();
        if (ddlReportType.SelectedValue == "Login Tracker")
        {
            DC = new DataColumn("Sr.No", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("FOS Code", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("FOS Name", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("Hub", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("DD Payable Location", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("Department Name", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("Login Date & Time", typeof(System.String));
            DT.Columns.Add(DC);


        }
        else if (ddlReportType.SelectedValue == "Password Updation Report")
        {
            DC = new DataColumn("Sr.No", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("FOS Code", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("FOS Name", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("Hub", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("DD Payable Location", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("Department Name", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("Password Change Date", typeof(System.String));
            DT.Columns.Add(DC);
        }
        else
        {
            DC = new DataColumn("Sr.No", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("FOS Code", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("FOS Name", typeof(System.String));
            DT.Columns.Add(DC);
           
            DC = new DataColumn("Hub", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("DD Payable Location", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("Department", typeof(System.String));
            DT.Columns.Add(DC);

            DC = new DataColumn("EmpType", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("Absent");
            DT.Columns.Add(DC);
            DC = new DataColumn("Present");
            DT.Columns.Add(DC);
        }

        int i = 0;
        if (ddlReportType.SelectedValue != "Login Tracker" && ddlReportType.SelectedValue != "Password Updation Report")
        {
            for (i = 0; i <= Datediff; i++)
            {
                DC = new DataColumn(" " + Convert.ToDateTime(dr.FromDt).AddDays(i).ToString("ddd") + ' ' + Convert.ToInt32(Convert.ToDateTime(dr.FromDt).AddDays(i).ToString("dd")) + " ", typeof(System.String));
                DT.Columns.Add(DC);
                Arrlist.Add(Convert.ToDateTime(dr.FromDt).AddDays(i).ToString());
            }
        }
        //for (i = 0; i <= Datediff; i++)
        //{

        //    DC = new DataColumn(" " + Convert.ToDateTime(dr.FromDt).AddDays(i).ToString("ddd") + ' ' + Convert.ToInt32(Convert.ToDateTime(dr.FromDt).AddDays(i).ToString("dd")) + " ", typeof(System.String));
        //    DT.Columns.Add(DC);
        //    Arrlist.Add(Convert.ToDateTime(dr.FromDt).AddDays(i).ToString());
        //}
        i = 0;
        int j = 0;
        int sno = 1;
        int countA = 0;
        int countP = 0;
        string EmpCode = "";
        DataRow DR;
        DR = DT.NewRow();
        string ColumnValue;
        Boolean ans = false;
        if (ddlReportType.SelectedValue == "Login Tracker" && Datediff >= 0)
        {
            while (BindDataReader.Read())
            {
                DR = DT.NewRow();
                DR["Sr.No"] = sno++;
                DR["FOS Code"] = BindDataReader["emp_code"].ToString();
                DR["FOS Name"] = BindDataReader["Emp Name"].ToString();
                DR["Hub"] = BindDataReader["Location"].ToString();
                DR["DD Payable Location"] = BindDataReader["Sub Location"].ToString();
                DR["Department Name"] = BindDataReader["Department Name"].ToString();
                DR["Login Date & Time"] = BindDataReader["Login Date & Time"].ToString();
                DT.Rows.Add(DR);



            }
        }
        else if (ddlReportType.SelectedValue == "Password Updation Report" && Datediff >= 0)
        {
            while (BindDataReader.Read())
            {
                DR = DT.NewRow();
                DR["Sr.No"] = sno++;
                DR["FOS Code"] = BindDataReader["emp_code"].ToString();
                DR["FOS Name"] = BindDataReader["Emp Name"].ToString();
                DR["Hub"] = BindDataReader["Location"].ToString();
                DR["DD Payable Location"] = BindDataReader["Sub Location"].ToString();
                DR["Department Name"] = BindDataReader["Department Name"].ToString();
                DR["Password Change Date"] = BindDataReader["Password Change Date"].ToString();
                DT.Rows.Add(DR);



            }
        }
        else if (ddlReportType.SelectedValue == "Without Data" && Datediff >= 0)
        {
            int SunCnt = 0;
            foreach (DataColumn ColumnSunday in DT.Columns)
            {
                if (ColumnSunday.ToString().Length > 3)
                {
                    if (ColumnSunday.ToString().Substring(1, 3) == "Sun")
                    {
                        if (ColumnSundayHeader == "")
                        {
                            ColumnSundayHeader = Convert.ToString(SunCnt);
                        }
                        else
                        {
                            ColumnSundayHeader = ColumnSundayHeader + ',' + Convert.ToString(SunCnt);
                        }
                        ColumnValue = ColumnSunday.ToString();
                    }
                    SunCnt++;
                }
            }

            while (BindDataReader.Read())
            {
                DR["Sr.No"] = sno;
                DR["FOS Code"] = BindDataReader["emp_code"];
                DR["Hub"] = BindDataReader["Centre_Name"];
                DR["DD Payable Location"] = BindDataReader["SubCentreName"];
                DR["FOS Name"] = BindDataReader["fullname"];
                DR["Department"] = BindDataReader["Department"];
                DR["EmpType"] = BindDataReader["Category"];
                DR["Absent"] = countA;
                DR["Present"] = countP;


                DT.Rows.Add(DR);
                DT.Rows.Add();
                DR = DT.NewRow();
                sno++;
            }

            for (int Newrows = 0; Newrows < 5; Newrows++)
            {
                DT.Rows.Add();
                DR = DT.NewRow();
                DT.Rows.Add(DR);
            }

            DT.Rows.Add();
            DR = DT.NewRow();
            DR["Full Name"] = "Attendance Incharge Signature";
            DT.Rows.Add(DR);

            DT.Rows.Add();
            DR = DT.NewRow();
            DR["Full Name"] = "Attendance Incharge Name";
            DT.Rows.Add(DR);

            GVDE.DataSource = DT;
            GVDE.DataBind();
            AssignLableMessage();

        }
        else if (ddlReportType.SelectedValue != "Without Data" && Datediff >= 0)
        {

            while (BindDataReader.Read())
            {

                if (i == 0)
                {
                    EmpCode = BindDataReader["emp_code"].ToString();
                    i++;
                }
                if (j == 0 && i == 1)
                {

                    DR["Sr.No"] = sno++;
                    DR["Hub"] = BindDataReader["Centre_Name"];
                    DR["DD Payable Location"] = BindDataReader["SubCentreName"];
                    DR["FOS Code"] = BindDataReader["emp_code"].ToString();
                    DR["FOS Name"] = BindDataReader["fullname"].ToString();
                    DR["Department"] = BindDataReader["Department"].ToString();
                    DR["EmpType"] = BindDataReader["Category"].ToString();
                    DR["Absent"] = countA;
                    DR["Present"] = countP;


                    j++;
                    i++;
                }

                if (EmpCode != BindDataReader["Emp_Code"].ToString())
                {
                    DT.Rows.Add(DR);

                    DT.Rows.Add();
                    DR = DT.NewRow();
                    EmpCode = BindDataReader["Emp_Code"].ToString();
                    DR["Sr.No"] = sno++;
                    DR["Hub"] = BindDataReader["Centre_Name"];
                    DR["DD Payable Location"] = BindDataReader["SubCentreName"];
                    DR["FOS Code"] = BindDataReader["emp_code"].ToString();
                    DR["FOS Name"] = BindDataReader["fullname"];
                    DR["Department"] = BindDataReader["Department"];
                    DR["EmpType"] = BindDataReader["Category"];
                    DR["Absent"] = countA;
                    DR["Present"] = countP;


                    j = 0;

                }
                if (EmpCode == BindDataReader["emp_code"].ToString())
                {
                    int cnt = 0;
                    foreach (DataColumn ColumnSunday in DT.Columns)
                    {
                        if (ColumnSunday.ToString().Length > 3)
                        {
                            if (ColumnSunday.ToString().Substring(1, 3) == "Sun")
                            {
                                if (ans == false)
                                {
                                    if (ColumnSundayHeader == "")
                                    {
                                        ColumnSundayHeader = Convert.ToString(cnt);
                                    }
                                    else
                                    {
                                        ColumnSundayHeader = ColumnSundayHeader + ',' + Convert.ToString(cnt);
                                    }
                                }
                                ColumnSundayHeader = ColumnSundayHeader + ',' + Convert.ToString(cnt);
                                ColumnValue = ColumnSunday.ToString();
                                if (ddlReportType.SelectedValue != "Without Data")
                                {
                                    if (BindDataReader["status"].ToString() != "L")
                                        DR["" + ColumnValue + ""] = "WO";
                                    else
                                        DR["" + ColumnValue + ""] = "L";
                                    // DR["" + ColumnValue + ""] = "P";
                                }
                            }
                        }
                        cnt++;

                    }

                    ans = true;
                    if (BindDataReader["Att_Date"].ToString().Substring(0, 3) != "Sun")
                    {
                        DR[" " + BindDataReader["Att_Date"] + " "] = BindDataReader["status"];
                    }
                    for (int k = 4; k < DT.Columns.Count; k++)
                    {
                        if ((k + i) <= DT.Columns.Count - 1)
                        {
                            if (DR[i + k].ToString() == "")
                            {
                                DR[i + k] = "NA";
                                // DR[i + k] = "A";
                            }

                            if (DT.Columns[i + k].ColumnName.Substring(0, 4).Trim() == "Sat")
                            {
                                if (i + k + 2 < DT.Columns.Count)
                                {

                                    if ((DR[i + k].ToString() == "A" || DR[i + k].ToString() == "") && (DR[i + k + 2].ToString() == "A" || DR[i + k + 2].ToString() == ""))
                                    {
                                        DR[i + k + 1] = "A";
                                    }
                                }

                            }


                            if (BindDataReader["DOL"].ToString() != null && BindDataReader["DOL"].ToString() != "")
                            {
                                if (k <= DT.Columns.Count - 6)
                                {
                                    if (Convert.ToDateTime(BindDataReader["DOL"]) <= Convert.ToDateTime(Arrlist[k - 4]))
                                    {
                                        DR[i + k + 3] = "Left";
                                    }
                                }
                            }
                        }
                    }
                }




            }
        }

        if (sno > 1 && ddlReportType.SelectedValue == "Client Report")
        //  if (sno > 1 && ddlReportType.SelectedValue != "Without Data")
        {

            DT.Rows.Add(DR);




            if (ddlReportType.SelectedValue == "Without Data")
            {
                for (int Newrows = 0; Newrows < 5; Newrows++)
                {
                    DT.Rows.Add();
                    DR = DT.NewRow();
                    DT.Rows.Add(DR);
                }

                DT.Rows.Add();
                DR = DT.NewRow();
                DR["Full Name"] = "Attendance Incharge Signature";
                DT.Rows.Add(DR);

                DT.Rows.Add();
                DR = DT.NewRow();
                DR["Full Name"] = "Attendance Incharge Name";
                DT.Rows.Add(DR);

            }
            GVDE.DataSource = DT;
            GVDE.DataBind();
            AssignLableMessage();
        }
        else
        {
            GVDE.DataSource = DT;
            GVDE.DataBind();
        }
    }


    //private void BindDateWise_Gridview_Client()
    //{
    //    try
    //    {
    //        dr.FromDt = con.strDate(txtFromDate.Text.ToString());
    //        dr.ToDt = con.strDate(txtToDate.Text.ToString());
    //    }

    //    catch
    //    {
    //        lblHierChichy.Text = "Please Enter Valid Date Format DD/MM/YYYY ";
    //        return;
    //    }

    //    OleDbDataReader BindDataReader;

    //    string DateDiff = Convert.ToString(Convert.ToDateTime(dr.ToDt).Date - Convert.ToDateTime(dr.FromDt).Date);
    //    int FindSubstring;
    //    FindSubstring = Convert.ToInt32(DateDiff.ToString().IndexOf(".", 1));

    //    int Datediff;
    //    if (FindSubstring == -1)
    //    {
    //        FindSubstring = 0;
    //        Datediff = 0;
    //    }
    //    else
    //    {
    //        Datediff = Convert.ToInt32(DateDiff.ToString().Substring(0, FindSubstring));
    //    }

    //    string strSubCenter = "";

    //    //bool result = Session["RoleId"].ToString().Contains("24");
    //    //bool ansCluster = Session["RoleId"].ToString().Contains("25");
    //    //bool ansCenter = Session["RoleId"].ToString().Contains("23");

    //    if (ddlCentre.SelectedValue == "" && ddlSubCentre.SelectedValue == "" && ddlCluster.SelectedValue == "")
    //    {
    //        strSubCenter = dr.ShowSubCenterData(Session["UserId"].ToString());
    //        SCentreName = strSubCenter.Split(',');
    //        strSubCenter = SCentreName[0];
    //    }
    //    else
    //    {
    //        strSubCenter = ddlSubCentre.SelectedValue;
    //    }
    //    BindDataReader = dr.ShowRolewiseEmplSalaryStatus_Client(ddlCentre.SelectedValue, strSubCenter, ddlReportType.SelectedValue, ddlCluster.SelectedValue);
    //    DataTable DT = new DataTable();
    //    DataColumn DC = new DataColumn();

    //    DC = new DataColumn("Sr.No", typeof(System.String));
    //    DT.Columns.Add(DC);
    //    DC = new DataColumn("Centre", typeof(System.String));
    //    DT.Columns.Add(DC);
    //    DC = new DataColumn("SubCentre", typeof(System.String));
    //    DT.Columns.Add(DC);
    //    DC = new DataColumn("Emp Code", typeof(System.String));
    //    DT.Columns.Add(DC);
    //    DC = new DataColumn("Full Name", typeof(System.String));
    //    DT.Columns.Add(DC);
    //    DC = new DataColumn("Department", typeof(System.String));
    //    DT.Columns.Add(DC);
    //    DC = new DataColumn("EmpType", typeof(System.String));
    //    DT.Columns.Add(DC);
    //    DC = new DataColumn("Absent");
    //    DT.Columns.Add(DC);
    //    DC = new DataColumn("Present");
    //    DT.Columns.Add(DC);


    //    int i = 0;

    //    for (i = 0; i <= Datediff; i++)
    //    {

    //        DC = new DataColumn(" " + Convert.ToDateTime(dr.FromDt).AddDays(i).ToString("ddd") + ' ' + Convert.ToInt32(Convert.ToDateTime(dr.FromDt).AddDays(i).ToString("dd")) + " ", typeof(System.String));
    //        DT.Columns.Add(DC);
    //        Arrlist.Add(Convert.ToDateTime(dr.FromDt).AddDays(i).ToString());
    //    }
    //    i = 0;
    //    int j = 0;
    //    int sno = 1;
    //    int countA = 0;
    //    int countP = 0;
    //    string EmpCode = "";
    //    DataRow DR;
    //    DR = DT.NewRow();
    //    string ColumnValue;
    //    Boolean ans = false;

    //    if (ddlReportType.SelectedValue == "Without Data" && Datediff >= 0)
    //    {
    //        int SunCnt = 0;
    //        foreach (DataColumn ColumnSunday in DT.Columns)
    //        {
    //            if (ColumnSunday.ToString().Substring(1, 3) == "Sun")
    //            {
    //                if (ColumnSundayHeader == "")
    //                {
    //                    ColumnSundayHeader = Convert.ToString(SunCnt);
    //                }
    //                else
    //                {
    //                    ColumnSundayHeader = ColumnSundayHeader + ',' + Convert.ToString(SunCnt);
    //                }
    //                ColumnValue = ColumnSunday.ToString();
    //            }
    //            SunCnt++;
    //        }

    //        while (BindDataReader.Read())
    //        {
    //            DR["Sr.No"] = sno;
    //            DR["Emp Code"] = BindDataReader["emp_code"];
    //            DR["Centre"] = BindDataReader["Centre_Name"];
    //            DR["SubCentre"] = BindDataReader["SubCentreName"];
    //            DR["Full Name"] = BindDataReader["fullname"];
    //            DR["Department"] = BindDataReader["Department"];
    //            DR["EmpType"] = BindDataReader["Category"];
    //            DR["Absent"] = countA;
    //            DR["Present"] = countP;


    //            DT.Rows.Add(DR);
    //            DT.Rows.Add();
    //            DR = DT.NewRow();
    //            sno++;
    //        }

    //        for (int Newrows = 0; Newrows < 5; Newrows++)
    //        {
    //            DT.Rows.Add();
    //            DR = DT.NewRow();
    //            DT.Rows.Add(DR);
    //        }

    //        DT.Rows.Add();
    //        DR = DT.NewRow();
    //        DR["Full Name"] = "Attendance Incharge Signature";
    //        DT.Rows.Add(DR);

    //        DT.Rows.Add();
    //        DR = DT.NewRow();
    //        DR["Full Name"] = "Attendance Incharge Name";
    //        DT.Rows.Add(DR);

    //        GVDE.DataSource = DT;
    //        GVDE.DataBind();
    //        AssignLableMessage();

    //    }
    //    else if (ddlReportType.SelectedValue != "Without Data" && Datediff >= 0)
    //    {

    //        while (BindDataReader.Read())
    //        {

    //            if (i == 0)
    //            {
    //                EmpCode = BindDataReader["emp_code"].ToString();
    //                i++;
    //            }
    //            if (j == 0 && i == 1)
    //            {

    //                DR["Sr.No"] = sno++;
    //                DR["Centre"] = BindDataReader["Centre_Name"];
    //                DR["SubCentre"] = BindDataReader["SubCentreName"];
    //                DR["Emp Code"] = BindDataReader["emp_code"].ToString();
    //                DR["Full Name"] = BindDataReader["fullname"].ToString();
    //                DR["Department"] = BindDataReader["Department"].ToString();
    //                DR["EmpType"] = BindDataReader["Category"].ToString();
    //                DR["Absent"] = countA;
    //                DR["Present"] = countP;


    //                j++;
    //                i++;
    //            }

    //            if (EmpCode != BindDataReader["Emp_Code"].ToString())
    //            {
    //                DT.Rows.Add(DR);

    //                DT.Rows.Add();
    //                DR = DT.NewRow();
    //                EmpCode = BindDataReader["Emp_Code"].ToString();
    //                DR["Sr.No"] = sno++;
    //                DR["Centre"] = BindDataReader["Centre_Name"];
    //                DR["SubCentre"] = BindDataReader["SubCentreName"];
    //                DR["Emp Code"] = BindDataReader["emp_code"].ToString();
    //                DR["Full Name"] = BindDataReader["fullname"];
    //                DR["Department"] = BindDataReader["Department"];
    //                DR["EmpType"] = BindDataReader["Category"];
    //                DR["Absent"] = countA;
    //                DR["Present"] = countP;


    //                j = 0;

    //            }
    //            if (EmpCode == BindDataReader["emp_code"].ToString())
    //            {
    //                int cnt = 0;
    //                foreach (DataColumn ColumnSunday in DT.Columns)
    //                {
    //                    if (ColumnSunday.ToString().Substring(1, 3) == "Sun")
    //                    {
    //                        if (ans == false)
    //                        {
    //                            if (ColumnSundayHeader == "")
    //                            {
    //                                ColumnSundayHeader = Convert.ToString(cnt);
    //                            }
    //                            else
    //                            {
    //                                ColumnSundayHeader = ColumnSundayHeader + ',' + Convert.ToString(cnt);
    //                            }
    //                        }
    //                        ColumnSundayHeader = ColumnSundayHeader + ',' + Convert.ToString(cnt);
    //                        ColumnValue = ColumnSunday.ToString();
    //                        if (ddlReportType.SelectedValue != "Without Data")
    //                        {
    //                            DR["" + ColumnValue + ""] = "P";
    //                        }
    //                    }
    //                    cnt++;

    //                }

    //                ans = true;
    //                if (BindDataReader["Att_Date"].ToString().Substring(0, 3) != "Sun")
    //                {
    //                    DR[" " + BindDataReader["Att_Date"] + " "] = BindDataReader["status"];
    //                }
    //                for (int k = 4; k < DT.Columns.Count; k++)
    //                {
    //                    if ((k + i) <= DT.Columns.Count - 1)
    //                    {
    //                        if (DR[i + k].ToString() == "")
    //                        {
    //                            DR[i + k] = "A";
    //                        }

    //                        if (DT.Columns[i + k].ColumnName.Substring(0, 4).Trim() == "Sat")
    //                        {
    //                            if (i + k + 2 < DT.Columns.Count)
    //                            {

    //                                if ((DR[i + k].ToString() == "A" || DR[i + k].ToString() == "") && (DR[i + k + 2].ToString() == "A" || DR[i + k + 2].ToString() == ""))
    //                                {
    //                                    DR[i + k + 1] = "A";
    //                                }
    //                            }

    //                        }


    //                        if (BindDataReader["DOL"].ToString() != null && BindDataReader["DOL"].ToString() != "")
    //                        {
    //                            if (k <= DT.Columns.Count - 6)
    //                            {
    //                                if (Convert.ToDateTime(BindDataReader["DOL"]) <= Convert.ToDateTime(Arrlist[k - 4]))
    //                                {
    //                                    DR[i + k + 3] = "Left";
    //                                }
    //                            }
    //                        }
    //                    }
    //                }
    //            }




    //        }
    //    }

    //    if (sno > 1 && ddlReportType.SelectedValue != "Without Data")
    //    {

    //        DT.Rows.Add(DR);




    //        if (ddlReportType.SelectedValue == "Without Data")
    //        {
    //            for (int Newrows = 0; Newrows < 5; Newrows++)
    //            {
    //                DT.Rows.Add();
    //                DR = DT.NewRow();
    //                DT.Rows.Add(DR);
    //            }

    //            DT.Rows.Add();
    //            DR = DT.NewRow();
    //            DR["Full Name"] = "Attendance Incharge Signature";
    //            DT.Rows.Add(DR);

    //            DT.Rows.Add();
    //            DR = DT.NewRow();
    //            DR["Full Name"] = "Attendance Incharge Name";
    //            DT.Rows.Add(DR);

    //        }
    //        GVDE.DataSource = DT;
    //        GVDE.DataBind();
    //        AssignLableMessage();
    //    }
    //    else
    //    {

    //    }
    //}

    //add by rani

    private void BindDateWise_Gridview_Client()
    {
        try
        {
            dr.FromDt = con.strDate(txtFromDate.Text.ToString());
            dr.ToDt = con.strDate(txtToDate.Text.ToString());
        }

        catch
        {
            lblHierChichy.Text = "Please Enter Valid Date Format DD/MM/YYYY ";
            return;
        }

        OleDbDataReader BindDataReader;


        string DateDiff = Convert.ToString(Convert.ToDateTime(dr.ToDt).Date - Convert.ToDateTime(dr.FromDt).Date);
        int FindSubstring;
        FindSubstring = Convert.ToInt32(DateDiff.ToString().IndexOf(".", 1));

        int Datediff;
        if (FindSubstring == -1)
        {
            FindSubstring = 0;
            Datediff = 0;
        }
        else
        {
            Datediff = Convert.ToInt32(DateDiff.ToString().Substring(0, FindSubstring));
        }

        string strSubCenter = "";


        string strCntre = "";
        string strCluster = "";
        string RmempId = "";
        string RsmempId = "";
        //bool result = Session["RoleId"].ToString().Contains("24");
        //bool ansCluster = Session["RoleId"].ToString().Contains("25");
        //bool ansCenter = Session["RoleId"].ToString().Contains("23");

        if (ddlCentre.SelectedValue == "" && ddlSubCentre.SelectedValue == "" && ddlCluster.SelectedValue == "")
        {
            strSubCenter = dr.ShowSubCenterData(Session["UserId"].ToString());
            SCentreName = strSubCenter.Split(',');
            strSubCenter = SCentreName[0];
            strCntre = Session["CentreId"].ToString();
            strCluster = dr.ShowClusterData(Session["UserId"].ToString());

        }
        else
        {
            strSubCenter = ddlSubCentre.SelectedValue;
        }
        if (Session["RoleId"].ToString() == "7")
        {
            RmempId = Session["UserId"].ToString();
        }
        else
        {
            RsmempId = Session["UserId"].ToString();
        }
        BindDataReader = dr.ShowRolewiseEmplSalaryStatus_Client(strCntre, strSubCenter, ddlReportType.SelectedValue, strCluster, RmempId, RsmempId);//(ddlCentre.SelectedValue, strSubCenter, ddlReportType.SelectedValue, ddlCluster.SelectedValue);

        //DataTable schemaTable = new DataTable();
        //schemaTable.Load(BindDataReader);

        DataTable DT = new DataTable();
        DataColumn DC = new DataColumn();
        if (ddlReportType.SelectedValue == "Login Tracker")
        {
            DC = new DataColumn("Sr.No", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("FOS Code", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("FOS Name", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("Hub", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("DD Payable Location", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("Department Name", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("Login Date & Time", typeof(System.String));
            DT.Columns.Add(DC);


        }
        else if (ddlReportType.SelectedValue == "Password Updation Report")
        {
            DC = new DataColumn("Sr.No", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("FOS Code", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("FOS Name", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("Hub", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("DD Payable Location", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("Department Name", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("Password Change Date", typeof(System.String));
            DT.Columns.Add(DC);
        }
        else
        {
            DC = new DataColumn("Sr.No", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("FOS Code", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("FOS Name", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("Hub", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("DD Payable Location", typeof(System.String));
            DT.Columns.Add(DC);
           
            DC = new DataColumn("Department", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("EmpType", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("Absent");
            DT.Columns.Add(DC);
            DC = new DataColumn("Present");
            DT.Columns.Add(DC);
        }

        int i = 0;
        if (ddlReportType.SelectedValue != "Login Tracker" && ddlReportType.SelectedValue != "Password Updation Report")
        {
            for (i = 0; i <= Datediff; i++)
            {
                DC = new DataColumn(" " + Convert.ToDateTime(dr.FromDt).AddDays(i).ToString("ddd") + ' ' + Convert.ToInt32(Convert.ToDateTime(dr.FromDt).AddDays(i).ToString("dd")) + " ", typeof(System.String));
                DT.Columns.Add(DC);
                Arrlist.Add(Convert.ToDateTime(dr.FromDt).AddDays(i).ToString());
            }
        }
        //for (i = 0; i <= Datediff; i++)
        //{

        //    DC = new DataColumn(" " + Convert.ToDateTime(dr.FromDt).AddDays(i).ToString("ddd") + ' ' + Convert.ToInt32(Convert.ToDateTime(dr.FromDt).AddDays(i).ToString("dd")) + " ", typeof(System.String));
        //    DT.Columns.Add(DC);
        //    Arrlist.Add(Convert.ToDateTime(dr.FromDt).AddDays(i).ToString());
        //}
        i = 0;
        int j = 0;
        int sno = 1;
        int countA = 0;
        int countP = 0;
        string EmpCode = "";
        DataRow DR;
        DR = DT.NewRow();
        string ColumnValue;
        Boolean ans = false;
        if (ddlReportType.SelectedValue == "Login Tracker" && Datediff >= 0)
        {
            while (BindDataReader.Read())
            {
                DR = DT.NewRow();
                DR["Sr.No"] = sno++;
                DR["FOS Code"] = BindDataReader["emp_code"].ToString();
                DR["FOS Name"] = BindDataReader["Emp Name"].ToString();
                DR["Hub"] = BindDataReader["Location"].ToString();
                DR["DD Payable Location"] = BindDataReader["Sub Location"].ToString();
                DR["Department Name"] = BindDataReader["Department Name"].ToString();
                DR["Login Date & Time"] = BindDataReader["Login Date & Time"].ToString();
                DT.Rows.Add(DR);



            }
        }
        else if (ddlReportType.SelectedValue == "Password Updation Report" && Datediff >= 0)
        {
            while (BindDataReader.Read())
            {
                DR = DT.NewRow();
                DR["Sr.No"] = sno++;
                DR["FOS Code"] = BindDataReader["emp_code"].ToString();
                DR["FOS Name"] = BindDataReader["Emp Name"].ToString();
                DR["Hub"] = BindDataReader["Location"].ToString();
                DR["DD Payable Location"] = BindDataReader["Sub Location"].ToString();
                DR["Department Name"] = BindDataReader["Department Name"].ToString();
                DR["Password Change Date"] = BindDataReader["Password Change Date"].ToString();
                DT.Rows.Add(DR);



            }
        }
        else if (ddlReportType.SelectedValue == "Without Data" && Datediff >= 0)
        {
            int SunCnt = 0;
            foreach (DataColumn ColumnSunday in DT.Columns)
            {
                if (ColumnSunday.ToString().Length > 3)
                {
                    if (ColumnSunday.ToString().Substring(1, 3) == "Sun")
                    {
                        if (ColumnSundayHeader == "")
                        {
                            ColumnSundayHeader = Convert.ToString(SunCnt);
                        }
                        else
                        {
                            ColumnSundayHeader = ColumnSundayHeader + ',' + Convert.ToString(SunCnt);
                        }
                        ColumnValue = ColumnSunday.ToString();
                    }
                    SunCnt++;
                }
            }

            while (BindDataReader.Read())
            {
                DR["Sr.No"] = sno;
                DR["FOS Code"] = BindDataReader["emp_code"];
                DR["Hub"] = BindDataReader["Centre_Name"];
                DR["DD Payable Location"] = BindDataReader["SubCentreName"];
                DR["FOS Name"] = BindDataReader["fullname"];
                DR["Department"] = BindDataReader["Department"];
                DR["EmpType"] = BindDataReader["Category"];
                DR["Absent"] = countA;
                DR["Present"] = countP;


                DT.Rows.Add(DR);
                DT.Rows.Add();
                DR = DT.NewRow();
                sno++;
            }

            for (int Newrows = 0; Newrows < 5; Newrows++)
            {
                DT.Rows.Add();
                DR = DT.NewRow();
                DT.Rows.Add(DR);
            }

            DT.Rows.Add();
            DR = DT.NewRow();
            DR["Full Name"] = "Attendance Incharge Signature";
            DT.Rows.Add(DR);

            DT.Rows.Add();
            DR = DT.NewRow();
            DR["Full Name"] = "Attendance Incharge Name";
            DT.Rows.Add(DR);

            GVDE.DataSource = DT;
            GVDE.DataBind();
            AssignLableMessage();

        }
        else if (ddlReportType.SelectedValue != "Without Data" && Datediff >= 0)
        {

            while (BindDataReader.Read())
            {

                if (i == 0)
                {
                    EmpCode = BindDataReader["emp_code"].ToString();
                    i++;
                }
                if (j == 0 && i == 1)
                {

                    DR["Sr.No"] = sno++;
                    DR["Hub"] = BindDataReader["Centre_Name"];
                    DR["DD Payable Location"] = BindDataReader["SubCentreName"];
                    DR["FOS Code"] = BindDataReader["emp_code"].ToString();
                    DR["FOS Name"] = BindDataReader["fullname"].ToString();
                    DR["Department"] = BindDataReader["Department"].ToString();
                    DR["EmpType"] = BindDataReader["Category"].ToString();
                    DR["Absent"] = countA;
                    DR["Present"] = countP;


                    j++;
                    i++;
                }

                if (EmpCode != BindDataReader["Emp_Code"].ToString())
                {
                    DT.Rows.Add(DR);

                    DT.Rows.Add();
                    DR = DT.NewRow();
                    EmpCode = BindDataReader["Emp_Code"].ToString();
                    DR["Sr.No"] = sno++;
                    DR["Hub"] = BindDataReader["Centre_Name"];
                    DR["DD Payable Location"] = BindDataReader["SubCentreName"];
                    DR["FOS Code"] = BindDataReader["emp_code"].ToString();
                    DR["FOS Name"] = BindDataReader["fullname"];
                    DR["Department"] = BindDataReader["Department"];
                    DR["EmpType"] = BindDataReader["Category"];
                    DR["Absent"] = countA;
                    DR["Present"] = countP;


                    j = 0;

                }
                if (EmpCode == BindDataReader["emp_code"].ToString())
                {
                    int cnt = 0;
                    foreach (DataColumn ColumnSunday in DT.Columns)
                    {
                        if (ColumnSunday.ToString().Length > 3)
                        {
                            if (ColumnSunday.ToString().Substring(1, 3) == "Sun")
                            {
                                if (ans == false)
                                {
                                    if (ColumnSundayHeader == "")
                                    {
                                        ColumnSundayHeader = Convert.ToString(cnt);
                                    }
                                    else
                                    {
                                        ColumnSundayHeader = ColumnSundayHeader + ',' + Convert.ToString(cnt);
                                    }
                                }
                                ColumnSundayHeader = ColumnSundayHeader + ',' + Convert.ToString(cnt);
                                ColumnValue = ColumnSunday.ToString();
                                if (ddlReportType.SelectedValue != "Without Data")//&& BindDataReader["status"].ToString()!="L" )
                                {
                                    //if(!Convert.ToString(BindDataReader["Att_Date"]).Contains(ColumnSunday.ToString()))
                                    //DR["" + ColumnValue + ""] = "WO";
                                    //else 
                                    if (BindDataReader["status"].ToString() != "L")
                                        DR["" + ColumnValue + ""] = "WO";
                                    else
                                        DR["" + ColumnValue + ""] = "L";



                                }

                            }
                        }


                        cnt++;


                    }

                    ans = true;

                    if (BindDataReader["Att_Date"].ToString().Substring(0, 3) != "Sun")
                    {
                        DR[" " + BindDataReader["Att_Date"] + " "] = BindDataReader["status"];
                    }
                    for (int k = 4; k < DT.Columns.Count; k++)
                    {
                        if ((k + i) <= DT.Columns.Count - 1)
                        {
                            if (DR[i + k].ToString() == "")
                            {
                                DR[i + k] = "NA";
                            }

                            if (DT.Columns[i + k].ColumnName.Substring(0, 4).Trim() == "Sat")
                            {
                                if (i + k + 2 < DT.Columns.Count)
                                {

                                    if ((DR[i + k].ToString() == "A" || DR[i + k].ToString() == "") && (DR[i + k + 2].ToString() == "A" || DR[i + k + 2].ToString() == ""))
                                    {
                                        DR[i + k + 1] = "A";
                                    }
                                }

                            }


                            if (BindDataReader["DOL"].ToString() != null && BindDataReader["DOL"].ToString() != "")
                            {
                                if (k <= DT.Columns.Count - 6)
                                {
                                    if (Convert.ToDateTime(BindDataReader["DOL"]) <= Convert.ToDateTime(Arrlist[k - 4]))
                                    {
                                        DR[i + k + 3] = "Left";
                                    }
                                }
                            }
                        }
                    }
                }




            }
        }

        if (sno > 1 && ddlReportType.SelectedValue == "Client Report")
        //  if (sno > 1 && ddlReportType.SelectedValue != "Without Data")
        {

            DT.Rows.Add(DR);




            if (ddlReportType.SelectedValue == "Without Data")
            {
                for (int Newrows = 0; Newrows < 5; Newrows++)
                {
                    DT.Rows.Add();
                    DR = DT.NewRow();
                    DT.Rows.Add(DR);
                }

                DT.Rows.Add();
                DR = DT.NewRow();
                DR["Full Name"] = "Attendance Incharge Signature";
                DT.Rows.Add(DR);

                DT.Rows.Add();
                DR = DT.NewRow();
                DR["Full Name"] = "Attendance Incharge Name";
                DT.Rows.Add(DR);

            }
            GVDE.DataSource = DT;
            GVDE.DataBind();
            AssignLableMessage();
        }
        else
        {
            GVDE.DataSource = DT;
            GVDE.DataBind();
        }
    }

    protected void ChangeColorForSunday(object sender, GridViewRowEventArgs e)
    {
        if (ColumnSundayHeader.Length <= 0)
            return;
        String[] ColumnIndex;
        ColumnIndex = ColumnSundayHeader.Split(',');
        foreach (string str in ColumnIndex)
        {
            if (str.Length > 0)
            {
                if (e.Row.RowIndex != -1 && e.Row.Cells[0].Text != "&nbsp;")
                {
                    e.Row.Cells[Convert.ToInt16(str)].BackColor = Color.BlanchedAlmond;



                }
            }
        }

        if (e.Row.RowType == DataControlRowType.Header)
        {
            foreach (TableCell cell in e.Row.Cells)
            {

                foreach (Control ctl in cell.Controls)
                {


                }

            }
        }

        int CountAbsent = 0;
        int CountPresent = 0;
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.Cells[0].Text != "&nbsp;")
        {
            for (int i = 9; i <= e.Row.Cells.Count - 1; i++)
            {
                if (e.Row.Cells[i].Text == "A")
                {

                    CountAbsent = CountAbsent + 1;
                }
                if (e.Row.Cells[i].Text == "P")
                {

                    CountPresent = Convert.ToInt32(CountPresent) + 1;

                }
            }

            string result = Session["RoleId"].ToString();     // result is true
            if (result == "1")
            {
                e.Row.Cells[7].Text = CountAbsent.ToString();
                e.Row.Cells[8].Text = CountPresent.ToString();

                decimal Total = (Convert.ToDecimal(e.Row.Cells[8].Text) / 30) * (Convert.ToDecimal(e.Row.Cells[8].Text));

                e.Row.Cells[6].Text = Convert.ToString(Convert.ToInt32(Total));
            }
            else
            {
                e.Row.Cells[7].Text = CountAbsent.ToString();
                e.Row.Cells[8].Text = CountPresent.ToString();
            }


        }

    }
    protected void GVDE_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void imgbtnExport_Click(object sender, ImageClickEventArgs e)
    {


        string result = Session["RoleId"].ToString();     // result is true
        if (result == "1")
        {
            BindDateWise_Gridview();
        }
        else
        {
            BindDateWise_Gridview_Client();
        }



        string strCentre;

        if (GVDE.Rows.Count > 0)
        {
            String attachment = "attachment; filename=DAT Daily Report.xls";
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Table tblSpace = new Table();
            TableRow tblRow = new TableRow();
            TableCell tblCell = new TableCell();
            tblCell.Text = " ";

            TableRow tblRow1 = new TableRow();
            TableCell tblCell1 = new TableCell();
            tblCell1.ColumnSpan = 20;// 10;
            tblCell1.Text = "<b><font size='3'>Teamspace Finance Services Pvt Ltd</font></b> <br/>" +
                            "<b><font size='3'></font></b> <br/>" +
                            "<b><font size='2'>DAT Daily Report FROM : " + dr.FromDt + "  TO : " + dr.ToDt + "  </font></b> <br/>" +
            "<b><font size='3'></font></b> <br/>";
            tblCell1.CssClass = "FormHeading";
            tblRow.Cells.Add(tblCell);
            tblRow1.Cells.Add(tblCell1);
            tblRow.Height = 20;
            tblSpace.Rows.Add(tblRow);
            tblSpace.Rows.Add(tblRow1);
            tblSpace.RenderControl(htw);
            Table tbl = new Table();
            GVDE.GridLines = GridLines.Both;
            GVDE.EnableViewState = false;
            GVDE.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }


    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            lblReportTitle.Text = "";
            GVDE.DataSource = null;
            GVDE.DataBind();

            string result11 = Session["RoleId"].ToString();     // result is true
            if (result11 == "1")
            {
                BindDateWise_Gridview();
            }
            else
            {
                BindDateWise_Gridview_Client();
            }

            if (GVDE.Rows.Count == 0)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "No Records Found";
                lblReportTitle.Text = "";
            }


        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message;
        }
    }


}

