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

public partial class InvalidRequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["AuthToken"] != null)
        {
            Label1.Text = Request.Cookies["AuthToken"].Value;
        }
        Session.Abandon();
    }
    protected void lnkLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Index.aspx", false);
    }
}
