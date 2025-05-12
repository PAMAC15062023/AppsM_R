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

public partial class Index : System.Web.UI.Page
{
    void Page_Init(object sender, EventArgs e)
    {
        ViewStateUserKey = Session.SessionID;

      
    } 


    protected void Page_Load(object sender, EventArgs e)
    {


        //string visitorIPAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];


        //if (String.IsNullOrEmpty(visitorIPAddress))
        //    visitorIPAddress = Request.ServerVariables["REMOTE_ADDR"];

        //if (string.IsNullOrEmpty(visitorIPAddress))
        //    visitorIPAddress = Request.UserHostAddress;

        //Label1.Visible = true;
        //Label1.Text = visitorIPAddress.ToString();

       
        // May not work if behind FireWall or using Proxy
        Label1.Text = Request.UserHostName.ToString();

   
        string strIpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (strIpAddress == null)
        {
            Label1.Text = Request.ServerVariables["REMOTE_ADDR"];
        }

        if (Request.QueryString["Message"] != null)
        {
            lblMsg.Text = Request.QueryString["Message"].ToString();
        }
    }
}
