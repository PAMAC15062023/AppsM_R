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

public partial class CPV_Cellular_CellularFEWiseSearch : System.Web.UI.Page
{
    CCommon con = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {

        CCommon objConn = new CCommon();
        sdsCaseType.ConnectionString = objConn.ConnectionString;  //Sir

        if (Session["isView"].ToString() != "1")
        Response.Redirect("NoAccess.aspx");
        lblMsg.Text = "";
        txtFromDate.Focus();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bool isValidDates = true;
        if (txtFromDate.Text.Trim() != "" && txtToDate.Text.Trim() != "")
        {
            DateTime dtFrom;
            DateTime dtTo;
            dtFrom = Convert.ToDateTime(con.strDate(txtFromDate.Text.Trim()));
            dtTo = Convert.ToDateTime(con.strDate(txtToDate.Text.Trim()));

            if (dtFrom > dtTo)
            {
                isValidDates = false;
                lblMsg.Visible = true;
                lblMsg.Text = "From date must be less than to date.";
            }
        }
        if (isValidDates)
        {
            string sFromDate;
            string sToDate;
            string sClientID;
            string sCentreID;
            CReport objReport = new CReport();
            DataSet dsFEReport = new DataSet();

            string Tdate;
            Tdate = Convert.ToDateTime(con.strDate(txtToDate.Text)).AddDays(1.0).ToString("dd-MMM-yyyy");
            objReport.CaseType = ddlCaseType.SelectedValue.ToString();
            dsFEReport = objReport.CELL_Fewise_Report(con.strDate(txtFromDate.Text.Trim()), Tdate, Session["ClientId"].ToString(), Session["CentreId"].ToString());

            if (dsFEReport.Tables[0].Rows.Count > 0)
            {
                dsFEReport.Tables[0].TableName = "FEWiseSearch";
                Session["dataset"] = dsFEReport;

                //Session["datasetHead"] = dsPendingListHead;
                Session["Path"] = Server.MapPath("CEL_FeWise_Report.rpt");
                Session.Remove("ParameterCollection");
                Response.Redirect("../../CrystalReportviewer.aspx?bckPgURL=CPV\\Cellular\\CellularFEWiseSearch.aspx");
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Record not found.";
            }
        }

    }
    protected void ddlCaseType_DataBound(object sender, EventArgs e)
    {
        ddlCaseType.Items.Insert(0, new ListItem("All", "0"));
    }
}
