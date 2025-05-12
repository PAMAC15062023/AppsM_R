using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineTest
{
    public partial class UserMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            String roleid = Session["RoleID"].ToString();

            if (roleid == "3")
            {
                givexam.Visible = true;
                qnMaster.Visible = false;
                qnPaper.Visible = false;
                setqnPaper.Visible = false;
                Aexaminees.Visible = false;
                examreport.Visible = false;
                ClientMaster.Visible = false;
                DesignationMaster.Visible = false;
                ProductMaster.Visible = false;
                LevelMaster.Visible = false;
                TypeMaster.Visible = false;
            }
            else
            {
                givexam.Visible = false;
                qnMaster.Visible = true;
                qnPaper.Visible = true;
                setqnPaper.Visible = true;
                Aexaminees.Visible = true;
                examreport.Visible = true;
                ClientMaster.Visible = true;
                DesignationMaster.Visible = true;
                ProductMaster.Visible = true;
                LevelMaster.Visible = true;
                TypeMaster.Visible = true;
            }

        }
        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("LoginPage.aspx", false);
        }

        protected void lnkChangePassword_Click(object sender, EventArgs e)
        {
            //Response.Redirect("ChangePassword.aspx", false);
            lblMsgXls.Text = "Please change password in Calculas....!";

        }
    }
}