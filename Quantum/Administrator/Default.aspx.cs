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
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count==0)
            Response.Redirect("~/Index.aspx?Message=Session expired.Please select the zone again.");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
}
