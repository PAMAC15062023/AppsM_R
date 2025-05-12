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
using System.Web.Mail;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;

public partial class ChangePassword : System.Web.UI.Page
{

    void Page_Init(object sender, EventArgs e)
    {
        ViewStateUserKey = Session.SessionID;
        Session.Timeout = 240;
        if (Session.Count == 0)
        {
            Session.Abandon();
            Response.Redirect("~/InvalidRequest.aspx");
        }


    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Request.QueryString["Err"] != null)
            {
                lblMsg.Visible = true;
                lblMsg.CssClass = "ErrorMessage";
                lblMsg.Text = Request.QueryString["Err"].ToString();
                btnLogin.Visible = true;
                btnCancel.Visible = false;
            }
            else
            {
                btnLogin.Visible = false;
                btnCancel.Visible = true;
            }
        }


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            //  bool isValid = ucCaptcha.Validate(txtCaptcha.Text.Trim());
            //isValid = true;
            //if (isValid)

            string result = txtCaptcha.Text;

            if (result == Session["CaptchaValue"].ToString())
            {
                CChangePwd objChange = new CChangePwd();
                objChange.NewPwd = txtNewPwd.Text;
                objChange.OldPwd = txtOldPwd.Text;
                objChange.UserId = Session["UserId"].ToString();
                objChange.UserAuthenticate();
                if (objChange.Status == "1")
                {
                    CLogin objLogin = new CLogin();

                    objLogin.UserId = Session["UserId"].ToString();
                    objLogin.CentreId = Session["CentreId"].ToString();
                    //objLogin.LogId = Session["LogId"].ToString();
                    objLogin.RoleId = Session["RoleId"].ToString();

                    objLogin.InsertLoginDetail_ChangePass();
                    Session["LogID"] = objLogin.LogId;

                    lblMsg.Visible = true;
                    lblMsg.CssClass = "UpdateMessage";
                    lblMsg.Text = "Password has been reset,Please login Again!";
                    btnCancel.Visible = false;
                    btnLogin.Visible = true;
                    txtNewPwd.ReadOnly = true;
                    txtOldPwd.ReadOnly = true;
                    txtConfirmPwd.ReadOnly = true;
                    btnSave.Enabled = false;
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.CssClass = "ErrorMessage";
                    lblMsg.Text = "Wrong Old Password";
                }
            }
            else
            {
                lblMessage.Text = "Invalid!";
                lblMessage.ForeColor = Color.Red;
                txtCaptcha.Text = "";
            }

        }
        catch (Exception exp)
        {
            lblMsg.Visible = true;
            lblMsg.CssClass = "ErrorMessage";
            lblMsg.Text = exp.Message;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrganizationTree.aspx");

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx?zone=" + HttpContext.Current.Session["Zone"]);
    }
}
