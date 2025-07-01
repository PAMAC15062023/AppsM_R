using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using YesBank;

namespace Pamac_Projects
{
    public partial class ENAM : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //if (Session["UserName"] != null)
                //{
                 //   lblWelcome.Text = "ENAM";

                  //  lblUserName.Text = Session["UserName"] + " Pamac Branch:   " + Session["PamacBranch"];


                    //if (Session["RoleId"] != null)
                    //{
                    //    string RoleID = Convert.ToString(Session["RoleId"]);
                    //    string currentPageName = Request.Url.Segments[Request.Url.Segments.Length - 1];
                    //    RolePageAuth rpa = new RolePageAuth();
                    //    bool result = rpa.CheckRolePageAuth(RoleID, currentPageName.Trim());

                    //    if (!result)
                    //    {
                    //        Response.Redirect("YBL_AuthorizeFailed.aspx", false);
                    //    }
                    //}
                //}

                //else
                //{
                //    Session.Clear();
                //    Response.Redirect("YBL_OPS_LoginPage.aspx", false);
                //}
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    CommonMaster commonMaster = new CommonMaster();
                    int Result = commonMaster.UserLogOut(Convert.ToString(Session["LoginName"]));

                    if (Result == 1)
                    {
                        Session.Clear();
                        Response.Redirect("YBL_OPS_LoginPage.aspx", false);
                    }
                }
                else
                {
                    Session.Clear();
                    Response.Redirect("YBL_OPS_LoginPage.aspx", false);
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void lkbtnchangePassword_Click(object sender, EventArgs e)
        {
            //Response.Redirect("YBL_ChangePassword.aspx", false);
        }

        protected void lnkChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("YBL_OPS_ChnagePassWord.aspx", false);
        }
    }
}
