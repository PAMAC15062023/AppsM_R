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

public partial class QueryBuilder_QueryBuilder : System.Web.UI.MasterPage
{
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0)
        {

            Response.Redirect("~/Index.aspx?Message=Session expired.Please select the zone again.");

            //if(Session["RoleId"].ToString()!="1")
            //    Response.Redirect("../OrganizationTree.aspx?Message='Access Denied.'");
        }
        CLogin objLogin = new CLogin();
        objLogin.UpdateLogoutTime();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            string UserId = Session["UserId"].ToString();
            C_QueryBuilderMenu obj = new C_QueryBuilderMenu();
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            dt = obj.GetMenu(UserId);
            dt1 = obj.GetMenu1(UserId);
            dt2 = obj.GetMenu2(UserId);

            // Menu1.Items.Add(new MenuItem("Pre Defined Reports"));
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string strMnuName = dt.Rows[i]["Query_Defination"].ToString();
                    string strUrl = dt.Rows[i]["Page_Url"].ToString();
                    // MenuItem mnMenuItem = new MenuItem();
                    MenuItem mnMenuItem = new MenuItem(strMnuName, strMnuName, "", strUrl);
                    Menu1.Items[0].ChildItems.Add(mnMenuItem);

                }
            }
            int it = Menu1.Items[0].ChildItems.Count;
           
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    string strMnuName = dt1.Rows[i]["Query_Defination"].ToString();
                    string strUrl = dt1.Rows[i]["Page_Url"].ToString();
                    // MenuItem mnMenuItem = new MenuItem();
                    MenuItem mnMenuItem = new MenuItem(strMnuName, strMnuName, "", strUrl);
                    Menu1.Items[2].ChildItems.Add(mnMenuItem);

                }
            }
            
            int it1 = Menu1.Items[2].ChildItems.Count;
            int it2 = Menu1.Items[3].ChildItems.Count;
            
            {
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    string strMnuName = dt2.Rows[i]["Query_Defination"].ToString();
                    string strUrl = dt2.Rows[i]["Page_Url"].ToString();
                    // MenuItem mnMenuItem = new MenuItem();
                    MenuItem mnMenuItem = new MenuItem(strMnuName, strMnuName, "", strUrl);
                    Menu1.Items[3].ChildItems.Add(mnMenuItem);

                }
            }

            dt.Clear();
            dt.Dispose();

            dt1.Clear();
            dt1.Dispose();

            dt2.Clear();
            dt2.Dispose();

        }
    }
}
