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

public partial class CPV_RL_RL_ViewCase : System.Web.UI.Page
{
    
    CRL_CaseEntry ObjRL = new CRL_CaseEntry();
    CCommon objCmn = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {

        CCommon objConn = new CCommon();
        sdsRL.ConnectionString = objConn.ConnectionString;  //Sir
       
        txtRefNo.Focus();
        if (Session["isView"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");
        //if (Session["isDelete"].ToString() != "1")
        //    Response.Redirect("NoAccess.aspx");

        lblMsg.Visible = false;
        if (Context.Request.QueryString["Msg"] != null && Context.Request.QueryString["Msg"] != "")
        {
            lblMsg.Visible = true;
            lblMsg.Text = Request.QueryString["Msg"].ToString();
        }
        else
        {
            lblMsg.Text = "";
        }
    }
    protected void gvRL_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet dsRL = new DataSet();
        DataSet dsVerification = new DataSet();

        string sCaseId = e.CommandArgument.ToString();
        if (e.CommandName == "Edit")
        {

            if (sCaseId != "")
            {
                Response.Redirect("RL_CaseEntry.aspx?CaseID=" + sCaseId);
                //Response.Redirect("Default2.aspx?CaseID=" + sCaseId);
            }
        }
        if (e.CommandName == "DeleteRL")
        {

            if (ObjRL.DeleteRLCaseEntry(sCaseId) == 1)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Record deleted successfully.";
            }
        }
        sdsRL.SelectCommand = ObjRL.GetRLCaseEntry(Session["CentreId"].ToString(), Session["ClientId"].ToString());
    }
    protected void gvRL_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton l = (LinkButton)e.Row.FindControl("lnkDeleteCreditCard");
            l.Attributes.Add("onclick", "javascript:return " +
                          "confirm('Are you sure you want to delete this record')");
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        lblMsg.Visible = false;
        if (chkName.Checked == true)
        {
            sdsRL.SelectCommand = ObjRL.GetRLCaseEntry(txtRefNo.Text.Trim(), txtName.Text.Trim(), true, txtFromDate.Text.Trim(), txtToDate.Text.Trim(), Session["CentreId"].ToString(), Session["ClientId"].ToString());
        }
        else
        {
            sdsRL.SelectCommand = ObjRL.GetRLCaseEntry(txtRefNo.Text.Trim(), txtName.Text.Trim(), false, txtFromDate.Text.Trim(), txtToDate.Text.Trim(), Session["CentreId"].ToString(), Session["ClientId"].ToString());
        }
        gvRL.DataBind();
        if (gvRL.Rows.Count == 0)
        {
            lblMsg.Visible = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "Record not found.";
        }
    }
    protected void btnNewCase_Click(object sender, EventArgs e)
    {
        Response.Redirect("RL_CaseEntry.aspx");
    }
}
