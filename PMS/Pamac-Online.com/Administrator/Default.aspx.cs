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


public partial class CC_Default : System.Web.UI.Page
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

        string strRole = Session["RoleID"].ToString();
        string[] strRole1 = strRole.Split(',');
        string Allow = "0";


        foreach (string str in strRole1)
        {

            if (str == "1")
            {
                Allow = "1";
            }

        }

        if (Allow == "0")
        {
            Session.Abandon();
            Response.Redirect("~/InvalidRequest.aspx");
        }
                 
    }
}
