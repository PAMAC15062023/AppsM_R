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

public partial class KYC_KYC_CaseView : System.Web.UI.Page
{
    CKYC objKYC = new CKYC();

    protected void Page_Load(object sender, EventArgs e)
    {
        CCommon objConn = new CCommon();
        sdsKYC.ConnectionString = objConn.ConnectionString;  //Sir
       
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

    protected void gvKYC_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataSet dsKYC = new DataSet();        

        string sCaseId = e.CommandArgument.ToString();
        if (e.CommandName == "Edit")
        {

            if (sCaseId != "")
            {
                Response.Redirect("KYC_CaseEntry.aspx?CaseID=" + sCaseId);
            }
        }
        if (e.CommandName == "DeleteKYC")
        {
            if (objKYC.DeleteKYCCaseEntry(sCaseId) == 1)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Record deleted successfully.";
            }
        }
        sdsKYC.SelectCommand = objKYC.GetKYCCaseEntry(Session["CentreId"].ToString(), Session["ClientId"].ToString());
    }

    protected void gvKYC_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton l = (LinkButton)e.Row.FindControl("lnkDeleteKYC");
            l.Attributes.Add("onclick", "javascript:return " +
                          "confirm('Are you sure you want to delete this record')");
        }
    }
    //protected void btnSearch_Click(object sender, EventArgs e)
    //{
    //    //lblMsg.Text = "";
    //    //lblMsg.Visible = false;
    //    //if (chkName.Checked == true)
    //    //    sdsKYC.SelectCommand = objKYC.GetKYCCaseEntry(txtRefNo.Text.Trim(), txtName.Text.Trim(), true, txtFromDate.Text.Trim(), txtToDate.Text.Trim());
    //    //else
    //    //    sdsKYC.SelectCommand = objKYC.GetKYCCaseEntry(txtRefNo.Text.Trim(), txtName.Text.Trim(), false, txtFromDate.Text.Trim(), txtToDate.Text.Trim());
    //}

    protected void btnNewCase_Click(object sender, EventArgs e)
    {
        Response.Redirect("KYC_CaseEntry.aspx?CaseID=Add");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        objKYC.CentreId = Session["CentreID"].ToString();
        objKYC.ClientId = Session["ClientID"].ToString();
        lblMsg.Text = "";
        lblMsg.Visible = false;
        if (chkName.Checked == true)
            sdsKYC.SelectCommand = objKYC.GetKYCCaseEntry(txtRefNo.Text.Trim(), txtName.Text.Trim(), true, txtFromDate.Text.Trim(), txtToDate.Text.Trim());
        else
            sdsKYC.SelectCommand = objKYC.GetKYCCaseEntry(txtRefNo.Text.Trim(), txtName.Text.Trim(), false, txtFromDate.Text.Trim(), txtToDate.Text.Trim());

    }
}
