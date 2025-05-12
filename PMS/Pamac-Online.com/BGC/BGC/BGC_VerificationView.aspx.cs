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

public partial class BGC_BGC_BGC_VerificationView : System.Web.UI.Page
{
    //EBC_Verification OnjEBC = new EBC_Verification();
    BGC OnjEBC = new BGC();

    string sVerifyType;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["isView"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");

        if (Session["CaseID"] != null)
        {
            if (txtCaseId.Text == "")
                txtCaseId.Text = Session["CaseID"].ToString();
        }

        lblMsg.Visible = false;
        txtCaseId.Focus();
        if (!IsPostBack)
        {
            if (Context.Request.QueryString["Msg"] != null && Context.Request.QueryString["Msg"] != "")
            {
                lblMsg.ForeColor = System.Drawing.Color.Yellow;
                lblMsg.BackColor = System.Drawing.Color.Black;
                lblMsg.Font.Bold = true;
                lblMsg.Visible = true;
                lblMsg.Text = "&nbsp;" + Request.QueryString["Msg"].ToString();


            }
            else
            {
                lblMsg.Text = "";
                lblMsg.Visible = false;
            }

        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            int blnN = 0;
            string sCaseId = txtCaseId.Text.Trim();
            Session.Remove("CaseID");
            Session["CaseID"] = txtCaseId.Text.Trim();

            string sClientId = Session["ClientId"].ToString();
            string sCentreId = Session["CentreId"].ToString();

            //OleDbDataReader oledbRead;
            //oledbRead = OnjEBC.GetVerificationDetailBGC(sCaseId, sClientId, sCentreId);
            DataSet ds1 = new DataSet();
            ds1 = OnjEBC.GetVerificationDetailBGC(sCaseId, sClientId, sCentreId);

            ////OleDbDataReader oledbReadFEId;
            ////oledbReadFEId = OnjEBC.GetVerifierIDBGC(sCaseId);

            DataSet ds = new DataSet();
            ds = OnjEBC.GetVerifierIDBGC(sCaseId);

            ////if (oledbReadFEId.Read() == true)
            ////{
            ////    hdnFEID.Value = oledbReadFEId["FE_ID"].ToString();
            ////}

            if (ds.Tables[0].Rows.Count > 0)
            {

                hdnFEID.Value = ds.Tables[0].Rows[0]["FE_ID"].ToString();
            }



            ////if (oledbRead.Read() == true)
            ////{
            ////    sVerifyType = oledbRead["Verification_type_id"].ToString();
            ////}

            if (ds1.Tables[0].Rows.Count > 0)
            {
                sVerifyType = ds1.Tables[0].Rows[0]["Verification_type_id"].ToString();

            }



            if (hdnFEID.Value.Trim() != "")
            {
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    //  Response.Redirect("CC_ResidenceVerification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType + "&VerifierId=" + hdnFEID.Value);


                    Response.Redirect("BGC_Verification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType + "&VerifierId=" + hdnFEID.Value);
                    blnN = 1;

                }
            }
            if (blnN == 0)
            {
                lblMsg.Visible = true;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "No record found.";
            }
            //oledbReadFEId.Close();
            //oledbRead.Close();
        }
        catch (Exception ed)
        {
        }
    }
    protected void cvSelectVerifyType_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (source.ToString() == "0")
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Please select verification Type.";
        }
    }
}
