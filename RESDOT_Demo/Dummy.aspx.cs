using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;



namespace RESDOT
{
    public partial class Dummy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int menuid = Convert.ToInt32(Request.QueryString["menuid"]);
            string menuname = (Request.QueryString["menuname"]);
            string activityid = Session["ActivityId"].ToString();

            //Response.Redirect("Mysample.aspx?menuid=11&menuname= FE Assignment&Activityid=13", false);
            Response.Redirect("Mysample.aspx?menuid="+menuid+"&menuname= "+ menuname+"&Activityid= "+ activityid, false);


            return;

        }
    }
}




  

    

