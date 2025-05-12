using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineTest
{
    public partial class OnlineTestMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    lblWelcome.Text = "ONLINE TEST";

                    lblUserName.Text = Session["UserName"] + " Loan Type:   " + Session["LoanType"];


                    if (Session["RoleId"] != null)
                    {
                        //string RoleID = Convert.ToString(Session["RoleId"]);
                        //string currentPageName = Request.Url.Segments[Request.Url.Segments.Length - 1];
                        ////RolePageAuth rpa = new RolePageAuth();
                        //bool result = rpa.CheckRolePageAuth(RoleID, currentPageName.Trim());

                        //if (!result)
                        //{
                        //    Response.Redirect("YBL_AuthorizeFailed.aspx", false);
                        //}
                    }
                }

                else
                {
                    Session.Clear();
                    Response.Redirect("LoginPage.aspx", false);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
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