using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pamac_Projects
{
    public partial class PP_download : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string mesg = "";
            Response.Redirect("PP_ActivityDetails.aspx?msg=" + mesg, false);
            String filename = Request.QueryString["file"];
            String pathOfFile = Server.MapPath("~/Uploadedfiles/" + filename);
            if (File.Exists(pathOfFile))
            {
                byte[] bts = System.IO.File.ReadAllBytes(pathOfFile);
                Response.Clear();
                Response.ClearHeaders();
                Response.AddHeader("Content-Type", "Application/octet-stream");
                Response.AddHeader("Content-Length", bts.Length.ToString());
                Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                Response.BinaryWrite(bts);
                Response.Flush();
                Response.End();
            }
            else
            {
                 mesg = "Spefified file does not exist";
                Response.Redirect("PP_ActivityDetails.aspx?msg=" + mesg, false);

                     //  Response.Redirect("Mysample.aspx?menuid=" + menuid + "&menuname= " + menuname + "&Activityid =" + activityid, false);
                     //Console.WriteLine("Specified file does not " +
                     //          "exist in the current directory.");
            }





        }
    }
}