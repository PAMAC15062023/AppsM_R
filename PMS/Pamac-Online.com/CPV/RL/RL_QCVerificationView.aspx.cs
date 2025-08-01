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

public partial class RL_QCVerificationView : System.Web.UI.Page
{
    CRL_VisitVerification objRL = new CRL_VisitVerification();

    protected void Page_Load(object sender, EventArgs e)
    {

        CCommon objConn = new CCommon();
        sdsVerifyType.ConnectionString = objConn.ConnectionString;  //Sir

        if (Session["CaseID"] != null)
        {
            if (txtCaseId.Text == "")
                txtCaseId.Text = Session["CaseID"].ToString();
        }
        if (!IsPostBack)
        {
            if (Session["isView"].ToString() != "1")
                Response.Redirect("NoAccess.aspx");

            lblMsg.Visible = false;
            txtCaseId.Focus();
            if (Context.Request.QueryString["Msg"] != null && Context.Request.QueryString["Msg"] != "")
            {
                //lblMsg.Visible = true;
                //lblMsg.Text = Request.QueryString["Msg"].ToString();

                lblMsg.ForeColor = System.Drawing.Color.Yellow;
                lblMsg.BackColor = System.Drawing.Color.Black;
                lblMsg.Font.Bold = true;
                lblMsg.Visible = true;
                lblMsg.Text = "&nbsp;" + Request.QueryString["Msg"].ToString();

                //if (objRL.IsVerificationComplete(txtCaseId.Text.ToString(), Session["ClientId"].ToString(), Session["CentreId"].ToString()) == "true")
                //{
                //    objRL.VerificationComplete(txtCaseId.Text.ToString());
                //    lblMsg.Text += " Case verification data entry completed.";
                //}
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
        int blnN = 0;
        string sCaseId = txtCaseId.Text.Trim();
        Session.Remove("CaseID");
        Session["CaseID"] = txtCaseId.Text.Trim();
        string sVerifyType = ddlVerifyType.SelectedValue.ToString();
        string sClientId = Session["ClientId"].ToString();
        string sCentreId = Session["CentreId"].ToString();
        
        OleDbDataReader oledbRead;
        oledbRead = objRL.GetQCVerificationDetail(sCaseId, sVerifyType, sClientId, sCentreId);
        
        OleDbDataReader oledbReadFEId;
        oledbReadFEId = objRL.GetVerifierID(sCaseId, sVerifyType);
        if (oledbReadFEId.Read() == true)
        {
            hdnFEID.Value = oledbReadFEId["FE_ID"].ToString();
        }
        if (hdnFEID.Value.Trim() != "")
        {
            if (oledbRead.Read() == true)
            {
                switch (sVerifyType)
                {
                    case "25":   //RV
                            Response.Redirect("RL_QCResidenceVerification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType + "&VerifierId=" + hdnFEID.Value);
                            blnN = 1;                       
                            break;
                    case "10":  //PRV                        
                            Response.Redirect("RL_QCResidenceVerification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType + "&VerifierId=" + hdnFEID.Value);
                            blnN = 1;                        
                            break;
                    case "26":  //BV                        
                            Response.Redirect("RL_QCBusinessVerification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType + "&VerifierId=" + hdnFEID.Value);
                            blnN = 1;                        
                            break;
                    case "14":    //RCB                        
                        Response.Redirect("RL_ResiCumBusiness.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType + "&VerifierId=" + hdnFEID.Value);
                            blnN = 1;                        
                            break;
                }
            }
        }
        else
        {
            if (oledbRead.Read() == true)
            {
                if (sVerifyType == "28")     //BT
                {
                    Response.Redirect("RL_QCBusinessTelephonicVerification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType);
                    blnN = 1;
                }
                else if (sVerifyType == "27")      //RT
                {
                    Response.Redirect("RL_QCResidenceTelephonicVerification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType);
                    blnN = 1;
                }
                else if (sVerifyType == "29" || sVerifyType == "30")      //Ref1
                {
                    Response.Redirect("RL_QCTeleResidenceVerification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType);
                    blnN = 1;
                }
                else if (sVerifyType == "13")      //Ref2
                {
                    Response.Redirect("RL_REF2Verification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType);
                    blnN = 1;
                }
            }
        }


        if (blnN == 0)
        {
            lblMsg.Visible = true;
            lblMsg.ForeColor = System.Drawing.Color.Red;
            lblMsg.Text = "No record found.";
        }
        oledbReadFEId.Close();
        oledbRead.Close();
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
