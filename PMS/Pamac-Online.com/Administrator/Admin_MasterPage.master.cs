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

public partial class Administrator_Admin_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Init(object sender, EventArgs e)
    {

        
    }

    protected void Page_Load(object sender, EventArgs e)
    {

                 
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        CLogin objLogin = new CLogin();
        objLogin.UpdateLogoutTime();


        Session.Abandon();
        Session.Clear();
        Response.Redirect("~/Welcome.aspx");
    }
}
