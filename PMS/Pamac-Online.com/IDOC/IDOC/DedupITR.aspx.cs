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
using System.IO;


public partial class IDOC_IDOC_DedupITR : System.Web.UI.Page
{
    CIDOC objIDoc = new CIDOC();  // Declaration of object 'objIDoc'
    protected void Page_Load(object sender, EventArgs e)
    {
        lblName.Text = "Dedup search for" + Request.QueryString["First_Name"].ToString() + " " + Request.QueryString["Last_Name"].ToString() + " " + Request.QueryString["Pan_No"].ToString();

        DataSet ds = new DataSet();

        ds = objIDoc.DedupITR(Request.QueryString["First_Name"], Request.QueryString["Last_Name"], Request.QueryString["Pan_No"]);
        if (ds.Tables[0].Rows.Count <= 0)
        {
            lblmsg.Text = "No record found";
            btnExport.Visible = false;
        }
        else
        {
            gvDedup.DataSource = ds;
            gvDedup.DataBind();
        }

    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        string attachment = "attachment; filename=dedup.xls";
        Response.Clear();
        Response.ClearHeaders();
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();

        HtmlTextWriter htw = new HtmlTextWriter(sw);

       gvDedup.RenderControl(htw);
       gvDedup.GridLines = GridLines.Both;
        Response.Write(sw.ToString());
        Response.End(); 
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }
}