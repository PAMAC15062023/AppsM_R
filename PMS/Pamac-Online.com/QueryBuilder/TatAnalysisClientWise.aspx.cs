using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using System.Configuration.Assemblies;

public partial class QueryBuilder_TatAnalysisClientWise : System.Web.UI.Page
{
    public DataTable dtMIS = new DataTable();
    C_QueryBuilderTAT obj = new C_QueryBuilderTAT();
    public string CenterId = "";
    public string ClientId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //Description   :  This Code is used To distingusish Repository PMS Database and PMS.
        //Created By    :  Gargi Srivastava
        //Created On    :  23-Nov-2007
        Session["DataBase"] = ddlDataBase.SelectedValue.ToString();
        //End Of Code
        if (!IsPostBack)
        {
            try
            {
                if (Session["UserId"].ToString() != "" || Session["UserId"].ToString()!=null)
                {
                    string UserId = Session["UserId"].ToString();
                    CenterId = obj.GetCenter(UserId);
                    ClientId = obj.GetClientId(CenterId);
                    ViewState["ClientId"] = ClientId;
                    ViewState["CenterId"] = CenterId;
                }
            }
            catch (Exception ex)
            {
                LblMsg.Visible = true;
                LblMsg.Text = ex.Message.ToString();
            }
        }
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        CCommon ObjCmn = new CCommon();
        try
        {
            obj.FromDate = ObjCmn.string_mm_dd_yy(txtFromDate.Text);
            string TDate = ObjCmn.string_mm_dd_yy(txtToDate.Text);
            string ToDate = Convert.ToDateTime(TDate).AddDays(1.0).ToString("dd/MM/yyyy");
            obj.ToDate = ObjCmn.string_mm_dd_yy(ToDate);

            DataTable dt = new DataTable();
            dt= obj.rptClient_CentreWise(ViewState["ClientId"].ToString(), ViewState["CenterId"].ToString());
            if (dt.Rows.Count > 0)
            {
                tbl.Visible = true;
                gvClientWise.DataSource = dt;
                gvClientWise.DataBind();

                lblFromDate.Text = txtFromDate.Text;
                lblToDate.Text = txtToDate.Text;
                gvExport.DataSource = dt;
                gvExport.DataBind();
            }
            else
            {
                tbl.Visible = true;
                gvClientWise.DataSource = "";
                gvClientWise.DataBind();
            }

        }
        catch (Exception ex)
        {
            LblMsg.Visible = true;
            LblMsg.Text= ex.Message.ToString();
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        tblExport.Visible = true;
        string attachment = "attachment; filename=TAT Analysis ClientWise.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();

        HtmlTextWriter htw = new HtmlTextWriter(sw);

        //gvTATMIS.RenderControl(htw);
        gvExport.GridLines = GridLines.Both;
        tblExport.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End(); 
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("TatAnalysisClientWise.aspx");
    }
}
