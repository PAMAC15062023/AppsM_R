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
using System.Text;
using System.IO;
using Microsoft.Office.Core;
using System.Configuration.Assemblies;
using CrystalDecisions.Shared;
using System.Drawing;
using System.Data.SqlClient;

public partial class DCR_DocCollection_CC_Dcr_Pickup_MIS : System.Web.UI.Page
{
    sup_remarks objq = new sup_remarks();
    CCommon objcon = new CCommon();
    DateTime dtfrom;
    DateTime dtto;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }

    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {

        bool isvaliddate = true;
        if (txtFDate.Text.Trim() == "" || txtTDate.Text.Trim() == "")
        {
            isvaliddate = false;
            lblMessage.Visible = true;
            lblMessage.Text = "Please Enter From Date And To Date";
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Font.Bold = true;
        }
        if (txtFDate.Text.Trim() != "" && txtTDate.Text.Trim() != "")
        {
            dtfrom = Convert.ToDateTime(objcon.strDate(txtFDate.Text.Trim()));
            dtto = Convert.ToDateTime(objcon.strDate(txtTDate.Text.Trim()));

            if (dtfrom > dtto)
            {
                isvaliddate = false;
                lblMessage.Visible = true;
                lblMessage.Text = "From Date must be less than To Date";
            }
        }
        if (isvaliddate == true)
        {
            lblMessage.Text = "";
            getsearch();
        }
    }

    protected void getsearch()
    {
        DataTable dt = new DataTable();

        string qry = "";

        qry = "exec Dcr_Pickup_MIS '" + Convert.ToDateTime(objcon.strDate(txtFDate.Text.Trim())).ToString("dd/MM/yyyy") + "','" + Convert.ToDateTime(objcon.strDate(txtTDate.Text.Trim())).ToString("dd/MM/yyyy") + "'";
        OleDbDataAdapter oledba = new OleDbDataAdapter(qry, objcon.ConnectionString);
        DataSet da = new DataSet();
        oledba.Fill(da, "Search");
        dt = da.Tables["Search"];

        if (dt.Rows.Count > 0)
        {
            gvtc.DataSource = dt;
            gvtc.DataBind();
            gvtc.Visible = true;
        }
        else
        {
            gvtc.Visible = false;
            lblMessage.Text = "Records Not Found!!!!!";
            lblMessage.Visible = true;

        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        getsearch();
        if (gvtc.Rows.Count > 0)
        {
            String attachment = "attachment; filename=PAMAC PDCR PickupMis.xls";
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
            tblCell1.Text = "<b><font size='3'>PAMAC FINSERVE PVT. LTD.</font></b> <br/>" +
                            "<b><font size='2'>PAMAC PDCR CoveringSheet FromDate : " + txtFDate.Text + " ToDate " + txtTDate.Text + "</font></b> <br/>";
            tblCell1.CssClass = "FormHeading";
            tblRow.Cells.Add(tblCell);
            tblRow1.Cells.Add(tblCell1);
            tblRow.Height = 20;
            tblSpace.Rows.Add(tblRow);
            tblSpace.Rows.Add(tblRow1);

            Table tbl = new Table();
            gvtc.EnableViewState = false;
            tblSpace.RenderControl(htw);
            gvtc.GridLines = System.Web.UI.WebControls.GridLines.Both;
            gvtc.RenderControl(htw);
            Response.Write(sw.ToString());

            Response.End();
        }
    }
}
