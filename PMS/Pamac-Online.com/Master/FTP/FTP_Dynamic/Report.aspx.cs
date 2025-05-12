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

public partial class FTP_FTP_Dynamic_Report : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count == 1)
        {
            string[] arr = new string[1];
            arr[0] = Request.QueryString["1"];         
             
            string ReportPath = String.Concat("FTP_RenderPage.aspx?1=", arr[0].ToString());

            IFrame1.Attributes.Add("src", ReportPath);



        }
    }
}
