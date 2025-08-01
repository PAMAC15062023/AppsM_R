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

public partial class IDOC_IDOC_IDOC_FEAutoAssignment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CCommon objConn = new CCommon();
        sdsVeriType.ConnectionString = objConn.ConnectionString;  //Sir
    }
    protected void btnFEAutoAssignmet_Click(object sender, EventArgs e)
    {
        try
        {
            CImport oImport = new CImport();
            CCommon objCmn = new CCommon();
            string Tdate;
            Tdate = Convert.ToDateTime(objCmn.strDate(txtToDate.Text.Trim())).AddDays(1.0).ToString("dd-MMM-yyyy");

            lblMsg.Visible = true;
            lblMsg.Text = oImport.FEAutoAssignment_IDOC(objCmn.strDate(txtFromDate.Text.Trim()), Tdate,
                                ddlType.SelectedValue.ToString(), Session["ClientId"].ToString(), Session["CentreId"].ToString());

        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error while FE AutoAssignment: " + ex.Message;
        }
    }
}
