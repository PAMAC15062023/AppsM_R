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

public partial class HR_HR_DATREPORT : System.Web.UI.Page
{

    DATREPORT dr = new DATREPORT();
    CCommon con = new CCommon();
    public string lblMessage = "";
    public String[] SCentreName;
    public string ColumnSundayHeader = "";
    int count = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        //        ddlCentre.Attributes.Add("OnChange", "return ddlfill();");
        lblReportTitle.Text = "";
        lblMsg.Text = "";
        if (!IsPostBack)
        {

            ddlCentre.DataSource = dr.Fill_Centre();
            ddlCentre.DataTextField = "centre_name";
            ddlCentre.DataValueField = "centre_id";
            ddlCentre.DataBind();


            ListItem item = new ListItem("--All Centres--", "");
            ddlCentre.Items.Insert(0, item);


        }
    }
    protected void btnShow_Click(object sender, CommandEventArgs e)
    {

    }
    protected void btnExportToExcel_Click(object sender, CommandEventArgs e)
    {

    }
    private void FillGrid()
    {
        try
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

            btnExportToExcel.Enabled = true;
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

            bool result = Session["RoleId"].ToString().Contains("24");
            //bool ansCluster = Session["RoleId"].ToString().Contains("25");
            bool ansCenter = Session["RoleId"].ToString().Contains("23");
            if (ddlCentre.SelectedValue == "" && ddlSubCentre.SelectedValue == "" && result == false && ansCenter == false)
            {
                strSubCenter = dr.ShowSubCenterData(Session["UserId"].ToString());
                SCentreName = strSubCenter.Split(',');
                strSubCenter = SCentreName[0];
            }
            else
            {
                strSubCenter = ddlSubCentre.SelectedValue;
            }
            BindDataReader = dr.ShowAttendanceCountReport(ddlCentre.SelectedValue, strSubCenter);
            DataTable DT = new DataTable();
            DataColumn DC = new DataColumn();

            DC = new DataColumn("Sr.No", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("Centre", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("SubCentre", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("Emp Code", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("Pamacian", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("Dept", typeof(System.String));
            DT.Columns.Add(DC);
            //added by kamal matekar
            DC = new DataColumn("Category", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("Units", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("Activity", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("Designation", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("Qualification", typeof(System.String));
            DT.Columns.Add(DC);
            DC = new DataColumn("Date of Join", typeof(System.String));
            DT.Columns.Add(DC);
            int i = 0;

            for (i = 0; i <= Datediff; i++)
            {

                //        BindDateWise_Gridview["Att_Date"]            

                //        DC = new DataColumn(" " + Convert.ToInt32(Convert.ToDateTime(dr.FromDt).AddDays(i).ToString("dd")) + " ", typeof(System.String));
                DC = new DataColumn(" " + Convert.ToDateTime(dr.FromDt).AddDays(i).ToString("ddd") + ' ' + Convert.ToInt32(Convert.ToDateTime(dr.FromDt).AddDays(i).ToString("dd")) + " ", typeof(System.String));
                DT.Columns.Add(DC);

            }

            i = 0;
            int j = 0;
            int sno = 1;
            string EmpCode = "";
            DataRow DR;
            DR = DT.NewRow();
            string ColumnValue;
            Boolean ans = false;

            ///* Code For Without Data Starts here */
            //if (ddlReportType.SelectedValue == "Without Data" && Datediff >= 0)
            //{
            //    int SunCnt = 0;
            //    foreach (DataColumn ColumnSunday in DT.Columns)
            //    {
            //        if (ColumnSunday.ToString().Substring(1, 3) == "Sun")
            //        {
            //            if (ColumnSundayHeader == "")
            //            {
            //                ColumnSundayHeader = Convert.ToString(SunCnt);
            //            }
            //            else
            //            {
            //                ColumnSundayHeader = ColumnSundayHeader + ',' + Convert.ToString(SunCnt);
            //            }
            //            //                        ColumnSundayHeader = ColumnSundayHeader + ',' + Convert.ToString(SunCnt);
            //            ColumnValue = ColumnSunday.ToString();
            //        }
            //        SunCnt++;
            //    }

            //    while (BindDataReader.Read())
            //    {
            //        DR["Sr.No"] = sno;
            //        DR["Emp Code"] = BindDataReader["emp_code"];
            //        DR["Centre"] = BindDataReader["Centre_Name"];
            //        DR["SubCentre"] = BindDataReader["SubCentreName"];
            //        DR["Pamacian"] = BindDataReader["fullname"];
            //        DR["Dept"] = BindDataReader["Department"];

            //        DT.Rows.Add(DR);
            //        DT.Rows.Add();
            //        DR = DT.NewRow();
            //        sno++;
            //    }
            //     for (int Newrows = 0; Newrows < 5; Newrows++)
            //    {
            //        DT.Rows.Add();
            //        DR = DT.NewRow();
            //        DT.Rows.Add(DR);
            //    }

            //    DT.Rows.Add();
            //    DR = DT.NewRow();
            //    DR["Pamacian"] = "Attendance Incharge Signature";
            //    DT.Rows.Add(DR);

            //    DT.Rows.Add();
            //    DR = DT.NewRow();
            //    DR["Pamacian"] = "Attendance Incharge Name";
            //    DT.Rows.Add(DR);

            //    GVDE.DataSource = DT;
            //    GVDE.DataBind();

            //    lblReportTitle.Text = "List of Employee Details From " + dr.FromDt + "  to " + dr.ToDt + " - " + ddlCentre.SelectedItem + " - " + ddlSubCentre.SelectedItem + " ";
            //}
            if (Datediff >= 0)
            {
                /* Ends Here */
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
                        DR["Centre"] = BindDataReader["Centre_Name"];
                        DR["SubCentre"] = BindDataReader["SubCentreName"];
                        DR["Emp Code"] = BindDataReader["emp_code"].ToString();
                        DR["Pamacian"] = BindDataReader["fullname"].ToString();
                        DR["Dept"] = BindDataReader["Department"].ToString();
                        //added by kamal matekar...
                        DR["Category"] = BindDataReader["Category"].ToString();
                        DR["Units"] = BindDataReader["Units"].ToString();
                        DR["Activity"] = BindDataReader["Activity"].ToString();
                        DR["Designation"] = BindDataReader["Designation"].ToString();
                        DR["Qualification"] = BindDataReader["Qualification"].ToString();
                        DR["Date of Join"] = BindDataReader["Date of Join"].ToString();


                        j++;
                        i++;
                    }

                    if (EmpCode != BindDataReader["Emp_Code"].ToString())
                    {
                        DT.Rows.Add(DR);

                        //for (int k = 4; k < DT.Columns.Count; k++)
                        //{
                        //    if ((k + i) <= DT.Columns.Count - 1)
                        //    {
                        //        if (DR[i + k].ToString() == "")
                        //        {
                        //            DR[i + k] = "A";
                        //        }
                        //        if (DT.Columns[i + k].ColumnName.Substring(0, 4).Trim() == "Sat")
                        //        {
                        //            if (i + k + 2 < DT.Columns.Count)
                        //            {
                        //                if ((DR[i + k].ToString() == "A" || DR[i + k].ToString() == "") && (DR[i + k + 2].ToString() == "A" || DR[i + k + 2].ToString() == ""))
                        //                {
                        //                    DR[i + k + 1] = "A";
                        //                }
                        //                else
                        //                {
                        //                    DR[i + k + 1] = "P";
                        //                }
                        //            }
                        //        }


                        //    }
                        //}
                        DT.Rows.Add();
                        DR = DT.NewRow();
                        EmpCode = BindDataReader["Emp_Code"].ToString();
                        DR["Sr.No"] = sno++;
                        DR["Centre"] = BindDataReader["Centre_Name"];
                        DR["SubCentre"] = BindDataReader["SubCentreName"];
                        DR["Emp Code"] = BindDataReader["emp_code"].ToString();
                        DR["Pamacian"] = BindDataReader["fullname"];
                        DR["Dept"] = BindDataReader["Department"];
                        //added by kamal matekar.....
                        DR["Category"] = BindDataReader["Category"];
                        DR["Units"] = BindDataReader["Units"];
                        DR["Activity"] = BindDataReader["Activity"];
                        DR["Designation"] = BindDataReader["Designation"];
                        DR["Qualification"] = BindDataReader["Qualification"];
                        DR["Date of Join"] = BindDataReader["Date of Join"].ToString();



                        j = 0;

                    }
                    if (EmpCode == BindDataReader["emp_code"].ToString())
                    {
                        int cnt = 0;
                        foreach (DataColumn ColumnSunday in DT.Columns)
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
                                    //commented by kamal matekar
                                    DR[i + k] = "A";
                                     // DR[i + k] = "P";
                                }

                                if (DT.Columns[i + k].ColumnName.Substring(0, 4).Trim() == "Sat")
                                {
                                    if (i + k + 2 < DT.Columns.Count)
                                    {

                                        if ((DR[i + k].ToString() == "A" || DR[i + k].ToString() == "") && (DR[i + k + 2].ToString() == "A" || DR[i + k + 2].ToString() == ""))
                                        {
                                            DR[i + k + 1] = "A";
                                        }
                                        else
                                        {
                                            DR[i + k + 1] = "P";
                                        }
                                    }
                                    //commented by kamal matekar
                                    //else
                                    //{
                                    //    DR[i + k + 1] = "P";
                                    //}
                                }
                               
                            }
                        }
                    }

                    //                string Month = Convert.ToDateTime(((Label)gvBankStatement.Rows[k].FindControl("lbl_mthyr")).Text).ToString("MMMMyyyy");

                }
            }

            if (sno > 1)
            {
                DT.Rows.Add(DR);

                //if (ddlReportType.SelectedValue == "Without Data")
                //{
                //    for (int Newrows = 0; Newrows < 5; Newrows++)
                //    {
                //        DT.Rows.Add();
                //        DR = DT.NewRow();
                //        DT.Rows.Add(DR);
                //    }

                //    DT.Rows.Add();
                //    DR = DT.NewRow();
                //    DR["Pamacian"] = "Attendance Incharge Signature";
                //    DT.Rows.Add(DR);

                //    DT.Rows.Add();
                //    DR = DT.NewRow();
                //    DR["Pamacian"] = "Attendance Incharge Name";
                //    DT.Rows.Add(DR);



                //}
                DataRow drRow;

                

                DataTable dtResult = new DataTable();
                dtResult.Columns.Add("Sr.No");
                dtResult.Columns.Add("Centre");
                dtResult.Columns.Add("SubCentre");
                dtResult.Columns.Add("PAMACian Code");
                dtResult.Columns.Add("PAMACian");
                dtResult.Columns.Add("Dept");
                //added by kamal matekar...
                dtResult.Columns.Add("Category");
                dtResult.Columns.Add("Units");
                dtResult.Columns.Add("Activity");
                dtResult.Columns.Add("Designation");
                dtResult.Columns.Add("Qualification");
                dtResult.Columns.Add("Date of Join");
                //Ended
                dtResult.Columns.Add("Present");
                dtResult.Columns.Add("Absent");


                for (int l = 0; l < DT.Rows.Count; l++)
                {
                    int countA = 0;
                    int countP = 0;

                        drRow = dtResult.NewRow();
                        drRow[0] = DT.Rows[l]["Sr.No"].ToString();
                        drRow[1] = DT.Rows[l]["Centre"].ToString();
                        drRow[2] = DT.Rows[l]["SubCentre"].ToString();
                        drRow[3] = DT.Rows[l]["Emp Code"].ToString();
                        drRow[4] = DT.Rows[l]["Pamacian"].ToString();
                        drRow[5] = DT.Rows[l]["Dept"].ToString();
                        //added by kamal matekar..
                        drRow[6] = DT.Rows[l]["Category"].ToString();
                        drRow[7] = DT.Rows[l]["Units"].ToString();
                        drRow[8] = DT.Rows[l]["Activity"].ToString();
                        drRow[9] = DT.Rows[l]["Designation"].ToString();
                        drRow[10] = DT.Rows[l]["Qualification"].ToString();
                        drRow[11] = DT.Rows[l]["Date of Join"].ToString();

                        if (DT.Rows[l]["Sr.No"].ToString() != "")
                        {

                        for (int m = 0; m < DT.Columns.Count; m++)
                        {

                            //commented by kamal matekar
                           // if (m >= 6)
                            if (m >= 12)
                            {
                                if (DT.Rows[l][m].ToString() == "A")
                                {
                                    countA++;

                                }
                                else
                                {
                                    countP++;
                                }
                            }

                        }
                        //added by kamal matekar....
                        //drRow[6] = Convert.ToString(countP);
                        //drRow[7] = Convert.ToString(countA);

                        drRow[12] = Convert.ToString(countP);
                        drRow[13] = Convert.ToString(countA);
                       
                        //Present = 0;
                        //Absent = 0;

                        dtResult.Rows.Add(drRow);
                        

                    }
                }


                //}


                //dtResult.Columns.Add("Sr.No");
                //dtResult.Columns.Add("Centre");
                //dtResult.Columns.Add("SubCentre");
                //dtResult.Columns.Add("Emp Code");
                //dtResult.Columns.Add("Pamacian");
                //dtResult.Columns.Add("Dept");
                //dtResult.Columns.Add("Present");
                //dtResult.Columns.Add("Absent");
                //if (DT.Rows.Count > 0)
                //{

                //    for (int g = 0; g < DT.Rows.Count; g++)
                //    {
                //        drRow = dtResult.NewRow();
                //        drRow[0] = DT.Rows[g]["Sr.No"].ToString();
                //        drRow[1] = DT.Rows[g]["Centre"].ToString();
                //        drRow[2] = DT.Rows[g]["SubCentre"].ToString();
                //        drRow[3] = DT.Rows[g]["Emp Code"].ToString();
                //        drRow[4] = DT.Rows[g]["Pamacian"].ToString();
                //        drRow[5] = DT.Rows[g]["Dept"].ToString();
                //        drRow[6] = Present;
                //        drRow[7] = Absent;


                //        dtResult.Rows.Add(drRow);


                //    }
                GVDE.DataSource = dtResult;
                GVDE.DataBind();
            }
            else
            {
                GVDE.DataSource = null;
                GVDE.DataBind();

            }
        }
        catch (Exception ex)
        {
            lblMsg.Text= "Error while retreiving records:Filling Grid " + ex.Message;
        }
 }
   

    protected void btnShow_Click(object sender, EventArgs e)
    {
        try
        {

            lblReportTitle.Text = "";
            GVDE.DataSource = null;
            GVDE.DataBind();
            FillGrid();

            if (GVDE.Rows.Count == 0)
            {

                lblMsg.Visible = true;
                lblMsg.Text = "No Records Found";
                lblReportTitle.Text = "";
                //                lblReportTitle.BackColor = Color.Red;
                //                lblReportTitle.ForeColor = Color.Red;
                //                lblReportTitle.BorderColor = Color.Black;
            }

            /*        dr.FromDt = txtFromDate.Text.ToString();
                    dr.ToDt = txtToDate.Text.ToString();
                    btnExportToExcel.Enabled = true;
                    GVDE.DataSource= dr.ShowEmployeedata(ddlCentre.SelectedValue,ddlSubCentre.SelectedValue);
                    GVDE.DataBind(); */
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message;
        }
    }
    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        FillGrid();

        if (GVDE.Rows.Count > 0)
        {
            String attachment = "attachment; filename=DAT REPORT.xls";
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
            tblCell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD., MUMBAI</font></b> <br/>" +
                            "<b><font size='2'>ATTENDANCE COUNT REPORT FROM : " + dr.FromDt + "  TO : " + dr.ToDt + " For " + ddlCentre.SelectedItem.Text + " For " + ddlSubCentre.SelectedItem + " </font></b> <br/>";
            tblCell1.CssClass = "FormHeading";
            tblRow.Cells.Add(tblCell);
            tblRow1.Cells.Add(tblCell1);
            tblRow.Height = 20;
            tblSpace.Rows.Add(tblRow);
            tblSpace.Rows.Add(tblRow1);
            tblSpace.RenderControl(htw);
            Table tbl = new Table();
            GVDE.EnableViewState = false;
            GVDE.GridLines = GridLines.Both;
            GVDE.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
        else
        {
            // lblMsg.Text = "No data to Export";
        }

    }
    protected void FillSubCentre(object sender, EventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = ex.Message;
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void ddlSubCentre_DataBound(object sender, EventArgs e)
    {
        ListItem item = new ListItem("--All Sub Centres--", "");
        ddlSubCentre.Items.Insert(0, item);
    }
    //protected void GVDE_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    string str = "";


    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        count++;
    //        str = count.ToString();
    //        ((Label)e.Row.FindControl("lblSrNo")).Text = str;

    //    }
    //}
}
