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
using myInfo;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Info obj = new Info();
            CLogin objLogin = new CLogin();
            objLogin.UpdateLogoutTime();
            //obj.UpdateTokenDetail();


            Session.Abandon();
            Session.Clear();
            Response.Redirect("Welcome.aspx");

        }
        catch (Exception ex)
        {
        }
        finally
        {
        }
    }
}
