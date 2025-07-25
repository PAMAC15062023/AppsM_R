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

public partial class QueryBuilder_PreDefinedMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count == 0)
            Response.Redirect("~/Index.aspx?Message=Session expired.Please select the zone again.");
        if (!IsPostBack)
        {
            string UserId = Session["UserId"].ToString();
            C_QueryBuilderMenu obj = new C_QueryBuilderMenu();
            DataTable dt = new DataTable();
            dt = obj.GetMenu(UserId);
           // Menu1.Items.Add(new MenuItem("Pre Defined Reports"));
            

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strMnuName = dt.Rows[i]["Query_Defination"].ToString();
                string strUrl = dt.Rows[i]["Page_Url"].ToString();
                // MenuItem mnMenuItem = new MenuItem();
                MenuItem mnMenuItem = new MenuItem(strMnuName, strMnuName, "", strUrl);
                Menu1.Items[0].ChildItems.Add(mnMenuItem);

            }
            int it = Menu1.Items[0].ChildItems.Count;
            dt.Clear();
            dt.Dispose();

        }

    }
}
