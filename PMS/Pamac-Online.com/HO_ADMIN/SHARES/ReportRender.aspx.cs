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
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Web.Services.Protocols;


public partial class HO_ADMIN_SHARES_ReportRender : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count == 0)
        {
            Response.Redirect("~/Index.aspx?Message=Session expired.Please select the zone again.");
        }
        else
        {
            if (Request.QueryString.Count == 5)
            {

                string[] arr = new string[5];
                arr[0] = Request.QueryString["1"];
                arr[1] = Request.QueryString["2"];
                arr[2] = Request.QueryString["3"];
                arr[3] = Request.QueryString["4"];
                arr[4] = Request.QueryString["5"];

                
                Render_Local_Report(arr);
                Page.Header.Title = "PAMAC Share Certificate";

            }
        }
    }
    private void Render_Local_Report(string[] Param)
    {
        Microsoft.Reporting.WebForms.ReportViewer rview = new Microsoft.Reporting.WebForms.ReportViewer();


        string fullSitePath = this.Request.PhysicalApplicationPath;
        fullSitePath = fullSitePath + "HO_ADMIN\\SHARES\\Reports\\ShareCertificate.rdlc";

        string URL = fullSitePath  ;
        rview.LocalReport.ReportPath = URL.ToString();

        System.Collections.Generic.List<Microsoft.Reporting.WebForms.ReportParameter> paramList = new System.Collections.Generic.List<Microsoft.Reporting.WebForms.ReportParameter>();

        ReportParameter[] RptParameters = new ReportParameter[5];
        RptParameters[0] = new ReportParameter("ShareHolderName", Param[0]);
        RptParameters[1] = new ReportParameter("Folio_No", Param[1]);
        RptParameters[2] = new ReportParameter("Certificate_No", Param[2]);
        RptParameters[3] = new ReportParameter("No_of_Shares_Text", Param[3]);
        RptParameters[4] = new ReportParameter("Dist_No", Param[4]);

        rview.LocalReport.SetParameters(RptParameters);

        string mimeType, encoding, extension, deviceInfo;

        string[] streamids;
        Microsoft.Reporting.WebForms.Warning[] warnings;

        string format = "PDF"; //Desired format goes here (PDF, Excel, or Image)
        deviceInfo = 
            "<DeviceInfo>" +
            "  <OutputFormat>PDF</OutputFormat>" +
            "  <PageWidth>8.5in</PageWidth>" +
            "  <PageHeight>8.5in</PageHeight>" +
            "  <MarginTop>0.5in</MarginTop>" +
            "  <MarginLeft>1in</MarginLeft>" +
            "  <MarginRight>1in</MarginRight>" +
            "  <MarginBottom>0.5in</MarginBottom>" +
            "</DeviceInfo>";//"<DeviceInfo>" + "<SimplePageHeaders>True</SimplePageHeaders>" + "</DeviceInfo>";
        byte[] bytes = rview.LocalReport.Render(format, deviceInfo, out mimeType, out encoding, out extension, out streamids, out warnings);
        Response.Clear();

        if (format == "PDF")
        {

            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-disposition", "filename=output.pdf");

        }
        else if (format == "Excel")
        {

            Response.ContentType = "application/excel";
            Response.AddHeader("Content-disposition", "filename=output.xls");


        }
        else if (format == "Image")
        {

            Response.ContentType = "image/tiff";
            Response.AddHeader("Content-disposition", "filename=output.tif");

        }

        Response.OutputStream.Write(bytes, 0, bytes.Length);
        Response.OutputStream.Flush();
        Response.OutputStream.Close();
        Response.Flush();
        Response.Close();
    }
}
