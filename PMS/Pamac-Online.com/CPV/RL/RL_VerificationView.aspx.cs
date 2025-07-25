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

public partial class RL_VerificationView : System.Web.UI.Page
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
        oledbRead = objRL.GetVerificationDetail(sCaseId, sVerifyType, sClientId, sCentreId);
        
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
                    case "1":   //RV
                            Response.Redirect("RL_ResidenceVerification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType + "&VerifierId=" + hdnFEID.Value);
                            blnN = 1;                       
                            break;
                    case "10":  //PRV                        
                            Response.Redirect("RL_ResidenceVerification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType + "&VerifierId=" + hdnFEID.Value);
                            blnN = 1;                        
                            break;
                    case "2":  //BV                        
                            Response.Redirect("RL_BusinessVerification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType + "&VerifierId=" + hdnFEID.Value);
                            blnN = 1;                        
                            break;
                    case "14":    //RCB                        
                        Response.Redirect("RL_ResiCumBusiness.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType + "&VerifierId=" + hdnFEID.Value);
                            blnN = 1;                        
                            break;
                        case "32":   //NOC
                            Response.Redirect("RL_ResidenceVerification_Noc.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType + "&VerifierId=" + hdnFEID.Value);
                            blnN = 1;
                            break;
                        case "31":   //Vend
                            Response.Redirect("RL_ResidenceVerification_Vend.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType + "&VerifierId=" + hdnFEID.Value);
                            blnN = 1;
                            break;
                        case "36":   //PV
                            Response.Redirect("RL_ResidenceVerification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType + "&VerifierId=" + hdnFEID.Value);
                            blnN = 1;
                            break;
                        //case "34":   //ITVR
                        //    Response.Redirect("RL_BusinessVerification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType + "&VerifierId=" + hdnFEID.Value);
                        //    blnN = 1;
                        //    break;
                        //case "35":   //SS
                        //    Response.Redirect("RL_SalarySlipVerification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType + "&VerifierId=" + hdnFEID.Value);
                        //    blnN = 1;
                        //    break;
                }
            }
        }
        else
        {
            if (oledbRead.Read() == true)
            {
                if (sVerifyType == "3")     //BT
                {
                    Response.Redirect("RL_BusinessTelephonicVerification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType);
                    blnN = 1;
                }
                else if (sVerifyType == "4")      //RT
                {
                    Response.Redirect("RL_ResidenceTelephonicVerification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType);
                    blnN = 1;
                }
                else if (sVerifyType == "12")      //Ref1
                {
                    Response.Redirect("RL_REF1Verification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType);
                    blnN = 1;
                }
                else if (sVerifyType == "13")      //Ref2
                {
                    Response.Redirect("RL_REF2Verification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType);
                    blnN = 1;
                }
                else if (sVerifyType == "34")      //ITVR
                {
                    Response.Redirect("RL_ITR.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType);
                    blnN = 1;
                }
                else if (sVerifyType == "35")      //SS
                {
                    Response.Redirect("RL_SalarySlipVerification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType);
                    blnN = 1;
                }
                else if (sVerifyType == "42")      //BK
                {
                    Response.Redirect("RL_BankStatementVerification.aspx?CaseID=" + sCaseId + "&VerTypeId=" + sVerifyType);
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
