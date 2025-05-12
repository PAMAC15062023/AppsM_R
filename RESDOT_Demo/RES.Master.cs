using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RESDOT
{
    public partial class RES : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Fetch username from session
                if (Session["fullName"] != null)
                {
                    lblUsername.Text = Session["fullName"].ToString();
                }
                else
                {
                    lblUsername.Text = "Guest"; // Default if not logged in
                }
            }
        }
    }
}