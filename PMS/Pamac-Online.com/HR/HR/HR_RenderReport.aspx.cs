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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

public partial class HR_HR_HR_RenderReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int arr = Convert.ToInt32(Request.QueryString["1"]);
       

        GenrateReport("PaySlip.rpt", arr); 
    }

    private void GenrateReport(string ReportPath, int UID)
    {
        CReport objReport = new CReport();
        string repFilePath = Server.MapPath(ReportPath);
        ReportDocument repDoc = new ReportDocument();
        repDoc.Load(repFilePath);

        //repDoc.SetDataSource(objReport.GetHrPaySlip(UID.ToString()));

        
        DataTable dtNew=new DataTable("Pay_Slip"); 

        dtNew=objReport.GetHrPaySlip(UID.ToString());

        repDoc.SetDataSource(dtNew);
        //Pay_Slip
    
            Response.Buffer = false;
            
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                repDoc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Pay_Slip");                
                
             //repDoc.ExportToStream(ExportFormatType.PortableDocFormat).;           
                
                //byte[] bytes=((System.IO.MemoryStream)(repDoc.ExportToStream(ExportFormatType.PortableDocFormat))).GetBuffer();


                //Response.ContentType = "application/pdf" ;
                //Response.AddHeader("Content-disposition", "filename=Pay_Slip.pdf");

                //Response.OutputStream.Write(bytes, 0, bytes.Length);
              
                //Response.OutputStream.Flush();
                //Response.OutputStream.Close();
                //Response.Flush();
                //Response.Close();

               // MemoryStream oStream; // using System.IO
               // oStream = (MemoryStream)
               // repDoc.ExportToStream(
               // CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

               // Response.Clear();
               // Response.Buffer = true;
               // Response.ContentType = "application/pdf";
               // Response.AddHeader("Content-disposition", "filename=Pay_Slip.pdf");
               
               // //Response.BinaryWrite(oStream.ToArray());
               // //Response.End();
               // //Response.Close();

               //// Response.OutputStream.Write(oStream.ToArray(), 0, oStream.ToArray().Length);
               // Response.BinaryWrite(oStream.ToArray());
               // Response.OutputStream.Flush();
               // Response.OutputStream.Close();
               // Response.Flush();
               // Response.Close();
            }
            
           


            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                ex = null;
            }
    }

    //private ReportDocument getReportDocument(string ReportPath,int UID)
    //{
    //    CReport objReport = new CReport();
    //    string repFilePath = Server.MapPath(ReportPath);
    //    ReportDocument repDoc = new ReportDocument();
    //    repDoc.Load(repFilePath);
    //    repDoc.SetDataSource(objReport.GetHrPaySlip(UID.ToString()));   

    //}

 
}
